using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Support.Extensions;
using Vt.Client.Core.Log;

namespace Vt.Client.Core {

    /// <summary>
    /// Selenium提供的Cookie无法直接从json反序列化的对象构造，故创建一个中间对象
    /// </summary>
    class CookieTmp {
        public bool Secure { get; set; }
        public bool IsHttpOnly { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public DateTime? Expiry { get; set; }

        public Cookie ToCookie()
        {
            CookieTmp cookie = this;
            return new Cookie( cookie.Name, cookie.Value, cookie.Domain, cookie.Path, Expiry );
        }
    }
    public class BrowserContoller {
        DriverHelper driver;
        /// <summary>
        /// 视频地址
        /// </summary>
        public readonly string VideoUrl;
        public BrowserContoller( string videoUrl )
        {
            driver = new DriverHelper();
            VideoUrl = videoUrl;
        }

        /// <summary>
        /// 尝试通过本地cookie进行登录
        /// </summary>
        /// <returns></returns>
        bool canLoginFromLocalCookie()
        {
            if( File.Exists( bilibiliCookiePath ) ) {
                try {
                    driver.Handle.Url = "https://www.bilibili.com";
                    var listCookie = JsonConvert.DeserializeObject<List<CookieTmp>>( File.ReadAllText( bilibiliCookiePath ));
                    listCookie.ForEach( cookie => {
                        driver.Handle.Manage().Cookies.AddCookie( cookie.ToCookie() );
                    } );
                }
                catch( Exception ex ) {
                    VtLogger.A.Error( "Read login cookie error: " + ex.Message );
                    return false;
                }
                VtLogger.A.Info( "[+] Local cookie login successed" );
                return true;
            }
            else {
                File.Create( bilibiliCookiePath );
                return false;
            }
        }
        const string bilibiliCookiePath = "./login/bilibili.json";

        void saveLoginCookie()
        {
            File.WriteAllText( bilibiliCookiePath,
                JsonConvert.SerializeObject( driver.Handle.Manage().Cookies.AllCookies.ToList() ) );
        }

        /// <summary>
        /// 该函数会一直阻塞，直至登录界面跳转
        /// </summary>
        public void TryLogin()
        {
            if( !canLoginFromLocalCookie() ) {
                VtLogger.A.Info( string.Format( "Local cookie login failed. Try to login in {0} seconds!", BrowserSettings.TimeOut ) );
                driver.NavigateTo( "https://passport.bilibili.com/login" );
                driver.WaitUntilTitleIs( "哔哩哔哩 (゜-゜)つロ 干杯~-bilibili" );
                saveLoginCookie();
            }
            else {
                driver.Handle.Navigate().Refresh();
                return;
            }
        }

        public void Hide()
        {
            driver.Window.Minimize();
        }

        public void Max()
        {
            driver.Window.Maximize();
        }

        /// <summary>
        /// 将视频定位至location  
        /// </summary>
        /// <param name="location">
        /// "100" 100秒处
        /// "3:00" 3分处
        /// </param>
        public void LocateVideoAtInFullScreenMode( string location )
        {
            //Actions action = new Actions(driver);
            //action.MoveToElement( driver.FindElementByXPath( "*[@id=\"bilibiliPlayer\"]/div[1]/div[1]" ) );
            //action.MoveByOffset( 10, 30 );
            //BrowserSettings.SetCursorPos( window.Position.X + 50, window.Position.Y + 50 );
            //BrowserSettings.SetCursorPos( window.Position.X + 51, window.Position.Y + 50 );
            //BrowserSettings.SetCursorPos( window.Position.X + 52, window.Position.Y + 50 );
            if( IsFullScreen() ) {
                PressEnter(); // 唤出视频栏
            }
            LocateVideoBasic( location );
        }

        public bool IsFullScreen()
        {
            return driver.Window.Size == System.Windows.Forms.SystemInformation.PrimaryMonitorSize;
        }

        public void LocateVideoBasic( string location )
        {
            // 按选时间进度按钮，准备跳转时间
            driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/div/span[1]" ).Click(); s( 20 );
            var _elm_location_input = driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/input" );
            
            _elm_location_input.SendKeys( Keys.Control + 'a' ); s( 20 );
            _elm_location_input.SendKeys( Keys.Backspace ); s( 20 );
            _elm_location_input.SendKeys( location ); s( 20 );
            _elm_location_input.SendKeys( Keys.Enter ); s( 20 );
        }

        private void s( int timeout )
        {
            Thread.Sleep( timeout );
        }

        public void PressEnter()
        {
            driver.FindElementByXPath( "/html" ).SendKeys( Keys.Enter );
        }
        public void SetWideScreenMode()
        {
            driver.Window.Maximize();
            // driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]" ).SendKeys( "f" );
            driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[3]/div[8]" ).Click();
        }

        public void SetFullScreenMode()
        {
            driver.Window.Maximize();
            // driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[9]/video" ).SendKeys( "f" );
            driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[3]/div[10]" ).Click();
        }
        /// <summary>
        /// 跳转至视频页面，将等待两秒
        /// </summary>
        public void GoToVideoPage()
        {
            driver.NavigateTo( VideoUrl );
            Thread.Sleep( 2000 ); // 稍微等待视频缓冲
        }

        /// <summary>
        /// 获取即时的视频时间位置，
        /// </summary>
        /// <returns>
        /// 形如“m：s”的字符串
        /// 例如： 03:20
        /// 表示当前在三分二十秒处
        /// </returns>
        public string GetCurrentLocationText()
        {
            return driver.RunJS<string>( 
                "return arguments[0].innerHTML",
                "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/div/span[1]"
                );
        }

        public void ShowVideoControl()
        {
            driver.RunJS<string>(
                "arguments[0].className = 'bilibili-player-area video-state-blackside video-control-show'", // 显示视频控制组件
                "//*[@id=\"bilibiliPlayer\"]/div[1]"
                ); s(300);
        }

        public void HideVideoControl()
        {
            driver.RunJS<string>(
                "arguments[0].className = 'bilibili-player-area video-state-blackside'",
                "//*[@id=\"bilibiliPlayer\"]/div[1]"
                );
        }

        public void Close()
        {
            driver.Handle.Close();
        }
    }
}

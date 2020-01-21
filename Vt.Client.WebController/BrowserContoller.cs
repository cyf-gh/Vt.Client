using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using System.IO;
using Newtonsoft.Json;
using stLib.Log;
using Vt.Client.WebController;

namespace Vt.Client.WebController {
    public enum BiliVideoGenre {
        BANGUMI,
        VIDEO,
        UNKNOWN
    }
    /// <summary>
    /// Selenium提供的Cookie无法直接从json反序列化的对象构造，故创建一个中间对象
    /// </summary>
    public class BrowserContoller : IBrowserContoller {
        DriverHelper driver;
        private readonly BiliVideoGenre genre;
        private readonly string XPathTimeLocation;
        private readonly string XPathTimeLocationInput;
        /// <summary>
        /// 视频地址
        /// </summary>
        public readonly string VideoUrl;
        private readonly String cookie;

        public BrowserContoller( BiliVideoGenre genre, string videoUrl, string cookie, string webdriverLocation = "./external/webdriver", string chromeBinaryLocation = null )
        {
            driver = new DriverHelper( webdriverLocation, chromeBinaryLocation );
            this.genre = genre;
            VideoUrl = videoUrl;
            this.cookie = cookie;

            switch ( genre ) {
                case BiliVideoGenre.BANGUMI:
                    XPathTimeLocation = "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[3]/div/span[1]";
                    XPathTimeLocationInput = "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[3]/input";
                    break;
                case BiliVideoGenre.VIDEO:
                    XPathTimeLocation = "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/div/span[1]";
                    XPathTimeLocationInput = "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/input";
                    break;
                default:
                    break;
            }
        }

        bool FeedCookieString( string cookie )
        {
            try {
                driver.Handle.Url = "https://www.bilibili.com";
                var listCookie = JsonConvert.DeserializeObject<List<CookieTmp>>( cookie );
                listCookie.ForEach( c => {
                    driver.Handle.Manage().Cookies.AddCookie( c.ToCookie() );
                } );
            } catch ( Exception ex ) {
                stLogger.Log( "Read login cookie error: \n" + cookie + "\n", ex );
                return false;
            }
            stLogger.Log( "[+] Local cookie login successed" );
            return true;
        }

        /// <summary>
        /// 尝试通过本地cookie进行登录
        /// </summary>
        /// <returns></returns>
        bool canLoginFromLocalCookie()
        {
            return FeedCookieString( CookieHelper.GetLocalCookieString( LocalCookieFilePath() ) );
        }

        bool canLoginFromStringCookie( string cookie )
        {
            return FeedCookieString( cookie );
        }

        void saveLoginCookie()
        {
            driver.SaveLoginCookie( LocalCookieFilePath() );
        }

        public bool IsPause()
        {
            return driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]" ).GetAttribute( "class" ).Contains( "pause" );
        }

        public void Pause()
        {
            if ( !IsPause() ) {
                driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[9]/video" ).Click();
            }
        }

        public void Play()
        {
            if ( IsPause() ) {
                driver.FindElementByXPath( "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[9]/video" ).Click();
            }
        }
        /// <summary>
        /// 该函数会一直阻塞，直至登录界面跳转
        /// </summary>
        /// <param name="cookie">默认值时尝试读取本地cookie</param>
        public void TryLogin()
        {
            try {
                bool isLogin = cookie == "" ? canLoginFromLocalCookie() : canLoginFromStringCookie( cookie );
                if ( !isLogin ) {
                    stLogger.Log( string.Format( "Local cookie login failed. Try to login in {0} seconds!", BrowserSettings.TimeOut ) );
                    driver.NavigateTo( "https://passport.bilibili.com/login" );
                    driver.WaitUntilTitleIs( "哔哩哔哩 (゜-゜)つロ 干杯~-bilibili" );
                    saveLoginCookie();
                } else {
                    driver.Handle.Navigate().Refresh();
                    return;
                }
            } catch ( Exception ex ) {
                throw ex;
            }
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
            if ( IsFullScreen() ) {
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
            driver.FindElementByXPath( XPathTimeLocation ).Click(); s( 20 );
            var _elm_location_input = driver.FindElementByXPath( XPathTimeLocationInput );
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
                XPathTimeLocation
                );
        }

        public void ShowVideoControl()
        {
            driver.RunJS<string>(
                "arguments[0].className = 'bilibili-player-area video-state-blackside video-control-show'", // 显示视频控制组件
                "//*[@id=\"bilibiliPlayer\"]/div[1]"
                ); s( 300 );
        }

        public void HideVideoControl()
        {
            driver.RunJS<string>(
                "arguments[0].className = 'bilibili-player-area video-state-blackside'",
                "//*[@id=\"bilibiliPlayer\"]/div[1]"
                );

            //
        }

        public void Close()
        {
            driver.Handle.Quit();
        }

        public String LocalCookieFilePath()
        {
            return "./login/bilibili.json";
        }
    }
}

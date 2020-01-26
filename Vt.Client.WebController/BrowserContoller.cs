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

    public class BrowserContoller {
        DriverHelper driver;
        private readonly BiliVideoGenre genre;
        private readonly string XPathTimeLocation;
        private readonly string XPathTimeLocationInput;
        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }
        private readonly String cookie;

        public bool IsUrlChanged()
        {
            if ( VideoUrl != driver.Handle.Url ) {
                VideoUrl = driver.Handle.Url;
                return true;
            } else {
                return false;
            }
        }

        public BiliVideoGenre GetVideoGenre()
        {
            if ( VideoUrl.Contains( "bilibili.com/bangumi" ) ) {
                return BiliVideoGenre.BANGUMI;
            }
            if ( VideoUrl.Contains( "bilibili.com/video" ) ) {
                return BiliVideoGenre.VIDEO;
            }
            return BiliVideoGenre.UNKNOWN;
        }

        public BrowserContoller( string videoUrl, string cookie, string webdriverLocation = "./external/webdriver", string chromeBinaryLocation = null )
        {
            switch ( DriverHelper.Browser ) {
                case "chrome":
                    driver = new DriverHelper( webdriverLocation, chromeBinaryLocation );
                    break;
                case "edge":
                    driver = new DriverHelper();
                    break;
                default:
                    break;
            }
            Hide();
            VideoUrl = videoUrl;
            this.genre = GetVideoGenre();
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

        public void Hide()
        {
            driver.Window.Position = new System.Drawing.Point( 10000, 0 );
            driver.Hide();
        }

        public void BringToScreen()
        {
            driver.Window.Position = new System.Drawing.Point( 0, 0 );
            driver.Max();
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
                    BringToScreen();
                    driver.WaitUntilTitleIs( "哔哩哔哩 (゜-゜)つロ 干杯~-bilibili" );
                    Hide();
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

        public void Log( string msg )
        {
            driver.ConsoleLog( msg );
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

        public void TryClearUnusedElements()
        {
            try {
                // 删除所有的高能进度条页面阻挡
                driver.DeleteElementByXPath( "//*[@id=\"bilibili_pbp\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"bilibili_pbp_pin\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"bilibili_pbp_panel\"]" );
                driver.ConsoleLog( "成功删除高能进度条" );
                // 删除所有冗余信息
                driver.DeleteElementByXPath( "//*[@id=\"recom_module\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"seasonlist_module\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"bili-header-m\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"internationalHeader\"]" );
                driver.ConsoleLog( "成功删除头部" );

                driver.DeleteElementByXPath( "//*[@id=\"reco_list\"]" );

                driver.DeleteElementByXPath( "//*[@id=\"slide_ad\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"right-bottom-banner\"]" );
                driver.DeleteElementByXPath( "//*[@id=\"live_recommand_report\"]" );
                driver.ConsoleLog( "冗余信息全部完成删除" );
            } catch ( Exception ) {
                return;
            }
        }

        public void CreateLobbyInfo()
        {
            driver.RunJS<string>(
                "var t = document.createElement('div');" +
                "t.setAttribute('id','vt-lobby-info');" +
                "t.innerText=\"VT_LOBBY_INFO\";" +
                "arguments[0].appendChild(t);",
                "//*[@id=\"app\"]/div/div[2]" );
        }

        public void UpdateLobbyStatus( List<string> msg )
        {
            var table = "";
            msg.ForEach( a => { table += a + "<br>"; } );

            driver.RunJS<string>(
                "arguments[0].innerHTML = \"" +
                table +
                "\";",
                "//*[@id=\"vt-lobby-info\"]" );
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

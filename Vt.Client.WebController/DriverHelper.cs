using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using stLib.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vt.Client.WebController;

namespace Vt.Client.WebController {
    public static class BrowserSettings {
        [DllImport( "User32.dll" )]
        public extern static void SetCursorPos( int x, int y );
        public const int TimeOut = 60;
    }

    /// <summary>
    /// 封装一系列Selenium操作
    /// </summary>
    public class DriverHelper {
        public IWebDriver Handle { get; set; }
        public IWindow Window { get; set; }
        WebDriverWait wait;
        public DriverHelper( string webdriverLocation = "./external/webdriver", string chromeBinaryLocation = null )
        {
            var driverService = ChromeDriverService.CreateDefaultService( webdriverLocation );
            driverService.HideCommandPromptWindow = true;
            var ops = new ChromeOptions();
            ops.AddArguments( "--test-type", "--no-first-run" );
            if ( !string.IsNullOrEmpty( chromeBinaryLocation ) ) {
                ops.BinaryLocation = chromeBinaryLocation;
            }
            Handle = new ChromeDriver( driverService, ops );
            // Handle.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds( BrowserSettings.TimeOut );
            Window = Handle.Manage().Window;
            wait = new WebDriverWait( Handle, new TimeSpan( 0, 0, BrowserSettings.TimeOut ) );
        }
        public IWebElement FindElementByXPath( string xpath )
        {
            return wait.Until( c => { return Handle.FindElement( By.XPath( xpath ) ); } );
        }

        public IWebElement FindElementByXPathDoNotWait( string xpath )
        {
            try {
                return Handle.FindElement( By.XPath( xpath ) );
            } catch ( Exception ) {
                return null;
            }
        }

        public void DeleteElementByXPath( string xpath )
        {
            if ( FindElementByXPathDoNotWait( xpath ) != null ) {
                RunJS<string>(
                    " arguments[0].parentNode.removeChild( arguments[0] ); ",
                    xpath );
            }
        }
        public void NavigateTo( string url )
        {
            Handle.Navigate().GoToUrl( url );
        }
        public void WaitUntilTitleIs( string title )
        {
            wait.Until( c => { return c == null ? false : c.Title == ( title ); } );
        }
        public T RunJS<T>( string JsCode, string elemXPath )
        {
            return Handle.ExecuteJavaScript<T>( JsCode, FindElementByXPathDoNotWait( elemXPath ) );
        }

        public void RunJS( string jsCode )
        {
            Handle.ExecuteJavaScript( jsCode );
        }
        public void SaveLoginCookie( string filePath )
        {
            File.WriteAllText( filePath,
                JsonConvert.SerializeObject( Handle.Manage().Cookies.AllCookies.ToList() ) );
        }

        public bool FeedCookieString( string cookie )
        {
            try {
                Handle.Url = "https://www.bilibili.com";
                var listCookie = JsonConvert.DeserializeObject<List<CookieTmp>>( cookie );
                listCookie.ForEach( c => {
                    Handle.Manage().Cookies.AddCookie( c.ToCookie() );
                } );
            } catch ( Exception ex ) {
                stLogger.Log( "Read login cookie error: ", ex );
                return false;
            }
            stLogger.Log( "[+] Local cookie login successed" );
            return true;
        }
        public void Hide()
        {
            Window.Minimize();
        }

        public void Max()
        {
            Window.Maximize();
        }

        /// <summary>
        /// 输出至浏览器的Log
        /// </summary>
        public void ConsoleLog( string logMessage )
        {
            Handle.ExecuteJavaScript( string.Format( "console.log(\"{0}\");", logMessage ) );
        }

        public static void KillChromeDriver()
        {
            System.Diagnostics.Process.Start( "CMD.exe", "taskkill /f /im chromedriver.exe" );
        }
    }
}

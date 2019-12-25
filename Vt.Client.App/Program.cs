using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.Core;

namespace Vt.Client.App {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            BrowserContoller browserContoller = new BrowserContoller( "https://www.bilibili.com/video/av79362092" );
            browserContoller.TryLogin();
            browserContoller.GoToVideoPage();
            browserContoller.LocateVideoBasic( "30" );
            browserContoller.SetFullScreenMode();
            Thread.Sleep( 3000 );
            browserContoller.LocateVideoAtInFullScreenMode( "10" );
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainFrame() );
        }
    }
}

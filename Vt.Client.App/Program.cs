using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.WebController;
using stLib.Log;
using stLib.Win32;
using System.Runtime.InteropServices;

namespace Vt.Client.App {
    static class Program {
        static void LoadServerInfo()
        {
            Global.ServerInfos = stLib.Config.IPPortConfig.Load();
            Global.SelectedServer = Global.ServerInfos[0];
        }

        static void LoadUserInfo()
        {
            var userName = File.ReadAllText( "./user.cfg" );
            Global.MyName = userName;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConsoleHelper.HideConsole();
            // 检查是否为调试模式
            if ( File.ReadAllText( "./.dev/debug.cfg" ) == "true" ) {
                Global.IsDebugMod = true;
            } else {
                // 非调试模式情况下只允许程序运行一个实例
                bool runone;
                Mutex run = new Mutex( true, "___vt_client___", out runone );
                if ( !runone ) {
                    return;
                } else {
                    run.ReleaseMutex();
                }
            }

            stLogger.Init();
            try {
                LoadServerInfo();
                LoadUserInfo();
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                MessageBox.Show( ex.Message );
                Application.Exit();
            }

            if ( Global.IsDebugMod ) {
                stLib.Common.Random rd = new stLib.Common.Random();
                Global.MyName = "debug" + rd.GetInt32().ToString();
                ConsoleHelper.ShowConsole();
                Console.WriteLine( "DEBUG MODE ON" );
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainFrame() );
        }
    }
}

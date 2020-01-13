using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.Core;
using Vt.Client.Core.Log;

namespace Vt.Client.App {
    static class Program {

        static void LoadServerInfo()
        {
            var ipInfo = File.ReadAllText("./server.cfg");
            var infos = ipInfo.Split(',');
            Global.IP = infos[0];
            Global.Tcp_Port = infos[1];
            Global.Udp_Port = infos[2];
        }

        static void LoadUserInfo()
        {
            var userName = File.ReadAllText("./user.cfg");
            Global.MyName = userName;
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                LoadServerInfo();
                LoadUserInfo();
            }
            catch (Exception ex)
            {
                VtLogger.A.Error( ex.ToString() );
                MessageBox.Show(ex.Message);
                throw;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainFrame() );
        }
    }
}

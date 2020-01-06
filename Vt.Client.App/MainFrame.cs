using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.Core;
using Vt.Client.Core.Log;

namespace Vt.Client.App {
    public partial class MainFrame : Form {
        public MainFrame()
        {
            InitializeComponent();
        }


        private void MainFrame_Load( Object sender, EventArgs e )
        {
            tb_nick_name.Text = Guid.NewGuid().ToString();
        }

        private void textBox1_TextChanged( Object sender, EventArgs e )
        {

        }

        private void createLobbyToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            // 检查是否有可以使用的udp同步服务器
            CreateLobby createLobby = new CreateLobby();
            createLobby.ShowDialog();
        }

        private void tb_nickName_TextChanged_1( Object sender, EventArgs e )
        {

        }
        BrowserContoller browserContoller;
        private void btn_save_name_Click( Object sender, EventArgs e )
        {
            try {
                browserContoller = new BrowserContoller( "https://www.bilibili.com/video/av79362092" );
                browserContoller.Hide();
                browserContoller.TryLogin();
                browserContoller.GoToVideoPage();
                browserContoller.Max();
                browserContoller.ShowVideoControl();
                browserContoller.LocateVideoBasic( "30" );
                browserContoller.HideVideoControl();
                // browserContoller.SetFullScreenMode();
                Thread.Sleep( 3000 );
                browserContoller.ShowVideoControl();
                browserContoller.LocateVideoAtInFullScreenMode( "10" );
                browserContoller.HideVideoControl();
                // rec.Start();
            }
            catch( Exception ex ) {
                VtLogger.A.Error( ex.ToString() );
            }

        }


        private void MainFrame_FormClosing( Object sender, FormClosingEventArgs e )
        {
            browserContoller?.Close();
        }

        private void serverConfigToolStripMenuItem_Click(Object sender, EventArgs e)
        {

        }
    }
}

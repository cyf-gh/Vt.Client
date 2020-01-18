using stLib.Common;
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
using Vt.Client.App.GUI;
using Vt.Client.Core;
using stLib.Log;
using Vt.Client.Core.Net;

namespace Vt.Client.App {
    public partial class MainFrame : Form {
        public MainFrame()
        {
            InitializeComponent();
        }


        private void MainFrame_Load( Object sender, EventArgs e )
        {
            tb_nick_name.Text = Global.MyName;
            // backgroundWorker1.RunWorkerAsync();
            // lb_lobs.DataSource = StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "query_lobbies@nil", Global.IP, Global.Tcp_Port ) );

            // lb_lobs.DataSource = new string[] { "123", "2332" };
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
        private void btn_save_name_Click( Object sender, EventArgs e )
        {

            Global.MyName = tb_nick_name.Text;
        }


        private void MainFrame_FormClosing( Object sender, FormClosingEventArgs e )
        {
            // TcpClient_.SendMessage_ShortConnect( "", Global.IP, Global.Tcp_Port );
        }

        private void serverConfigToolStripMenuItem_Click( Object sender, EventArgs e )
        {

        }

        private void refreshToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            string [] lobs = null;
            lb_lobs.Items.Clear();
            try {
                lobs = StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "query_lobbies", Global.IP, Global.Tcp_Port ) );
            } catch ( Exception ex ) {
                MessageBox.Show(ex.Message);
                return;
            }
            foreach ( var l in lobs ) {
                lb_lobs.Items.Add( l );
            }
        }

        private void lb_lobs_SelectedIndexChanged( Object sender, EventArgs e )
        {

        }

        private void lb_lobs_DoubleClick( Object sender, EventArgs e )
        {
            if ( Global.IsInLobby ) {
                MessageBox.Show("您已在房间中，不能同时加入多个房间");
                return;
            }
            string lobbyName = lb_lobs.Items[lb_lobs.SelectedIndex].ToString();
            InputBox paswdInput = new InputBox( lobbyName );
            paswdInput.ShowDialog();
        }
    }
}

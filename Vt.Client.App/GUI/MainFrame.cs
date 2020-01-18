﻿using stLib.Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.App.GUI;
using stLib.Net.Haste;
using System.IO;

namespace Vt.Client.App {
    public partial class MainFrame : Form {
        public MainFrame()
        {
            InitializeComponent();
        }


        private void MainFrame_Load( Object sender, EventArgs e )
        {
            tb_nick_name.Text = Global.MyName;
        }

        private void createLobbyToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            // 检查是否有可以使用的udp同步服务器
            CreateLobby createLobby = new CreateLobby();
            createLobby.ShowDialog();
        }

        private void tb_nickname_TextChange( Object sender, EventArgs e )
        {
            Global.MyName = tb_nick_name.Text;
        }

        private void MainFrame_FormClosing( Object sender, FormClosingEventArgs e )
        {
            // 关闭房间，清理资源
            // TcpClient_.SendMessage_ShortConnect( "", Global.IP, Global.Tcp_Port );
        }

        private void serverConfigToolStripMenuItem_Click( Object sender, EventArgs e )
        {

        }

        private async void refreshToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            lb_lobs.Items.Clear();
            Cursor = Cursors.WaitCursor;
            var lobs = await Task.Run( () => {
                try {
                    return StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "query_lobbies", Global.IP, Global.Tcp_Port ) );
                } catch ( Exception ex ) {
                    MessageBox.Show( ex.Message );
                    return null;
                }
            } );
            Cursor = Cursors.Default;
            if ( lobs == null ) {
                return;
            }
            foreach ( var l in lobs ) {
                lb_lobs.Items.Add( l );
            }
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

        private void tb_nick_name_MouseLeave( Object sender, EventArgs e )
        {
            File.WriteAllText( "./user.cfg", tb_nick_name.Text );
        }
    }
}

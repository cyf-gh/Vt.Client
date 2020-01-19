using stLib.Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.App.GUI;
using stLib.Net.Haste;
using System.IO;
using stLib.Win32;
using Vt.Client.WebController;

namespace Vt.Client.App {
    public partial class MainFrame : Form {
        public MainFrame()
        {
            InitializeComponent();
        }

        void freshServerStatus()
        {
            Text = "服务器信息：" + Global.SelectedServer?.Readable();
        }

        private async void MainFrame_Load( Object sender, EventArgs e )
        {
            tb_nick_name.Text = Global.MyName;

            freshLoginStatus();
            freshServerStatus();
            await RefreshLobby();
        }

        void freshLoginStatus()
        {
            if ( File.ReadAllText( "./login/bilibili.json" ) != "" ) {
                BiliBiliToolStrip.Text = "哔哩哔哩（已登录）";
            }
        }

        //private void FeedMenuItem( ToolStripMenuItem parent, string _path, string extension, EventHandler clickEvt )
        //{
        //    foreach ( var path in ProjectDirectoryHelper.GetSpecificFilePaths( _path, extension ) ) {
        //        var menuItem = new KeyValueToolStripMenuItem( GetFileName( path ) );
        //        menuItem.Click += clickEvt;
        //        menuItem.Value = path;
        //        parent.DropDownItems.Add( menuItem );
        //    }
        //}

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
            DialogResult result = MessageBox.Show( "是否退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
            // 关闭房间，清理资源
            // TcpClient_.SendMessage_ShortConnect( "", Global.SelectedServer );
            if ( result == DialogResult.OK ) {
            } else {
                e.Cancel = true;
            }
        }

        private void serverConfigToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.ShowDialog();
            freshServerStatus();
        }

        public async Task RefreshLobby()
        {
            lb_lobs.Items.Clear();
            Cursor = Cursors.WaitCursor;
            var lobs = await Task.Run( () => {
                try {
                    return StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "query_lobbies@", Global.SelectedServer ) );
                } catch ( Exception ex ) {
                    MessageBox.Show( ex.Message );
                    return null;
                }
            } );
            Cursor = Cursors.Default;

            if ( lobs == null ) {
                return;
            }
            if ( lobs.Count == 0 ) {
                MessageBox.Show( "当前服务器中没有任何房间" );
                return;
            }
            foreach ( var l in lobs ) {
                lb_lobs.Items.Add( l );
            }
        }

        private void lb_lobs_DoubleClick( Object sender, EventArgs e )
        {
            if ( Global.IsInLobby ) {
                MessageBox.Show( "您已在房间中，不能同时加入多个房间" );
                return;
            }
            if ( lb_lobs.SelectedIndex == -1 ) {
                MessageBox.Show( "目前无房间可加入" );
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

        private void lb_lobs_SelectedIndexChanged( Object sender, EventArgs e )
        {

        }

        private void serversToolStripMenuItem_Click( Object sender, EventArgs e )
        {

        }

        private async void testCurrentServer_Click( Object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            bool ok = await Task.Run( () => {
                try {
                    UdpClient_ udpClient_ = new UdpClient_();
                    string tcpRe = TcpClient_.SendMessage_ShortConnect( "ping@", Global.SelectedServer );
                    string udpRe = udpClient_.SendMessage( "ping@", Global.SelectedServer );
                    if ( tcpRe == "OK" && udpRe == "OK" ) {
                        return true;
                    }
                    return false;
                } catch ( Exception ex ) {
                    MessageBox.Show( ex.Message );
                    return false;
                }
            } );
            if ( ok ) {
                MessageBox.Show( "OK", Global.SelectedServer.Readable());
            }
            Cursor = Cursors.Default;
        }

        private async void btn_refresh_Click( Object sender, EventArgs e )
        {
            await RefreshLobby();
        }

        private void BiliBiliToolStrip_Click( Object sender, EventArgs e )
        {
            if ( File.ReadAllText( "./login/bilibili.json" ) != "" ) {
                DialogResult result = MessageBox.Show( "是否重写登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
                if ( result == DialogResult.Cancel ) {
                    return;
                } else {
                    File.WriteAllText( "./login/bilibili.json", "" );
                }
            }
            BrowserContoller c = new BrowserContoller( "", "" );
            c.TryLogin();
            c.Close();
            freshLoginStatus();
            MessageBox.Show( File.Exists( "./login/bilibili.json" ) ? "登陆成功！" : "登录失败，未保存登录信息\n请重试", "登录状态" );
        }
    }
}

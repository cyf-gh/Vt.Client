using stLib.Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.App.GUI;
using stLib.Net.Haste;
using System.IO;
using stLib.Win32;
using Vt.Client.WebController;
using stLib.Log;
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.Dism;
using System.Net;
using System.Text;

namespace Vt.Client.App {
    public partial class MainFrame : Form {
        public MainFrame()
        {
            InitializeComponent();
        }

        void freshServerStatus()
        {
            Text = "浏览器：" + DriverHelper.Browser + "    服务器信息：" + G.SelectedServer?.Readable();
        }

        private async void MainFrame_Load( Object sender, EventArgs e )
        {
            tb_nick_name.Text = G.MyName;

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
            G.MyName = tb_nick_name.Text;
        }

        private void MainFrame_FormClosing( Object sender, FormClosingEventArgs e )
        {
            DialogResult result = MessageBox.Show( "是否退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );

            // 关闭房间，清理资源
            // TcpClient_.SendMessage_ShortConnect( "", Global.SelectedServer );
            if ( result == DialogResult.OK ) {
                G.SaveConfig();
                // DriverHelper.KillChromeDriver();
                // Environment.Exit( 0 );
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
                    return StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "query_lobbies@", G.SelectedServer ) );
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
            if ( G.IsInLobby ) {
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
            File.WriteAllText( "./config/user.cfg", tb_nick_name.Text );
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
                    string tcpRe = TcpClient_.SendMessage_ShortConnect( "ping@", G.SelectedServer );
                    string udpRe = udpClient_.SendMessage( "ping@", G.SelectedServer );
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
                MessageBox.Show( "OK", G.SelectedServer.Readable() );
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
            try {
                G.Lobby.BC = new BrowserContoller( "", "" );
                G.Lobby.BC.TryLogin();
            } catch ( Exception ex ) {
                stLogger.Log( "", ex );
            }
            G.Lobby.BC.Close();
            freshLoginStatus();
            MessageBox.Show( File.ReadAllText( "./login/bilibili.json" ) != "" ? "登陆成功！" : "登录失败，未保存登录信息\n请重试", "登录状态" );
        }

        private void ClearLoginStatusToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            DialogResult result = MessageBox.Show( "清空登陆状态？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
            if ( result == DialogResult.Cancel ) {
                return;
            } else {
                File.WriteAllText( "./login/bilibili.json", "" );
                freshLoginStatus();
            }
        }

        private void version_btn_Click( Object sender, EventArgs e )
        {
            MessageBox.Show( "0.0.1b3", "版本" );
        }

        private void MainFrame_FormClosed( Object sender, FormClosedEventArgs e )
        {
            DriverHelper.KillChromeDriver();
            Environment.Exit( 0 );
        }

        private void edgeToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            string capName = "Microsoft.WebDriver~~~~0.0.1.0";
            try {
                DismApi.Initialize( DismLogLevel.LogErrors );
                using ( DismSession session = DismApi.OpenOnlineSession() ) {
                    foreach ( DismCapability feature in DismApi.GetCapabilities( session ) ) {
                        Console.WriteLine( feature.Name );
                        if ( feature.Name == capName ) {
                            if ( feature.State != DismPackageFeatureState.Installed ) {
                                MessageBox.Show( "检测到Microsoft.WebDriver功能未添加\n即将开始下载，这可能需要几分钟。" );
                                DismApi.AddCapability( session, capName );
                            } else {
                                MessageBox.Show( "检测到Microsoft.WebDriver功能已经添加" );
                            }
                        }
                    }
                }
                DismApi.Shutdown();
            } catch ( Exception ex ) {
                MessageBox.Show( "可能需要使用管理员权限启动\n" + ex.Message );
                throw;
            }
            DriverHelper.Browser = "edge";
            freshServerStatus();
        }

        private void LocalChromeToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            DriverHelper.Browser = "chrome";
            G.ChromeBinPath = "";
            freshServerStatus();
        }

        private void NoLocalChromeToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            DriverHelper.Browser = "chrome";
            if ( File.Exists( "./external/Chrome/chrome.exe" ) ) {
                G.ChromeBinPath = "./external/Chrome/chrome.exe";
            } else {
                MessageBox.Show( "./external/Chrome/chrome.exe\n" + "未寻找到chrome\n" + "建议下载chrome或切换至edge浏览器" );
            }
            freshServerStatus();
        }

        private void updateToolStripMenuItem_Click( Object sender, EventArgs e )
        {
            int ver = 0;
            try {
                ver = System.Convert.ToInt32( fetchRawFromHttp( "https://gitee.com/cyf-my/vt.update/raw/master/Version.txt" ) );
            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
            if ( ver > G.Version ) {
                MessageBox.Show( "New version is founded. Click to start update." );
                DialogResult result = MessageBox.Show( "Are you sure to update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
                if ( result == DialogResult.Yes ) {
                    Process.Start( "ppUpdator.App.exe" );
                    Application.Exit();
                }
            } else {
                MessageBox.Show( "已是最新版本" );
            }
        }

        private string fetchRawFromHttp( string urlAddress )
        {
            string data = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( urlAddress );
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if ( response.StatusCode == HttpStatusCode.OK ) {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if ( response.CharacterSet == null ) {
                    readStream = new StreamReader( receiveStream );
                } else {
                    readStream = new StreamReader( receiveStream, Encoding.GetEncoding( response.CharacterSet ) );
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data;
        }
    }
}

using System;
using System.Windows.Forms;
using Vt.Client.Core;
using Vt.Client.WebController;

namespace Vt.Client.App {
    public partial class CreateLobby : Form {
        public CreateLobby()
        {
            InitializeComponent();
        }

        private void tb_lobby_name_TextChanged( Object sender, EventArgs e )
        {

        }

        private void btn_create_lobby_Click( Object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;
            if ( tb_lbpswd.Text == "" ) {
                MessageBox.Show( "Fatal", "Password must be not empty." );
                Cursor = Cursors.Default;
                return;
            }
            try {
                LobbyBorrower lobbyBorrower = new LobbyBorrower( Global.SelectedServer, tb_lobby_name.Text, tb_lbpswd.Text );
                ProtocolMaker protocolMaker = new ProtocolMaker();
                string responseFromLender = lobbyBorrower.Lend(
                    new YPM.Packager.ypmPackage( "create_lobby", new string[] {
                        tb_lobby_name.Text,
                        tb_lbpswd.Text,
                        ddd_maxOffset.Items[ddd_maxOffset.SelectedIndex].ToString(),
                        Global.MyName,
                        tb_url.Text,
                        cb_is_share_cookie.Checked ? CookieHelper.GetLocalCookieString( "./login/bilibili.json" ) : "no"
                    } ).ToString() );
                switch ( responseFromLender ) {
                    case "OK": {
                        MessageBox.Show( "创建成功！" );
                        InLobby inLobby = new InLobby( true, tb_lobby_name.Text, "", tb_url.Text, lobbyBorrower );
                        Close();
                        inLobby.ShowDialog();
                        break;
                    }
                    case "LOBBY_ALREADY_EXISTS": {
                        MessageBox.Show( "Fatal", "There's a same named lobby existed.\nPlease try for another name" );
                        break;
                    }
                    default: {
                        MessageBox.Show( "Lobby Lender", "Cannot lend lobby currently." );
                        break;
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
            Cursor = Cursors.Default;
        }

        private void CreateLobby_Load( Object sender, EventArgs e )
        {
            stLib.Common.Random rd = new stLib.Common.Random();
            tb_lobby_name.Text = "Lobby" + rd.GetInt32().ToString();
            lb_server_info.Text = string.Format( "Server IP: {0}\n Udp:{1}\n Tcp:{2}", Global.SelectedServer.IP, Global.SelectedServer.UdpPort, Global.SelectedServer.TcpPort );
            ddd_maxOffset.SelectedIndex = 0;
        }

        private void tb_url_TextChanged( Object sender, EventArgs e )
        {
            if ( tb_url.Text.Contains( "BiliBili" ) ) {
                lb_video_url.Text = "bilibili";
            } else {
                lb_video_url.Text = "视频URL：";
            }
        }

        private void lb_video_url_Click( Object sender, EventArgs e )
        {

        }
    }
}

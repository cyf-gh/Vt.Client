using System;
using System.IO;
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
            this.Text = "创建中...";
            this.Enabled = false;
            if ( tb_lbpswd.Text == "" ) {
                MessageBox.Show( "Fatal", "Password must be not empty." );
                Cursor = Cursors.Default;
                return;
            }

            if ( cb_is_share_cookie.Checked ) {
                if ( File.ReadAllText( "./login/bilibili.json" ) == "" ) {
                    MessageBox.Show( "未找到登录的本地信息\n您还未登录bilibili，请回到主界面的登陆选项登录\n或取消共享登录状态的选项" );
                    return;
                }
            }

            try {
                switch ( G.Lobby.Start(
                            tb_lobby_name.Text,
                            cb_is_share_cookie.Checked ? CookieHelper.GetLocalCookieString( "./login/bilibili.json" ) : "",
                            tb_url.Text,
                            tb_lbpswd.Text,
                            ddd_maxOffset.Items[ddd_maxOffset.SelectedIndex].ToString(),
                            true
                        ) ) {
                    case "OK": {
                        Close();
                        break;
                    }
                    case "LOBBY_ALREADY_EXISTS": {
                        MessageBox.Show( "错误", "已经有一个同样名字的房间存在，\n请使用其他名字重试。" );
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
            this.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void CreateLobby_Load( Object sender, EventArgs e )
        {
            stLib.Common.Random rd = new stLib.Common.Random();
            tb_lobby_name.Text = "Lobby" + rd.GetInt32().ToString();
            Text = G.SelectedServer.Readable();
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

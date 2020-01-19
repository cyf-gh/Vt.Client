using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using stLib.Net.Haste;
using Vt.Client.Core;

namespace Vt.Client.App.GUI {
    public partial class InputBox : Form {
        private readonly String lobName;

        public InputBox( string lobName )
        {
            InitializeComponent();
            this.lobName = lobName;
        }

        private void btn_OK_Click( Object sender, EventArgs e )
        {
            var rep = TcpClient_.SendMessage_ShortConnect( string.Format( "join_lobby@{0},{1},{2}", lobName, Global.MyName, tb_text.Text ), Global.SelectedServer );
            switch ( rep ) {
                case "PSWD_INCOR":
                    MessageBox.Show( "密码错误" );
                    return;
                case "NO_SUCH_LOBBY":
                    MessageBox.Show( "该房间当前不可使用" );
                    Close();
                    return;
                case "ALREADY_IN_LOBBY":
                    MessageBox.Show( "您已在房间中" );
                    Close();
                    return;
                default:
                    break;
            }
            var url___cookie = Regex.Split( rep, @"\$_\$", RegexOptions.IgnoreCase );
            InLobby inLobby = new InLobby( false, lobName, url___cookie[1], url___cookie[0], new LobbyBorrower( Global.SelectedServer, lobName, tb_text.Text ) );
            inLobby.Show();
            Close();
        }
    }
}

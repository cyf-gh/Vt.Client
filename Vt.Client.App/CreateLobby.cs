using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.Core;

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
            try {
                LobbyBorrower lobbyLender = new LobbyBorrower();
                if ( !lobbyLender.Lend( Global.IP, Global.Tcp_Port ) ) {
                    MessageBox.Show( "Lobby Lender", "Cannot lend lobby currently." );
                }
            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        private void CreateLobby_Load( Object sender, EventArgs e )
        {
            tb_lobby_name.Text = "Lobby" + Guid.NewGuid().ToString();
            lb_server_info.Text = string.Format( "Server IP: {0}\n Udp:{1}\n Tcp:{2}", Global.IP, Global.Udp_Port, Global.Tcp_Port );
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // 检查是否有同名房间
        }

        private void CreateLobby_Load( Object sender, EventArgs e )
        {
            tb_lobby_name.Text = "Lobby" + Guid.NewGuid().ToString();
        }
    }
}

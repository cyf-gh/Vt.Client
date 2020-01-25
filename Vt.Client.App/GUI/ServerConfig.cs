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
    public partial class ServerConfig : Form {
        public ServerConfig()
        {
            InitializeComponent();
        }

        private void ServerConfig_Load( Object sender, EventArgs e )
        {
            this.lb_server.DataSource = G.ServerInfos;
            lb_server.DisplayMember = "IP";
        }

        private void lb_server_SelectedIndexChanged( Object sender, EventArgs e )
        {

        }

        private void lb_server_DoubleClick( Object sender, EventArgs e )
        {
            G.SelectedServer = G.ServerInfos[lb_server.SelectedIndex];
            MessageBox.Show( "已切换为\n" + G.SelectedServer.IP, "服务器设置" );
            this.Close();
        }
    }
}

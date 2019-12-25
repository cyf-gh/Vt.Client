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
    public partial class InLobby : Form {
        private readonly Boolean isHost;

        public InLobby( bool isHost )
        {
            InitializeComponent();
            this.isHost = isHost;
        }

        private void InLobby_Load( Object sender, EventArgs e )
        {
        }

        private void tb_video_url_TextChanged( Object sender, EventArgs e )
        {
            if( tb_video_url.Text.Contains( "bilibili" ) ) {
                this.Text = "WebSite: BiliBili";
            }
        }
    }
}

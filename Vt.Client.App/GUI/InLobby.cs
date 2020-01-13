using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.Core;
using Vt.Client.Core.Log;

namespace Vt.Client.App {
    public partial class InLobby : Form {
        private readonly Boolean isHost;
        private readonly String lobbyName;
        private readonly String videoUrl;
        private readonly LobbyBorrower borrower;
        private BrowserContoller browserContoller;

        public InLobby( bool isHost, string lobbyName, string videoUrl, LobbyBorrower borrower )
        {
            InitializeComponent();
            this.isHost = isHost;
            this.lobbyName = lobbyName;
            this.videoUrl = videoUrl;
            this.borrower = borrower;
            Global.IsInLobby = true;
            // bgw_viewers_syncer.RunWorkerAsync();
            this.Text = lobbyName;
            tb_video_url.Text = videoUrl;
        }

        private void InLobby_Load( Object sender, EventArgs e )
        {
            tb_video_url.Enabled = false;
            if ( !isHost ) {
                bt_start.Enabled = false;
                bt_start.Text = "Waiting Host";
            }
        }

        private void tb_video_url_TextChanged( Object sender, EventArgs e )
        {

        }

        private void InLobby_FormClosing( Object sender, FormClosingEventArgs e )
        {
            DialogResult result = MessageBox.Show( isHost ? "Close Lobby?" : "Exit Lobby?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
            if ( result == DialogResult.OK ) {
                Global.IsInLobby = false;
                if ( isHost ) {
                    borrower.Return();
                }
            } else {
                e.Cancel = true;
            }
        }

        private void bgw_viewers_syncer_DoWork( Object sender, DoWorkEventArgs e )
        {
        }

        private void lb_viewerList_SelectedIndexChanged( Object sender, EventArgs e )
        {

        }

        private void button1_Click( Object sender, EventArgs e )
        {
            lb_viewerList.Items.Clear();
            var lobs = borrower.QueryViewers();
            foreach ( var l in lobs ) {
                lb_viewerList.Items.Add( l );
            }
        }

        private void bt_start_Click( Object sender, EventArgs e )
        {
            SyncWorker syncWorker = new SyncWorker();
            syncWorker.Do();
            try {
                browserContoller = new BrowserContoller( tb_video_url.Text );
                browserContoller.Hide();
                browserContoller.TryLogin();
                browserContoller.GoToVideoPage();
                browserContoller.Max();
                browserContoller.ShowVideoControl();
                browserContoller.LocateVideoBasic( "30" );
                browserContoller.HideVideoControl();
                // browserContoller.SetFullScreenMode();
                Thread.Sleep( 3000 );
                browserContoller.ShowVideoControl();
                browserContoller.LocateVideoAtInFullScreenMode( "10" );
                browserContoller.HideVideoControl();
                // rec.Start();
            } catch ( Exception ex ) {
                VtLogger.A.Error( ex.ToString() );
            }
        }
    }
}

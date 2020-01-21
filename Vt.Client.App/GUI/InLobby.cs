using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Vt.Client.WebController;
using stLib.Log;
using Vt.Client.Core;

namespace Vt.Client.App {
    public partial class InLobby : Form {
        private readonly Boolean isHost;
        private readonly String lobbyName;
        private readonly String cookie;
        private readonly String videoUrl;
        private readonly LobbyBorrower borrower;
        private BrowserContoller browserContoller;
        SyncWorker syncWorker;
        public InLobby( bool isHost, string lobbyName, string cookie, string videoUrl, LobbyBorrower borrower )
        {
            InitializeComponent();
            this.isHost = isHost;
            this.lobbyName = lobbyName;
            this.cookie = cookie;
            this.videoUrl = videoUrl;
            this.borrower = borrower;
            Global.IsInLobby = true;
            bgw_viewers_syncer.RunWorkerAsync();
            Text = "房间：" + lobbyName;
            tb_video_url.Text = videoUrl;
        }

        private void InLobby_Load( Object sender, EventArgs e )
        {
            tb_video_url.Enabled = false;
            if ( !isHost ) {
                bt_start.Enabled = false;
                bt_start.Text = "Waiting Host";
                browserContoller = new BrowserContoller( GetVideoGenre(), tb_video_url.Text, cookie, Global.WebdriverDir, Global.ChromeBinPath );

                syncWorker = new SyncWorker( Global.MyName, browserContoller, Global.SelectedServer );
                syncWorker.Do();
            }
        }

        private BiliVideoGenre GetVideoGenre()
        {
            if ( videoUrl.Contains( "bilibili.com/bangumi" ) ) {
                return BiliVideoGenre.BANGUMI;
            }
            if ( videoUrl.Contains( "bilibili.com/video" ) ) {
                return BiliVideoGenre.VIDEO;
            }
            return BiliVideoGenre.UNKNOWN;
        }

        private void tb_video_url_TextChanged( Object sender, EventArgs e )
        {

        }

        private void InLobby_FormClosing( Object sender, FormClosingEventArgs e )
        {
            DialogResult result = MessageBox.Show( isHost ? "是否关闭房间?\n这会导致您房间中的所有人视频中断。" : "是否退出房间?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
            if ( result == DialogResult.OK ) {
                Global.IsInLobby = false;
                try {
                    browserContoller.Close();
                    syncWorker.Stop();
                    bgw_viewers_syncer.CancelAsync();
                    if ( isHost ) {
                        borrower.Return();
                    } else {
                        borrower.Leave( Global.MyName );
                    }
                } catch ( Exception ex ) {
                    MessageBox.Show( ex.Message );
                }
            } else {
                e.Cancel = true;
            }
        }

        public delegate void MyInvoke();

        private void freshViewerList()
        {
            lb_viewerList.Items.Clear();
            var lobs = borrower.QueryViewers();
            foreach ( var l in lobs ) {
                lb_viewerList.Items.Add( l );
            }
        }

        private void bgw_viewers_syncer_DoWork( Object sender, DoWorkEventArgs e )
        {
            while ( true ) {
                Thread.Sleep( 1000 );
                MyInvoke mi = new MyInvoke( freshViewerList );
                BeginInvoke( mi );
            }
        }

        private void lb_viewerList_SelectedIndexChanged( Object sender, EventArgs e )
        {

        }

        private void bt_start_Click( Object sender, EventArgs e )
        {
            try {
                browserContoller = new BrowserContoller( GetVideoGenre(), tb_video_url.Text, cookie, Global.WebdriverDir, Global.ChromeBinPath );
                if ( syncWorker != null ) {
                    return;
                }
                syncWorker = new SyncWorker( Global.MyName, browserContoller, Global.SelectedServer );
                syncWorker.Do();
            } catch ( Exception ex ) {
                stLogger.Log( "", ex );
            }
        }
    }
}

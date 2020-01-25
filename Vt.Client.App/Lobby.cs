using stLib.Excep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vt.Client.Core;
using Vt.Client.WebController;

namespace Vt.Client.App {
    public class Lobby {
        public LobbyBorrower LB { get; set; } = null;
        public UdpProtocolMaker PM = new UdpProtocolMaker();
        private bool isHost;
        public SyncWorker SW { get; set; } = null;
        public BrowserContoller BC { get; set; } = null;


        public string Start( string lobbyName, string cookie = "", string url = "",  string password = "", string offset = "", bool isHost = false )
        {
            string msg = "";
            LB = new LobbyBorrower( G.SelectedServer, lobbyName );

            if ( isHost ) {
                msg = G.Lobby.LB.Lend(
                        new YPM.Packager.ypmPackage( "create_lobby", new string[] {
                            lobbyName,
                            password,
                            offset,
                            G.MyName,
                            url,
                            cookie != "" ? cookie : "no"
                        } ).ToString() );
            }

            BC = new BrowserContoller( url, cookie, G.WebdriverDir, G.ChromeBinPath );
            this.isHost = isHost;

            try {
                if ( SW != null ) {
                    Exit();
                }
                SW = new SyncWorker( G.MyName, BC, LB, G.SelectedServer );
                
                ExcepHelper.LogOnly( BC.TryLogin );
                ExcepHelper.LogOnly( SW.NavToVideoUrl );
                SW.Do();
            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message );
                throw ex;
            }
            return msg;
        }

        public void Exit()
        {
            SW.Stop();
            BC.Close();
            if ( isHost ) {
                LB.Return();
            } else {
                LB.Leave( G.MyName );
            }
        }
    }
}

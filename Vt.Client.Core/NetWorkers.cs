using stLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using stLib.Net.Haste;
using stLib.Log;
using stLib.Net;
using Vt.Client.WebController;
using YPM.Packager;
using stLib.Excep;

namespace Vt.Client.Core {
    public class SyncWorker {
        public SyncWorker( string nickName, BrowserContoller browserContoller, LobbyBorrower b, IPPort ipport )
        {
            lobbyName = b.LobbyName;
            this.nickName = nickName;
            this.bc = browserContoller;
            this.b = b;
            this.syn = new UdpClient_();
            this.ipport = ipport;
        }

        UdpProtocolMaker protocolMaker = new UdpProtocolMaker();

        private readonly IPPort ipport;
        private bool stopFlag = false;
        private readonly UdpClient_ syn;
        private readonly String lobbyName;
        private readonly String nickName;
        private readonly BrowserContoller bc;
        private readonly LobbyBorrower b;

        private void syncVideoMode()
        {
            bc.BringToScreen();
            while ( !stopFlag ) {
                if ( bc.GetVideoGenre() == BiliVideoGenre.UNKNOWN ) {
                    return;
                }
                Thread.Sleep( 900 );
                ExcepHelper.LogOnly( updateLobbyInfo, "in sendLocationPermantly" );
                ExcepHelper.LogOnly( processVideoSync, "in sendLocationPermantly" );
            }
        }

        public void NavToVideoUrl()
        {
            bc.GoToVideoPage();
            Thread.Sleep( 3000 );
            bc.TryClearUnusedElements();
            bc.CreateLobbyInfo();
        }
        public void updateLobbyInfo()
        {
            List<string> lobs = new List<string>();
            try {
                lobs = b.QueryViewers();
                lobs.Insert( 0, lobbyName );
            } catch ( Exception ex ) {
                stLogger.Log( ex );
            }
            //foreach ( var l in lobs )  bc.Log(l);
            bc.UpdateLobbyStatus( lobs );
        }

        public void processVideoSync()
        {
            bool isUrlChanged = bc.IsUrlChanged();

            var recv = syn.SendMessage(
            protocolMaker.MakePackageMsg(
                lobbyName,
                nickName,
                isUrlChanged ? "00:00" : bc.GetCurrentLocationText(),
                isUrlChanged ? true : bc.IsPause(),
                bc.VideoUrl )
            , ipport );

            if ( isUrlChanged ) {
                NavToVideoUrl();
                return;
            }

            Console.WriteLine( recv );
            switch ( recv ) {
                case "OK": return;
                case "p": bc.Pause(); return;
                case "s": bc.Play(); return;
            }
            if ( recv.Contains( "http" ) ) {
                bc.VideoUrl = recv;
                NavToVideoUrl();
                return;
            }
            if ( recv.Contains( ":" ) ) {
                bc.ShowVideoControl();
                bc.LocateVideoBasic( recv );
                bc.HideVideoControl();
                return;
            }
        }

        public Task SyncHandle { get; set; } = null;
        public void Do()
        {
            TaskFactory taskFactory = new TaskFactory();
            stopFlag = false;
            SyncHandle = taskFactory.StartNew( syncVideoMode );
        }

        public void Resume()
        {

        }

        public void Pause()
        {

        }

        public void Stop()
        {
            if ( SyncHandle != null ) {
                stopFlag = true;
            }
        }
    }

    public class LobbyBorrower {
        private readonly IPPort ipport;
        public LobbyBorrower( IPPort ipport, string lobbyName )
        {
            this.ipport = ipport;
            LobbyName = lobbyName;
            LobbyName = lobbyName;
            udpClient = new UdpClient_();
        }

        public String LobbyName { get; }

        private UdpClient_ udpClient;

        public string Lend( string msg )
        {
            try {
                return TcpClient_.SendMessage_ShortConnect( msg, ipport );
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                throw;
            }
        }

        public string Return()
        {
            try {
                return TcpClient_.SendMessage_ShortConnect( "delete_lobby@" + LobbyName, ipport );
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                throw;
            }
        }

        public List<string> QueryViewers()
        {
            try {
                return StringHelper.ParseComData( udpClient.SendMessage( "get_lobby_viewers@" + LobbyName, ipport ) );
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                throw;
            }
        }

        public string Leave( string myName )
        {
            try {
                return TcpClient_.SendMessage_ShortConnect(
                    new ypmPackage( "exit_lobby",
                                    new string[] {
                                        myName, LobbyName
                                    } ).ToString()
                    , ipport );
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                throw;
            }
        }
    }

    public class Viewer {
        private readonly String name;

        public Viewer( string name )
        {
            this.name = name;
        }
    }
}

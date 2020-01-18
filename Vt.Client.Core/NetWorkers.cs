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
using Vt.Client.Core.Protocol;
using stLib.Log;

namespace Vt.Client.Core {
    public class SyncWorker {
        public SyncWorker( string nickName, BrowserContoller browserContoller, string ip, string udpPort )
        {
            this.nickName = nickName;
            this.browserContoller = browserContoller;
            this.ip = ip;
            this.udpPort = udpPort;
            this.synccer = new UdpClient_();
        }

        ProtocolMaker protocolMaker = new ProtocolMaker();

        private bool stopFlag = false;
        private readonly UdpClient_ synccer;
        private readonly String nickName;
        private readonly BrowserContoller browserContoller;
        private readonly String ip;
        private readonly String udpPort;

        private void sendLocationPermantly()
        {
            browserContoller.TryLogin();
            browserContoller.GoToVideoPage();
            Thread.Sleep( 3000 );

            while ( !stopFlag ) {
                try {
                    Thread.Sleep( 200 );
                    var recv = synccer.SendMessage(
                        protocolMaker.MakePackageMsg(
                            nickName,
                            browserContoller.GetCurrentLocationText(),
                            browserContoller.IsPause() )
                        , ip, udpPort );
                    Console.WriteLine( recv );
                    switch ( recv ) {
                        case "OK":
                            continue;
                        case "p":
                            browserContoller.Pause();
                            continue;
                        case "s":
                            browserContoller.Play();
                            continue;
                        default:
                            if ( recv.Contains( ":" ) ) {
                                browserContoller.ShowVideoControl();
                                browserContoller.LocateVideoBasic( recv );
                                browserContoller.HideVideoControl();
                            }
                            continue;
                    }
                } catch ( Exception ex ) {
                    Console.WriteLine( ex );
                    continue;
                }
            }
        }
        public Task SyncHandle { get; set; } = null;
        public void Do()
        {
            TaskFactory taskFactory = new TaskFactory();
            stopFlag = false;
            SyncHandle = taskFactory.StartNew( sendLocationPermantly );
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
        private readonly String ip;
        private readonly String tcpPort;

        public LobbyBorrower( string ip, string tcpPort, string lobbyName, string lobbyPassword )
        {
            this.ip = ip;
            this.tcpPort = tcpPort;
            LobbyName = lobbyName;
            LobbyPassword = lobbyPassword;
            LobbyName = lobbyName;
        }

        public String LobbyName { get; }
        public String LobbyPassword { get; }

        public string Lend( string msg )
        {
            try {
                return TcpClient_.SendMessage_ShortConnect( msg, ip, tcpPort );
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                throw;
            }
        }

        public string Return()
        {
            try {
                return TcpClient_.SendMessage_ShortConnect( "delete_lobby@" + LobbyName, ip, tcpPort );
            } catch ( Exception ex ) {
                stLogger.Log( ex.ToString() );
                throw;
            }
        }

        public string[] QueryViewers()
        {
            try {
                return StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "get_lobby_viewers@" + LobbyName, ip, tcpPort ) );
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

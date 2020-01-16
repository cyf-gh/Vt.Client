using stLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vt.Client.Core.Log;
using Vt.Client.Core.Net;
using Vt.Client.Core.Protocol;

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

        private readonly UdpClient_ synccer;
        private readonly String nickName;
        private readonly BrowserContoller browserContoller;
        private readonly String ip;
        private readonly String udpPort;

        private void sendLocationPermantly()
        {
            //browserContoller.Hide();
            browserContoller.TryLogin();
            browserContoller.GoToVideoPage();
            //browserContoller.Max();
            Thread.Sleep( 3000 );
            //browserContoller.ShowVideoControl();
            //browserContoller.LocateVideoAtInFullScreenMode( "10" );
            //browserContoller.HideVideoControl();

            while ( true ) {
                try {
                    Thread.Sleep(100);
                    var recv = synccer.SendMessage(
                        protocolMaker.MakePackageMsg(
                            nickName,
                            browserContoller.GetCurrentLocationText(),
                            browserContoller.IsPause() )
                        , ip, udpPort );
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
                            if ( recv.Contains(":") ) {
                                browserContoller.ShowVideoControl();
                                browserContoller.LocateVideoBasic( recv );
                                browserContoller.HideVideoControl();
                            }
                            continue;
                    }
                    Console.WriteLine( synccer.RecievMessage() );
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
            SyncHandle = taskFactory.StartNew( sendLocationPermantly );
        }

        public void Stop()
        {
            SyncHandle.GetAwaiter();
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
                VtLogger.A.Error( ex.ToString() );
                throw;
            }
        }

        public string Return()
        {
            try {
                return TcpClient_.SendMessage_ShortConnect( "delete_lobby@"+LobbyName, ip, tcpPort );
            } catch ( Exception ex ) {
                VtLogger.A.Error( ex.ToString() );
                throw;
            }
        }

        public string[] QueryViewers()
        {
            try {
                return StringHelper.ParseComData( TcpClient_.SendMessage_ShortConnect( "get_lobby_viewers@" + LobbyName, ip, tcpPort )  );
            } catch ( Exception ex ) {
                VtLogger.A.Error( ex.ToString() );
                throw;
            }
        }
    }

}

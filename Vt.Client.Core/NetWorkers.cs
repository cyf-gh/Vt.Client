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
            while ( true ) {
                synccer.SendMessage(
                    protocolMaker.MakePackageMsg(
                        nickName,
                        browserContoller.GetCurrentLocationText() )
                    , ip, udpPort );
                Console.WriteLine( synccer.RecievMessage() );
                Thread.Sleep( 300 );
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
        public bool Lend( string ip, string tcpPort )
        {
            try {
                string lendLobbyContrast = "";
                TcpClient_.SendMessage_ShortConnect( lendLobbyContrast, ip, tcpPort );
                return true;
            } catch ( Exception ex ) {
                VtLogger.A.Error( ex.ToString() );
                throw;
            }
        }
    }

}

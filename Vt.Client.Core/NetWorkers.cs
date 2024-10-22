﻿using stLib.Common;
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

namespace Vt.Client.Core {
    public class SyncWorker {
        public SyncWorker( string lobbyName, string nickName, IBrowserContoller browserContoller, IPPort ipport )
        {
            this.lobbyName = lobbyName;
            this.nickName = nickName;
            this.browserContoller = browserContoller;
            this.synccer = new UdpClient_();
            this.ipport = ipport;
        }

        UdpProtocolMaker protocolMaker = new UdpProtocolMaker();

        private readonly IPPort ipport;
        private bool stopFlag = false;
        private readonly UdpClient_ synccer;
        private readonly String lobbyName;
        private readonly String nickName;
        private readonly IBrowserContoller browserContoller;

        private void sendLocationPermantly()
        {
            try {
                browserContoller.TryLogin();
                browserContoller.GoToVideoPage();
                Thread.Sleep( 3000 );
                browserContoller.TryClearUnusedElements();
            } catch ( Exception ex ) {
                stLogger.Log( ex );
            }
            while ( !stopFlag ) {
                try {
                    Console.WriteLine( browserContoller.GetCurrentLocationText() );
                    Thread.Sleep( 900 );
                    var recv = synccer.SendMessage(
                        protocolMaker.MakePackageMsg(
                            lobbyName,
                            nickName,
                            browserContoller.GetCurrentLocationText(),
                            browserContoller.IsPause() )
                        , ipport );
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
                    stLogger.Log( "In sendLocationPermantly", ex );
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
        private readonly IPPort ipport;
        public LobbyBorrower( IPPort ipport, string lobbyName, string lobbyPassword )
        {
            this.ipport = ipport;
            LobbyName = lobbyName;
            LobbyPassword = lobbyPassword;
            LobbyName = lobbyName;
            udpClient = new UdpClient_();
        }

        public String LobbyName { get; }

        private UdpClient_ udpClient;

        public String LobbyPassword { get; }

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
                                    }).ToString()
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

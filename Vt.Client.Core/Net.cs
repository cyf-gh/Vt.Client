using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vt.Client.Core.Log;

namespace Vt.Client.Core.Net {
    public class UdpClient_ {
        public UdpClient sender;
        public UdpClient_()
        {
            sender = new UdpClient();
        }

        public string SendMessage( string message, string ip, string udpPort )
        {
            // var message = obj as string;
            byte[] sendbytes = Encoding.ASCII.GetBytes( message );

            IPEndPoint remoteIpep = new IPEndPoint(
                IPAddress.Parse( ip ), Convert.ToInt32( udpPort ) ); // 发送到的IP地址和端口号

            sender.Send( sendbytes, sendbytes.Length, remoteIpep );
            byte[] bytRecv = sender.Receive( ref remoteIpep );
            string resp = Encoding.ASCII.GetString( bytRecv, 0, bytRecv.Length );
            return resp;
        }

        public string RecievMessage()
        {
            IPEndPoint remoteIpep = new IPEndPoint( IPAddress.Any, 0 );
            byte[] bytRecv = sender.Receive( ref remoteIpep );
            string message = Encoding.ASCII.GetString( bytRecv, 0, bytRecv.Length );
            return message;
        }
    }

    public class TcpClient_ {
        static public string SendMessage_ShortConnect( string msg, string ip, string tcpPort )
        {
            TcpClient tcpClient = new TcpClient();
            string Resp = "";
            try {
                tcpClient.Connect( IPAddress.Parse( ip ), Convert.ToInt32( tcpPort ) );
            } catch ( Exception ex ) {
                throw ex;
            }

            NetworkStream ntwStream = tcpClient.GetStream();
            if ( ntwStream.CanWrite ) {
                Byte[] bytSend = Encoding.UTF8.GetBytes( msg );
                ntwStream.Write( bytSend, 0, bytSend.Length );
            } else {
                VtLogger.A.Debug( "Cannot write tcp stream." );
            }
            if ( ntwStream.CanRead ) {
                const int maxLength = 1024;
                Byte[] bytSend = new Byte[maxLength];
                Byte[] bytSend2 = new Byte[ntwStream.Read( bytSend, 0, maxLength )];
                for ( int i = 0; i < bytSend2.Length; i++ ) {
                    bytSend2[i] = bytSend[i];
                }
                Resp = Encoding.UTF8.GetString( bytSend2 );
            }
            ntwStream.Close();
            tcpClient.Close();
            return Resp;
        }
    }
}

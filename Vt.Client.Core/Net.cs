using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Vt.Client.Core.Log;

namespace Vt.Client.Core.Net {
    public class UdpClient_ {
        public UdpClient sender;
        public UdpClient_()
        {
            sender = new UdpClient();
        }

        public void SendMessage( string message, string ip, string udpPort )
        {
            // var message = obj as string;
            byte[] sendbytes = Encoding.Unicode.GetBytes( message );

            IPEndPoint remoteIpep = new IPEndPoint(
                IPAddress.Parse( ip ), Convert.ToInt32( udpPort ) ); // 发送到的IP地址和端口号

            sender.Send( sendbytes, sendbytes.Length, remoteIpep );
        }

        public string RecievMessage()
        {
            IPEndPoint remoteIpep = new IPEndPoint( IPAddress.Any, 0 );
            byte[] bytRecv = sender.Receive( ref remoteIpep );
            string message = Encoding.ASCII.GetString( bytRecv, 0, bytRecv.Length );
            return message + ',' + remoteIpep.ToString();
        }
    }

    public class TcpClient_ {
        static public async void SendMessage_ShortConnect( string msg, string ip, string tcpPort )
        {
            TcpClient tcpClient = new TcpClient();
            try {
                tcpClient.Connect( IPAddress.Parse( ip ), Convert.ToInt32( tcpPort ) );
            } catch ( Exception ex ) {
                throw ex;
            }

            NetworkStream ntwStream = tcpClient.GetStream();
            if ( ntwStream.CanWrite ) {
                Byte[] bytSend = Encoding.UTF8.GetBytes( msg );
                await ntwStream.WriteAsync( bytSend, 0, bytSend.Length );
            } else {
                VtLogger.A.Debug( "Cannot write tcp stream." );
            }

            ntwStream.Close();
            tcpClient.Close();
        }
    }
}

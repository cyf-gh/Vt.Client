using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Vt.Client.Core {
    public class Synccer {
        public UdpClient sender;
        public Synccer()
        {
            sender = new UdpClient();
        }

        public void SendMessage( string message )
        {
            // var message = obj as string;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);

            IPEndPoint remoteIpep = new IPEndPoint(
                IPAddress.Parse("127.0.0.1"), 8800); // 发送到的IP地址和端口号

            sender.Send( sendbytes, sendbytes.Length, remoteIpep );
        }

        public string RecievMessage()
        {
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);
            byte[] bytRecv = sender.Receive(ref remoteIpep);
            string message = Encoding.ASCII.GetString( bytRecv, 0, bytRecv.Length );
            return message+','+ remoteIpep.ToString();
        }
    }
}

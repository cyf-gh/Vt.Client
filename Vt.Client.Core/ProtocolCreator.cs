using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stLib.Common;

namespace Vt.Client.Core.Protocol
{
    public class ProtocolMaker
    {
        // "$name,$password,$max_offset,$host_name,$video_url,$is_share_cookie”
        public string MakeLobbyContrast( string lobbyName, string lobbyPassword, string maxOffset, string hostName, string videoUrl, string isShareCookie )
        {
            string msg = string.Format( "create_lobby@{0},{1},{2},{3},{4},{5}", lobbyName, lobbyPassword, maxOffset, hostName, videoUrl, isShareCookie );
            if ( StringHelper.CountOfKeyIn( ',', msg ) != 5 ) {
                throw new Exception( "Please check if you use ',' in any of\nLobby Name\nPassword\nYour Name\nVideoUrl" );
            }
            return msg;
        }
        public string MakePackageMsg(string name, string currentLocation) 
        {
            return string.Format("{0},{1},{2}", name, currentLocation, DateTime.Now);
        }
        public string EnterLobby( string name, string password )
        {
            return string.Format("join_lobby@,{0},{1}", name, password );
        }
    }
}

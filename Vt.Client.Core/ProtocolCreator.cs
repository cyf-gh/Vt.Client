using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stLib.Common;

namespace Vt.Client.Core
{
    public class UdpProtocolMaker
    {
        public string MakePackageMsg(string lobbyName, string name, string currentLocation, bool isPause) 
        {
            return string.Format("{0},{1},{2},{3}", lobbyName, name, currentLocation, isPause? "p": "s");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vt.Client.Core.Protocol
{
    public class ProtocolMaker
    {
        public string MakePackageMsg(string name, string currentLocation) 
        {
            return string.Format("{0},{1},{2}", name, currentLocation, DateTime.Now);
        }
    }
}

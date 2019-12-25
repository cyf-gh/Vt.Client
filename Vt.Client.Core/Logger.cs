using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Vt.Client.Core.Log {
    public class VtLogger {
        static public NLog.Logger A { get; set; } = NLog.LogManager.GetCurrentClassLogger();
    }
}

using stLib.Net;
using System.Collections.Generic;
using System.IO;

namespace Vt.Client.App {
    public static class Global {
        public static string MyName { get; set; }

        public static List<IPPort> ServerInfos { get; set; }

        public static IPPort SelectedServer { get; set; } = null;
        public static bool IsInLobby { get; set; } = false;

        public static bool IsDebugMod { get; set; } = false;

        public static string ChromeBinPath { get; set; } = "";
        public static string WebdriverDir { get; set; } = "";
    }
}

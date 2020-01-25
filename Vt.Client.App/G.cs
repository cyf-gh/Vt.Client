using stLib.Net;
using System.Collections.Generic;
using System.IO;
using Vt.Client.Core;
using Vt.Client.WebController;

namespace Vt.Client.App {
    public static class G {
        public static string MyName { get; set; }

        public static List<IPPort> ServerInfos { get; set; }

        public static IPPort SelectedServer { get; set; } = null;
        public static bool IsInLobby { get; set; } = false;

        public static bool IsDebugMod { get; set; } = false;

        public static string ChromeBinPath { get; set; } = "";
        public static string WebdriverDir { get; set; } = "";

        public static Lobby Lobby { get; set; } = new Lobby();
    }
}

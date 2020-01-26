using IniParser;
using IniParser.Model;
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

        public static FileIniDataParser InitParser = new FileIniDataParser();
        public static IniData IniData { get; set; }

        public const int Version = 1000;

        public static void LoadConfig()
        {
            IniData = InitParser.ReadFile( "./config/app.cfg" );
            G.IsDebugMod = IniData["dev"]["mode"] == "debug";
            G.ChromeBinPath = IniData["web"]["chrome_bin"] == "def" ? "" : IniData["web"]["chrome_bin"];
            if ( !File.Exists( G.ChromeBinPath ) ) {
                G.ChromeBinPath = "";
            }
            G.WebdriverDir = IniData["web"]["webdriver_dir"];
            DriverHelper.Browser = IniData["web"]["browser"];
        }

        public static void SaveConfig()
        {
            IniData["web"]["browser"] = DriverHelper.Browser;
            IniData["web"]["chrome_bin"] = G.ChromeBinPath == "" ? "def" : "./external/Chrome/chrome.exe";

            G.InitParser.WriteFile( "./config/app.cfg", G.IniData );
        }
    }
}

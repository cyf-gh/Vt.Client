using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vt.Client.WebController {
    /// <summary>
    /// Selenium提供的Cookie无法直接从json反序列化的对象构造，故创建一个中间对象
    /// </summary>
    class CookieTmp {
        public bool Secure { get; set; }
        public bool IsHttpOnly { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public DateTime? Expiry { get; set; }

        public Cookie ToCookie()
        {
            CookieTmp cookie = this;
            return new Cookie( cookie.Name, cookie.Value, cookie.Domain, cookie.Path, Expiry );
        }
    }
    public class CookieHelper {
        public static string GetLocalCookieString( string filePath )
        {
            if ( File.Exists( filePath ) ) {
                return File.ReadAllText( filePath );
            } else {
                File.Create( filePath );
                return null;
            }
        }
    }
}

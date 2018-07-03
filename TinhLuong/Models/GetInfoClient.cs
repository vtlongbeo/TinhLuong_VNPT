
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Management;
using System.Management.Instrumentation;
namespace TinhLuong.Models
{
    public class GetInfoClient
    {
        public HttpBrowserCapabilities Browser { get; set; }
        public string GetMACAddress()
        {

            //ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Win32_NetworkAdapterConfiguration");
            //ManagementObjectCollection objMOC = objMOS.Get();
            //string MACAddress = String.Empty;
            //foreach (ManagementObject objMO in objMOC)
            //{
            //    if (MACAddress == String.Empty) // only return MAC Address from first card 
            //    {
            //        MACAddress = objMO["MacAddress"].ToString();
            //    }
            //    objMO.Dispose();
            //}
            //MACAddress = MACAddress.Replace(":", "");
            //return MACAddress;
            //get Mac this computer
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public  string GetIP()
        {
            try
            {
                Console.WriteLine(string.Join("|", new List<object> {
                    HttpContext.Current.Request.UserHostAddress,
                    HttpContext.Current.Request.Headers["X-Forwarded-For"],
                    HttpContext.Current.Request.Headers["REMOTE_ADDR"]
                })
            );
                var ip = HttpContext.Current.Request.UserHostAddress;
                if (HttpContext.Current.Request.Headers["X-Forwarded-For"] != null)
                {
                    ip = HttpContext.Current.Request.Headers["X-Forwarded-For"];
                    Console.WriteLine(ip + "|X-Forwarded-For");
                }
                else if (HttpContext.Current.Request.Headers["REMOTE_ADDR"] != null)
                {
                    ip = HttpContext.Current.Request.Headers["REMOTE_ADDR"];
                    Console.WriteLine(ip + "|REMOTE_ADDR");
                }
                return ip;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return null;
        }

        public string GetBrowserInfo()
        {
            HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
            string UserAgent = HttpContext.Current.Request.UserAgent;
            string userPlatform = GetUserPlatform(UserAgent);
            string getVerm = GetMobileVersion(UserAgent, userPlatform);
            string info = "browser: " + bc.Browser.ToString() + " - Version: " + bc.Version.ToString() +" - Platform: " +userPlatform +" - ISMoblieVersion: " + getVerm;
            return info;
        }
        public String GetUserPlatform(string ua)
        {

            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";

            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

            if (ua.Contains("Mac OS"))
                return "Mac OS";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                return "Windows 10";

            //fallback to basic platform:
            return HttpContext.Current.Request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
        }

        public String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }
    }
}
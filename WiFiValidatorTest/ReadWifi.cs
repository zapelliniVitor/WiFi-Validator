using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WiFiValidatorTest
{
    public class ReadWifi
    {

        public string GetWifiIp()
        {
            string[] strIP = null;
            int count = 0;
            string s = null;

            IPHostEntry hostEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (hostEntry.AddressList.Length > 0)
            {
                strIP = new string[hostEntry.AddressList.Length];
                foreach (IPAddress ip in hostEntry.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        //strIP[count] = ip.ToString();
                        //s += strIP[count];
                        s += ip.ToString();
                        count++;
                    }
                }
            }

            return s;
        }
    
    }
}

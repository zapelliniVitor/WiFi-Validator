using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WiFiValidatorTest
{
    class Program
    {
       public bool IpValidator()
        {

            //if (new FileInfo(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt").Length == 0)
            if (new FileInfo(new Config().Adress()).Length == 0)
            {
                new Config().StoreWifiIP();
                return false;
            }

            return true;
        }
    }
}

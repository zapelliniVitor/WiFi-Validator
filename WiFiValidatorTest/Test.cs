using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WiFiValidatorTest
{
    class Test
    {
        static void Main(string[] args)
        {
            if (new FileInfo(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt").Length == 0)
            {
                Console.WriteLine(new DAL().StoreWifiIP());
            }

            Console.WriteLine(new DAL().validateWiFi());
        }
    }
}

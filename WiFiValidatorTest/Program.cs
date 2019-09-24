using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WiFiValidatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!new Config().VerifyIfTxtExists())
            {
                new Config().StoreWifiIP();
            }


            //if (new FileInfo(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt").Length == 0)
            if (new FileInfo(@"C:\Users\moc\Source\Repos\WiFi-Validator\WiFiValidatorTest\bin\Debug\WiFiIP.txt").Length == 0)
            {
                Console.WriteLine(new Config().StoreWifiIP());
            }

            Console.WriteLine(new Config().ValidateWiFi());
        }
    }
}

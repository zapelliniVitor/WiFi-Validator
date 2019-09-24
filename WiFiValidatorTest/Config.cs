using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WiFiValidatorTest
{
    class DAL
    {
        public string StoreWifiIP()
        {
            System.IO.File.WriteAllText(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt", new ReadWifi().GetWifiIp());
            return "IP gravado com sucesso. \r\n";
        }

        public string validateWiFi()
        {
            string s = File.ReadAllText(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt");
            if (s == new ReadWifi().GetWifiIp())
            {
                return "IP compativel. \r\n ACESSO PERMITIDO!";
            }

            return "IP não compativel. \r\n ACESSO NEGADO!";
        }
    }
}

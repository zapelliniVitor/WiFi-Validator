﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WiFiValidatorTest
{
    class Config
    {
        public bool VerifyIfTxtExists()
        {
            if (System.IO.File.Exists(Adress()))
            {
                return true;
            }
            return false;
        }

        public string StoreWifiIP()
        {
            //System.IO.File.WriteAllText(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt", new ReadWifi().GetWifiIp());
            FileStream fs1 = new FileStream(Adress(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter w = new StreamWriter(fs1);
            w.Write(new ReadWifi().GetWifiIp());
            w.Close();


            return "IP gravado com sucesso. \r\n";
        }

        public string ValidateWiFi()
        {
            //string s = System.IO.File.ReadAllText(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt");
            string[] s = System.IO.File.ReadAllLines(Adress());
            int count = 0;

            foreach (string ip in s)
            {
                if (s[count] == new ReadWifi().GetWifiIp())
                {
                    return "IP compativel. \r\n" + "ACESSO PERMITIDO!";
                }
                count++;
            }
            

            return "IP não compativel. \r\n" + "ACESSO NEGADO!";
        }

        public string Adress()
        {
            return @"C:\Users\moc\Source\Repos\WiFi-Validator\WiFiValidatorTest\bin\Debug\WiFiIP.txt";
        }
    }
    
}

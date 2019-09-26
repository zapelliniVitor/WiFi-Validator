using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WiFiValidatorTest
{
    class Config
    {
        public bool VerifyDataBase()
        {
            if (!new DAL().VerifyTableInDataBase())
            {
                return false;
            }

            return true;
        }

        public bool StoreWifiIP()
        {
            //System.IO.File.WriteAllText(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt", new ReadWifi().GetWifiIp());
            //FileStream fs1 = new FileStream(Adress(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //StreamWriter w = new StreamWriter(fs1);
            //w.Write(GetWifiIp());
            //w.Close();

            return new DAL().InsertIP();

        }

        public bool ValidateWiFi()
        {
            //string s = System.IO.File.ReadAllText(@"C:\Users\User\Desktop\WifiIP\WiFiIP.txt");
            string[] s = System.IO.File.ReadAllLines(Adress());
            int count = 0;

            foreach (string ip in s)
            {
                if (s[count] == GetWifiIp())
                {
                    return true;
                }
                count++;
            }

            return false;
        }

        public string Adress()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moc\Documents\WiFiDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

        internal string GetWifiIp()
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

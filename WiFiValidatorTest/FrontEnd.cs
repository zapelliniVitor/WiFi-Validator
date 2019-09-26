using System;
using System.Collections.Generic;
using System.Text;

namespace WiFiValidatorTest
{
    public class FrontEnd
    {
        static void Main(string[] args)
        {
            
            if (!new Config().VerifyDataBase())
            {
                Console.WriteLine("Não existe dados, favor contatar suporte Dr. Mapper.");
                return;
            }

            Console.WriteLine("PRIMEIRO ACESSO? \r\n" +
                              "DIGITE 1 PARA SIM OU 2 PARA NÃO.");
            string s = Console.ReadLine();
            if (s == "1")
            {
                Console.Clear();
                if (!new Config().StoreWifiIP())
                {
                    Console.WriteLine("IP já configurado. Tente novamente.");
                    return;
                }
            }
            else if(s == "2")
            {
                if (!new Program().IpValidator())
                {

                    Console.WriteLine("IP não compatível, favor contatar suporte Dr. Mapper.");
                    return;
                }
            }
            else if (s != "2" && s != "1")
            {
                Console.Clear();
                Console.WriteLine("É 1 OU 2, seu acéfalo, escreve direito, energúmeno.");
                return;
            }

            Console.WriteLine("Seja bem-vindo, seu bosta.");

        }
    }
}

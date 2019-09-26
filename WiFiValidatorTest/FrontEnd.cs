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
            }
            

            if (!new Program().IpValidator())
            {
                Console.WriteLine("IP não compatível, favor contatar suporte Dr. Mapper.");
            }
            
        }

    }
}

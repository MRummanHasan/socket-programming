using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress test1 = IPAddress.Parse("192.168.1.1");
            IPAddress test2 = IPAddress.Loopback;
            IPAddress test3 = IPAddress.Broadcast;
            IPAddress test4 = IPAddress.Any;
            IPAddress test5 = IPAddress.None;


            IPHostEntry ihe = Dns.GetHostByName(Dns.GetHostName());
            IPAddress myself = ihe.AddressList[0];
            Console.WriteLine(myself);
            
            if (IPAddress.IsLoopback(test2))
            {
                Console.WriteLine("The Loopback address is: {0}", test2.ToString());
            }
            else
            {
                Console.WriteLine("Error obtaining the loopback address");
            }
            Console.WriteLine("The local IP address is: {0}",myself.ToString());

            if (myself == test2)
            {
                Console.WriteLine("Loopback address is same as local address");
            }
            else
            {
                Console.WriteLine("Loopback address is not same as local address");
            }
            Console.WriteLine();
            Console.WriteLine("test address {0}",test1);
            Console.WriteLine("Braodcast Address {0}", test3);
            Console.WriteLine("ANY address {0}", test4);
            Console.WriteLine("NONE address {0}", test5);
            



            Console.ReadKey();
        }
    }
}

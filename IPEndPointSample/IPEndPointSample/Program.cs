﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPEndPointSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress test1 = IPAddress.Parse("192.168.1.1");
            IPEndPoint ie = new IPEndPoint(test1, 8000);
            Console.WriteLine("The IPEndPoint is: {0} ", ie.ToString());
            Console.WriteLine("The AddressFamily is: {0} ",ie.AddressFamily);
            Console.WriteLine("The address is: {0}, and the port is: {1}\n", ie.Address, ie.Port);
            Console.WriteLine("The min port number is: {0} ", IPEndPoint.MinPort);
            Console.WriteLine("The max port number is: {0}\n", IPEndPoint.MaxPort);

            ie.Port = 80;
            Console.WriteLine("The changed IPEndPoint value is: {0} \n", ie.ToString());

            SocketAddress sa = ie.Serialize();
            Console.WriteLine("The SocketAddress is: {0} ", sa.ToString());
            Console.WriteLine("The IPEndPoint is: {0} ", ie.ToString());
            Console.WriteLine("The AddressFamily is: {0} ", ie.AddressFamily);
            Console.WriteLine("The address is: {0}, and the port is: {1}\n", ie.Address, ie.Port);
            
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(8888);
            server.Start();
            Console.WriteLine("Server Started. \n Waiting for clients...");

            Socket socketForClinets = server.AcceptSocket();

            if (socketForClinets.Connected)
            {
                NetworkStream ns = new NetworkStream(socketForClinets);
                StreamWriter sw = new StreamWriter(ns);

                Console.WriteLine("Server: Welcome Client");
                sw.WriteLine("Welcome Client");
                
                sw.Flush();
                sw.Close();
                ns.Close();
            }
            socketForClinets.Close();
        }
    }
}

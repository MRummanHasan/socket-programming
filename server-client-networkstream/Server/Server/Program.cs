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
            Console.WriteLine("Server Started & Waiting for client...");
            Socket socketForClinets = server.AcceptSocket();

            if (socketForClinets.Connected)
            {
                // send message to client
                NetworkStream ns = new NetworkStream(socketForClinets);
                StreamWriter sw = new StreamWriter(ns);

                Console.WriteLine("Server: Welcome Client");
                sw.WriteLine("WELCOME Client");
                sw.Flush();

                // Get message from client
                StreamReader sr = new StreamReader(ns);
                Console.WriteLine("Client >> " + sr.ReadLine());
                sw.Close();
                ns.Close();
            }

            socketForClinets.Close();

            Console.ReadKey();
        }
    }
}

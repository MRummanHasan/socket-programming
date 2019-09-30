using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(proA);
            t1.Name = "My Thread";
            Console.WriteLine("Before Start Thread");
            Console.WriteLine("Thread Name is = " + t1.Name);
            Console.WriteLine("Thread Live is = " + t1.IsAlive);
            Console.WriteLine("Thread Background is = " + t1.IsBackground);
            Console.WriteLine("Thread Id is = " + t1.ManagedThreadId);
            Console.WriteLine("Thread State is = " + t1.ThreadState);
            Console.WriteLine("Thread Domain is = " + Thread.GetDomain().FriendlyName);

            t1.Start();
            Console.WriteLine("\nAfter Start Thread");
            Console.WriteLine("Thread Name is = " + t1.Name);
            Console.WriteLine("Thread Live is = " + t1.IsAlive);
            Console.WriteLine("Thread Background is = " + t1.IsBackground);
            Console.WriteLine("Thread Id is = " + t1.ManagedThreadId);
            Console.WriteLine("Thread State is = " + t1.ThreadState);
            Console.WriteLine("Thread Domain is = " + Thread.GetDomain().FriendlyName);

            Thread t2 = new Thread(proA);
            Thread t3 = new Thread(proB);
            t2.Priority = ThreadPriority.Highest;
            t3.Priority = ThreadPriority.BelowNormal;
            t2.Start();
            t3.Start();

            Console.ReadKey();
        }

       

        static void proA(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("number A = {0}", i);
                Thread.Sleep(100);
            }
        }

        static void proB(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Num B = {0}", i);
                Thread.Sleep(100);
            }
        }


    }
}

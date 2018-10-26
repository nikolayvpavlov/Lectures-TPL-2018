using System;
using System.Collections.Generic;
using System.Threading;

namespace A.ThreadCosts
{
    class Program
    {
        static ManualResetEvent waitEvent = new ManualResetEvent(false);

        static void Worker()
        {
            waitEvent.WaitOne();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Creating a hell of a lot of threads...");
            var threads = new List<Thread>();
            while (true)
            {
                try
                {
                    var t = new Thread(Worker);
                    t.Start();
                    threads.Add(t);
                    if (threads.Count % 100 == 0)
                    {
                        Console.WriteLine($"{threads.Count} threads created.");
                    }
                }
                catch (OutOfMemoryException x)
                {
                    Console.WriteLine($"We ran out of memory at {threads.Count} threads");
                    break;
                }
            }
            waitEvent.Set();
            foreach (var t in threads) t.Join();
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}

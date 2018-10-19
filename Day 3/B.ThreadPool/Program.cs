using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace B.ThreadPool
{
    class Program
    {
        static ManualResetEvent workCompleted = new ManualResetEvent(false);
        static void SomeWorker(object state)
        {
            Console.WriteLine(" >> hello from the thread pool!");
            workCompleted.Set();
        }

        static void Main(string[] args)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(SomeWorker);
            Console.WriteLine("Item queued to the thread pool.");

            workCompleted.WaitOne();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}

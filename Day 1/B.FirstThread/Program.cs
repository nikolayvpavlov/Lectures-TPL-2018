using System;
using System.Threading;

namespace B.FirstThread
{
    class Program
    {
        static void ThreadMethod()
        {
            Console.WriteLine("Hello from my first thread!");
            Console.WriteLine("Thread id: " + 
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("My first thread is done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main process thread here: "
                + Thread.CurrentThread.ManagedThreadId);

            //ThreadMethod();
            var firstThread = new Thread(ThreadMethod);
            firstThread.Start();

            Console.WriteLine("Main is ready.");
            Console.ReadLine();
        }
    }
}

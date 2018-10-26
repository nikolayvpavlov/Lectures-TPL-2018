using System;
using System.Threading;

namespace B.Locking
{
    class Program
    {
        static int data = 1000;
        static object objLock = new object();

        static void Worker(object obj)
        {
            string tag = obj.ToString();
            for (int i = 0; i < 10; i++)
            {
                lock (objLock)
                {

                    data = data + 1;
                    Thread.Sleep(3);
                    data = data - 1;
                    Console.WriteLine(tag + ": " + data.ToString());
                }
                Thread.Sleep(3);
            }
        }

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Worker, "A");
            ThreadPool.QueueUserWorkItem(Worker, "B");
            ThreadPool.QueueUserWorkItem(Worker, "C");

            Console.ReadLine();
        }
    }
}

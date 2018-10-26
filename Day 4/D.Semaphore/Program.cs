using System;
using System.Threading;

namespace D.SemaphoreDemo
{
    class Program
    {
        private const int CustomersCount = 100;
        static Semaphore bar = new Semaphore(10, 10);
        static CountdownEvent countdown = new CountdownEvent(CustomersCount);

        static Random rand = new Random();

        static void Customer(object tag)
        {
            string number = tag.ToString();

            bar.WaitOne();
            Console.WriteLine($"{number} entered Da Bar.");
            while (true)
            {
                Thread.Sleep(100);
                int chance;
                lock (rand) { chance = rand.Next(3); }
                switch (chance)
                {
                    case 0:
                        Console.WriteLine($"{number} is drinking.");
                        break;
                    case 1:
                        Console.WriteLine($"{number} is dancing.");
                        break;
                    case 2:
                        Console.WriteLine($"{number} goes home.");
                        bar.Release();
                        countdown.Signal();
                        return;
                }
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < CustomersCount; i++)
            {
                ThreadPool.QueueUserWorkItem(Customer, i.ToString());
            }
            countdown.Wait();

            Console.WriteLine("Da Bar closed.");
            Console.ReadLine();
        }
    }
}

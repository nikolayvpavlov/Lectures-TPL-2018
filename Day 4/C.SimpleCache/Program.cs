using System;
using System.Collections.Generic;
using System.Threading;

namespace C.SimpleCache
{
    class Program
    {
        static Random rand = new Random();
        //static SimpleCache cache = new SimpleCache();
        static SimpleCacheEnhanced cache = new SimpleCacheEnhanced();

        static void Worker(object obj)
        {
            for (int i = 0; i < 100; i++)
            {
                string key;
                lock (rand)
                {
                    int k = rand.Next(10);
                    key = k.ToString();
                }
                var value = cache.GetValue(key);
                Console.WriteLine(value);
                Thread.Sleep(5);
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Worker);
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}

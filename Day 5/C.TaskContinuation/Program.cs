using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C.TaskContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> first = new Task<int>(
                () => 42
                );
            Task<int> second = first.ContinueWith<int>(
                previous => previous.Result / 2
                );
            Task third = second.ContinueWith(
                previous => Console.WriteLine(previous.Result));

            first.Start();

            third.Wait();
            Console.WriteLine("All completed.");

            Console.ReadLine();
        }
    }
}

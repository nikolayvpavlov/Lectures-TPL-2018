using System;
using System.Diagnostics;
using System.Linq;

namespace A.BranchPrediction
{
    class Program
    {
        static int size = 20_000_000;
        static int[] data;

        static void GenerateData()
        {
            Random rand = new Random();
            data = Enumerable
                .Repeat(0, size)
                .Select(i => rand.Next(10))
                .ToArray();
        }

        static int CountSmaller(int boundary)
        {
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                if (data[i] < boundary) result++;
            }
            return result;
        }

        static void Main(string[] args)
        {
            GenerateData();
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < 11; i++)
            {
                watch.Restart();
                int count = CountSmaller(i);
                watch.Stop();
                Console.WriteLine($"{i}: {count}, elapsed time: {watch.ElapsedMilliseconds}");
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}

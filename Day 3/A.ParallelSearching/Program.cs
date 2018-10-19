using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace A.ParallelSearching
{
    /// <summary>
    /// We search for closest points.
    /// For every point in array searchData, we search into inputData for the closest point, 
    /// and store it at the same position into array resultData;
    /// </summary>
    class Program
    {
        const int inputDataSize = 1_000_000;
        static Point[] inputData = new Point[inputDataSize];

        const int searchDataSize = 100;
        static Point[] searchData = new Point[searchDataSize];
        static Point[] resultData = new Point[searchDataSize];

        static void GenerateRandomData (Point[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Point()
                {
                    X = rand.NextDouble() * 100_000,
                    Y = rand.NextDouble() * 100_000
                };
            }
        }

        static void LinearSearch()
        {
            for (int i = 0; i < searchDataSize; i++)
            {
                SearchOne(i);
            }
        }

        private static void SearchOne(int i)
        {
            var searchPoint = searchData[i];
            foreach (var p in inputData)
            {
                if (resultData[i] == null)
                {
                    resultData[i] = p;
                }
                else
                {
                    double oldDistance = searchPoint.GetDistanceFrom(resultData[i]);
                    double newDistance = searchPoint.GetDistanceFrom(p);
                    if (newDistance < oldDistance)
                    {
                        resultData[i] = p;
                    }
                }
            }
        }

        static void AllThreadSearch()
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < searchDataSize; i++)
            {
                var thread = new Thread(
                    obj =>
                    {
                        int index = (int)obj;
                        SearchOne(index);
                    });
                thread.Start(i);
                threads.Add(thread);
            }
            foreach (var t in threads) t.Join();
        }

        static void FewThreadSearch()
        {
            int threadCount = Environment.ProcessorCount;
            int workSize = searchDataSize / threadCount;
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < threadCount; i++)
            {
                var thread = new Thread(
                    obj =>
                    {
                        int[] range = (int[])obj;
                        int from = range[0];
                        int to = range[1];
                        for (int index = from; index < to; index++)
                        {
                            SearchOne(index);
                        }
                    }
                    );
                int rangeFrom = workSize * i;
                int rangeTo = workSize * (i + 1);
                thread.Start(new int[]{ rangeFrom, rangeTo });
                threads.Add(thread);
            }
            foreach (var t in threads) t.Join();
        }

        static void Main(string[] args)
        {
            Console.Write("Generatic data...  ");
            GenerateRandomData(inputData);
            GenerateRandomData(searchData);
            Console.WriteLine("Done.");
            Console.WriteLine();

            Stopwatch watch = new Stopwatch();

            Console.Write("Linear searching... ");
            watch.Restart();
            LinearSearch();
            watch.Stop();
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds} ms.");

            Console.Write("All thread searching... ");
            watch.Restart();
            AllThreadSearch();
            watch.Stop();
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds} ms.");

            Console.Write("Few thread searching... ");
            watch.Restart();
            FewThreadSearch();
            watch.Stop();
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds} ms.");

            Console.WriteLine();
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}

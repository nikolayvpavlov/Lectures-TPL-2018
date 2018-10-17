using System;
using System.Threading;

namespace E.ReturnValueWaitCompletion
{
    class Program
    {
        static int answerValue;
        static void ComputeTheUltimateAnswer ()
        {
            int answer;
            Console.WriteLine("Thinking...");
            Thread.Sleep(1000);
            answer = 42;
            answerValue = answer;
            Console.WriteLine("Done.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("App started.");

            Thread worker = new Thread(ComputeTheUltimateAnswer);
            worker.Start();

            Console.WriteLine("Do something else.");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine("Now I need the answer.");
            Console.WriteLine("First I need to wait for the worker to complete.");
            worker.Join();
            Console.WriteLine("Worker is ready.");
            Console.WriteLine("And the answer is..." + answerValue);
            Console.ReadLine();
        }
    }
}

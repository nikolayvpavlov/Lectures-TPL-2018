using System;
using System.Threading;

namespace A.WaitCompletionAndCancellation
{
    class Program
    {
        enum WorkerResult { Started, Completed, Canceled }
        static WorkerResult Result;

        static ManualResetEvent WorkCompleteEvent;
        static ManualResetEvent WorkCancelEvent;

        static void Worker()
        {
            Result = WorkerResult.Started;
            for (int i = 0; i < 100; i++)
            {
                if (WorkCancelEvent.WaitOne(0))
                {
                    Result = WorkerResult.Canceled;
                    break;
                }
                Thread.Sleep(100);
            }
            if (Result == WorkerResult.Started)
            {
                Result = WorkerResult.Completed;
            }
            WorkCompleteEvent.Set();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start some work.  Press 'c' to cancel.");
            WorkCompleteEvent = new ManualResetEvent(false);
            WorkCancelEvent = new ManualResetEvent(false);

            var thread = new Thread(Worker);
            thread.Start();

            Console.Write("Progress: ");
            while (!WorkCompleteEvent.WaitOne(0))
            {
                if (Console.KeyAvailable)
                {
                    var ch = Console.ReadKey();
                    if (ch.KeyChar == 'c')
                    {
                        WorkCancelEvent.Set();
                    }
                }
                Console.Write("."); Thread.Sleep(500);
            }
            Console.WriteLine();

            switch (Result)
            {
                case WorkerResult.Completed:
                    Console.WriteLine("Work completed.");
                    break;
                case WorkerResult.Canceled:
                    Console.WriteLine("Work canceled.");
                    break;
                default: throw new Exception("Something unexpected happened.");
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Threading;

namespace B.Exceptions
{
    class Program
    {
        enum WorkerResult { Started, Completed, Canceled, Error }

        class WorkerParams
        {
            public WorkerResult ResultStatus { get; set; }
            public Exception Exception { get; set; }
            public int Result { get; set; }
            public ManualResetEvent CompleteEvent { get; }

            public WorkerParams()
            {
                CompleteEvent = new ManualResetEvent(false);
            }
        }

        
        static void Worker(object obj)
        {
            WorkerParams p = (WorkerParams)obj;
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(30);
                }
                int a = 0;
                int b = 5 / a;
                p.ResultStatus = WorkerResult.Completed;
                p.Result = 42;
            }
            catch (Exception x)
            {
                Console.WriteLine("Thread: something went wrong.");
                p.Exception = x;
                p.ResultStatus = WorkerResult.Error;
            }
            p.CompleteEvent.Set();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Work started...");
            var threadParams = new WorkerParams();
            try
            {
                var thread = new Thread(Worker);
                thread.Start(threadParams);
                Console.Write("Wait for the thread to complete:");
                while (!threadParams.CompleteEvent.WaitOne(200)) Console.Write(".");
                Console.WriteLine();
                if (threadParams.ResultStatus == WorkerResult.Error)
                {
                    Console.WriteLine("Here is what happened: " 
                        + threadParams.Exception.Message);
                }
            }
            catch (Exception x) //This *will NOT* catch the exception from within the thread.
            {
                Console.WriteLine("Something went wrong: " + x.Message);
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}

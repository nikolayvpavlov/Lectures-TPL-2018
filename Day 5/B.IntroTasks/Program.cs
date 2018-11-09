using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B.IntroTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task firstTask = new Task(
                () => Console.WriteLine("Hi from my first task!")
                );
            firstTask.Start();

            Console.WriteLine("Doing something else...");

            //Wait for the task to finish;

            //1. Continuously check if the task is running.
            //while (!firstTask.IsCompleted)
            //{
            //    Thread.Sleep(100);
            //}

            //2. By waiting on the task.
            firstTask.Wait(); //Blocks until the task is complete.

            Console.WriteLine();
            Console.WriteLine("Starting a second task.");
            
            //Getting results from a task.
            Task<int> secondTask = new Task<int>(
                () => 42
                );
            secondTask.Start();

            Console.WriteLine("Doing something else...");

            secondTask.Wait();
            Console.WriteLine("And the result is: " + secondTask.Result);
            Console.WriteLine();

            Task<int> faultyTask = new Task<int>(
                () => Int32.Parse("abcdefg")
                );
            faultyTask.Start();

            try
            {
                int val = faultyTask.Result;
            }
            catch (Exception x)
            {
                Console.WriteLine("Some error occured:");
                string msg = x.InnerException.Message;
                Console.WriteLine(msg);
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}

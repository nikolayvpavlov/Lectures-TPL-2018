using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace A.BarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            bar.InitInventory();
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < 50; i++)
            {
                customers.Add(new Customer(i.ToString(), bar));
            }
            //Run them all
            List<Thread> customerThreads = new List<Thread>();
            foreach (var c in customers)
            {
                Thread t = new Thread(c.Go);
                t.Start();
                customerThreads.Add(t);
            }
            foreach (var t in customerThreads)
            {
                t.Join();
            }

            Console.WriteLine();
            Console.WriteLine("Order summary:");
            var orderSummary =
                from o in bar.Orders
                group o by o into gr
                select new { DrinkType = gr.Key, Count = gr.Count() };
            foreach (var dt in orderSummary)
            {
                Console.WriteLine(dt.DrinkType + ": " + dt.Count.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Simulation complete.");
            Console.ReadLine();
        }
    }
}

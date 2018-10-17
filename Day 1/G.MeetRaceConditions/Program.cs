using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G.MeetRaceConditions
{
    class Program
    {
        static int data = 100;

        static void BadMethod(object param)
        {
            for (int i = 0; i < 10; i++)
            {
                data++;
                Thread.Sleep(3);
                data--;
                Console.WriteLine(param.ToString() + ": " + data);
            }
        }

        static void Main(string[] args)
        {
            Thread one, two;
            one = new Thread(BadMethod);
            two = new Thread(BadMethod);
            one.Start("A");
            two.Start("B");
            one.Join();
            two.Join();
            Console.WriteLine("Ready.");
            Console.ReadLine();
        }
    }
}

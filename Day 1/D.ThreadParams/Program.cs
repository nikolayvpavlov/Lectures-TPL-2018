using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D.ThreadParams
{
    class Program
    {
        static void ThreadMethod (object param)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(param.ToString() + " here.");
                Thread.Sleep(1);
            }
        }

        static void Main(string[] args)
        {
            Thread one, two;
            one = new Thread(ThreadMethod);
            two = new Thread(ThreadMethod);

            one.Start("A");
            two.Start("B");

            Console.ReadLine();
        }
    }
}

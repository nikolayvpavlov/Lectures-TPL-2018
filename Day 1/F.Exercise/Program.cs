using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

namespace F.Exercise
{
    class Program
    {
        static int size = 5;
        static int[] values;

        static void Generator(object p)
        {
            int index = (int)p;
            int value;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                value = BitConverter.ToInt32(rno, 0);
            }
            values[index] = value;
            Console.WriteLine(value);
        }

        static void Main(string[] args)
        {
            values = new int[size];
            var threads = new Thread[size];
            for (int i = 0; i < size; i++)
            {
                threads[i] = new Thread(Generator);
                threads[i].Start(i);
            }
            foreach (var t in threads) t.Join();

            int sum = values.Sum();
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}

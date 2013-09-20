using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem_16
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger pow = BigInteger.Pow(2, 1000);
            Console.WriteLine("2^1000 : " + pow);
            int sum=0;
            while (pow > 0)
            {
                sum += (int)(pow % 10);
                pow /= 10;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}

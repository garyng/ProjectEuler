using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Pow(SumOf1toN(100), 2) - SumOf1toNSquare(100));
            Console.ReadKey();
        }

        static double SumOf1toN(double n)
        {
            // formula : ((1+n)/2)*n
            return ((1 + n) / 2) * n;
        }

        static double SumOf1toNSquare(double n)
        {
            // formula : (n(2n+1)(n+1))/6
            return (n * (2 * n + 1) * (n + 1)) / 6;
        }
    }
}

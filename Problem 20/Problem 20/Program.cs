using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
namespace Problem_20
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger fac = Factorial(100);
            Console.WriteLine("100! : " + fac);
            int sum = 0;
            while (fac > 0)
            {
                sum += (int)(fac % 10);
                fac /= 10;
            }
            Console.WriteLine("Sum : " + sum);
            Console.ReadKey();
        }

        static BigInteger Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}

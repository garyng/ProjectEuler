using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem_15
{
    class Program
    {

        // formula, n = grid size
        static void Main(string[] args)
        {
            int n = 20;
            Console.WriteLine(nCr(n*2,n));

            Console.ReadKey();


        }

        static BigInteger nCr(int n, int r)
        {
            if (n >= r)
            {
                BigInteger result = 1;
                for (int i = n; i >= n - r + 1; i--)
                {
                    result *= i;
                }
                for (int i = 1; i <= r; i++)
                {
                    result /= i;
                }
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}

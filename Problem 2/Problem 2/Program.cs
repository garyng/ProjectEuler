using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (CalFib(i) < 4000000)
            {
                i += 1;
            }
            i -= 1;
            Console.WriteLine("Fib number that <4000000 : " + CalFib(i) + " index : " + i);
            double Sum = 0;

            for (int y = 3; y <= i; y += 3)
            {
                Sum += CalFib(y);
            }

            Console.WriteLine("Sum : " + Sum);

            Console.ReadKey();
        }

        static double CalFib(int i)
        {
            if (i <= 2)
            {
                return 1;
            }
            else
            {
                return CalFib(i - 1) + CalFib(i - 2);
            }
        }
    }
}

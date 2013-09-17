﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2
{
    class Program
    {
//        Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

//1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

//By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
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

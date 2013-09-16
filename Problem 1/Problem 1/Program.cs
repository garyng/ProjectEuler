using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1
{
    class Program
    {
        //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        //Find the sum of all the multiples of 3 or 5 below 1000.

        static void Main(string[] args)
        {
            HashSet<int> iMul3 = new HashSet<int>();
            HashSet<int> iMul5 = new HashSet<int>();
            int iStp3 = 1000 / 3;
            int iStp5 = 1000 / 5 - 1;

            for (int i = 1; i <= iStp3; i++)
            {
                iMul3.Add(i * 3);
            }
            for (int i = 1; i <= iStp5; i++)
            {
                iMul5.Add(i * 5);
            }

            long lSum = 0;
            iMul3.Union(iMul5).ToList().ForEach(item=>lSum+=item);
            Console.WriteLine(lSum);

            // Using formula
            Console.WriteLine(CalSum(999,3,5));


            Console.ReadKey();

        }

       static double CalSum (int max,int mul1,int mul2)
        {
            double mul1Floor = Math.Floor((double)(max / mul1));
            double mul2Floor = Math.Floor((double)(max / mul2));
            double comFloor = Math.Floor((double)(max / (mul1*mul2)));
            return ((mul1 + mul1Floor * mul1) / 2) * mul1Floor + ((mul2 + mul2Floor * mul2) / 2) * mul2Floor - (((mul1 * mul2) + comFloor * (mul1 * mul2)) / 2) * comFloor;
        }
    }
}

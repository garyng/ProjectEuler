using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find the largest palindrome made from the product of two 3-digit numbers.

            //lowest = 100*100 = 10000
            //largest = 999*999 = 998001
            Stopwatch sw = Stopwatch.StartNew();
            CheckPalinProduct(MakePalin(900, 999, true));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }

        static List<int> MakePalin(int front, int frontMax,bool isEven)
        {
            List<int> Palin = new List<int>();

            for (int i = front; i <=frontMax; i++)
            {
                Palin.Add(Convert.ToInt32(FlipInt(i, isEven)));
            }
            Console.WriteLine(Palin.Count);
            return Palin;
        }

        static void CheckPalinProduct(List<int> Palin)
        {
            // just check from 99~999 for finding the factors
            // sqrt(998001) = 999
            // and two factors, i and j, if i > sqrt(num), then j will smaller
            Palin.ForEach(delegate(int item)
            {
                for (int i = 99; i <= 999; i++)
                {
                    if ((item / i) > 999 || i*i < item)
                    {
                        continue;
                    }
                    if (item % i == 0)
                    {
                        Console.WriteLine(item + " : " + i + "*" + item/i);
                    }
                }

            });

        }

        static int FlipInt(int front, bool isEven)
        {
            string strFront = front.ToString();
            if (isEven)
            {
                return Convert.ToInt32(strFront + string.Join("", strFront.Reverse().ToList()));
            }
            else
            {
                return Convert.ToInt32(strFront + string.Join("", strFront.Substring(0, strFront.Length - 1).Reverse().ToList()));
            }
        }
    }
}

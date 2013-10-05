using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace Problem_23
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 28123;
            List<int> primes = ESieve(limit);
            List<int> abundant = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (FactorSum(i, primes) > i)
                {
                    abundant.Add(i);
                }
            }
            Console.WriteLine(String.Format("Total abundant number < {0} is {1}", limit, abundant.Count));

            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool[] canWriteAsAbund = new bool[limit + 1];

            for (int i = 0; i < abundant.Count; i++)
            {
                for (int j = i; j < abundant.Count; j++)
                {
                    if (abundant[i] + abundant[j] <= limit)
                    {
                        canWriteAsAbund[abundant[i] + abundant[j]] = true;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            int sum = 0;
            for (int i = 0; i <= limit; i++)
            {
                if (canWriteAsAbund[i] == false)
                {
                    sum += i;
                }
            }

            sw.Stop();
            Console.WriteLine("Sum: {0} Time elapsed: {1}", sum, sw.Elapsed);

            Console.ReadKey();
        }

        public static List<int> ESieve(int max)
        {
            BitArray baSeive = new BitArray(max - 1);
            List<int> primes = new List<int>();
            for (int i = 2; i < baSeive.Count + 2; i++)
            {
                if (baSeive.Get(i - 2) == false)
                {
                    for (int j = i + i; j <= max; j += i)
                    {
                        baSeive.Set(j - 2, true);
                    }
                }
            }
            for (int i = 0; i < baSeive.Count; i++)
            {
                if (baSeive.Get(i) == false)
                {
                    primes.Add(i + 2);
                }
            }
            return primes;
        }

        /// <summary>
        /// find sum of of distinct factors that not include itself
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Primes"></param>
        /// <returns></returns>
        public static int FactorSum(int Number, List<int> Primes)
        {
            List<int> primes = new List<int>(Primes);
            int number = Number;
            int item;
            int facSum = 1;
            if (primes.BinarySearch(number) > -1)
            {
                return 1;
            }
            for (int i = 0; i < primes.Count; i++)
            {
                item = primes[i];
                if (item > Number)
                {
                    break;
                }
                if ((number % item) == 0)
                {
                    bool isDivisible = true;
                    int primeMul = 1;
                    while (isDivisible)
                    {
                        primeMul *= item;
                        number /= item;
                        if (number % item > 0)
                        {
                            isDivisible = false;
                        }
                    }
                    facSum *= (primeMul * item - 1) / (item - 1);
                }
                if (number == 1)
                {
                    break;
                }
            }
            return (facSum - Number);
        }
    }

}

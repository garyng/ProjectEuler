using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_21
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 20000;
            List<int> primes = ESeive(limit);
            Dictionary<int, int> sumAllFacs = new Dictionary<int, int>();

            List<int> amic = new List<int>();

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 1; i < limit / 2; i++)
            {
                int sumOfFac = GetSumOfFactors(Factorize(i, primes)) - i;
                int sumOfFacFac = 0;
                if (sumOfFac > i)
                {
                    sumAllFacs.Add(i, sumOfFac);
                }
                else if (sumOfFac < i)
                {
                    int value = 0;
                    if (sumAllFacs.TryGetValue(sumOfFac, out value))
                    {
                        if (value == i)
                        {
                            amic.Add(i);
                            amic.Add(sumOfFac);
                        }
                    }
                }


                //Console.WriteLine("{0}->{1}->{2}",i,sumOfFac,sumOfFacFac);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            int sum = 0;
            amic.ForEach(item => sum += item);
            Console.WriteLine("Sum {0}", sum);

            Console.ReadKey();
        }

        public static List<int> ESeive(int max)
        {
            List<bool> bSieve = new List<bool>();
            List<int> iNumbers = new List<int>();

            for (int i = 1; i <= max; i++)  //exclude 1
            {
                bSieve.Add(true);  //true = prime
                iNumbers.Add(i);
            }
            bSieve[0] = false;  //[0]=1
            for (int i = 1; i < iNumbers.Count; i++)
            {
                for (int y = iNumbers[i]; y <= iNumbers.Last(); y += iNumbers[i])
                {
                    if (y == iNumbers[i]) continue;
                    bSieve[y - 1] = false;
                }
            }
            List<int> Prime = new List<int>();
            for (int i = 0; i < bSieve.Count; i++)
            {
                if (bSieve[i] == true)
                {
                    Prime.Add(iNumbers[i]);
                }
            }

            return Prime;
        }

        public static Dictionary<int, int> Factorize(int Number, List<int> Primes)
        {
            Dictionary<int, int> factors = new Dictionary<int, int>();
            List<int> primes = new List<int>(Primes);
            int number = Number;
            int item;
            int limit = (int)Math.Ceiling(Math.Sqrt(number));
            if (primes.BinarySearch(number) > -1)
            {
                factors.Add(number, 1);
                return factors;
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
                    int facValue;
                    while (isDivisible)
                    {
                        if (factors.TryGetValue(item, out facValue))
                        {
                            factors[item] = facValue + 1;
                        }
                        else
                        {
                            factors.Add(item, 1);
                        }

                        number /= item;
                        if (number % item > 0)
                        {
                            isDivisible = false;
                        }
                    }
                }
                if (number == 1)
                {
                    break;
                }
            }

            return factors;
        }

        /// <summary>
        /// Get sum of factors without itself
        /// </summary>
        /// <param name="Factors"></param>
        /// <returns></returns>
        public static int GetSumOfFactors(Dictionary<int, int> Factors)
        {
            var facEnum = Factors.GetEnumerator();
            KeyValuePair<int, int> facPair = new KeyValuePair<int, int>();
            int facCount = 1;
            while (facEnum.MoveNext())
            {
                facPair = facEnum.Current;
                facCount *= (int)((Math.Pow(facPair.Key, facPair.Value + 1) - 1) / (facPair.Key - 1));
            }
            return facCount;
        }
    }
}

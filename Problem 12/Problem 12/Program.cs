using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int largest = 0;
            int sum = 1;
            int count = 1;
            List<int> primes = GenPrime(100000);
            Stopwatch sw = Stopwatch.StartNew();
            int facCount = 0;
            while (largest < 500)
            {
                facCount = GetFactorsCount(sum, primes);
                if (facCount > largest)
                {
                    largest = facCount;
                }
                count++;
                sum += count;
            }
            sum -= count;
            count--;
            sw.Stop();
            Console.WriteLine("Number : " + sum + " with " + largest + " factors, triangular number # " + count);
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }

        /// <summary>
        /// (a+1)(b+1)...
        /// </summary>
        /// <param name="Number">A number</param>
        /// <param name="Primes">A list of prime</param>
        /// <returns>Factors count</returns>
        public static int GetFactorsCount(int Number, List<int> Primes)
        {
            Dictionary<int, int> primeFactors = Factorize(Number, Primes);
            var facEnum = primeFactors.GetEnumerator();
            KeyValuePair<int, int> facPair = new KeyValuePair<int, int>();
            int facCount = 1;
            while (facEnum.MoveNext())
            {
                facPair = facEnum.Current;
                facCount *= facPair.Value + 1;
            }
            return facCount;
        }

        public static List<int> GenPrime(int max)
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

        /// <summary>
        /// Factorize a number with a given prime list
        /// </summary>
        /// <param name="num">Number to factorize</param>
        /// <param name="primes">List of primes</param>
        /// <returns>A dictionary with the prime factor and its index</returns>
        public static Dictionary<int, int> Factorize(int Number, List<int> Primes)
        {
            Dictionary<int, int> factors = new Dictionary<int, int>();
            List<int> primes = new List<int>(Primes);
            int number = Number;
            int item;
            // can optimize to : Loop until sqrt(Number)
            for (int i = 0; i < primes.Count; i++)
            {
                item = primes[i];
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
    }
}

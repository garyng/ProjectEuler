using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Collections;

namespace MathHelper
{
    public class Prime
    {
        public static List<int> Read(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            List<int> iPrimes = new List<int>();
            List<string> strPrimes = Regex.Split(sr.ReadToEnd(), Environment.NewLine).ToList();
            //remove the last blank line
            if (strPrimes.Last() == "")
            {
                strPrimes.RemoveAt(strPrimes.Count - 1);
            }
            strPrimes.ForEach(item => iPrimes.Add(Convert.ToInt32(item)));
            return iPrimes;
        }

        public static void Write(List<int> Prime, string FileName)
        {
            StreamWriter sw = new StreamWriter(FileName);
            Prime.ForEach(delegate(int item)
            {
                sw.WriteLine(item);
            });
            sw.Close();
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
    }

    public class Factor
    {
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

        public static int GCD(int Num1, int Num2)
        {
            if (Num1 == 0)
            {
                return Num2;
            }
            int n1 = Num1;
            int n2 = Num2;
            while (n2 > 0)
            {
                if (n1 > n2)
                {
                    n1 -= n2;
                }
                else
                {
                    n2 -= n1;
                }
            }
            return n1;
        }

        //LCM(a,b)= a*(b/GCD(a,b))
        public static int LCM(int Num1, int Num2)
        {
            //will throw error?
            return Num1 * (Num2 / GCD(Num1, Num2));
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

        /// <summary>
        /// Get sum of all factors including itself
        /// </summary>
        /// <param name="Factors"></param>
        /// <returns></returns>
        public static BigInteger GetSumOfFactors(Dictionary<int, int> Factors)
        {
            var facEnum = Factors.GetEnumerator();
            KeyValuePair<int, int> facPair = new KeyValuePair<int, int>();
            BigInteger facCount = 1;
            while (facEnum.MoveNext())
            {
                facPair = facEnum.Current;
                facCount *= (BigInteger.Pow(facPair.Key, facPair.Value + 1) - 1) / (facPair.Key - 1);
            }
            return facCount;
        }
    }

    public class Factorial
    {
        public static BigInteger Calc(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }

    public class Combination
    {
        public static BigInteger Calc(int n, int r)
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

    public class Permutation
    {
        public static BigInteger Calc(int n, int r)
        {
            if (n >= r)
            {
                BigInteger result = 1;
                for (int i = n; i >= n - r + 1; i--)
                {
                    result *= i;
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

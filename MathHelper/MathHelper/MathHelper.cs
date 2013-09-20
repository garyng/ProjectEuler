using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

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


        public static List<int> Generate(int max)
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



    }

    public class Factor
    {
        /// <summary>
        /// Factorize a number with a given prime list
        /// </summary>
        /// <param name="num">Number to factorize</param>
        /// <param name="primes">List of primes</param>
        /// <returns>A dictionary with the prime factor and its index</returns>
        public static Dictionary<int,int> Factorize(int Number, List<int> Primes)
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
    }


}

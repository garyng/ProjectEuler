using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_3
{
    class Program
    {
        //What is the largest prime factor of the number 600851475143 ?
        static void Main(string[] args)
        {
            List<int> Prime = ReadPrimeFromFile("Primes.txt");

            TrialDiv(Prime, 600851475143);
            Console.WriteLine("Done.");
            Console.ReadKey();

        }

        static void TrialDiv(List<int> primes, double num)
        {
            // No optimization..
            for (int i = 0; i < primes.Count; i++)
            {
                if (num % primes[i] == 0)
                {
                    Console.WriteLine(primes[i]); 
                }
            }
        }

        static List<int> ReadPrimeFromFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            List<int> iPrimes = new List<int>();
            List<string> strPrimes = Regex.Split(sr.ReadToEnd(), Environment.NewLine).ToList();
            //remove the last blank line
            strPrimes.RemoveAt(strPrimes.Count - 1);
            strPrimes.ForEach(item => iPrimes.Add(Convert.ToInt32(item)));
            return iPrimes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Sieve_Of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<int> Prime =  Sieve(1000000);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            OutputToFile(Prime, "Primes.txt");
            Console.WriteLine("Wrote to file..");
            Console.ReadKey();
            // new line at the end of the file...
            Prime.ForEach(item => Console.WriteLine(item));
            Console.ReadKey();
        }

        static void OutputToFile(List<int> Prime, string FileName)
        {
            StreamWriter sw = new StreamWriter(FileName);
            Prime.ForEach(delegate(int item)
            {
                sw.WriteLine(item);
            });
            sw.Close();
        }

        static List<int> Sieve(int max)
        {
            List<bool> bSieve = new List<bool>();
            List<int> iNumbers = new List<int>();

            for (int i =1; i <= max; i++)  //exclude 1
            {
                bSieve.Add(true);  //true = prime
                iNumbers.Add(i);
            }
            bSieve[0] = false;  //[0]=1
            for (int i = 1; i < iNumbers.Count; i++)
            {
                for (int y = iNumbers[i]; y <= iNumbers.Last(); y+=iNumbers[i])
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
}

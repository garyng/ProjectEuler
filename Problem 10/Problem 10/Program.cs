using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_10
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum =0;
            GenPrime(2000000).ForEach(item => sum += item);
            Console.WriteLine(sum);

            Console.ReadKey();


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
    }
}

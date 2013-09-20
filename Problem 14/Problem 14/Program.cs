using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_14
{
    class Program
    {
        // 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1 ; 10 terms (include 13)
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int max = 1000000;

            long current = 0;
            long count = 0;
            long largest = 0;
            long largestNum = 0;

            long keyValue;
            Dictionary<long, long> cache = new Dictionary<long, long>();
            
            for (int i = 2; i < max; i++)
            {
                current = i;
                count = 1;
                while (current > 1)
                {
                    current = CalCollatz(current);
                    count++;
                    if (current < i)
                    {
                        if (cache.TryGetValue(current, out keyValue))
                        {
                            count += keyValue - 1;
                            break;
                        }

                    }
                }
                cache.Add(i, count);

                if (count > largest)
                {
                    largestNum = i;
                    largest = count;
                }
            }
            sw.Stop();
            Console.WriteLine(largestNum + " steps : " + largest);
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
            string seq = "";
            while (largestNum > 1)
            {
                largestNum = CalCollatz(largestNum);
                seq += " → " +largestNum;
            }
            Console.WriteLine(seq);

            Console.ReadKey();
        }

        static long CalCollatz(long n)
        {
            if (n % 2 == 0)
            {
                return n / 2;
            }
            else
            {
                return 3 * n + 1;
            }
        }

        
    }
}

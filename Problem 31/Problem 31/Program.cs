using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_31
{
    class Program
    {
        static void Main(string[] args)
        {
            int coinToChg = 200;
            int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] ways = new int[coinToChg + 1];
            ways[0] = 1;
            for (int i = 0; i < coins.Count(); i++)
            {
                for (int j = coins[i]; j <= coinToChg; j++)
                {
                    ways[j] += ways[j - coins[i]];
                }
            }
            Console.WriteLine(ways.Last());
            Console.ReadKey();
        }
    }
}

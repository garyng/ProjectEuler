using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_27
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> primes = ESieve(10000);
			int limit = 1000;
			int nMax = 0;
			int bMax = 0;
			int aMax = 0;
			for (int a = -limit; a <= limit; a++)
			{
				for (int b = -limit; b <= limit; b++)
				{
					int n = 0;
					while (primes.BinarySearch(Math.Abs(n * n + a * n + b)) > -1)
					{
						n++;
					}
					if (n > nMax)
					{
						nMax = n;
						bMax = b;
						aMax = a;
					}
				}
			}
			Console.WriteLine("a " + aMax + " b " +bMax + " n " + nMax + " product " + aMax*bMax );
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
	}
}

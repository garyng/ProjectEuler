using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_32
{
	class Program
	{
		static void Main(string[] args)
		{
			SortedSet<long> panPro = new SortedSet<long>();
			long product = 0L;
			long joined= 0L;
			for (int m = 2; m < 100; m++)
			{
				int end = 10000 / m + 1;
				for (int n = 1; n <= end; n++)
				{
					product = m * n;
					joined = join(join(m, n), product);
					if (joined >= 100000000)
					{
						if (isPan(joined))
						{
							panPro.Add(product);
							Console.WriteLine("m " + m + " n " + n + " pro " + product + " joined " + joined);
						}
					}
				}
			}
			SortedSet<long>.Enumerator pro = panPro.GetEnumerator();
			long sum = 0L;
			while (pro.MoveNext())
			{
				sum += pro.Current;
			}
			Console.WriteLine(sum);
			
			Console.ReadKey();
		}

		private static long join(long a, long b)
		{
			long c = b;
			while (c > 0)
			{
				a *= 10;
				c /= 10;
			}
			return a + b;
		}

		private static bool isPan(long num)
		{
			int digits = 0;
			int count = 0;
			int tmpDigits;

			while (num > 0)
			{
				tmpDigits = digits;
				digits = digits | 1 << (int)((num % 10) - 1);
				if (tmpDigits == digits)
				{
					return false;
				}
				count++;
				num /= 10;
			}
			return digits == (1 << count) - 1;
		}
	}
}

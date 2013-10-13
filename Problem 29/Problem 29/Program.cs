using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_29
{
	class Program
	{
		static void Main(string[] args)
		{
			SortedSet<double> pow = new SortedSet<double>();
			
			int limit = 100;
			for (int a = 2; a <= limit; a++)
			{
				for (int b = 2; b <= limit; b++)
				{
					pow.Add(Math.Pow(a, b));
				}
			}

			Console.WriteLine(pow.Count);
			Console.ReadKey();
		}
	}
}

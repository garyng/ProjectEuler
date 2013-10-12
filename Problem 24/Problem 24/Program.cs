using System;
using System.Collections.Generic;

namespace Problem_24
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> factorial = cacheFactorial(9);

			List<int> number = new List<int>() { 0,1,2,3,4,5,6,7,8,9 };
			List<int> result = new List<int>();

			int nth = 1000000;
			
			//skip the last one
			for (int i = factorial.Count - 1; i >= 0; i--)
			{
				for (int j = 0; j < number.Count; j++)
				{
					//Console.WriteLine(  (i+1) + " " + factorial[i] + " " + j + " " + factorial[i]*(j+1));
					if ((factorial[i] * j +1) <= nth && factorial[i] * (j + 1) >= nth)
					{
						//Console.WriteLine(factorial[i] * j + 1 + "~" + factorial[i] * (j + 1));
						//Console.WriteLine(factorial[i]*(j+1));
						//Console.WriteLine(nth);
						result.Add(number[j]);
						number.RemoveAt(j);
						nth -= factorial[i] * j;

						break;
					}
				}
			}

			Console.WriteLine(string.Join("",result) + number[0]);
			Console.ReadKey();

		}

		public static List<int> cacheFactorial(int n)
		{
			List<int> factorial = new List<int>();
			int fac = 1;
			for (int i = 1; i <= n; i++)
			{
				fac *= i;
				factorial.Add(fac);
			}
			return factorial;
		}

		
	}
}

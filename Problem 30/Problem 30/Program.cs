using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_30
{
	class Program
	{
		static void Main(string[] args)
		{
			int limit = 360000;
			int result = 0;
			for (int i = 2; i < limit; i++)
			{
				int curNum = i;
				int sum = 0;
				while (curNum > 0)
				{
					int digits = curNum % 10;
					curNum /= 10;

					int tmpDigits = digits;
					for (int j = 1; j < 5; j++)
					{
						tmpDigits *= digits;
					}
					sum += tmpDigits;
				}
				if (sum == i)
				{
					result += i;
					Console.WriteLine(i);
				}
			}
			Console.WriteLine("Sum " + result);
			Console.ReadKey();
		}
	}
}

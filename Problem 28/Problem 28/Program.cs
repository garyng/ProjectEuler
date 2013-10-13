using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_28
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine(calDiagSum((1001-1)/2));
			Console.ReadKey();
		}

		private static int calDiagSum(int n)
		{
			if (n == 0)
			{
				return 1;
			}
			else
			{
				return (int)Math.Pow((2*n+1),2)*4 - 12 * n + calDiagSum(n - 1);
			}
		}
	}
}

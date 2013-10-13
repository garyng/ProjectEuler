using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_25
{
	class Program
	{
		public static void Main(string[] args)
		{
			BigInteger limit = BigInteger.Pow(10, 999);
			BigInteger fibNum = BigInteger.Zero;
			BigInteger prevFibNum = 1;
			BigInteger prevFibNum1 = 1;
			int count = 2;
			while (fibNum < limit)
			{
				fibNum = prevFibNum + prevFibNum1;
				count++;
				prevFibNum1 = prevFibNum;
				prevFibNum = fibNum;
			}
			Console.WriteLine("fib#" + count + " : \n" + fibNum);

			Console.ReadKey();
		}
	}
}

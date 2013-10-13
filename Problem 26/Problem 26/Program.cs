using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_26
{
	class Program
	{
		static void Main(string[] args)
		{
			int longest = 0;
			int num = 0;
			for (int i = 1; i <= 1000; i++)
			{
				int current = calLength(i);
				if (current > longest)
				{
					longest = current;
					num = i;
				}
				
			}
			Console.WriteLine("Number " + num + " recurring cycle " + longest);
			Console.ReadKey();
		}

		private static int calLength(int Num)
		{
			int lastR = 10;
			//bool[] bR = new bool[10];
			int[] remainer = new int[Num];
			int position = 1;
			for (int i = 0; i <= Num; i++)
			{
				lastR = lastR % Num;
				if (lastR == 0)
				{
					return position;
				}
				if (remainer[lastR] > 0)
				{
					return position - remainer[lastR];
				}
				else
				{
					remainer[lastR] = position;
				}
				lastR *= 10;
				position++;
			}
			return -1;

		}
	}
}

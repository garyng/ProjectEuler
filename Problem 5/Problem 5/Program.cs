using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 20; i++)
            {
                numbers.Add(i);
            }

            int product = 1;
            for (int i = 1; i < numbers.Count; i++)
            {
                product = LCM(product, numbers[i]);
                
            }
            Console.WriteLine(product);
            Console.ReadKey();

        }
        public static int LCM(int Num1, int Num2)
        {
            //will throw error?
            return Num1 * (Num2 / GCD(Num1, Num2));
        }
        public static int GCD(int Num1, int Num2)
        {
            if (Num1 == 0)
            {
                return Num2;
            }
            int n1 = Num1;
            int n2 = Num2;
            while (n2 > 0)
            {
                if (n1 > n2)
                {
                    n1 -= n2;
                }
                else
                {
                    n2 -= n1;
                }
            }
            return n1;
        }
    }
}

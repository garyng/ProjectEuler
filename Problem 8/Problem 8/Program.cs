using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = ReadFromFile("number.txt");
            int largest = 0;
            int product = 0;
            string digits;
            for (int i = 0; i < number.Length-4; i++)
            {
                digits = number.Substring(i, 5);
                product = Multiply(digits);
                if (product > largest)
                {
                    largest = product;
                }
            }
            Console.WriteLine(largest);
            Console.ReadKey();
        }

        static string ReadFromFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            return sr.ReadToEnd();
        }

        static int Multiply(string num)
        {
            int number = int.Parse(num);
            int product = 1;
            while (number > 0)
            {
                product *= number % 10;
                number /= 10;
            }
            return product;
        }
    }
}

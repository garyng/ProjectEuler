using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = ReadFromFile("numbers.txt");
            BigInteger sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum+=BigInteger.Parse(numbers[i]);
            }
            Console.WriteLine(sum.ToString().Substring(0,10));
            Console.ReadKey();
        }

        static List<string> ReadFromFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            string num = sr.ReadToEnd();
            return Regex.Split(num, Environment.NewLine).ToList();
        }
    }
}

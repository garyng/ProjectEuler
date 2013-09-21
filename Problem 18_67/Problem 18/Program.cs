using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> num18 = ReadFromFile("18.txt");
            List<List<int>> num67 = ReadFromFile("67.txt");

            Console.WriteLine("Max (Problem#18) : {0} \nMax (Problem#67) : {1} ", CalMax(num18), CalMax(num67));
            Console.ReadKey();
        }

        static int CalMax(List<List<int>> numbers)
        {
            long sum1 = 0;
            long sum2 = 0;
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < numbers[i].Count - 1; j++)
                {
                    sum1 = numbers[i][j] + numbers[i - 1][j];
                    sum2 = numbers[i][j + 1] + numbers[i - 1][j];
                    numbers[i - 1][j] = (int)Math.Max(sum1, sum2);
                }
            }
            return numbers[0][0];
        }

        static List<List<int>> ReadFromFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            List<string> numberString = Regex.Split(sr.ReadToEnd(), Environment.NewLine).ToList();
            List<List<int>> numbers = new List<List<int>>();
            numberString.ForEach(delegate(string item)
            {
                numbers.Add(Regex.Split(item, " ").ToList().Select(i => int.Parse(i)).ToList());
            });

            return numbers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_22
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> names = ReadFromFile("names.txt");
            names.Sort();
            long sum = 0;
            long totalProduct = 0;
            for (int i = 0; i < names.Count; i++)
            {
                sum = 0;
                names[i].ToList().ForEach(delegate(char item)
                {
                    sum += Convert.ToInt32(item) - 64;
                });
                sum *= (i + 1);
                totalProduct += sum;
            }
            Console.WriteLine("Total : {0}",totalProduct);
            Console.ReadKey();
        }

        static List<string> ReadFromFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            return Regex.Split(sr.ReadToEnd(), ",").ToList().Select(item => item.Replace("\"", "")).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Problem_11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> num = ReadFromFile("numbers.txt");

            long product = 0;
            long largest = 0;
            int largeCol = 0;
            int largeRow = 0;

            int direction = 0;
            //0 = >>>>

            //1 =   v
            //      v
            //      v
            //      v

            //2 = \
            //     \
            //      \
            //      _\/

            //3 =     /
            //       /
            //      /
            //    \/_

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < num.Count; i++)
            {
                for (int j = 0; j < num[i].Count; j++)
                {
                    //start from 0
                    if (j % 4 == 0)
                    {
                        //>>>>
                        product = num[i][j] * num[i][j + 1] * num[i][j + 2] * num[i][j + 3];
                        //if (product > largest)
                        //{
                        //    largest = product;
                        //    largeRow = i;
                        //    largeCol = j;
                        //}

                        SetLarge(product, 0, i, j, ref largest, ref largeRow, ref largeCol, ref direction);
                    }
                    if (i % 4 == 0)
                    {
                        //v
                        //v
                        //v
                        //v
                        product = num[i][j] * num[i + 1][j] * num[i + 2][j] * num[i + 3][j];
                        SetLarge(product, 1, i, j, ref largest, ref largeRow, ref largeCol, ref direction);
                        if (j + 3 < num[i].Count)
                        {
                            //\
                            // \
                            //  \
                            //  _\/
                            product = num[i][j] * num[i + 1][j + 1] * num[i + 2][j + 2] * num[i + 3][j + 3];
                            SetLarge(product, 2, i, j, ref largest, ref largeRow, ref largeCol, ref direction);
                        }
                       
                    }
                    if (j >= 3)
                    {
                        //    /
                        //   /
                        //  /
                        //\/_
                        if (i + 3 < num.Count)
                        {
                            product = num[i][j] * num[i + 1][j - 1] * num[i + 2][j - 2] * num[i + 3][j - 3];
                            SetLarge(product, 3, i, j, ref largest, ref largeRow, ref largeCol, ref direction);
                        }

                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Largest : {0}  Row,Col : {1},{2}  Time : {3}  Dir : {4}", largest, largeRow, largeCol, sw.Elapsed, direction);
            Console.ReadKey();
        }

        static void SetLarge(long Product, int dir, int i, int j, ref long largest, ref int largeRow, ref int largeCol, ref int direction)
        {
            if (Product > largest)
            {
                largest = Product;
                largeRow = i;
                largeCol = j;
                direction = dir;
            }
        }

        /// <summary>
        /// [row][column]
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        static List<List<int>> ReadFromFile(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            List<string> numbersString = Regex.Split(sr.ReadToEnd(), Environment.NewLine).ToList();
            List<List<int>> splitNum = new List<List<int>>();
            numbersString.ForEach(delegate(string item)
            {
                splitNum.Add(Regex.Split(item, " ").ToList().Select(subitem => int.Parse(subitem)).ToList());
            });
            return splitNum;
        }
    }
}

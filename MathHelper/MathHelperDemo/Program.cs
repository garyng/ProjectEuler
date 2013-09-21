using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using MathHelper;
using System.Diagnostics;

namespace MathHelperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine(MathHelper.Permutation.Calc(4, 4));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }
    }
}

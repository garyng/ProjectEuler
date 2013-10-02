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
            Console.WriteLine("{0}", MathHelper.Factor.GetFactorsCount(1000, MathHelper.Prime.ESeive(1000)));
            var a = MathHelper.Factor.Factorize(1000, MathHelper.Prime.ESeive(1000));
            Console.WriteLine(MathHelper.Factor.GetSumOfFactors(MathHelper.Factor.Factorize(1000, MathHelper.Prime.ESeive(1000))));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }

    }


}


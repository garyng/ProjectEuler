using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 1000;
            int a = 0;
            int b = 0;
            int c = 0;
            bool found = false;

            for (a = 1; a < s; a++)
            {
                for (b = a; b < s; b++)
                {
                    c = s - a - b;
                    if (a * a + b * b == c * c)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }

            Console.WriteLine(a + " " + b + " " + c + " " + a*b*c);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathAPI
{
    public class MathHelper
    {
        public static int Add(int a, int b)
        {
            Console.WriteLine($"Now adding {a} and {b}");
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            Console.WriteLine($"Now multiplying {a} and {b}");
            return a * b;
        }
    }
}

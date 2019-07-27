using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMath
{
    public class Math_Factorial
    {
        public static void Print(int math)
        {
            Console.WriteLine($"{math}!={ReturnFactorial(math)}");
        }
        static int ReturnFactorial(int math=10)
        {
            int result = 1, i;
            for (i = 2; i <= math; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}

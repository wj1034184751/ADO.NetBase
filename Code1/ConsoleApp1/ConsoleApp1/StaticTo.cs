using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StaticTo
    {
    }

    public class TypeWithField<T>
    {
        public static string field { get; set; }

        public static void PrintField()
        {
            Console.WriteLine($"{field}:{typeof(T).Name}");
        }
    }

    public class TypeWithFieldClass<T>
    {
        public string field { get; set; }

        public void PrintField()
        {
            Console.WriteLine($"{field}:{typeof(T).Name}");
        }
    }
}

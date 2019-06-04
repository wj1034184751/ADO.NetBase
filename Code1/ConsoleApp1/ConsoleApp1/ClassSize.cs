using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ClassSize
    {
        public static void Print()
        {
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                typeof(byte).Name, sizeof(byte), byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(sbyte).Name, sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(short).Name, sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(ushort).Name, sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(int).Name, sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(uint).Name, sizeof(uint), uint.MinValue, uint.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                     "long-" + typeof(long).Name, sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                     "ulong-" + typeof(ulong).Name, sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(float).Name, sizeof(float), float.MinValue, float.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(double).Name, sizeof(double), double.MinValue, double.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(decimal).Name, sizeof(decimal), decimal.MinValue, decimal.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t\n",
                      typeof(bool).Name, sizeof(bool));
            Console.WriteLine("{0}:\t 所占字节数: {1}\t 最小值:{2}\t 最大值:{3}\n",
                      typeof(char).Name, sizeof(char), char.MinValue, char.MaxValue);
            Console.WriteLine("{0}:\t 所占字节数: {1}\t ",
                      typeof(IntPtr).Name, IntPtr.Size);
        }
    }

    public class ClassSizeInfo 
    {
        public static void PrintSize<T1>(T1 t1)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("测试!");

            List<Product> list = Product.GetSampleProducts();
            ////自己新建类比较
            //list.Sort(new ProductNameComparer());
            //委托比较一
           // list.Sort(delegate (Product x, Product y)
           //{
           //    return x.Name.CompareTo(y.Name);
           //});

            ////委托比较二
            list.Sort((x, y) =>
                x.Name.CompareTo(y.Name));

            foreach (var item in list.OrderBy(d => d.Name))
            {
                Console.WriteLine(item);
            }
        }
    }
}

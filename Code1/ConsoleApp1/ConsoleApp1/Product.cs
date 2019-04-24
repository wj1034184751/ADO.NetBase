using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product(string name,decimal price)
        {
            Name = name;
            Price = price;
        }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
               new Product(name:"wj",price:99m),
               new Product(name:"wc",price:59m),
               new Product(name:"wy",price:39m)
            };
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Name, Price);
        }
    }

    public class ProductNameComparer :IComparer<Product>
    {
        public int Compare(Product x , Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}

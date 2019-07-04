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
            //int x = 1;
            //int y = (x++) + (x++);
            //int z = (++x) + (++x);
            //Console.WriteLine("x:{0},y:{1},z:{2}", x, y, z);

            //Console.WriteLine("测试!");

            //List<Product> list = Product.GetSampleProducts();
            ////自己新建类比较
            //list.Sort(new ProductNameComparer());
            //委托比较一
            // list.Sort(delegate (Product x, Product y)
            //{
            //    return x.Name.CompareTo(y.Name);
            //});

            ////委托比较二
            //list.Sort((x, y) =>
            //    x.Name.CompareTo(y.Name));

            //foreach (var item in list.OrderBy(d => d.Name))
            //{
            //    Console.WriteLine(item);
            //}

            ////委托三
            //List<Product> matches = list.FindAll(d => d.Price > 1);
            //Action<Product> print = Console.WriteLine;
            //matches.ForEach(print);

            ////委托四
            //DelegateTest.Run();

            ////强类型
            //object o = "hello world";
            //////Console.WriteLine(o.length);
            //Console.WriteLine(((string)o).Length);

            //////委托五
            //Func<int, int, string> tfunc = (x, y) => (x * y).ToString();
            //Console.WriteLine(tfunc(5, 20));

            //////HashTable

            //string text = @"Do you like grren eggs and ham? I do not like them ,Sam-I-am.";
            //Dictionary<string, int> frequencies = HashTable.CountWords(text);

            //foreach (KeyValuePair<string, int> item in frequencies)
            //{
            //    string word = item.Key;
            //    int frequency = item.Value;
            //    Console.WriteLine("{0}:{1}", word, frequency);
            //}
            //TypeWithField<int>.field = "First";
            //TypeWithField<string>.field = "Second";
            //TypeWithField<double>.field = "Third";

            //TypeWithField<int>.PrintField();
            //TypeWithField< string>.PrintField();
            //TypeWithField<double>.PrintField();
            //ThreadRun.ThreadT1();
            //ThreadRun.ThreadT2();
            //ThreadRun.ThreadT3();

            //using (DisposableTest test = new DisposableTest())
            //{
            //    test.DoSomething();
            //}
            //StepDemo demo = new StepDemo();
            //ReadFile rf = new ReadFile();
            //demo.AddOnWork(rf.BeginReadFile, rf.EndReadFile);
            //demo.DoAsyncWork(null);
            //Console.ReadLine();

            //InitEvent evv = new InitEvent();
            //MyString ms = new MyString("hahs");
            //ms.str = "ffff";
            //ms.str = "ffffff1";

            //ThreadRun.ThreadT6();

            //ClassSize.Print();

            //DelegateSample.Print();
            //LambdaTest.Print();

            //ExpressionTest.Print2();

            //DeleteClass.Print();

            LinqTest.Print();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _32NetSet
{
    public class NetSet_ReflectTest
    {
        public static void Print()
        {
            Console.WriteLine("列出程序集中所有类型!");
            Assembly a = Assembly.LoadFrom("32NetSet.dll");
            Type[] myTypes = a.GetTypes();
            foreach(Type  t in myTypes)
            {
                Console.WriteLine(t.Name);
            }

            Console.WriteLine("列出 Hello World 中所有方法!");
            Type ht = typeof(HelloWorld);
            MethodInfo[] mifs = ht.GetMethods();
            foreach(MethodInfo info in mifs)
            {
                Console.WriteLine(info.Name);
            }
        }
    }

    public class HelloWorld
    {
        string myName = null;
        public HelloWorld(string name)
        {
            this.myName = name;
        }

        public HelloWorld():this(null)
        {

        }

        public string Name
        {
            get { return myName; }
        }

        public void SayHello()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Console.WriteLine("Hello World");
            else
                Console.WriteLine("Hello," + myName);
        }

    }
}

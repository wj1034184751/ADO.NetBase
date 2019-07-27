using System;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSet_Singleton
    {
        private static object lockObject = new object();
        private static NetSet_Singleton instance = null;
        private NetSet_Singleton() { }

        public static NetSet_Singleton Instance
        {
            get
            {
                if (instance == null)
                    lock (lockObject)
                        if (instance == null)
                            instance = new NetSet_Singleton();

                return instance;
            }
        }

        public void Print()
        {
            Console.WriteLine($"This Guid:{Guid.NewGuid().ToString()}");
        }
    }

    public class NetSet_Class
    {
        public NetSet_Class()
        {
            Console.WriteLine("NEW Instance Created");
        }

        static NetSet_Class()
        {
            Console.WriteLine("This is Static Constructor");
        }

        public static void Hello()
        {
            Console.WriteLine("Hello");
        }

        public static void Printf()
        {
            NetSet_Class.Hello();
            NetSet_Class ms = new NetSet_Class();

        }
    }

    public class MyNewClass
    {
        protected MyNewClass() { }
    }

    public class MyFactory
    {
        public MyFactory() { }

        public MyNewClass CreateNewClass()
        {
            return new mySubClass();
        }

        private class mySubClass : MyNewClass
        {
            public mySubClass() : base()
            {

            }
        }
    }
}

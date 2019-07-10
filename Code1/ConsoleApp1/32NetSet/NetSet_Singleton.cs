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
}

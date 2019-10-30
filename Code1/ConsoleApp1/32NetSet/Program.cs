using System;
using System.Collections;
using System.Numerics;

namespace _32NetSet
{
    class t1
    {
        //公司
        public int a { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //var singClass = NetSet_Singleton.Instance;
            //NetSet_AbstractFactory.Print();

            //NetSetAllOne.Print();

            //NetSet_ReflectTest.Print();

            //NetSet_Builder.Printf();

            //NodeListTest.Printf();

            //NetSet_Class.Printf();

            //NetSet_FactoryMehod.Printf();

            //NetSet_Prototype.Printf();

            //NetSet_Bridge.Printf();

            //NetSet_Decorator.Printf();
            //var result = Math.Log(1000000, 10);
            //Console.WriteLine(result);
            //Console.ReadLine();


            //NetSet_Observer.Printf();

            var result = Cocoon.getButterfly(1);
            MathHelper.Complex c1 = new MathHelper.Complex(2, 3);
            MathHelper.Complex c2 = new MathHelper.Complex(6, 8);
            result.Execute(c1, c2);
        }
    }
}

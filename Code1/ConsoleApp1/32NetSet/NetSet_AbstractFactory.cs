using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _32NetSet
{
    public class NetSet_AbstractFactory
    {
        public static void Print()
        {
            AbstractFactory fac1 = new ConcreateFactory1();
            Client c1 = new Client(fac1);
            c1.Run();

            AbstractFactory fac2 = new ConcreateFactory2();
            Client c2 = new Client(fac2);
            c2.Run();
        }
    }

    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    abstract class AbstractProductA
    {
        public abstract void Interact(AbstractProductB b);
    }

    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    class Client
    {
        private AbstractProductA AbstractProductA;
        private AbstractProductB AbstractProductB;

        public Client(AbstractFactory factory)
        {
            AbstractProductA = factory.CreateProductA();
            AbstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            AbstractProductA.Interact(AbstractProductB);
            AbstractProductB.Interact(AbstractProductA);
        }
    }

    class ConcreateFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    class ConcreateFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    class ProductA1 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + "intercat with " + b.GetType().Name);
        }
    }

    class ProductA2 : AbstractProductA
    {
        public override void Interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + "intercat with " + b.GetType().Name);
        }
    }

    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + "intercat with " + a.GetType().Name);
        }
    }

    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + "intercat with " + a.GetType().Name);
        }
    }

}

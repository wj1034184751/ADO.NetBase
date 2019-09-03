using System;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSet_Decorator
    {
        public static void Printf()
        {
            Tank tank = new T50();
            DecoratorA da = new DecoratorA(tank);
            DecoratorB db = new DecoratorB(da);
            db.Shot();
            db.Run();
        }
    }

    public abstract class Tank
    {
        public abstract void Shot();
        public abstract void Run();
    }

    public class T50:Tank
    {
        public override void Shot()
        {
            Console.WriteLine("T50坦克平均每秒5发子弹!");
        }

        public override void Run()
        {
            Console.WriteLine("T50坦克平均每时运行30仅是!");
        }
    }

    public class T70 : Tank
    {
        public override void Shot()
        {
            Console.WriteLine("T70坦克平均每秒10发子弹!");
        }

        public override void Run()
        {
            Console.WriteLine("T70坦克平均每时运行35仅是!");
        }
    }

    public abstract class Decorator : Tank
    {
        private Tank tank;

        public Decorator(Tank tank)
        {
            this.tank = tank;
        }

        public override void Shot()
        {
            Console.WriteLine("T70坦克平均每时运行35仅是!");
            Console.WriteLine("imya");
        }
      

        public override void Run()
        {
            Console.WriteLine("T70坦克平均每时运行35仅是!");
        }
       
    }

    public class DecoratorA : Decorator
    {
        public DecoratorA(Tank tank) : base(tank)
        {
        }

        public override void Shot()
        {
            Console.WriteLine("功能扩展 卫星功能!");
            base.Shot();
        }

        public override void Run()
        {
            base.Run();
        }
    }

    public class DecoratorB : Decorator
    {
        public DecoratorB(Tank tank) : base(tank)
        {
        }

        public override void Shot()
        {
            Console.WriteLine("功能扩展 水陆两栖功能!");
            base.Shot();
        }

        public override void Run()
        {
            base.Run();
        }
    }
}

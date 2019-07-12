using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSetAllOne
    {
        public static void Print()
        {
            Person p1 = new Person("王健");
            p1.DoTo("外出");
            if(p1.MyHat==null)
            {
                Console.WriteLine("没有戴帽子!");
            }
            else
            {
                Console.WriteLine($"{p1.MyHat.Name} {p1.MyHat.HatType} {p1.MyEquipment.Name}");
            }
        }
    }

    public class Person
    {
        private Hat myHat;
        private Equipment myEquipment;
        private string myName;

        private ArrayList arr;

        public Person()
        {
            arr = new ArrayList();
            arr.Add(new Wlak());
            arr.Add(new Swimming());
        }

        public Person(string name) : this()
        {
            myName = name;
        }

        public string MyName
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }

        public Hat MyHat
        {
            get { return myHat; }
            set { myHat = value; }
        }

        public Equipment MyEquipment
        {
            get
            {
                return myEquipment;
            }
            set
            {
                myEquipment = value;
            }
        }


        public void DoTo(string name)
        {
            int i;

            for (i = 0; i < arr.Count; i++)
            {
                BeHavior myp = (BeHavior)arr[i];
                if (myp.Name == name)
                {
                    myHat = HatFactory.CreateHat(myp);
                    myEquipment = EquipmentFactory.CreateEquipment(myp);
                    myp.Doto();
                    break;
                }
            }
        }

    }

    public interface IBeHavior
    {
        void Doto();
        string Name { get; set; }

        string Des { get; set; }
    }

    public abstract class BeHavior : IBeHavior
    {
        public BeHavior() { }

        protected Person Person;
        private  string name;
        private string dec;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Des
        {
            get
            {
                return dec;
            }
            set
            {
                dec = value;
            }
        }

        public abstract void Doto();
       
    }

    public class Wlak : BeHavior
    {
        public Wlak()
        {
            this.Name = "外出";
            this.Des = "外出的类";
        }
        public override void Doto()
        {
            Console.WriteLine($"{Name} Doto {Des}");
        }
    }

    public class Swimming : BeHavior
    {
        public Swimming()
        {
            this.Name = "游泳";
            this.Des = "游泳的类";
        }
        public override void Doto()
        {
            Console.WriteLine($"{Name} Doto {Des} ");
        }
    }

    public class HatFactory
    {
        public HatFactory() { }

        public static Hat CreateHat(BeHavior b)
        {
            Hat hat = null;
            string bn = b.Name;
            switch (bn)
            {
                case "外出":
                    hat = new WalkHat();
                    break;
                case "游戏":
                    hat = new SwimmingHat();
                    break;
            }
            return hat;
        }
    }
    public class Hat
    {
        public Hat() { }

        public string Name { get; set; }

        public string Color { get; set; }

        public string HatType { get; set; }

    }

    public class WalkHat:Hat
    {
        public WalkHat()
        {
            this.Name = "太阳帽";
            this.Color = "红色";
            this.HatType = "外出类型";
        }
    }

    public class SwimmingHat : Hat
    {
        public SwimmingHat()
        {
            this.Name = "游泳帽";
            this.Color = "黄色";
            this.HatType = "游泳类型";
        }
    }

    public class EquipmentFactory
    {
        public EquipmentFactory() { }

        public static Equipment CreateEquipment(BeHavior b)
        {
            Equipment eq = null;
            string bs = b.Name;
            switch (bs)
            {
                case "外出":
                    eq = new Armor();
                    break;
                case "游戏":
                    eq = new Knife();
                    break;
            }
            return eq;
        }
    }

    public class Equipment
    {
        public string Name { get; set; }

    }

    public class Knife:Equipment
    {
        public Knife()
        {
            this.Name = "刀";
        }
    }

    public class Armor : Equipment
    {
        public Armor()
        {
            this.Name = "铠甲";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSet_Bridge
    {
        public static void Printf()
        {
            Brush b = new BigBrush();
            b.SetColor(new Red());
            b.Paint();
            b.SetColor(new Blue());
            b.Paint();

            b = new SmallBrush();
            b.SetColor(new Red());
            b.Paint();
        }
    }

    public abstract class Brush
    {
        protected Color c;
        public abstract void Paint();

        public void SetColor(Color c)
        {
            this.c = c;
        }
    }

    public class BigBrush:Brush
    {
        public override void Paint()
        {
            Console.WriteLine($"Using big brush and color{c.color} painting");
        }
    }

    public class SmallBrush : Brush
    {
        public override void Paint()
        {
            Console.WriteLine($"Using SmallBrush and color{c.color} painting");
        }
    }

    public class Color
    {
        public string color;
    }

    public class Red : Color {
        public  Red()
        {
            this.color = "red";
        }
    }
    public class Blue : Color
    {
        public Blue()
        {
            this.color = "red";
        }
    }
}

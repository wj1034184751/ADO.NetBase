using System;

namespace MathHelper
{
    public class Complex
    {
        float real;
        float imag;

        public Complex(float r,float i)
        {
            real = r;
            imag = i;
        }

        public void setReal(float r)
        {
            real = r;
        }

        public void setImag(float i)
        {
            imag = i;
        }

        public float getReal()
        {
            return real;
        }

        public float getImag()
        {
            return imag;
        }

        public abstract class Butterfly
        {
            float y;
            public Butterfly()
            {

            }

            public Butterfly (float angle)
            {
                y = angle;
            }

            abstract public void Execute(Complex x, Complex y);
        }

        public class AddButterfly : Butterfly
        {
            float oldrl, oldil;
            public AddButterfly(float angle)
            {
            }

            public override void Execute(Complex xi, Complex xj)
            {
                oldrl = xi.getReal();
                oldil = xi.getImag();
                xi.setReal(oldrl + xj.getReal());
                xj.setReal(oldrl - xj.getReal());
                xi.setImag(oldil + xj.getImag());
                xj.setImag(oldil - xj.getImag());
            }
        }

        public class TrigButterfly : Butterfly
        {
            float y, oldrl, oldil;
            float cosy, siny;
            float r2cosy, r2siny, i2cosy, i2siny;

            public TrigButterfly(float angle)
            {
                y = angle;
                cosy = (float)Math.Cos(y);
                siny = (float)Math.Sin(y);
            }

            public override void Execute(Complex xi, Complex xj)
            {
                oldrl = xi.getReal();
                oldil = xi.getImag();
                r2cosy = xj.getReal() * cosy;
                r2siny = xj.getReal() * siny;
                i2cosy = xj.getImag() * cosy;
                i2siny = xj.getImag() * siny;
                xi.setReal(oldrl + r2cosy + i2siny);
                xi.setImag(oldil - r2siny + i2cosy);
                xj.setReal(oldrl - r2cosy - i2siny);
                xj.setImag(oldil + r2siny - i2cosy);
            }
        }
    }
}

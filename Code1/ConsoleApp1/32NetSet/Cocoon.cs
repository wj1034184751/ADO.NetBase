using System;
using System.Collections.Generic;
using System.Text;
using static MathHelper.Complex;

namespace _32NetSet
{
    public class Cocoon
    {
        static public Butterfly getButterfly(float y)
        {
            if (y != 0)
                return new TrigButterfly(y);
            else
                return new AddButterfly(y);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public abstract class SwimmingEvent
    {
        protected int numLanes;
        protected ArrayList swimmers;

        public SwimmingEvent(string filename,int lanes)
        {
            numLanes = lanes;
            swimmers = new ArrayList();

        }
    }


    class NetSet_Factory_Swimming
    {
    }
}

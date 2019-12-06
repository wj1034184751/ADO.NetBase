using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public abstract class Event
    {
        protected int numLanes;
        protected ArrayList swimmer;

        public Event(string filename,int lanes)
        {
            numLanes = lanes;
            swimmer = new ArrayList();
            FileHelper.csFile f = new FileHelper.csFile(filename);
            f.OpenForRead();
            string s = f.readLine();
            while(s!=null)
            {
                
            }
        }

     
    }

    public class NetSet_Swimmer
    {
    }
}

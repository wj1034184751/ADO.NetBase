using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSet_Adapter
    {
    }

    //public interface Target
    //{
    //    void Do();
    //}

    //public class Adaptee
    //{
    //    public void Execute()
    //    {

    //    }
    //}

    //public class Adapter : Target
    //{
    //    private Adaptee adaptee;

    //    public Adapter(Adaptee ap)
    //    {
    //        adaptee = ap;
    //    }
    //    public void Do()
    //    {
    //        adaptee.Execute();
    //    }
    //}

    #region Adapter2
    public interface IStack
    {
        void Push(object item);
        void Pop();
        object Peek();
    }

    public class Adapter : IStack
    {
        ArrayList adaptee;

        public Adapter()
        {
            adaptee = new ArrayList();
        }
        public object Peek()
        {
            return adaptee[adaptee.Count - 1];
        }

        public void Pop()
        {
            adaptee.RemoveAt(adaptee.Count - 1);
        }

        public void Push(object item)
        {
            adaptee.Add(item);
        }
    }

    public class Adapter2 : ArrayList, IStack
    {
        public object Peek()
        {
            return this[this.Count - 1];
        }

        public void Pop()
        {
            this.RemoveAt(this.Count - 1);
        }

        public void Push(object item)
        {
            this.Add(item);
        }
    }
    #endregion
}

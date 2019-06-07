using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EventBus<T>
    {
        private EventBus() { }

        private static EventBus<T> Eve { get; set; }

        public static EventBus<T> CreateInstance()
        {
            if (Eve == null)
            {
                Eve = new EventBus<T>();
            }

            return Eve;
        }

        private Dictionary<string, List<EventHandler>> dic = new Dictionary<string, List<EventHandler>>();

        public void InvockEvent(string eventName)
        {
            if (!Exist(eventName))
            {
                return;
            }

            foreach (var eventHandler in dic[eventName])
            {
                eventHandler.BeginInvoke(this, new EventArgs(), null, null);
            }
        }

        public void AddEvent(string eventName, EventHandler e)
        {
            if (Exist(eventName))
            {
                dic[eventName].Add(e);
            }
            else
            {
                List<EventHandler> list = new List<EventHandler>();
                list.Add(e);
                dic.Add(eventName, list);
            }
        }

        public void RemoveEvent(string eventName)
        {
            if (!Exist(eventName))
            {
                return;
            }

            dic.Remove(eventName);
        }

        public void UpdateEvent(string eventName,List<EventHandler>es)
        {
            if(Exist(eventName))
            {
                dic[eventName].AddRange(es);
            }
            else
            {
                List<EventHandler> list = new List<EventHandler>();
                list.AddRange(es);
                dic.Add(eventName, list);
            }
        }

        public void RemoveByHandle(string eventName, EventHandler e)
        {
            if (!Exist(eventName))
            {
                return;
            }

            dic[eventName].Where(d => d == e).ToList().Remove(e);
        }

        private bool Exist(string key)
        {
            return dic.Keys.Contains(key);
        }
    }

    public class MyString
    {
        private EventBus<MyString> ev = EventBus<MyString>.CreateInstance();

        private string Str { get; set; }

        public MyString(string str)
        {
            this.Str = str;
        }

        public string str
        {
            get { return this.Str; }

            set
            {
                if (value != this.str)
                {
                    ev.InvockEvent("valueChange");
                }

                if (value.Length != this.Str.Length)
                {
                    ev.InvockEvent("valueLengthChange");
                }

                Str = value;
            }
        }
    }

    public class InitEvent
    {
        public static EventBus<MyString> ev = EventBus<MyString>.CreateInstance();
        static InitEvent()
        {

            ev.AddEvent("valueChange", (o, e) =>
             {
                 Console.WriteLine(1111111);
             });
            ev.AddEvent("valueLengthChange", (o, e) =>
             {
                 Console.WriteLine("长度变了");
             });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    #region
    public delegate void StringProcessor(string input);

    public class DelegateTest
    {
        public static void Run()
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");
            StringProcessor jonVotice, tomVotice, background;
            ////创建三个委托实例
            jonVotice = new StringProcessor(jon.Say);
            tomVotice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);
            ////调用委托实例
            jonVotice("Hello,son");
            tomVotice.Invoke("Hello,Dayy!");
            background("An airplance files past.");
        }
    }

    public class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public void Say(string message)
        {
            Console.WriteLine("{0} says:{1}", name, message);
        }
    }

    public class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("{0}", note);
        }
    }

    public delegate bool ComparisonHandler(int first, int second);

    public class DelegateSample
    {
        public static  bool GreaterThan(int first,int second)
        {
            return first > second;
        }

        public static bool GreaterThan2(int first, int second)
        {
            return first < second;
        }

        public static void SampleSort(int[] items, ComparisonHandler comparisonHandler)
        {
            int i;
            int j;
            int temp;

            if (comparisonHandler == null)
            {
                throw new ArgumentException("comparsionMethod");
            }

            if (items == null)
            {
                return;
            }

            for (i = 0; i <= items.Length; i++)
            {
                for (j = i + 1; j < items.Length; j++)
                {
                    if (comparisonHandler(items[i], items[j]))
                    {
                        temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public static void Print()
        {
            //int[] items = new int[] { 1, 10, 20, 4, 2, -3, -64, 33, 100, 2034, -342, 21 };

            //SampleSort(items,GreaterThan2);

            //foreach (var item in items)
            //{
            //    Console.Write(item + ",");
            //}

            IEnumerable<Process> processes = Process.GetProcesses().Where(d =>
              {
                  return d.WorkingSet64 > 10;
              });

            foreach(var item in processes)
            {
                Console.WriteLine(item.ProcessName);
            }
        }
    }
    #endregion
}

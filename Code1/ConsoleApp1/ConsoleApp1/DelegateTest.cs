using System;
using System.Collections.Generic;
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
    #endregion
}

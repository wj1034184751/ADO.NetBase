using System;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSet_Prototype
    {
        public static void Printf()
        {
            GameSystem game = new GameSystem();
            game.Run(new NormalActorA());
        }
    }

    public abstract class NormatActor
    {
        public abstract NormatActor clone();
    }

    public abstract class NormalActor
    {
        public abstract NormalActor clone();
    }

    public class NormalActorA : NormalActor
    {
        public override NormalActor clone()
        {
            Console.WriteLine("NormalActorA is call");
            return (NormalActor)this.MemberwiseClone();
        }
    }

    public class NormalActorB:NormalActor
    {
        public override NormalActor clone()
        {
            Console.WriteLine("NormalActorB was called");
            return (NormalActor)this.MemberwiseClone();
        }
    }

    public class GameSystem
    {
        public void Run(NormalActor normalActor)
        {
            NormalActor n1 = normalActor.clone();
            NormalActor n2 = normalActor.clone();
            NormalActor n3 = normalActor.clone();
            NormalActor n4 = normalActor.clone();
        }
    }
}

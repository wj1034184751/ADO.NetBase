using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace _32NetSet
{
    public class NetSet_Builder
    {
        public static void Printf()
        {
            var imgplath = @"D:\OtherCode\书\23设计\1.jpg";
            var nimgpath = @"D:\OtherCode\书\23设计\2.jpg";
            using (var img = Image.FromFile(@"D:\OtherCode\书\23设计\1.jpg"))
            {
                using (var g = Graphics.FromImage(img))
                {
                    g.DrawString("我爱你中国,亲爱的母亲", new Font(new FontFamily("宋体"), 14), new SolidBrush(System.Drawing.Color.Red), 10, 20, new StringFormat());
                    GUIFaceBuilder b = new GUIFaceBuilder(g);
                    FaceDirector c = new FaceDirector(b);
                    c.CreateFace();
                    img.Save(nimgpath);
                }
            }
        }
    }

    public abstract class FaceBuilder
    {
        public FaceBuilder() { }

        public abstract void BuilderFace();
        public abstract void BuilderEyes();
        public abstract void BuilderNose();
        public abstract void BuilderEars();
        public abstract void BuilderMouth();
    }

    public class GUIFaceBuilder : FaceBuilder
    {
        private Graphics grap;
        private Pen p;
        public GUIFaceBuilder(Graphics g)
        {
            grap = g;
            p = new Pen(System.Drawing.Color.Blue);
        }
        public override void BuilderEars()
        {
            grap.DrawEllipse(p, 100, 100, 200, 300);
        }

        public override void BuilderEyes()
        {
            grap.DrawEllipse(p, 125, 220, 50, 30);
            grap.DrawEllipse(p, 225, 220, 50, 30);
        }

        public override void BuilderFace()
        {
            grap.DrawEllipse(p, 80, 250, 20, 40);
            grap.DrawEllipse(p, 300, 250, 20, 40);
        }

        public override void BuilderMouth()
        {
            grap.DrawEllipse(p, 190, 250, 20, 50);
        }

        public override void BuilderNose()
        {
            grap.DrawEllipse(p, 190, 35, 20, 1);
        }
    }

    public class FaceObjectBuilder : FaceBuilder
    {
        private Face face;
        public FaceObjectBuilder() { }

        public override void BuilderEars()
        {
            throw new NotImplementedException();
        }

        public override void BuilderEyes()
        {
            throw new NotImplementedException();
        }

        public override void BuilderFace()
        {
            face = new Face();
        }

        public override void BuilderMouth()
        {
            throw new NotImplementedException();
        }

        public override void BuilderNose()
        {
            throw new NotImplementedException();
        }
    }

    public class Face
    {
       
    }
    public class FaceDirector
    {
        private FaceBuilder b;
        public FaceDirector(FaceBuilder b)
        {
            this.b = b;
        }

        public void CreateFace()
        {
            b.BuilderFace();
            b.BuilderEyes();
            b.BuilderEars();
            b.BuilderMouth();
            b.BuilderNose();
        }
    }

    #region other
    public class Link : ICloneable
    {
        private Node myBeginNode;
        private Node myEndNode;

        public Link() { }

        public Node BeginNode
        {
            set
            {
                myBeginNode = value;
            }
            get
            {
                return myBeginNode;
            }
        }

        public Node EndNode
        {
            set
            {
                myEndNode = value;
            }

            get
            {
                return myEndNode;
            }
        }

        public object Clone()
        {
            return new Link();
        }
    }

    public class Node : ICloneable
    {
        private ArrayList myLinks = new ArrayList();

        public Node() { }

        public ArrayList Links
        {
            get
            {
                return myLinks;
            }
        }

        public object Clone()
        {
            return new Node();
        }
    }
    public class Graph : ICloneable
    {
        private ArrayList myNodes = new ArrayList();
        private ArrayList myLinks = new ArrayList();
        public Graph() { }

        public ArrayList Nodes
        {
            get
            {
                return myNodes;
            }
        }

        public ArrayList Links
        {
            get
            {
                return myLinks;
            }
        }

        public object Clone()
        {
            Graph g = new Graph();
            Hashtable hnode = new Hashtable();
            Hashtable hlink = new Hashtable();

            foreach(var n in this.myNodes)
            {
                Node newn = (Node)((Node)n).Clone();
                g.Nodes.Add(newn);
                hnode.Add(newn, n);
            }

            foreach(Link l in this.myLinks)
            {
                Link newl = (Link)l.Clone();
                g.Links.Add(newl);
                hlink.Add(l, newl);
            }

            foreach(Node n in g.Nodes)
            {
                Node oldn = (Node)hnode[n];
                foreach(Link l in oldn.Links)
                {
                    Link newl = (Link)hlink[l];
                    n.Links.Add(newl);
                    if (l.BeginNode == oldn)
                        newl.BeginNode = n;
                    else
                        newl.EndNode = n;
                }
            }
            return g;
        }
    }

    public class NodeListTest
    {
        public static void Printf()
        {
            Graph g1 = new Graph();
            g1.Links.Add("g1_L1");
            g1.Links.Add("g1_L2");
            g1.Nodes.Add("g1_N1");
            g1.Nodes.Add("g1_N2");
            Graph g2 = (Graph)g1.Clone();
            g2.Links.Add("g2_L1");
            
        }
    }
    #endregion

    #region Builder2

    public class House
    { }
    public abstract class Builder
    {
        public abstract void BuildDoor();
        public abstract void BuildWall();
        public abstract void BuildWindows();
        public abstract void BuildFloor();
        public abstract void BuildHouseCeiling();

        public abstract House GetHouse();
    }

    public class Director
    {
        private Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildWall();
            builder.BuildDoor();
            builder.BuildFloor();
            builder.BuildWindows();
            builder.BuildHouseCeiling();
        }
    }

    public class ChineseBuilder:Builder
    {
        private House ChineseHouse = new House();

        public override void BuildDoor()
        {
            Console.WriteLine("this Door is style of Chinese");
        }

        public override void BuildFloor()
        {
            Console.WriteLine("this Floor is style of Chinese");
        }

        public override void BuildHouseCeiling()
        {
            Console.WriteLine("this HouseCeiling is style of Chinese");
        }

        public override void BuildWall()
        {
            Console.WriteLine("this Wall is style of Chinese");
        }

        public override void BuildWindows()
        {
            Console.WriteLine("this Windows is style of Chinese");
        }

        public override House GetHouse()
        {
            return ChineseHouse;
        }
    }

    public class RomanBuilder : Builder
    {
        private House RomanHouse = new House();

        public override void BuildDoor()
        {
            Console.WriteLine("this Roman is style of Chinese");
        }

        public override void BuildFloor()
        {
            Console.WriteLine("this Roman is style of Chinese");
        }

        public override void BuildHouseCeiling()
        {
            Console.WriteLine("this Roman is style of Chinese");
        }

        public override void BuildWall()
        {
            Console.WriteLine("this Roman is style of Chinese");
        }

        public override void BuildWindows()
        {
            Console.WriteLine("this Roman is style of Chinese");
        }

        public override House GetHouse()
        {
            return RomanHouse;
        }
    }

    public class ClientBuilder
    {
        public static void Printf()
        {
            ChineseBuilder cbuilder = new ChineseBuilder();
            Director director = new Director(cbuilder);
            director.Construct();
        }
    }
    #endregion
}


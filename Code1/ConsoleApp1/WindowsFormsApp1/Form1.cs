using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Thread th1;
        Thread th2;
        Thread th3;
        Thread th4;
        Thread th5;
        Thread th6;
        static bool IsLive = false;
        static Color[] colorArray = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Tomato, Color.Violet, Color.Teal };
        static int[] intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static  ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
        static List<string> list = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsLive = true;
            //th1 = new Thread(TestT1Run);
            //th1.IsBackground = true;
            //th1.Start();

            TestT2Run();
        }

        public void TestT1Run()
        {
            this.textBox1.BackColor = colorArray[0];
            this.textBox2.BackColor = colorArray[1];
            this.textBox3.BackColor = colorArray[2];
            this.textBox4.BackColor = colorArray[3];
            this.textBox5.BackColor = colorArray[4];
            this.textBox6.BackColor = colorArray[5];
            while (IsLive)
            {
                Thread.Sleep(1000);
                var list = CreateInt();
                this.textBox1.Text = list[0];
                this.textBox2.Text = list[1];
                this.textBox3.Text = list[2];
                this.textBox4.Text = list[3];
                this.textBox5.Text = list[4];
                this.textBox6.Text = list[5];
            }
        }

        public void TestT2Run()
        {
            th1 = new Thread(new ParameterizedThreadStart(Thread1));
            th2 = new Thread(Thread2);
            th3 = new Thread(Thread3);
            th4 = new Thread(Thread4);
            th5 = new Thread(Thread5);
            th6 = new Thread(Thread6);

            th1.Start(true);
            th1.IsBackground = true;

            //th2.Start();
            //th2.IsBackground = true;

            //th3.Start();
            //th3.IsBackground = true;

            //th4.Start();
            //th4.IsBackground = true;

            //th5.Start();
            //th5.IsBackground = true;

            //th6.Start();
            //th6.IsBackground = true;
        }

        public static List<string> CreateInt()
        {
            while (list.Count <= 6)
            {
                var item = $"{intArray[new Random().Next(0, 9)]}{intArray[new Random().Next(0, 9)]}";
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public void ClearList()
        {
            list.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ThreadAbort();
            //string result = this.textBox1.Text + this.textBox2.Text + this.textBox3.Text + this.textBox4.Text + this.textBox5.Text + this.textBox6.Text;
         
        }

        public void Thread1(object isLive)
        {
           
       
            th2.Start(true);
            th2.IsBackground = true;
            while (bool.Parse(isLive.ToString()))
            {
             
                var list = CreateInt();
                this.textBox1.BackColor = colorArray[0];
                this.textBox1.Text = list[0];
                ClearList();
            }
        }
        public void Thread2(object isLive)
        {
           
            th3.Start(true);
            th3.IsBackground = true;

            while (bool.Parse(isLive.ToString()))
            {
              
                var list = CreateInt();
                this.textBox2.BackColor = colorArray[1];
                this.textBox2.Text = list[1];
                ClearList();
            }
        }
        public void Thread3(object isLive)
        {

        
            th4.Start(true);
            th4.IsBackground = true;
            while (bool.Parse(isLive.ToString()))
            {
         
                var list = CreateInt();
                this.textBox3.BackColor = colorArray[2];
                this.textBox3.Text = list[2];
                ClearList();
            }
        }
        public void Thread4(object isLive)
        {
     
            th5.Start(true);
            th5.IsBackground = true;

            while (bool.Parse(isLive.ToString()))
            {
         
                var list = CreateInt();
                this.textBox4.BackColor = colorArray[3];
                this.textBox4.Text = list[3];
                ClearList();
            }
        }
        public void Thread5(object isLive)
        {
      
            th6.Start(true);
            th6.IsBackground = true;

            while (bool.Parse(isLive.ToString()))
            {
             
                var list = CreateInt();
                this.textBox5.BackColor = colorArray[4];
                this.textBox5.Text = list[4];
                ClearList();
            }
        }
        public void Thread6(object isLive)
        {
           
            while (bool.Parse(isLive.ToString()))
            {
             
                var list = CreateInt();
                this.textBox6.BackColor = colorArray[5];
                this.textBox6.Text = list[5];
                ClearList();
            }
        }

        public void ThreadAbort()
        {
            Thread th = new Thread(() =>
              {
                  th1.Abort();
                  this.textBox8.Text += $"{this.textBox1.Text}";
                  Thread.Sleep(2000);

                  th2.Abort();
                  this.textBox8.Text += $"{this.textBox2.Text}";
                  Thread.Sleep(3000);

                  th3.Abort();
                  this.textBox8.Text += $"{this.textBox3.Text}";
                  Thread.Sleep(3000);

                  th4.Abort();
                  this.textBox8.Text += $"{this.textBox4.Text}";
                  Thread.Sleep(3000);

                  th5.Abort();
                  this.textBox8.Text += $"{this.textBox5.Text}";
                  Thread.Sleep(3000);

                  th6.Abort();
                  this.textBox8.Text += $"{this.textBox6.Text}";
              });
            th.Start();
            th.IsBackground = true;
        }
    }
}

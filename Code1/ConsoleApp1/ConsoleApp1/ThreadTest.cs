using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    public class ThreadTest
    {
        public void HelloWorld()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"Thrad:{Thread.CurrentThread.ManagedThreadId} Hello ,world.");
        }

        public void RepeatHelloWorld(object count)
        {
            for (int i = 0; i < (int)count; i++)
            {
                Console.WriteLine($"Thrad:{Thread.CurrentThread.ManagedThreadId} Repeat Hello world.");
            }
        }
    }

    public class TestRunClass
    {
        public string Name { get; set; }

        public int State { get; set; }
    }

    public class ThreadRun
    {
        public const int Repetitions = 1000;

        public WaitCallback back;

        public static void ThreadT1()
        {
            Console.WriteLine($"Thrad:{Thread.CurrentThread.ManagedThreadId}");
            ThreadTest t1 = new ThreadTest();
            Thread th1 = new Thread(t1.HelloWorld);
            th1.Start();
            Thread th2 = new Thread(t1.RepeatHelloWorld);
            th2.Start(5);
        }

        public static void ThreadT2()
        {
            ThreadRun run = new ThreadRun();
            TestRunClass myclass = new TestRunClass();
            run.back = new WaitCallback(d =>
              {

                  var obj = (TestRunClass)d;
                  obj.Name = "wj";
                  obj.State = 1;
                  Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId} Name :{CallContext.LogicalGetData("Name")} state:{obj.Name}");
              });
            run.back(myclass);
            Console.WriteLine("主线程");
            Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine();

            CallContext.LogicalSetData("Name", "Alice");
            ThreadPool.QueueUserWorkItem(run.back);
            Console.WriteLine("IsFlowSuppressed:{0}", ExecutionContext.IsFlowSuppressed());
            //ExecutionContext.SuppressFlow();
            //ThreadPool.QueueUserWorkItem(
            //    d =>
            //    {
            //        Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId} Name :{CallContext.LogicalGetData("Name")}");
            //    });
            Console.WriteLine();
            Console.Write("Hit <Enter> to End.");
            Thread.Sleep(5000);
            Console.WriteLine($"MyClass Name{myclass.Name} State{myclass.State}");
        }

        public static void ThreadT3()
        {
            ThreadRun r = new ThreadRun();
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "test.txt");
            Console.WriteLine("主程序中!");
            Console.WriteLine("线程的Id:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();

            FileStream fs = new FileStream(path, System.IO.FileMode.Open, System.Security.AccessControl.FileSystemRights.Read, System.IO.FileShare.Read, 8, System.IO.FileOptions.Asynchronous);
            byte[] butter = new byte[fs.Length];
            //fs.Read(butter, 0, butter.Length);
            //string message = Encoding.Default.GetString(butter, 0, butter.Length);
            //Console.WriteLine(message);
            AsyncCallback back = new AsyncCallback(r.AsyncCallback);
            //IAsyncResult result = fs.BeginRead(butter, 0, butter.Length, d =>
            //     {
            //         Console.WriteLine("第三步操作中,");
            //         Console.WriteLine("线程的 Id:{0}", Thread.CurrentThread.ManagedThreadId);
            //         //int lenth = fs.EndRead(d);
            //         //string message = Encoding.Default.GetString(butter, 0, butter.Length);
            //         //Console.WriteLine(message);
            //     }, fs);
            IAsyncResult result2 = fs.BeginRead(butter, 0, butter.Length, back, null);
            Console.WriteLine("第一步完成 !");
            Console.WriteLine("线程的Id:{0}", Thread.CurrentThread.ManagedThreadId);
            //result.AsyncWaitHandle.WaitOne();
            int lenth = fs.EndRead(result2);
            string message = Encoding.Default.GetString(butter, 0, butter.Length);
            Console.WriteLine(message);
            Console.WriteLine("结束》》》》》》》》》》》》》》》》》线程的Id:{0}", Thread.CurrentThread.ManagedThreadId);
            //Console.ReadLine();
        }

        public static void ThreadT4()
        {
            Console.WriteLine($"主线程:{Thread.CurrentThread.ManagedThreadId}");
            ThreadPool.QueueUserWorkItem(new WaitCallback(WaitCallBack));
            Console.WriteLine("主线程在工作");
            Thread.Sleep(5000);
            Console.WriteLine("主线程结束");
        }

        public void AsyncCallback(IAsyncResult ar)
        {
            Console.WriteLine("开始管道结束部分任务");
            Console.WriteLine("线程的 Id:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("继续管道处理过程");
        }

        public void AsyncCallback2(IAsyncResult ar)
        {
            Console.WriteLine("开始管道结束部分任务");
            Console.WriteLine("线程的 Id:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("继续管道处理过程");
        }

        public static void WaitCallBack(object test)
        {
            Console.WriteLine($"当前线程:{Thread.CurrentThread.ManagedThreadId}");
        }

        public static void ThreadT5()
        {
            ThreadPool.QueueUserWorkItem(DoWork, "+");

            for(int count=0; count<Repetitions;count++)
            {
                Console.Write("-");
            }

            Thread.Sleep(1000);
        }

        public static void DoWork(object state)
        {
            for (int count = 0; count < Repetitions; count++)
            {
                Console.Write(state);
            }
        }

        public static void ThreadT6()
        {
            Console.WriteLine($"当前线程:{Thread.CurrentThread.ManagedThreadId}");
            Task<string> task = Task.Run<string>(() =>
             {
                 Console.WriteLine($"当前线程:{Thread.CurrentThread.ManagedThreadId}");
                 return Calculate(100);
             });
            task.Wait();
        }

        public static string Calculate(int digits = 100)
        {
            Console.WriteLine($"当前线程:{Thread.CurrentThread.ManagedThreadId}");
            for (var i = 0; i < digits; i++)
            {
                Console.Write("+");
            }

            return "Hello";
        }
    }

    public class NextStep
    {
        private System.Web.EndEventHandler _nextHandler;

        public NextStep(EndEventHandler handler)
        {
            this._nextHandler = handler;
        }

        public void AsyncCallback(IAsyncResult ar)
        {
            Console.WriteLine("开始管道结束部分任务");
            Console.WriteLine("线程的 Id:{0}", Thread.CurrentThread.ManagedThreadId);

            this._nextHandler(ar);

            Console.WriteLine("继续管道处理过程");
        }
    }

    public class ReadFile
    {
        private byte[] bufer = new byte[2048];
        FileStream fs;

        public IAsyncResult BeginReadFile(object sender, EventArgs e, AsyncCallback cb, object extraData)
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "test.txt");
            Console.WriteLine("正在执行开始方法!");
            Console.WriteLine("线程的Id:{0}", Thread.CurrentThread.ManagedThreadId);
            fs = new System.IO.FileStream(path, FileMode.Open);
            bufer = new byte[fs.Length];
            Console.WriteLine();
            return fs.BeginRead(bufer, 0, bufer.Length, cb, null);
        }

        public void EndReadFile(IAsyncResult ar)
        {
            Console.WriteLine("正在执行结束方法!");
            Console.WriteLine("线程的Id:{0}", Thread.CurrentThread.ManagedThreadId);
            int lenth = fs.EndRead(ar);
            string message = System.Text.Encoding.Default.GetString(bufer, 0, lenth);
            Console.WriteLine(message);
            Console.WriteLine("结束方法执行完毕!");
            Console.WriteLine();
        }
    }

    public class StepDemo
    {
        private BeginEventHandler _beginHandler;
        private EndEventHandler _endHandler;

        public void AddOnWork(BeginEventHandler beginHandler,EndEventHandler endHandler)
        {
            this._beginHandler = beginHandler;
            this._endHandler = endHandler;
        }

        public void DoAsyncWork(object UnUsed)
        {
            DoAsyncBeginWork();
        }

        private void DoAsyncBeginWork()
        {
            Console.WriteLine("开始执行管理  开始部分工作");
            Console.WriteLine("线程的Id:{0}", Thread.CurrentThread.ManagedThreadId);
            if (this._beginHandler != null)
            {
                NextStep step = new NextStep(this._endHandler);
                this._beginHandler(this, EventArgs.Empty, step.AsyncCallback, null);
            }

            Console.WriteLine("注意！ 此时管道的开始部分已经执行完成了");
            Console.WriteLine();
        }
    }

    public class ThreadTestTwo
    {
        public static void Print()
        {
            //Thread t = new Thread(PrintNumberWithDelay);
            //t.Start();
            //t.Join();
            //PrintNumber();
            Console.WriteLine("Starting program...");
            Thread t = new Thread(PrintNumberWithDelay);
            t.Start();
            t.Abort();
            Console.WriteLine("A thread has been abortd");
            Thread t2 = new Thread(PrintNumber);
            t2.Start();
            PrintNumber();
        }

        static void PrintNumber()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void PrintNumberWithDelay()
        {
            Console.WriteLine("Starting....");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    public class ThreadLock
    {
        public static void Print()
        {
            object lcok1 = new object();
            object lock2 = new object();
            new Thread(() => LockTooMuch(lcok1, lock2)).Start();
            lock (lock2)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Moniotr.tlyrneter");
                if (Monitor.TryEnter(lcok1, TimeSpan.FromDays(5)))
                {
                    Console.WriteLine("Acqu a reqsourece");
                }
                else
                {
                    Console.WriteLine("TimeOut");
                }
            }

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>");

            lock (lock2)
            {
                Console.WriteLine("This will be a deadlock!");
                Thread.Sleep(1000);
                lock(lcok1)
                {
                    Console.WriteLine("thdsf");
                }
            }
        }

        public static  void LockTooMuch(object lock1,object lock2)
        {
            lock(lock1)
            {
                Thread.Sleep(1000);
                lock (lock2) ;
            }
        }
    }

    public class ThradThrow
    {
        public static void Print()
        {
            var t = new Thread(FaultyThread);
            t.Start();
            t.Join();
            try
            {
                t = new Thread(BadFaultyThread);
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("We wont get here!");
            }
        }
        static void BadFaultyThread()
        {
            Console.WriteLine("Starting a faulty thread...");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            throw new Exception("Boom!");
        }

        static void FaultyThread()
        {
            try
            {
                Console.WriteLine("Start a faulty thread...");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                throw new Exception("Boom!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception handled:{0}", ex.Message);
            }
        }
    }

    public class ThreadHybrid
    {
        public static void Print()
        {
            var c = new Counter();
            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() =>
            {
                Console.WriteLine("tt");
                TestCounter(c);
            });
            var t3 = new Thread(() => {
                Console.WriteLine("tttt");
                TestCounter(c);
            });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"Total count:{c.Count}");

            var c1 = new CounterMutex();
            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() =>
            {
                Console.WriteLine("tt");
                TestCounter(c1);
            });
            t3 = new Thread(() => TestCounter(c1));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"Total count:{c1.Count}");
        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 10000000000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
    }

    public abstract class CounterBase
    {
        public abstract void Increment();
        public abstract void Decrement();
    }

    public class Counter : CounterBase
    {
        private int _count;

        public int Count { get { return _count; } }

        public override void Increment()
        {
            _count++;
        }

        public override void Decrement()
        {
            _count--;
        }
    }

    public class CounterNoLock : CounterBase
    {
        private int _count;

        public int Count { get { return _count; } }

        public override void Increment()
        {
            Interlocked.Increment(ref _count);
        }

        public override void Decrement()
        {
            Interlocked.Decrement(ref _count);
        }
    }

    public class CounterMutex : CounterBase
    {
        const string MutexName = "TreadMutex";
        private int _count;

        public int Count { get { return _count; } }

        public override void Increment()
        {
            using (var m = new Mutex(false, MutexName))
            {
                if (!m.WaitOne())
                {
                    _count++;
                    m.ReleaseMutex();
                }
                else
                    m.ReleaseMutex();
            }
        }

        public override void Decrement()
        {
            using (var m = new Mutex(false, MutexName))
            {
                if (!m.WaitOne())
                {
                    _count--;
                    m.ReleaseMutex();
                }
                else
                    m.ReleaseMutex();
            }
        }
    }

    public class ThreadSemaphoreSlim
    {
        public static void Print()
        {
            for (int i = 1; i <= 9; i++)
            {
                string threadName = "Thread" + i;
                int secondToWait = 2 + 2 * i;
                var t = new Thread(() => AccessDatabase(threadName, secondToWait));
                t.Start();
            }
        }

        static SemaphoreSlim _semaphore = new SemaphoreSlim(4);

        static void AccessDatabase(string name,int seconds)
        {
            Console.WriteLine("{0} waite to access a database", name);
            _semaphore.Wait();
            Console.WriteLine("{0} was granted an access to a database", name);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} is completed", name);
            _semaphore.Release();
        }
    }
}

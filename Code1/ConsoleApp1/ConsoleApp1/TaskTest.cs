using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TaskTest
    {
        public static async void Printf()
        {
            TaskTest t = new TaskTest();
            CancellationToken c = new CancellationToken();
            var result =await t.DoSaync(c);
            Console.WriteLine(c.WaitHandle);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(1);
        }

        public Task<int> DoSaync(CancellationToken canceToken)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            int result = 1;
            Console.WriteLine(canceToken.CanBeCanceled);
            Console.WriteLine(canceToken.IsCancellationRequested);
            return Task.FromResult(result);
        }
    }
}


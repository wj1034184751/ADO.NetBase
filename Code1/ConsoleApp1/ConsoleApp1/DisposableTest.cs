using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DisposableTest : IDisposable
    {
        public void DoSomething()
        {
            Console.WriteLine("Do some thing....");
        }

        public void Dispose()
        {
            Console.WriteLine("及时释放资源");
        }
    }
}

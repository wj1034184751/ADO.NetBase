using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExpressionTest
    {
        public static void Print()
        {
            ConstantExpression _constExp = Expression.Constant("aaa", typeof(string));
            MethodCallExpression _methodCallexp = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), _constExp);
            Expression<Action> consoleLambdaExp = Expression.Lambda<Action>(_methodCallexp);
            consoleLambdaExp.Compile()();
            Console.ReadLine();
        }

        public static void Print2()
        {
            ParameterExpression _parameExp = Expression.Parameter(typeof(string), "MyParameter");
            MethodCallExpression _methodCallexp = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), _parameExp);
            Expression<Action<string>> consoleLambdaExp = Expression.Lambda<Action<string>>(_methodCallexp,_parameExp);
            consoleLambdaExp.Compile()("Hello!");
            Console.ReadLine();
        }
    }
}

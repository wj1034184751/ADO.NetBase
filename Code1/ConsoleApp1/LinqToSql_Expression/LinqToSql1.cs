
using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql_Expression
{
    public static class Exp
    {
        public static string TransferExpressionType(this ExpressionType expressionType)
        {
            string type = string.Empty;
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    type = "="; break;
                case ExpressionType.GreaterThanOrEqual:
                    type = ">="; break;
                case ExpressionType.LessThanOrEqual:
                    type = "<="; break;
                case ExpressionType.NotEqual:
                    type = "!="; break;
                case ExpressionType.AndAlso:
                    type = "And"; break;
                case ExpressionType.OrElse:
                    type = "Or"; break;
            }
            return type;
        }
    }

    public class LinqToSql1
    {
        public string LinqToSqlFuncTest()
        {
            Func<Users, bool> funcUser = u => u.Name == "SkyChen";
            Expression<Func<Users, bool>> expressionUser = u => u.Name == "SkyChen" && u.Age >= 20;
            ExpressionTypeHelper ex = new ExpressionTypeHelper();
            ex.ResolveExpression(expressionUser);
            return ex.Where;
            return ResoleExpression(expressionUser);
        }

        public static string ResoleExpression(Expression<Func<Users,bool>>expression)
        {
            var bodyNode = (BinaryExpression)expression.Body;
            var leftNode = (MemberExpression)bodyNode.Left;
            var rightNode = (ConstantExpression)bodyNode.Right;
           
            return $"{leftNode.Member.Name},{rightNode.Value},{bodyNode.NodeType.TransferExpressionType()}";
        }
        
        public static void Printf()
        {
            //LinqToSql1 linq1 = new LinqToSql1();
            //Console.WriteLine(linq1.LinqToSqlFuncTest());

            //var func = ExpressionTypeHelper.GenerateExpression(new Users());
            //List<Users> list = new List<Users>();
            //list.Add(new Users() { Name = "wj", Phone = "18968047524", Sex = 1, Age = 20 });
            //list.Add(new Users() { Name = "wc", Phone = "18968047524", Sex = 1, Age = 21 });
            //list.Add(new Users() { Name = "wy", Phone = "18968047345", Sex = 1, Age = 22 });
            //list.Add(new Users() { Name = "wG", Phone = "189680474354", Sex = 0, Age = 23 });
            //list.Add(new Users() { Name = "wgg", Phone = "1896832324", Sex = 0, Age = 24 });

            //var ii = list.Where(func).ToList();

            //ExpressionTypeHelper.MyParameterExpression();

            //ExpressionTest.ExpressionTest_Equals();
            //ExpressionTest.ExpressionTest_EqualsAnd();
            //ExpressionTest.ExpressionVisitorTest();
            ExpressionTest.ExpressionSelectSetValue();
            
        }
    }
}

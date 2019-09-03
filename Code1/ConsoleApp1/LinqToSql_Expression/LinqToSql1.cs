
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
            LinqToSql1 linq1 = new LinqToSql1();
            Console.WriteLine(linq1.LinqToSqlFuncTest());
        }
    }
}

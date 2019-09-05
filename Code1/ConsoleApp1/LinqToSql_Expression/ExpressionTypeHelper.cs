using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql_Expression
{
    public class ExpressionTypeHelper
    {
        public StringBuilder GeWhere = new StringBuilder();

        public string Where
        {
            get
            {
                return GeWhere.ToString();
            }
        }

        public void ResolveExpression(Expression<Func<Users,bool>> expression)
        {
            Visit(expression.Body);
        }

        public void Visit(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    VisitConstantExpression(expression);
                    break;
                case ExpressionType.MemberAccess:
                    VisitMemberExpression(expression);
                    break;
                case ExpressionType.Convert:
                    VisitUnaryExpression(expression);
                    break;
                default:
                    VisitBinaryExpression(expression);
                    break;
            }
        }

        public void VisitUnaryExpression(Expression expression)
        {
            var e = (UnaryExpression)expression;
            Visit(e.Operand);
        }

        public void VisitBinaryExpression(Expression expression)
        {
            var e = (BinaryExpression)expression;
            GeWhere.Append("{");
            Visit(e.Left);

            GeWhere.Append(e.NodeType.TransferExpressionType());

            Visit(e.Right);
            GeWhere.Append("}");
        }

        public void VisitConstantExpression(Expression expression)
        {
            var e = (ConstantExpression)expression;

            if (e.Type == typeof(string))
                GeWhere.Append("'" + e.Value + "'");
            else
                GeWhere.Append(e.Value);
        }

        public void VisitMemberExpression(Expression expression)
        {
            var e = (MemberExpression)expression;
            GeWhere.Append(e.Member.Name);
        }

        public static Func<T,bool> GenerateExpression<T>(T searchModel) where T:class ,new ()
        {
            List<MethodCallExpression> mcList = new List<MethodCallExpression>();
            Type type = searchModel.GetType();
            ParameterExpression parameterExpression = Expression.Parameter(type, "x");
            var pros = type.GetProperties();
            foreach(var t in pros)
            {
                var objValue = t.GetValue(searchModel, null);
                if(objValue!=null)
                {
                    Expression proerty = Expression.Property(parameterExpression, t);
                    ConstantExpression constantExpression = Expression.Constant(objValue, t.PropertyType);
                    var t_type = t.PropertyType.Name;
                    switch (t_type)
                    {
                        case "Int32":
                            mcList.Add(Expression.Call(proerty, typeof(Int32).GetMethod("Contains"), new Expression[] { constantExpression }));
                            break;
                        case "String":
                            mcList.Add(Expression.Call(proerty, typeof(string).GetMethod("Contains"), new Expression[] { constantExpression }));
                            break;
                    }

                  
                }
            }

            if(mcList.Count==0)
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Constant(true, typeof(bool)), new ParameterExpression[] { parameterExpression }).Compile();
            }
            else
            {
                return Expression.Lambda<Func<T, bool>>(MethodCall(mcList), new ParameterExpression[] { parameterExpression }).Compile();
            }
        }

        public static Expression MethodCall<T>(List<T>mcList) where T:MethodCallExpression
        {
            if (mcList.Count == 1) return mcList[0];
            BinaryExpression binaryExpression = null;
            for(int i=0;i<mcList.Count;i+=2)
            {
                if(i<mcList.Count-1)
                {
                    BinaryExpression binary = Expression.OrElse(mcList[i], mcList[i + 1]);
                    if (binaryExpression != null)
                        binaryExpression = Expression.OrElse(binaryExpression, binary);
                    else
                        binaryExpression = binary;
                }
            }
            if (mcList.Count % 2 != 0)
                return Expression.OrElse(binaryExpression, mcList[mcList.Count - 1]);
            else
                return binaryExpression;
        }

        public static void MyConstantExpression(object value)
        {
            var value_type = value.GetType().Name;
            ConstantExpression constExp = Expression.Constant(value, typeof(string));
        }

        delegate int del(int i);
        public static void MyParameterExpression()
        {
            ParameterExpression a = Expression.Parameter(typeof(int), "i");
            ParameterExpression b = Expression.Parameter(typeof(int), "j");
            BinaryExpression r1 = Expression.Multiply(a, b);

            ParameterExpression c = Expression.Parameter(typeof(int), "w");
            ParameterExpression d = Expression.Parameter(typeof(int), "x");
            BinaryExpression r2 = Expression.Multiply(c, d);

            BinaryExpression result = Expression.Add(r1, r2);
            Expression<Func<int, int, int, int, int>> lambda = Expression.Lambda<Func<int, int, int, int, int>>(result,a, b, c, d);
            Expression<Func<int, int, int, int, int>> lambda2 = (x1, x2, x3, x4) => x3;
            Console.WriteLine(lambda2 + "");
            Console.WriteLine(lambda2.Compile()(4, 2, 5, 6));
            Func<int, int, int, int, int> f = lambda.Compile();

            Console.WriteLine(f(1, 1, 1, 1) + "");
        }
    }
}

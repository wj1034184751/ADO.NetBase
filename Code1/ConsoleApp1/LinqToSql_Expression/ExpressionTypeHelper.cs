using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

    }
}

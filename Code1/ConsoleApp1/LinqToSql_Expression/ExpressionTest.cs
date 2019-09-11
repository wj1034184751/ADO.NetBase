using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql_Expression
{
    public class ExpressionTest
    {
        public static void ExpressionTest_Equals()
        {
            Expression<Func<Users, bool>> func = x => x.Name.Equals("w");
            Users u = new Users() { Name = "wj", Age = 15 };
            var result = func.Compile()(u);


            ParameterExpression parameterExpression = Expression.Parameter(typeof(Users), "x");
            var field = Expression.PropertyOrField(parameterExpression,typeof(Users).GetProperty("Name").Name);
            var toString = typeof(Users).GetMethod("ToString");
            var toStringCall = Expression.Call(field, toString, new Expression[0]);
            var equals = typeof(Users).GetMethod("Equals");
            var constant = Expression.Constant("wj", typeof(string));
            var equalsCall = Expression.Call(toStringCall, equals, new Expression[] { constant });
            
            Expression<Func<Users, bool>> expression = Expression.Lambda<Func<Users, bool>>(equalsCall, new ParameterExpression[]
                {
                    parameterExpression
                });
            var isTrue = expression.Compile().Invoke(new Users()
            {
                Name = "wj",
                Age = 12
            });
        }

        public static void ExpressionTest_EqualsAnd()
        {
            Expression<Func<Users, bool>> func = x => x.Name.Equals("w") && x.Age > 12;
            Users u = new Users() { Name = "wj", Age = 15 };
            var result = ((BinaryExpression)func.Body).Right;


            ParameterExpression parameterExpression = Expression.Parameter(typeof(Users), "x");
            var leftfield = Expression.PropertyOrField(parameterExpression, typeof(Users).GetProperty("Name").Name);
            var leftfieldToString = typeof(Users).GetMethod("ToString");
            var leftToStringCall = Expression.Call(leftfield, leftfieldToString, new Expression[0]);
            var leftEquals = typeof(Users).GetMethod("Equals");
            var leftConstant = Expression.Constant("wj", typeof(string));
            var equalsCall = Expression.Call(leftToStringCall, leftEquals, new Expression[] { leftConstant });

            var rightfield = Expression.PropertyOrField(parameterExpression, typeof(Users).GetProperty("Age").Name);
            var rightConstant = Expression.Constant(12, typeof(int));
            var rightFieldLeft = Expression.Convert(rightfield, typeof(int));
            var greaterThan = Expression.GreaterThan(rightFieldLeft, rightConstant);

            var andCall = Expression.AndAlso(equalsCall, greaterThan);


            Expression<Func<Users, bool>> expression = Expression.Lambda<Func<Users, bool>>(andCall, new ParameterExpression[]
                {
                    parameterExpression
                });
            var body = expression.Body;
            var isTrue = expression.Compile().Invoke(new Users()
            {
                Name = "wj",
                Age = 15
            });

            Users model = new Users()
            {
                Name = "wjcc",
                Age = 156
            };

            var reuslt = ExpressionGenericMapper<Users, Admin>(model);
        }

        public static T2 ExpressionGenericMapper<T1,T2>(T1 t)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T1), "x");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach(var item in typeof(T2).GetProperties())
            {
                MemberExpression property = Expression.Property(parameterExpression, typeof(T1).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            foreach(var item in typeof(T2).GetFields())
            {
                MemberExpression property = Expression.Field(parameterExpression, typeof(T1).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(T2)), memberBindingList.ToArray());
            Expression<Func<T1, T2>> lambda = Expression.Lambda<Func<T1, T2>>(memberInitExpression, new ParameterExpression[]
            {
                parameterExpression
            });
            return lambda.Compile()(t);
        }
        public static void ExpressionVisitorTest()
        {
            Expression<Func<int, int, int>> oexpression = (m, n) => m * n + 2;

            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
            ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");
            BinaryExpression multipayBinaryExpression = Expression.Multiply(parameterExpression, parameterExpression2);

            ConstantExpression constantExpression = Expression.Constant(2, typeof(int));

            BinaryExpression addBinaryExpression = Expression.Add(multipayBinaryExpression, constantExpression);

            ParameterExpression[] parameters = new ParameterExpression[]
            {
                parameterExpression,
                parameterExpression2
            };

            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(addBinaryExpression, parameters);

            var resultStr = expression.Body;
        }

        public static void ExpressionSelectSetValue()
        {
            Users users = new Users()
            {
                Age = 26,
                Name = "wj",
                Phone = "18968047524",
            };

            Expression<Func<Users, Admin>> expression = s => new Admin() { Age = s.Age, Name = s.Name, Phone = s.Phone };
            ParameterExpression paramterExpression = Expression.Parameter(typeof(Users), "s");

            //MethodInfo methodInfo = typeof(Admin).GetProperty("Age").GetMethod;
            List<MemberAssignment> memberAssignmentList = new List<MemberAssignment>();
            //MemberAssignment ageMemberAssignment = Expression.Bind
            //    (
            //    typeof(Admin).GetProperty("Age").SetMethod, Expression.Property(paramterExpression, typeof(Admin).GetProperty("Age").GetMethod)
            //    );
            foreach (var item in typeof(Admin).GetProperties())
            {
                MemberAssignment memberAssignment = Expression.Bind(item.SetMethod, Expression.Property(paramterExpression, typeof(Users).GetProperty(item.Name).SetMethod));
                memberAssignmentList.Add(memberAssignment);
            }

            Expression<Func<Users, Admin>> _expression = Expression.Lambda<Func<Users, Admin>>
                (
                    Expression.MemberInit(Expression.New(typeof(Admin)), memberAssignmentList.ToArray()),
                    new ParameterExpression[] { paramterExpression }
                );
            var body = _expression.Body.ToString();
            Admin admin = _expression.Compile()(users);
        }
    }
}

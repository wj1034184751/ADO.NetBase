using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Extensions
    {
        #region 枚举
        /// <summary>
        /// 从枚举中获取Description
        /// </summary>
        /// <param name="enumName">需要获取枚举描述的枚举</param>
        /// <returns>描述内容</returns>
        public static string GetDescription(this Enum enumName)
        {
            string _description = string.Empty;
            FieldInfo _fieldInfo = enumName.GetType().GetField(enumName.ToString());
            DescriptionAttribute[] _attributes = _fieldInfo.GetDescriptAttr();
            if (_attributes != null && _attributes.Length > 0)
                _description = _attributes[0].Description;
            else
                _description = enumName.ToString();
            return _description;
        }
        /// <summary>
		/// 获取字段Description
		/// </summary>
		/// <param name="fieldInfo">FieldInfo</param>
		/// <returns>DescriptionAttribute[] </returns>
		private static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo)
        {
            if (fieldInfo != null)
            {
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return null;
        }
        #endregion
    }
    public enum PrintEnum
    {
        [Description("Main")]
        main,
        [Description("Program")]
        program,
        [Description("Other")]
        other
    }

    public class UitHelper
    {
        static int CurrentInt = 0;
        public static void PrintF(PrintEnum type,string name)
        {
            CurrentInt++;
            var typename = type.GetDescription();
            Console.WriteLine($"{typename} : Task {name} is running on a thread id {Thread.CurrentThread.ManagedThreadId}. is thread pool thread:{Thread.CurrentThread.IsThreadPoolThread} . This Current Count:{CurrentInt}");
        }
    }
}

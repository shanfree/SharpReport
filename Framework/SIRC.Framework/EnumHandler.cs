using System;
using System.Collections.Generic;
using System.Text;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class EnumHandler<T>
    {
        /// <summary>
        /// 从数字转化为枚举
        /// </summary>
        /// <param name="intString"></param>
        /// <returns></returns>
        public static T GetEnumFromIntString(string intString)
        {
            T _object = (T)Enum.Parse(typeof(T), intString);    
            return _object;
        }

        /// <summary>
        /// 根据枚举获取数字
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetStringFromEnum(T t)
        {
            string strEnum = Enum.Format(typeof(T), t, "d");
            return strEnum;
        }
        /// <summary>
        /// 获取枚举集合
        /// </summary>
        /// <returns></returns>
        public static string[] GetListFromEnumType()
        {
            string[] names = Enum.GetNames(typeof(T));
            return names;
        }

        /// <summary>
        /// 从数字转化为枚举
        /// </summary>
        /// <param name=" t"></param>
        /// <returns></returns>
        public static int GetIntFromEnum(T t)
        {
            string strEnum = Enum.Format(typeof(T), t, "d");
            return int.Parse(strEnum);
        }

    }
}

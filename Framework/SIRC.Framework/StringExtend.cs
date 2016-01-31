/********************************************************************************************
 * 文件名称:	StringExtend.cs
 * 设计人员:	严向晖（yanxianghui@gmail.com）
 * 设计时间:	2007-11-23
 * 功能描述:	
 * 注意事项:	
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *				
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 字符串的验证
    /// </summary>
    public class StringExtend
    {
        #region 转化
        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转为首字母小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToCamel(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToPascal(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return s[0].ToString().ToUpper() + s.Substring(1);
        }

        #endregion

        #region 验证
        /// <summary>
        /// 验证字符串是否正则规范
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsMatch(string s, string pattern)
        {
            if (s == null) return false;
            else return Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// 是否为整型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        /// <summary>
        /// 是否为日期
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDateTime(string s)
        {
            DateTime i = DateTime.MinValue;
            return DateTime.TryParse(s, out i);
        }

        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDecimal(string s)
        {
            Decimal i = Decimal.One;
            return Decimal.TryParse(s, out i);
        }
        #endregion

        #region 运算
        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="factor1"></param>
        /// <param name="factor2"></param>
        /// <returns></returns>
        public static string Time(string factor1, string factor2)
        {
            decimal dFactor1 = Convert.ToDecimal(factor1);
            decimal dFactor2 = Convert.ToDecimal(factor2);
            decimal result = dFactor1 * dFactor2;
            return result.ToString();
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="factor1"></param>
        /// <param name="factor2"></param>
        /// <returns></returns>
        public static string Add(string factor1, string factor2)
        {
            decimal dFactor1 = Convert.ToDecimal(factor1);
            decimal dFactor2 = Convert.ToDecimal(factor2);
            decimal result = dFactor1 + dFactor2;
            return result.ToString();
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="factor1"></param>
        /// <param name="factor2"></param>
        /// <returns></returns>
        public static string Divide(string factor1, string factor2)
        {
            decimal dFactor1 = Convert.ToDecimal(factor1);
            decimal dFactor2 = Convert.ToDecimal(factor2);
            decimal result = dFactor1 / dFactor2;
            return result.ToString();
        }

        #endregion
    }
}

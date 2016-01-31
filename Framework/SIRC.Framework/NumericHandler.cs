using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NumericHandler
    {
        /// <summary>
        /// 向上取整
        /// </summary>
        /// <param name="oper1">操作数一</param>
        /// <param name="oper2">操作数二</param>
        /// <returns>int</returns>
        public static int GetIntToUp(int oper1, int oper2)
        {
            double t = Math.Ceiling((double)oper1 / (double)oper2);
            int pageCount = Convert.ToInt32(t);
            return pageCount;
        }
        /// <summary>
        /// 字符串转化为数字相加
        /// </summary>
        /// <param name="oper1"></param>
        /// <param name="oper2"></param>
        /// <returns></returns>
        public static string StringAdd(string oper1, string oper2)
        {
            if (string.IsNullOrEmpty(oper1))
            {
                oper1 = "0";
            }
            if (string.IsNullOrEmpty(oper2))
            {
                oper2 = "0";
            }
            decimal d = Convert.ToDecimal(oper1) + Convert.ToDecimal(oper2);
            return d.ToString();
        }
        /// <summary>
        /// 字符串数字比较大小
        /// </summary>
        /// <param name="oper1">字符串1</param>
        /// <param name="oper2">字符串2</param>
        /// <returns>1：操作数1大于操作数2，0：相等，-1：小于，-2：错误</returns>
        public static int StringCompare(string oper1, string oper2)
        {
            try
            {
                decimal a = Convert.ToDecimal(oper1);
                decimal b = Convert.ToDecimal(oper2);
                if (a > b)
                {
                    return 1;
                }
                else if (a == b)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 转换数字到中文字符，如100->一百
        /// </summary>
        /// <param name="number">一万亿以下数字</param>
        /// <returns></returns>
        public static string TranslateNumericToChar(string number)
        {
            // 只能输入0和非0开头的数字
            string numRegExpress = @"^(0|[1-9][0-9]{0,11})$";
            Match match = Regex.Match(number, numRegExpress);
            if (!match.Success)
            {
                throw new ArgumentException("只能输入0和一万亿以下非0开头的数字");
            }
            //数字 数组 
            string[] Nums = new string[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            //位 数组 
            string[] Digits = new string[] { "", "十", "百", "千" };
            //单位 数组 
            string[] Units = new string[] { "", "万", "亿" };

            string resChar = ""; //返回值 
            int p = 0; //字符位置指针 
            int m = number.Length % 4; //取模 

            // 四位一组得到组数 
            int k = (m > 0 ? number.Length / 4 + 1 : number.Length / 4);

            // 外层循环在所有组中循环 
            // 从左到右 高位到低位 四位一组 逐组处理 
            // 每组最后加上一个单位: "[万亿]","[亿]","[万]" 
            for (int i = k; i > 0; i--)
            {
                int L = 4;
                if (i == k && m != 0)
                {
                    L = m;
                }
                // 得到一组四位数 最高位组有可能不足四位 
                string s = number.Substring(p, L);
                int l = s.Length;

                // 内层循环在该组中的每一位数上循环 从左到右 高位到低位 
                for (int j = 0; j < l; j++)
                {
                    //处理改组中的每一位数加上所在位: "仟","佰","拾",""(个) 
                    int n = Convert.ToInt32(s.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < l - 1
                            && Convert.ToInt32(s.Substring(j + 1, 1)) > 0 //后一位(右低) 
                            && !resChar.EndsWith(Nums[n]))
                        {
                            resChar += Nums[n];
                        }
                        if (s.Length == 1)
                        {
                            resChar += Nums[n];
                        }
                    }
                    else
                    {
                        //处理 1013 一千零"十三", 1113 一千一百"一十三" 
                        if (!(n == 1 && (resChar.EndsWith(Nums[0]) | resChar.Length == 0) && j == l - 2))
                        {
                            resChar += Nums[n];
                        }
                        resChar += Digits[l - j - 1];
                    }
                }
                p += L;
                // 每组最后加上一个单位: [万],[亿] 等 
                if (i < k) //不是最高位的一组 
                {
                    if (Convert.ToInt32(s) != 0)
                    {
                        //如果所有 4 位不全是 0 则加上单位 [万],[亿] 等 
                        resChar += Units[i - 1];
                    }
                }
                else
                {
                    //处理最高位的一组,最后必须加上单位 
                    resChar += Units[i - 1];
                }
            }
            return resChar;
        }

    }
}

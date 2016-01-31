/********************************************************************************************
 * 文件名称:	DataTableHandler.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 中国大陆身份证验证（15，18位）
    /// </summary>
    public class IdCardCheck
    {
        #region prop
        //位权值数组
        private static byte[] Weight = new byte[17];
        //身份证行政区划代码部分长度
        private static byte fPart = 6;
        //算法求模关键参数
        private static byte fMode = 11;
        //旧身份证长度
        private static byte oIdLen = 15;
        //新身份证长度
        private static byte nIdLen = 18;
        //新身份证年份标记值
        private static string yearFlag = "19";
        //校验字符串
        private static string checkCode = "10X98765432";
        ////最小行政区划分代码
        //private static int minCode = 110000;
        ////最大行政区划分代码
        //private static int maxCode = 820000;
        private static Random rand = new Random();
        #endregion

        #region 私有方法
        /// <summary>
        /// 计算位权值数组
        /// </summary>
        private static void SetWBuffer()
        {
            for (int i = 0; i < Weight.Length; i++)
            {
                int k = (int)Math.Pow(2, (Weight.Length - i));
                Weight[i] = (byte)(k % fMode);
            }
        }

        /// <summary>
        /// 获取新身份证最后一位校验位
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns></returns>
        private static string GetCheckCode(string idCard)
        {
            int sum = 0;
            //进行加权求和计算
            for (int i = 0; i < Weight.Length; i++)
            {
                sum += int.Parse(idCard.Substring(i, 1)) * Weight[i];
            }
            //求模运算得到模值
            byte mode = (byte)(sum % fMode);
            return checkCode.Substring(mode, 1);
        }

        /// <summary>
        /// 检查身份证长度是否合法
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns></returns>
        private static bool CheckLen(string idCard)
        {
            if (idCard.Length == oIdLen || idCard.Length == nIdLen)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证是否是新身份证
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns></returns>
        private static bool IsNew(string idCard)
        {
            if (idCard.Length == nIdLen)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取时间串
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        /// <returns></returns>
        private static string GetDate(string idCard)
        {
            string str = "";
            if (IsNew(idCard))
            {
                str = idCard.Substring(fPart, 8);
            }
            else
            {
                str = yearFlag + idCard.Substring(fPart, 6);
            }
            return str;
        }

        /// <summary>
        /// 检查时间是否合法
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        private static bool CheckDate(string idCard)
        {
            //日期是否符合格式
            bool flag = false;
            string strDate = GetDate(idCard);
            DateTime result = DateTime.Now;
            string format = "yyyyMMdd";
            flag = DateTime.TryParseExact(strDate, format, CultureInfo.InvariantCulture,
    DateTimeStyles.None, out result);
            return flag;
        }

        /// <summary>
        /// 根据年份和月份检查天是否合法
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="day">天</param>
        /// <returns></returns>
        private static bool CheckDay(int year, int month, int day)
        {
            //是否是闰年
            bool rYearFlag = false;
            //天是否合法
            bool rDayFlag = false;
            if (((year % 4 == 0) && (year % 3200 != 0)) || (year % 400 == 0))
            {
                rYearFlag = true;
            }

            #region 检查天是否合法
            if (month == 2)
            {
                if (rYearFlag)
                {
                    if (day > 0 && day <= 29)
                    {
                        rDayFlag = true;
                    }
                }
                else
                {
                    if (day > 0 && day <= 28)
                    {
                        rDayFlag = true;
                    }
                }
            }
            else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day > 0 && day <= 31)
                {
                    rDayFlag = true;
                }
            }
            else
            {
                if (day > 0 && day <= 30)
                {
                    rDayFlag = true;
                }
            }
            #endregion

            return rDayFlag;
        }
        /// <summary>
        /// 旧身份证号码转换成新身份证号码
        /// </summary>
        /// <param name="oldIdCard">旧身份证号码</param>
        /// <returns>新身份证号码</returns>
        private static string GetNewIdCard(string oldIdCard)
        {
            if (oldIdCard.Length == 15)
            {
                string newIdCard = oldIdCard.Substring(0, fPart);
                newIdCard += yearFlag;
                newIdCard += oldIdCard.Substring(fPart, 9);
                newIdCard += GetCheckCode(newIdCard);
                return newIdCard;
            }
            return string.Empty;
        }

        /// <summary>
        /// 新身份证号码转换成旧身份证号码
        /// </summary>
        /// <param name="newIdCard">新身份证号码</param>
        /// <returns>旧身份证号码</returns>
        private static string GetOldIdCard(string newIdCard)
        {
            if (newIdCard.Length == 18)
            {
                string oldIdCard = newIdCard.Substring(0, fPart);
                oldIdCard += newIdCard.Substring(8, 9);
                return oldIdCard;
            }
            return string.Empty;
        }

        #endregion

        /// <summary>
        /// 检查身份证是否合法
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool CheckCard(string idCard, out string msg)
        {
            //身份证是否合法标志
            bool flag = false;
            msg = string.Empty;
            SetWBuffer();
            if (!CheckLen(idCard))
            {
                msg = "身份证长度不符合要求";
                flag = false;
            }
            else
            {
                if (!CheckDate(idCard))
                {
                    msg = "身份证日期不符合要求";
                    flag = false;
                }
                else
                {
                    if (!IsNew(idCard))
                    {
                        idCard = GetNewIdCard(idCard);
                    }
                    string checkCode = GetCheckCode(idCard);
                    string lastCode = idCard.Substring(idCard.Length - 1, 1);
                    if (checkCode == lastCode)
                    {
                        flag = true;
                    }
                    else
                    {
                        msg = "身份证验证错误";
                        flag = false;
                    }
                }
            }
            return flag;
        }

    }
}

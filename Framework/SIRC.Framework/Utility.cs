using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// Summary description for Utility
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// 输出文本文件
        /// </summary>
        /// <param name="path"></param>
        public static void ResponseFile(string path)
        {
            HttpContext.Current.Response.Clear();

            System.IO.Stream iStream = null;
            byte[] buffer = new Byte[10000];
            int length;
            long dataToRead;
            string filename = System.IO.Path.GetFileName(path);

            try
            {
                iStream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                dataToRead = iStream.Length;

                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.ContentType = "application/octet-msword";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename= " + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
                HttpContext.Current.Response.AddHeader("Content-Length", dataToRead.ToString());

                while (dataToRead > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 10000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("文件下载时出现错误!" + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
            }
        }


        /// <summary>
        /// 判断是否为日期型
        /// </summary>
        /// <param name="datetime">日期</param>
        /// <param name="mess">输出的错误信息</param>
        public static void IsDateTime(string datetime, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(datetime) == false)
            {
                if (!Regex.IsMatch(datetime.Trim(), @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[469]|11)-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)[13579][26])-0?2-29)|(((1[6-9]|[2-9]\d)[2468][048])-0?2-29)|(((1[6-9]|[2-9]\d)0[48])-0?2-29)|(([13579]6)00-0?2-29)|(([2468][048])00-0?2-29)|(([3579]2)00-0?2-29))$"))
                {
                    message = "时间输入格式错误,请重新输入!如2008-01-10";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// 判断输入是否为数值
        /// </summary>
        /// <param name="numstring">输入的字符</param>
        /// <param name="mess">输出的错误信息</param>
        public static void IsNum(string numstring, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(numstring) == false)
            {
                if (!Regex.IsMatch(numstring.Trim(), @"^[+-]?\d*[.]?\d*$"))
                {
                    message = "输入的字符不为数值,请重新输入!";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// 判断输入是否为正整数
        /// </summary>
        /// <param name="numstring">输入的字符</param>
        /// <param name="mess">输出的错误信息</param>
        public static void IsInt(string numstring, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(numstring) == false)
            {
                if (!Regex.IsMatch(numstring.Trim(), @"^((\+)\d)?\d*$"))
                {
                    message = "输入的字符不为正整数,请重新输入!";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// 判断输入是否为数字或是小数(正浮点数 + 0)
        /// </summary>
        /// <param name="numstring">输入的字符</param>
        /// <param name="mess">输出的错误信息</param>
        public static void IsFloat(string numstring, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(numstring) == false)
            {
                if (!Regex.IsMatch(numstring.Trim(), @"^\d+(\.\d+)?$"))
                {
                    message = "输入的字符不为数字或是小数,请重新输入!";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// 时间类型转换
        /// </summary>
        /// <param name="dt">时间类型</param>
        /// <returns>string</returns>
        public static string GetDateTime(DateTime dt)
        {
            string strDT = "";
            if (dt == null)
            {
                return strDT;
            }
            if (dt.Date != DateTime.MaxValue.Date && dt.Date != DateTime.MinValue.Date)
            {
                strDT = dt.ToString("yyyy-MM-dd");
            }
            return strDT;
        }

        /// <summary>
        /// 时间类型转换
        /// </summary>
        /// <param name="dt">时间类型</param>
        /// <returns>string</returns>
        public static string GetDateTime(string dt)
        {
            string strDT = "";
            if (String.IsNullOrEmpty(dt) == false)
            {
                DateTime time = Convert.ToDateTime(dt);
                if (time.Date != DateTime.MaxValue.Date && time.Date != DateTime.MinValue.Date)
                {
                    strDT = time.ToString("yyyy-MM-dd");
                }
            }

            return strDT;
        }
    }
}
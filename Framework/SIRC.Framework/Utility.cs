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
        /// ����ı��ļ�
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
                HttpContext.Current.Response.Write("�ļ�����ʱ���ִ���!" + ex.Message);
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
        /// �ж��Ƿ�Ϊ������
        /// </summary>
        /// <param name="datetime">����</param>
        /// <param name="mess">����Ĵ�����Ϣ</param>
        public static void IsDateTime(string datetime, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(datetime) == false)
            {
                if (!Regex.IsMatch(datetime.Trim(), @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[469]|11)-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)[13579][26])-0?2-29)|(((1[6-9]|[2-9]\d)[2468][048])-0?2-29)|(((1[6-9]|[2-9]\d)0[48])-0?2-29)|(([13579]6)00-0?2-29)|(([2468][048])00-0?2-29)|(([3579]2)00-0?2-29))$"))
                {
                    message = "ʱ�������ʽ����,����������!��2008-01-10";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// �ж������Ƿ�Ϊ��ֵ
        /// </summary>
        /// <param name="numstring">������ַ�</param>
        /// <param name="mess">����Ĵ�����Ϣ</param>
        public static void IsNum(string numstring, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(numstring) == false)
            {
                if (!Regex.IsMatch(numstring.Trim(), @"^[+-]?\d*[.]?\d*$"))
                {
                    message = "������ַ���Ϊ��ֵ,����������!";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// �ж������Ƿ�Ϊ������
        /// </summary>
        /// <param name="numstring">������ַ�</param>
        /// <param name="mess">����Ĵ�����Ϣ</param>
        public static void IsInt(string numstring, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(numstring) == false)
            {
                if (!Regex.IsMatch(numstring.Trim(), @"^((\+)\d)?\d*$"))
                {
                    message = "������ַ���Ϊ������,����������!";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// �ж������Ƿ�Ϊ���ֻ���С��(�������� + 0)
        /// </summary>
        /// <param name="numstring">������ַ�</param>
        /// <param name="mess">����Ĵ�����Ϣ</param>
        public static void IsFloat(string numstring, string mess)
        {
            string message = String.Empty;
            if (String.IsNullOrEmpty(numstring) == false)
            {
                if (!Regex.IsMatch(numstring.Trim(), @"^\d+(\.\d+)?$"))
                {
                    message = "������ַ���Ϊ���ֻ���С��,����������!";
                    if (String.IsNullOrEmpty(mess) == false)
                    {
                        message = mess;
                    }
                    throw new ArithmeticException(message);
                }
            }
        }

        /// <summary>
        /// ʱ������ת��
        /// </summary>
        /// <param name="dt">ʱ������</param>
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
        /// ʱ������ת��
        /// </summary>
        /// <param name="dt">ʱ������</param>
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SerializeHandler<T>
    {
        /// <summary>
        /// 序列化对象实例到字节流
        /// </summary>
        /// <param name="instance">对象实例</param>
        /// <returns></returns>
        public static string SerializeToBase64(T instance)
        {
            MemoryStream memStream = null;
            try
            {
                BinaryFormatter serializer = new BinaryFormatter();
                byte[] bArray = null;
                memStream = new MemoryStream();
                serializer.Serialize(memStream, instance);
                bArray = memStream.ToArray();
                string base64String = Convert.ToBase64String(bArray);
                return base64String;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (memStream != null)
                    memStream.Close();
            }
        }
        /// <summary>
        /// xml序列化
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string SerializeToXmlString(T instance)
        {
            string serialString = "";
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream memS = new MemoryStream();
            TextWriter writer = new StreamWriter(memS, new UTF8Encoding());
            try
            {
                serializer.Serialize(writer, instance);
                serialString = new UTF8Encoding().GetString(memS.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                memS.Close();
                writer.Close();
            }
            return serialString;
        }

        /// <summary>
        /// xml序列化至本地路径
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="filePath">本地文件的完整路径，如c:\temp\mine.xml</param>
        public static void SerializeToFilePath(T instance,string filePath)
        {
            XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8);
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            try
            {
                mySerializer.Serialize(writer, instance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
            }
        }


        /// <summary>
        /// 对象初始化，指定字符串进行读取，创建相应的实体对象
        /// </summary>
        /// <example>
        /// <code>
        /// User uData = InitByString(typeof(User), userStr) as User;
        /// </code>
        /// </example>
        /// <param name="objStr">用于初始化的字符串</param>
        /// <returns>Object 对象</returns>
        public static T InitByString(string objStr)
        {
            //TODO:replace xmlns --yanxh
            //string str = " xmlns=\"http://schemas.microsoft.com/office/infopath/2003/myXSD/2007-12-12T01:03:51\"";
            //objStr = objStr.Replace(str, "");
            XmlSerializer xmlserial = new XmlSerializer(typeof(T));
            TextReader tReader = new StringReader(objStr);
            try
            {
                return (T)xmlserial.Deserialize(tReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tReader.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static T DeSerializeFromBase64(string base64String)
        {
            T Instance = default(T);
            BinaryFormatter serializer = null;
            MemoryStream ms = null;

            try
            {
                serializer = new BinaryFormatter();
                byte[] bArray = Convert.FromBase64String(base64String);
                ms = new MemoryStream(bArray);
                Instance = (T)serializer.Deserialize(ms);
                return Instance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ms != null)
                    ms.Close();
            }
        }
        /// <summary>
        /// 从本地文件反序列化实体
        /// </summary>
        /// <param name="filePath">本地文件路径</param>
        /// <returns></returns>
        public static T DeSerializeFromFile(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                string msg = string.Format("文档丢失或在{0}处不可访问.", filePath);
                throw new FileNotFoundException(msg);
            }

            T Instance = default(T);
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                Instance = (T)formatter.Deserialize(fs);
            }
            return Instance;
        }
    }
}

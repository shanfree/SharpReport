/********************************************************************************************
 * 文件名称:	Config.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	配置文件的基本操作
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 配置文件的基本操作
    /// </summary>
    public class Config 
    {
        /// <summary>
        /// 修改AppSettings节点
        /// </summary>
        /// <param name="webConfigDirectory">web.config文件的目录</param>
        /// <param name="appSettingsAddkey">节点名称</param>
        /// <param name="keyvalue">修改后的节点值</param>
        /// <returns>是否成功</returns>
        public static bool AppSettingsEdit(string webConfigDirectory, string appSettingsAddkey, string keyvalue)
        {
            try
            {
                string path = webConfigDirectory;
                XmlDocument xd = new XmlDocument();
                xd.Load(path);

                //如果没有appSetting，则添加  
                if (xd.SelectNodes("//appSettings").Count == 0)
                {
                    xd.DocumentElement.AppendChild(xd.CreateElement("appSettings"));
                }

                //判断节点是否存在，如果存在则修改当前节点  
                bool addNode = true;
                foreach (XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
                {
                    if (xn1.Attributes["key"].Value == appSettingsAddkey)
                    {
                        addNode = false;
                        xn1.Attributes["value"].Value = keyvalue;
                        // xn1.ParentNode.RemoveChild(xn1);  
                        break;
                    }
                }

                //当前节点不存在，则添加新节点  
                if (addNode)
                {
                    //创建新节点  
                    XmlNode xn2 = xd.CreateElement("add");

                    //添加key  
                    XmlAttribute xa = xd.CreateAttribute("key");
                    xa.Value = appSettingsAddkey;
                    xn2.Attributes.Append(xa);

                    //添加value  
                    xa = xd.CreateAttribute("value");
                    xa.Value = keyvalue;
                    xn2.Attributes.Append(xa);
                    xd.SelectSingleNode("/configuration/appSettings").AppendChild(xn2);
                }
                //保存web.config  
                xd.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取AppSettings节点
        /// </summary>
        /// <param name="webConfigDirectory">web.config文件的目录</param>
        /// <param name="appSettingsAddkey">节点名称</param>
        /// <returns>修改后的节点值</returns>
        public static string AppSettingsRead(string webConfigDirectory, string appSettingsAddkey)
        {
            try
            {
                string path = webConfigDirectory;
                XmlDocument xd = new XmlDocument();
                xd.Load(path);

                //如果没有appSetting，则添加  
                if (xd.SelectNodes("//appSettings").Count == 0)
                {
                    xd.DocumentElement.AppendChild(xd.CreateElement("appSettings"));
                }

                foreach (XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
                {
                    if (xn1.Attributes["key"].Value == appSettingsAddkey)
                    {
                        return xn1.Attributes["value"].Value;
                    }
                }

                //当前节点不存在，则添加新节点  
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

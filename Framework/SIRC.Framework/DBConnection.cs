/********************************************************************************************
 * 文件名称:	DBConnection.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	管理员
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
 
namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 数据库连接串管理
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// 数据库链接串
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        /// <summary>
        /// 日志模块数据库链接串
        /// </summary>
        public static readonly string LogConnectionString = ConfigurationManager.AppSettings["LogConnectionString"];
        /// <summary>
        /// 用户和权限模块数据库链接串
        /// </summary>
        public static readonly string MembershipConnectionString = ConfigurationManager.AppSettings["MembershipConnectionString"];

    }
}

/********************************************************************************************
 * 文件名称:	SystemLog.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-12
 * 功能描述:	日志操作类
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class SystemLog
    {
        //private static readonly string path = "SIRC.Framework.Utility";
        //private static readonly string className = "SIRC.Framework.Utility.Log";
        //private static readonly ILog dal = (ILog)Assembly.Load(path).CreateInstance(className);

        private static readonly ILog dal = new Log();
        /// <summary>
        /// 将信息作为严重错误存入日志
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="sourceID">信息源（如栏目ID）</param>
        public void Write(string message, string sourceID)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("日志内容不能为空.");
            }
            dal.Write(message, sourceID);
        }
        /// <summary>
        /// 将信息作为指定类型的数据存入日志
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="sourceID">信息源（如栏目ID）</param>
        /// <param name="logType">信息类型，有错误，一般信息，审核通过，审核失败等<seealso cref="EventLogEntryType"/></param>
        public void Write(string message, EventLogEntryType logType, string sourceID)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("日志内容不能为空.");
            }
            dal.Write(message, logType, sourceID);
        }

        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex)
        {
            if (pageSize < 1 || pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return dal.GetLogInfoList(pageSize, pageIndex);
        }

        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isFullText">是否导出全文</param>
        /// <returns></returns>
        public IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex, bool isFullText)
        {
            if (pageSize < 1 || pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return dal.GetLogInfoList(pageSize, pageIndex, isFullText);
        }

        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="from">日志开始时间</param>
        /// <param name="to">日志结束时间</param>
        /// <param name="sourceID">来源类型ID</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, string sourceID, int pageSize, int pageIndex)
        {
            // sql数据库不支持0001-1-1
            from = (from == DateTime.MinValue) ? DateTime.Today.AddYears(-10) : from;
            to = (to == DateTime.MaxValue) ? DateTime.Today.AddDays(1) : to;
            if (pageSize < 1 || pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return dal.GetLogInfoList(from, to, sourceID, pageSize, pageIndex);
        }
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="from">日志开始时间</param>
        /// <param name="to">日志结束时间</param>
        /// <param name="type">日志类型:信息,警告,错误,验证通过</param>
        /// <param name="sourceID">来源ID</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, EventLogEntryType type, string sourceID, int pageSize, int pageIndex)
        {
            // sql数据库不支持0001-1-1
            from = (from == DateTime.MinValue) ? DateTime.Today.AddYears(-10) : from;
            to = (to == DateTime.MaxValue) ? DateTime.Today.AddDays(1) : to;
            string typeID = EnumHandler<EventLogEntryType>.GetStringFromEnum(type);
            if (pageSize < 1 || pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return dal.GetLogInfoList(from, to, type, sourceID, pageSize, pageIndex);
        }
        /// <summary>
        /// 获取日志条目具体信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>日志条目实体</returns>
        public LogInfo GetLogInfoByID(string id)
        {
            if (id == null || "" == id)
            {
                throw new ArgumentNullException();
            }
            return dal.GetLogInfoByID(id);
        }
    }
}

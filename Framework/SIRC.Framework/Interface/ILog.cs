/********************************************************************************************
 * 文件名称:	ILog.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-12
 * 功能描述:	日志接口
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
using System.Text;
using System.Diagnostics;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        string Write(string message, string sourceID);
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logType"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        string Write(string message, EventLogEntryType logType, string sourceID);
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex);
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isFullText">是否导出全文</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex, bool isFullText);

        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="from">日志开始时间</param>
        /// <param name="to">日志结束时间</param>
        /// <param name="sourceID">来源类型ID</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, string sourceID, int pageSize, int pageIndex);
        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="from">日志开始时间</param>
        /// <param name="to">日志结束时间</param>
        /// <param name="type">日志类型:信息,警告,错误,验证通过</param>
        /// <param name="sourceID"></param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, EventLogEntryType type, string sourceID, int pageSize, int pageIndex);
        /// <summary>
        /// 获取日志条目具体信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>日志条目实体</returns>
        LogInfo GetLogInfoByID(string id);
    }
}

/********************************************************************************************
 * 文件名称:	Log.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-12
 * 功能描述:	日志记录
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 日志访问DAL
    /// </summary>
    public class Log : ILog
    {
        private const string SQL_SELECT = @"SELECT     
                                    ID, 
                                    Time, 
                                    Type, 
                                    SUBSTRING(Message, 0, 70) + '...' AS Message, SourceID
                                    FROM  dbo.[Log]";
        private const string SQL_SELECT_FULLTEXT = @"SELECT  *
                                    FROM  dbo.[Log]";
        #region ILog Members
        /// <summary>
        /// 写入数据库日志
        /// </summary>
        /// <param name="message">写入的信息</param>
        /// <param name="sourceID">日志源</param>
        /// <returns>日志记录主键</returns>
        public string Write(string message, string sourceID)
        {
            return Write(message, EventLogEntryType.Error, sourceID);
        }

        /// <summary>
        /// 写入数据库日志
        /// </summary>
        /// <param name="message">写入的信息</param>
        /// <param name="logType">日志类型,信息,警告,错误,验证通过等</param>
        /// <param name="sourceID">日志源</param>
        /// <returns>日志记录主键</returns>
        public string Write(string message, EventLogEntryType logType, string sourceID)
        {
            string typeID = EnumHandler<EventLogEntryType>.GetStringFromEnum(logType);

            string sql = @"INSERT INTO [Log]
                                           ([Message]
                                           ,[Type]
                                           ,[SourceID])
                                     VALUES
                                           (@Message
                                           ,@Type
                                           ,@SourceID)";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Message", message);
            param[1] = new SqlParameter("@Type", typeID);
            param[2] = new SqlParameter("@SourceID", sourceID);
            string result = Convert.ToString(SqlHelper.ExecuteScalar(DBConnection.LogConnectionString, CommandType.Text, sql, param));
            return result;
        }

        /// <summary>
        /// 获取日志信息
        /// </summary>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public virtual IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex)
        {
            string sql = SQL_SELECT;
            string pageSql = CommonHelper.GetPagedSQL(sql, "ID", true, pageSize, pageIndex);
            SqlDataReader dr = SqlHelper.ExecuteReader(DBConnection.LogConnectionString, CommandType.Text, pageSql);
            IList<LogInfo> list = GetListFromReader(dr);
            // 总页数以自定义列表类型CustomList封装
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, pageSize, list);
            return cList;
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
            if (isFullText == false)
            {
                return GetLogInfoList(pageSize, pageIndex);
            }
            string sql = SQL_SELECT_FULLTEXT;
            string pageSql = CommonHelper.GetPagedSQL(sql, "ID", true, pageSize, pageIndex);
            SqlDataReader dr = SqlHelper.ExecuteReader(DBConnection.LogConnectionString, CommandType.Text, pageSql);
            IList<LogInfo> list = GetListFromReader(dr);
            // 总页数以自定义列表类型CustomList封装
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, pageSize, list);
            return cList;
        }

        private IList<LogInfo> GetListFromReader(SqlDataReader dr)
        {
            IList<LogInfo> list = new List<LogInfo>();
            while (dr.Read())
            {
                LogInfo cInfo = new LogInfo();
                cInfo.ID = dr["ID"].ToString();
                cInfo.Time = (dr["Time"] == null) ? DateTime.Today : DateTime.Parse(dr["Time"].ToString());
                cInfo.TypeID = dr["Type"].ToString();
                cInfo.Message = (dr["Message"] == null) ? null : dr["Message"].ToString();
                cInfo.SourceID = (dr["SourceID"] == null) ? null : dr["Message"].ToString();
                list.Add(cInfo);
            }
            return list;
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
        public virtual IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, string sourceID, int pageSize, int pageIndex)
        {
            string sql = SQL_SELECT + @" WHERE
                                                            [Time] < @To
                                                            and [Time] > @From
                                                            {0}";

            if (string.IsNullOrEmpty(sourceID) == false)
            {
                string sourceClau = string.Format("and [SourceID] = {0}", sourceID);
                sql = string.Format(sql, sourceClau);
            }
            else
            {
                sql = string.Format(sql, "");
            }
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@To", to);
            param[1] = new SqlParameter("@From", from);
            string pageSql = CommonHelper.GetPagedSQL(sql, "ID", true, pageSize, pageIndex);
            SqlDataReader dr = SqlHelper.ExecuteReader(DBConnection.LogConnectionString, CommandType.Text, pageSql, param);
            IList<LogInfo> list = GetListFromReader(dr);
            // 总页数以自定义列表类型CustomList封装
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, param, pageSize, list);
            return cList;
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
        public virtual IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, EventLogEntryType type, string sourceID, int pageSize, int pageIndex)
        {
            string sql = SQL_SELECT + @" WHERE
                                    [Time] < @To
                                    and [Time] > @From
                                    {0}";
            if (string.IsNullOrEmpty(sourceID) == false)
            {
                string sourceClau = string.Format("and [SourceID] = {0}", sourceID);
                sql = string.Format(sql, sourceClau);
            }
            else
            {
                sql = string.Format(sql, "");
            }
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@To", to);
            param[1] = new SqlParameter("@From", from);
            string typeID = EnumHandler<EventLogEntryType>.GetStringFromEnum(type);
            param[2] = new SqlParameter("@TypeID", typeID);
            string pageSql = CommonHelper.GetPagedSQL(sql, "ID", true, pageSize, pageIndex);
            SqlDataReader dr = SqlHelper.ExecuteReader(DBConnection.LogConnectionString, CommandType.Text, pageSql, param);
            IList<LogInfo> list = GetListFromReader(dr);
            // 总页数以自定义列表类型CustomList封装
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, param, pageSize, list);
            return cList;

        }
        /// <summary>
        /// 获取日志条目具体信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>日志条目实体</returns>
        public LogInfo GetLogInfoByID(string id)
        {
            string sql = @"SELECT * FROM  dbo.[Log] where 
                                    [ID] = @ID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            SqlDataReader dr = SqlHelper.ExecuteReader(DBConnection.LogConnectionString, CommandType.Text, sql, param);
            IList<LogInfo> list = GetListFromReader(dr);
            if (null != list && list.Count > 0)
            {
                return list[0];
            }
            return null;
        }
        #endregion
    }
}

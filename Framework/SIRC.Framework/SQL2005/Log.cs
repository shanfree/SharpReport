/********************************************************************************************
 * �ļ�����:	Log.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-12
 * ��������:	��־��¼
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
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
    /// ��־����DAL
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
        /// д�����ݿ���־
        /// </summary>
        /// <param name="message">д�����Ϣ</param>
        /// <param name="sourceID">��־Դ</param>
        /// <returns>��־��¼����</returns>
        public string Write(string message, string sourceID)
        {
            return Write(message, EventLogEntryType.Error, sourceID);
        }

        /// <summary>
        /// д�����ݿ���־
        /// </summary>
        /// <param name="message">д�����Ϣ</param>
        /// <param name="logType">��־����,��Ϣ,����,����,��֤ͨ����</param>
        /// <param name="sourceID">��־Դ</param>
        /// <returns>��־��¼����</returns>
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
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <returns></returns>
        public virtual IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex)
        {
            string sql = SQL_SELECT;
            string pageSql = CommonHelper.GetPagedSQL(sql, "ID", true, pageSize, pageIndex);
            SqlDataReader dr = SqlHelper.ExecuteReader(DBConnection.LogConnectionString, CommandType.Text, pageSql);
            IList<LogInfo> list = GetListFromReader(dr);
            // ��ҳ�����Զ����б�����CustomList��װ
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, pageSize, list);
            return cList;
        }

        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="isFullText">�Ƿ񵼳�ȫ��</param>
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
            // ��ҳ�����Զ����б�����CustomList��װ
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
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="from">��־��ʼʱ��</param>
        /// <param name="to">��־����ʱ��</param>
        /// <param name="sourceID">��Դ����ID</param>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
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
            // ��ҳ�����Զ����б�����CustomList��װ
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, param, pageSize, list);
            return cList;
        }
        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="from">��־��ʼʱ��</param>
        /// <param name="to">��־����ʱ��</param>
        /// <param name="type">��־����:��Ϣ,����,����,��֤ͨ��</param>
        /// <param name="sourceID">��ԴID</param>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
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
            // ��ҳ�����Զ����б�����CustomList��װ
            CustomList<LogInfo> cList = PageAmoutHelper<LogInfo>.GetCutomList(DBConnection.LogConnectionString, sql, param, pageSize, list);
            return cList;

        }
        /// <summary>
        /// ��ȡ��־��Ŀ������Ϣ
        /// </summary>
        /// <param name="id">����</param>
        /// <returns>��־��Ŀʵ��</returns>
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

/********************************************************************************************
 * �ļ�����:	SystemLog.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-12
 * ��������:	��־������
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// ��־��¼
    /// </summary>
    public class SystemLog
    {
        //private static readonly string path = "SIRC.Framework.Utility";
        //private static readonly string className = "SIRC.Framework.Utility.Log";
        //private static readonly ILog dal = (ILog)Assembly.Load(path).CreateInstance(className);

        private static readonly ILog dal = new Log();
        /// <summary>
        /// ����Ϣ��Ϊ���ش��������־
        /// </summary>
        /// <param name="message">��Ϣ����</param>
        /// <param name="sourceID">��ϢԴ������ĿID��</param>
        public void Write(string message, string sourceID)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("��־���ݲ���Ϊ��.");
            }
            dal.Write(message, sourceID);
        }
        /// <summary>
        /// ����Ϣ��Ϊָ�����͵����ݴ�����־
        /// </summary>
        /// <param name="message">��Ϣ����</param>
        /// <param name="sourceID">��ϢԴ������ĿID��</param>
        /// <param name="logType">��Ϣ���ͣ��д���һ����Ϣ�����ͨ�������ʧ�ܵ�<seealso cref="EventLogEntryType"/></param>
        public void Write(string message, EventLogEntryType logType, string sourceID)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("��־���ݲ���Ϊ��.");
            }
            dal.Write(message, logType, sourceID);
        }

        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
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
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="isFullText">�Ƿ񵼳�ȫ��</param>
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
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="from">��־��ʼʱ��</param>
        /// <param name="to">��־����ʱ��</param>
        /// <param name="sourceID">��Դ����ID</param>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <returns></returns>
        public IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, string sourceID, int pageSize, int pageIndex)
        {
            // sql���ݿⲻ֧��0001-1-1
            from = (from == DateTime.MinValue) ? DateTime.Today.AddYears(-10) : from;
            to = (to == DateTime.MaxValue) ? DateTime.Today.AddDays(1) : to;
            if (pageSize < 1 || pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return dal.GetLogInfoList(from, to, sourceID, pageSize, pageIndex);
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
        public IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, EventLogEntryType type, string sourceID, int pageSize, int pageIndex)
        {
            // sql���ݿⲻ֧��0001-1-1
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
        /// ��ȡ��־��Ŀ������Ϣ
        /// </summary>
        /// <param name="id">����</param>
        /// <returns>��־��Ŀʵ��</returns>
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

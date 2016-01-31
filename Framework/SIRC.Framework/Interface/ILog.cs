/********************************************************************************************
 * �ļ�����:	ILog.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-12
 * ��������:	��־�ӿ�
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
using System.Text;
using System.Diagnostics;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// ��־�ӿ�
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// ��¼������־
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        string Write(string message, string sourceID);
        /// <summary>
        /// ��¼������־
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logType"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        string Write(string message, EventLogEntryType logType, string sourceID);
        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex);
        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <param name="isFullText">�Ƿ񵼳�ȫ��</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(int pageSize, int pageIndex, bool isFullText);

        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="from">��־��ʼʱ��</param>
        /// <param name="to">��־����ʱ��</param>
        /// <param name="sourceID">��Դ����ID</param>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, string sourceID, int pageSize, int pageIndex);
        /// <summary>
        /// ��ȡ��־��Ϣ
        /// </summary>
        /// <param name="from">��־��ʼʱ��</param>
        /// <param name="to">��־����ʱ��</param>
        /// <param name="type">��־����:��Ϣ,����,����,��֤ͨ��</param>
        /// <param name="sourceID"></param>
        /// <param name="pageSize">��¼��</param>
        /// <param name="pageIndex">ҳ��</param>
        /// <returns></returns>
        IList<LogInfo> GetLogInfoList(DateTime from, DateTime to, EventLogEntryType type, string sourceID, int pageSize, int pageIndex);
        /// <summary>
        /// ��ȡ��־��Ŀ������Ϣ
        /// </summary>
        /// <param name="id">����</param>
        /// <returns>��־��Ŀʵ��</returns>
        LogInfo GetLogInfoByID(string id);
    }
}

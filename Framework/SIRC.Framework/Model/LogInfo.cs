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
    /// ��־ʵ��
    /// </summary>
    public class LogInfo
    {
        private string _id;
        /// <summary>
        /// ����
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _sourceID;
        /// <summary>
        /// ��־Դ���ƣ�����ĿID��
        /// </summary>
        public string SourceID
        {
            get { return _sourceID; }
            set { _sourceID = value; }
        }
        private string _typeID;
        /// <summary>
        /// ��־����ID
        /// </summary>
        public string TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private DateTime _time;
        /// <summary>
        /// ��־��¼ʱ��
        /// </summary>
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// ��־����:Error = 1,Warning = 2,Information = 4,SuccessAudit = 8,FailureAudit = 16,
        /// </summary>
        public EventLogEntryType Type
        {
            get
            {
                return EnumHandler<EventLogEntryType>.GetEnumFromIntString(this._typeID);
            }
        }

        private string _message;
        /// <summary>
        /// ��־����
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public LogInfo()
        {

        }
    }
}

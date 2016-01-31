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
    /// 日志实体
    /// </summary>
    public class LogInfo
    {
        private string _id;
        /// <summary>
        /// 主键
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _sourceID;
        /// <summary>
        /// 日志源名称（如栏目ID）
        /// </summary>
        public string SourceID
        {
            get { return _sourceID; }
            set { _sourceID = value; }
        }
        private string _typeID;
        /// <summary>
        /// 日志类型ID
        /// </summary>
        public string TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private DateTime _time;
        /// <summary>
        /// 日志记录时间
        /// </summary>
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// 日志类型:Error = 1,Warning = 2,Information = 4,SuccessAudit = 8,FailureAudit = 16,
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
        /// 日志内容
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

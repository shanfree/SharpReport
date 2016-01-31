/********************************************************************************************
 * 文件名称:	LogEntry.cs
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
using System.Text;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 日志访问
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// 日志访问接口，单件模式
        /// </summary>
        public static SystemLog Log = SingleGeneric<SystemLog>.CreateInstance();

    }
}

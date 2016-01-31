/**  版本信息模板在安装目录下，可自行修改。
* Port.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:41   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace Sirc.SharpReport.IDAL
{
	/// <summary>
	/// 接口层Port
	/// </summary>
    public interface IPort : IDBPersistenceBase<PortInfo>
	{
                /// <summary>
        /// 按照航线和港口类型返回港口列表，按照排序号从小到大排序
        /// </summary>
        /// <param name="routeID">航线ID</param>
        /// <param name="portType">港口类型</param>
        /// <returns></returns>
        IList<PortInfo> GetList(string routeID, string portType);

        /// <summary>
        /// 获取港口信息
        /// portType 2 始发港 4 目的港 5 经停港
        /// </summary>
        /// <returns>列表</returns>
        DataSet GetPortListByRoute(string routeID, string portType);
	} 
}

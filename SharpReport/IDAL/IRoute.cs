/**  版本信息模板在安装目录下，可自行修改。
* Route.cs
*
* 功 能： N/A
* 类 名： Route
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:43   N/A    初版
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
namespace Sirc.SharpReport.IDAL
{
	/// <summary>
	/// 接口层Route
	/// </summary>
    public interface IRoute : IDBPersistenceBase<RouteInfo>
	{
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        DataSet GetBaseList(int pageSize, int pageIndex);

        /// <summary>
        /// 判断路线是否被航次引用
        /// </summary>
        /// <returns>列表</returns>
        int isRouteUsed(string routeId);
	} 
}

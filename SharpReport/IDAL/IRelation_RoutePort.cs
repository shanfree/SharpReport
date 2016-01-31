/**  版本信息模板在安装目录下，可自行修改。
* IRelation_RoutePort.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/4/13 23:54:00   matthewzjq    初版
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
    /// 接口层 航程港口对应表
    /// </summary>
    public interface IRelation_RoutePort : IDBPersistenceBase<Relation_RoutePortInfo>
    {
        /// <summary>
        /// 获取航线港口信息
        /// </summary>
        /// <returns>列表</returns>
        IList<Relation_RoutePortInfo> GetListByRouteID(string routeID);

        /// <summary>
        /// 删除航线
        /// </summary>
        /// <returns>列表</returns>
        void DeleteByRoute(string routeID);
    }
}

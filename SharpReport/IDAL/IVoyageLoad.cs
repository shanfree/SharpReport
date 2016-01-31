/**  版本信息模板在安装目录下，可自行修改。
* VoyageLoad.cs
*
* 功 能： N/A
* 类 名： VoyageLoad
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:45   N/A    初版
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
    /// 接口层VoyageLoad
    /// </summary>
    public interface IVoyageLoad : IDBPersistenceBase<VoyageLoadInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        IList<VoyageLoadInfo> GetList(string shipID);
        /// <summary>
        /// 获取还未填写 船舶油料航次消耗表 的航次
        /// </summary>
        /// <returns>列表</returns>
        IList<VoyageLoadInfo> GetUnReporList();

                /// <summary>
        /// 按航次进行统计
        /// </summary>
        /// <param name="fromDate">航次结束从</param>
        /// <param name="toDate">到</param>
        /// <param name="shipID">船舶</param>
        /// <param name="voyageName">航次</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        DataSet GetDataSetByQuery(string fromDate, string toDate, string shipID, string voyageName, int pageSize, int pageIndex);

        /// <summary>
        /// 按航次进行统计
        /// </summary>
        /// <param name="fromDate">航次结束从</param>
        /// <param name="toDate">到</param>
        /// <param name="shipID">船舶</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        DataSet GetDataSetByStatistic(string fromDate, string toDate, string shipID, int pageSize, int pageIndex);



        VoyageLoadInfo GetByVoyageID(string voyageID);
    }
}

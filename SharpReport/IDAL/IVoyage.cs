/**  版本信息模板在安装目录下，可自行修改。
* Voyage.cs
*
* 功 能： N/A
* 类 名： Voyage
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
    /// 接口层Voyage
    /// </summary>
    public interface IVoyage : IDBPersistenceBase<VoyageInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="voyageIds">航次主键数组</param>
        /// <returns>列表</returns>
        IList<VoyageInfo> GetList(string[] voyageIds);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        IList<VoyageInfo> GetListByShipID(string shipID);
        /// <summary>
        /// 获取还未填写 船舶油料航次消耗表 的航次
        /// </summary>
        /// <returns>列表</returns>
        IList<VoyageInfo> GetUnReportVoyage();
                /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶装箱报表主键</param>
        /// <returns>列表</returns>
        VoyageInfo GetListByLoadID(string voyageLoadID);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="isReport">是否已填写报表</param>
        /// <param name="dateID">通过报告期查询</param>
        /// <param name="shipID">通过船舶查询</param>
        /// <returns>列表</returns>
        DataSet GetBaseList(bool isReport, string dateID, string shipID, int pageSize, int pageIndex);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="reportID">燃润报表主键</param>
        /// <returns>列表</returns>
        IList<VoyageInfo> GetVoyageListByReportID(string reportID);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns>列表</returns>
        void UpdateVoyage(string voyageIds, string baseId);

                /// <summary>
        /// 燃润报表删除后删除航次和报表的关联
        /// </summary>
        /// <param name="reportID">燃润报表ID</param>
        /// <returns>列表</returns>
        void RanrunDelete(string reportID);

    }
}

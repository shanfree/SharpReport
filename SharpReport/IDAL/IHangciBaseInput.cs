/**  版本信息模板在安装目录下，可自行修改。
* IHangciBaseInput.cs
*
* 功 能： N/A
* 类 名： IHangciBaseInput
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/14 19:30:00   matthewzjq    初版
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
    /// 接口层IHangciBaseInput
    /// </summary>
    public interface IHangciBaseInput : IDBPersistenceBase<HangciBaseInputInfo>
    {
        /// <summary>
        /// 获取航次基本信息
        /// </summary>
        /// <returns>列表</returns>
        IList<HangciBaseInputInfo> GetListByVoyageID(string voyageID);

        /// <summary>
        /// 获取船舶燃料消耗统计报表
        /// 参数yyyy mm 格式
        /// </summary>
        /// <returns>datatable</returns>
        DataTable GetMonthlyReportData(string year, string month);

        /// <summary>
        /// 消耗表列表
        /// </summary>
        /// <param name="dateID">报告期ID，可以为空，显示所有报表</param>
        /// <param name="qShipName">船名，模糊查询</param>
        /// <param name="qStartDate">启航时间，可以为空</param>
        /// <param name="qEndDate">抵港时间，可以为空</param>
        /// <param name="qStartPortID">起发港ID</param>
        /// <param name="qEndPortID">目的港ID</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        DataSet GetBaseInputList(
            string dateID, string qShipName, string qStartDate, string qEndDate, string qStartPortID, string qEndPortID, int pageSize, int pageIndex);
    }
}

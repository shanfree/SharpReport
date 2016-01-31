/**  版本信息模板在安装目录下，可自行修改。
* Ship.cs
*
* 功 能： N/A
* 类 名： Ship
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:44   N/A    初版
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
    /// 接口层Ship
    /// </summary>
    public interface IShip : IDBPersistenceBase<ShipInfo>
    {
        /// <summary>
        /// 根据报告期获取收入报表
        /// </summary>
        /// <param name="dateID">通过报告期查询，为空则返回所有</param>
        /// <param name="shipID">通过船舶查询，为空则返回所有</param>
        /// <param name="reportType">报表类型，为空则返回所有报表</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        DataSet GetIncomeMonthReport(string dateID, string shipID, int pageSize, int pageIndex);

    }
}

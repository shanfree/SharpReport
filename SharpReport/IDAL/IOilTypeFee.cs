/**  版本信息模板在安装目录下，可自行修改。
* IOilTypeFee.cs
*
* 功 能： N/A
* 类 名： IOilType
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/10 11:00:00   matthewzjq    初版
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
    /// 接口层IOilTypeFee
    /// </summary>
    public interface IOilTypeFee : IDBPersistenceBase<OilTypeFeeInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="oilFeeReportID">消耗表主表ID</param>
        /// <returns>列表</returns>
        IList<OilTypeFeeInfo> GetList(string oilFeeReportID);
    }
}

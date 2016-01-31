/**  版本信息模板在安装目录下，可自行修改。
* XiuliInput.cs
*
* 功 能： N/A
* 类 名： XiuliInput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using Sirc.SharpReport.Model;
using SIRC.Framework.Utility;

namespace Sirc.SharpReport.IDAL
{
    /// <summary>
    /// 接口层XiuliInput
    /// </summary>
    public interface IXiuliInput : IDBPersistenceBase<XiuliInputInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询，为空则返回所有</param>
        /// <param name="shipID">通过船舶查询，为空则返回所有</param>
        /// <param name="reportType">报表类型，为空则返回所有报表</param>
        /// <returns>列表</returns>
        DataSet GetList(string dateID, string shipID, string reportType, int pageSize, int pageIndex);
        /// <summary>
        /// 按年份，船舶统计报表信息
        /// </summary>
        /// <param name="year">报表的年份，为空显示所有年份</param>
        /// <param name="shipID">报表对应的船舶，为空显示所有的船舶</param>
        DataSet GetCountStatictis(string year, string shipID);

        /// <summary>
        /// 按季度，船舶统计报表信息
        /// </summary>
        /// <param name="year">报表的年份</param>
        /// <param name="quarter">报表对应的季度</param>
        DataSet GetSumStatictis(string year, string quarter);

    }
}

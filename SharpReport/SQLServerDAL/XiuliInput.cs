/**  版本信息模板在安装目录下，可自行修改。
* XiuliInput.cs
*
* 功 能： N/A
* 类 名： XiuliInput
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Sirc.SharpReport.IDAL;
using Sirc.SharpReport.Model;
using SIRC.Framework.Utility;
using System.Collections.Generic;


namespace Sirc.SharpReport.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:XiuliInput
    /// </summary>
    public partial class XiuliInput : DBPersistenceBase<XiuliInputInfo>, IXiuliInput
    {
        public XiuliInput()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM XiuliInput WHERE ID = @ID";
        #endregion

        /// <summary>
        /// 连接串
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                return DBConnection.ConnectionString;
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询，为空则返回所有</param>
        /// <param name="shipID">通过船舶查询，为空则返回所有</param>
        /// <param name="reportType">报表类型，为空则返回所有报表</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns>列表</returns>
        public DataSet GetList(string dateID, string shipID, string reportType, int pageSize, int pageIndex)
        {
            string sql = @"
                        select dbo.V_XiuliInput.*, [User].Name as UserName from 
                        dbo.V_XiuliInput left join [User] on V_XiuliInput.InputUserID = [User].ID
                        WHERE 1 = 1 {0}";
            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(dateID) == false)
            {
                typeClause += " AND DimTimeID = " + dateID;
            }
            if (string.IsNullOrEmpty(shipID) == false)
            {
                typeClause += " AND ShipID = " + shipID;
            }
            if (string.IsNullOrEmpty(reportType) == false)
            {
                typeClause += " AND ReportTypeID = " + reportType;
            }
            sql = string.Format(sql, typeClause);
            string pagedSQL = CommonHelper.GetPagedSQL(sql, "CreateTime", true, pageSize, pageIndex);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                // 总页数以自定义列表类型CustomList封装
                CustomDataSet cDS = PageAmoutHelper<object>.GetCutomDataSet(this.ConnectionString, sql, pageSize, ds);
                return cDS;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 按年份，船舶统计报表信息
        /// </summary>
        /// <param name="year">报表的年份</param>
        /// <param name="shipID">报表对应的船舶，为空显示所有的船舶</param>
        public DataSet GetCountStatictis(string year, string shipID)
        {
            string sql = @"
                                    select Year, MonthNumOfYear,ID,
                                    isnull(
                                    (
                                        select count(1) from dbo.V_XiuliInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    {0}
                                    ),0) as 全部,
                                    isnull(
                                    (
                                        select sum(总数) from dbo.V_XiuliInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    {0}
                                    ),0) as 总数,                                  
                                    isnull(
                                    (
                                        select count(1) from dbo.V_XiuliInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    and ReportTypeID = 1
		                                    {0}
                                    ),0) as 预估录入,
                                    isnull(
                                    (
                                        select count(1) from dbo.V_XiuliInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    and ReportTypeID = 2
		                                    {0}
                                    ),0) as 修正录入,
                                    isnull(
                                    (
                                        select count(1) from dbo.V_XiuliInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    and ReportTypeID = 3
		                                    {0}
                                    ),0) as 财务确认
                                    from dbo.DimTime DT
                                    where Year = @Year
                                    order by Year,MonthNumOfYear";
            string shipClause = "and V.ShipID = " + shipID;
            if (string.IsNullOrEmpty(shipID))
            {
                shipClause = string.Empty;
            }
            sql = string.Format(sql, shipClause);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year", year);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            return ds;
        }

        /// <summary>
        /// 按季度，船舶统计报表信息
        /// </summary>
        /// <param name="year">报表的年份</param>
        /// <param name="quarter">报表对应的季度</param>
        public DataSet GetSumStatictis(string year, string quarter)
        {
            string sql = @"
                                    SELECT S.Name,S.ID,
                                    CASE VI.UsageType 
                                    WHEN 1 THEN '日常用'
                                    WHEN 2 THEN '厂修用'
                                    WHEN 3 THEN '航修用'
                                    ELSE '其他' END as UsageType,
                                    isnull(
                                    (
                                        select SUM(总数) from dbo.V_XiuliInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 总数,
                                    isnull(
                                    (
                                        select SUM(自购物料) from dbo.V_XiuliInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and 
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 自购物料,
                                    isnull(
                                    (
                                        select SUM(备件) from dbo.V_XiuliInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 备件,
                                    isnull(
                                    (
                                        select SUM(修理费用) from dbo.V_XiuliInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 修理费用
                                    FROM dbo.Ship S,dbo.V_XiuliInput VI
                                    WHERE S.ID = VI.ShipID
                                    group by S.Name,S.ID,UsageType
                                    order by S.ID
                                    ";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@QuarterNumOfYear", quarter);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            return ds;
        }
    }
}


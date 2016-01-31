/**  版本信息模板在安装目录下，可自行修改。
* WuliaoInput.cs
*
* 功 能： N/A
* 类 名： WuliaoInput
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
    /// 数据访问类:WuliaoInput
    /// </summary>
    public partial class WuliaoInput : DBPersistenceBase<WuliaoInputInfo>, IWuliaoInput
    {
        /// <summary>
        /// 
        /// </summary>
        public WuliaoInput()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM WuliaoInput WHERE ID = @ID";
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
        /// <returns>列表</returns>
        public DataSet GetList(string dateID, string shipID, string reportType, int pageSize, int pageIndex)
        {
            //TODO:这里错误，两张发票显示两张报表
            string sql = @"
                            select 
                            dbo.V_WuliaoInput.[Year], 
                            dbo.V_WuliaoInput.MonthNumOfYear, 
                            dbo.V_WuliaoInput.Name, 
                            dbo.V_WuliaoInput.ReportTypeID, 
                            dbo.V_WuliaoInput.ID, 
                            dbo.V_WuliaoInput.总数, 
                            dbo.V_WuliaoInput.UsageType, 
                            dbo.V_WuliaoInput.CreateTime, 
                            [User].Name as UserName,'1' as ReportCatalog,
                            dbo.Invoice.ReportType,
                            dbo.Invoice.Number
                            from
                             dbo.V_WuliaoInput LEFT OUTER JOIN
                                dbo.Invoice ON dbo.V_WuliaoInput.ID = dbo.Invoice.KeyID LEFT OUTER JOIN
                                dbo.[User] ON dbo.V_WuliaoInput.InputUserID = dbo.[User].ID
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
        /// 按发票的编号统计报表信息
        /// </summary>
        /// <param name="invoiceNo">发票的编号</param>
        public DataSet GetList(string invoiceNo)
        {
            #region sql
            string sql = @"
                        select * from
                        (
                            select 
                            dbo.V_WuliaoInput.[Year], 
                            dbo.V_WuliaoInput.MonthNumOfYear, 
                            dbo.V_WuliaoInput.Name, 
                            dbo.V_WuliaoInput.ReportTypeID, 
                            dbo.V_WuliaoInput.ID, 
                            dbo.V_WuliaoInput.总数, 
                            dbo.V_WuliaoInput.CreateTime, 
                            [User].Name as UserName,'1' as ReportCatalog,
                            dbo.Invoice.ReportType,
                            dbo.Invoice.Number
                            from 
                             dbo.V_WuliaoInput LEFT OUTER JOIN
                                dbo.Invoice ON dbo.V_WuliaoInput.ID = dbo.Invoice.KeyID LEFT OUTER JOIN
                                dbo.[User] ON dbo.V_WuliaoInput.InputUserID = dbo.[User].ID
                            union
                            select 
                            dbo.V_XiuliInput.[Year], 
                            dbo.V_XiuliInput.MonthNumOfYear, 
                            dbo.V_XiuliInput.Name, 
                            dbo.V_XiuliInput.ReportTypeID, 
                            dbo.V_XiuliInput.ID, 
                            dbo.V_XiuliInput.总数, 
                            dbo.V_XiuliInput.CreateTime, 
                            [User].Name as UserName,'2' as ReportCatalog,
                            dbo.Invoice.ReportType,
                            dbo.Invoice.Number
                            from 
                             dbo.V_XiuliInput LEFT OUTER JOIN
                                dbo.Invoice ON dbo.V_XiuliInput.ID = dbo.Invoice.KeyID LEFT OUTER JOIN
                                dbo.[User] ON dbo.V_XiuliInput.InputUserID = dbo.[User].ID
                            union
                            select 
                            dbo.V_Jianyan.[Year], 
                            dbo.V_Jianyan.MonthNumOfYear, 
                            dbo.V_Jianyan.Name, 
                            dbo.V_Jianyan.ReportTypeID, 
                            dbo.V_Jianyan.ID, 
                            dbo.V_Jianyan.总数, 
                            dbo.V_Jianyan.CreateTime, 
                            [User].Name as UserName,'3' as ReportCatalog,
                            dbo.Invoice.ReportType,
                            dbo.Invoice.Number
                            from 
                             dbo.V_Jianyan LEFT OUTER JOIN
                                dbo.Invoice ON dbo.V_Jianyan.ID = dbo.Invoice.KeyID LEFT OUTER JOIN
                                dbo.[User] ON dbo.V_Jianyan.InputUserID = dbo.[User].ID    
                            union
                            select 
                            dbo.V_Beijian.[Year], 
                            dbo.V_Beijian.MonthNumOfYear, 
                            dbo.V_Beijian.Name, 
                            dbo.V_Beijian.ReportTypeID, 
                            dbo.V_Beijian.ID, 
                            dbo.V_Beijian.总数, 
                            dbo.V_Beijian.CreateTime, 
                            [User].Name as UserName,'4' as ReportCatalog,
                            dbo.Invoice.ReportType,
                            dbo.Invoice.Number
                            from 
                             dbo.V_Beijian LEFT OUTER JOIN
                                dbo.Invoice ON dbo.V_Beijian.ID = dbo.Invoice.KeyID LEFT OUTER JOIN
                                dbo.[User] ON dbo.V_Beijian.InputUserID = dbo.[User].ID  
                        ) as T      
                        WHERE  Number is not null and (Number like '%{0}%')";
            #endregion

            sql = string.Format(sql, invoiceNo);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);
            return ds;
        }

        /// <summary>
        /// 按年份，船舶统计物料报表信息
        /// </summary>
        /// <param name="year">报表的年份</param>
        /// <param name="shipID">报表对应的船舶，为空显示所有的船舶</param>
        public DataSet GetCountStatictis(string year, string shipID)
        {
            string sql = @"
                                    select Year, MonthNumOfYear,ID,
                                    isnull(
                                    (
                                        select count(1) from dbo.V_WuliaoInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    {0}
                                    ),0) as 全部,
                                    isnull(
                                    (
                                        select sum(总数) from dbo.V_WuliaoInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    {0}
                                    ),0) as 总数,                                  
                                    isnull(
                                    (
                                        select count(1) from dbo.V_WuliaoInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    and ReportTypeID = 1
		                                    {0}
                                    ),0) as 预估录入,
                                    isnull(
                                    (
                                        select count(1) from dbo.V_WuliaoInput V
                                        where V.MonthNumOfYear = DT.MonthNumOfYear and V.Year = DT.Year 
		                                    and ReportTypeID = 2
		                                    {0}
                                    ),0) as 修正录入,
                                    isnull(
                                    (
                                        select count(1) from dbo.V_WuliaoInput V
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
        /// 按季度，船舶统计物料报表信息
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
                                        select SUM(总数) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 总数,
                                    isnull(
                                    (
                                        select SUM(生产用品) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and 
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 生产用品,
                                    isnull(
                                    (
                                        select SUM(生活用品) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 生活用品,
                                    isnull(
                                    (
                                        select SUM(办公用品) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 办公用品,
                                    isnull(
                                    (
                                        select SUM(油漆) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 油漆,
                                    isnull(
                                    (
                                        select SUM(缆绳) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 缆绳,
                                    isnull(
                                    (
                                        select SUM(锁具) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                            V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 锁具,
                                    isnull(
                                    (
                                        select SUM(药品) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                             V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 药品,
                                    isnull(
                                    (
                                        select SUM(其他) from dbo.V_WuliaoInput V
                                        where 
                                            V.QuarterNumOfYear = @QuarterNumOfYear and V.Year = @Year and
                                             V.ShipID = S.ID
                                            and V.UsageType = VI.UsageType
                                    ),0) as 其他
                                    FROM dbo.Ship S,dbo.V_WuliaoInput VI
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


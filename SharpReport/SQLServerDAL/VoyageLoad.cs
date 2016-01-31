/**  版本信息模板在安装目录下，可自行修改。
* VoyageLoad.cs
*
* 功 能： N/A
* 类 名： VoyageLoad
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
    /// 数据访问类:VoyageLoad
    /// </summary>
    public partial class VoyageLoad : DBPersistenceBase<VoyageLoadInfo>, IVoyageLoad
    {
        /// <summary>
        /// 
        /// </summary>
        public VoyageLoad()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM VoyageLoad WHERE ID = @ID";
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
        /// 根据航次ID获取实体
        /// </summary>
        /// <param name="voyageID">实体主键</param>
        /// <returns>实体</returns>
        public VoyageLoadInfo GetByVoyageID(string voyageID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@VoyageID", voyageID);

            string sql = @"
                        select * from V_VoyageLoad
                        WHERE VoyageID =@VoyageID ";
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<VoyageLoadInfo> list = GetListFromReader(dr);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<VoyageLoadInfo> GetList(string shipID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ShipID", shipID);

            string sql = @"
                        select * from V_VoyageLoad
                        WHERE ShipID =@ShipID ";
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<VoyageLoadInfo> list = GetListFromReader(dr);
            return list;
        }

        /// <summary>
        /// 获取还未填写 船舶油料航次消耗表 的航次
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageLoadInfo> GetUnReporList()
        {
            string sql = @"
                        select * from V_VoyageLoad
                        WHERE VoyageLoadID IS NULL ";
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql);
            IList<VoyageLoadInfo> list = GetListFromReader(dr);
            return list;
        }

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
        public DataSet GetDataSetByQuery(string fromDate, string toDate, string shipID, string voyageName, int pageSize, int pageIndex)
        {
            string sql = @"
                                SELECT ShipName,Name,EndDate,
                                LCLAmount,TEUEmpty,TEUHeavy,FEUEmpty,FEUHeavy,FFEUEmpty,FFEUHeavy,Rest,EqualTo,
                                LCLAmount+TEUEmpty+TEUHeavy+FEUEmpty+FEUHeavy+FFEUEmpty+FFEUHeavy+EqualTo AS TOTAL
                                FROM
                                dbo.V_VoyageLoad
                                WHERE 
                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL {0}";

            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(fromDate) == false)
            {
                typeClause += "AND EndDate >= " + fromDate;
            }
            if (string.IsNullOrEmpty(toDate) == false)
            {
                typeClause += "AND EndDate <= " + toDate;
            }
            if (string.IsNullOrEmpty(shipID) == false)
            {
                typeClause += " AND ShipID = " + shipID;
            }
            if (string.IsNullOrEmpty(voyageName) == false)
            {
                typeClause += " AND Name LIKE '%" + voyageName + "%'";
            }
            sql = string.Format(sql, typeClause);
            string pagedSQL = CommonHelper.GetPagedSQL(sql, "Name", false, pageSize, pageIndex);
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
        /// 按航次进行统计
        /// </summary>
        /// <param name="fromDate">航次结束从</param>
        /// <param name="toDate">到</param>
        /// <param name="voyageID">航次ID</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet GetDataSetByStatistic(string fromDate, string toDate, string shipID, int pageSize, int pageIndex)
        {
            #region sql
            string sql = @"
                                    select Year, MonthNumOfYear,ID,
                                    isnull(
                                    (
                                        SELECT
		                                sum(LCLAmount)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as LCLAmount,
                                    isnull(
                                    (
                                        SELECT
		                                sum(TEUEmpty)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as TEUEmpty,
                                    isnull(
                                    (
                                        SELECT
		                                sum(TEUHeavy)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as TEUHeavy,
                                    isnull(
                                    (
                                        SELECT
		                                sum(FEUEmpty)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as FEUEmpty,
                                    isnull(
                                    (
                                        SELECT
		                                sum(FEUHeavy)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as FEUHeavy,
                                    isnull(
                                    (
                                        SELECT
		                                sum(FFEUEmpty)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as FFEUEmpty,
                                    isnull(
                                    (
                                        SELECT
		                                sum(FFEUHeavy)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as FFEUHeavy,
                                    isnull(
                                    (
                                        SELECT
		                                sum(Rest)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as Rest,
                                    isnull(
                                    (
                                        SELECT
		                                sum(EqualTo)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) as EqualTo,
                                    isnull(
                                    (
                                        SELECT
		                                sum(LCLAmount+TEUEmpty+TEUHeavy+FEUEmpty+FEUHeavy+FFEUEmpty+FFEUHeavy+EqualTo)
		                                FROM
		                                dbo.V_VoyageLoad
		                                WHERE 
		                                LCLAmount IS NOT NULL AND TEUEmpty IS NOT NULL
		                                AND DatePart (Year,EndDate) = Year
		                                AND DatePart (Month,EndDate) = MonthNumOfYear
                                        {0}
                                    ),0) AS TOTAL
                                    from dbo.DimTime DT
                                    where Year = 2013
                                    order by Year,MonthNumOfYear
                                ";

            #endregion

            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(fromDate) == false)
            {
                typeClause += "AND EndDate >= " + fromDate;
            }
            if (string.IsNullOrEmpty(toDate) == false)
            {
                typeClause += "AND EndDate <= " + toDate;
            }
            if (string.IsNullOrEmpty(shipID) == false)
            {
                typeClause += " AND ShipID = " + shipID;
            }
            sql = string.Format(sql, typeClause);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);
            return ds;
        }


    }
}


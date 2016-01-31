/**  版本信息模板在安装目录下，可自行修改。
* RentShipReport.cs
*
* 功 能： N/A
* 类 名： RentShipReport
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
    /// 数据访问类:RentShipReport
    /// </summary>
    public partial class RentShipReport : DBPersistenceBase<RentShipReportInfo>, IRentShipReport
    {
        /// <summary>
        /// 
        /// </summary>
        public RentShipReport()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM V_RentShipReport WHERE ID = @ID";
        private const string SQL_SELECT_ShipID = @"SELECT * FROM V_RentShipReport WHERE ShipID = @ShipID";
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
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<RentShipReportInfo> GetList(string shipID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ShipID", shipID);

            string sql = SQL_SELECT_ShipID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<RentShipReportInfo> list = GetListFromReader(dr);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询</param>
        /// <param name="shipID">通过船舶查询</param>
        /// <returns>列表</returns>
        public DataSet GetList(string year, string month, string shipID, int pageSize, int pageIndex)
        {
            string sql = @"
                        select * from V_RentShipReport
                        WHERE 1 = 1 ";
            string typeClause = string.Empty;
            //报告期以到港计算
            if (string.IsNullOrEmpty(year) == false)
            {
                sql += string.Format(" and DatePart (Year,EndDate) = {0}  ", year);
            }
            if (string.IsNullOrEmpty(month) == false)
            {
                sql += string.Format("  and DatePart (Month,EndDate) = {0} ", month);
            }
            if (string.IsNullOrEmpty(shipID) == false)
            {
                typeClause += "AND ShipID = " + shipID;
            }
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
    }
}


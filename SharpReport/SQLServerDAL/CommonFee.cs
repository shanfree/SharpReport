/**  版本信息模板在安装目录下，可自行修改。
* CommonFee.cs
*
* 功 能： N/A
* 类 名： CommonFee
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
    /// 数据访问类:CommonFee
    /// </summary>
    public partial class CommonFee : DBPersistenceBase<CommonFeeInfo>, ICommonFee
    {
        public CommonFee()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM CommonFee WHERE ID = @ID";
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
        /// <param name="year">年份数字</param>
        /// <param name="month">月份数字</param>
        /// <param name="departmentID"></param>
        /// <returns>列表</returns>
        public IList<CommonFeeInfo> GetList(string year, string month, string departmentID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@DepartmentID", departmentID);
            string sql = @"
                        select dbo.V_CommonFee.* from 
                        dbo.V_CommonFee
                        WHERE Year=@Year AND DepartmentID=@DepartmentID  ";
            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(month) == false)
            {
                typeClause = " AND MonthNumOfYear = " + month;
                sql += typeClause;
            }

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<CommonFeeInfo> list = GetListFromReader(dr, false, true);
            return list;
        }

        /// <summary>
        /// 按年度统计各个部门的费用子项之和
        /// </summary>
        /// <param name="departmentID">部门ID，其中4：安监部；5：人资部</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetStatistic(string departmentID, int year)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@DepartmentID", departmentID);
            string sql = @"
                                    SELECT Name,DepartmentName,
                                    (
                                         SELECT isnull(sum(Amount),0) 
                                         FROM dbo.CommonFee,DimTime
                                         WHERE 
                                         CommonFee.DimTimeID = DimTime.ID AND
                                         FeeCatalogID = FC.ID AND
                                         DimTime.Year = @Year 
                                    ) as Amount,
                                    (
                                         SELECT isnull(count(1),0) 
                                         FROM dbo.CommonFee,DimTime
                                         WHERE 
                                         CommonFee.DimTimeID = DimTime.ID AND
                                         FeeCatalogID = FC.ID AND
                                         DimTime.Year = @Year 
                                    ) as Number
                                     FROM
                                    dbo.V_FeeCatalog FC
                                    WHERE FC.DepartmentID = @DepartmentID
                                ";
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            return ds;
        }

    }
}


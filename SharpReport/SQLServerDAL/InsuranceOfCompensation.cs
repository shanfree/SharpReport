/**  版本信息模板在安装目录下，可自行修改。
* InsuranceOfCompensation.cs
*
* 功 能： N/A
* 类 名： InsuranceOfCompensation
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
    /// 数据访问类:InsuranceOfCompensation
    /// </summary>
    public partial class InsuranceOfCompensation : DBPersistenceBase<InsuranceOfCompensationInfo>, IInsuranceOfCompensation
    {
        public InsuranceOfCompensation()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM InsuranceOfCompensation WHERE ID = @ID";
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

        ///// <summary>
        ///// 写入扩展属性
        ///// </summary>
        ///// <param name="reader">数据库游标</param>
        ///// <param name="t">实体对象</param>
        ///// <returns></returns>
        //protected override InsuranceOfCompensationInfo WriteLazyLoadProperty(SqlDataReader reader, InsuranceOfCompensationInfo t)
        //{
        //    string id = t.ID;
        //    IList<ContainerInfo> cList = new Container().GetList(id);
        //    t.ContainerList = cList;
        //    return t;
        //}

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="year">年份数字</param>
        /// <param name="month">月份数字</param>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public DataSet GetList(string year, string month, string shipID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@Month", month);
            //获取所有子栏目树节点

            string sql = @"
                        select dbo.V_InsuranceOfCompensation.* from 
                        dbo.V_InsuranceOfCompensation
                        WHERE Year=@Year AND MonthNumOfYear=@Month {0}";
            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(shipID) == false)
            {
                typeClause = " AND ShipID = " + shipID;
            }
            sql = string.Format(sql, typeClause);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            return ds;
        }

    }
}


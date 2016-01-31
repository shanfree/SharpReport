/**  版本信息模板在安装目录下，可自行修改。
* CertificateFlee.cs
*
* 功 能： N/A
* 类 名： CertificateFlee
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
    /// 数据访问类:CertificateFlee
    /// </summary>
    public partial class CertificateFlee : DBPersistenceBase<CertificateFleeInfo>, ICertificateFlee
    {
        public CertificateFlee()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM CertificateFlee WHERE ID = @ID";
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
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public DataSet GetList(string year)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year", year);
            //获取所有子栏目树节点

            string sql = @"
                        select dbo.V_CertificateFlee.* from 
                        dbo.V_CertificateFlee
                        WHERE Year=@Year ";
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            return ds;
        }

    }
}


/**  版本信息模板在安装目录下，可自行修改。
* Invoice.cs
*
* 功 能： N/A
* 类 名： Invoice
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
    /// 数据访问类:Invoice
    /// </summary>
    public partial class Invoice : DBPersistenceBase<InvoiceInfo>, IInvoice
    {
        public Invoice()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Invoice WHERE ID = @ID";
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
        /// 获取报表的发票列表
        /// </summary>
        /// <param name="reportType">报表类型</param>
        /// <param name="keyID">报表主键</param>
        /// <returns></returns>
        public IList<InvoiceInfo> GetInvoiceList(string reportType, string keyID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ReportType", reportType);
            param[1] = new SqlParameter("@KeyID", keyID);

            string sql = @"SELECT * FROM V_Invoice 
                                    WHERE ReportType = @ReportType
                                    AND KeyID = @KeyID";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<InvoiceInfo> list = GetListFromReader(dr, false, false);
            return list;
        }

        /// <summary>
        /// 根据发票编号获取实体
        /// </summary>
        /// <param name="number">发票编号</param>
        /// <returns>实体</returns>
        public IList<InvoiceInfo> GetByNumber(string number)
        {
            string sql = @"SELECT * FROM V_Invoice 
                                    WHERE Number LIKE '%" + number + "%'";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql);
            IList<InvoiceInfo> list = GetListFromReader(dr, false, false);
            return list;
        }

    }
}


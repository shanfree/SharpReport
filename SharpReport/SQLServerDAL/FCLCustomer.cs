/**  版本信息模板在安装目录下，可自行修改。
* FCLCustomer.cs
*
* 功 能： N/A
* 类 名： FCLCustomer
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
    /// 数据访问类:FCLCustomer
    /// </summary>
    public partial class FCLCustomer : DBPersistenceBase<FCLCustomerInfo>, IFCLCustomer
    {
        /// <summary>
        /// 
        /// </summary>
        public FCLCustomer()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM V_FCLCustomer WHERE ID = @ID";
        private const string SQL_SELECT_FCLID = @"SELECT * FROM V_FCLCustomer WHERE FCLID = @FCLID";
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
        /// <param name="FCLID">实体主键</param>
        /// <returns>实体</returns>
        public IList<FCLCustomerInfo> GetByFCLID(string FCLID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FCLID", FCLID);

            string sql = SQL_SELECT_FCLID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<FCLCustomerInfo> list = GetListFromReader(dr);
            return list;
        }
        


    }
}


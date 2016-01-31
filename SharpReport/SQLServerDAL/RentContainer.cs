/**  版本信息模板在安装目录下，可自行修改。
* RentContainer.cs
*
* 功 能： N/A
* 类 名： RentContainer
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
    /// 数据访问类:RentContainer
    /// </summary>
    public partial class RentContainer : DBPersistenceBase<RentContainerInfo>, IRentContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public RentContainer()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM V_RentContainer WHERE ID = @ID";
        //private const string SQL_SELECT_ShipID = @"SELECT * FROM V_RentContainer WHERE ShipID = @ShipID";
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
        /// <param name="reportID">通过报告期查询</param>
        /// <returns>列表</returns>
        public IList<RentContainerInfo> GetList(string reportID)
        {
            string sql = @"
                        select * from V_RentContainer
                        WHERE 1 = 1 ";
            string typeClause = string.Empty;
            //报告期以到港计算
            if (string.IsNullOrEmpty(reportID) == false)
            {
                sql += string.Format(" and ReportID = {0}  ", reportID);
            }
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql);
            IList<RentContainerInfo> list = GetListFromReader(dr);
            return list;
        }
    }
}


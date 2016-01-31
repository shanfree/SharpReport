/**  版本信息模板在安装目录下，可自行修改。
* IOilType.cs
*
* 功 能： N/A
* 类 名： IOilType
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/10 11:00:00   matthewzjq    初版
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
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace Sirc.SharpReport.SQLServerDAL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OilTypeFee : DBPersistenceBase<OilTypeFeeInfo>, IOilTypeFee
    {
        /// <summary>
        /// 
        /// </summary>
        public OilTypeFee()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM OilTypeFee WHERE ID = @ID";
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
        /// <param name="oilFeeReportID">消耗表主表ID</param>
        /// <returns>列表</returns>
        public IList<OilTypeFeeInfo> GetList(string oilFeeReportID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@OilFeeReportID", oilFeeReportID);
            string sql = @"
                        select V_OilTypeFee.* from 
                        dbo.V_OilTypeFee
                        WHERE OilFeeReportID = @OilFeeReportID  ";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<OilTypeFeeInfo> list = GetListFromReader(dr, false, true);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            return list;
        }
    }
}

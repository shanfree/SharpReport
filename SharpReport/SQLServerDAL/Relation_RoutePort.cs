/**  版本信息模板在安装目录下，可自行修改。
* Relation_RoutePort.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/13 23:54:00   matthewzjq    初版
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
    /// 数据访问类: Relation_RoutePort
    /// </summary>
    public partial class Relation_RoutePort : DBPersistenceBase<Relation_RoutePortInfo>, IRelation_RoutePort
    {
        public Relation_RoutePort()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Relation_RoutePort WHERE ID = @ID";
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
        /// 获取航线港口信息
        /// </summary>
        /// <returns>列表</returns>
        public IList<Relation_RoutePortInfo> GetListByRouteID(string routeID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RouteID", routeID);
            string sql = @"select t.* from Relation_RoutePort t where t.RouteID = @RouteID";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<Relation_RoutePortInfo> list = GetListFromReader(dr, false, false);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// 删除航线
        /// </summary>
        /// <returns>列表</returns>
        public void DeleteByRoute(string routeID)
        {
            string sql = @"delete from Relation_RoutePort where RouteID = " + routeID;

            SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql);
        }
    }
}

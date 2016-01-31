/**  版本信息模板在安装目录下，可自行修改。
* Port.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:41   N/A    初版
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
    /// 数据访问类:Port
    /// </summary>
    public partial class Port : DBPersistenceBase<PortInfo>, IPort
    {
        public Port()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM V_RoutePort WHERE ID = @ID";
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
        /// 按照航线和港口类型返回港口列表，按照排序号从小到大排序
        /// </summary>
        /// <param name="routeID">航线ID</param>
        /// <param name="portType">港口类型</param>
        /// <returns></returns>
        public IList<PortInfo> GetList(string routeID, string portType)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RouteID", routeID);

            string sql = @"SELECT * FROM V_RoutePort 
                                where RouteID = @RouteID {0}
                                order by OrderNum asc";
            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(portType) == false)
            {
                typeClause = " and PortTypeID =  " + portType;
            }
            sql = string.Format(sql, typeClause);

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<PortInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;

        }

        /// <summary>
        /// 获取港口信息
        /// portType 2 始发港 4 目的港 5 经停港
        /// </summary>
        /// <returns>列表</returns>
        public DataSet GetPortListByRoute(string routeID, string portType)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@RouteID", routeID);
            param[1] = new SqlParameter("@PortTypeID", portType);

            string sql = @"select p.ID PortID,p.Name PortName,t.OrderNum,t.ID relateId from Relation_RoutePort t,Port p where t.RouteID = @RouteID and t.PortTypeID = @PortTypeID and t.PortID = p.ID order by t.OrderNum";

            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            return ds;
            /*
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<PortInfo> list = GetListFromReader(dr, false, false);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;*/
        }

    }
}


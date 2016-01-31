/**  版本信息模板在安装目录下，可自行修改。
* Route.cs
*
* 功 能： N/A
* 类 名： Route
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
    /// 数据访问类:Route
    /// </summary>
    public partial class Route : DBPersistenceBase<RouteInfo>, IRoute
    {
        public Route()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Route WHERE ID = @ID";
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
        /// 写入扩展属性
        /// </summary>
        /// <param name="reader">数据库游标</param>
        /// <param name="t">实体对象</param>
        /// <returns></returns>
        protected override RouteInfo WriteLazyLoadProperty(SqlDataReader reader, RouteInfo t)
        {
            string id = t.ID;
            IList<PortInfo> cList = new Port().GetList(id, string.Empty);
            if (cList == null || cList.Count == 0)
            {
                t.TotalRoute = t.Name + "[未填写经停港]";
                return t;
            }
            string routeTotal = string.Empty;
            foreach (PortInfo pInfo in cList)
            {
                routeTotal += " → " + pInfo.Name;
            }
            if (routeTotal.StartsWith(" → "))
            {
                routeTotal = routeTotal.Substring(3);
            }
            t.TotalRoute = routeTotal;
            return t;
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public DataSet GetBaseList(int pageSize, int pageIndex)
        {
            string sql = @"
                select base3.*,isnull(pp3.Name,'') PassPortName3 from 
                (select base2.*,isnull(pp2.Name,'') PassPortName2 from 
                (select base.*,isnull(pp1.Name,'') PassPortName1 from 

                (SELECT r.ID,r.Name RouteName,ps.Name StartPortName, pe.Name EndPortName, r.Distance 
                 FROM [dbo].[Route] r, [dbo].[Relation_RoutePort] rrps,[dbo].[Relation_RoutePort] rrpe, [dbo].[Port] ps,[dbo].[Port] pe 
                 where r.ID = rrps.RouteID and rrps.PortTypeID='2' and rrps.PortID=ps.ID 
                 and r.ID=rrpe.RouteID and rrpe.PortTypeID='4' and rrpe.PortID=pe.ID) base 
                 
                 left join [dbo].[Relation_RoutePort] rrpp1 on base.ID = rrpp1.RouteID and
                 rrpp1.PortTypeID='5' and rrpp1.OrderNum='1' left join [dbo].[Port] pp1 on 
                 rrpp1.PortID=pp1.ID ) base2
                 
                 left join [dbo].[Relation_RoutePort] rrpp2 on base2.ID = rrpp2.RouteID and
                 rrpp2.PortTypeID='5' and rrpp2.OrderNum='2' left join [dbo].[Port] pp2 on 
                 rrpp2.PortID=pp2.ID  ) base3
                 
                 left join [dbo].[Relation_RoutePort] rrpp3 on base3.ID = rrpp3.RouteID and
                 rrpp3.PortTypeID='5' and rrpp3.OrderNum='3' left join [dbo].[Port] pp3 on 
                 rrpp3.PortID=pp3.ID";

            string pagedSQL = CommonHelper.GetPagedSQL(sql, "ID", true, pageSize, pageIndex);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, pagedSQL);
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

        /// <summary>
        /// 判断路线是否被航次引用
        /// </summary>
        /// <returns>列表</returns>
        public int isRouteUsed(string routeId)
        {
            string sql = @"
                        SELECT count(1) from Voyage where RouteID = " + routeId;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql));
        }
    }
}


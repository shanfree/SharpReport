/**  版本信息模板在安装目录下，可自行修改。
* Voyage.cs
*
* 功 能： N/A
* 类 名： Voyage
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
    /// 数据访问类:Voyage
    /// </summary>
    public partial class Voyage : DBPersistenceBase<VoyageInfo>, IVoyage
    {
        public Voyage()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM V_Voyage WHERE ID = @ID";
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
        /// <param name="voyageIds">航次主键数组</param>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetList(string[] voyageIds)
        {
            string strVoyageIds = string.Empty;
            for (int i = 0; i < voyageIds.Length; i++)
            {
                strVoyageIds += "," + voyageIds[i];
            }
            strVoyageIds = strVoyageIds.Substring(1);
            //获取所有子栏目树节点

            string sql = @"
                        select* from 
                        V_Voyage
                        WHERE ID IN ( {0} )";
            sql = string.Format(sql, strVoyageIds);

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql);
            IList<VoyageInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetListByShipID(string shipID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ShipID", shipID);
            //获取所有子栏目树节点

            string sql = @"
                        select* from 
                        V_Voyage
                        WHERE ShipID=@ShipID";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<VoyageInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }
                /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶装箱报表主键</param>
        /// <returns>列表</returns>
        public VoyageInfo GetListByLoadID(string voyageLoadID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@VoyageLoadID", voyageLoadID);
            //获取所有子栏目树节点

            string sql = @"
                        select* from 
                        V_Voyage
                        WHERE VoyageLoadID=@VoyageLoadID";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<VoyageInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 获取还未填写 船舶油料航次消耗表 的航次
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetUnReportVoyage()
        {

            string sql = @"
                            select v.ID,v.Name,v.RouteID,v.ShipID,SUBSTRING(convert(varchar,v.BeginDate,120),1,10)BeginDate,
                            SUBSTRING(convert(varchar,v.EndDate,120),1,10)EndDate from Voyage v where 
                            v.ID not in(select h.VoyageID from HangciBaseInput h)";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql);
            IList<VoyageInfo> list = GetListFromReader(dr, false, false);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="isReport">是否已填写报表</param>
        /// <param name="dateID">通过报告期查询</param>
        /// <param name="shipID">通过船舶查询</param>
        /// <returns>列表</returns>
        public DataSet GetBaseList(bool isReport, string dateID, string shipID, int pageSize, int pageIndex)
        {
            string sql = @"
                        select vo.ID,vo.Name VoyageName, vo.VoyageLoadID, s.Name ShipName,ro.Name RouteName,s.ID ShipId,
                            StartTime = 
	                            case convert(varchar,vo.BeginDate,120) 
		                            when '1900-01-01' then ''
		                            else convert(varchar,vo.BeginDate,120) 
	                            end,
                            EndTime = 
	                            case convert(varchar,vo.EndDate,120) 
		                            when '1900-01-01' then ''
		                            else convert(varchar,vo.EndDate,120) 
	                            end,
	                        vo.HangciBaseId,OrderNum
                        from Voyage vo, Ship s, Route ro where vo.RouteID = ro.ID and vo.ShipID = s.ID 
                        ";

            if (isReport == false)
            {
                sql += " and vo.ID in ( select VoyageID from HangciBaseInput)";
            }
            if (string.IsNullOrEmpty(dateID) == false)
            {
                DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dateID);
                sql += string.Format(" and DatePart (Year,BeginDate) = {0} and DatePart (Month,BeginDate) = {1} ", dInfo.Year, dInfo.MonthNumOfYear);
            }
            if (string.IsNullOrEmpty(shipID) == false)
            {
                sql += " and ShipID = " + shipID;
            }
            string pagedSQL = CommonHelper.GetPagedSQL(sql, "StartTime", true, pageSize, pageIndex);
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
        /// 获取列表
        /// </summary>
        /// <param name="reportID">燃润报表主键</param>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetVoyageListByReportID(string reportID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HangciBaseID", reportID);
            //            string sql = @"
            //                                    select v.Name VoyageName,v.BeginDate,v.EndDate,r.Distance,ps.Name sName,pe.Name eName,s.Name ShipName,
            //                                        s.Captain,s.ChiefEngineer,s.GeneralManager,datediff(hh,v.BeginDate,v.EndDate) DiffHours
            //                                    from Voyage v, route r,Relation_RoutePort rrps,Relation_RoutePort rrpe,Port ps,Port pe, Ship s
            //                                    where 1=1
            //                                    and v.RouteID = r.ID
            //                                    and r.ID = rrpe.RouteID
            //                                    and r.ID = rrps.RouteID
            //                                    and rrps.PortTypeID = '2'
            //                                    and rrpe.PortTypeID = '4'
            //                                    and rrps.PortID = ps.ID
            //                                    and rrpe.PortID = pe.ID
            //                                    and v.ShipID = s.ID 
            //                                    and v.HangciBaseID = @HangciBaseID
            //                         order by v.BeginDate";

            string sql = @"
                        select *  from V_Voyage where HangciBaseID = @HangciBaseID order by BeginDate";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<VoyageInfo> list = GetListFromReader(dr, false, true);
            return list;
        }


        /// <summary>
        /// 更新航次对应的报表信息
        /// </summary>
        /// <param name="voyageIds"></param>
        /// <param name="baseId"></param>
        public void UpdateVoyage(string voyageIds, string baseId)
        {
            string sql = @"
                update Voyage set HangciBaseID = " + baseId + " where ID in (" + voyageIds + ")";
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 燃润报表删除后删除航次和报表的关联
        /// </summary>
        /// <param name="reportID">燃润报表ID</param>
        public void RanrunDelete(string reportID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HangciBaseID", reportID);

            string sql = @"
                update Voyage set HangciBaseID = '' where HangciBaseID = @HangciBaseID";
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
        }
    }
}


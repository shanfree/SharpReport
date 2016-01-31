/**  版本信息模板在安装目录下，可自行修改。
* HangciBaseInput.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/14 19:30:00   matthewzjq    初版
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
    /// 数据访问类:HangciBaseInput
    /// </summary>
    public partial class HangciBaseInput : DBPersistenceBase<HangciBaseInputInfo>, IHangciBaseInput
    {
        public HangciBaseInput()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM HangciBaseInput WHERE ID = @ID";
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
        /// 获取航次基本信息
        /// </summary>
        /// <returns>列表</returns>
        public IList<HangciBaseInputInfo> GetListByVoyageID(string voyageID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@VoyageID", voyageID);
            string sql = @"select t.* from HangciBaseInput t where t.VoyageID = @VoyageID";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<HangciBaseInputInfo> list = GetListFromReader(dr, false, false);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }

        /// <summary>
        /// 获取船舶燃料消耗统计报表
        /// 参数yyyy mm 格式
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetMonthlyReportData(string year, string month)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@Month", month);

            string sql = @"
                    select s.Name shipName, base3.* from(
	                    select base2.ShipID,base2.ShipComponentID,
	                    sum(base2.MainSlowWorkTime) MainSlowWorkTime,
	                    sum(base2.MainCruiseWorkTime) MainCruiseWorkTime,
	                    sum(base2.VoyageWorkTime) VoyageWorkTime,
	                    sum(base2.FuelConsume) FuelConsume,
	                    sum(base2.DieselConsume) DieselConsume,
	                    sum(base2.OtherConsume) OtherConsume,
	                    sum(base2.Distance) distance,
	                    MIN(base2.BeginDate) beginDate,
	                    MAX(base2.EndDate) EndDate  from(
		                    select v.ShipID,v.ID VoyageId,r.Distance,hbi.ID BaseInputID,
		                    convert(varchar,v.BeginDate,120) BeginDate,
		                    convert(varchar,v.EndDate,120) EndDate,
		                    vc.ShipComponentID,vc.MainSlowWorkTime,vc.MainCruiseWorkTime,
		                    vc.VoyageWorkTime,vc.FuelConsume,vc.DieselConsume,vc.OtherConsume 
		                    from (
			                    select vo.ID from Voyage vo where substring(convert(varchar,vo.EndDate,111),1,4) = @Year 
				                    and substring(convert(varchar,vo.EndDate,111),6,2) = @Month)base, 
				                    Voyage v, HangciBaseInput hbi,VoyageConsume vc,Route r
				                    where v.HangciBaseID = hbi.ID and hbi.ID=vc.BaseInputID and r.ID=v.RouteID
				                    and base.ID = v.ID) base2 group by base2.ShipComponentID,base2.ShipID)base3, Ship s
				                    where base3.ShipID = s.ID";

            return SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param).Tables[0];
        }

        #region 消耗表列表
        /// <summary>
        /// 消耗表列表
        /// </summary>
        /// <param name="dateID">报告期ID，可以为空，显示所有报表</param>
        /// <param name="qShipName">船名，模糊查询</param>
        /// <param name="qStartDate">启航时间，可以为空</param>
        /// <param name="qEndDate">抵港时间，可以为空</param>
        /// <param name="qStartPortID">起发港ID</param>
        /// <param name="qEndPortID">目的港ID</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public DataSet GetBaseInputList(
            string dateID, string qShipName, string qStartDate, string qEndDate, string qStartPortID, string qEndPortID, int pageSize, int pageIndex)
        {
            string sql = @"
                            SELECT 
                            HB.ID,
                            V.ID VoyageID,
                            V.ShipName,
                            V.OrderNum,
                            V.RouteName,
                            V.Name,
                            V.sName,
                            V.eName,
                            V.sPortID,
                            V.ePortID, 
                            V.BeginDate,
                            V.EndDate
                              FROM 
                            dbo.HangciBaseInput HB,V_Voyage V
                            WHERE HB.ID = V.HangciBaseID AND V.ID IN 
                            (
                                SELECT  MIN(ID) FROM Voyage GROUP BY HangciBaseID
                            )";
            //            string sql = @"
            //                Select base.*,p1.Name StartPort,p2.Name EndPort,base2.WorkTime,
            //                    v1.ShipID,s.Name ShipName
            //                    from 
            //                    (select v1.HangciBaseID, MIN(v1.BeginDate) StartTime,MAX(v2.EndDate) EndTime
            //                    from Voyage v1,Voyage v2
            //                    where v1.ID=v2.ID 
            //                    group by v1.HangciBaseID)base, Voyage v1,Voyage v2,Ship s,
            //                    Relation_RoutePort rp1, Relation_RoutePort rp2,Port p1, Port p2,
            //                    (select BaseInputID,SUM(VoyageWorkTime) WorkTime from VoyageConsume group by BaseInputID) base2
            //                    where 1=1 
            //                    and base.HangciBaseID = v1.HangciBaseID and base.StartTime = v1.BeginDate 
            //                    and v1.RouteID = rp1.RouteID and rp1.PortTypeID=2 and rp1.PortID=p1.ID
            //                    and base.HangciBaseID = v2.HangciBaseID and base.EndTime = v2.EndDate
            //                    and v2.RouteID = rp2.RouteID and rp2.PortTypeID=4 and rp2.PortID=p2.ID
            //                    and base.HangciBaseID = base2.BaseInputID and v1.ShipID=s.ID ";
            //报告期以出发时间计算
            if (string.IsNullOrEmpty(dateID) == false)
            {
                DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dateID);
                sql += string.Format(" and DatePart (Year,BeginDate) = {0} and DatePart (Month,BeginDate) = {1} ", dInfo.Year, dInfo.MonthNumOfYear);
            }

            if (string.IsNullOrEmpty(qShipName) == false)
            {
                sql += " and V.ShipName like '%" + qShipName + "%'";
            }
            if (string.IsNullOrEmpty(qStartPortID) == false)
            {
                sql += " and sPortID = " + qStartPortID;
            }
            if (string.IsNullOrEmpty(qEndPortID) == false)
            {
                sql += " and ePortID = " + qEndPortID;
            }
            if (string.IsNullOrEmpty(qStartDate) == false)
            {
                sql += " and BeginDate >= CONVERT(datetime,'" + qStartDate + "')";
            }
            if (string.IsNullOrEmpty(qEndDate) == false)
            {
                sql += " and EndDate <= CONVERT(datetime,'" + qEndDate + "')";
            }

            string pagedSQL = CommonHelper.GetPagedSQL(sql, "BeginDate", true, pageSize, pageIndex);
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
        #endregion
    }
}

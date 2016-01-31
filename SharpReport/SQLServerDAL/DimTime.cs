/********************************************************************************************
 * 文件名称:	DimTime.cs
 * 设计人员:	欧照阳
 * 设计时间:	2007-02-22
 * 功能描述:	时间定义数据层
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian Sirc
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

using SIRC.Framework.Utility;
using Sirc.SharpReport.IDAL;
using Sirc.SharpReport.Model;

namespace Sirc.SharpReport.SQLServerDAL
{
    /// <summary>
    /// 时间定义
    /// </summary>
    public class DimTime : IDimTime
    {
        /// <summary>
        /// 得到年份列表
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeYearList()
        {
            string sql = "SELECT DISTINCT(Year) FROM DimTime";

            DataSet ds = SqlHelper.ExecuteDataset(DBConnection.ConnectionString, CommandType.Text, sql);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据年份得到季度列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeQuarterList(string year)
        {
            string sql = "SELECT DISTINCT(QuarterNumOfYear) FROM DimTime WHERE Year = @Year";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year", year);

            DataSet ds = SqlHelper.ExecuteDataset(DBConnection.ConnectionString, CommandType.Text, sql, param);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据年份得到月份列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeMonthList(string year)
        {
            string sql = "SELECT DISTINCT MonthNumOfYear,ID FROM DimTime WHERE Year = @Year";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year", year);

            DataSet ds = SqlHelper.ExecuteDataset(DBConnection.ConnectionString, CommandType.Text, sql, param);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据时间ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DimTimeInfo GetDimTimeInfo(string id)
        {
            string sql = "select * from DimTime where ID = @ID";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            SqlDataReader xr = SqlHelper.ExecuteReader(DBConnection.ConnectionString, CommandType.Text, sql, param);
            IList<DimTimeInfo> list = getIListFromSqlDataReader(xr);
            if (null == list||list.Count<=0)
            {//修改xsn 添加list.Count<=0判断
                return null;
            }
            return list[0];
        }

        private IList<DimTimeInfo> getIListFromSqlDataReader(SqlDataReader xr)
        {
            IList<DimTimeInfo> ilist = new List<DimTimeInfo>();

            while (xr.Read())
            {
                DimTimeInfo tInfo = new DimTimeInfo();

                string tID = Convert.ToString(xr["ID"]);
                tInfo = new DimTimeInfo(tID);
                tInfo.MonthName = Convert.ToString(xr["MonthName"]);
                tInfo.MonthNumOfYear = Convert.ToInt32(xr["MonthNumOfYear"]);
                tInfo.QuarterName = Convert.ToString(xr["QuarterName"]);
                tInfo.QuarterNumOfYear = Convert.ToInt32(xr["QuarterNumOfYear"]);
                tInfo.Year = Convert.ToInt32(xr["Year"]);
                ilist.Add(tInfo);
            }
            return ilist;

        }
        /// <summary>
        /// 获取去年的时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isMonth">true-月,false-季</param>
        /// <returns></returns>
        public DimTimeInfo GetLastDimTime(string id, bool isMonth)
        {
            DimTimeInfo tInfo = GetDimTimeInfo(id);
            string year = (tInfo.Year - 1).ToString();
            string lastId = "";
            if (isMonth)
            {
                lastId = GetIDByMonth(year, tInfo.MonthNumOfYear.ToString());
            }
            else
            {
                lastId = GetIDByQuarter(year, tInfo.QuarterNumOfYear.ToString());
            }
            return GetDimTimeInfo(lastId);
        }
        /// <summary>
        /// 获取前年的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DimTimeInfo GetTheYearBeforeLastDimTimeInfo(string id)
        {
            DimTimeInfo tInfo = GetDimTimeInfo(id);
            string year = (tInfo.Year - 2).ToString();
            string lastId = GetIDByQuarter(year, tInfo.QuarterNumOfYear.ToString());
            return GetDimTimeInfo(lastId);
        }
        /// <summary>
        /// 得到季度的标识ID
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="quarter">季度的序号</param>
        /// <returns></returns>
        public string GetIDByQuarter(string year, string quarter)
        {
            string sql = "select top 1 ID from DimTime where Year = @Year and QuarterNumOfYear = @Quarter";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@Quarter", quarter);

            string id = SqlHelper.ExecuteScalar(DBConnection.ConnectionString, CommandType.Text, sql, param).ToString();

            return id;
        }

        /// <summary>
        /// 得到月份的标识ID
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public string GetIDByMonth(string year, string month)
        {
            string sql = "select ID from DimTime where Year = @Year and MonthNumOfYear = @Month";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", year);
            param[1] = new SqlParameter("@Month", month);

            string id = SqlHelper.ExecuteScalar(DBConnection.ConnectionString, CommandType.Text, sql, param).ToString();

            return id;

        }

    }
}

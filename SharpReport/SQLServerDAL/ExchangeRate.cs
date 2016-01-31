/**  版本信息模板在安装目录下，可自行修改。
* ExchangeRate.cs
*
* 功 能： N/A
* 类 名： ExchangeRate
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
    /// 数据访问类:ExchangeRate
    /// </summary>
    public partial class ExchangeRate : DBPersistenceBase<ExchangeRateInfo>, IExchangeRate
    {
        /// <summary>
        /// 
        /// </summary>
        public ExchangeRate()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM ExchangeRate WHERE ID = @ID";
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
        /// <param name="currencyID"></param>
        /// <param name="dimID"></param>
        /// <returns>列表</returns>
        public IList<ExchangeRateInfo> GetList(string currencyID, string dimID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CurrencyID", currencyID);
            string sql = @"select  * from 
                                dbo.V_ExchangeRate
                                where 
                                CurrencyID = @CurrencyID
                        ";
            string typeClause = string.Empty;
            if (string.IsNullOrEmpty(dimID) == false)
            {
                typeClause = " and DimTimeID =  " + dimID;
            }
            sql = string.Format(sql, typeClause);

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<ExchangeRateInfo> eList = GetListFromReader(dr, false, false);
            return eList;
        }

                /// <summary>
        /// 获取对应比重某月的汇率
        /// </summary>
        /// <param name="currencyID"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public ExchangeRateInfo GetInfo(string currencyID, int year, int month)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CurrencyID", currencyID);
            param[1] = new SqlParameter("@Year", year);
            param[2] = new SqlParameter("@Month", month);
            string sql = @"select  * from 
                                dbo.V_ExchangeRate
                                where 
                                CurrencyID = @CurrencyID AND
                                Year = @Year AND
                                MonthNumOfYear = @Month
                        ";

            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<ExchangeRateInfo> eList = GetListFromReader(dr, false, false);
            if (eList == null || eList.Count == 0)
            {
                return null;
            }
            return eList[0];
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="currencyID"></param>
        /// <param name="dimID"></param>
        /// <returns>列表</returns>
        public ExchangeRateInfo GetInfo(string currencyID, string dimID)
        {
            IList<ExchangeRateInfo> eList = GetList(currencyID, dimID);
            if (eList == null || eList.Count == 0)
            {
                ExchangeRateInfo eInfo = new ExchangeRateInfo();
                // 人民币返回1：1
                if (currencyID == "1")
                {
                    eInfo.Rate = "1";
                }
                return eInfo;
            }
            return eList[0];
        }
    }
}


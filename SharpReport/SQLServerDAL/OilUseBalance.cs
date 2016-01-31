/**  版本信息模板在安装目录下，可自行修改。
* OilUseBalance.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/14 23:00:00   matthewzjq    初版
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

namespace Sirc.SharpReport.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:OilType
    /// </summary>
    public partial class OilUseBalance : DBPersistenceBase<OilUseBalanceInfo>, IOilUseBalance
    {
        public OilUseBalance()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM OilUseBalance WHERE ID = @ID";
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
        /// <returns>列表</returns>
        public DataSet GetOilBalanceInfo(string baseId)
        {
            string sql = @"
                select oub1.ID ID1,oub1.Remaining Remaining1,oub1.Addition Addition1,oub1.Consuming Consuming1,oub1.Balance Balance1,
                       oub2.ID ID2,oub2.Remaining Remaining2,oub2.Addition Addition2,oub2.Consuming Consuming2,oub2.Balance Balance2,
                       oub3.ID ID3,oub3.Remaining Remaining3,oub3.Addition Addition3,oub3.Consuming Consuming3,oub3.Balance Balance3,
                       oub4.ID ID4,oub4.Remaining Remaining4,oub4.Addition Addition4,oub4.Consuming Consuming4,oub4.Balance Balance4,
                       oub5.ID ID5,oub5.Remaining Remaining5,oub5.Addition Addition5,oub5.Consuming Consuming5,oub5.Balance Balance5,
                       oub6.ID ID6,oub6.Remaining Remaining6,oub6.Addition Addition6,oub6.Consuming Consuming6,oub6.Balance Balance6,
                       oub7.ID ID7,oub7.Remaining Remaining7,oub7.Addition Addition7,oub7.Consuming Consuming7,oub7.Balance Balance7,
                       oub8.ID ID8,oub8.Remaining Remaining8,oub8.Addition Addition8,oub8.Consuming Consuming8,oub8.Balance Balance8,
                       oub9.ID ID9,oub9.Remaining Remaining9,oub9.Addition Addition9,oub9.Consuming Consuming9,oub9.Balance Balance9
                        

                from   OilUseBalance oub1, 
                       OilUseBalance oub2, 
                       OilUseBalance oub3, 
                       OilUseBalance oub4, 
                       OilUseBalance oub5, 
                       OilUseBalance oub6,
                       OilUseBalance oub7,
                       OilUseBalance oub8,
                       OilUseBalance oub9, 
                       HangciBaseInput hbi 

               where oub1.BaseInputID = hbi.ID 
                      and oub2.BaseInputID = hbi.ID 
                      and oub3.BaseInputID = hbi.ID
                      and oub4.BaseInputID = hbi.ID
                      and oub5.BaseInputID = hbi.ID
                      and oub6.BaseInputID = hbi.ID
                      and oub7.BaseInputID = hbi.ID
                      and oub8.BaseInputID = hbi.ID
                      and oub9.BaseInputID = hbi.ID
                      and oub1.OilTypeID=1
                      and oub2.OilTypeID=2
                      and oub3.OilTypeID=3
                      and oub4.OilTypeID=4
                      and oub5.OilTypeID=5
                      and oub6.OilTypeID=6
                      and oub7.OilTypeID=8
                      and oub8.OilTypeID=9
                      and oub9.OilTypeID=7 ";

            if (!baseId.Equals(""))
            {
                sql += " and hbi.ID = " + baseId;
            }

            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);
            return ds;
        }
    }
}

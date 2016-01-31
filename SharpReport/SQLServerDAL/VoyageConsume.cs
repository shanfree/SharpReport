/**  版本信息模板在安装目录下，可自行修改。
* VoyageConsume.cs
*
* 功 能： N/A
* 类 名： VoyageConsume
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 23:39:41   N/A    初版
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
    /// 数据访问类:VoyageConsume
    /// </summary>
    public partial class VoyageConsume : DBPersistenceBase<VoyageConsumeInfo>, IVoyageConsume
    {
        public VoyageConsume()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM VoyageConsume WHERE ID = @ID";
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
        public DataSet GetVoyageConsumeInfo(string baseId)
        {
            string sql = @"
                select 
                    vc1.ID ID1,vc1.MainSlowWorkTime MainSlowWorkTime1, vc1.MainCruiseWorkTime MainCruiseWorkTime1, vc1.VoyageWorkTime VoyageWorkTime1, 
                    vc1.FuelConsume FuelConsume1, vc1.DieselConsume DieselConsume1, vc1.OtherConsume OtherConsume1, 
                    vc2.ID ID2,vc2.MainSlowWorkTime MainSlowWorkTime2, vc2.MainCruiseWorkTime MainCruiseWorkTime2, vc2.VoyageWorkTime VoyageWorkTime2, 
                    vc2.FuelConsume FuelConsume2, vc2.DieselConsume DieselConsume2, vc2.OtherConsume OtherConsume2, 
                    vc3.ID ID3,vc3.MainSlowWorkTime MainSlowWorkTime3, vc3.MainCruiseWorkTime MainCruiseWorkTime3, vc3.VoyageWorkTime VoyageWorkTime3, 
                    vc3.FuelConsume FuelConsume3, vc3.DieselConsume DieselConsume3, vc3.OtherConsume OtherConsume3, 
                    vc4.ID ID4,vc4.MainSlowWorkTime MainSlowWorkTime4, vc4.MainCruiseWorkTime MainCruiseWorkTime4, vc4.VoyageWorkTime VoyageWorkTime4, 
                    vc4.FuelConsume FuelConsume4, vc4.DieselConsume DieselConsume4, vc4.OtherConsume OtherConsume4, 
                    vc5.ID ID5,vc5.MainSlowWorkTime MainSlowWorkTime5, vc5.MainCruiseWorkTime MainCruiseWorkTime5, vc5.VoyageWorkTime VoyageWorkTime5, 
                    vc5.FuelConsume FuelConsume5, vc5.DieselConsume DieselConsume5, vc5.OtherConsume OtherConsume5
    
                from VoyageConsume vc1,VoyageConsume vc2,VoyageConsume vc3,VoyageConsume vc4,VoyageConsume vc5,HangciBaseInput hbi 

                where   vc1.BaseInputID = hbi.ID and vc1.ShipComponentID = 1
                        and vc2.BaseInputID = hbi.ID and vc2.ShipComponentID = 2
                        and vc3.BaseInputID = hbi.ID and vc3.ShipComponentID = 3
                        and vc4.BaseInputID = hbi.ID and vc4.ShipComponentID = 4
                        and vc5.BaseInputID = hbi.ID and vc5.ShipComponentID = 5 ";

            if (!baseId.Equals(""))
            {
                sql += " and hbi.ID = " + baseId;
            }

            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);
            return ds;
        }
    }
}

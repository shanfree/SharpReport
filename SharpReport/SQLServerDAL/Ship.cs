/**  版本信息模板在安装目录下，可自行修改。
* Ship.cs
*
* 功 能： N/A
* 类 名： Ship
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

namespace Sirc.SharpReport.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Ship
    /// </summary>
    public partial class Ship : DBPersistenceBase<ShipInfo>, IShip
    {
        public Ship()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Ship WHERE ID = @ID";
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
        /// 根据报告期获取收入报表
        /// </summary>
        /// <param name="dateID">通过报告期查询，为空则返回所有</param>
        /// <param name="shipID">通过船舶查询，为空则返回所有</param>
        /// <param name="reportType">报表类型，为空则返回所有报表</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet GetIncomeMonthReport(string dateID, string shipID, int pageSize, int pageIndex)
        {
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dateID);
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", dInfo.Year.ToString());
            param[1] = new SqlParameter("@Month", dInfo.MonthNumOfYear.ToString());
            //获取所有子栏目树节点

            #region sql
            string sql = @"
                    SELECT [ID],[Name],[Code],RentDate,OperationType,
                    (
                        isnull((
                            select count(1) from dbo.Voyage V
                            where ShipID = S.ID 
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 运行航次,
                    (
                        isnull((
                            select sum(LCLAmount) from dbo.VoyageLCL,Voyage V
                            where VoyageLCL.VoyageID = V.ID AND V.ShipID = S.ID 
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 承运货量,
                    (
                        isnull((
                            select sum(Amount) from dbo.VoyageLCL,Voyage V
                            where VoyageLCL.VoyageID = V.ID AND V.ShipID = S.ID AND CurrencyID = 2
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 散货美元收入,
                    (
                        isnull((
                            select sum(Amount) from dbo.VoyageLCL,Voyage V
                            where VoyageLCL.VoyageID = V.ID AND V.ShipID = S.ID AND CurrencyID = 1
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 散货人民币收入,
                    (
                        isnull((
                            select sum(TotalStand) from dbo.VoyageLoad,Voyage V
                            where VoyageLoad.VoyageID = V.ID AND V.ShipID = S.ID 
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 承运箱量,
                    (
                        isnull((
                            select sum(Amount) from dbo.VoyageFCL,Voyage V
                            where VoyageFCL.VoyageID = V.ID AND V.ShipID = S.ID AND CurrencyID = 2
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 集装箱美元收入,
                    (
                        isnull((
                            select sum(Amount) from dbo.VoyageFCL,Voyage V
                            where VoyageFCL.VoyageID = V.ID AND V.ShipID = S.ID AND CurrencyID = 1
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 集装箱人民币收入,
                    (
                        isnull((
                            select sum(RentDays) from dbo.RentShipReport V
                            where ShipID = S.ID 
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 出租天数,
                    (
                        isnull((
                            select sum(Amount) from dbo.RentShipReport V
                            where ShipID = S.ID AND CurrencyID = 2
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 出租美元收入,
                    (
                        isnull((
                            select sum(Amount) from dbo.RentShipReport V
                            where ShipID = S.ID AND CurrencyID = 1
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 出租人民币收入,
                    (
                        isnull((
                            select sum(Amount) from dbo.V_VoyageOther V
                            where ShipID = S.ID AND CurrencyID = 1
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 其他人民币收入,
                    (
                        isnull((
                            select sum(Amount) from dbo.V_VoyageOther V
                            where ShipID = S.ID AND CurrencyID = 2
                            and DatePart (Year,V.EndDate) = @Year and DatePart (Month,V.EndDate) = @Month
                            ),0.00)
                    ) as 其他美元收入
                    FROM    dbo.Ship S
                    WHERE    S.Enable = 1 AND ((S.OperationType = '2' AND S.RentDate > GETDATE()) OR S.OperationType = '1')   {0}                                 
                        ";
            #endregion

            string shipClause = string.Empty;
            if (string.IsNullOrEmpty(shipID) == false)
            {
                shipClause = "AND S.ID = " + shipID;
            }
            sql = string.Format(sql, shipClause);

            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, param);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                // 总页数以自定义列表类型CustomList封装
                CustomDataSet cDS = PageAmoutHelper<object>.GetCutomDataSet(this.ConnectionString, sql, param, pageSize, ds);
                return cDS;
            }
            else
            {
                return null;
            }
        }
    }
}


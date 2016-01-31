/**  版本信息模板在安装目录下，可自行修改。
* RentShipReport.cs
*
* 功 能： N/A
* 类 名： RentShipReport
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Sirc.SharpReport.Model;
using Sirc.SharpReport.DALFactory;
using Sirc.SharpReport.IDAL;
using SIRC.Framework.Utility;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 备件
    /// </summary>
    public class RentShipReport
    {
        private readonly IRentShipReport dal = DataAccess.CreateRentShipReport();

        public RentShipReport()
        { }

        /// <summary>
        ///租金、通讯费、绑扎锁具、其他合计
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetAmout(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("发票主键不能为空。");
            }
            RentShipReportInfo vInfo = GetByID(ID);
            // 运费、滞期、速遣合计
            return GetAmout(vInfo);
        }
        public string GetAmout(RentShipReportInfo vInfo)
        {
            // 运费、滞期、速遣合计
            decimal dPrice = Convert.ToDecimal(vInfo.Price);
            decimal dDays = Convert.ToDecimal(vInfo.RealDays);
            decimal dComun = Convert.ToDecimal(vInfo.CommunicateFee);
            decimal dLockFee = Convert.ToDecimal(vInfo.LockFee);
            decimal dOtherFee = Convert.ToDecimal(vInfo.OtherFee);
            decimal dTotal = dPrice * dDays + dComun + dLockFee + dOtherFee;
            return dTotal.ToString();
        }

        /// <summary>
        /// 获取发票的等额人民币价值,汇率按照开票时间计算
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetRMBAmout(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("发票主键不能为空。");
            }
            RentShipReportInfo vInfo = GetByID(ID);
            // 运费、滞期、速遣合计
            string total = GetAmout(ID);
            decimal dTotal = decimal.Parse(total);

            if (vInfo.CurrencyID != "1" && vInfo.InputDate == null)
            {
                return "--";
            }
            decimal amount = new ExchangeRate().GetRMB(total, vInfo.CurrencyID, vInfo.CreateTime);
            return amount.ToString();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询</param>
        /// <param name="shipID">通过船舶查询</param>
        /// <returns>列表</returns>
        public DataSet GetList(string year, string month, string shipID, int pageSize, int pageIndex)
        {
            int i = 0;
            //if (string.IsNullOrEmpty(dateID) == false && int.TryParse(dateID, out i) == false)
            //{
            //    throw new ArgumentNullException("参数dateID不能转化为整型。");
            //}
            if (string.IsNullOrEmpty(shipID) == false && int.TryParse(shipID, out i) == false)
            {
                throw new ArgumentNullException("参数shipID不能转化为整型。");
            }
            return dal.GetList(year, month, shipID, pageSize, pageIndex);
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<RentShipReportInfo> GetList(string shipID)
        {
            if (string.IsNullOrEmpty(shipID))
            {
                throw new ArgumentNullException("参数shipID不能为空。");
            }
            return dal.GetList(shipID);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<RentShipReportInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public RentShipReportInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID, false, true);
        }

        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(RentShipReportInfo cInfo)
        {
            string msg = string.Empty;
            //int restInt = 0;
            //int equalInt = 0;
            //if (int.TryParse(cInfo.Rest, out restInt) && int.TryParse(cInfo.EqualTo, out equalInt))
            //{
            //    if (restInt > equalInt)
            //    {
            //        throw new ArgumentException("特殊的柜数目必须小于或者等于标准柜数目。");
            //    }
            //}
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(RentShipReportInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            //string msg = string.Empty;
            //int restInt = 0;
            //int equalInt = 0;
            //if (int.TryParse(cInfo.Rest, out restInt) && int.TryParse(cInfo.EqualTo, out equalInt))
            //{
            //    if (restInt > equalInt)
            //    {
            //        throw new ArgumentException("特殊的柜数目必须小于或者等于标准柜数目。");
            //    }
            //}
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            RentShipReportInfo cInfo = new RentShipReportInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


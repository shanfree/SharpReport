/**  版本信息模板在安装目录下，可自行修改。
* RentContainerReport.cs
*
* 功 能： N/A
* 类 名： RentContainerReport
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
    public class RentContainerReport
    {
        private readonly IRentContainerReport dal = DataAccess.CreateRentContainerReport();

        public RentContainerReport()
        { }

        /// <summary>
        /// 获得货柜出租报表各个类型货柜的总租金
        /// </summary>
        /// <param name="reportID"></param>
        /// <returns></returns>
        public string GetAmout(string reportID)
        {
           // RentContainerReportInfo rpInfo = new RentContainerReport().GetByID(reportID);
            decimal total = 0; 
            IList<RentContainerInfo> rList = new RentContainer().GetList(reportID);
            foreach (RentContainerInfo rInfo in rList)
            {
                total += Convert.ToDecimal(rInfo.RentFee);
            }
            //decimal dTotal = dPrice * dDays + dComun + dLockFee + dOtherFee;
            //return dTotal.ToString();
            return total.ToString();
        }

        /// <summary>
        /// 获取发票的等额人民币价值,汇率按照开票时间计算
        /// </summary>
        /// <param name="reportID"></param>
        /// <returns></returns>
        public string GetRMBAmout(string reportID)
        {
            if (string.IsNullOrEmpty(reportID))
            {
                throw new ArgumentNullException("reportID不能为空。");
            }
            RentContainerReportInfo vInfo = GetByID(reportID);
            // 运费、滞期、速遣合计
            string total = GetAmout(reportID);
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
        /// <param name="dateID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet GetList(string dateID,int pageSize, int pageIndex)
        {
            int i = 0;
            if (string.IsNullOrEmpty(dateID) == false && int.TryParse(dateID, out i) == false)
            {
                throw new ArgumentNullException("参数dateID不能转化为整型。");
            }
            return dal.GetList(dateID, pageSize, pageIndex);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<RentContainerReportInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public RentContainerReportInfo GetByID(string ID)
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
        public string Add(RentContainerReportInfo cInfo)
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
        public void Update(RentContainerReportInfo cInfo)
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
            RentContainerReportInfo cInfo = new RentContainerReportInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


/**  版本信息模板在安装目录下，可自行修改。
* VoyageFCL.cs
*
* 功 能： N/A
* 类 名： VoyageFCL
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
    public partial class VoyageFCL
    {
        private readonly IVoyageFCL dal = DataAccess.CreateVoyageFCL();
        /// <summary>
        /// 
        /// </summary>
        public VoyageFCL()
        { }
        /// <summary>
        /// 获取发票的等额人民币价值,汇率按照开票时间计算
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetAmout(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("发票主键不能为空。");
            }
            VoyageFCLInfo vInfo = GetByID(ID);

            return GetAmout(vInfo);
        }
        /// <summary>
        /// 航次船舶租金，包干燃油，箱费用，增减港口费用，船舶延时作业费，港口装卸费，港口理货费
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetAmout(VoyageFCLInfo vInfo)
        {
            string total = NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                NumericHandler.StringAdd(
                vInfo.Fee, vInfo.BeginFee),
                vInfo.EndFee),
                vInfo.OilFee),
                vInfo.Box),
                vInfo.Tally),
                vInfo.Subsidize),
                vInfo.BookFee),
                vInfo.BranchOther),
                vInfo.Other);
            decimal dTotal = decimal.Parse(total);

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
            VoyageFCLInfo vInfo = GetByID(ID);
            return GetRMBAmout(vInfo);
        }
        /// <summary>
        /// 获取发票的等额人民币价值,汇率按照开票时间计算
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetRMBAmout(VoyageFCLInfo vInfo)
        {
            // 运费、滞期、速遣合计
            string total = GetAmout(vInfo);
            decimal dTotal = decimal.Parse(total);

            if (vInfo.CurrencyID != "1" && vInfo.InputDate == null)
            {
                return "--";
            }
            decimal amount = new ExchangeRate().GetRMB(total, vInfo.CurrencyID, vInfo.CreateTime);
            return amount.ToString();
        }


        /// <summary>
        /// 根据航次ID获取实体
        /// </summary>
        /// <param name="voyageID">实体主键</param>
        /// <returns>实体</returns>
        public VoyageFCLInfo GetByVoyageID(string voyageID)
        {
            if (string.IsNullOrEmpty(voyageID))
            {
                throw new ArgumentNullException("航次ID不能为空。");
            }
            return dal.GetByVoyageID(voyageID);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<VoyageFCLInfo> GetList(string shipID)
        {
            if (string.IsNullOrEmpty(shipID))
            {
                throw new ArgumentNullException("参数shipID不能为空。");
            }
            return dal.GetList(shipID);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询</param>
        /// <param name="shipID">通过船舶查询</param>
        /// <param name="reportType"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns>列表</returns>
        public DataSet GetList(string dateID, string shipID, string reportType, int pageSize, int pageIndex)
        {
            int i = 0;
            if (string.IsNullOrEmpty(dateID) == false && int.TryParse(dateID, out i) == false)
            {
                throw new ArgumentNullException("参数dateID不能转化为整型。");
            }
            if (string.IsNullOrEmpty(shipID) == false && int.TryParse(shipID, out i) == false)
            {
                throw new ArgumentNullException("参数shipID不能转化为整型。");
            }
            return dal.GetList(dateID, shipID, reportType, pageSize, pageIndex);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageFCLInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public VoyageFCLInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(VoyageFCLInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(VoyageFCLInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            VoyageFCLInfo cInfo = new VoyageFCLInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


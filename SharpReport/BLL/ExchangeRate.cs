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
using Sirc.SharpReport.IDAL;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;
using Sirc.SharpReport.DALFactory;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 数据访问类:ExchangeRate
    /// </summary>
    public partial class ExchangeRate
    {
        private readonly IExchangeRate dal = DataAccess.CreateExchangeRate();

        public ExchangeRate()
        { }

        /// <summary>
        /// 获取某个货币金额的等额人民币
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="currencyID">货币种类</param>
        /// <param name="date">汇率结算日期</param>
        /// <returns>等额人民币</returns>
        public decimal GetRMB(string amount, string currencyID, DateTime date)
        {
            ExchangeRateInfo eInfo = GetInfo(currencyID, date.Year, date.Month);
            string strRate = (eInfo.CurrencyID == "1") ? "1" : eInfo.Rate;
            decimal amout = Convert.ToDecimal(amount);
            decimal rate = Convert.ToDecimal(strRate);
            //四舍六入五成双
            decimal localAmout = Math.Round(amout / rate, 2);
            return localAmout;
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="currencyID"></param>
        /// <param name="dimID"></param>
        /// <returns>列表</returns>
        public IList<ExchangeRateInfo> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="currencyID"></param>
        /// <param name="dimID"></param>
        /// <returns>列表</returns>
        public IList<ExchangeRateInfo> GetList(string currencyID)
        {
            if (string.IsNullOrEmpty(currencyID))
            {
                throw new ArgumentNullException("currencyID不能为空。");
            }
            return dal.GetList(currencyID, string.Empty);
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="currencyID"></param>
        /// <param name="dimID"></param>
        /// <returns>列表</returns>
        public ExchangeRateInfo GetInfo(string currencyID, string dimID)
        {
            if (string.IsNullOrEmpty(currencyID))
            {
                throw new ArgumentNullException("currencyID不能为空。");
            }
            if (string.IsNullOrEmpty(dimID))
            {
                throw new ArgumentNullException("dimID不能为空。");
            }
            return dal.GetInfo(currencyID, dimID);
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
            if (string.IsNullOrEmpty(currencyID))
            {
                throw new ArgumentNullException("currencyID不能为空。");
            }
            if (year < 1970 || year > 2050 || month > 12 || month < 1)
            {
                throw new ArgumentNullException("年份或者月份超过有效期。");
            }
            ExchangeRateInfo eInfo = new ExchangeRateInfo();
            if (currencyID == "1")
            {
                eInfo.CurrencyID = currencyID;
                eInfo.Rate = "1";
            }
            else
            {
                eInfo = dal.GetInfo(currencyID, year, month);
            }
            return eInfo;
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public ExchangeRateInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加船舶
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(ExchangeRateInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新船舶
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(ExchangeRateInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加船舶
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            ExchangeRateInfo cInfo = new ExchangeRateInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion

    }
}


/**  版本信息模板在安装目录下，可自行修改。
* Invoice.cs
*
* 功 能： N/A
* 类 名： Invoice
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

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 发票
    /// </summary>
    public partial class Invoice
    {
        private readonly IInvoice dal = DataAccess.CreateInvoice();
        /// <summary>
        /// 发票
        /// </summary>
        public Invoice()
        { }

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
            InvoiceInfo vInfo = new Invoice().GetByID(ID);
            ExchangeRateInfo eInfo = new ExchangeRate().GetInfo(vInfo.CurrencyID, vInfo.InputDate.Year, vInfo.InputDate.Month);
            string strRate = (eInfo.CurrencyID == "1") ? "1" : eInfo.Rate;
            decimal amout = Convert.ToDecimal(vInfo.Amout);
            decimal rate = Convert.ToDecimal(strRate);
            //四舍六入五成双
            decimal localAmout = Math.Round(amout / rate, 2);
            return localAmout.ToString();
        }

        /// <summary>
        /// 获取发票的汇率按照开票时间计算
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetExchangeRate(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("发票主键不能为空。");
            }
            InvoiceInfo vInfo = new Invoice().GetByID(ID);
            if (vInfo.CurrencyID == "1")
            {
                return "1";
            }
            ExchangeRateInfo eInfo = new ExchangeRate().GetInfo(vInfo.CurrencyID, vInfo.InputDate.Year, vInfo.InputDate.Month);
            return eInfo.Rate.ToString();
        }


        /// <summary>
        /// 获取报表的发票列表
        /// </summary>
        /// <param name="reportType">报表类型</param>
        /// <param name="keyID">报表主键</param>
        /// <returns></returns>
        public IList<InvoiceInfo> GetInvoiceListAddBlank(string reportType, string keyID)
        {
            if (string.IsNullOrEmpty(reportType))
            {
                throw new ArgumentNullException("报表类型不能为空。");
            }
            IList<InvoiceInfo> list = new List<InvoiceInfo>();
            if (string.IsNullOrEmpty(keyID) == false)
            {
                list = dal.GetInvoiceList(reportType, keyID);
            }
            list.Add(new InvoiceInfo());
            return list;
        }

        #region 根据发票编码定位到报表
        /// <summary>
        /// 根据发票编号获取实体
        /// </summary>
        /// <param name="number">发票编号</param>
        /// <returns>实体</returns>
        public IList<InvoiceInfo> GetListByNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("发票编号不能为空。");
            }
            return dal.GetByNumber(number);
        }
        #endregion

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<InvoiceInfo> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public InvoiceInfo GetByID(string ID)
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
        public string Add(InvoiceInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 添加发票
        /// </summary>
        /// <param name="number">发票编号</param>
        /// <param name="amout">金额</param>
        /// <param name="currencyID">币种</param>
        /// <param name="rate">增值税点</param>
        /// <param name="inputDate">开票时间</param>
        /// <param name="personName">报销人</param>
        /// <param name="reportType"><seealso cref="ReportCatalog"/>报表类型</param>
        /// <param name="keyID">报表主键</param>
        public void Add(string number, string amout, string currencyID, string rate, DateTime inputDate, string personName, string reportType, string keyID)
        {
            InvoiceInfo cInfo = new InvoiceInfo();
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("发票编号不能为空。");
            }
            if (string.IsNullOrEmpty(amout))
            {
                throw new ArgumentNullException("发票金额不能为空。");
            }
            if (string.IsNullOrEmpty(currencyID))
            {
                throw new ArgumentNullException("发票币种不能为空。");
            }
            if (string.IsNullOrEmpty(rate))
            {
                throw new ArgumentNullException("发票税率不能为空。");
            }

            cInfo.Number = number;
            cInfo.Amout = amout;
            cInfo.CurrencyID = currencyID;
            cInfo.Rate = rate;
            cInfo.InputDate = inputDate;
            cInfo.PersonName = personName;
            cInfo.ReportType = reportType;
            cInfo.KeyID = keyID;
            dal.Add(cInfo);
        }

        /// <summary>
        /// 更新发票
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="number">发票编号</param>
        /// <param name="amout">金额</param>
        /// <param name="currencyID">币种</param>
        /// <param name="rate">增值税点</param>
        /// <param name="inputDate">开票时间</param>
        /// <param name="personName">报销人</param>
        public void Update(string id, string number, string amout, string currencyID, string rate, DateTime inputDate, string personName)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("发票编号不能为空。");
            }
            if (string.IsNullOrEmpty(amout))
            {
                throw new ArgumentNullException("发票金额不能为空。");
            }
            if (string.IsNullOrEmpty(currencyID))
            {
                throw new ArgumentNullException("发票币种不能为空。");
            }
            if (string.IsNullOrEmpty(rate))
            {
                throw new ArgumentNullException("发票税率不能为空。");
            }
            InvoiceInfo cInfo = GetByID(id);
            cInfo.Number = number;
            cInfo.Amout = amout;
            cInfo.CurrencyID = currencyID;
            cInfo.Rate = rate;
            cInfo.InputDate = inputDate;
            cInfo.PersonName = personName;
            dal.Update(cInfo);
        }
        /// <summary>
        /// 更新发票
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        public void Update(string id, string url)
        {
            InvoiceInfo cInfo = GetByID(id);
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            cInfo.URL = url;
            dal.Update(cInfo);
        }

        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            InvoiceInfo cInfo = new InvoiceInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


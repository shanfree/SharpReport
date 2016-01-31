/**  版本信息模板在安装目录下，可自行修改。
* Voyage.cs
*
* 功 能： N/A
* 类 名： Voyage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using SIRC.Framework.Utility;
namespace Sirc.SharpReport.Model
{
    /// <summary>
    /// Voyage:航次(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "VoyageLCL", ExtendName = "V_VoyageLCL")]
    public partial class VoyageLCLInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public VoyageLCLInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public VoyageLCLInfo(string ID)
        {
            this._id = ID;
        }

        #region Model

        #region 基本
        private string _id;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _VoyageID;
        /// <summary>
        /// 所在航次
        /// </summary>
        [Persistence(ColumnName = "VoyageID")]
        public string VoyageID
        {
            get { return _VoyageID; }
            set { _VoyageID = value; }
        }
        /// <summary>
        /// 运费：
        /// </summary>
        public string Fee
        {
            get
            {
                    decimal fLCLAmountReal = decimal.Parse(LCLAmountReal);
                    decimal fLCLPrice = decimal.Parse(LCLPrice);
                    return (fLCLAmountReal * fLCLPrice).ToString();
            }
        }

        private string _Amount = "0";
        /// <summary>
        /// 总运费：
        /// </summary>
        [Persistence(ColumnName = "Amount")]
        public string Amount
        {
            get 
            {
                return _Amount; 
            }
            set { _Amount = value; }
        }

        private string _currencyID = "1";
        /// <summary>
        /// 币种主键，默认1为人民币
        /// </summary>
        [Persistence(ColumnName = "CurrencyID")]
        public string CurrencyID
        {
            set { _currencyID = value; }
            get { return _currencyID; }
        }
        private string _User1 = "";
        /// <summary>
        /// 主管
        /// </summary>
        [Persistence(ColumnName = "User1")]
        public string User1
        {
            set { _User1 = value; }
            get { return _User1; }
        }
        private string _User2 = "";
        /// <summary>
        /// 审核
        /// </summary>
        [Persistence(ColumnName = "User2")]
        public string User2
        {
            set { _User2 = value; }
            get { return _User2; }
        }
        private string _User3 = "";
        /// <summary>
        /// 制表
        /// </summary>
        [Persistence(ColumnName = "User3")]
        public string User3
        {
            set { _User3 = value; }
            get { return _User3; }
        }
        private DateTime _InputDate = DateTime.Now;
        /// <summary>
        /// 开票日期
        /// </summary>
        [Persistence(ColumnName = "InputDate")]
        public DateTime InputDate
        {
            set { _InputDate = value; }
            get { return _InputDate; }
        }
        private DateTime _createtime = DateTime.Now;
        /// <summary>
        /// 录入日期
        /// </summary>
        [Persistence(ColumnName = "CreateTime")]
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        private string _Customer = "";
        /// <summary>
        /// 客户名称
        /// </summary>
        [Persistence(ColumnName = "Customer")]
        public string Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        private string _TaxNo = "";
        /// <summary>
        /// 纳税识别号
        /// </summary>
        [Persistence(ColumnName = "TaxNo")]
        public string TaxNo
        {
            get { return _TaxNo; }
            set { _TaxNo = value; }
        }

        #endregion

        #region 散货

        private string _LCLAmount = "0";
        /// <summary>
        /// 散货载货量
        /// </summary>
        [Persistence(ColumnName = "LCLAmount")]
        public string LCLAmount
        {
            get { return _LCLAmount; }
            set { _LCLAmount = value; }
        }
        private string _LCLAmountReal = "0";
        /// <summary>
        /// 计费货运量
        /// </summary>
        [Persistence(ColumnName = "LCLAmountReal")]
        public string LCLAmountReal
        {
            get { return _LCLAmountReal; }
            set { _LCLAmountReal = value; }
        }
        private string _LCLCatalog = "0";
        /// <summary>
        /// 散货种类
        /// </summary>
        [Persistence(ColumnName = "LCLCatalog")]
        public string LCLCatalog
        {
            get { return _LCLCatalog; }
            set { _LCLCatalog = value; }
        }
        private string _LCLPrice = "0";
        /// <summary>
        /// 运价（元/吨）：
        /// </summary>
        [Persistence(ColumnName = "LCLPrice")]
        public string LCLPrice
        {
            get { return _LCLPrice; }
            set { _LCLPrice = value; }
        }

        private string _DelayDay = "0";
        /// <summary>
        /// 滞期时间（天）： 
        /// </summary>
        [Persistence(ColumnName = "DelayDay")]
        public string DelayDay
        {
            set { _DelayDay = value; }
            get { return _DelayDay; }
        }
        private string _DelayRate = "0";
        /// <summary>
        /// 滞期率（元/天）： 
        /// </summary>
        [Persistence(ColumnName = "DelayRate")]
        public string DelayRate
        {
            set { _DelayRate = value; }
            get { return _DelayRate; }
        }
        /// <summary>
        /// 滞期费 
        /// </summary>
        public string DelayAmount
        {
            get 
            {
                decimal fDay = decimal.Parse(DelayDay);
                decimal fRate = decimal.Parse(DelayRate);
                return (fDay * fRate).ToString(); 
            }
        }

        private string _QuickDay = "0";
        /// <summary>
        /// 速遣时间（天）：： 
        /// </summary>
        [Persistence(ColumnName = "QuickDay")]
        public string QuickDay
        {
            set { _QuickDay = value; }
            get { return _QuickDay; }
        }
        private string _QuickRate = "0";
        /// <summary>
        /// 速遣率（元/天） 
        /// </summary>
        [Persistence(ColumnName = "QuickRate")]
        public string QuickRate
        {
            set { _QuickRate = value; }
            get { return _QuickRate; }
        }
        /// <summary>
        /// 速遣费 
        /// </summary>
        public string DispatchAmount
        {
            get
            {
                decimal fDay = decimal.Parse(QuickDay);
                decimal fRate = decimal.Parse(QuickRate);
                return (fDay * fRate).ToString();
            }
        }
        #endregion

        #endregion Model

    }
}


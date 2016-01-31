/**  版本信息模板在安装目录下，可自行修改。
* InsuranceOfContainer.cs
*
* 功 能： N/A
* 类 名： InsuranceOfContainer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/20 9:45:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using SIRC.Framework.Utility;
using System.Collections.Generic;


namespace Sirc.SharpReport.Model
{
    /// <summary>
    /// InsuranceOfContainer:内贸线货运险投保货量及保费
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "InsuranceOfContainer")]
    public partial class InsuranceOfContainerInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public InsuranceOfContainerInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public InsuranceOfContainerInfo(string ID)
        {
            this.ID = ID;
        }

        #region Model
        private string _id;
        /// <summary>
        /// 主键
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private string _dimtimeid;
        /// <summary>
        /// 报告期主键
        /// </summary>
        [Persistence(ColumnName = "DimTimeID")]
        public string DimTimeID
        {
            set { _dimtimeid = value; }
            get { return _dimtimeid; }
        }

        private string _inputuserid;
        /// <summary>
        /// 登记人
        /// </summary>
        [Persistence(ColumnName = "InputUserID")]
        public string InputUserID
        {
            set { _inputuserid = value; }
            get { return _inputuserid; }
        }
        private string _approveuserid;
        /// <summary>
        /// 财务部审核人员
        /// </summary>
        [Persistence(ColumnName = "ApproveUserID")]
        public string ApproveUserID
        {
            set { _approveuserid = value; }
            get { return _approveuserid; }
        }

        private DateTime _createtime = DateTime.Now;
        /// <summary>
        /// 报表创建时间
        /// </summary>
        [Persistence(ColumnName = "CreateTime")]
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        private string _currencyID = string.Empty;
        /// <summary>
        /// 币种主键，默认1为人民币
        /// </summary>
        [Persistence(ColumnName = "CurrencyID")]
        public string CurrencyID
        {
            set { _currencyID = value; }
            get { return _currencyID; }
        }
        private string _exchangeRateID = string.Empty;
        /// <summary>
        /// 汇率主键，默认NULL，不进行转换
        /// </summary>
        [Persistence(ColumnName = "ExchangeRateID")]
        public string ExchangeRateID
        {
            set { _exchangeRateID = value; }
            get { return _exchangeRateID; }
        }

        private string _柜号起始字母 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "柜号起始字母")]
        public string 柜号起始字母
        {
            set { _柜号起始字母 = value; }
            get { return _柜号起始字母; }
        }
        
        private string _集装箱数量20 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "集装箱数量20")]
        public string 集装箱数量20
        {
            set { _集装箱数量20 = value; }
            get { return _集装箱数量20; }
        }

        private string _集装箱数量40 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "集装箱数量40")]
        public string 集装箱数量40
        {
            set { _集装箱数量40 = value; }
            get { return _集装箱数量40; }
        }

        private string _单价20 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "单价20")]
        public string 单价20
        {
            set { _单价20 = value; }
            get { return _单价20; }
        }

        private string _单价40 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "单价40")]
        public string 单价40
        {
            set { _单价40 = value; }
            get { return _单价40; }
        }

        private string _保额 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保额")]
        public string 保额
        {
            set { _保额 = value; }
            get { return _保额; }
        }

        private string _基本险保险费率 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "基本险保险费率")]
        public string 基本险保险费率
        {
            set { _基本险保险费率 = value; }
            get { return _基本险保险费率; }
        }

        private string _保费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保费")]
        public string 保费
        {
            set { _保费 = value; }
            get { return _保费; }
        }

        private DateTime _保险期限自;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保险期限自")]
        public DateTime 保险期限自
        {
            set { _保险期限自 = value; }
            get { return _保险期限自; }
        }

        private DateTime _保险期限到;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保险期限到")]
        public DateTime 保险期限到
        {
            set { _保险期限到 = value; }
            get { return _保险期限到; }
        }

        private string _备注 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "备注")]
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }



        #endregion Model

    }
}


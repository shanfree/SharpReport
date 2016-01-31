/**  版本信息模板在安装目录下，可自行修改。
* CommonFee.cs
*
* 功 能： N/A
* 类 名： CommonFee
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
    /// CommonFee:内贸线货运险投保货量及保费
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "V_CommonFee")]
    public partial class CommonFeeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public CommonFeeInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public CommonFeeInfo(string ID)
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
        private int _monthNumOfYear;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "MonthNumOfYear", IsExtend = true)]
        public int MonthNumOfYear
        {
            set { _monthNumOfYear = value; }
            get { return _monthNumOfYear; }
        }
        private int _year;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Year", IsExtend = true)]
        public int Year
        {
            set { _year = value; }
            get { return _year; }
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
        private string _shipID;
        /// <summary>
        /// 船舶主键
        /// </summary>
        [Persistence(ColumnName = "ShipID")]
        public string ShipID
        {
            set { _shipID = value; }
            get { return _shipID; }
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

        private string _feeCatalogID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "FeeCatalogID")]
        public string FeeCatalogID
        {
            set { _feeCatalogID = value; }
            get { return _feeCatalogID; }
        }



        private string _Amount = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Amount")]
        public string Amount
        {
            set { _Amount = value; }
            get { return _Amount; }
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


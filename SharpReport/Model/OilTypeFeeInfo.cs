/**  版本信息模板在安装目录下，可自行修改。
* OilTypeFee.cs
*
* 功 能： N/A
* 类 名： OilTypeFee
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
using SIRC.Framework.Utility;
namespace Sirc.SharpReport.Model
{

    /// <summary>
    /// OilTypeFee:物料报表信息(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "OilTypeFee")]
    public partial class OilTypeFeeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public OilTypeFeeInfo()
        { }
        public OilTypeFeeInfo(string ID)
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

        private string _OilTypeID;
        /// <summary>
        /// 油种类主键
        /// </summary>
        [Persistence(ColumnName = "OilTypeID")]
        public string OilTypeID
        {
            set { _OilTypeID = value; }
            get { return _OilTypeID; }
        }

        private string _Price;
        /// <summary>
        /// 油单价
        /// </summary>
        [Persistence(ColumnName = "Price")]
        public string Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

        private string _Quantity;
        /// <summary>
        /// 加油量
        /// </summary>
        [Persistence(ColumnName = "Quantity")]
        public string Quantity
        {
            set { _Quantity = value; }
            get { return _Quantity; }
        }

        private string _PortID;
        /// <summary>
        /// 加油港ID
        /// </summary>
        [Persistence(ColumnName = "PortID")]
        public string PortID
        {
            set { _PortID = value; }
            get { return _PortID; }
        }

        private string _CurrencyID;
        /// <summary>
        /// 币种ID
        /// </summary>
        [Persistence(ColumnName = "CurrencyID")]
        public string CurrencyID
        {
            set { _CurrencyID = value; }
            get { return _CurrencyID; }
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

        //private string _InvoiceID;
        ///// <summary>
        ///// 发票ID
        ///// </summary>
        //[Persistence(ColumnName = "InvoiceID")]
        //public string InvoiceID
        //{
        //    set { _InvoiceID = value; }
        //    get { return _InvoiceID; }
        //}


        private string _OilFeeReportID;
        /// <summary>
        /// 加油费用报表ID
        /// </summary>
        [Persistence(ColumnName = "OilFeeReportID")]
        public string OilFeeReportID
        {
            set { _OilFeeReportID = value; }
            get { return _OilFeeReportID; }
        }

        #endregion Model
    }
}


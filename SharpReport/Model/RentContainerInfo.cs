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
    [Persistence(ColumnName = "RentContainer", ExtendName = "V_RentContainer")]
    public partial class RentContainerInfo
    {
        public RentContainerInfo()
        { }
        public RentContainerInfo(string ID)
        {
            this._id = ID;
        }

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
        private string _ReportID;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "ReportID")]
        public string ReportID
        {
            get { return _ReportID; }
            set { _ReportID = value; }
        }

        //private string _currencyID = "1";
        ///// <summary>
        ///// 币种主键，默认1为人民币
        ///// </summary>
        //[Persistence(ColumnName = "CurrencyID")]
        //public string CurrencyID
        //{
        //    set { _currencyID = value; }
        //    get { return _currencyID; }
        //}
        //private string _CurrencyName = "";
        ///// <summary>
        ///// 币种主键，默认1为人民币
        ///// </summary>
        //[Persistence(ColumnName = "CurrencyName", IsExtend = true)]
        //public string CurrencyName
        //{
        //    set { _CurrencyName = value; }
        //    get { return _CurrencyName; }
        //}

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
        #endregion

        #region 租金报表

        private string _ContainerTypeID = "1";
        /// <summary>
        /// 货柜类型
        /// </summary>
        [Persistence(ColumnName = "ContainerTypeID")]
        public string ContainerTypeID
        {
            set { _ContainerTypeID = value; }
            get { return _ContainerTypeID; }
        }
        private string _Amount = "0";
        /// <summary>
        /// 货柜数量：
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

        private string _Price = "0";
        /// <summary>
        /// 天租金
        /// </summary>
        [Persistence(ColumnName = "Price")]
        public string Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

        private string _RentFee = "0";
        /// <summary>
        /// 计费期租金
        /// </summary>
        [Persistence(ColumnName = "RentFee")]
        public string RentFee
        {
            set { _RentFee = value; }
            get { return _RentFee; }
        }

        private string _Remark = "0";
        /// <summary>
        /// 备注
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }

        #endregion

    }
}


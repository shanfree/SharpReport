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
    [Persistence(ColumnName = "RentShipReport", ExtendName = "V_RentShipReport")]
    public partial class RentShipReportInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public RentShipReportInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public RentShipReportInfo(string ID)
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
        private string _ShipID;
        /// <summary>
        /// 船舶
        /// </summary>
        [Persistence(ColumnName = "ShipID")]
        public string ShipID
        {
            get { return _ShipID; }
            set { _ShipID = value; }
        }
        private string _Amount = "0";
        /// <summary>
        /// 总费用：
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
        private string _CurrencyName = "";
        /// <summary>
        /// 币种主键，默认1为人民币
        /// </summary>
        [Persistence(ColumnName = "CurrencyName", IsExtend = true)]
        public string CurrencyName
        {
            set { _CurrencyName = value; }
            get { return _CurrencyName; }
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

        #region 租金报表
        private string _RentTypeID = "";
        /// <summary>
        /// 出租类型
        /// </summary>
        [Persistence(ColumnName = "RentTypeID")]
        public string RentTypeID
        {
            get { return _RentTypeID; }
            set { _RentTypeID = value; }
        }
        private DateTime _BeginDate = DateTime.Now;
        /// <summary>
        /// 租金计算开始时间
        /// </summary>
        [Persistence(ColumnName = "BeginDate")]
        public DateTime BeginDate
        {
            set { _BeginDate = value; }
            get { return _BeginDate; }
        }
        private DateTime _EndDate = DateTime.Now;
        /// <summary>
        /// 租金计算结束时间
        /// </summary>
        [Persistence(ColumnName = "EndDate")]
        public DateTime EndDate
        {
            set { _EndDate = value; }
            get { return _EndDate; }
        }
        private string _RentDays = "0";
        /// <summary>
        /// 出租天数
        /// </summary>
        [Persistence(ColumnName = "RentDays")]
        public string RentDays
        {
            set { _RentDays = value; }
            get 
            {
                if (_RentDays != "0")
                {
                    int days = (EndDate - BeginDate).Days;
                    _RentDays = days.ToString();
                }
                return _RentDays; 
            }
        }
        private string _DiscountDays = "0";
        /// <summary>
        /// 扣租时间
        /// </summary>
        [Persistence(ColumnName = "DiscountDays")]
        public string DiscountDays
        {
            set { _DiscountDays = value; }
            get { return _DiscountDays; }
        }
        private string _RealDays = "0";
        /// <summary>
        /// 计算租金时间
        /// </summary>
        [Persistence(ColumnName = "RealDays")]
        public string RealDays
        {
            set { _RealDays = value; }
            get { return _RealDays; }
        }
        private string _Price = "0";
        /// <summary>
        /// 日租金
        /// </summary>
        [Persistence(ColumnName = "Price")]
        public string Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        private string _RentFee = "0";
        /// <summary>
        /// 租金
        /// </summary>
        [Persistence(ColumnName = "RentFee")]
        public string RentFee
        {
            set { _RentFee = value; }
            get { return _RentFee; }
        }
        private string _CommunicateFee = "0";
        /// <summary>
        /// 通讯费
        /// </summary>
        [Persistence(ColumnName = "CommunicateFee")]
        public string CommunicateFee
        {
            set { _CommunicateFee = value; }
            get { return _CommunicateFee; }
        }
        private string _LockFee = "0";
        /// <summary>
        /// 绑扎锁具补贴
        /// </summary>
        [Persistence(ColumnName = "LockFee")]
        public string LockFee
        {
            set { _LockFee = value; }
            get { return _LockFee; }
        }
        private string _OtherFee = "0";
        /// <summary>
        /// 其他补贴
        /// </summary>
        [Persistence(ColumnName = "OtherFee")]
        public string OtherFee
        {
            set { _OtherFee = value; }
            get { return _OtherFee; }
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


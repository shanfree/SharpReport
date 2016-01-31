using System;
using SIRC.Framework.Utility;

namespace Sirc.SharpReport.Model
{
    /// <summary>
    /// 报表类型
    /// </summary>
    public enum ReportCatalog
    {
        Wuliao = 1,
        Xiuli,
        Jianyan,
        Beijian,
        /// <summary>
        /// 货运险报表
        /// </summary>
        InsuranceOfFreightTransport = 5,
        /// <summary>
        /// 船舶险
        /// </summary>
        InsuranceOfShip,
        /// <summary>
        /// 船舶保赔险
        /// </summary>
        InsuranceOfCompensation,
        /// <summary>
        /// 集装箱箱体保险
        /// </summary>
        InsuranceOfContainer = 8,
        /// <summary>
        /// 证书
        /// </summary>
        Certificate = 9,
        /// <summary>
        /// 安监部报表
        /// </summary>
        Supervision = 10,
        /// <summary>
        /// 人资部报表
        /// </summary>
        HumanResource = 11,
        /// <summary>
        /// 油料添加报表
        /// </summary>
        OilFeeReport = 12,
    }



    /// <summary>
    /// 报表的基类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ReportBaseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ReportBaseInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public ReportBaseInfo(string ID)
        {
            this.ID = ID;
        }


        #region Model
        private string _id;
        private string _dimtimeid;
        private string _inputuserid;
        private string _approveuserid;
        private DateTime _createtime = DateTime.Now;

        /// <summary>
        /// 主键
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
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

        private string _usagetype;
        /// <summary>
        /// 1：日常用、2：厂修用和3：航修用
        /// </summary>
        [Persistence(ColumnName = "UsageType")]
        public string UsageType
        {
            set { _usagetype = value; }
            get { return _usagetype; }
        }
        /// <summary>
        /// 登记人
        /// </summary>
        [Persistence(ColumnName = "InputUserID")]
        public string InputUserID
        {
            set { _inputuserid = value; }
            get { return _inputuserid; }
        }
        /// <summary>
        /// 财务部审核人员
        /// </summary>
        [Persistence(ColumnName = "ApproveUserID")]
        public string ApproveUserID
        {
            set { _approveuserid = value; }
            get { return _approveuserid; }
        }
        private string _reportTypeID = string.Empty;
        /// <summary>
        /// 预估录入、修正录入、财务确认
        /// </summary>
        [Persistence(ColumnName = "ReportTypeID")]
        public string ReportTypeID
        {
            set { _reportTypeID = value; }
            get { return _reportTypeID; }
        }

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

        private string _preestimateFormID;
        /// <summary>
        /// 预估输入的XML表单
        /// </summary>
        [Persistence(ColumnName = "PreestimateFormID")]
        public string PreestimateFormID
        {
            set { _preestimateFormID = value; }
            get { return _preestimateFormID; }
        }
        private string _amendFormID;
        /// <summary>
        /// 修正录入XML表单
        /// </summary>
        [Persistence(ColumnName = "AmendFormID")]
        public string AmendFormID
        {
            set { _amendFormID = value; }
            get { return _amendFormID; }
        }

        #endregion Model

    }
}

/*  版本信息模板在安装目录下，可自行修改。
* Invoice.cs
*
* 功 能： N/A
* 类 名： Invoice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/20 9:45:11   N/A    初版
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
    /// Invoice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "Invoice")]
    public partial class InvoiceInfo
    {
        public InvoiceInfo()
        { }
        public InvoiceInfo(string ID)
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
        private string _number = "";
        /// <summary>
        /// 发票编号
        /// </summary>
        [Persistence(ColumnName = "Number")]
        public string Number
        {
            set { _number = value; }
            get { return _number; }
        }
        private string _amout = "0";
        /// <summary>
        /// 发票原始金额
        /// </summary>
        [Persistence(ColumnName = "Amout")]
        public string Amout
        {
            set { _amout = value; }
            get { return _amout; }
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
        private string _Rate = "1";
        /// <summary>
        /// 税率
        /// </summary>
        [Persistence(ColumnName = "Rate")]
        public string Rate
        {
            set { _Rate = value; }
            get { return _Rate; }
        }

        private string _remark = "";
        /// <summary>
        /// 发票金额
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        private string _personName = "";
        /// <summary>
        /// 报销人
        /// </summary>
        [Persistence(ColumnName = "PersonName")]
        public string PersonName
        {
            set { _personName = value; }
            get { return _personName; }
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
        private byte[] _scanImage;
        /// <summary>
        /// 财务部审核人员
        /// </summary>
        [Persistence(ColumnName = "ScanImage",IsLazyLoad=true)]
        public byte[] ScanImage
        {
            set { _scanImage = value; }
            get { return _scanImage; }
        }
        private string _reportType = "1";
        /// <summary>
        /// 报表类型(数据库中的表名)
        /// </summary>
        [Persistence(ColumnName = "ReportType")]
        public string ReportType
        {
            set { _reportType = value; }
            get { return _reportType; }
        }
        public ReportCatalog ReportCatalog
        {
            get 
            {
                return EnumHandler<ReportCatalog>.GetEnumFromIntString(this.ReportType); 
            }
        }

        /// <summary>
        /// 报表类型名称
        /// </summary>
        public string ReportCatalogName
        {
            get
            {
                string name = string.Empty;
                switch (this.ReportCatalog)
                {
                    case ReportCatalog.Wuliao:
                        name = "物料报表";
                        break;
                    case ReportCatalog.Xiuli:
                        name = "修理报表";
                        break;
                    case ReportCatalog.Jianyan:
                        name = "检验报表";
                        break;
                    case ReportCatalog.Beijian:
                        name = "备件报表";
                        break;
                    case ReportCatalog.InsuranceOfFreightTransport:
                        name = "货运险报表";
                        break;
                    case ReportCatalog.InsuranceOfShip:
                        name = "船舶险报表";
                        break;
                    case ReportCatalog.InsuranceOfCompensation:
                        name = "船舶保赔险报表";
                        break;
                    case ReportCatalog.InsuranceOfContainer:
                        name = "集装箱箱体保险";
                        break;
                    case ReportCatalog.Certificate:
                        name = "证书费用";
                        break;
                    case ReportCatalog.Supervision:
                        name = "安监部报表";
                        break;
                    case ReportCatalog.HumanResource:
                        name = "人资部报表";
                        break;
                    case ReportCatalog.OilFeeReport:
                        name = "油料添加报表";
                        break;
                    default:
                        break;
                }
                return name;
            }
        }

        /// <summary>
        /// 报表链接
        /// </summary>
        public string ReportUrl
        {
            get
            {
                if (string.IsNullOrEmpty(this.KeyID))
                {
                    return string.Empty;
                }
                string format = string.Empty;
                #region 获取报表填报页面的相对路径
                switch (this.ReportCatalog)
                {
                    case ReportCatalog.Wuliao:
                        format = "../ChuanJ/WuliaoInputPage.aspx?id={0}";
                        break;
                    case ReportCatalog.Xiuli:
                        format = "../ChuanJ/XiuliinputPage.aspx?id={0}";
                        break;
                    case ReportCatalog.Jianyan:
                        format = "../ChuanJ/JianyanInputPage.aspx?id={0}";
                        break;
                    case ReportCatalog.Beijian:
                        format = "../ChuanJ/BeijianInputPage.aspx?id={0}";
                        break;
                    case ReportCatalog.InsuranceOfFreightTransport:
                        format = "../Hangy/InsuranceOfFreightTransportInput.aspx?id={0}";
                        break;
                    case ReportCatalog.InsuranceOfShip:
                        format = "../Hangy/InsuranceOfCompensationInput.aspx?id={0}";
                        break;
                    case ReportCatalog.InsuranceOfCompensation:
                        format = "../Hangy/InsuranceOfCompensationInput.aspx?id={0}";
                        break;
                    case ReportCatalog.InsuranceOfContainer:
                        format = "../Hangy/InsuranceOfContainerInput.aspx?id={0}";
                        break;
                    case ReportCatalog.Certificate:
                        format = "../Hangy/CertificateInput.aspx?id={0}";
                        break;
                    case ReportCatalog.Supervision:
                        format = "../Anjian/CommonFeeList.aspx?id={0}";
                        break;
                    case ReportCatalog.HumanResource:
                        format = "../HR/CommonFeeList.aspx?id={0}";
                        break;
                    case ReportCatalog.OilFeeReport:
                        format = "../Hangy/OilFee.aspx?id={0}";
                        break;
                    default:
                        throw new NotImplementedException("无法识别的报表类型。");
                        break;
                }
                #endregion

                string url = string.Format(format, this.KeyID);
                return url;
            }
        }

        private string _keyID = "0";
        /// <summary>
        /// 报表主键ID
        /// </summary>
        [Persistence(ColumnName = "KeyID")]
        public string KeyID
        {
            set { _keyID = value; }
            get { return _keyID; }
        }
        private string _url = "";
        /// <summary>
        /// 报表扫描件文件名称
        /// </summary>
        [Persistence(ColumnName = "URL")]
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }

        #endregion Model 

    }
}


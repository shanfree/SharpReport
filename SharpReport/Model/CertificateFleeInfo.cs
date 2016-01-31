/**  版本信息模板在安装目录下，可自行修改。
* CertificateFlee.cs
*
* 功 能： N/A
* 类 名： CertificateFlee
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
    /// CertificateFlee:内贸线货运险投保货量及公正
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "CertificateFlee")]
    public partial class CertificateFleeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public CertificateFleeInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public CertificateFleeInfo(string ID)
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

        private string _项目名称 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "项目名称")]
        public string 项目名称
        {
            set { _项目名称 = value; }
            get { return _项目名称; }
        }
        private DateTime _发证日期;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "发证日期")]
        public DateTime 发证日期
        {
            set { _发证日期 = value; }
            get { return _发证日期; }
        }

        private DateTime _有效期至;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "有效期至")]
        public DateTime 有效期至
        {
            set { _有效期至 = value; }
            get { return _有效期至; }
        }



        private DateTime _年审有效日期;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "年审有效日期")]
        public DateTime 年审有效日期
        {
            set { _年审有效日期 = value; }
            get { return _年审有效日期; }
        }

        private string _快递费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "快递费")]
        public string 快递费
        {
            set { _快递费 = value; }
            get { return _快递费; }
        }

        private string _图纸复印费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "图纸复印费")]
        public string 图纸复印费
        {
            set { _图纸复印费 = value; }
            get { return _图纸复印费; }
        }

        private string _洗照片 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "洗照片")]
        public string 洗照片
        {
            set { _洗照片 = value; }
            get { return _洗照片; }
        }

        private string _其他 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "其他")]
        public string 其他
        {
            set { _其他 = value; }
            get { return _其他; }
        }

        private string _证书类型 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "证书类型")]
        public string 证书类型
        {
            set { _证书类型 = value; }
            get { return _证书类型; }
        }

        private string _公正 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "公正")]
        public string 公正
        {
            set { _公正 = value; }
            get { return _公正; }
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


/**  版本信息模板在安装目录下，可自行修改。
* InsuranceOfCompensation.cs
*
* 功 能： N/A
* 类 名： InsuranceOfCompensation
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
    /// InsuranceOfCompensation:内贸线货运险投保货量及保费
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "InsuranceOfCompensation")]
    public partial class InsuranceOfCompensationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public InsuranceOfCompensationInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public InsuranceOfCompensationInfo(string ID)
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

        private string _beginDate = string.Empty;
        /// <summary>
        /// 出发时间
        /// </summary>
        [Persistence(ColumnName = "BeginDate")]
        public string BeginDate
        {
            set { _beginDate = value; }
            get { return _beginDate; }
        }

        private string _endDate = string.Empty;
        /// <summary>
        /// 到达时间
        /// </summary>
        [Persistence(ColumnName = "EndDate")]
        public string EndDate
        {
            set { _endDate = value; }
            get { return _endDate; }
        }


        private string _船舶险保单号 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "船舶险保单号")]
        public string 船舶险保单号
        {
            set { _船舶险保单号 = value; }
            get { return _船舶险保单号; }
        }
        
        private string _主险保额 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "主险保额")]
        public string 主险保额
        {
            set { _主险保额 = value; }
            get { return _主险保额; }
        }

        private string _主险费率 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "主险费率")]
        public string 主险费率
        {
            set { _主险费率 = value; }
            get { return _主险费率; }
        }


        private string _主险保费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "主险保费")]
        public string 主险保费
        {
            get 
            {
                _主险保费 = StringExtend.Time(主险保额, 主险费率);
                _主险保费 = StringExtend.Divide(_主险保费,"100");
                return _主险保费;
            }
            set { _主险保费 = value; }
        }

        private string _战争保赔险费率 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "战争保赔险费率")]
        public string 战争保赔险费率
        {
            set { _战争保赔险费率 = value; }
            get { return _战争保赔险费率; }
        }

        private string _战争保赔险保费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "战争保赔险保费")]
        public string 战争保赔险保费
        {
            get
            {
                _战争保赔险保费 = StringExtend.Time(主险保额, 战争保赔险费率);
                _战争保赔险保费 = StringExtend.Divide(_战争保赔险保费, "100");
                return _战争保赔险保费;
            }
            set { _战争保赔险保费 = value; }
        }

        private string _免赔额 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "免赔额")]
        public string 免赔额
        {
            set { _免赔额 = value; }
            get { return _免赔额; }
        }

        private string _船舶险总保费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "船舶险总保费")]
        public string 船舶险总保费
        {
            get
            {
                _船舶险总保费 = StringExtend.Add(主险保费, 战争保赔险保费);
                return _船舶险总保费;
            }
            set { _船舶险总保费 = value; }
        }

        private string _保赔险保单号 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保赔险保单号")]
        public string 保赔险保单号
        {
            set { _保赔险保单号 = value; }
            get { return _保赔险保单号; }
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

        private string _保赔险费率 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保赔险费率")]
        public string 保赔险费率
        {
            set { _保赔险费率 = value; }
            get { return _保赔险费率; }
        }

        private string _保赔险保费 = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "保赔险保费")]
        public string 保赔险保费
        {
            set { _保赔险保费 = value; }
            get { return _保赔险保费; }
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


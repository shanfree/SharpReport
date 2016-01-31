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
    [Persistence(ColumnName = "VoyageFCL", ExtendName = "V_VoyageFCL")]
    public partial class VoyageFCLInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public VoyageFCLInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public VoyageFCLInfo(string ID)
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
        
        private string _Amount = "0";
        /// <summary>
        /// 运费由以下组成：航次船舶租金，包干燃油，箱费用，增减港口费用，船舶延时作业费，港口装卸费，港口理货费
        /// </summary>
        [Persistence(ColumnName = "Amount")]
        public string Amount
        {
            get { return _Amount; }
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

        #endregion

        #region 集装箱
        private string _Fee = "";
        /// <summary>
        /// 运费金额
        /// </summary>
        [Persistence(ColumnName = "Fee")]
        public string Fee
        {
            set { _Fee = value; }
            get { return _Fee; }
        }
        private string _BeginFee = "";
        /// <summary>
        /// 始运港装卸费
        /// </summary>
        [Persistence(ColumnName = "BeginFee")]
        public string BeginFee
        {
            set { _BeginFee = value; }
            get { return _BeginFee; }
        }
        private string _EndFee = "";
        /// <summary>
        /// 目的港装卸费
        /// </summary>
        [Persistence(ColumnName = "EndFee")]
        public string EndFee
        {
            set { _EndFee = value; }
            get { return _EndFee; }
        }
        private string _OilFee = "";
        /// <summary>
        /// 油款
        /// </summary>
        [Persistence(ColumnName = "OilFee")]
        public string OilFee
        {
            set { _OilFee = value; }
            get { return _OilFee; }
        }
        private string _Tally = "";
        /// <summary>
        /// 理货费
        /// </summary>
        [Persistence(ColumnName = "Tally")]
        public string Tally
        {
            set { _Tally = value; }
            get { return _Tally; }
        }
        private string _Box = "";
        /// <summary>
        /// 箱费
        /// </summary>
        [Persistence(ColumnName = "Box")]
        public string Box
        {
            set { _Box = value; }
            get { return _Box; }
        }
        private string _Other = "";
        /// <summary>
        /// 其他
        /// </summary>
        [Persistence(ColumnName = "Other")]
        public string Other
        {
            set { _Other = value; }
            get { return _Other; }
        }

        private string _Subsidize = "0";
        /// <summary>
        /// 政府补贴
        /// </summary>
        [Persistence(ColumnName = "Subsidize")]
        public string Subsidize
        {
            set { _Subsidize = value; }
            get { return _Subsidize; }
        }

        private string _BookFee = "0";
        /// <summary>
        /// 订舱费
        /// </summary>
        [Persistence(ColumnName = "BookFee")]
        public string BookFee
        {
            set { _BookFee = value; }
            get { return _BookFee; }
        }

        private string _BranchOther = "0";
        /// <summary>
        /// 其他
        /// </summary>
        [Persistence(ColumnName = "BranchOther")]
        public string BranchOther
        {
            set { _BranchOther = value; }
            get { return _BranchOther; }
        }


        private string _Remark = "";
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
        #endregion Model

    }
}


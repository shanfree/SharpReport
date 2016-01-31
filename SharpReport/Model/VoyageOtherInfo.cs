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
    [Persistence(ColumnName = "VoyageOther", ExtendName = "V_VoyageOther")]
    public partial class VoyageOtherInfo
    {
        public VoyageOtherInfo()
        { }
        public VoyageOtherInfo(string ID)
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
        private string _VoyageID;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "VoyageID")]
        public string VoyageID
        {
            get { return _VoyageID; }
            set { _VoyageID = value; }
        }
        private string _Amount = "0";
        /// <summary>
        /// 
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

        #endregion

        #region 其他

        private string _Remark;
        /// <summary>
        /// 其他收入说明
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _OtherName;
        /// <summary>
        /// 其他收入项目
        /// </summary>
        [Persistence(ColumnName = "OtherName")]
        public string OtherName
        {
            get { return _OtherName; }
            set { _OtherName = value; }
        }

        #endregion

    }
}


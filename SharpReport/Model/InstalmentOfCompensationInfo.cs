/**  版本信息模板在安装目录下，可自行修改。
* InstalmentOfCompensation.cs
*
* 功 能： N/A
* 类 名： InstalmentOfCompensation
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


namespace Sirc.SharpReport.Model
{
	/// <summary>
	/// InstalmentOfCompensation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    [Persistence(ColumnName = "InstalmentOfCompensation")]
    public partial class InstalmentOfCompensationInfo
	{
        public InstalmentOfCompensationInfo()
		{}
        public InstalmentOfCompensationInfo(string ID)
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

        private string _compensationID;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "CompensationID")]
        public string CompensationID
        {
            set { _compensationID = value; }
            get { return _compensationID; }
        }

        private string _reportType;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "ReportType")]
        public string ReportType
        {
            set { _reportType = value; }
            get { return _reportType; }
        }

        private string _currencyID;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "CurrencyID")]
        public string CurrencyID
        {
            set { _currencyID = value; }
            get { return _currencyID; }
        }

        private string _amount;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Amount")]
        public string Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }

        private DateTime _payDate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "PayDate")]
        public DateTime PayDate
        {
            set { _payDate = value; }
            get { return _payDate; }
        }

        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
		#endregion Model

	}
}


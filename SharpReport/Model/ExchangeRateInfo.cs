/**  版本信息模板在安装目录下，可自行修改。
* ExchangeRate.cs
*
* 功 能： N/A
* 类 名： ExchangeRate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:43   N/A    初版
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
    /// ExchangeRate:汇率转换(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "ExchangeRate")]
	public partial class ExchangeRateInfo
	{
        public ExchangeRateInfo()
		{}
		#region Model
		private string _id;
		/// <summary>
		/// 
		/// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        private string _dimTimeID;
		/// <summary>
		/// 名称
		/// </summary>
        [Persistence(ColumnName = "DimTimeID")]
        public string DimTimeID
		{
            set { _dimTimeID = value; }
            get { return _dimTimeID; }
		}
        private string _rate = "未定义";
        /// <summary>
        /// 汇率转换：人民币=外币/汇率
        /// </summary>
        [Persistence(ColumnName = "Rate")]
        public string Rate
        {
            set { _rate = value; }
            get { return _rate; }
        }
        private string _currencyID;
        /// <summary>
        /// 币种主键，默认1为人民币
        /// </summary>
        [Persistence(ColumnName = "CurrencyID")]
        public string CurrencyID
        {
            set { _currencyID = value; }
            get { return _currencyID; }
        }

		#endregion Model

	}
}


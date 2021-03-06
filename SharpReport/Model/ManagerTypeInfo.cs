﻿/**  版本信息模板在安装目录下，可自行修改。
* ManagerType.cs
*
* 功 能： N/A
* 类 名： ManagerType
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
    /// ManagerType:经营方式(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "ManagerType")]
	public partial class ManagerTypeInfo
	{
        public ManagerTypeInfo()
		{}

		#region Model
		private string _id;
		private string _name;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "Name")]
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        private string _TaxRate;
        /// <summary>
		/// 税率
		/// </summary>
        [Persistence(ColumnName = "TaxRate")]
        public string TaxRate
		{
            set { _TaxRate = value; }
            get { return _TaxRate; }
		}
		#endregion Model

	}
}


/**  版本信息模板在安装目录下，可自行修改。
* Department.cs
*
* 功 能： N/A
* 类 名： Department
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:41   N/A    初版
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
    /// Department:部门(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "Department")]
	public partial class DepartmentInfo
	{
        public DepartmentInfo()
		{}

		#region Model
		private string _id;
		private string _fullname;
		private string _shortname;
		private string _remark;

		/// <summary>
		/// 部门主键
		/// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 全名
		/// </summary>
        [Persistence(ColumnName = "FullName")]
        public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 简称
		/// </summary>
        [Persistence(ColumnName = "ShortName")]
        public string ShortName
		{
			set{ _shortname=value;}
			get{return _shortname;}
		}
		/// <summary>
		/// 备注
		/// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}


/**  版本信息模板在安装目录下，可自行修改。
* User.cs
*
* 功 能： N/A
* 类 名： User
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
    /// User:用户(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "User")]
	public partial class UserInfo
	{
        public UserInfo()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _password;
		private DateTime _lastlogindate= DateTime.Now;
		private int _departmentid;
		/// <summary>
		/// 
		/// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "Password")]
        public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "LastLoginDate")]
        public DateTime LastLoginDate
		{
			set{ _lastlogindate=value;}
			get{return _lastlogindate;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "DepartmentID")]
        public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		#endregion Model

	}
}


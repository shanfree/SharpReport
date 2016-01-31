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
using System.Collections.Generic;
namespace SIRC.Framework.SharpMemberShip.Model
{
	/// <summary>
    /// User:用户(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "V_User")]
	public partial class UserInfo
	{
        public UserInfo()
		{}
		#region Model
        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _password = string.Empty;
        private DateTime _lastlogindate = DateTime.Now;
        private string _departmentid = string.Empty;
        private string _departmentName = string.Empty;
        private string _GUID = string.Empty;
        private DateTime _expireDate = DateTime.Now;
        private IList<MenuInfo> _mList = new List<MenuInfo>();
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
        public string DepartmentID
		{
			set{ _departmentid=value;} 
			get{return _departmentid;}
		}
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "DepartmentName",IsExtend=true)]
        public string DepartmentName
        {
            set { _departmentName = value; }
            get { return _departmentName; }
        }

        /// <summary>
        /// 成功登录后的身份凭据
        /// </summary>
        [Persistence(ColumnName = "GUID", IsExtend=true)]
        public string GUID
        {
            set { _GUID = value; }
            get { return _GUID; }
        }
        /// <summary>
        /// 本次登录的过期时间（默认为3hr，数据库可修改默认值）
        /// </summary>
        [Persistence(ColumnName = "ExpireDate", IsExtend=true)]
        public DateTime ExpireDate
        {
            set { _expireDate = value; }
            get { return _expireDate; }
        }
        private DateTime _createDate = DateTime.Now;
        /// <summary>
        /// 用户创建时间
        /// </summary>
        [Persistence(ColumnName = "CreateDate")]
        public DateTime CreateDate
        {
            set { _createDate = value; }
            get { return _createDate; }
        }

        /// <summary>
        /// 本次登录的过期时间（默认为3hr，数据库可修改默认值）
        /// </summary>
        [Persistence(IsExtend = true)]
        public IList<MenuInfo> MenuList
        {
            set { _mList = value; }
            get { return _mList; }
        }

		#endregion Model

	}
}


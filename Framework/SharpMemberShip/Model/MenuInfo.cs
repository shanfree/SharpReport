/********************************************************************************************
 * 文件名称: MenuInfo.cs
 * 设计人员: 严向晖 （yanxianghui@gmail.com）
 * 设计时间: 2013/2/19
 * 功能描述: 
 * 注意事项: 
 * 版权所有: Copyright (c) 2013, Fujian SIRC
 * 修改记录:       修改时间     人员     修改备注
 *	----------	   --------		-----     -----------------------------------------
 * 
 ********************************************************************************************/

using System;
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip.Model
{
	/// <summary>
	/// 实体类MenuInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[Persistence(ColumnName = "Menu")]
    public class MenuInfo : ITreeNode
	{
        /// <summary>
        /// 默认根节点主键
        /// </summary>
        public const string DEFAULT_PARENT_ID = "1";

		public MenuInfo()
		{}

		#region 持久化字段
		private string _id;
		/// <summary>
		/// 主键
		/// </summary>
		[Persistence(IsPrimaryKey = true, ColumnName = "ID")]
		public string ID
		{
			set
			{
				 _id = value;
			}
			get
			{
				return _id;
			}
		}
		private string _name;
		/// <summary>
		/// 栏目名称
		/// </summary>
		[Persistence(ColumnName = "Name")]
		public string Name
		{
			set
			{
				 _name = value;
			}
			get
			{
				return _name;
			}
		}
		private string _remark;
		/// <summary>
		/// 描述信息
		/// </summary>
		[Persistence(ColumnName = "Remark")]
		public string Remark
		{
			set
			{
				 _remark = value;
			}
			get
			{
				return _remark;
			}
		}
		private string _menucode;
		/// <summary>
		/// 栏目代码，00为根栏目，0000-00FF为其一级子栏目，依次类推。
		/// </summary>
		[Persistence(ColumnName = "MenuCode")]
		public string MenuCode
		{
			set
			{
				 _menucode = value;
			}
			get
			{
				return _menucode;
			}
		}
		private string _url;
		/// <summary>
		/// 栏目URL地址。
		/// </summary>
		[Persistence(ColumnName = "URL")]
		public string URL
		{
			set
			{
				 _url = value;
			}
			get
			{
				return _url;
			}
		}
		private string _target;
		/// <summary>
        /// 栏目脚本的目标框架blank,self,top
		/// </summary>
		[Persistence(ColumnName = "Target")]
		public string Target
		{
			set
			{
				 _target = value;
			}
			get
			{
				return _target;
			}
		}
		private string _parentid;
		/// <summary>
		/// 
		/// </summary>
		[Persistence(ColumnName = "ParentID")]
        public string ParentID
		{
			set
			{
				 _parentid = value;
			}
			get
			{
				return _parentid;
			}
		}
		#endregion 持久化字段

	} 
}


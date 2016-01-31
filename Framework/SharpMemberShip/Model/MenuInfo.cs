/********************************************************************************************
 * �ļ�����: MenuInfo.cs
 * �����Ա: ������ ��yanxianghui@gmail.com��
 * ���ʱ��: 2013/2/19
 * ��������: 
 * ע������: 
 * ��Ȩ����: Copyright (c) 2013, Fujian SIRC
 * �޸ļ�¼:       �޸�ʱ��     ��Ա     �޸ı�ע
 *	----------	   --------		-----     -----------------------------------------
 * 
 ********************************************************************************************/

using System;
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip.Model
{
	/// <summary>
	/// ʵ����MenuInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	[Persistence(ColumnName = "Menu")]
    public class MenuInfo : ITreeNode
	{
        /// <summary>
        /// Ĭ�ϸ��ڵ�����
        /// </summary>
        public const string DEFAULT_PARENT_ID = "1";

		public MenuInfo()
		{}

		#region �־û��ֶ�
		private string _id;
		/// <summary>
		/// ����
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
		/// ��Ŀ����
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
		/// ������Ϣ
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
		/// ��Ŀ���룬00Ϊ����Ŀ��0000-00FFΪ��һ������Ŀ���������ơ�
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
		/// ��ĿURL��ַ��
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
        /// ��Ŀ�ű���Ŀ����blank,self,top
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
		#endregion �־û��ֶ�

	} 
}


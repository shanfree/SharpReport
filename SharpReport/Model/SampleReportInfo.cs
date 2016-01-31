/**  版本信息模板在安装目录下，可自行修改。
* SampleReport.cs
*
* 功 能： N/A
* 类 名： SampleReport
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
    /// SampleReport:样例报表(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Persistence(ColumnName = "SampleReport")]
    public partial class SampleReportInfo
	{
        /// <summary>
        /// 
        /// </summary>
        public SampleReportInfo()
		{}
		#region Model
		private string _id;
		private int _userid;
		private int _reporttypeid;
		private DateTime _createtime= DateTime.Now;
		private int _dateid;
		private decimal? _data1;
		private decimal? _data2;
		private decimal? _data3;
		private string _approvedocument;
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
        [Persistence(ColumnName = "UserID")]
        public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "ReportTypeID")]
        public int ReportTypeID
		{
			set{ _reporttypeid=value;}
			get{return _reporttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "CreateTime")]
        public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "DateID")]
        public int DateID
		{
			set{ _dateid=value;}
			get{return _dateid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "Data1")]
        public decimal? Data1
		{
			set{ _data1=value;}
			get{return _data1;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "Data2")]
        public decimal? Data2
		{
			set{ _data2=value;}
			get{return _data2;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "Data3")]
        public decimal? Data3
		{
			set{ _data3=value;}
			get{return _data3;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "ApproveDocument")]
        public string ApproveDocument
		{
			set{ _approvedocument=value;}
			get{return _approvedocument;}
		}
		#endregion Model

	}
}


/**  版本信息模板在安装目录下，可自行修改。
* BeijianInput.cs
*
* 功 能： N/A
* 类 名： BeijianInput
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
	/// BeijianInput:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    [Persistence(ColumnName = "BeijianInput")]
    public partial class BeijianInputInfo : ReportBaseInfo
	{
        public BeijianInputInfo()
		{}
        public BeijianInputInfo(string ID)
        {
            this.ID = ID;
        }

		#region Model
		private string _总数="0";
		private string _主机;
		private string _副机;
		private string _舾装;
		private string _电器;
		private string _辅机;
		private string _分油机;

		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "总数")]
        public string 总数
		{
			set{ _总数=value;}
            get
            {
                string result = NumericHandler.StringAdd(this.主机, this.副机);
                result = NumericHandler.StringAdd(result, this.舾装);
                result = NumericHandler.StringAdd(result, this.电器);
                result = NumericHandler.StringAdd(result, this.辅机);
                result = NumericHandler.StringAdd(result, this.分油机);
                this.总数 = result;
                return _总数;
            }
        }
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "主机")]
        public string 主机
		{
			set{ _主机=value;}
			get{return _主机;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "副机")]
        public string 副机
		{
			set{ _副机=value;}
			get{return _副机;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "舾装")]
        public string 舾装
		{
			set{ _舾装=value;}
			get{return _舾装;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "电器")]
        public string 电器
		{
			set{ _电器=value;}
			get{return _电器;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "辅机")]
        public string 辅机
		{
			set{ _辅机=value;}
			get{return _辅机;}
		}
		/// <summary>
		/// 
		/// </summary>
        [Persistence(ColumnName = "分油机")]
        public string 分油机
		{
			set{ _分油机=value;}
			get{return _分油机;}
		}
		#endregion Model

	}
}


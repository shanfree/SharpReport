/**  版本信息模板在安装目录下，可自行修改。
* WuliaoInput.cs
*
* 功 能： N/A
* 类 名： WuliaoInput
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
    /// WuliaoInput:物料报表信息(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "WuliaoInput")]
    public partial class WuliaoInputInfo : ReportBaseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public WuliaoInputInfo()
        { }
        public WuliaoInputInfo(string ID)
        {
            this.ID = ID;
        }

        #region Model
        private string _总数 = "0";
        private string _生产用品;
        private string _生活用品;
        private string _办公用品;
        private string _油漆;
        private string _缆绳;
        private string _锁具;
        private string _药品;
        private string _其他;

        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "总数")]
        public string 总数
        {
            set { _总数 = value; }
            get
            {
                string result = NumericHandler.StringAdd(this.办公用品, this.生活用品);
                result = NumericHandler.StringAdd(result, this.生产用品);
                result = NumericHandler.StringAdd(result, this.锁具);
                result = NumericHandler.StringAdd(result, this.药品);
                result = NumericHandler.StringAdd(result, this.油漆);
                result = NumericHandler.StringAdd(result, this.缆绳);
                result = NumericHandler.StringAdd(result, this.其他);
                this.总数 = result;
                return _总数;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "生产用品")]
        public string 生产用品
        {
            set { _生产用品 = value; }
            get { return _生产用品; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "生活用品")]
        public string 生活用品
        {
            set { _生活用品 = value; }
            get { return _生活用品; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "办公用品")]
        public string 办公用品
        {
            set { _办公用品 = value; }
            get { return _办公用品; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "油漆")]
        public string 油漆
        {
            set { _油漆 = value; }
            get { return _油漆; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "缆绳")]
        public string 缆绳
        {
            set { _缆绳 = value; }
            get { return _缆绳; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "锁具")]
        public string 锁具
        {
            set { _锁具 = value; }
            get { return _锁具; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "药品")]
        public string 药品
        {
            set { _药品 = value; }
            get { return _药品; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "其他")]
        public string 其他
        {
            set { _其他 = value; }
            get { return _其他; }
        }
        #endregion Model
    }
}


/**  版本信息模板在安装目录下，可自行修改。
* OilTypeInfo.cs
*
* 功 能： N/A
* 类 名： OilTypeInfo
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/10 11:00:00   matthewzjq    初版
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
    /// OilTypeInfo:油品(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "OilType")]
    public partial class OilTypeInfo
    {
        public OilTypeInfo()
        { }
        #region Model
        private string _id;
        private string _name;
        private int _category;
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
        /// 油品名称
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 注释
        /// </summary>
        [Persistence(ColumnName = "Category")]
        public int Category
        {
            set { _category = value; }
            get { return _category; }
        }
        #endregion Model

    }
}


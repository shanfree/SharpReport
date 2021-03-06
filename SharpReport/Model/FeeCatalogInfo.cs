﻿/**  版本信息模板在安装目录下，可自行修改。
* FeeCatalog.cs
*
* 功 能： N/A
* 类 名： FeeCatalog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:42   N/A    初版
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
    /// FeeCatalog:报表类型(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class FeeCatalogInfo
    {
        public FeeCatalogInfo()
        { }

        public FeeCatalogInfo(string id)
        {
            this._id = id;
        }

        #region Model
        private string _id;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private string _name;
        /// <summary>
        /// 费用类型
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        private string _departmentID;
        /// <summary>
        /// 所在单位
        /// </summary>
        [Persistence(ColumnName = "DepartmentID")]
        public string DepartmentID
        {
            set { _departmentID = value; }
            get { return _departmentID; }
        }
        #endregion Model

    }
}


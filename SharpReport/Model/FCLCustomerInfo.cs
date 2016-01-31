/**  版本信息模板在安装目录下，可自行修改。
* Voyage.cs
*
* 功 能： N/A
* 类 名： Voyage
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
    /// Voyage:航次(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "FCLCustomer", ExtendName = "V_FCLCustomer")]
    public partial class FCLCustomerInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public FCLCustomerInfo()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public FCLCustomerInfo(string ID)
        {
            this._id = ID;
        }

        #region Model

        private string _id;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _Name;
        /// <summary>
        /// 客户名称
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Fee = "";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Fee")]
        public string Fee
        {
            get { return _Fee; }
            set { _Fee = value; }
        }
        private string _gp20 = "";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "gp20")]
        public string gp20
        {
            get { return _gp20; }
            set { _gp20 = value; }
        }
        private string _gp40 = "";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "gp40")]
        public string gp40
        {
            get { return _gp40; }
            set { _gp40 = value; }
        }

        private string _dp20 = "";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "dp20")]
        public string dp20
        {
            get { return _dp20; }
            set { _dp20 = value; }
        }
        private string _dp40 = "";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "dp40")]
        public string dp40
        {
            get { return _dp40; }
            set { _dp40 = value; }
        }

        private string _FCLID = "";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "FCLID")]
        public string FCLID
        {
            get { return _FCLID; }
            set { _FCLID = value; }
        }

        #endregion Model

    }
}


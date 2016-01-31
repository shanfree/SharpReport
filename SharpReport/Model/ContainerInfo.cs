/**  版本信息模板在安装目录下，可自行修改。
* Container.cs
*
* 功 能： N/A
* 类 名： Container
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
    /// Container:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "Container")]
    public partial class ContainerInfo
    {
        public ContainerInfo()
        { }
        public ContainerInfo(string ID)
        {
            this.ID = ID;
        }

        #region Model
        private string _id;
        /// <summary>
        /// 主键
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private string _insuranceID;
        /// <summary>
        /// 所属的保险报表编号
        /// </summary>
        [Persistence(ColumnName = "InsuranceID")]
        public string InsuranceID
        {
            set { _insuranceID = value; }
            get { return _insuranceID; }
        }
        private string _编号;
        /// <summary>
        /// 货柜编号
        /// </summary>
        [Persistence(ColumnName = "编号")]
        public string 编号
        {
            set { _编号 = value; }
            get { return _编号; }
        }
        private string _投保金额 = "0";
        /// <summary>
        /// 单位：万元
        /// </summary>
        [Persistence(ColumnName = "投保金额")]
        public string 投保金额
        {
            set { _投保金额 = value; }
            get { return _投保金额; }
        }

        private string _货柜类型 = "1";
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "货柜类型")]
        public string 货柜类型
        {
            set { _货柜类型 = value; }
            get { return _货柜类型; }
        }
        private string _备注;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "备注")]
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }

        #endregion Model

    }
}


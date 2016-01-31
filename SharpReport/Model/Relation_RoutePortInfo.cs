/**  版本信息模板在安装目录下，可自行修改。
* Relation_RoutePortInfo.cs
*
* 功 能： N/A
* 类 名： Relation_RoutePortInfo
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/4/13 23:54:00   matthewzjq    初版
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
    /// Relation_RoutePortInfo:航线港口对应关系(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "Relation_RoutePort")]
    public partial class Relation_RoutePortInfo
    {
        public Relation_RoutePortInfo()
        { }
        #region Model
        private string _id;
        private int _routeid;
        private int _portid;
        private int _porttypeid;
        private string _ordernum;
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
        /// 航线ID
        /// </summary>
        [Persistence(ColumnName = "RouteID")]
        public int RouteID
        {
            set { _routeid = value; }
            get { return _routeid; }
        }
        /// <summary>
        /// 港口ID
        /// </summary>
        [Persistence(ColumnName = "PortID")]
        public int PortID
        {
            set { _portid = value; }
            get { return _portid; }
        }
        /// <summary>
        /// 港口类型ID
        /// </summary>
        [Persistence(ColumnName = "PortTypeID")]
        public int PortTypeID
        {
            set { _porttypeid = value; }
            get { return _porttypeid; }
        }
        /// <summary>
        /// OrderNum
        /// </summary>
        [Persistence(ColumnName = "OrderNum")]
        public string OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        #endregion Model

    }
}

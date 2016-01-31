/**  版本信息模板在安装目录下，可自行修改。
* Port.cs
*
* 功 能： N/A
* 类 名： Port
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
    /// Port:港口(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "Port")]
    public partial class PortInfo
    {

        public PortInfo()
        {

        }

        #region Model
        private string _id;
        private string _name;
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
        /// 港口名称
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        private string _routeID;
        /// <summary>
        /// 所在的航线ID
        /// </summary>
        [Persistence(ColumnName = "RouteID", IsExtend = true)]
        public string RouteID
        {
            set { _routeID = value; }
            get { return _routeID; }
        }

        private string _portTypeID;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "PortTypeID", IsExtend = true)]
        public string PortTypeID
        {
            set { _portTypeID = value; }
            get { return _portTypeID; }
        }

        private string _orderNum;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "OrderNum", IsExtend = true)]
        public string OrderNum
        {
            set { _orderNum = value; }
            get { return _orderNum; }
        }
        #endregion Model

    }
}


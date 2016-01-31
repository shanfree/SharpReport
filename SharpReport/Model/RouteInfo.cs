/**  版本信息模板在安装目录下，可自行修改。
* Route.cs
*
* 功 能： N/A
* 类 名： Route
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
    /// Route:航线(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "Route")]
    public partial class RouteInfo
    {
        public RouteInfo()
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
        /// 航线名称
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        private float _distance;
        /// <summary>
        /// 航线距离（海里）
        /// </summary>
        [Persistence(ColumnName = "Distance")]
        public float Distance
        {
            set { _distance = value; }
            get { return _distance; }
        }

        private string _totalRoute;
        /// <summary>
        /// 航线表述
        /// </summary>
        [Persistence(ColumnName = "TotalRoute", IsLazyLoad = true)]
        public string TotalRoute
        {
            set { _totalRoute = value; }
            get { return _totalRoute; }
        }

        #endregion Model

    }
}


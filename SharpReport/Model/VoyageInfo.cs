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
    [Persistence(ColumnName = "Voyage", ExtendName = "V_Voyage")]
    public partial class VoyageInfo
    {
        public VoyageInfo()
        { }
        #region Model
        private string _id;
        private string _name;
        private int _routeid;
        private int _shipid;
        private string _hangcibaseid;
        private DateTime _begindate = DateTime.Now;
        private DateTime _enddate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 航次名称
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 航次baseid
        /// </summary>
        [Persistence(ColumnName = "HangciBaseID")]
        public string HangciBaseID
        {
            get { return _hangcibaseid; }
            set { _hangcibaseid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "RouteID")]
        public int RouteID
        {
            get { return _routeid; }
            set { _routeid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "ShipID")]
        public int ShipID
        {
            get { return _shipid; }
            set { _shipid = value; }
        }

        private int _orderNum = 1;
        /// <summary>
        /// 手动的排序号，默认为1
        /// </summary>
        [Persistence(ColumnName = "OrderNum")]
        public int OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }


        /// <summary>
        /// 航次起始时间
        /// </summary>
        [Persistence(ColumnName = "BeginDate")]
        public DateTime BeginDate
        {
            get { return _begindate; }
            set { _begindate = value; }
        }
        /// <summary>
        /// 航次结束时间
        /// </summary>
        [Persistence(ColumnName = "EndDate")]
        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }
        /// <summary>
        /// 开始到结束经过的小时数
        /// </summary>
        public int DiffHours
        {
            get
            {
                TimeSpan ts1 = new TimeSpan(EndDate.Ticks);
                TimeSpan ts2 = new TimeSpan(BeginDate.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                int diffHours = int.Parse(ts.TotalHours.ToString());
                return diffHours;
            }
        }
        private string _sName;
        /// <summary>
        /// 起始港
        /// </summary>
        [Persistence(ColumnName = "sName", IsExtend = true)]
        public string sName
        {
            get { return _sName; }
            set { _sName = value; }
        }
        private string _eName;
        /// <summary>
        /// 目的港
        /// </summary>
        [Persistence(ColumnName = "eName", IsExtend = true)]
        public string eName
        {
            get { return _eName; }
            set { _eName = value; }
        }


        private string _shipName;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "ShipName", IsExtend = true)]
        public string ShipName
        {
            get { return _shipName; }
            set { _shipName = value; }
        }

        private float _distance;
        /// <summary>
        /// 航线距离（公里）
        /// </summary>
        [Persistence(ColumnName = "Distance", IsExtend = true)]
        public float Distance
        {
            set { _distance = value; }
            get { return _distance; }
        }

        private string _Captain;
        /// <summary>
        /// 船长
        /// </summary>
        [Persistence(ColumnName = "Captain", IsExtend = true)]
        public string Captain
        {
            get { return _Captain; }
            set { _Captain = value; }
        }

        private string _ChiefEngineer;
        /// <summary>
        /// 轮机
        /// </summary>
        [Persistence(ColumnName = "ChiefEngineer", IsExtend = true)]
        public string ChiefEngineer
        {
            get { return _ChiefEngineer; }
            set { _ChiefEngineer = value; }
        }

        private string _GeneralManager;
        /// <summary>
        /// 大副
        /// </summary>
        [Persistence(ColumnName = "GeneralManager", IsExtend = true)]
        public string GeneralManager
        {
            get { return _GeneralManager; }
            set { _GeneralManager = value; }
        }

        private string _ManagerTypeID;
        /// <summary>
        /// 经营类型
        /// </summary>
        [Persistence(ColumnName = "ManagerTypeID")]
        public string ManagerTypeID
        {
            get { return _ManagerTypeID; }
            set { _ManagerTypeID = value; }
        }

        /// <summary>
        /// 船舶运行时间，精确到小数点4位
        /// </summary>
        public string LastingDays
        {
            get
            {
                string stime = this.BeginDate.Date.ToString("yyyy-MM-dd");
                if (stime.Equals("1900-01-01"))
                {
                    return "--";
                }
                stime = this.EndDate.Date.ToString("yyyy-MM-dd");
                if (stime.Equals("1900-01-01"))
                {
                    return "--";
                }
                TimeSpan tspan = this.EndDate - this.BeginDate;
                return String.Format("{0:N4}", tspan.TotalDays);
            }
        }

        #endregion Model

    }
}


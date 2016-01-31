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
    /// VoyageConsume:航次消耗
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "VoyageConsume")]
    public partial class VoyageConsumeInfo
    {
        public VoyageConsumeInfo()
		{}
		#region Model
        private string _id;
		private int _baseinputid;
		private int _shipcomponentid;
        private float _mainslowworktime;
        private float _maincruiseworktime;
        private float _voyageworktime;
        private float _fuelconsume;
        private float _dieselconsume;
        private float _otherconsume;
		/// <summary>
		/// ID
		/// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 航次ID
		/// </summary>
        [Persistence(ColumnName = "BaseInputID")]
        public int BaseInputID
		{
            set { _baseinputid = value; }
            get { return _baseinputid; }
		}
		/// <summary>
		/// 船舶部件ID
		/// </summary>
        [Persistence(ColumnName = "ShipComponentID")]
        public int ShipComponentID
		{
            set { _shipcomponentid = value; }
            get { return _shipcomponentid; }
		}
		/// <summary>
        /// 主机慢车工作时间
		/// </summary>
        [Persistence(ColumnName = "MainSlowWorkTime")]
        public float MainSlowWorkTime
		{
            set { _mainslowworktime = value; }
            get { return _mainslowworktime; }
		}
        /// <summary>
        /// 主机定速工作时间
        /// </summary>
        [Persistence(ColumnName = "MainCruiseWorkTime")]
        public float MainCruiseWorkTime
        {
            set { _maincruiseworktime = value; }
            get { return _maincruiseworktime; }
        }
        /// <summary>
        /// 主副机航次工作时间
        /// </summary>
        [Persistence(ColumnName = "VoyageWorkTime")]
        public float VoyageWorkTime
        {
            set { _voyageworktime = value; }
            get { return _voyageworktime; }
        }
        /// <summary>
        /// 燃料油
        /// </summary>
        [Persistence(ColumnName = "FuelConsume")]
        public float FuelConsume
        {
            set { _fuelconsume = value; }
            get { return _fuelconsume; }
        }
        /// <summary>
        /// 柴油
        /// </summary>
        [Persistence(ColumnName = "DieselConsume")]
        public float DieselConsume
        {
            set { _dieselconsume = value; }
            get { return _dieselconsume; }
        }
        /// <summary>
        /// 其他
        /// </summary>
        [Persistence(ColumnName = "OtherConsume")]
        public float OtherConsume
        {
            set { _otherconsume = value; }
            get { return _otherconsume; }
        }
		#endregion Model
    }
}

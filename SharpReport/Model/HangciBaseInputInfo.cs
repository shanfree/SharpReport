/**  版本信息模板在安装目录下，可自行修改。
* HangciBaseInputInfo.cs
*
* 功 能： N/A
* 类 名： HangciBaseInputInfo
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/14 18:00:00   matthewzjq    初版
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
    /// HangciBaseInputInfo:航次基表
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "HangciBaseInput")]
    public partial class HangciBaseInputInfo
    {
        public HangciBaseInputInfo()
        { }
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
        private DateTime _shipinputdate=DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "ShipInputDate")]
        public DateTime ShipInputDate
        {
            set { _shipinputdate = value; }
            get { return _shipinputdate; }
        }
        private DateTime _generalmanagerdate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "GeneralManagerDate")]
        public DateTime GeneralManagerDate
        {
            set { _generalmanagerdate = value; }
            get { return _generalmanagerdate; }
        }
        #endregion Model
    }
}

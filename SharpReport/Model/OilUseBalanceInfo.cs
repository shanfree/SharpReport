/**  版本信息模板在安装目录下，可自行修改。
* OilUseBalanceInfo.cs
*
* 功 能： N/A
* 类 名： OilUseBalanceInfo
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/4/14 15:36:00   matthewzjq    初版
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
    /// OilUseBalanceInfo:燃润油领用结存（吨）
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "OilUseBalance")]
    public partial class OilUseBalanceInfo
    {
        public OilUseBalanceInfo()
        { }
        #region Model
        private string _id;
        private int _baseinputid;
        private int _oiltypeid;
        private float _remaining;
        private float _addition;
        private float _consuming;
        private float _balance;
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
        /// 
        /// </summary>
        [Persistence(ColumnName = "BaseInputID")]
        public int BaseInputID
        {
            set { _baseinputid = value; }
            get { return _baseinputid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "OilTypeID")]
        public int OilTypeID
        {
            set { _oiltypeid = value; }
            get { return _oiltypeid; }
        }
        /// <summary>
        /// 上航次结存
        /// </summary>
        [Persistence(ColumnName = "Remaining")]
        public float Remaining
        {
            set { _remaining = value; }
            get { return _remaining; }
        }
        /// <summary>
        /// 本航次添加数
        /// </summary>
        [Persistence(ColumnName = "Addition")]
        public float Addition
        {
            set { _addition = value; }
            get { return _addition; }
        }
        /// <summary>
        /// 本航次消耗数
        /// </summary>
        [Persistence(ColumnName = "Consuming")]
        public float Consuming
        {
            set { _consuming = value; }
            get { return _consuming; }
        }
        /// <summary>
        /// 本航次结存量
        /// </summary>
        [Persistence(ColumnName = "Balance")]
        public float Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        #endregion Model
    }
}

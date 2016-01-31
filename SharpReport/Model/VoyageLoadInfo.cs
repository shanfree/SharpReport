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
    [Persistence(ColumnName = "VoyageLoad", ExtendName = "V_VoyageLoad")]
    public partial class VoyageLoadInfo
    {
        public VoyageLoadInfo()
        { }
        public VoyageLoadInfo(string ID)
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

        #region 集装箱

        private string _VoyageID;
        /// <summary>
        /// 船舶该航次装载情况
        /// </summary>
        [Persistence(ColumnName = "VoyageID")]
        public string VoyageID
        {
            get { return _VoyageID; }
            set { _VoyageID = value; }
        }

        private string _teuEmpty = "0";
        /// <summary>
        /// twenty-foot equivalent unit 20空
        /// </summary>
        [Persistence(ColumnName = "TEUEmpty")]
        public string TEUEmpty
        {
            get { return _teuEmpty; }
            set { _teuEmpty = value; }
        }
        private string _teuHeavy = "0";
        /// <summary>
        /// twenty-foot equivalent unit 20重
        /// </summary>
        [Persistence(ColumnName = "TEUHeavy")]
        public string TEUHeavy
        {
            get { return _teuHeavy; }
            set { _teuHeavy = value; }
        }
        private string _teuFrost = "0";
        /// <summary>
        /// twenty-foot equivalent unit 20冰冻
        /// </summary>
        [Persistence(ColumnName = "TEUFrost")]
        public string TEUFrost
        {
            get { return _teuFrost; }
            set { _teuFrost = value; }
        }

        private string _feuEmpty = "0";
        /// <summary>
        /// twenty-foot equivalent unit 40空
        /// </summary>
        [Persistence(ColumnName = "FEUEmpty")]
        public string FEUEmpty
        {
            get { return _feuEmpty; }
            set { _feuEmpty = value; }
        }
        private string _feuHeavy = "0";
        /// <summary>
        /// twenty-foot equivalent unit 40重
        /// </summary>
        [Persistence(ColumnName = "FEUHeavy")]
        public string FEUHeavy
        {
            get { return _feuHeavy; }
            set { _feuHeavy = value; }
        }
        private string _feuFrost = "0";
        /// <summary>
        /// twenty-foot equivalent unit 40冰冻
        /// </summary>
        [Persistence(ColumnName = "FEUFrost")]
        public string FEUFrost
        {
            get { return _feuFrost; }
            set { _feuFrost = value; }
        }
        private string _feuDanger = "0";
        /// <summary>
        /// twenty-foot equivalent unit 40危险
        /// </summary>
        [Persistence(ColumnName = "FEUDanger")]
        public string FEUDanger
        {
            get { return _feuDanger; }
            set { _feuDanger = value; }
        }

        private string _ffeuEmpty = "0";
        /// <summary>
        /// Forty-five-foot equivalent unit 45空
        /// </summary>
        [Persistence(ColumnName = "FFEUEmpty")]
        public string FFEUEmpty
        {
            get { return _ffeuEmpty; }
            set { _ffeuEmpty = value; }
        }
        private string _ffeuHeavy = "0";
        /// <summary>
        /// twenty-foot equivalent unit 45重
        /// </summary>
        [Persistence(ColumnName = "FFEUHeavy")]
        public string FFEUHeavy
        {
            get { return _ffeuHeavy; }
            set { _ffeuHeavy = value; }
        }
        private string _ffeuFrost = "0";
        /// <summary>
        /// twenty-foot equivalent unit 45冰冻
        /// </summary>
        [Persistence(ColumnName = "FFEUFrost")]
        public string FFEUFrost
        {
            get { return _ffeuFrost; }
            set { _ffeuFrost = value; }
        }
        private string _ffeuDanger = "0";
        /// <summary>
        /// twenty-foot equivalent unit 45危险
        /// </summary>
        [Persistence(ColumnName = "FFEUDanger")]
        public string FFEUDanger
        {
            get { return _ffeuDanger; }
            set { _ffeuDanger = value; }
        }

        private string _rest = "0";
        /// <summary>
        /// 特殊的柜
        /// </summary>
        [Persistence(ColumnName = "Rest")]
        public string Rest
        {
            get { return _rest; }
            set { _rest = value; }
        }

        private string _equalTo = "0";
        /// <summary>
        /// 相当于多少个标准箱
        /// </summary>
        [Persistence(ColumnName = "EqualTo")]
        public string EqualTo
        {
            get { return _equalTo; }
            set { _equalTo = value; }
        }

        private string _TotalNat = "0";
        /// <summary>
        /// 自然柜总数
        /// </summary>
        [Persistence(ColumnName = "TotalNat")]
        public string TotalNat
        {
            get { return _TotalNat; }
            set { _TotalNat = value; }
        }

        private string _TotalStand = "0";
        /// <summary>
        /// 相当于多少个标准箱
        /// </summary>
        [Persistence(ColumnName = "TotalStand")]
        public string TotalStand
        {
            get { return _TotalStand; }
            set { _TotalStand = value; }
        }
        #endregion

        #endregion Model

    }
}


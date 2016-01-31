/**  版本信息模板在安装目录下，可自行修改。
* OilFeeReport.cs
*
* 功 能： N/A
* 类 名： OilFeeReport
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
    /// OilFeeReport:物料报表信息(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "OilFeeReport")]
    public partial class OilFeeReportInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public OilFeeReportInfo()
        { }
        public OilFeeReportInfo(string ID)
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

        private string _inputuserid;
        /// <summary>
        /// 登记人
        /// </summary>
        [Persistence(ColumnName = "InputUserID")]
        public string InputUserID
        {
            set { _inputuserid = value; }
            get { return _inputuserid; }
        }
        private string _approveuserid;
        /// <summary>
        /// 财务部审核人员
        /// </summary>
        [Persistence(ColumnName = "ApproveUserID")]
        public string ApproveUserID
        {
            set { _approveuserid = value; }
            get { return _approveuserid; }
        }
        private string _reportTypeID = string.Empty;
        /// <summary>
        /// 预估录入、修正录入、财务确认
        /// </summary>
        [Persistence(ColumnName = "ReportTypeID")]
        public string ReportTypeID
        {
            set { _reportTypeID = value; }
            get { return _reportTypeID; }
        }
        private DateTime _createtime = DateTime.Now;
        /// <summary>
        /// 报表创建时间
        /// </summary>
        [Persistence(ColumnName = "CreateTime")]
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }

        private string _VoyageID = string.Empty;
        /// <summary>
        /// 对应航次ID
        /// </summary>
        [Persistence(ColumnName = "VoyageID")]
        public string VoyageID
        {
            set { _VoyageID = value; }
            get { return _VoyageID; }
        }

        #region 扩展列
        private string _VoyageName = string.Empty;
        /// <summary>
        /// 航次名称（扩展列）
        /// </summary>
        [Persistence(ColumnName = "VoyageName", IsExtend = true)]
        public string VoyageName
        {
            set { _VoyageName = value; }
            get { return _VoyageName; }
        }

        private string _InputUserName = string.Empty;
        /// <summary>
        /// 登记人（扩展列）
        /// </summary>
        [Persistence(ColumnName = "InputUserName", IsExtend = true)]
        public string InputUserName
        {
            set { _InputUserName = value; }
            get { return _InputUserName; }
        }

        private string _ApproveUserName = string.Empty;
        /// <summary>
        /// 财务确认人（扩展列）
        /// </summary>
        [Persistence(ColumnName = "ApproveUserName", IsExtend = true)]
        public string ApproveUserName
        {
            set { _ApproveUserName = value; }
            get { return _ApproveUserName; }
        }

        #endregion
        #endregion Model
    }
}


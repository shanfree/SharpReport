/**  版本信息模板在安装目录下，可自行修改。
* ReportType.cs
*
* 功 能： N/A
* 类 名： ReportType
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Sirc.SharpReport.IDAL;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;

namespace Sirc.SharpReport.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:ReportType
    /// </summary>
    public partial class ReportType : DBPersistenceBase<ReportTypeInfo>, IReportType
    {
        public ReportType()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM ReportType WHERE ID = @ID";
        #endregion

        /// <summary>
        /// 连接串
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                return DBConnection.ConnectionString;
            }
        }

    }
}


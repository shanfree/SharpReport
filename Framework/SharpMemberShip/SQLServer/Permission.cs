/**  版本信息模板在安装目录下，可自行修改。
* Permission.cs
*
* 功 能： N/A
* 类 名： Permission
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
using SIRC.Framework.SharpMemberShip.IDAL;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
using System.Collections.Generic;

namespace SIRC.Framework.SharpMemberShip.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Permission
    /// </summary>
    public partial class Permission : DBPersistenceBase<PermissionInfo>, IPermission
    {
        public Permission()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Permission WHERE ID = @ID";

        private const string SQL_SELECT_GroupID = @"SELECT * FROM Permission WHERE GroupID = @GroupID";

        #endregion

        /// <summary>
        /// 连接串
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                return DBConnection.MembershipConnectionString;
            }
        }

                /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="permissionGroupID">权限组ID</param>
        /// <returns>列表</returns>
        public IList<PermissionInfo> GetList(string permissionGroupID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@GroupID", permissionGroupID);
            string sql = SQL_SELECT_GroupID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<PermissionInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }
    }
}


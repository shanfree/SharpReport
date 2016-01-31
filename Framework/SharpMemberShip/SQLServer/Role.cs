/**  版本信息模板在安装目录下，可自行修改。
* Role.cs
*
* 功 能： N/A
* 类 名： Role
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
    /// 数据访问类:Role
    /// </summary>
    public partial class Role : DBPersistenceBase<RoleInfo>, IRole
    {
        public Role()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM [Role] WHERE ID = @ID";

        private const string SQL_SELECT_BY_UserID = @"SELECT * FROM [V_Role] WHERE UserID = @UserID";

        private const string SQL_SELECT_BY_MenuID = @"SELECT * FROM [V_Role] WHERE UserID = @UserID";

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
        /// 根据用户主键获取角色列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<RoleInfo> GetListByUserID(string userID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", userID);
            string sql = SQL_SELECT_BY_UserID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<RoleInfo> list = GetListFromReader(dr, false, false);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list;
        }
        /// <summary>
        /// 根据栏目主键获取绑定的角色列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<RoleInfo> GetListByMenuID(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            string sql = @"
                                    select RoleID as ID,RoleName as Name,RoleRemark as Remark from
                                    V_MenuPGroupRole
                                    where ID = @MenuID";
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<RoleInfo> list = GetListFromReader(dr, false, false);
            return list;
        }


    }
}


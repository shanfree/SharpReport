/**  版本信息模板在安装目录下，可自行修改。
* User.cs
*
* 功 能： N/A
* 类 名： User
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
    /// 数据访问类:User
    /// </summary>
    public partial class User : DBPersistenceBase<UserInfo>, IUser
    {
        public User()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM [V_User] WHERE ID = @ID";

        private const string SQL_SELECT_BY_NAME = @"SELECT ID FROM [V_User] WHERE Name = @Name and Password=@Password";

        private const string SQL_INSERT_GUID =
                                @"
                                DELETE FROM [UserLoginGUID] WHERE UserID = @UserID
                                INSERT INTO [UserLoginGUID](UserID) VALUES (@UserID)
                                SELECT [GUID] FROM [UserLoginGUID] WHERE [UserID] = @UserID";

        private const string SQL_SELECT_GUID = @"SELECT * FROM V_User WHERE GUID = @GUID";
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
        /// 根据单点guid得到用户信息
        /// </summary>
        /// <param name="guid">单点guid</param>
        /// <returns></returns>
        public UserInfo GetUserInfoByGuid(string guid)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@GUID", guid);
            string sql = SQL_SELECT_GUID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<UserInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 用户登录的方法，返回会话GUID，该GUID作为获取帐户信息，权限验证的凭据
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>会话GUID</returns>
        public string Login(string userName, string password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Name", userName);
            param[1] = new SqlParameter("@Password", password);
            string sql = SQL_SELECT_BY_NAME;
            Object o = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, param);
            string userID = (null == o) ? string.Empty : o.ToString();

            SqlParameter[] param1 = new SqlParameter[1];
            param1[0] = new SqlParameter("@UserID", userID);
            string sql1 = SQL_INSERT_GUID;
            Object result = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql1, param1);
            string guid = (null == result) ? string.Empty : result.ToString();
            return guid;
        }

        /// <summary>
        /// 为用户添加角色
        /// </summary>
        /// <param name="userID">用户</param>
        /// <param name="roleIDArray">要绑定的角色ID数组</param>
        /// <returns></returns>
        public void AddRoles(string userID, string[] roleIDArray)
        {
            for (int i = 0; i < roleIDArray.Length; i++)
            {
                string roleID = roleIDArray[i];
                string sql = @"
                                        DELETE FROM [Relation_User_Role] WHERE UserID = @UserID
                                        INSERT INTO [Relation_User_Role] ([UserID],[RoleID]) VALUES (@UserID,@RoleID)";
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@UserID", userID);
                param[1] = new SqlParameter("@RoleID", roleID);
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
            }
        }
    }
}


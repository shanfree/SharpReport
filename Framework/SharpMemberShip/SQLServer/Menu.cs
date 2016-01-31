/**  版本信息模板在安装目录下，可自行修改。
* Menu.cs
*
* 功 能： N/A
* 类 名： Menu
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
    /// 数据访问类:Menu
    /// </summary>
    public partial class Menu : DBPersistenceBase<MenuInfo>, IMenu
    {
        public Menu()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Menu WHERE ID = @ID";

        private const string SQL_SELECT_GetTreeByUserID =
            @"
                --显示所有子栏目树
                SELECT * FROM
                (
                select m.* from Menu m, dbo.V_MenuRole mr
                where m.MenuCode like mr.MenuCode  + '%' and
                mr.UserID = @UserID and m. Visable = 1
                union
                --显示所有直系上级节点
                SELECT m.* from dbo.Menu m,dbo.V_MenuRole vm
                WHERE vm.MenuCode like (m.MenuCode + '%[0-9]') and 
                UserID = @UserID and Visable = 1
                ) AS T
                ORDER BY OrderID ";

        private const string SQL_SELECT_CHILD_MAX_MENUCODE =
    @"SELECT Max(MenuCode) from dbo.Menu
        WHERE ParentID= @ParentID";

        private const string SQL_SELECT_ChildTree = @"SELECT * from dbo.fGetMenuTree(@ID)";

        private const string SQL_SELECT_RolePGCode = @"
                                                                                        SELECT PermissionGroupCode FROM V_MenuRole
                                                                                        WHERE [GUID] = @GUID AND ID = @MenuID";

        private const string SQL_INSERT_Relation_MenuPGroup_Role =
            @"INSERT INTO [Relation_MenuPGroup_Role]
           ([MenuID],[PermissionGroupCode],[RoleID]) VALUES(@MenuID,@PermissionGroupCode,@RoleID) SELECT @@IDENTITY";

        private const string SQL_DELETE_MenuPGroup = @"DELETE [Relation_MenuPGroup] WHERE MenuID = @MenuID";


        private const string SQL_INSERT_MenuPGroup =
                        @"INSERT INTO [Relation_MenuPGroup]
                           ([MenuID]
                           ,[PermissionGroupID])
                            VALUES
                           (@MenuID,@PermissionGroupID) SELECT @@IDENTITY";
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
        /// 根据栏目节点ID获取整个栏目树
        /// </summary>
        /// <param name="rootID">根节点栏目ID</param>
        /// <returns>栏目树</returns>
        public IList<MenuInfo> GetTree(string rootID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", rootID);
            //获取所有子栏目树节点
            string sql = SQL_SELECT_ChildTree;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<MenuInfo> mList = GetListFromReader(dr, false, true);
            //添加根节点
            MenuInfo rootInfo = GetByID(rootID);
            mList.Insert(0, rootInfo);
            return mList;
        }
        /// <summary>
        /// 根据用户ID获取整个栏目树
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>栏目树</returns>
        public IList<MenuInfo> GetTreeByUserID(string userID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", userID);
            string sql = SQL_SELECT_GetTreeByUserID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<MenuInfo> mList = GetListFromReader(dr, false, true);
            return mList;
        }

        /// <summary>
        /// 移除栏目对应的所有栏目组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <returns>操作是否成功</returns>
        public bool RemoveAllPermissionGroup(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            string sql = SQL_DELETE_MenuPGroup;
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
            return true;
        }

        /// <summary>
        /// 为栏目绑定权限组，栏目绑定唯一的权限组，
        /// 如果需要增加栏目对应的权限，请对栏目组进行权限扩充
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <param name="permissionGroupID">权限组ID</param>
        public string AddPermissionGroup(string menuID, string permissionGroupID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            param[1] = new SqlParameter("@PermissionGroupID", permissionGroupID);
            string sql = SQL_INSERT_MenuPGroup;
            object o = SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
            string result = (o == null) ? string.Empty : o.ToString();
            return result;
        }

        /// <summary>
        /// 为单一角色绑定栏目的权限组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="permissionGroupCode">权限组代码，假设某个权限组为：浏览1，修改10，删除100，审批1000。该用户在该栏目的权限组代码1011表示，具有浏览修改和审批权限，而不具有删除权限</param>
        public void AddRoleToMenu(string menuID, string roleID, string permissionGroupCode)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            param[1] = new SqlParameter("@PermissionGroupCode", permissionGroupCode);
            param[2] = new SqlParameter("@RoleID", roleID);
            string sql = SQL_INSERT_Relation_MenuPGroup_Role;
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
        }
        /// <summary>
        /// 初始化栏目权限，删除目前栏目关联的所有角色
        /// </summary>
        /// <param name="menuID"></param>
        public void InitialMenuRole(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            string sql = @"DELETE RMR 
                                    FROM dbo.Relation_MenuPGroup_Role RMR,dbo.Relation_MenuPGroup RMP
                                    WHERE 
                                    RMR.MenuPGRelationID = RMP.ID AND
                                    RMP.MenuID = @MenuID";
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
        }

        /// <summary>
        /// 获取子栏目最大的栏目代码
        /// </summary>
        /// <param name="menuID">父栏目ID</param>
        /// <returns>栏目编码，同级编号为00～99</returns>
        public string GetMaxChildCode(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ParentID", menuID);
            string sql = SQL_SELECT_CHILD_MAX_MENUCODE;
            object o = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, param);
            return (o == null) ? string.Empty : o.ToString();
        }
        /// <summary>
        /// 用户角色在该栏目拥有的位值
        /// </summary>
        /// <param name="menuID">栏目主键</param>
        /// <param name="userSignonGUID">用户登录后的验证串</param>
        /// <returns></returns>
        public string GetPermissionGroupCodeOfMenuByGUID(string menuID, string userSignonGUID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MenuID", menuID);
            param[1] = new SqlParameter("@GUID", userSignonGUID);
            string sql = SQL_SELECT_RolePGCode;
            object o = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, param);
            return (o == null) ? string.Empty : o.ToString();
        }
        /// <summary>
        /// 用户角色在该栏目拥有的位值
        /// </summary>
        /// <param name="menuID">栏目主键</param>
        /// <param name="roleID">角色主键</param>
        /// <returns></returns>
        public string GetPermissionGroupCodeOfMenuByRole(string menuID, string roleID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MenuID", menuID);
            param[1] = new SqlParameter("@RoleID", roleID);
            string sql = @"SELECT PermissionGroupCode FROM V_MenuPGroupRole
                                WHERE RoleID = @RoleID AND ID = @MenuID";
            object o = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, param);
            return (o == null) ? string.Empty : o.ToString();
        }

    }
}


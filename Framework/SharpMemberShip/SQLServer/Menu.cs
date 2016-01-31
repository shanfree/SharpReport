/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* Menu.cs
*
* �� �ܣ� N/A
* �� ���� Menu
*
* Ver    �������             ������  �������
* ����������������������������������������������������������������������
* V0.01  2013/2/14 14:15:41   N/A    ����
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*������������������������������������������������������������������������
*�����˼�����ϢΪ����˾������Ϣ��δ������˾����ͬ���ֹ���������¶������
*������Ȩ���У�����׿Խ���������Ƽ����޹�˾������������������������������
*������������������������������������������������������������������������
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
    /// ���ݷ�����:Menu
    /// </summary>
    public partial class Menu : DBPersistenceBase<MenuInfo>, IMenu
    {
        public Menu()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM Menu WHERE ID = @ID";

        private const string SQL_SELECT_GetTreeByUserID =
            @"
                --��ʾ��������Ŀ��
                SELECT * FROM
                (
                select m.* from Menu m, dbo.V_MenuRole mr
                where m.MenuCode like mr.MenuCode  + '%' and
                mr.UserID = @UserID and m. Visable = 1
                union
                --��ʾ����ֱϵ�ϼ��ڵ�
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
        /// ���Ӵ�
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                return DBConnection.MembershipConnectionString;
            }
        }

        /// <summary>
        /// ������Ŀ�ڵ�ID��ȡ������Ŀ��
        /// </summary>
        /// <param name="rootID">���ڵ���ĿID</param>
        /// <returns>��Ŀ��</returns>
        public IList<MenuInfo> GetTree(string rootID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", rootID);
            //��ȡ��������Ŀ���ڵ�
            string sql = SQL_SELECT_ChildTree;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<MenuInfo> mList = GetListFromReader(dr, false, true);
            //��Ӹ��ڵ�
            MenuInfo rootInfo = GetByID(rootID);
            mList.Insert(0, rootInfo);
            return mList;
        }
        /// <summary>
        /// �����û�ID��ȡ������Ŀ��
        /// </summary>
        /// <param name="userID">�û�ID</param>
        /// <returns>��Ŀ��</returns>
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
        /// �Ƴ���Ŀ��Ӧ��������Ŀ��
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <returns>�����Ƿ�ɹ�</returns>
        public bool RemoveAllPermissionGroup(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            string sql = SQL_DELETE_MenuPGroup;
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, param);
            return true;
        }

        /// <summary>
        /// Ϊ��Ŀ��Ȩ���飬��Ŀ��Ψһ��Ȩ���飬
        /// �����Ҫ������Ŀ��Ӧ��Ȩ�ޣ������Ŀ�����Ȩ������
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <param name="permissionGroupID">Ȩ����ID</param>
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
        /// Ϊ��һ��ɫ����Ŀ��Ȩ����
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <param name="roleID">��ɫID</param>
        /// <param name="permissionGroupCode">Ȩ������룬����ĳ��Ȩ����Ϊ�����1���޸�10��ɾ��100������1000�����û��ڸ���Ŀ��Ȩ�������1011��ʾ����������޸ĺ�����Ȩ�ޣ���������ɾ��Ȩ��</param>
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
        /// ��ʼ����ĿȨ�ޣ�ɾ��Ŀǰ��Ŀ���������н�ɫ
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
        /// ��ȡ����Ŀ������Ŀ����
        /// </summary>
        /// <param name="menuID">����ĿID</param>
        /// <returns>��Ŀ���룬ͬ�����Ϊ00��99</returns>
        public string GetMaxChildCode(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ParentID", menuID);
            string sql = SQL_SELECT_CHILD_MAX_MENUCODE;
            object o = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, param);
            return (o == null) ? string.Empty : o.ToString();
        }
        /// <summary>
        /// �û���ɫ�ڸ���Ŀӵ�е�λֵ
        /// </summary>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="userSignonGUID">�û���¼�����֤��</param>
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
        /// �û���ɫ�ڸ���Ŀӵ�е�λֵ
        /// </summary>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="roleID">��ɫ����</param>
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


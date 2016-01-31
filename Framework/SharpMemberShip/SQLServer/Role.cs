/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* Role.cs
*
* �� �ܣ� N/A
* �� ���� Role
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
    /// ���ݷ�����:Role
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
        /// �����û�������ȡ��ɫ�б�
        /// </summary>
        /// <returns>�б�</returns>
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
        /// ������Ŀ������ȡ�󶨵Ľ�ɫ�б�
        /// </summary>
        /// <returns>�б�</returns>
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


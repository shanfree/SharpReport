/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* Permission.cs
*
* �� �ܣ� N/A
* �� ���� Permission
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
    /// ���ݷ�����:Permission
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="permissionGroupID">Ȩ����ID</param>
        /// <returns>�б�</returns>
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


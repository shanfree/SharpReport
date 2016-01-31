/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* PermissionGroup.cs
*
* �� �ܣ� N/A
* �� ���� PermissionGroup
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
    /// ���ݷ�����:PermissionGroup
    /// </summary>
    public partial class PermissionGroup : DBPersistenceBase<PermissionGroupInfo>, IPermissionGroup
    {
        public PermissionGroup()
        { }

        #region sql
        private const string SQL_SELECT = @"SELECT * FROM PermissionGroup WHERE ID = @ID";

        private const string SQL_SELECT_MENUID = @"SELECT * FROM V_PermissionGroup WHERE MenuID = @MenuID";

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
        /// ��ȡ��Ŀ�󶨵�Ȩ����
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <returns>��Ŀ��Ӧ��Ȩ����</returns>
        public PermissionGroupInfo GetByMenuID(string menuID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MenuID", menuID);
            string sql = SQL_SELECT_MENUID;
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sql, param);
            IList<PermissionGroupInfo> list = GetListFromReader(dr, false, true);
            if (null == list || list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

    }
}


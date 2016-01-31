using System;
using System.Data;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;

namespace SIRC.Framework.SharpMemberShip.IDAL
{
    /// <summary>
    /// �ӿڲ�IMenu ��ժҪ˵����
    /// </summary>
    public interface IPermissionGroup : IDBPersistenceBase<PermissionGroupInfo>
    {
        /// <summary>
        /// ��ȡ��Ŀ�󶨵�Ȩ����
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <returns>��Ŀ��Ӧ��Ȩ����</returns>
        PermissionGroupInfo GetByMenuID(string menuID);
        /// <summary>
        /// ��Ȩ�������Ŀ
        /// </summary>
        /// <param name="permissionGroupID">Ȩ����ID</param>
        /// <param name="menuID">��ĿID</param>
        /// <returns>�Ƿ�󶨳ɹ�</returns>
        //bool BindGroupToMenu(string permissionGroupID, string menuID);

    }
}

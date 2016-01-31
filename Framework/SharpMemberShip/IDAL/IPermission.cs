using System;
using System.Data;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
using System.Collections.Generic;

namespace SIRC.Framework.SharpMemberShip.IDAL
{
    /// <summary>
    /// �ӿڲ�IMenu ��ժҪ˵����
    /// </summary>
    public interface IPermission : IDBPersistenceBase<PermissionInfo>
    {
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="permissionGroupID">Ȩ����ID</param>
        /// <returns>�б�</returns>
        IList<PermissionInfo> GetList(string permissionGroupID);

    }
}

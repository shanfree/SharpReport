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
    public interface IRole : IDBPersistenceBase<RoleInfo>
    {
        IList<RoleInfo> GetListByUserID(string userID);
        /// <summary>
        /// ������Ŀ������ȡ��ɫ�б�
        /// </summary>
        /// <returns>�б�</returns>
        IList<RoleInfo> GetListByMenuID(string menuID);


    }
}

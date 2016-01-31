using System;
using System.Data;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
using System.Collections.Generic;

namespace SIRC.Framework.SharpMemberShip.IDAL
{
    /// <summary>
    /// 接口层IMenu 的摘要说明。
    /// </summary>
    public interface IPermission : IDBPersistenceBase<PermissionInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="permissionGroupID">权限组ID</param>
        /// <returns>列表</returns>
        IList<PermissionInfo> GetList(string permissionGroupID);

    }
}

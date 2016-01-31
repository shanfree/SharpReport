using System;
using System.Data;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;

namespace SIRC.Framework.SharpMemberShip.IDAL
{
    /// <summary>
    /// 接口层IMenu 的摘要说明。
    /// </summary>
    public interface IPermissionGroup : IDBPersistenceBase<PermissionGroupInfo>
    {
        /// <summary>
        /// 获取栏目绑定的权限组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <returns>栏目对应的权限组</returns>
        PermissionGroupInfo GetByMenuID(string menuID);
        /// <summary>
        /// 绑定权限组和栏目
        /// </summary>
        /// <param name="permissionGroupID">权限组ID</param>
        /// <param name="menuID">栏目ID</param>
        /// <returns>是否绑定成功</returns>
        //bool BindGroupToMenu(string permissionGroupID, string menuID);

    }
}

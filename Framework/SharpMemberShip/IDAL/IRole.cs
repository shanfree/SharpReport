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
    public interface IRole : IDBPersistenceBase<RoleInfo>
    {
        IList<RoleInfo> GetListByUserID(string userID);
        /// <summary>
        /// 根据栏目主键获取角色列表
        /// </summary>
        /// <returns>列表</returns>
        IList<RoleInfo> GetListByMenuID(string menuID);


    }
}

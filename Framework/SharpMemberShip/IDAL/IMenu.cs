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
    public interface IMenu : IDBPersistenceBase<MenuInfo>
    {
        /// <summary>
        /// 根据栏目节点ID获取整个栏目树
        /// </summary>
        /// <param name="rootID">根节点栏目ID</param>
        /// <returns>栏目树</returns>
        IList<MenuInfo> GetTree(string rootID);

        /// <summary>
        /// 获取子栏目最大的栏目代码
        /// </summary>
        /// <param name="menuID">父栏目ID</param>
        /// <returns>栏目编码，同级编号为00～99</returns>
        string GetMaxChildCode(string menuID);

        /// <summary>
        /// 根据用户ID获取整个栏目树
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>栏目树</returns>
        IList<MenuInfo> GetTreeByUserID(string userID);

        /// <summary>
        /// 移除栏目对应的所有栏目组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <returns>操作是否成功</returns>
        bool RemoveAllPermissionGroup(string menuID);

        /// <summary>
        /// 为栏目绑定权限组，栏目绑定唯一的权限组，
        /// 如果需要增加栏目对应的权限，请对栏目组进行权限扩充
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <param name="permissionGroupID">权限组ID</param>
        string AddPermissionGroup(string menuID, string permissionGroupID);

        /// <summary>
        /// 为单一角色绑定栏目的权限组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="permissionGroupCode">权限组代码，假设某个权限组为：浏览1，修改10，删除100，审批1000。该用户在该栏目的权限组代码1011表示，具有浏览修改和审批权限，而不具有删除权限</param>
        void AddRoleToMenu(string menuID, string roleID, string permissionGroupCode);

        /// <summary>
        /// 用户角色在该栏目拥有的位值
        /// </summary>
        /// <param name="menuID">栏目主键</param>
        /// <param name="userSignonGUID">用户登录后的验证串</param>
        /// <returns></returns>
        string GetPermissionGroupCodeOfMenuByGUID(string menuID, string userSignonGUID);

        /// <summary>
        /// 用户角色在该栏目拥有的位值
        /// </summary>
        /// <param name="menuID">栏目主键</param>
        /// <param name="roleID">角色主键</param>
        /// <returns></returns>
        string GetPermissionGroupCodeOfMenuByRole(string menuID, string userSignonGUID);

        /// <summary>
        /// 初始化栏目权限，删除目前栏目关联的所有角色
        /// </summary>
        /// <param name="menuID"></param>
        void InitialMenuRole(string menuID);
    }
}

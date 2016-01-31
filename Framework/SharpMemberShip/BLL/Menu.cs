/**  版本信息模板在安装目录下，可自行修改。
* Menu.cs
*
* 功 能： N/A
* 类 名： Menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:38   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip.Model;
using SIRC.Framework.SharpMemberShip.IDAL;
using DAL = SIRC.Framework.SharpMemberShip.SQLServerDAL;
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip.BLL
{
    /// <summary> 
    /// 栏目
    /// </summary>
    public partial class Menu
    {
        //根节点主键
        private const string ROOT_ID = "1";

        private readonly IMenu dal = new DAL.Menu();

        public Menu()
        { }

        /// <summary>
        /// 根据栏目节点ID获取整个栏目树
        /// </summary>
        /// <param name="rootID">根节点栏目ID</param>
        /// <returns>栏目树</returns>
        public TreeNodeInfo<MenuInfo> GetTree(string rootID)
        {
            if (string.IsNullOrEmpty(rootID))
            {
                rootID = ROOT_ID;
            }
            IList<MenuInfo> mList = dal.GetTree(rootID);
            TreeNodeInfo<MenuInfo> treeNode = new TreeNodeInfo<MenuInfo>(mList, rootID);
            return treeNode;
        }

        /// <summary>
        /// 根据用户ID获取整个栏目树
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>栏目树</returns>
        public TreeNodeInfo<MenuInfo> GetTreeByUserID(string userID, string rootID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                throw new ArgumentNullException("用户ID不能为空。");
            }
            IList<MenuInfo> mList = dal.GetTreeByUserID(userID);
            TreeNodeInfo<MenuInfo> treeNode = new TreeNodeInfo<MenuInfo>(mList, rootID);
            return treeNode;
        }

        /// <summary>
        /// 为栏目绑定权限组，栏目绑定唯一的权限组，
        /// 该栏目下的所有子栏目将同时绑定相同的权限组，
        /// 如果需要增加栏目对应的权限，请对栏目组进行权限扩充
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <param name="permissionGroupID">权限组ID</param>
        public string AddPermissionGroup(string menuID, string permissionGroupID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("栏目ID不能为空。");
            }
            if (string.IsNullOrEmpty(permissionGroupID))
            {
                throw new ArgumentNullException("权限组ID不能为空。");
            }
            // 更改当前栏目的权限组
            dal.RemoveAllPermissionGroup(menuID);
            string result = dal.AddPermissionGroup(menuID, permissionGroupID);
            // 更改子栏目的权限组
            TreeNodeInfo<MenuInfo> menuTree = GetTree(menuID);
            if (menuTree.SubNodeList == null || menuTree.SubNodeList.Count == 0)
            {
                return result;
            }
            foreach (TreeNodeInfo<MenuInfo> mInfo in menuTree.SubNodeList)
            {
                //递归实现
                AddPermissionGroup(mInfo.STInstance.ID, permissionGroupID);
            }
            return result;
        }
        #region 将角色和栏目以及权限组进行绑定
        /// <summary>
        /// 将角色和栏目以及权限组进行绑定
        /// </summary>
        /// <param name="menuID">栏目</param>
        /// <param name="permissionGroupID">权限</param>
        /// <param name="rList">角色列表</param>
        public void AddRolesToMenu(string menuID, string permissionGroupID, IList<RoleInfo> rList)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("请选择栏目");
            }
            if (string.IsNullOrEmpty(permissionGroupID))
            {
                throw new ArgumentNullException("请选择权限组绑定。");
            }
            if (rList == null || rList.Count == 0)
            {
                throw new ArgumentNullException("请选择至少一个角色进行绑定。");
            }
            string relationID = string.Empty;
            PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(menuID);
            if (pgInfo == null || pgInfo.ID != permissionGroupID)
            {
                // 栏目未绑定任何权限组，则先进行绑定
                relationID = new BLL.Menu().AddPermissionGroup(menuID, permissionGroupID);
            }
            else
            {
                relationID = pgInfo.RelationID;
            }
            //删除栏目权限组组合所对应的所有角色
            InitialMenuRole(menuID);
            foreach (RoleInfo rInfo in rList)
            {
                string defaultCode = new PermissionGroup().GetDefaultCodeFromPermissionGroupID(permissionGroupID);
                AddRoleToMenu(menuID, rInfo.ID, defaultCode);
            }
        }

        /// <summary>
        /// 初始化栏目权限，删除目前栏目关联的所有角色
        /// </summary>
        /// <param name="menuID"></param>
        private void InitialMenuRole(string menuID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("请指定栏目ID。");
            }
            dal.InitialMenuRole(menuID);
        }

        /// <summary>
        /// 为单一角色绑定栏目的权限组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="permissionGroupCode">权限组代码，假设某个权限组为：浏览1，修改10，删除100，审批1000。该用户在该栏目的权限组代码1011表示，具有浏览修改和审批权限，而不具有删除权限</param>
        public void AddRoleToMenu(string menuID, string roleID, string permissionGroupCode)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("栏目ID不能为空。");
            }
            if (string.IsNullOrEmpty(roleID))
            {
                throw new ArgumentNullException("角色ID不能为空。");
            }
            if (string.IsNullOrEmpty(permissionGroupCode))
            {
                throw new ArgumentNullException("权限组代码不能为空。");
            }
            // 判断权限组代码是否对应权限组
            PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(menuID);
            IList<PermissionInfo> pList = new Permission().GetList(pgInfo.ID);
            if (pList == null)
            {
                throw new Exception("栏目" + menuID + "对应的权限组不存在");
            }
            if (permissionGroupCode.Length != pList.Count)
            {
                throw new Exception("角色添加失败，权限组代码的长度和权限数目不相等。");
            }
            dal.AddRoleToMenu(menuID, roleID, permissionGroupCode);
        }
        #endregion


        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="parentMenuID">父节点ID</param>
        /// <param name="cInfo">添加的栏目，“栏目代码信息”（MenuCode）属性为系统自动生成。如系统已存在父节点（0103），并且具有2个同级节点，同级节点的最大编号为（010302），则该节点编号为010303</param>
        /// <returns>新增实体的主键</returns>
        public string AddChild(string parentMenuID, MenuInfo cInfo)
        {
            if (string.IsNullOrEmpty(parentMenuID))
            {
                throw new ArgumentNullException("父节点ID不能为空。");
            }
            // 生成新增栏目的栏目代码
            string maxChildCode = new Menu().getMaxChildCode(parentMenuID);
            MenuInfo pInfo = new Menu().GetByID(parentMenuID);
            // 末2位+1，为空则为00；
            if (string.IsNullOrEmpty(maxChildCode))
            {
                cInfo.MenuCode = pInfo.MenuCode + "00";
            }
            else
            {
                // 默认编码为00～99
                int width = 2;
                string max = maxChildCode.Substring(maxChildCode.Length - width);
                int maxNum = int.Parse(max);
                cInfo.MenuCode = pInfo.MenuCode + String.Format("{0:D2}", maxNum++); ;
            }
            cInfo.ParentID = parentMenuID;
            string menuID = dal.Add(cInfo);
            //获取副栏目权限组，子节点默认绑定
            PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(parentMenuID);
            if (null != pgInfo && string.IsNullOrEmpty(pgInfo.ID) == true)
            {
                AddPermissionGroup(menuID, pgInfo.ID);
            }
            return menuID;
        }
        /// <summary>
        /// 获取子栏目最大的栏目代码
        /// </summary>
        /// <param name="menuID">父栏目ID</param>
        /// <returns>栏目编码，同级编号为00～99</returns>
        private string getMaxChildCode(string menuID)
        {
            return dal.GetMaxChildCode(menuID);
        }

        /// <summary>
        /// 添加同辈节点
        /// </summary>
        /// <param name="peerMenuID">同辈节点ID</param>
        /// <param name="cInfo">添加的栏目，“栏目代码信息”（MenuCode）属性为系统自动生成</param>
        /// <returns>新增实体的主键</returns>
        public string AddPeer(string peerMenuID, MenuInfo cInfo)
        {
            if (string.IsNullOrEmpty(peerMenuID))
            {
                throw new ArgumentNullException("同级节点ID不能为空。");
            }
            MenuInfo peerNode = GetByID(peerMenuID);
            return AddChild(peerNode.ParentID, cInfo);
        }

        /// <summary>
        /// 判断用户是否对特定的栏目具有特定的权限
        /// </summary>
        /// <param name="permissions">用户请求的权限</param>
        /// <param name="menuID">栏目主键</param>
        /// <param name="userSignonGUID">用户登录后的验证串</param>
        /// <returns></returns>
        public bool CanUserProcessOperation(int permissions, string menuID, string userSignonGUID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("栏目ID不能为空。");
            }
            if (string.IsNullOrEmpty(userSignonGUID))
            {
                throw new ArgumentNullException("用户未登录或者登录已经过期。");
            }
            // 该权限对应的位值
            // 用户角色在该栏目拥有的位值
            string roleCode = GetPermissionGroupCodeOfMenuByGUID(menuID, userSignonGUID);
            if (string.IsNullOrEmpty(roleCode))
            {
                // 如果未绑定任何权限组，则对任何权限验证提示失败
                return false;
            }
            int roleCodeNum = int.Parse(roleCode);
            if ((permissions & roleCodeNum) == permissions)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断用户是否对特定的栏目具有特定的权限
        /// </summary>
        /// <param name="permissions">用户请求的权限</param>
        /// <param name="menuID">栏目主键</param>
        /// <param name="userSignonGUID">用户登录后的验证串</param>
        /// <returns></returns>
        public bool CanUserProcessOperation(DefaultPermissions permissions, string menuID, string userSignonGUID)
        {
            int perCodeNum = EnumHandler<DefaultPermissions>.GetIntFromEnum(permissions);
            return CanUserProcessOperation(perCodeNum, menuID, userSignonGUID);
        }

        /// <summary>
        /// 用户角色在该栏目拥有的位值
        /// </summary>
        /// <param name="menuID">栏目主键</param>
        /// <param name="userSignonGUID">用户登录后的验证串</param>
        /// <returns></returns>
        private string GetPermissionGroupCodeOfMenuByGUID(string menuID, string userSignonGUID)
        {
            return dal.GetPermissionGroupCodeOfMenuByGUID(menuID, userSignonGUID);
        }

        /// <summary>
        /// 用户角色在该栏目拥有的位值
        /// </summary>
        /// <param name="menuID">栏目主键</param>
        /// <param name="roleID">角色主键</param>
        /// <returns></returns>
        public string GetPermissionGroupCodeOfMenuByRole(string menuID, string roleID)
        {
            return dal.GetPermissionGroupCodeOfMenuByRole(menuID, roleID);
        }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<MenuInfo> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 获取用户具有权限的栏目列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<MenuInfo> GetList(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                throw new ArgumentNullException("用户ID不能为空。");
            }
            IList<MenuInfo> mList = dal.GetTreeByUserID(userID);
            return mList;
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public MenuInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(MenuInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            MenuInfo cInfo = new MenuInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


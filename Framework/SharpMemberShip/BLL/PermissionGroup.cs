/**  版本信息模板在安装目录下，可自行修改。
* PermissionGroup.cs
*
* 功 能： N/A
* 类 名： PermissionGroup
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

namespace SIRC.Framework.SharpMemberShip.BLL
{
    /// <summary>
    /// 部门
    /// </summary>
    public partial class PermissionGroup
    {
        private readonly IPermissionGroup dal = new DAL.PermissionGroup();

        public PermissionGroup()
        { }

        /// <summary>
        /// 获取栏目绑定的权限组
        /// </summary>
        /// <param name="menuID">栏目ID</param>
        /// <returns>栏目对应的权限组</returns>
        public PermissionGroupInfo GetByMenuID(string menuID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("栏目ID不能为空。");
            }
            return dal.GetByMenuID(menuID);
        }

        /// <summary>
        /// 根据栏目组主键获取默认权限编码（全部权限为拒绝）
        /// </summary>
        /// <param name="ID">权限组ID</param>
        /// <returns>权限组编码，权限组代码，假设某个权限组为：浏览1，修改10，删除100，审批1000。
        /// 该用户在该栏目的默认权限组代码0000表示无任何权限</returns>
        public string GetDefaultCodeFromPermissionGroupID(string ID)
        {
            // TODO:应该能针对任意权限组生成
            return "0000";
        }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<PermissionGroupInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public PermissionGroupInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(PermissionGroupInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(PermissionGroupInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            PermissionGroupInfo cInfo = new PermissionGroupInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


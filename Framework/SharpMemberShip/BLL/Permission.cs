/**  版本信息模板在安装目录下，可自行修改。
* Permission.cs
*
* 功 能： N/A
* 类 名： Permission
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
    public partial class Permission
    {
        private readonly IPermission dal = new DAL.Permission();

        public Permission()
        { }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="permissionGroupID">权限组ID</param>
        /// <returns>列表</returns>
        public IList<PermissionInfo> GetList(string permissionGroupID)
        {
            if (string.IsNullOrEmpty(permissionGroupID))
            {
                throw new ArgumentNullException("权限组ID不能为空。");
            }

            return dal.GetList(permissionGroupID);
        }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<PermissionInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public PermissionInfo GetByID(string ID)
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
        public string Add(PermissionInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(PermissionInfo cInfo)
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
            PermissionInfo cInfo = new PermissionInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


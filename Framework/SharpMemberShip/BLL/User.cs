/**  版本信息模板在安装目录下，可自行修改。
* User.cs
*
* 功 能： N/A
* 类 名： User
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
    /// 用户
    /// </summary>
    public partial class User
    {
        private readonly IUser dal = new DAL.User();

        public User()
        { }

        /// <summary>
        /// 根据单点guid得到用户信息
        /// </summary>
        /// <param name="guid">单点guid</param>
        /// <returns></returns>
        public UserInfo GetUserInfoByGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                throw new ArgumentNullException("用户身份标识不能为空。");
            }
            UserInfo uInfo = dal.GetUserInfoByGuid(guid);
            if (null != uInfo && string.IsNullOrEmpty(uInfo.ID) == false)
            {
                uInfo.MenuList = new Menu().GetList(uInfo.ID);
            }
            return uInfo;
        }

        /// <summary>
        /// 用户登录的方法，返回会话GUID，该GUID作为获取帐户信息，权限验证的凭据
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>会话GUID</returns>
        public string Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("用户名称不能为空。");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("用户密码不能为空。");
            }
            string guid = dal.Login(userName, password);
            return guid;
        }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<UserInfo> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns>列表</returns>
        public virtual IList<UserInfo> GetList(bool isLazyLaod, bool isExtend)
        {
            return dal.GetList(isLazyLaod, isExtend);
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public UserInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="departmentID"></param>
        /// <returns>新增实体的主键</returns>
        public string Add(string name, string password, string departmentID)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("用户名称不能为空。");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("用户密码不能为空。");
            }
            if (string.IsNullOrEmpty(departmentID))
            {
                throw new ArgumentNullException("所属部门不能为空。");
            }
            UserInfo cInfo = new UserInfo();
            cInfo.Name = name;
            cInfo.Password = password;
            cInfo.DepartmentID = departmentID;
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 为用户添加角色
        /// </summary>
        /// <param name="userID">用户</param>
        /// <param name="roleIDArray">要绑定的角色ID数组</param>
        /// <returns></returns>
        public void AddRoles(string userID, string[] roleIDArray)
        {
            if (string.IsNullOrEmpty(userID))
            {
                throw new ArgumentNullException("用户不能为空。");
            }
            if (roleIDArray == null || roleIDArray.Length == 0)
            {
                throw new ArgumentNullException("角色不能为空。");
            }
            dal.AddRoles(userID, roleIDArray);

        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="departmentID"></param>
        public void Update(string ID, string name, string password, string departmentID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("用户不能为空。");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("用户名称不能为空。");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("用户密码不能为空。");
            }
            if (string.IsNullOrEmpty(departmentID))
            {
                throw new ArgumentNullException("所属部门不能为空。");
            }
            UserInfo cInfo = new UserInfo();
            cInfo.ID = ID;
            cInfo.Name = name;
            cInfo.Password = password;
            cInfo.DepartmentID = departmentID;
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            UserInfo cInfo = new UserInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


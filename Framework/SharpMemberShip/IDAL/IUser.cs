/**  版本信息模板在安装目录下，可自行修改。
* User.cs
*
* 功 能： N/A
* 类 名： User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 14:15:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
namespace SIRC.Framework.SharpMemberShip.IDAL
{
    /// <summary>
    /// 接口层User
    /// </summary>
    public interface IUser : IDBPersistenceBase<UserInfo>
    {
        /// <summary>
        /// 根据单点guid得到用户信息
        /// </summary>
        /// <param name="guid">单点guid</param>
        /// <returns></returns>
        UserInfo GetUserInfoByGuid(string guid); 

                /// <summary>
        /// 用户登录的方法，返回会话GUID，该GUID作为获取帐户信息，权限验证的凭据
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>会话GUID</returns>
        string Login(string userName, string password);

                /// <summary>
        /// 为用户添加角色
        /// </summary>
        /// <param name="userID">用户</param>
        /// <param name="roleIDArray">要绑定的角色ID数组</param>
        /// <returns></returns>
        void AddRoles(string userID, string[] roleIDArray);



    }
}

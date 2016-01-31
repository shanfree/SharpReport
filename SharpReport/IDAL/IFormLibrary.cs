/********************************************************************************************
 * 文件名称:	FormLibrary.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-11-04
 * 功能描述:	表单库文档保存的数据库访问类
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 ********************************************************************************************/
using System;
using System.Data;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace Sirc.SharpReport.IDAL
{
    public interface IFormLibrary<T>
    {
        /// <summary>
        /// 根据主键获取申请内容
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <returns>申请书实体</returns>
        string GetContentByID(string id);
       
        /// <summary>
        /// 根据主键获取申请书实体
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <returns>申请书实体</returns>
        T GetByID(string id);
        /// <summary>
        /// 添加申请书信息
        /// </summary>
        /// <param name="t">更新的内容</param>
        string Add(T t);

        /// <summary>
        /// 更新申请书信息
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <param name="t">更新的内容</param>
        void Update(string id, T t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);
    }
}

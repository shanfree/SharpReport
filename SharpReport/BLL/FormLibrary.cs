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
using System.Text;
using Sirc.SharpReport.IDAL;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;
using Sirc.SharpReport.DALFactory;

namespace Sirc.SharpReport.BLL
{
    public class FormLibrary<T>
    {
        protected virtual IFormLibrary<T> DAL
        {
            get
            { 
                return DataAccess<T>.CreateFormLibrary();
            }
        }
        /// <summary>
        /// 根据主键获取申请内容
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <returns>申请书实体</returns>
        public string GetContentByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DAL.GetContentByID(id);
        }
        /// <summary>
        /// 根据主键获取申请书实体
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <returns>申请书实体</returns>
        public T GetByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DAL.GetByID(id);
        }
                /// <summary>
        /// 添加申请书信息
        /// </summary>
        /// <param name="t">更新的内容</param>
        public string Add(T t)
        {
            return DAL.Add(t);
        }
        /// <summary>
        /// 更新申请书信息
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <param name="t">更新的内容</param>
        public void Update(string id, T t)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            DAL.Update(id, t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            DAL.Delete(id);
        }
    }
}

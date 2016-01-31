﻿/**  版本信息模板在安装目录下，可自行修改。
* InstalmentOfCompensation.cs
*
* 功 能： N/A
* 类 名： InstalmentOfCompensation
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
using Sirc.SharpReport.Model;
using Sirc.SharpReport.DALFactory;
using Sirc.SharpReport.IDAL;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 备件
    /// </summary>
    public partial class InstalmentOfCompensation
    {
        private readonly IInstalmentOfCompensation dal = DataAccess.CreateInstalmentOfCompensation();

        public InstalmentOfCompensation()
        { }

        /// <summary>
        /// 按季度，统计物料报表信息
        /// </summary>
        /// <param name="reportID">船舶险ID</param>
        /// <param name="reportType">报表类型</param>
        public IList<InstalmentOfCompensationInfo> GetList(string reportID, string reportType)
        {
            if (string.IsNullOrEmpty(reportID))
            {
                throw new ArgumentNullException("reportID不能为空。");
            }
            if (string.IsNullOrEmpty(reportType))
            {
                throw new ArgumentNullException("reportType不能为空。");
            }
            return dal.GetList(reportID, reportType);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<InstalmentOfCompensationInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public InstalmentOfCompensationInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(InstalmentOfCompensationInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(InstalmentOfCompensationInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            InstalmentOfCompensationInfo cInfo = new InstalmentOfCompensationInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


﻿/**  版本信息模板在安装目录下，可自行修改。
* RentContainer.cs
*
* 功 能： N/A
* 类 名： RentContainer
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
using SIRC.Framework.Utility;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 备件
    /// </summary>
    public class RentContainer
    {
        private readonly IRentContainer dal = DataAccess.CreateRentContainer();

        public RentContainer()
        { }



        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询</param>
        /// <returns>列表</returns>
        public IList<RentContainerInfo> GetList(string reportID)
        {
            IList<RentContainerInfo> list = new List<RentContainerInfo>();
            if (string.IsNullOrEmpty(reportID) == false)
            {
                list = dal.GetList(reportID);
            }
            RentContainerInfo rInfo = new RentContainerInfo();
            list.Add(rInfo);
            return list;
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<RentContainerInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public RentContainerInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID, false, true);
        }

        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(RentContainerInfo cInfo)
        {
            string msg = string.Empty;
            //int restInt = 0;
            //int equalInt = 0;
            //if (int.TryParse(cInfo.Rest, out restInt) && int.TryParse(cInfo.EqualTo, out equalInt))
            //{
            //    if (restInt > equalInt)
            //    {
            //        throw new ArgumentException("特殊的柜数目必须小于或者等于标准柜数目。");
            //    }
            //}
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(RentContainerInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            //string msg = string.Empty;
            //int restInt = 0;
            //int equalInt = 0;
            //if (int.TryParse(cInfo.Rest, out restInt) && int.TryParse(cInfo.EqualTo, out equalInt))
            //{
            //    if (restInt > equalInt)
            //    {
            //        throw new ArgumentException("特殊的柜数目必须小于或者等于标准柜数目。");
            //    }
            //}
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            RentContainerInfo cInfo = new RentContainerInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


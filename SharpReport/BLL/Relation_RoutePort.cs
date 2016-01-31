/**  版本信息模板在安装目录下，可自行修改。
* PortType.cs
*
* 功 能： N/A
* 类 名： Relation_RoutePort
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/13 23:54:00   matthewzjq    初版
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
    /// 航线港口对应
    /// </summary>
    public partial class Relation_RoutePort
    {
        private readonly IRelation_RoutePort dal = DataAccess.CreateRelation_RoutePort();

        public Relation_RoutePort()
        { }

        #region 成员方法
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<Relation_RoutePortInfo> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获取航线港口信息
        /// </summary>
        /// <returns>列表</returns>
        public IList<Relation_RoutePortInfo> GetListByRouteID(string routeID)
        {
            if (string.IsNullOrEmpty(routeID))
            {
                throw new ArgumentNullException("用户主键不能为空。");
            }

            return dal.GetListByRouteID(routeID);
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public Relation_RoutePortInfo GetByID(string ID)
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
        public string Add(Relation_RoutePortInfo cInfo)
        {
            // 如果是始运港，排序为0，如果是目的港，排序为99，其他类型排序号不变
            if (cInfo.PortTypeID == 2)
            {
                cInfo.OrderNum = "0";
            }
            else if (cInfo.PortTypeID == 4)
            {
                cInfo.OrderNum = "99";
            }
            else
            {
                int order = int.Parse(cInfo.OrderNum);
                if (order < 1 || order > 98)
                {
                    throw new ArgumentException("排序号必须为1-98之间的数字。");
                }
            }
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(Relation_RoutePortInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            // 如果是始运港，排序为0，如果是目的港，排序为99，其他类型排序号不变
            if (cInfo.PortTypeID == 2)
            {
                cInfo.OrderNum = "0";
            }
            else if (cInfo.PortTypeID == 4)
            {
                cInfo.OrderNum = "99";
            }
            else
            {
                int order = int.Parse(cInfo.OrderNum);
                if (order < 1 || order > 98)
                {
                    throw new ArgumentException("排序号必须为1-98之间的数字。");
                }
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
            Relation_RoutePortInfo cInfo = new Relation_RoutePortInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }

        /// <summary>
        /// 删除航线
        /// </summary>
        /// <returns>列表</returns>
        public void DeleteByRoute(string routeID)
        {
            if (string.IsNullOrEmpty(routeID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.DeleteByRoute(routeID);
        }

        #endregion
    }
}

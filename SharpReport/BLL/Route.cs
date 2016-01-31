/**  版本信息模板在安装目录下，可自行修改。
* Route.cs
*
* 功 能： N/A
* 类 名： Route
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
    /// 航线
    /// </summary>
    public partial class Route
    {
        private readonly IRoute dal = DataAccess.CreateRoute();

        public Route()
        { }


        #region 成员方法
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<RouteInfo> GetList()
        {
            return dal.GetList(true, true);
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public RouteInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID, true, true);
        }

        /// <summary>
        /// 添加航线
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(RouteInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新航线
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(RouteInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加航线
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            RouteInfo cInfo = new RouteInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public DataSet GetBaseList(int pageSize, int pageIndex)
        {
            if (pageSize < 1 || pageIndex < 0)
            {
                throw new ArgumentNullException("分页参数错误。");
            }

            return dal.GetBaseList(pageSize, pageIndex);
        }

        /// <summary>
        /// 判断路线是否被航次引用
        /// </summary>
        /// <returns>列表</returns>
        public int isRouteUsed(string routeId)
        {
            if (string.IsNullOrEmpty(routeId))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.isRouteUsed(routeId);
        }
        #endregion
    }
}


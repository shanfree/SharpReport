/**  版本信息模板在安装目录下，可自行修改。
* Port.cs
*
* 功 能： N/A
* 类 名： Port
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
    /// 港口
    /// </summary>
    public partial class Port
    {
        private readonly IPort dal = DataAccess.CreatePort();

        /// <summary>
        /// 
        /// </summary>
        public Port()
        { }

        /// <summary>
        /// 获取港口信息
        /// portType 2 始发港 4 目的港 5 经停港
        /// </summary>
        /// <returns>列表</returns>
        public DataSet GetPortListByRoute(string routeID, string portType)
        {
            if (string.IsNullOrEmpty(routeID))
            {
                throw new ArgumentNullException("路线不能为空。");
            }
            if (string.IsNullOrEmpty(portType))
            {
                throw new ArgumentNullException("港口类型。");
            }
            return dal.GetPortListByRoute(routeID, portType);
        }

        /// <summary>
        /// 按照航线和港口类型返回港口列表，按照排序号从小到大排序
        /// </summary>
        /// <param name="routeID">航线ID</param>
        /// <param name="portType">港口类型: 2 始发港 4 目的港 5 经停港</param>
        /// <returns></returns>
        public IList<PortInfo> GetList(string routeID, string portType)
        {
            if (string.IsNullOrEmpty(routeID))
            {
                throw new ArgumentNullException("路线不能为空。");
            }
            int id = 0;
            if (string.IsNullOrEmpty(portType) == false && int.TryParse(portType, out id) == false)
            {
                throw new ArgumentNullException("未识别的港口类型。");
            }
            return dal.GetList(routeID, portType);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<PortInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public PortInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加港口
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(PortInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新港口
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(PortInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加港口
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            PortInfo cInfo = new PortInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }

        #endregion
    }
}


/**  版本信息模板在安装目录下，可自行修改。
* Voyage.cs
*
* 功 能： N/A
* 类 名： Voyage
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
    /// 航次
    /// </summary>
    public partial class Voyage
    {
        private readonly IVoyage dal = DataAccess.CreateVoyage();

        public Voyage()
        { }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="voyageIds">航次主键数组</param>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetList(string[] voyageIds)
        {
            if (voyageIds == null || voyageIds.Length == 0)
            {
                throw new ArgumentNullException();
            }
            return dal.GetList(voyageIds);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetListByShipID(string shipID)
        {
            if (string.IsNullOrEmpty(shipID))
            {
                throw new ArgumentNullException("shipID不能为空。");
            }
            return dal.GetListByShipID(shipID);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶装箱报表主键</param>
        /// <returns>列表</returns>
        public VoyageInfo GetListByLoadID(string voyageLoadID)
        {
            if (string.IsNullOrEmpty(voyageLoadID))
            {
                throw new ArgumentNullException("voyageLoadID不能为空。");
            }
            return dal.GetListByLoadID(voyageLoadID);
        }

        /// <summary>
        /// 获取还未填写 船舶油料航次消耗表 的航次
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetUnReportVoyage()
        {
            return dal.GetUnReportVoyage();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public VoyageInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }
        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns>实体</returns>
        public VoyageInfo GetByID(string ID, bool isLazyLaod, bool isExtend)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID, isLazyLaod, isExtend);
        }

        /// <summary>
        /// 添加航次
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(VoyageInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.Name))
            {
                throw new ArgumentNullException("航次名称不能为空。");
            }
            if (cInfo.OrderNum < 1)
            {
                throw new ArgumentNullException("航次排序号不能小于1。");
            }
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新航次
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(VoyageInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加航次
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            VoyageInfo cInfo = new VoyageInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="isReport">是否已填写报表</param>
        /// <param name="dateID">通过报告期查询</param>
        /// <param name="shipID">通过船舶查询</param>
        /// <returns>列表</returns>
        public DataSet GetBaseList(bool isReport, string dateID, string shipID, int pageSize, int pageIndex)
        {
            int i = 0;
            if (string.IsNullOrEmpty(dateID) == false && int.TryParse(dateID, out i) == false)
            {
                throw new ArgumentNullException("参数dateID不能转化为整型。");
            }
            if (string.IsNullOrEmpty(shipID) == false && int.TryParse(shipID, out i) == false)
            {
                throw new ArgumentNullException("参数shipID不能转化为整型。");
            }
            return dal.GetBaseList(isReport, dateID, shipID, pageSize, pageIndex);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="reportID">燃润报表主键</param>
        /// <returns>列表</returns>
        public IList<VoyageInfo> GetVoyageListByReportID(string reportID)
        {
            if (string.IsNullOrEmpty(reportID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetVoyageListByReportID(reportID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns>列表</returns>
        public void UpdateVoyage(string voyageIds, string baseId)
        {
            if (string.IsNullOrEmpty(voyageIds))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            if (string.IsNullOrEmpty(baseId))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.UpdateVoyage(voyageIds, baseId);
        }

        /// <summary>
        /// 燃润报表删除后删除航次和报表的关联
        /// </summary>
        /// <param name="reportID">燃润报表ID</param>
        /// <returns>列表</returns>
        public void RanrunDelete( string reportID)
        {
            if (string.IsNullOrEmpty(reportID))
            {
                throw new ArgumentNullException("参数reportID不能为空。");
            }
            dal.RanrunDelete(reportID);
        }

        #endregion
    }
}


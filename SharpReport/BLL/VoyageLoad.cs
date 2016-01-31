/**  版本信息模板在安装目录下，可自行修改。
* VoyageLoad.cs
*
* 功 能： N/A
* 类 名： VoyageLoad
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
    public class VoyageLoad
    {
        private readonly IVoyageLoad dal = DataAccess.CreateVoyageLoad();

        public VoyageLoad()
        { }

        /// <summary>
        /// 根据航次ID获取实体
        /// </summary>
        /// <param name="voyageID">实体主键</param>
        /// <returns>实体</returns>
        public VoyageLoadInfo GetByVoyageID(string voyageID)
        {
            if (string.IsNullOrEmpty(voyageID))
            {
                throw new ArgumentNullException("航次ID不能为空。");
            }
            return dal.GetByVoyageID(voyageID);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="shipID">船舶主键</param>
        /// <returns>列表</returns>
        public IList<VoyageLoadInfo> GetList(string shipID)
        {
            if (string.IsNullOrEmpty(shipID))
            {
                throw new ArgumentNullException("参数shipID不能为空。");
            }
            return dal.GetList(shipID);
        }

        /// <summary>
        /// 获取还未填写 船舶油料航次消耗表 的航次
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageLoadInfo> GetUnReporList()
        {
            return dal.GetUnReporList();
        }

        /// <summary>
        /// 按航次进行统计
        /// </summary>
        /// <param name="fromDate">航次结束从</param>
        /// <param name="toDate">到</param>
        /// <param name="shipID">船舶</param>
        /// <param name="voyageName">航次</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet GetDataSetByQuery(string fromDate, string toDate, string shipID, string voyageName, int pageSize, int pageIndex)
        {
            return dal.GetDataSetByQuery(fromDate, toDate, shipID, voyageName, pageSize, pageIndex);
        }


        /// <summary>
        /// 按航次进行统计
        /// </summary>
        /// <param name="fromDate">航次结束从</param>
        /// <param name="toDate">到</param>
        /// <param name="voyageID">航次ID</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet GetDataSetByStatistic(string fromDate, string toDate, string shipID, int pageSize, int pageIndex)
        {
            return dal.GetDataSetByStatistic(fromDate, toDate, shipID, pageSize, pageIndex);
        }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<VoyageLoadInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public VoyageLoadInfo GetByID(string ID)
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
        public string Add(VoyageLoadInfo cInfo)
        {
            string msg = string.Empty;
            int restInt = 0;
            int equalInt = 0;
            if (int.TryParse(cInfo.Rest, out restInt) && int.TryParse(cInfo.EqualTo, out equalInt))
            {
                if (restInt > equalInt)
                {
                    throw new ArgumentException("特殊的柜数目必须小于或者等于标准柜数目。");
                }
            }
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(VoyageLoadInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            string msg = string.Empty;
            int restInt = 0;
            int equalInt = 0;
            if (int.TryParse(cInfo.Rest, out restInt) && int.TryParse(cInfo.EqualTo, out equalInt))
            {
                if (restInt > equalInt)
                {
                    throw new ArgumentException("特殊的柜数目必须小于或者等于标准柜数目。");
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
            VoyageLoadInfo cInfo = new VoyageLoadInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion

    }
}


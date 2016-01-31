/**  版本信息模板在安装目录下，可自行修改。
* OilUseBalance.cs
*
* 功 能： N/A
* 类 名： Port
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/14 23:00:00   matthewzjq    初版
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
    /// 燃润油领用结存（吨）
    /// </summary>
    public partial class OilUseBalance
    {
        private readonly IOilUseBalance dal = DataAccess.CreateOilUseBalance();

        public OilUseBalance()
        { }


        #region 成员方法
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<OilUseBalanceInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public OilUseBalanceInfo GetByID(string ID)
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
        public string Add(OilUseBalanceInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新港口
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(OilUseBalanceInfo cInfo)
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
            OilUseBalanceInfo cInfo = new OilUseBalanceInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public DataSet GetOilBalanceInfo(string baseId)
        {
            if (string.IsNullOrEmpty(baseId))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetOilBalanceInfo(baseId);
        }
        #endregion
    }
}

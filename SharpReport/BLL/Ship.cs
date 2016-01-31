/**  版本信息模板在安装目录下，可自行修改。
* Ship.cs
*
* 功 能： N/A
* 类 名： Ship
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
    /// 船舶
    /// </summary>
    public partial class Ship
    {
        private readonly IShip dal = DataAccess.CreateShip();

        public Ship()
        { }

        /// <summary>
        /// 根据报告期获取收入报表
        /// </summary>
        /// <param name="dateID">通过报告期查询，为空则返回所有</param>
        /// <param name="shipID">通过船舶查询，为空则返回所有</param>
        /// <param name="reportType">报表类型，为空则返回所有报表</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet GetIncomeMonthReport(string dateID, string shipID, int pageSize, int pageIndex)
        {
            if (string.IsNullOrEmpty(dateID))
            {
                throw new ArgumentNullException("报告期主键不能为空。");
            }
            return dal.GetIncomeMonthReport(dateID, shipID, pageSize, pageIndex);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<ShipInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public ShipInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// 添加船舶
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(ShipInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新船舶
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(ShipInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 添加船舶
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            ShipInfo cInfo = new ShipInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


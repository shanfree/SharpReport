/**  版本信息模板在安装目录下，可自行修改。
* PortType.cs
*
* 功 能： N/A
* 类 名： PortType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/2/14 19:45:38   N/A    初版
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
    /// 航次基表
    /// </summary>
    public partial class HangciBaseInput
    {
        private readonly IHangciBaseInput dal = DataAccess.CreateHangciBaseInput();

        public HangciBaseInput()
        { }


        #region 成员方法
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<HangciBaseInputInfo> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获取航次基本信息
        /// </summary>
        /// <returns>列表</returns>
        public IList<HangciBaseInputInfo> GetListByVoyageID(string voyageID)
        {
            if (string.IsNullOrEmpty(voyageID))
            {
                throw new ArgumentNullException("用户主键不能为空。");
            }

            return dal.GetListByVoyageID(voyageID);
        }

        /// <summary>
        /// 获取船舶燃料消耗统计报表
        /// 参数yyyy mm 格式
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetMonthlyReportData(string year, string month)
        {
            if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month))
            {
                throw new ArgumentNullException("年和月不能为空。");
            }

            return dal.GetMonthlyReportData(year, month);
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public HangciBaseInputInfo GetByID(string ID)
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
        public string Add(HangciBaseInputInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(HangciBaseInputInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// 删除燃润报表
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            HangciBaseInputInfo cInfo = new HangciBaseInputInfo();
            cInfo.ID = ID;
            dal.Delete(cInfo);
            // 删除航次与报表的关联
            new Voyage().RanrunDelete(ID);
        }

        /// <summary>
        /// 消耗表列表
        /// </summary>
        /// <param name="dateID">报告期ID，可以为空，显示所有报表</param>
        /// <param name="qShipName">船名，模糊查询</param>
        /// <param name="qStartDate">启航时间，可以为空</param>
        /// <param name="qEndDate">抵港时间，可以为空</param>
        /// <param name="qStartPortID">起发港ID</param>
        /// <param name="qEndPortID">目的港ID</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public DataSet GetBaseInputList(
            string dateID, string qShipName, string qStartDate, string qEndDate, string qStartPortID, string qEndPortID, int pageSize, int pageIndex)
        {
            int i = 0;
            if (string.IsNullOrEmpty(dateID) == false && int.TryParse(dateID, out i) == false)
            {
                throw new ArgumentNullException("参数dateID不能转化为整型。");
            }
            if (string.IsNullOrEmpty(qStartPortID) == false && int.TryParse(qStartPortID, out i) == false)
            {
                throw new ArgumentNullException("参数qStartPortID不能转化为整型。");
            }
            if (string.IsNullOrEmpty(qEndPortID) == false && int.TryParse(qEndPortID, out i) == false)
            {
                throw new ArgumentNullException("参数qStartPortID不能转化为整型。");
            }
            DateTime dt = DateTime.Now;
            if (string.IsNullOrEmpty(qStartDate) == false && DateTime.TryParse(qStartDate, out dt) == false)
            {
                throw new ArgumentNullException("参数qStartDate不能转化为日期。");
            }
            if (string.IsNullOrEmpty(qEndDate) == false && DateTime.TryParse(qEndDate, out dt) == false)
            {
                throw new ArgumentNullException("参数qEndDate不能转化为日期。");
            }

            return dal.GetBaseInputList(dateID, qShipName, qStartDate, qEndDate, qStartPortID, qEndPortID, pageSize, pageIndex);
        }
        #endregion
    }
}

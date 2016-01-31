/**  版本信息模板在安装目录下，可自行修改。
* IOilType.cs
*
* 功 能： N/A
* 类 名： IOilType
*
* Ver    变更日期             负责人        变更内容
* ───────────────────────────────────
* V0.01  2013/3/10 11:00:00   matthewzjq    初版
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
    public partial class OilTypeFee
    {
        private readonly IOilTypeFee dal = DataAccess.CreateOilTypeFee();

        public OilTypeFee()
        { }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="oilFeeReportID">消耗表主表ID</param>
        /// <returns>列表</returns>
        public IList<OilTypeFeeInfo> GetListAddBlank(string oilFeeReportID)
        {
            IList<OilTypeFeeInfo> list = GetList(oilFeeReportID);
            if (list == null)
            {
                list = new List<OilTypeFeeInfo>(); 
            }
            OilTypeFeeInfo oInfo = new OilTypeFeeInfo();
            list.Add(oInfo);
            return list;
        }



        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="oilFeeReportID">消耗表主表ID</param>
        /// <returns>列表</returns>
        public IList<OilTypeFeeInfo> GetList(string oilFeeReportID)
        {
            if (string.IsNullOrEmpty(oilFeeReportID))
            {
                throw new ArgumentNullException("参数oilFeeReportID不能为空。");
            }
            return dal.GetList(oilFeeReportID);
        }


        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<OilTypeFeeInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public OilTypeFeeInfo GetByID(string ID)
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
        public string Add(OilTypeFeeInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(OilTypeFeeInfo cInfo)
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
            OilTypeFeeInfo cInfo = new OilTypeFeeInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}

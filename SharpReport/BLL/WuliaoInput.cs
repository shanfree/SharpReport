﻿/**  版本信息模板在安装目录下，可自行修改。
* WuliaoInput.cs
*
* 功 能： N/A
* 类 名： WuliaoInput
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
    /// 物料
    /// </summary>
    public partial class WuliaoInput
    {
        private readonly IWuliaoInput dal = DataAccess.CreateWuliaoInput();

        public WuliaoInput()
        { }

        /// <summary>
        /// 按年份，船舶统计报表信息
        /// </summary>
        /// <param name="year">报表的年份，为空显示所有年份</param>
        /// <param name="shipID">报表对应的船舶，为空显示所有的船舶</param>
        public DataSet GetCountStatictis(string year, string shipID)
        {
            int resut = 0;
            if (int.TryParse(year, out resut) == false)
            {
                throw new ArgumentException("年份必须为数字。");
            }
            return dal.GetCountStatictis(year, shipID);
        }

        /// <summary>
        /// 按季度，统计物料报表信息
        /// </summary>
        /// <param name="year">报表的年份</param>
        /// <param name="quarter">报表对应的季度</param>
        public DataSet GetSumStatictis(string year, string quarter)
        {
            int resut = 0;
            if (int.TryParse(year, out resut) == false)
            {
                throw new ArgumentException("年份必须为数字。");
            }
            if (int.TryParse(quarter, out resut) == false)
            {
                throw new ArgumentException("季度必须为数字。");
            }
            return dal.GetSumStatictis(year, quarter);

        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dateID">通过报告期查询，为空则返回所有</param>
        /// <param name="shipID">通过船舶查询，为空则返回所有</param>
        /// <param name="reportType">报表类型，为空则返回所有报表</param>
        /// <returns>列表</returns>
        public DataSet GetList(string dateID, string shipID, string reportType, int pageSize, int pageIndex)
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
            return dal.GetList(dateID, shipID, reportType, pageSize, pageIndex);
        }
        /// <summary>
        /// 按发票的编号统计报表信息
        /// </summary>
        /// <param name="invoiceNo">发票的编号</param>
        public DataSet GetList(string invoiceNo)
        {
            if (string.IsNullOrEmpty(invoiceNo))
            {
                throw new ArgumentException("发票的编号不能为空。");
            }
            return dal.GetList(invoiceNo);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<WuliaoInputInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public WuliaoInputInfo GetByID(string ID)
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
        public string Add(WuliaoInputInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(WuliaoInputInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            // 加载报表之前的状态，如果状态一致，则直接更新，否则保存到文档库
            WuliaoInputInfo preInfo = GetByID(cInfo.ID);
            if (preInfo.ReportTypeID == cInfo.ReportTypeID)
            {
                dal.Update(cInfo);
                return;
            }
            if (preInfo.ReportTypeID == "1")
            {
                // 之前为预估输入存入文档库
                string formID = new FormLibrary<WuliaoInputInfo>().Add(preInfo);
                cInfo.PreestimateFormID = formID;
            }
            if (preInfo.ReportTypeID == "2")
            {
                // 之前为预估输入存入文档库
                string formID = new FormLibrary<WuliaoInputInfo>().Add(preInfo);
                cInfo.AmendFormID = formID;
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
            WuliaoInputInfo cInfo = new WuliaoInputInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


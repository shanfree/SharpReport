/**  版本信息模板在安装目录下，可自行修改。
* CommonFee.cs
*
* 功 能： N/A
* 类 名： CommonFee
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
    public partial class CommonFee
    {
        private readonly ICommonFee dal = DataAccess.CreateCommonFee();
        /// <summary>
        /// 
        /// </summary>
        public CommonFee()
        { }

        /// <summary>
        /// 获取发票的等额人民币价值,汇率按照开票时间计算
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetRMBAmout(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("发票主键不能为空。");
            }
            CommonFeeInfo vInfo = new CommonFee().GetByID(ID);
            ExchangeRateInfo eInfo = new ExchangeRate().GetInfo(vInfo.CurrencyID, vInfo.Year, vInfo.MonthNumOfYear);
            string strRate = (eInfo.CurrencyID == "1") ? "1" : eInfo.Rate;
            decimal amout = Convert.ToDecimal(vInfo.Amount);
            decimal rate = Convert.ToDecimal(strRate);
            //四舍六入五成双
            decimal localAmout = Math.Round(amout / rate, 2);
            return localAmout.ToString();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="year">年份数字</param>
        /// <param name="month">月份数字,为string.empty时显示全年</param>
        /// <param name="departmentID"></param>
        /// <returns>列表</returns>
        public IList<CommonFeeInfo> GetList(string year, string month, string departmentID)
        {
            if (string.IsNullOrEmpty(year))
            {
                throw new ArgumentNullException("年份不能为空。");
            }
            return dal.GetList(year, month, departmentID);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="year">年份数字</param>
        /// <param name="month">月份数字</param>
        /// <param name="departmentID"></param>
        /// <returns>列表</returns>
        public IList<CommonFeeInfo> GetListAddBlank(string year, string month, string departmentID)
        {
            IList<CommonFeeInfo> list = GetList(year, month, departmentID);
            CommonFeeInfo cInfo = new CommonFeeInfo();
            list.Add(cInfo);
            return list;
        }

                /// <summary>
        /// 按年度统计各个部门的费用子项之和
        /// </summary>
        /// <param name="departmentID">部门ID，其中4：安监部；5：人资部</param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetStatistic(string departmentID, int year)
        {
            if (string.IsNullOrEmpty(departmentID) || year < 2000 || year > 2200)
            {
                throw new ArgumentException("部门主键为空或者年份超过有效范围。");
            }
            return dal.GetStatistic(departmentID, year);
        }

        #region 成员方法
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public IList<CommonFeeInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID">实体主键</param>
        /// <returns>实体</returns>
        public CommonFeeInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("参数ID不能为空。");
            }
            return dal.GetByID(ID, false, true);
        }

        /// <summary>
        /// 添加费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        /// <returns>新增实体的主键</returns>
        public string Add(CommonFeeInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// 更新费用类别
        /// </summary>
        /// <param name="cInfo">实体</param>
        public void Update(CommonFeeInfo cInfo)
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
            CommonFeeInfo cInfo = new CommonFeeInfo(ID);
            dal.Delete(cInfo);
        }
        #endregion
    }
}


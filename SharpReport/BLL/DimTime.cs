/********************************************************************************************
 * 文件名称:	DimTime.cs
 * 设计人员:	欧照阳
 * 设计时间:	2007-02-22
 * 功能描述:	时间定义数据层
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian Sirc
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Sirc.SharpReport.IDAL;
using Sirc.SharpReport.DALFactory;
using Sirc.SharpReport.Model;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// 时间定义数据层
    /// </summary>
    public class DimTime
    {
        private static readonly IDimTime dal = DataAccess.CreateDimTime();

        /// <summary>
        /// 得到年份列表
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeYearList()
        {
            return dal.GetDimTimeYearList();
        }

        /// <summary>
        /// 根据年份得到月份列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeMonthList(string year)
        {
            if (String.IsNullOrEmpty(year))
            {
                throw new ArgumentException("参数不能为空。");
            }
            return dal.GetDimTimeMonthList(year);
        }

        /// <summary>
        /// 根据年份得到季度列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeQuarterList(string year)
        {
            if (null == year || string.Empty == year)
            {
                throw new ArgumentException("参数不能为空。");
            }
            return dal.GetDimTimeQuarterList(year);
        }

        /// <summary>
        /// 根据时间ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DimTimeInfo GetDimTimeInfo(string id)
        {
            if (null == id || string.Empty == id)
            {
                throw new ArgumentException("参数不能为空。");
            }
            return dal.GetDimTimeInfo(id);
        }
        /// <summary>
        /// 获取去年的时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isMonth">true-月,false-季</param>
        /// <returns></returns>
        public DimTimeInfo GetLastDimTime(string id, bool isMonth)
        {
            if (null == id || string.Empty == id)
            {
                throw new ArgumentException("参数不能为空。");
            }
            return dal.GetLastDimTime(id, isMonth);
        }
        /// <summary>
        /// 获取前年的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DimTimeInfo GetTheYearBeforeLastDimTimeInfo(string id)
        {
            if (null == id || string.Empty == id)
            {
                throw new ArgumentException("参数不能为空。");
            }
            return dal.GetTheYearBeforeLastDimTimeInfo(id);
        }
        /// <summary>
        /// 得到季度的标识ID
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="quarter">季度的序号</param>
        /// <returns>string</returns>
        public string GetIDByQuarter(string year, string quarter)
        {
            if (null == year || string.Empty == year || null == quarter || string.Empty == quarter)
            {
                throw new ArgumentException("参数不能为空。");
            }
            return dal.GetIDByQuarter(year, quarter);
        }
        /// <summary>
        /// 得到月份的标识ID
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份的序号</param>
        /// <returns>string</returns>
        public string GetIDByMonth(string year, string month)
        {
            if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month))
            {
                throw new ArgumentException("参数不能为空。");
            }
            int result = -1;
            bool isYear = int.TryParse(year, out result);
            bool isMonth = int.TryParse(month, out result);
            if (isYear == false || isMonth == false)
            {
                throw new ArgumentException("不是有效的年份或月份值。");
            }
            return dal.GetIDByMonth(year, month);
        }
    }
}

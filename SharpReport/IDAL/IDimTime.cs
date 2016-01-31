/********************************************************************************************
 * 文件名称:	IDimTime.cs
 * 设计人员:	欧照阳
 * 设计时间:	2008-02-22
 * 功能描述:	时间定义接口层
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
using Sirc.SharpReport.Model;

namespace Sirc.SharpReport.IDAL
{
    /// <summary>
    /// 时间定义
    /// </summary>
    public interface IDimTime
    {
        /// <summary>
        /// 得到年份列表
        /// </summary>
        /// <returns>DataSet</returns>
        DataSet GetDimTimeYearList();

        /// <summary>
        /// 根据年份得到月份列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>DataSet</returns>
        DataSet GetDimTimeMonthList(string year);

        /// <summary>
        /// 根据年份得到季度列表
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>DataSet</returns>
        DataSet GetDimTimeQuarterList(string year);

        /// <summary>
        /// 根据时间ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DimTimeInfo GetDimTimeInfo(string id);

        /// <summary>
        /// 获取去年的时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isMonth">true-月,false-季</param>
        /// <returns></returns>
        DimTimeInfo GetLastDimTime(string id, bool isMonth);

        /// <summary>
        /// 获取前年的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DimTimeInfo GetTheYearBeforeLastDimTimeInfo(string id);

        /// <summary>
        /// 得到季度的标识ID
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns></returns>
        string GetIDByQuarter(string year, string quarter);

        /// <summary>
        /// 得到月份的标识ID
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        string GetIDByMonth(string year, string month);
    }
}

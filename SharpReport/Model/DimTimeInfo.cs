/********************************************************************************************
 * 文件名称:	DimTimeInfo.cs
 * 设计人员:	欧照阳
 * 设计时间:	2008-02-21
 * 功能描述:	时间定义实体层,用于报表的时间统一定义
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

namespace Sirc.SharpReport.Model
{
    /// <summary>
    /// 时间定义实体层
    /// </summary>
    [Serializable]
    public class DimTimeInfo
    {
        private string _ID;

        /// <summary>
        /// 标识ID
        /// </summary>
        public string ID
        {
            get { return _ID; }
        }

        private string monthName;

        /// <summary>
        /// 月名称
        /// </summary>
        public string MonthName
        {
            get { return monthName; }
            set { monthName = value; }
        }

        private int monthNumOfYear;

        /// <summary>
        /// 月份在年份中的排序号
        /// </summary>
        public int MonthNumOfYear
        {
            get { return monthNumOfYear; }
            set { monthNumOfYear = value; }
        }

        private string quarterName;

        /// <summary>
        /// 季度名称
        /// </summary>
        public string QuarterName
        {
            get { return quarterName; }
            set { quarterName = value; }
        }

        private int quarterNumOfYear;

        /// <summary>
        /// 季度在年份中的排序号
        /// </summary>
        public int QuarterNumOfYear
        {
            get { return quarterNumOfYear; }
            set { quarterNumOfYear = value; }
        }

        private int year;

        /// <summary>
        /// 年份
        /// </summary>
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public DimTimeInfo()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ID">主键</param>
        public DimTimeInfo(string ID)
        {
            this._ID = ID;
        }

	
	
	
	
	
	
    }
}

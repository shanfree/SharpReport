/********************************************************************************************
 * 文件名称:	CommonHelper.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	构造分页，获取记录集总数的tsql
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		    人员		    修改备注
 *				    ----------		    ------		-------------------------------------------------
 *                  2010-02-04     hjc           GetResultSetAmoutSQL方法FROM子句设置别名
 ********************************************************************************************/
using System.Collections.Generic;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 构造分页，获取记录集总数的tsql
    /// </summary> 
    public sealed class CommonHelper
    {
        /// <summary>
        /// 获取记录集总页数的SQL
        /// </summary>
        /// <param name="unPagedSQL">未分页的sql</param>
        /// <returns>记录集总页数的SQL</returns>
        public static string GetResultSetAmoutSQL(string unPagedSQL)
        {
            string common = @"SELECT count(1) AS Amout FROM 
                                            (
                                              {0}
                                            ) as Total";
            return string.Format(common, unPagedSQL);
        }

        /// <summary>
        /// 获取分页后的sql，默认按id列递增排序
        /// </summary>
        /// <param name="unPagedSQL">未分页的sql</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public static string GetPagedSQL(string unPagedSQL, int pageSize, int pageIndex)
        {
            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1);
            string common = @"  
                                SELECT * 
                                FROM (
		                                SELECT *,ROW_NUMBER() Over(order by id) as rowNum from        
			                                (   {0}
				                                ) as Total
			                                ) as myTable
                                WHERE rowNum between {1} and {2}
                            ";
            return string.Format(common, unPagedSQL, start, end);
        }

        /// <summary>
        /// 获取分页后的sql
        /// </summary>
        /// <param name="unPagedSQL">未分页的sql</param>
        /// <param name="orderColumnName">按该列排序</param>
        /// <param name="isDesc">是否为降序</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns>string</returns>
        public static string GetPagedSQL(string unPagedSQL, string orderColumnName, bool isDesc, int pageSize, int pageIndex)
        {
            string order = isDesc ? "DESC" : "ASC";

            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1);
            string common = @"  
                                SELECT * 
                                FROM (
		                                SELECT *,ROW_NUMBER() Over(order by {0} {1}) as rowNum from        
			                                (   {2}
				                                ) as Total
			                                ) as myTable
                                WHERE rowNum between {3} and {4}
                            ";
            return string.Format(common, orderColumnName, order, unPagedSQL, start, end);
        }
        /// <summary>
        /// 获取分页后的sql
        /// </summary>
        /// <param name="unPagedSQL">未分页的sql</param>
        /// <param name="orderExpression">排序表达式,字段 升序(降序),字段 升序(降序) 如 ID Desc,Level Asc</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public static string GetPagedSQL(string unPagedSQL, string orderExpression, int pageSize, int pageIndex)
        {
            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1);
            string common = @"  
                                SELECT * 
                                FROM (
		                                SELECT *,ROW_NUMBER() Over(order by {0}) as rowNum from        
			                                (   {1}
				                                ) as Total
			                                ) as myTable
                                WHERE rowNum between {2} and {3}
                            ";
            return string.Format(common, orderExpression, unPagedSQL, start, end);
        }
        /// <summary>
        /// 获取分页后的sql
        /// </summary>
        /// <param name="unPagedSQL">未分页的sql</param>
        /// <param name="orderColumnSet">排序字段和排序规则，键为排序的字段名称，值为布尔型，表示是否降序，如：<example>orderColumnSet.Add("name", true);orderColumnSet.Add("sex", false);</example></param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public static string GetPagedSQL(string unPagedSQL, Dictionary<string, bool> orderColumnSet, int pageSize, int pageIndex)
        {
            string orderClause = string.Empty;
            foreach (KeyValuePair<string, bool> entry in orderColumnSet)
            {
                string format = string.Format("{0} {1},", entry.Key, entry.Value ? "Desc" : "Asc");
                orderClause += format;
            }
            // 去掉末尾的","
            orderClause = orderClause.Remove(orderClause.Length - 1);
            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1);
            string common = @"  
                                SELECT * 
                                FROM (
		                                SELECT *,ROW_NUMBER() Over(order by {0}) as rowNum from        
			                                (   {1}
				                                ) as Total
			                                ) as myTable
                                WHERE rowNum between {2} and {3}
                            ";
            return string.Format(common, orderClause, unPagedSQL, start, end);
        }
    }
}

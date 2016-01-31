using System.Collections.Generic;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 构造分页，获取记录集总数的psql
    /// </summary>
    public sealed class PSQLHelper
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
                                            )";
            return string.Format(common, unPagedSQL);
        }

        /// <summary>
        /// 获取分页后的sql，默认按ID列递增排序
        /// </summary>
        /// <param name="unPagedSQL">未分页的sql，如果该语句未排序，则按ID排序（必须有ID字段）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public static string GetPagedSQL(string unPagedSQL, int pageSize, int pageIndex)
        {
            bool isOrdered = unPagedSQL.ToUpper().Contains("ORDER BY ");
            // 原语句是否排序，如果是，则不添加排序，否则按ID排序（必须有ID字段）
            string orderClause = isOrdered ? string.Empty : "ORDER BY ID ASC";
            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1) + 1;
            string common = @"  
                                SELECT * 
                                FROM
                                (
                                  SELECT A.*,ROWNUM RN
                                  FROM
                                  (
                                    {0} {1}
                                  ) A
                                  WHERE ROWNUM < {2}
                                ) B
                                WHERE B.RN >= {3}
                            ";
            return string.Format(common, unPagedSQL, orderClause, end, start);
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
            string orderClause = string.Format("ORDER BY {0} {1} ",orderColumnName,order);

            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1) + 1;
            string common = @"  
                                SELECT * 
                                FROM
                                (
                                  SELECT A.*,ROWNUM RN
                                  FROM
                                  (
                                    {0} {1}
                                  ) A
                                  WHERE ROWNUM < {2}
                                ) B
                                WHERE B.RN >= {3}
                            ";
            return string.Format(common, unPagedSQL, orderClause, end, start);
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
            string orderClause = orderExpression;

            int start = pageSize * pageIndex + 1;
            int end = pageSize * (pageIndex + 1) + 1;
            string common = @"  
                                SELECT * 
                                FROM
                                (
                                  SELECT A.*,ROWNUM RN
                                  FROM
                                  (
                                    {0} {1}
                                  ) A
                                  WHERE ROWNUM < {2}
                                ) B
                                WHERE B.RN >= {3}
                            ";
            return string.Format(common, unPagedSQL, orderClause, end, start);
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
            int end = pageSize * (pageIndex + 1) + 1;
            string common = @"  
                                SELECT * 
                                FROM
                                (
                                  SELECT A.*,ROWNUM RN
                                  FROM
                                  (
                                    {0} {1}
                                  ) A
                                  WHERE ROWNUM < {2}
                                ) B
                                WHERE B.RN >= {3}
                            ";
            return string.Format(common, unPagedSQL, orderClause, end, start);
        }
    }
}

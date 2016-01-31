using System.Collections.Generic;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// �����ҳ����ȡ��¼��������psql
    /// </summary>
    public sealed class PSQLHelper
    {
        /// <summary>
        /// ��ȡ��¼����ҳ����SQL
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql</param>
        /// <returns>��¼����ҳ����SQL</returns>
        public static string GetResultSetAmoutSQL(string unPagedSQL)
        {
            string common = @"SELECT count(1) AS Amout FROM 
                                            (
                                              {0}
                                            )";
            return string.Format(common, unPagedSQL);
        }

        /// <summary>
        /// ��ȡ��ҳ���sql��Ĭ�ϰ�ID�е�������
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql����������δ������ID���򣨱�����ID�ֶΣ�</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">ҳ����</param>
        /// <returns></returns>
        public static string GetPagedSQL(string unPagedSQL, int pageSize, int pageIndex)
        {
            bool isOrdered = unPagedSQL.ToUpper().Contains("ORDER BY ");
            // ԭ����Ƿ���������ǣ���������򣬷���ID���򣨱�����ID�ֶΣ�
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
        /// ��ȡ��ҳ���sql
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql</param>
        /// <param name="orderColumnName">����������</param>
        /// <param name="isDesc">�Ƿ�Ϊ����</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">ҳ����</param>
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
        /// ��ȡ��ҳ���sql
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql</param>
        /// <param name="orderExpression">������ʽ,�ֶ� ����(����),�ֶ� ����(����) �� ID Desc,Level Asc</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">ҳ����</param>
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
        /// ��ȡ��ҳ���sql
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql</param>
        /// <param name="orderColumnSet">�����ֶκ�������򣬼�Ϊ������ֶ����ƣ�ֵΪ�����ͣ���ʾ�Ƿ����磺<example>orderColumnSet.Add("name", true);orderColumnSet.Add("sex", false);</example></param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">ҳ����</param>
        /// <returns></returns>
        public static string GetPagedSQL(string unPagedSQL, Dictionary<string, bool> orderColumnSet, int pageSize, int pageIndex)
        {
            string orderClause = string.Empty;
            foreach (KeyValuePair<string, bool> entry in orderColumnSet)
            {
                string format = string.Format("{0} {1},", entry.Key, entry.Value ? "Desc" : "Asc");
                orderClause += format;
            }
            // ȥ��ĩβ��","
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

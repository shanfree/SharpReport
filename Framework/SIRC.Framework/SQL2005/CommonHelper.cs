/********************************************************************************************
 * �ļ�����:	CommonHelper.cs
 * �����Ա:	(yanxianghui@gmail.com)
 * ���ʱ��:	2009-03-16
 * ��������:	�����ҳ����ȡ��¼��������tsql
 * ע������:	
 * ��Ȩ����:	Copyright (c) 2009, Fujian SIRC
 * �޸ļ�¼: 	�޸�ʱ��		    ��Ա		    �޸ı�ע
 *				    ----------		    ------		-------------------------------------------------
 *                  2010-02-04     hjc           GetResultSetAmoutSQL����FROM�Ӿ����ñ���
 ********************************************************************************************/
using System.Collections.Generic;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// �����ҳ����ȡ��¼��������tsql
    /// </summary> 
    public sealed class CommonHelper
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
                                            ) as Total";
            return string.Format(common, unPagedSQL);
        }

        /// <summary>
        /// ��ȡ��ҳ���sql��Ĭ�ϰ�id�е�������
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">ҳ����</param>
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
        /// ��ȡ��ҳ���sql
        /// </summary>
        /// <param name="unPagedSQL">δ��ҳ��sql</param>
        /// <param name="orderExpression">������ʽ,�ֶ� ����(����),�ֶ� ����(����) �� ID Desc,Level Asc</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="pageIndex">ҳ����</param>
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

/********************************************************************************************
 * �ļ�����:	PageAmoutHelper.cs
 * �����Ա:	������
 * ���ʱ��:	2007-11-12
 * ��������:	��ȡ��ҳ��
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
 *				----------		------		-------------------------------------------------
 *                              hxj        ׷�ӷ��� public static CustomDataSet GetCutomList(string connectionString, string sql, SqlParameter[] paramList, string orderString, int pageSize, IList<T> list)
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// ��ȡ��ҳ��
    /// </summary>
    public class PageAmoutHelper<T>
    {
        /// <summary>
        /// ��װʵ���б�,��ȡ��ҳ����Ϣ
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="sql">�޷�ҳ��sql,��������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="list">��ҳ��Ľ����</param>
        /// <returns></returns>
        public static CustomList<T> GetCutomList(string connectionString, string sql, int pageSize, IList<T> list)
        {
            // ��ȡ��ҳ��
            int resultSetAmout = -1;
            string resultAmoutSQL = CommonHelper.GetResultSetAmoutSQL(sql);
            object result = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }
            // ��ҳ�����Զ����б�����CustomList��װ
            CustomList<T> cList = new CustomList<T>(resultSetAmout, list);
            return cList;
        }

        /// <summary>
        /// ��װʵ���б�,��ȡ��ҳ����Ϣ
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="sql">�������޷�ҳ��sql</param>
        /// <param name="paramList">����sql����Ĳ�������,���ܴ��з�ҳ����</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="list">��ҳ��Ľ����</param>
        /// <returns></returns>
        public static CustomList<T> GetCutomList(string connectionString, string sql, SqlParameter[] paramList, int pageSize, IList<T> list)
        {
            // ��ȡ��ҳ��
            int resultSetAmout = -1;
            string resultAmoutSQL = CommonHelper.GetResultSetAmoutSQL(sql);
            SqlParameter[] newParamList = new SqlParameter[paramList.Length];
            for (int i = 0; i < paramList.Length; i++)
            {
                newParamList[i] = new SqlParameter(paramList[i].ParameterName, paramList[i].Value);
            }
            object result = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL, newParamList);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }
            // ��ҳ�����Զ����б�����CustomList��װ
            CustomList<T> cList = new CustomList<T>(resultSetAmout, list);
            return cList;

        }

        /// <summary>
        /// ��װʵ���б�,��ȡ��ҳ����Ϣ
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="sql">�޷�ҳ��sql</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="ds">��ҳ��Ľ����</param>
        /// <returns></returns>
        public static CustomDataSet GetCutomDataSet(string connectionString, string sql, int pageSize, DataSet ds)
        {
            // ��ȡ��ҳ��
            int resultSetAmout = -1;
            string resultAmoutSQL = CommonHelper.GetResultSetAmoutSQL(sql);
            object result = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }

            // ��ҳ�����Զ����б�����CustomList��װ
            CustomDataSet cList = new CustomDataSet(resultSetAmout, ds);
            return cList;
        }

        /// <summary>
        /// ��װʵ���б�,��ȡ��ҳ����Ϣ
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="sql">�޷�ҳ��sql</param>
        /// <param name="paramList">����sql����Ĳ�������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="ds">��ҳ��Ľ����</param>
        /// <returns></returns>
        public static CustomDataSet GetCutomDataSet(string connectionString, string sql, SqlParameter[] paramList, int pageSize, DataSet ds)
        {
            // ��ȡ��ҳ��
            int resultSetAmout = -1;
            string resultAmoutSQL = CommonHelper.GetResultSetAmoutSQL(sql);
            SqlParameter[] newParamList = new SqlParameter[paramList.Length];
            for (int i = 0; i < paramList.Length; i++)
            {
                newParamList[i] = new SqlParameter(paramList[i].ParameterName, paramList[i].Value);
            }
            object result = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL, newParamList);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }

            // ��ҳ�����Զ����б�����CustomList��װ
            CustomDataSet cList = new CustomDataSet(resultSetAmout, ds);
            return cList;
        }
    }
}
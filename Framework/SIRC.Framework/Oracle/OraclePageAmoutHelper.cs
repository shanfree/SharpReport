/********************************************************************************************
 * 文件名称:	PageAmoutHelper.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-11-12
 * 功能描述:	获取总页数
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *                              hxj        追加方法 public static CustomDataSet GetCutomList(string connectionString, string sql, OracleParameter[] paramList, string orderString, int pageSize, IList<T> list)
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 获取总页数
    /// </summary>
    public class OraclePageAmoutHelper<T>
    {
        /// <summary>
        /// 封装实体列表,获取总页数信息
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="sql">无分页的sql,不带参数</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="list">分页后的结果集</param>
        /// <returns></returns>
        public static CustomList<T> GetCutomList(string connectionString, string sql, int pageSize, IList<T> list)
        {
            // 获取总页数
            int resultSetAmout = -1;
            string resultAmoutSQL = PSQLHelper.GetResultSetAmoutSQL(sql);
            object result = OracleHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }
            // 总页数以自定义列表类型CustomList封装
            CustomList<T> cList = new CustomList<T>(resultSetAmout, list);
            return cList;
        }

        /// <summary>
        /// 封装实体列表,获取总页数信息
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="sql">带参数无分页的sql</param>
        /// <param name="paramList">运行sql所需的参数集合,不能带有分页参数</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="list">分页后的结果集</param>
        /// <returns></returns>
        public static CustomList<T> GetCutomList(string connectionString, string sql, OracleParameter[] paramList, int pageSize, IList<T> list)
        {
            // 获取总页数
            int resultSetAmout = -1;
            string resultAmoutSQL = PSQLHelper.GetResultSetAmoutSQL(sql);
            OracleParameter[] newParamList = new OracleParameter[paramList.Length];
            for (int i = 0; i < paramList.Length; i++)
            {
                newParamList[i] = new OracleParameter(paramList[i].ParameterName, paramList[i].Value);
            }
            object result = OracleHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL, newParamList);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }
            // 总页数以自定义列表类型CustomList封装
            CustomList<T> cList = new CustomList<T>(resultSetAmout, list);
            return cList;
        }

        /// <summary>
        /// 封装实体列表,获取总页数信息
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="sql">无分页的sql</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="ds">分页后的结果集</param>
        /// <returns></returns>
        public static CustomDataSet GetCutomDataSet(string connectionString, string sql, int pageSize, DataSet ds)
        {
            // 获取总页数
            int resultSetAmout = -1;
            string resultAmoutSQL = PSQLHelper.GetResultSetAmoutSQL(sql);
            object result = OracleHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }

            // 总页数以自定义列表类型CustomList封装
            CustomDataSet cList = new CustomDataSet(resultSetAmout, ds);
            return cList;
        }

        /// <summary>
        /// 封装实体列表,获取总页数信息
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="sql">无分页的sql</param>
        /// <param name="paramList">运行sql所需的参数集合</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="ds">分页后的结果集</param>
        /// <returns></returns>
        public static CustomDataSet GetCutomDataSet(string connectionString, string sql, OracleParameter[] paramList, int pageSize, DataSet ds)
        {
            // 获取总页数
            int resultSetAmout = -1;
            string resultAmoutSQL = PSQLHelper.GetResultSetAmoutSQL(sql);
            OracleParameter[] newParamList = new OracleParameter[paramList.Length];
            for (int i = 0; i < paramList.Length; i++)
            {
                newParamList[i] = new OracleParameter(paramList[i].ParameterName, paramList[i].Value);
            }
            object result = OracleHelper.ExecuteScalar(connectionString, CommandType.Text, resultAmoutSQL, newParamList);
            if (DBNull.Value == result)
            {
                resultSetAmout = 0;
            }
            else
            {
                resultSetAmout = int.Parse(result.ToString());
            }

            // 总页数以自定义列表类型CustomList封装
            CustomDataSet cList = new CustomDataSet(resultSetAmout, ds);
            return cList;
        }
    }
}

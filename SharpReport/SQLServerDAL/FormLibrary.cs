/********************************************************************************************
 * 文件名称:	FormLibrary.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-11-04
 * 功能描述:	表单库文档保存的数据库访问类
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 ********************************************************************************************/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Sirc.SharpReport.IDAL;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace Sirc.SharpReport.SQLServerDAL
{
    public class FormLibrary<T> : IFormLibrary<T>
    {
        #region sql
        private const string SQL_SELECT = @"SELECT * FROM FormLibrary WHERE ID = @ID";
        protected const string SQL_INSERT = @"
                                                                    INSERT INTO [FormLibrary]
                                                                               ([CONTENT])
                                                                        OUTPUT INSERTED.ID  
                                                                         VALUES
                                                                               (@CONTENT)
                                                                    ";
        //批量添加的代码
        protected const string SQL_INSERT_BAT_TEST = @"
                                                                    INSERT INTO [FormLibrary]
                                                                               ([CONTENT],DocName)
                                                                        OUTPUT INSERTED.ID  
                                                                         VALUES
                                                                               (@CONTENT,@DocName)
                                                                    ";
        protected const string SQL_UPDATE = @"UPDATE FormLibrary SET CONTENT = @CONTENT WHERE ID = @ID";
        private const string SQL_DELETE = @"DELETE FROM FormLibrary WHERE ID = @ID";
        #endregion

        /// <summary>
        /// 连接串
        /// </summary>
        protected virtual string ConnnectionString
        {
            get
            {
                return DBConnection.ConnectionString;
            }
        }

        /// <summary>
        /// 根据主键获取申请内容
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <returns>申请书实体</returns>
        public string  GetContentByID(string id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            string sql = "SELECT Content FROM FormLibrary WHERE ID = @ID";
            object result = SqlHelper.ExecuteScalar(this.ConnnectionString, CommandType.Text, sql, param);
            if (result != null)
            {
                string xml = Convert.ToString(result);
                return xml;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据主键获取申请书实体
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <returns>申请书实体</returns>
        public T GetByID(string id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            SqlDataReader dr = SqlHelper.ExecuteReader(this.ConnnectionString, CommandType.Text, SQL_SELECT, param);
            IList<T> list = getList(dr);
            if (null == list || list.Count == 0)
            {
                return default(T);
            }
            return list[0];
        }
        /// <summary>
        /// 添加申请书信息
        /// </summary>
        /// <param name="t">更新的内容</param>
        public virtual string Add(T t)
        {
            string xml = SerializeHandler<T>.SerializeToXmlString(t);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CONTENT", xml);
            string key = SqlHelper.ExecuteScalar(this.ConnnectionString, CommandType.Text, SQL_INSERT, param).ToString();
            return key;
        }

        /// <summary>
        /// 测试的代码，批量导入旧文档库数据时使用的方法，业务系统不得使用该接口
        /// </summary>
        /// <param name="docName">文档名称</param>
        /// <param name="xmlContent">文档内容</param>
        /// <returns>插入数据主键</returns>
        private string Add(string docName, string xmlContent)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CONTENT", xmlContent);
            param[1] = new SqlParameter("@DocName", docName);
            string key = SqlHelper.ExecuteScalar(this.ConnnectionString, CommandType.Text, SQL_INSERT_BAT_TEST, param).ToString();
            return key;
        }


        /// <summary>
        /// 更新申请书信息
        /// </summary>
        /// <param name="id">申请书主键</param>
        /// <param name="t">更新的内容</param>
        public virtual void Update(string id, T t)
        {
            string xml = SerializeHandler<T>.SerializeToXmlString(t);
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", id);
            param[1] = new SqlParameter("@CONTENT", xml);
            SqlHelper.ExecuteNonQuery(this.ConnnectionString, CommandType.Text, SQL_UPDATE, param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            SqlHelper.ExecuteNonQuery(this.ConnnectionString, CommandType.Text, SQL_DELETE, param);
        }

        #region 私有函数
        /// <summary>
        /// 从数据库获取实体列表
        /// </summary>
        /// <param name="reader">数据库记录集游标</param>
        /// <returns>审批事项实体列表<seealso cref="ApplicationRecordInfo"/></returns>
        private IList<T> getList(SqlDataReader reader)
        {
            IList<T> list = new List<T>();
            try
            {
                while (reader.Read())
                {
                    T t = GetInstance(reader) ;
                    list.Add(t);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
            return list;
        }
        /// <summary>
        /// 从数据库中获取该实例
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected virtual T GetInstance(SqlDataReader reader)
        {
            string xml = Convert.ToString(reader["CONTENT"]);
            T t = SerializeHandler<T>.InitByString(xml);
            return t;
        }
        #endregion

    }
}

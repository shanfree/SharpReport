/********************************************************************************************
 * �ļ�����:	FormLibrary.cs
 * �����Ա:	������
 * ���ʱ��:	2007-11-04
 * ��������:	�����ĵ���������ݿ������
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
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
        //������ӵĴ���
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
        /// ���Ӵ�
        /// </summary>
        protected virtual string ConnnectionString
        {
            get
            {
                return DBConnection.ConnectionString;
            }
        }

        /// <summary>
        /// ����������ȡ��������
        /// </summary>
        /// <param name="id">����������</param>
        /// <returns>������ʵ��</returns>
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
        /// ����������ȡ������ʵ��
        /// </summary>
        /// <param name="id">����������</param>
        /// <returns>������ʵ��</returns>
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
        /// �����������Ϣ
        /// </summary>
        /// <param name="t">���µ�����</param>
        public virtual string Add(T t)
        {
            string xml = SerializeHandler<T>.SerializeToXmlString(t);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CONTENT", xml);
            string key = SqlHelper.ExecuteScalar(this.ConnnectionString, CommandType.Text, SQL_INSERT, param).ToString();
            return key;
        }

        /// <summary>
        /// ���ԵĴ��룬����������ĵ�������ʱʹ�õķ�����ҵ��ϵͳ����ʹ�øýӿ�
        /// </summary>
        /// <param name="docName">�ĵ�����</param>
        /// <param name="xmlContent">�ĵ�����</param>
        /// <returns>������������</returns>
        private string Add(string docName, string xmlContent)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CONTENT", xmlContent);
            param[1] = new SqlParameter("@DocName", docName);
            string key = SqlHelper.ExecuteScalar(this.ConnnectionString, CommandType.Text, SQL_INSERT_BAT_TEST, param).ToString();
            return key;
        }


        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="id">����������</param>
        /// <param name="t">���µ�����</param>
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

        #region ˽�к���
        /// <summary>
        /// �����ݿ��ȡʵ���б�
        /// </summary>
        /// <param name="reader">���ݿ��¼���α�</param>
        /// <returns>��������ʵ���б�<seealso cref="ApplicationRecordInfo"/></returns>
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
        /// �����ݿ��л�ȡ��ʵ��
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

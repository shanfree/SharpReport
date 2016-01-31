/********************************************************************************************
 * 文件名称:	DBPersistenceBase.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	将实体持久化到数据库的基本操作
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 将实体持久化到数据库的基本操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBPersistenceBase<T> : IDBPersistenceBase<T> where T : new()
    {
        /// <summary>
        /// 数据库连接串，必须在派生类中重写
        /// </summary>
        protected virtual string ConnectionString
        {
            get
            {
                throw new NotSupportedException("连接串必须在派生类中重写。");
            }
        }

        /// <summary>
        /// 根据主键获取记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns>实体</returns>
        public virtual T GetByID(string id, bool isLazyLaod, bool isExtend)
        {
            // 表名
            String className = GetViewName(typeof(T));
            // 选取单条记录的sql
            string SQL_SELECT_ID = string.Format(@"SELECT top 1 *
                                                                                  FROM dbo.[{0}]
                                                                                  WHERE ID = @ID", className);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", id);
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, SQL_SELECT_ID, param);
                IList<T> list = GetListFromReader(reader, isLazyLaod, isExtend);
                if (list.Count == 0)
                {
                    return default(T);
                }
                return list[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        /// <summary>
        /// 根据主键获取记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        public virtual T GetByID(string id)
        {
            return GetByID(id, false, false);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns>列表</returns>
        public virtual IList<T> GetList(bool isLazyLaod, bool isExtend)
        {
            // 表名
            String className = GetViewName(typeof(T));
            // 选取单条记录的sql
            string SQL_SELECT_LIST = string.Format(@"SELECT  * FROM dbo.[{0}]", className);
            SqlDataReader reader = null;
            try
            {
                reader = SqlHelper.ExecuteReader(this.ConnectionString, CommandType.Text, SQL_SELECT_LIST);
                IList<T> list = GetListFromReader(reader, isLazyLaod, isExtend);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        public virtual IList<T> GetList()
        {
            return GetList(false, false);
        }

        #region GetListFromReader
        /// <summary>
        /// 从数据库获取实体列表
        /// </summary>
        /// <param name="reader">数据库记录集游标</param>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns>实体列表</returns>
        protected IList<T> GetListFromReader(SqlDataReader reader, bool isLazyLaod, bool isExtend)
        {
            IList<T> ilist = new List<T>();
            try
            {
                Type type = typeof(T);
                // 所有属性
                PropertyInfo[] proList = type.GetProperties();
                while (reader.Read())
                {
                    T t = new T();
                    foreach (PropertyInfo item in proList)
                    {
                        object[] attr = item.GetCustomAttributes(typeof(PersistenceAttribute), true);
                        // 需要持久化的字段才写入数据库
                        if (attr != null && attr.Length > 0)
                        {
                            PersistenceAttribute pAttr = attr[0] as PersistenceAttribute;
                            // 该字段被标记为延迟加载
                            if (pAttr.IsLazyLoad)
                            {
                                continue;
                            }
                            string colName = pAttr.ColumnName;
                            // 映射字段为空或 客户端不要求加载扩展字段则不读取
                            if (string.IsNullOrEmpty(colName) || (pAttr.IsExtend == true && isExtend == false))
                            {
                                continue;
                            }
                            if (reader[colName] == DBNull.Value)
                            {
                                // 空值不赋值
                                continue;
                            }
                            string strValue = Convert.ToString(reader[colName]);
                            object proValue = Convert.ChangeType(strValue, item.PropertyType);
                            item.SetValue(t, proValue, null);
                        }//END IF
                    }// END FOR
                    // 写入扩展属性
                    if (isLazyLaod)
                    {
                        t = WriteLazyLoadProperty(reader, t);
                    }
                    ilist.Add(t);
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
            if (null == ilist || ilist.Count == 0)
            {
                return new List<T>();
            }
            return ilist;
        }

        /// <summary>
        /// 默认不获取延迟加载字段，扩展字段，从数据库获取实体
        /// </summary>
        /// <param name="reader">数据库记录集游标</param>
        /// <returns>实体列表</returns>
        protected IList<T> GetListFromReader(SqlDataReader reader)
        {
            return GetListFromReader(reader, false, false);
        }

        /// <summary>
        /// 写入扩展属性
        /// </summary>
        /// <param name="reader">数据库游标</param>
        /// <param name="t">实体对象</param>
        /// <returns></returns>
        protected virtual T WriteLazyLoadProperty(SqlDataReader reader, T t)
        {
            return t;
        }
        #endregion

        #region 私有函数
        private PersistenceAttribute GetPersistenceAttribute(MemberInfo mInfo)
        {
            string dbName = string.Empty;
            object[] attr = mInfo.GetCustomAttributes(typeof(PersistenceAttribute), true);
            // 需要持久化的字段才写入数据库
            if (attr != null && attr.Length > 0)
            {
                PersistenceAttribute pAttr = attr[0] as PersistenceAttribute;
                return pAttr;
            }
            return new PersistenceAttribute();
        }
        /// <summary>
        /// 获取表名，删除，更新用
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <returns>对应数据库表名</returns>
        private string GetTableName(Type type)
        {
            // 表名
            String className = GetPersistenceAttribute(type).ColumnName;
            if (string.IsNullOrEmpty(className))
            {
                throw new ArgumentNullException("实例对应的表不能为空。");
            }
            //// 针对User等关键字为表名须添加[User]
            //className = "[" + className + "]";
            return className;
        }
        /// <summary>
        /// 获取视图名，读取用
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetViewName(Type type)
        {
            // 视图
            String extendName = GetPersistenceAttribute(type).ExtendName;
            if (string.IsNullOrEmpty(extendName))
            {
                // 不定义视图则获取表
                return GetTableName(type);
            }
            return extendName;
        }
        #endregion

        /// <summary>
        /// 将实体持久化到数据库
        /// </summary>
        /// <param name="t"></param>
        /// <returns>数据库记录主键</returns>
        public virtual string Add(T t)
        {
            // 数据库字段
            String fields = string.Empty;
            // 实体属性值
            String values = string.Empty;
            // 表名
            String className = GetTableName(typeof(T));
            // 所有属性
            Type type = t.GetType();
            PropertyInfo[] proList = type.GetProperties();
            // 需要持久化到数据库的字段个数
            int dbColumnCount = 0;
            IList<SqlParameter> paramList = new List<SqlParameter>();
            foreach (PropertyInfo item in proList)
            {
                PersistenceAttribute pAttr = GetPersistenceAttribute(item);
                // 需要持久化的字段，非扩展字段才写入数据库
                if (string.IsNullOrEmpty(pAttr.ColumnName) == false && pAttr.IsExtend == false && pAttr.IsLazyLoad == false)
                {
                    if (pAttr.IsPrimaryKey == true)
                        continue;
                    string colName = pAttr.ColumnName;
                    SqlParameter param = new SqlParameter("@" + colName, null);
                    object oValue = item.GetValue(t, null);
                    //string colValue = (oValue == null) ? null : oValue.ToString();
                    if (item.PropertyType == typeof(DateTime))
                    {
                        DateTime tValue = Convert.ToDateTime(oValue);
                        string colValue = string.Empty;
                        if (tValue == DateTime.MaxValue || tValue == DateTime.MinValue)
                        {
                            colValue = null;
                        }
                        param.SqlDbType = SqlDbType.DateTime;
                        param.Value = tValue;
                    }
                    else if (item.PropertyType == typeof(byte[]))
                    {
                        byte[] tValue = oValue as byte[];
                        param.SqlDbType = SqlDbType.Image;
                        param.Value = tValue;
                    }
                    else
                    {
                        string tValue = (oValue == null) ? null : oValue.ToString();
                        param.Value = tValue;
                    }
                    // 参数值
                    // 构造带参数的sql
                    paramList.Add(param);
                    fields += colName + ",";
                    values += "@" + colName + ",";
                    dbColumnCount++;
                }
            }
            // 构造带参数sql
            fields = fields.Substring(0, fields.Length - 1);
            values = values.Substring(0, values.Length - 1);
            String sql = "INSERT INTO [{0}] ( {1} ) VALUES ( {2} ) SELECT @@IDENTITY";
            sql = String.Format(sql, className, fields, values);
            // 参数数组
            SqlParameter[] paramArray = new SqlParameter[paramList.Count];
            paramList.CopyTo(paramArray, 0);
            return Convert.ToString(SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, paramArray));
        }
        /// <summary>
        /// 根据实体主键的值，在数据库中删除对饮记录
        /// </summary>
        /// <param name="t"></param>
        public virtual void Delete(T t)
        {
            String columnName = string.Empty;
            String id = string.Empty;
            Type type = t.GetType();
            // 表名
            String className = GetTableName(typeof(T));

            IList<SqlParameter> paramList = new List<SqlParameter>();
            PropertyInfo[] proList = type.GetProperties();
            foreach (PropertyInfo item in proList)
            {
                PersistenceAttribute pAttr = GetPersistenceAttribute(item);
                // 需要持久化的字段才写入数据库
                if (string.IsNullOrEmpty(pAttr.ColumnName) == false)
                {
                    if (pAttr.IsPrimaryKey == true)
                    {
                        id = item.GetValue(t, null).ToString();
                        columnName = pAttr.ColumnName;
                        SqlParameter param = new SqlParameter("@" + columnName, id);
                        paramList.Add(param);
                        break;
                    }
                }
            }
            String sql = "DELETE [{0}] WHERE {1} = @{2}";
            sql = String.Format(sql, className, columnName, columnName);
            // 参数数组
            SqlParameter[] paramArray = new SqlParameter[paramList.Count];
            paramList.CopyTo(paramArray, 0);
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, paramArray);
        }
        /// <summary>
        /// 将实体的所有主键，更新到数据库中的所有字段
        /// </summary>
        /// <param name="t"></param>
        public virtual void Update(T t)
        {
            String pkColumnName = string.Empty;
            String id = string.Empty;
            String content = string.Empty;
            string where = string.Empty;
            // 表名
            String className = GetTableName(typeof(T));

            IList<SqlParameter> paramList = new List<SqlParameter>();
            Type type = t.GetType();
            PropertyInfo[] proList = type.GetProperties();
            foreach (PropertyInfo item in proList)
            {
                PersistenceAttribute pAttr = GetPersistenceAttribute(item);
                // 需要持久化的字段才写入数据库
                if (string.IsNullOrEmpty(pAttr.ColumnName) == false && pAttr.IsExtend == false)
                {
                    string colName = pAttr.ColumnName;
                    object oValue = item.GetValue(t, null);
                    // 参数值
                    SqlParameter param = new SqlParameter("@" + colName, oValue);
                    paramList.Add(param);
                    if (pAttr.IsPrimaryKey == true)
                    {
                        where += string.Format(" {0} = @{0} AND", colName);
                    }
                    else
                    {
                        content += string.Format("{0} = @{0} ,", colName);
                    }
                    if (item.PropertyType == typeof(DateTime))
                    {
                        DateTime tValue = Convert.ToDateTime(item.GetValue(t, null));
                        if (tValue == DateTime.MaxValue || tValue == DateTime.MinValue)
                        {
                            param.Value = null;
                        }
                        else
                        {
                            param.Value = tValue;
                        }
                    }
                    else if (item.PropertyType == typeof(byte[]))
                    {
                        byte[] tValue = item.GetValue(t, null) as byte[];
                        param.Value = tValue;
                        param.SqlDbType = SqlDbType.Image;
                    }
                    else
                    {
                        object colValue = (null == oValue) ? null : oValue.ToString();
                        param.Value = colValue;
                    }
                }
            }
            where = where.Remove(where.Length - 4);
            content = content.Substring(0, content.Length - 1);
            String sql = "UPDATE [{0}] SET {1} WHERE {2}";
            sql = String.Format(sql, className, content, where);
            // 参数数组
            SqlParameter[] paramArray = new SqlParameter[paramList.Count];
            paramList.CopyTo(paramArray, 0);
            SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, paramArray);
        }

        #region 实体比较
        /// <summary>
        /// 比较类型为T的两个实例的差异，以字符串形式返回
        /// </summary>
        /// <param name="info1">实例1，通常为变更后的实例</param>
        /// <param name="info2">实例2，通常为变更前的实例</param>
        /// <returns>变更内容，格式为【变更字段1说明】由【旧值】变更为【新值】；【变更字段2说明】由【旧值】变更为【新值】.......</returns>
        public virtual string Compare(T info1, T info2)
        {
            string returnMessage = string.Empty;
            Type type = typeof(T);
            PropertyInfo[] proList = type.GetProperties();
            foreach (PropertyInfo item in proList)
            {
                PersistenceAttribute pAttr = GetPersistenceAttribute(item);
                // 需要持久化的字段才存在变更，如果是外键字段则特别处理
                if (string.IsNullOrEmpty(pAttr.ColumnName) == false && pAttr.IsExtend == false
                    && String.IsNullOrEmpty(pAttr.Description) == false)
                {
                    if (pAttr.IsPrimaryKey == true)
                    {
                        //不支持主键变更
                        continue;
                    }
                    string colName = pAttr.ColumnName;
                    string colValueNew = Convert.ToString(item.GetValue(info1, null));
                    string colValueOld = Convert.ToString(item.GetValue(info2, null));
                    string colRemark = pAttr.Description;
                    if (pAttr.IsForeignKey == true)
                    {
                        if (colValueNew != colValueOld)
                        {
                            returnMessage += GetForeignChangeContent(colRemark, colValueOld, colValueNew);
                            continue;
                        }
                    }
                    if (colValueNew != colValueOld)
                    {
                        string format = string.Format("{0}由'{1}'变更为'{2}'； ", colRemark, colValueOld, colValueNew);
                        returnMessage += format;
                    }
                }
            }
            return returnMessage;
        }
        /// <summary>
        /// 获取外键字段的信息变更
        /// </summary>
        /// <param name="remark">数据库字段说明</param>
        /// <param name="valueOld">字段旧值</param>
        /// <param name="valueNew">字段新值</param>
        /// <returns></returns>
        protected virtual string GetForeignChangeContent(string remark, string valueOld, string valueNew)
        {
            string format = string.Format("{0}由'{1}'变更为'{2}'； ", remark, valueOld, valueNew);
            return format;
        }
        #endregion
    }
}

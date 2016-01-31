/********************************************************************************************
 * 文件名称:	IDBPersistenceBase.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-12
 * 功能描述:	持久化业务实体接口
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 持久化业务实体接口
    /// </summary>
    /// <typeparam name="T">业务实体类型，必须是引用类型,且具有默认的构造函数</typeparam>
    public interface IDBPersistenceBase<T>
     where T : new()
    {

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>列表</returns>
        IList<T> GetList();

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns>列表</returns>
        IList<T> GetList(bool isLazyLaod, bool isExtend);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetByID(string id);
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <param name="isLazyLaod">客户端是否忽略延迟加载字段</param>
        /// <param name="isExtend">是否加载扩展字段</param>
        /// <returns></returns>
        T GetByID(string id, bool isLazyLaod, bool isExtend);
        /// <summary>
        /// 添加到数据库
        /// </summary>
        /// <param name="t">业务实体</param>
        /// <returns>数据库主键</returns>
        string Add(T t);
        /// <summary>
        /// 数据库中删除该实体
        /// </summary>
        /// <param name="t">业务实体</param>
        void Delete(T t);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t">新的业务实体，通过id属性关联</param>
        void Update(T t);
    }
}

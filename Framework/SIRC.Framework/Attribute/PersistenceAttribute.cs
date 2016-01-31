/********************************************************************************************
 * 文件名称:	PersistenceAttribute.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	标明实体属性所在的数据库字段
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 标明实体属性所在的数据库字段
    /// </summary>
    public class PersistenceAttribute : Attribute
    {
        /// <summary>
        /// 是否为主键
        /// </summary>
        public Boolean IsPrimaryKey = false;
        /// <summary>
        /// 数据库字段名
        /// </summary>
        public String ColumnName = string.Empty;
        /// <summary>
        /// 类加载时对应的视图名称
        /// </summary>
        public String ExtendName = string.Empty;
        /// <summary>
        /// 字段是否为扩展字段（更新，添加时不用）
        /// </summary>
        public bool IsExtend = false;
        /// <summary>
        /// 是否延迟加载（用户大数据量字段，列表读取时不进行加载）
        /// </summary>
        public bool IsLazyLoad = false;
        /// <summary>
        /// 数据库字段说明
        /// </summary>
        public String Description = string.Empty;
        /// <summary>
        /// 是否为外键
        /// </summary>
        public Boolean IsForeignKey = false;
    }
}

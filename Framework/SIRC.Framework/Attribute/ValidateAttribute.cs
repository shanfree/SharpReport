/********************************************************************************************
 * 文件名称:	ValidateAttribute.cs
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
    public class ValidateAttribute : Attribute
    {
        /// <summary>
        /// 验证的类型
        /// </summary>
        public ValidateType Type = ValidateType.IsNullOrEmpty;
        /// <summary>
        /// 是否可以为NULL或String.Empty
        /// </summary>
        public bool IsNullOrEmpty = true;
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Regex = string.Empty;
        /// <summary>
        /// 用户验证逻辑的DLL名称，不含后缀名
        /// </summary>
        public string AssemblyName = string.Empty;
        /// <summary>
        ///用户验证逻辑的类全名
        /// </summary>
        public string ClassFullName = string.Empty;
    }
    /// <summary>
    /// 验证的类型
    /// </summary>
    public enum ValidateType
    { 
        /// <summary>
        /// 是否可以为NULL或String.Empty
        /// </summary>
        IsNullOrEmpty = 1,
        /// <summary>
        /// 数值值域
        /// </summary>
        NumericRange,
        /// <summary>
        /// 正则
        /// </summary>
        Regex,
        /// <summary>
        /// 用户逻辑
        /// </summary>
        Customer
    }
}

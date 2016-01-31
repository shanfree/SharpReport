/********************************************************************************************
 * 文件名称:	CustomList.cs
 * 设计人员:	严向辉
 * 设计时间:	2007-09-12
 * 功能描述:	自定义实体列表，加入总页数属性
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *              2008-3-3        黄景灿      把类设置为可序列化[Serializable]
 ********************************************************************************************/
using System;
using System.Collections.Generic;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// CustomList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class CustomList<T> : List<T>
    {
        private int _totalAmout;
        /// <summary>
        /// 记录集的总数
        /// </summary>
        public int TotalAmout
        {
            get { return _totalAmout; }
            set { _totalAmout = value; }
        }

        /// <summary>
        /// CustomList
        /// </summary>
        /// <param name="resultSetAmout">resultSetAmout</param>
        /// <param name="list">IList</param>
        public CustomList(int resultSetAmout, IList<T> list)
        {
            this.AddRange(list);
            this.TotalAmout = resultSetAmout;
        }
        /// <summary>
        /// CustomList
        /// </summary>
        public CustomList()
        {
            this.AddRange(new List<T>());
            this.TotalAmout = 0;
        }
    }
}

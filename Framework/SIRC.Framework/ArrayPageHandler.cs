/********************************************************************************************
 * 文件名称:	ArrayPageHandler.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	数组操作类
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
    /// 数组操作类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ArrayPageHandler<T>
    {
        /// <summary>
        /// 数组分页
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <returns>T</returns>
        public static T[] GetPagedArrayByIndex(T[] array, int pageSize, int pageIndex)
        {
            int startIndex = pageSize * pageIndex;
            int pageTotel = startIndex + pageSize - 1;
            //如果大于总数则减小当前页大小
            if (pageTotel > array.Length - 1)
            {
                pageTotel = array.Length - 1;
                pageSize = array.Length - startIndex;
            }

            T[] pagedArray = new T[pageSize];
            for (int i = startIndex, j = 0; i <= pageTotel; i++, j++)
            {
                pagedArray.SetValue(array.GetValue(i), j);
            }
            return pagedArray;
        }

    }
}

/********************************************************************************************
 * 文件名称:	SingleGeneric.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-28
 * 功能描述:	单件泛型
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
using System.Text;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 单件泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleGeneric<T> where T : new() //<T>泛型的参数，晚绑定
    {
        private static T _instance = default(T);
        private static readonly object lockHelper = new object();
        private SingleGeneric()
        {
        }
        /// <summary>
        /// 创建单件
        /// </summary>
        /// <returns></returns>
        public static T CreateInstance()
        {
            //这样lock以及lock块内的代码只会在第一次调用CreateInstance方法的时候执行，
            //第一次调用该方法后_instance就不再为null了,if块内的代码就无须执行了
            if(_instance == null)
            {
                lock(lockHelper)
                {
                    if(_instance == null)
                        _instance = new T(); 
                }
            }
            return _instance;
        }

        private SingleGeneric(T t)
        {
            _instance = t;
        }
    }
}

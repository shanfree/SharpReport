/********************************************************************************************
 * 文件名称:	IIterator.cs
 * 设计人员:	(yanxianghui@gmail.com)
 * 设计时间:	2009-03-16
 * 功能描述:	迭代器接口
 * 注意事项:	
 * 版权所有:	Copyright (c) 2009, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 迭代器接口（IIterator）
    /// </summary>
    public interface IIterator<T>
    {
        /// <summary>
        /// 第一个对象
        /// </summary>
        /// <returns></returns>
        T First();

        /// <summary>
        /// 下一个对象
        /// </summary>
        /// <returns></returns>
        T Next();

        /// <summary>
        /// 当前对象
        /// </summary>
        T Current { get; }

        /// <summary>
        /// 是否迭代完毕
        /// </summary>
        bool IsDone { get; }
    }

    /// <summary>
    /// 迭代器（Iterator）
    /// </summary>
    public class Iterator<T> : IIterator<T>
    {
        private IList<T> _list;
        private int _current = 0;
        private int _step = 1;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list"></param>
        public Iterator(IList<T> list)
        {
            //FileStream fs = new FileStream("",FileMode.Open);
            //StreamReader sr = new StreamReader(fs);
            //sr.r
            this._list = list;
        }

        /// <summary>
        /// 第一个对象
        /// </summary>
        /// <returns></returns>
        public T First()
        {
            _current = 0;
            return _list[_current];
        }

        /// <summary>
        /// 下一个对象
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            _current += _step;

            if (!IsDone)
            {
                return _list[_current];
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 当前对象
        /// </summary>
        public T Current
        {
            get { return _list[_current]; }
        }

        /// <summary>
        /// 是否迭代完毕
        /// </summary>
        public bool IsDone
        {
            get { return _current >= _list.Count ? true : false; }
        }

        /// <summary>
        /// 步长
        /// </summary>
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
    }
}

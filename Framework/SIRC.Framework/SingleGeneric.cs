/********************************************************************************************
 * �ļ�����:	SingleGeneric.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-28
 * ��������:	��������
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// ��������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleGeneric<T> where T : new() //<T>���͵Ĳ��������
    {
        private static T _instance = default(T);
        private static readonly object lockHelper = new object();
        private SingleGeneric()
        {
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public static T CreateInstance()
        {
            //����lock�Լ�lock���ڵĴ���ֻ���ڵ�һ�ε���CreateInstance������ʱ��ִ�У�
            //��һ�ε��ø÷�����_instance�Ͳ���Ϊnull��,if���ڵĴ��������ִ����
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

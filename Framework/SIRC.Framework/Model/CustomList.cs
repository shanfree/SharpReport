/********************************************************************************************
 * �ļ�����:	CustomList.cs
 * �����Ա:	�����
 * ���ʱ��:	2007-09-12
 * ��������:	�Զ���ʵ���б�������ҳ������
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
 *				----------		------		-------------------------------------------------
 *              2008-3-3        �ƾ���      ��������Ϊ�����л�[Serializable]
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
        /// ��¼��������
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

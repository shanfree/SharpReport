/********************************************************************************************
 * �ļ�����:	FormLibrary.cs
 * �����Ա:	������
 * ���ʱ��:	2007-11-04
 * ��������:	�����ĵ���������ݿ������
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
 *				----------		------		-------------------------------------------------
 ********************************************************************************************/
using System;
using System.Data;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace Sirc.SharpReport.IDAL
{
    public interface IFormLibrary<T>
    {
        /// <summary>
        /// ����������ȡ��������
        /// </summary>
        /// <param name="id">����������</param>
        /// <returns>������ʵ��</returns>
        string GetContentByID(string id);
       
        /// <summary>
        /// ����������ȡ������ʵ��
        /// </summary>
        /// <param name="id">����������</param>
        /// <returns>������ʵ��</returns>
        T GetByID(string id);
        /// <summary>
        /// �����������Ϣ
        /// </summary>
        /// <param name="t">���µ�����</param>
        string Add(T t);

        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="id">����������</param>
        /// <param name="t">���µ�����</param>
        void Update(string id, T t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);
    }
}

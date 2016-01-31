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
using System.Text;
using Sirc.SharpReport.IDAL;
using SIRC.Framework.Utility;
using Sirc.SharpReport.Model;
using System.Collections.Generic;
using Sirc.SharpReport.DALFactory;

namespace Sirc.SharpReport.BLL
{
    public class FormLibrary<T>
    {
        protected virtual IFormLibrary<T> DAL
        {
            get
            { 
                return DataAccess<T>.CreateFormLibrary();
            }
        }
        /// <summary>
        /// ����������ȡ��������
        /// </summary>
        /// <param name="id">����������</param>
        /// <returns>������ʵ��</returns>
        public string GetContentByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DAL.GetContentByID(id);
        }
        /// <summary>
        /// ����������ȡ������ʵ��
        /// </summary>
        /// <param name="id">����������</param>
        /// <returns>������ʵ��</returns>
        public T GetByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DAL.GetByID(id);
        }
                /// <summary>
        /// �����������Ϣ
        /// </summary>
        /// <param name="t">���µ�����</param>
        public string Add(T t)
        {
            return DAL.Add(t);
        }
        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="id">����������</param>
        /// <param name="t">���µ�����</param>
        public void Update(string id, T t)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            DAL.Update(id, t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            DAL.Delete(id);
        }
    }
}

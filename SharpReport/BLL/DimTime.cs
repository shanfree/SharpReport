/********************************************************************************************
 * �ļ�����:	DimTime.cs
 * �����Ա:	ŷ����
 * ���ʱ��:	2007-02-22
 * ��������:	ʱ�䶨�����ݲ�
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian Sirc
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Sirc.SharpReport.IDAL;
using Sirc.SharpReport.DALFactory;
using Sirc.SharpReport.Model;

namespace Sirc.SharpReport.BLL
{
    /// <summary>
    /// ʱ�䶨�����ݲ�
    /// </summary>
    public class DimTime
    {
        private static readonly IDimTime dal = DataAccess.CreateDimTime();

        /// <summary>
        /// �õ�����б�
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeYearList()
        {
            return dal.GetDimTimeYearList();
        }

        /// <summary>
        /// ������ݵõ��·��б�
        /// </summary>
        /// <param name="year">���</param>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeMonthList(string year)
        {
            if (String.IsNullOrEmpty(year))
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            return dal.GetDimTimeMonthList(year);
        }

        /// <summary>
        /// ������ݵõ������б�
        /// </summary>
        /// <param name="year">���</param>
        /// <returns>DataSet</returns>
        public DataSet GetDimTimeQuarterList(string year)
        {
            if (null == year || string.Empty == year)
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            return dal.GetDimTimeQuarterList(year);
        }

        /// <summary>
        /// ����ʱ��ID��ȡʵ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DimTimeInfo GetDimTimeInfo(string id)
        {
            if (null == id || string.Empty == id)
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            return dal.GetDimTimeInfo(id);
        }
        /// <summary>
        /// ��ȡȥ���ʱ��
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isMonth">true-��,false-��</param>
        /// <returns></returns>
        public DimTimeInfo GetLastDimTime(string id, bool isMonth)
        {
            if (null == id || string.Empty == id)
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            return dal.GetLastDimTime(id, isMonth);
        }
        /// <summary>
        /// ��ȡǰ�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DimTimeInfo GetTheYearBeforeLastDimTimeInfo(string id)
        {
            if (null == id || string.Empty == id)
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            return dal.GetTheYearBeforeLastDimTimeInfo(id);
        }
        /// <summary>
        /// �õ����ȵı�ʶID
        /// </summary>
        /// <param name="year">���</param>
        /// <param name="quarter">���ȵ����</param>
        /// <returns>string</returns>
        public string GetIDByQuarter(string year, string quarter)
        {
            if (null == year || string.Empty == year || null == quarter || string.Empty == quarter)
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            return dal.GetIDByQuarter(year, quarter);
        }
        /// <summary>
        /// �õ��·ݵı�ʶID
        /// </summary>
        /// <param name="year">���</param>
        /// <param name="month">�·ݵ����</param>
        /// <returns>string</returns>
        public string GetIDByMonth(string year, string month)
        {
            if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month))
            {
                throw new ArgumentException("��������Ϊ�ա�");
            }
            int result = -1;
            bool isYear = int.TryParse(year, out result);
            bool isMonth = int.TryParse(month, out result);
            if (isYear == false || isMonth == false)
            {
                throw new ArgumentException("������Ч����ݻ��·�ֵ��");
            }
            return dal.GetIDByMonth(year, month);
        }
    }
}

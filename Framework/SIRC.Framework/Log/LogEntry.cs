/********************************************************************************************
 * �ļ�����:	LogEntry.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-12
 * ��������:	��־������
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
    /// ��־����
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// ��־���ʽӿڣ�����ģʽ
        /// </summary>
        public static SystemLog Log = SingleGeneric<SystemLog>.CreateInstance();

    }
}

/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* PermissionGroup.cs
*
* �� �ܣ� N/A
* �� ���� PermissionGroup
*
* Ver    �������             ������  �������
* ����������������������������������������������������������������������
* V0.01  2013/2/14 14:15:38   N/A    ����
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*������������������������������������������������������������������������
*�����˼�����ϢΪ����˾������Ϣ��δ������˾����ͬ���ֹ���������¶������
*������Ȩ���У�����׿Խ���������Ƽ����޹�˾������������������������������
*������������������������������������������������������������������������
*/
using System;
using System.Data;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip.Model;
using SIRC.Framework.SharpMemberShip.IDAL;
using DAL = SIRC.Framework.SharpMemberShip.SQLServerDAL;

namespace SIRC.Framework.SharpMemberShip.BLL
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class PermissionGroup
    {
        private readonly IPermissionGroup dal = new DAL.PermissionGroup();

        public PermissionGroup()
        { }


        #region ��Ա����
        /// ��ȡ�б�
        /// </summary>
        /// <returns>�б�</returns>
        public IList<PermissionGroupInfo> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// ����ID��ȡʵ��
        /// </summary>
        /// <param name="ID">ʵ������</param>
        /// <returns>ʵ��</returns>
        public PermissionGroupInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("����ID����Ϊ�ա�");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// ��Ӳ���
        /// </summary>
        /// <param name="cInfo">ʵ��</param>
        /// <returns>����ʵ�������</returns>
        public string Add(PermissionGroupInfo cInfo)
        {
            return dal.Add(cInfo);
        }

        /// <summary>
        /// ���²���
        /// </summary>
        /// <param name="cInfo">ʵ��</param>
        public void Update(PermissionGroupInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("����ID����Ϊ�ա�");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// ��Ӳ���
        /// </summary>
        /// <param name="ID">ʵ������</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            PermissionGroupInfo cInfo = new PermissionGroupInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


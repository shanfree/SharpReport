/********************************************************************************************
 * �ļ�����: PermissionGroupInfo.cs
 * �����Ա: ������ ��yanxianghui@gmail.com��
 * ���ʱ��: 2013/2/19
 * ��������: 
 * ע������: 
 * ��Ȩ����: Copyright (c) 2013, Fujian SIRC
 * �޸ļ�¼:       �޸�ʱ��     ��Ա     �޸ı�ע
 *	----------	   --------		-----     -----------------------------------------
 * 
 ********************************************************************************************/

using System;
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip.Model
{
    /// <summary>
    /// ʵ����PermissionGroupInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "PermissionGroup")]
    public class PermissionGroupInfo
    {
        public PermissionGroupInfo()
        { }

        #region �־û��ֶ�
        private string _id;
        /// <summary>
        /// ����
        /// </summary>
        [Persistence(IsPrimaryKey = true, ColumnName = "ID")]
        public string ID
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        private string _name;
        /// <summary>
        /// Ȩ��������
        /// </summary>
        [Persistence(ColumnName = "Name")]
        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }
        private string _remark;
        /// <summary>
        /// ������Ϣ
        /// </summary>
        [Persistence(ColumnName = "Remark")]
        public string Remark
        {
            set
            {
                _remark = value;
            }
            get
            {
                return _remark;
            }
        }
        private string _relationID;
        /// <summary>
        /// ��Ŀ��Ȩ�����ϵ����
        /// </summary>
        [Persistence(ColumnName = "RelationID", IsExtend = true)]
        public string RelationID
        {
            set
            {
                _relationID = value;
            }
            get
            {
                return _relationID;
            }
        }

        #endregion �־û��ֶ�

    }
}


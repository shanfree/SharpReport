/********************************************************************************************
 * �ļ�����: PermissionInfo.cs
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
    /// 
    /// </summary>
    [Flags]
    public enum DefaultPermissions
    {
        ��� = 1,
        �޸� = 2,
        ���� = 4,
        ���� = 8,
    }

    /// <summary>
    /// ʵ����PermissionInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    [Persistence(ColumnName = "Permission")]
    public class PermissionInfo
    {
        public PermissionInfo()
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
        /// Ȩ������
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
        private string _flags;
        /// <summary>
        /// 
        /// </summary>
        [Persistence(ColumnName = "Flags")]
        public string Flags
        {
            set
            {
                _flags = value;
            }
            get
            {
                return _flags;
            }
        }
        private int _groupid;
        /// <summary>
        /// ������Ȩ����
        /// </summary>
        [Persistence(ColumnName = "GroupID")]
        public int GroupID
        {
            set
            {
                _groupid = value;
            }
            get
            {
                return _groupid;
            }
        }
        #endregion �־û��ֶ�

    }
}


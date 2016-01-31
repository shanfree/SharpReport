using System;
using System.Data;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
using System.Collections.Generic;

namespace SIRC.Framework.SharpMemberShip.IDAL
{
    /// <summary>
    /// �ӿڲ�IMenu ��ժҪ˵����
    /// </summary>
    public interface IMenu : IDBPersistenceBase<MenuInfo>
    {
        /// <summary>
        /// ������Ŀ�ڵ�ID��ȡ������Ŀ��
        /// </summary>
        /// <param name="rootID">���ڵ���ĿID</param>
        /// <returns>��Ŀ��</returns>
        IList<MenuInfo> GetTree(string rootID);

        /// <summary>
        /// ��ȡ����Ŀ������Ŀ����
        /// </summary>
        /// <param name="menuID">����ĿID</param>
        /// <returns>��Ŀ���룬ͬ�����Ϊ00��99</returns>
        string GetMaxChildCode(string menuID);

        /// <summary>
        /// �����û�ID��ȡ������Ŀ��
        /// </summary>
        /// <param name="userID">�û�ID</param>
        /// <returns>��Ŀ��</returns>
        IList<MenuInfo> GetTreeByUserID(string userID);

        /// <summary>
        /// �Ƴ���Ŀ��Ӧ��������Ŀ��
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <returns>�����Ƿ�ɹ�</returns>
        bool RemoveAllPermissionGroup(string menuID);

        /// <summary>
        /// Ϊ��Ŀ��Ȩ���飬��Ŀ��Ψһ��Ȩ���飬
        /// �����Ҫ������Ŀ��Ӧ��Ȩ�ޣ������Ŀ�����Ȩ������
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <param name="permissionGroupID">Ȩ����ID</param>
        string AddPermissionGroup(string menuID, string permissionGroupID);

        /// <summary>
        /// Ϊ��һ��ɫ����Ŀ��Ȩ����
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <param name="roleID">��ɫID</param>
        /// <param name="permissionGroupCode">Ȩ������룬����ĳ��Ȩ����Ϊ�����1���޸�10��ɾ��100������1000�����û��ڸ���Ŀ��Ȩ�������1011��ʾ����������޸ĺ�����Ȩ�ޣ���������ɾ��Ȩ��</param>
        void AddRoleToMenu(string menuID, string roleID, string permissionGroupCode);

        /// <summary>
        /// �û���ɫ�ڸ���Ŀӵ�е�λֵ
        /// </summary>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="userSignonGUID">�û���¼�����֤��</param>
        /// <returns></returns>
        string GetPermissionGroupCodeOfMenuByGUID(string menuID, string userSignonGUID);

        /// <summary>
        /// �û���ɫ�ڸ���Ŀӵ�е�λֵ
        /// </summary>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="roleID">��ɫ����</param>
        /// <returns></returns>
        string GetPermissionGroupCodeOfMenuByRole(string menuID, string userSignonGUID);

        /// <summary>
        /// ��ʼ����ĿȨ�ޣ�ɾ��Ŀǰ��Ŀ���������н�ɫ
        /// </summary>
        /// <param name="menuID"></param>
        void InitialMenuRole(string menuID);
    }
}

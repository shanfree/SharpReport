/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* Menu.cs
*
* �� �ܣ� N/A
* �� ���� Menu
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
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip.BLL
{
    /// <summary> 
    /// ��Ŀ
    /// </summary>
    public partial class Menu
    {
        //���ڵ�����
        private const string ROOT_ID = "1";

        private readonly IMenu dal = new DAL.Menu();

        public Menu()
        { }

        /// <summary>
        /// ������Ŀ�ڵ�ID��ȡ������Ŀ��
        /// </summary>
        /// <param name="rootID">���ڵ���ĿID</param>
        /// <returns>��Ŀ��</returns>
        public TreeNodeInfo<MenuInfo> GetTree(string rootID)
        {
            if (string.IsNullOrEmpty(rootID))
            {
                rootID = ROOT_ID;
            }
            IList<MenuInfo> mList = dal.GetTree(rootID);
            TreeNodeInfo<MenuInfo> treeNode = new TreeNodeInfo<MenuInfo>(mList, rootID);
            return treeNode;
        }

        /// <summary>
        /// �����û�ID��ȡ������Ŀ��
        /// </summary>
        /// <param name="userID">�û�ID</param>
        /// <returns>��Ŀ��</returns>
        public TreeNodeInfo<MenuInfo> GetTreeByUserID(string userID, string rootID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                throw new ArgumentNullException("�û�ID����Ϊ�ա�");
            }
            IList<MenuInfo> mList = dal.GetTreeByUserID(userID);
            TreeNodeInfo<MenuInfo> treeNode = new TreeNodeInfo<MenuInfo>(mList, rootID);
            return treeNode;
        }

        /// <summary>
        /// Ϊ��Ŀ��Ȩ���飬��Ŀ��Ψһ��Ȩ���飬
        /// ����Ŀ�µ���������Ŀ��ͬʱ����ͬ��Ȩ���飬
        /// �����Ҫ������Ŀ��Ӧ��Ȩ�ޣ������Ŀ�����Ȩ������
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <param name="permissionGroupID">Ȩ����ID</param>
        public string AddPermissionGroup(string menuID, string permissionGroupID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("��ĿID����Ϊ�ա�");
            }
            if (string.IsNullOrEmpty(permissionGroupID))
            {
                throw new ArgumentNullException("Ȩ����ID����Ϊ�ա�");
            }
            // ���ĵ�ǰ��Ŀ��Ȩ����
            dal.RemoveAllPermissionGroup(menuID);
            string result = dal.AddPermissionGroup(menuID, permissionGroupID);
            // ��������Ŀ��Ȩ����
            TreeNodeInfo<MenuInfo> menuTree = GetTree(menuID);
            if (menuTree.SubNodeList == null || menuTree.SubNodeList.Count == 0)
            {
                return result;
            }
            foreach (TreeNodeInfo<MenuInfo> mInfo in menuTree.SubNodeList)
            {
                //�ݹ�ʵ��
                AddPermissionGroup(mInfo.STInstance.ID, permissionGroupID);
            }
            return result;
        }
        #region ����ɫ����Ŀ�Լ�Ȩ������а�
        /// <summary>
        /// ����ɫ����Ŀ�Լ�Ȩ������а�
        /// </summary>
        /// <param name="menuID">��Ŀ</param>
        /// <param name="permissionGroupID">Ȩ��</param>
        /// <param name="rList">��ɫ�б�</param>
        public void AddRolesToMenu(string menuID, string permissionGroupID, IList<RoleInfo> rList)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("��ѡ����Ŀ");
            }
            if (string.IsNullOrEmpty(permissionGroupID))
            {
                throw new ArgumentNullException("��ѡ��Ȩ����󶨡�");
            }
            if (rList == null || rList.Count == 0)
            {
                throw new ArgumentNullException("��ѡ������һ����ɫ���а󶨡�");
            }
            string relationID = string.Empty;
            PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(menuID);
            if (pgInfo == null || pgInfo.ID != permissionGroupID)
            {
                // ��Ŀδ���κ�Ȩ���飬���Ƚ��а�
                relationID = new BLL.Menu().AddPermissionGroup(menuID, permissionGroupID);
            }
            else
            {
                relationID = pgInfo.RelationID;
            }
            //ɾ����ĿȨ�����������Ӧ�����н�ɫ
            InitialMenuRole(menuID);
            foreach (RoleInfo rInfo in rList)
            {
                string defaultCode = new PermissionGroup().GetDefaultCodeFromPermissionGroupID(permissionGroupID);
                AddRoleToMenu(menuID, rInfo.ID, defaultCode);
            }
        }

        /// <summary>
        /// ��ʼ����ĿȨ�ޣ�ɾ��Ŀǰ��Ŀ���������н�ɫ
        /// </summary>
        /// <param name="menuID"></param>
        private void InitialMenuRole(string menuID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("��ָ����ĿID��");
            }
            dal.InitialMenuRole(menuID);
        }

        /// <summary>
        /// Ϊ��һ��ɫ����Ŀ��Ȩ����
        /// </summary>
        /// <param name="menuID">��ĿID</param>
        /// <param name="roleID">��ɫID</param>
        /// <param name="permissionGroupCode">Ȩ������룬����ĳ��Ȩ����Ϊ�����1���޸�10��ɾ��100������1000�����û��ڸ���Ŀ��Ȩ�������1011��ʾ����������޸ĺ�����Ȩ�ޣ���������ɾ��Ȩ��</param>
        public void AddRoleToMenu(string menuID, string roleID, string permissionGroupCode)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("��ĿID����Ϊ�ա�");
            }
            if (string.IsNullOrEmpty(roleID))
            {
                throw new ArgumentNullException("��ɫID����Ϊ�ա�");
            }
            if (string.IsNullOrEmpty(permissionGroupCode))
            {
                throw new ArgumentNullException("Ȩ������벻��Ϊ�ա�");
            }
            // �ж�Ȩ��������Ƿ��ӦȨ����
            PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(menuID);
            IList<PermissionInfo> pList = new Permission().GetList(pgInfo.ID);
            if (pList == null)
            {
                throw new Exception("��Ŀ" + menuID + "��Ӧ��Ȩ���鲻����");
            }
            if (permissionGroupCode.Length != pList.Count)
            {
                throw new Exception("��ɫ���ʧ�ܣ�Ȩ�������ĳ��Ⱥ�Ȩ����Ŀ����ȡ�");
            }
            dal.AddRoleToMenu(menuID, roleID, permissionGroupCode);
        }
        #endregion


        /// <summary>
        /// �����Ŀ
        /// </summary>
        /// <param name="parentMenuID">���ڵ�ID</param>
        /// <param name="cInfo">��ӵ���Ŀ������Ŀ������Ϣ����MenuCode������Ϊϵͳ�Զ����ɡ���ϵͳ�Ѵ��ڸ��ڵ㣨0103�������Ҿ���2��ͬ���ڵ㣬ͬ���ڵ�������Ϊ��010302������ýڵ���Ϊ010303</param>
        /// <returns>����ʵ�������</returns>
        public string AddChild(string parentMenuID, MenuInfo cInfo)
        {
            if (string.IsNullOrEmpty(parentMenuID))
            {
                throw new ArgumentNullException("���ڵ�ID����Ϊ�ա�");
            }
            // ����������Ŀ����Ŀ����
            string maxChildCode = new Menu().getMaxChildCode(parentMenuID);
            MenuInfo pInfo = new Menu().GetByID(parentMenuID);
            // ĩ2λ+1��Ϊ����Ϊ00��
            if (string.IsNullOrEmpty(maxChildCode))
            {
                cInfo.MenuCode = pInfo.MenuCode + "00";
            }
            else
            {
                // Ĭ�ϱ���Ϊ00��99
                int width = 2;
                string max = maxChildCode.Substring(maxChildCode.Length - width);
                int maxNum = int.Parse(max);
                cInfo.MenuCode = pInfo.MenuCode + String.Format("{0:D2}", maxNum++); ;
            }
            cInfo.ParentID = parentMenuID;
            string menuID = dal.Add(cInfo);
            //��ȡ����ĿȨ���飬�ӽڵ�Ĭ�ϰ�
            PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(parentMenuID);
            if (null != pgInfo && string.IsNullOrEmpty(pgInfo.ID) == true)
            {
                AddPermissionGroup(menuID, pgInfo.ID);
            }
            return menuID;
        }
        /// <summary>
        /// ��ȡ����Ŀ������Ŀ����
        /// </summary>
        /// <param name="menuID">����ĿID</param>
        /// <returns>��Ŀ���룬ͬ�����Ϊ00��99</returns>
        private string getMaxChildCode(string menuID)
        {
            return dal.GetMaxChildCode(menuID);
        }

        /// <summary>
        /// ���ͬ���ڵ�
        /// </summary>
        /// <param name="peerMenuID">ͬ���ڵ�ID</param>
        /// <param name="cInfo">��ӵ���Ŀ������Ŀ������Ϣ����MenuCode������Ϊϵͳ�Զ�����</param>
        /// <returns>����ʵ�������</returns>
        public string AddPeer(string peerMenuID, MenuInfo cInfo)
        {
            if (string.IsNullOrEmpty(peerMenuID))
            {
                throw new ArgumentNullException("ͬ���ڵ�ID����Ϊ�ա�");
            }
            MenuInfo peerNode = GetByID(peerMenuID);
            return AddChild(peerNode.ParentID, cInfo);
        }

        /// <summary>
        /// �ж��û��Ƿ���ض�����Ŀ�����ض���Ȩ��
        /// </summary>
        /// <param name="permissions">�û������Ȩ��</param>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="userSignonGUID">�û���¼�����֤��</param>
        /// <returns></returns>
        public bool CanUserProcessOperation(int permissions, string menuID, string userSignonGUID)
        {
            if (string.IsNullOrEmpty(menuID))
            {
                throw new ArgumentNullException("��ĿID����Ϊ�ա�");
            }
            if (string.IsNullOrEmpty(userSignonGUID))
            {
                throw new ArgumentNullException("�û�δ��¼���ߵ�¼�Ѿ����ڡ�");
            }
            // ��Ȩ�޶�Ӧ��λֵ
            // �û���ɫ�ڸ���Ŀӵ�е�λֵ
            string roleCode = GetPermissionGroupCodeOfMenuByGUID(menuID, userSignonGUID);
            if (string.IsNullOrEmpty(roleCode))
            {
                // ���δ���κ�Ȩ���飬����κ�Ȩ����֤��ʾʧ��
                return false;
            }
            int roleCodeNum = int.Parse(roleCode);
            if ((permissions & roleCodeNum) == permissions)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// �ж��û��Ƿ���ض�����Ŀ�����ض���Ȩ��
        /// </summary>
        /// <param name="permissions">�û������Ȩ��</param>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="userSignonGUID">�û���¼�����֤��</param>
        /// <returns></returns>
        public bool CanUserProcessOperation(DefaultPermissions permissions, string menuID, string userSignonGUID)
        {
            int perCodeNum = EnumHandler<DefaultPermissions>.GetIntFromEnum(permissions);
            return CanUserProcessOperation(perCodeNum, menuID, userSignonGUID);
        }

        /// <summary>
        /// �û���ɫ�ڸ���Ŀӵ�е�λֵ
        /// </summary>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="userSignonGUID">�û���¼�����֤��</param>
        /// <returns></returns>
        private string GetPermissionGroupCodeOfMenuByGUID(string menuID, string userSignonGUID)
        {
            return dal.GetPermissionGroupCodeOfMenuByGUID(menuID, userSignonGUID);
        }

        /// <summary>
        /// �û���ɫ�ڸ���Ŀӵ�е�λֵ
        /// </summary>
        /// <param name="menuID">��Ŀ����</param>
        /// <param name="roleID">��ɫ����</param>
        /// <returns></returns>
        public string GetPermissionGroupCodeOfMenuByRole(string menuID, string roleID)
        {
            return dal.GetPermissionGroupCodeOfMenuByRole(menuID, roleID);
        }


        #region ��Ա����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <returns>�б�</returns>
        public IList<MenuInfo> GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// ��ȡ�û�����Ȩ�޵���Ŀ�б�
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<MenuInfo> GetList(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                throw new ArgumentNullException("�û�ID����Ϊ�ա�");
            }
            IList<MenuInfo> mList = dal.GetTreeByUserID(userID);
            return mList;
        }

        /// <summary>
        /// ����ID��ȡʵ��
        /// </summary>
        /// <param name="ID">ʵ������</param>
        /// <returns>ʵ��</returns>
        public MenuInfo GetByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("����ID����Ϊ�ա�");
            }
            return dal.GetByID(ID);
        }

        /// <summary>
        /// ������Ŀ
        /// </summary>
        /// <param name="cInfo">ʵ��</param>
        public void Update(MenuInfo cInfo)
        {
            if (string.IsNullOrEmpty(cInfo.ID))
            {
                throw new ArgumentNullException("����ID����Ϊ�ա�");
            }
            dal.Update(cInfo);
        }


        /// <summary>
        /// �����Ŀ
        /// </summary>
        /// <param name="ID">ʵ������</param>
        /// <returns></returns>
        public void Delete(string ID)
        {
            MenuInfo cInfo = new MenuInfo();
            cInfo.ID = ID;

            dal.Delete(cInfo);
        }
        #endregion
    }
}


/********************************************************************************************
 * �ļ�����:	TreeNodeInfo.cs
 * �����Ա:	yanxh
 * ���ʱ��:	2007-11-12
 * ��������:	���νṹ��ʵ��ӿ�
 *		
 * ע������:	
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
 *				    ----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml.Serialization;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// ���νṹ��ʵ��ӿ�
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// ����
        /// </summary>
        string ID { get; }
        /// <summary>
        /// ���ڵ�����
        /// </summary>
        string ParentID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        string Name { get; set; }
    }

    /// <summary>
    /// �������ݽṹ�ķ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class TreeNodeInfo<T> where T : ITreeNode //: ISerializable 
    {
        #region ����
        private T _menuNode;
        /// <summary>
        /// ��ǰ�ڵ㣬��SubNodeList����Ԫ�صĸ��ڵ�
        /// </summary>
        public T STInstance
        {
            get { return _menuNode; }
            set { _menuNode = value; }
        }

        private T _currentNode;
        /// <summary>
        /// ��STInstanceΪ���ڵ����������ǰ�����Ľڵ㣬
        /// ��������һ�¸��ڵ������MoveNext()����
        /// </summary>
        [XmlIgnore]
        public T EnumerateNode
        {
            get { return _currentNode; }
            set
            {
                _currentNode = value;
            }
        }
        /// <summary>
        /// �ӽڵ�����
        /// </summary>
        [XmlIgnore]
        public int Count
        {
            get
            {
                int total = 0;
                total = this.SubNodeList.Count;
                if (total != 0)
                {
                    foreach (TreeNodeInfo<T> node in this.SubNodeList)
                    {
                        total += node.Count;
                    }
                }
                return total;
            }
        }
        #region �ӽڵ㼯
        private IList<TreeNodeInfo<T>> _menuList = new List<TreeNodeInfo<T>>();
        /// <summary>
        /// �ӽڵ㼯��
        /// </summary>
        [XmlIgnore]
        public IList<TreeNodeInfo<T>> SubNodeList
        {
            get { return _menuList; }
            set { _menuList = value; }
        }
        /// <summary>
        /// ���л�ʱʹ��
        /// </summary>
        public List<TreeNodeInfo<T>> ChildList
        {
            get { return _menuList as List<TreeNodeInfo<T>>; }
            set { _menuList = value; }
        }
        /// <summary>
        /// �ӽڵ㼯������������ʱʹ��
        /// </summary>
        [XmlIgnore]
        public IList<T> ChildNodeList
        {
            get
            {
                IList<T> list = new List<T>();
                foreach (TreeNodeInfo<T> t in this.SubNodeList)
                {
                    list.Add(t.STInstance);
                }
                return list;
            }
        }
        #endregion


        private int _childIndex = 0;
        /// <summary>
        /// �Ѿ��������ӽڵ�����
        /// </summary>
        [XmlIgnore]
        protected int ChildIndex
        {
            get
            {
                return _childIndex;
            }
            set
            {
                _childIndex = value;
            }
        }
        #endregion

        #region ���캯��
        /// <summary>
        /// ���б�ת��Ϊ���νṹ
        /// </summary>
        /// <param name="list">�б�</param>
        /// <param name="rootID">���ڵ�ID</param>
        public TreeNodeInfo(IList<T> list, string rootID)
        {
            // ��Ӹ��ڵ�
            T t = findNodeByID(list, rootID);
            this.STInstance = t;
            //TreeNodeInfo<T> baseNode = new TreeNodeInfo<T>(t);
            buildReportTreeByParentID(this, list, t.ID);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuNode"></param>
        public TreeNodeInfo(T menuNode)
        {
            this.STInstance = menuNode;
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeInfo()
        {
        }
        #endregion

        #region ����
        /// <summary>
        /// ���ýڵ����
        /// </summary>
        public void Reset()
        {
            this.ChildIndex = 0;
            for (int i = 0; i < this.SubNodeList.Count; i++)
            {
                this.SubNodeList[i].Reset();
            }
        }
        /// <summary>
        /// ������ȱ����ӽڵ�,
        /// ��ȡ�����ĵ�ǰ�ڵ����������EnumerateNode
        /// </summary>
        /// <returns>false��û���ӽڵ㣬true�������ӽڵ�</returns>
        public virtual bool MoveNext()
        {
            // (���ڵ�δ������ and û���ӽڵ�) or �����ӽڵ㶼�Ѿ�����
            //if ((this.ChildIndex == 0 && (null == this.SubNodeList || this.SubNodeList.Count == 0)) || this.ChildIndex == this.SubNodeList.Count - 1)
            if (this.ChildIndex == 0 && (null == this.SubNodeList || this.SubNodeList.Count == 0))
            {
                // �ӽڵ������ϣ�ʹ�õ�ǰ�Ľڵ�
                this.EnumerateNode = this.STInstance;
                this.ChildIndex++;
                // �Ժ����ٸ���������
                return true;
            }
            // ����δ���������ӽڵ�
            else if (this.ChildIndex <= this.SubNodeList.Count - 1 && (null != this.SubNodeList || this.SubNodeList.Count != 0))
            {
                bool hasChild = this.SubNodeList[this.ChildIndex].MoveNext();
                if (hasChild == false)
                {
                    // ȡ�¸��ӽڵ�
                    this.ChildIndex++;
                    if (this.ChildIndex > this.SubNodeList.Count - 1)
                    {
                        // �ӽڵ������ϣ�ʹ�õ�ǰ�Ľڵ�
                        this.EnumerateNode = this.STInstance;
                        this.ChildIndex++;
                        // �Ժ����ٸ���������
                        return true;
                    }
                    else
                    {
                        // ���������ƽ�һ���ڵ�
                        this.SubNodeList[this.ChildIndex].MoveNext();
                    }
                }
                // ʹ������ڵ�
                this.EnumerateNode = this.SubNodeList[this.ChildIndex].EnumerateNode;
                // �ڵ��ƽ��ɹ�
                return true;
            }
            else
            {
                // �������������
                // ֪ͨ���������¸��ֵܽڵ�
                return false;
            }
        }

        /// <summary>
        /// �������ҵ���ӦID�Ľڵ�
        /// </summary>
        /// <param name="queryNodeID">�ڵ�ID</param>
        /// <returns>��Ӧ�ڵ�</returns>
        public T FindByNodeID(string queryNodeID)
        {
            return FindByNodeID(this, queryNodeID);
        }
        /// <summary>
        /// �������ҵ���ӦID�Ľڵ�
        /// </summary>
        /// <param name="node">���ҵ���</param>
        /// <param name="queryNodeID">�ڵ�ID</param>
        /// <returns>��Ӧ�ڵ�</returns>
        public T FindByNodeID(TreeNodeInfo<T> node, string queryNodeID)
        {
            T t = default(T);
            //�����ӽڵ�
            IList<T> cList = node.ChildNodeList;
            t = findNodeByID(cList, queryNodeID);
            if (t.Equals(null) == false)
            {
                return t;
            }
            // ��������
            IList<TreeNodeInfo<T>> subNodeSet = this.SubNodeList;
            foreach (TreeNodeInfo<T> it in subNodeSet)
            {
                t = findNodeByID(it.ChildNodeList, queryNodeID);
                if (t.Equals(null) == false)
                {
                    return t;
                }
                else
                {
                    return FindByNodeID(it, queryNodeID);
                }
            }
            // û�ҵ�
            return t;
        }

        /// <summary>
        /// �������ӽڵ�
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="totalList"></param>
        /// <param name="parentID"></param>
        private void buildReportTreeByParentID(
            TreeNodeInfo<T> currentNode, IList<T> totalList, string parentID)
        {
            IList<T> subNodeSet = findNodeListByParentID(totalList, parentID);
            foreach (T menu in subNodeSet)
            {
                TreeNodeInfo<T> treeNode = new TreeNodeInfo<T>(menu);
                currentNode.SubNodeList.Add(treeNode);

                if (totalList != null && totalList.Count > 0)
                {
                    // ������нڵ�δ��ӣ�������ݹ����
                    buildReportTreeByParentID(treeNode, totalList, menu.ID);
                }
                else
                {
                    // û�и���ڵ���Ҫ��ӣ�����ѭ��
                    continue;
                }
            }
            // ��ǰ�ڵ�������ӽڵ������ϣ�����ѭ��
        }
        /// <summary>
        /// �Ӽ�����ɸѡ��ָ��ID�Ľڵ�
        /// </summary>
        /// <param name="totalList">���нڵ�ļ���</param>
        /// <param name="ID">�ڵ�ID</param>
        /// <returns>T��Ĭ��ֵ��IDΪnull</returns>
        private T findNodeByID(IList<T> totalList, string ID)
        {
            foreach (T t in totalList)
            {
                if (t.ID == ID)
                {
                    return t;
                }
            }
            return default(T);
        }
        /// <summary>
        /// �Ӽ�����ɸѡ��ָ��parentID���Ӽ�
        /// </summary>
        /// <param name="totalList">���нڵ�ļ���,�ڵ㱻ɸѡ���󽫴Ӹü�����ɾ��</param>
        /// <param name="parentID">���ڵ�ID</param>
        /// <returns></returns>
        private IList<T> findNodeListByParentID(IList<T> totalList, string parentID)
        {
            IList<T> resultList = new List<T>();
            if (null == totalList)
            {
                return resultList;
            }
            // �ڵ���Ӻ�ɾ��
            for (int i = 0; i < totalList.Count; )
            {
                T menu = totalList[i];
                if (menu.ParentID == parentID)
                {
                    resultList.Add(menu);
                    totalList.Remove(menu);
                    continue;
                }
                else
                {
                    i++;
                }
            }
            return resultList;
        }
        #endregion
    }
}


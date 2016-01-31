/********************************************************************************************
 * 文件名称:	TreeNodeInfo.cs
 * 设计人员:	yanxh
 * 设计时间:	2007-11-12
 * 功能描述:	树形结构的实体接口
 *		
 * 注意事项:	
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
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
    /// 树形结构的实体接口
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// 主键
        /// </summary>
        string ID { get; }
        /// <summary>
        /// 父节点主键
        /// </summary>
        string ParentID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }
    }

    /// <summary>
    /// 树形数据结构的泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class TreeNodeInfo<T> where T : ITreeNode //: ISerializable 
    {
        #region 属性
        private T _menuNode;
        /// <summary>
        /// 当前节点，是SubNodeList所有元素的父节点
        /// </summary>
        public T STInstance
        {
            get { return _menuNode; }
            set { _menuNode = value; }
        }

        private T _currentNode;
        /// <summary>
        /// 以STInstance为根节点的子树，当前遍历的节点，
        /// 继续遍历一下个节点请调用MoveNext()方法
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
        /// 子节点总数
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
        #region 子节点集
        private IList<TreeNodeInfo<T>> _menuList = new List<TreeNodeInfo<T>>();
        /// <summary>
        /// 子节点集合
        /// </summary>
        [XmlIgnore]
        public IList<TreeNodeInfo<T>> SubNodeList
        {
            get { return _menuList; }
            set { _menuList = value; }
        }
        /// <summary>
        /// 序列化时使用
        /// </summary>
        public List<TreeNodeInfo<T>> ChildList
        {
            get { return _menuList as List<TreeNodeInfo<T>>; }
            set { _menuList = value; }
        }
        /// <summary>
        /// 子节点集，对子树查找时使用
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
        /// 已经遍历的子节点索引
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

        #region 构造函数
        /// <summary>
        /// 将列表转化为树形结构
        /// </summary>
        /// <param name="list">列表</param>
        /// <param name="rootID">根节点ID</param>
        public TreeNodeInfo(IList<T> list, string rootID)
        {
            // 添加根节点
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

        #region 方法
        /// <summary>
        /// 重置节点计数
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
        /// 深度优先遍历子节点,
        /// 获取遍历的当前节点请调用属性EnumerateNode
        /// </summary>
        /// <returns>false：没有子节点，true：还有子节点</returns>
        public virtual bool MoveNext()
        {
            // (本节点未遍历过 and 没有子节点) or 所有子节点都已经遍历
            //if ((this.ChildIndex == 0 && (null == this.SubNodeList || this.SubNodeList.Count == 0)) || this.ChildIndex == this.SubNodeList.Count - 1)
            if (this.ChildIndex == 0 && (null == this.SubNodeList || this.SubNodeList.Count == 0))
            {
                // 子节点遍历完毕，使用当前的节点
                this.EnumerateNode = this.STInstance;
                this.ChildIndex++;
                // 以后不用再该子树遍历
                return true;
            }
            // 存在未遍历过得子节点
            else if (this.ChildIndex <= this.SubNodeList.Count - 1 && (null != this.SubNodeList || this.SubNodeList.Count != 0))
            {
                bool hasChild = this.SubNodeList[this.ChildIndex].MoveNext();
                if (hasChild == false)
                {
                    // 取下个子节点
                    this.ChildIndex++;
                    if (this.ChildIndex > this.SubNodeList.Count - 1)
                    {
                        // 子节点遍历完毕，使用当前的节点
                        this.EnumerateNode = this.STInstance;
                        this.ChildIndex++;
                        // 以后不用再该子树遍历
                        return true;
                    }
                    else
                    {
                        // 否则向下推进一个节点
                        this.SubNodeList[this.ChildIndex].MoveNext();
                    }
                }
                // 使用子孙节点
                this.EnumerateNode = this.SubNodeList[this.ChildIndex].EnumerateNode;
                // 节点推进成功
                return true;
            }
            else
            {
                // 该子树遍历完毕
                // 通知父级遍历下个兄弟节点
                return false;
            }
        }

        /// <summary>
        /// 在树中找到对应ID的节点
        /// </summary>
        /// <param name="queryNodeID">节点ID</param>
        /// <returns>对应节点</returns>
        public T FindByNodeID(string queryNodeID)
        {
            return FindByNodeID(this, queryNodeID);
        }
        /// <summary>
        /// 在树中找到对应ID的节点
        /// </summary>
        /// <param name="node">查找的树</param>
        /// <param name="queryNodeID">节点ID</param>
        /// <returns>对应节点</returns>
        public T FindByNodeID(TreeNodeInfo<T> node, string queryNodeID)
        {
            T t = default(T);
            //查找子节点
            IList<T> cList = node.ChildNodeList;
            t = findNodeByID(cList, queryNodeID);
            if (t.Equals(null) == false)
            {
                return t;
            }
            // 查找子树
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
            // 没找到
            return t;
        }

        /// <summary>
        /// 加所有子节点
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
                    // 如果还有节点未添加，则继续递归添加
                    buildReportTreeByParentID(treeNode, totalList, menu.ID);
                }
                else
                {
                    // 没有更多节点需要添加，跳出循环
                    continue;
                }
            }
            // 当前节点的所有子节点添加完毕，跳出循环
        }
        /// <summary>
        /// 从集合中筛选出指定ID的节点
        /// </summary>
        /// <param name="totalList">所有节点的集合</param>
        /// <param name="ID">节点ID</param>
        /// <returns>T的默认值，ID为null</returns>
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
        /// 从集合中筛选出指定parentID的子集
        /// </summary>
        /// <param name="totalList">所有节点的集合,节点被筛选出后将从该集合中删除</param>
        /// <param name="parentID">父节点ID</param>
        /// <returns></returns>
        private IList<T> findNodeListByParentID(IList<T> totalList, string parentID)
        {
            IList<T> resultList = new List<T>();
            if (null == totalList)
            {
                return resultList;
            }
            // 节点添加后删除
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


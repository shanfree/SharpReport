/********************************************************************************************
 * 文件名称:	WUC_NewsList.cs
 * 设计人员:	严向晖（ｙａｎｘｉａｎｇｈｕｉ＠ｇｍａｉｌ．ｃｏｍ）
 * 设计时间:	2007-09-12
 * 功能描述:	首页显示的栏目样式
 * 注意事项:	
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace SIRC.Framework.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DropdownTreeBase<T> : System.Web.UI.UserControl where T : ITreeNode
    {
        #region 属性
        private TreeNodeInfo<T> _TreeNode = null;
        /// <summary>
        /// 数据源
        /// </summary>
        public TreeNodeInfo<T> DataSource
        {
            get
            {
                return _TreeNode;
            }
            set
            {
                _TreeNode = value;
            }
        }

        private string _ErrorMessage = "";
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
            }
        }

        private bool _IsClear = false;
        /// <summary>
        /// 是否显示清空按钮
        /// </summary>
        public bool IsClear
        {
            get
            {
                return _IsClear;
            }
            set
            {
                _IsClear = value;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tMenus"></param>
        protected void DataBind(TreeView tMenus)
        {
            TreeNodeInfo<T> tree = this.DataSource;
            if (null == tree)
            {
                return;
            }
            //TODO:MasterPage_Default 代码重复，需要重构
            foreach (TreeNodeInfo<T> node in tree.SubNodeList)
            {
                string name = node.STInstance.Name;
                string id = node.STInstance.ID;
                TreeNode treeNode = new TreeNode(name, id);
                NodeAdd(node.STInstance, treeNode);
                tMenus.Nodes.Add(treeNode);
                if (node.Count != 0)
                {
                    BindTree(node, treeNode);
                }
            }
        }

        /// <summary>
        /// 生成栏目树
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="treeNode"></param>
        private void BindTree(TreeNodeInfo<T> tree, TreeNode treeNode)
        {
            foreach (TreeNodeInfo<T> node in tree.SubNodeList)
            {
                string name = node.STInstance.Name;
                string id = node.STInstance.ID;
                TreeNode subNode = new TreeNode(name, id);
                NodeAdd(node.STInstance, subNode);
                treeNode.ChildNodes.Add(subNode);
                if (node.Count != 0)
                {
                    BindTree(node, subNode);
                }
            }
        }

        /// <summary>
        /// 节点被添加到树控件时，可重写的方法
        /// </summary>
        /// <param name="t"></param>
        /// <param name="treeNode"></param>
        protected virtual void NodeAdd(T t,TreeNode treeNode)
        {
            return;
        }
    }
}

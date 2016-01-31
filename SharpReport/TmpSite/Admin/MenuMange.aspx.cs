/********************************************************************************************
 * 文件名称:	.cs
 * 设计人员:	严向晖(yanxianghui@gmail.com)
 * 设计时间:	2009-04-10
 * 功能描述:	
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Web.UI.WebControls;
using Shanfree.Portal.BLL;
using Shanfree.Portal.Model;
using System.Diagnostics;
using Shanfree.Framework.Utility;

public partial class Admin_MenuMange : BasePage
{
    #region 属性
    /// <summary>
    /// 需要后台登陆
    /// </summary>
    protected override bool IsAdminPage
    {
        get
        {
            return true;
        }
    }
    /// <summary>
    /// 栏目ID
    /// </summary>
    private string MenuID
    {
        get
        {
            return GetViewState("MenuID");
        }
        set
        {
            ViewState["MenuID"] = value;
        }
    }
    /// <summary>
    /// 父栏目ID
    /// </summary>
    private string ParentID
    {
        get
        {
            return GetViewState("ParentID");
        }
        set
        {
            ViewState["ParentID"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindTree();
            }
        }
        catch (Exception ex)
        {
            ShowMsg(ex.Message);
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.一般错误);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void BindTree()
    {
        tMenus.Nodes.Clear();
        TreeNodeInfo<MenuInfo> tree = new CommonMenu().GetMenuTree(MenuInfo.DEFAULT_PARENT_ID, true);
        foreach (TreeNodeInfo<MenuInfo> node in tree.SubNodeList)
        {
            string name = node.STInstance.Name;
            string id = node.STInstance.ID;
            string url = node.STInstance.Url;
            string sortNum = node.STInstance.SortNum.ToString();
            TreeNode treeNode = new TreeNode(name, id);
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
    /// <param name="parentItem"></param>
    private void BindTree(TreeNodeInfo<MenuInfo> tree, TreeNode treeNode)
    {
        foreach (TreeNodeInfo<MenuInfo> node in tree.SubNodeList)
        {
            string name = node.STInstance.Name;
            string id = node.STInstance.ID;
            string url = node.STInstance.Url;
            TreeNode subNode = new TreeNode(name, id);
            treeNode.ChildNodes.Add(subNode);
            if (node.Count != 0)
            {
                BindTree(node, subNode);
            }
        }
    }
    /// <summary>
    /// 选择编辑栏目
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tMenus_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            //选中节点值
            string value = tMenus.SelectedNode.Value;
            this.MenuID = value;
            MenuInfo mInfo = new CommonMenu().GetMenuByID(this.MenuID);
            this.ParentID = mInfo.ParentID;
            lbName.Text = mInfo.Name;
            tbName.Text = mInfo.Name;
            tbSortNum.Text = mInfo.SortNum.ToString();
            tbURL.Text = mInfo.Url;
            rblIsShow.SelectedIndex = (mInfo.IsShow == true) ? 0 : 1;
            rblExtend.SelectedIndex = (mInfo.IsExtendUrl == true) ? 0 : 1;
            rblNews.SelectedIndex = (mInfo.IsRecentNews == true) ? 0 : 1;
            btnSubmit.Visible = true;
            btnAdd.Visible = true;
            btnDel.Visible = true;
            btnSub.Visible = true;
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string menuID = this.MenuID;
            string parentID = this.ParentID;
            string name = tbName.Text;
            string url = tbURL.Text;
            int sortNum = Convert.ToInt16(tbSortNum.Text);
            bool isShow = (rblIsShow.SelectedIndex == 0) ? true : false;
            bool isExtend = (rblExtend.SelectedIndex == 0) ? true : false;
            bool isNews = (rblNews.SelectedIndex == 0) ? true : false;
            new CommonMenu().Update(menuID, name, parentID, sortNum, isShow, url, isExtend, isNews);
            BindTree();
            ShowMsg("操作成功。");
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    /// <summary>
    /// 添加同级节点
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string parentID = this.ParentID;
            string name = tbName.Text;
            string url = tbURL.Text;
            int sortNum = Convert.ToInt16(tbSortNum.Text);
            bool isShow = (rblIsShow.SelectedIndex == 0) ? true : false;
            bool isExtend = (rblExtend.SelectedIndex == 0) ? true : false;
            bool isNews = (rblNews.SelectedIndex == 0) ? true : false;
            string id = new CommonMenu().Add(name, parentID, sortNum, isShow, url, isExtend, isNews);
            this.MenuID = id;
            BindTree();
            ShowMsg("操作成功。");
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    /// <summary>
    /// 添加子节点
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSub_Click(object sender, EventArgs e)
    {
        try
        {
            this.ParentID = this.MenuID;
            string parentID = this.MenuID;
            string name = tbName.Text;
            string url = tbURL.Text;
            int sortNum = Convert.ToInt16(tbSortNum.Text);
            bool isShow = (rblIsShow.SelectedIndex == 0) ? true : false;
            bool isExtend = (rblExtend.SelectedIndex == 0) ? true : false;
            bool isNews = (rblNews.SelectedIndex == 0) ? true : false;
            string id = new CommonMenu().Add(name, parentID, sortNum, isShow, url, isExtend, isNews);
            this.MenuID = id;
            BindTree();
            ShowMsg("操作成功。");
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            string menuID = this.MenuID;
            new CommonMenu().Delelte(menuID);
            BindTree();
            ShowMsg("操作成功。");
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
}

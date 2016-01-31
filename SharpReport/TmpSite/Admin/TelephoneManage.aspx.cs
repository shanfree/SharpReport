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
using Shanfree.Portal.BLL;
using System.Web.UI.WebControls;
using Shanfree.Portal.Model;
using System.Collections.Generic;
using System.Diagnostics;
using Shanfree.Framework.Utility;

public partial class Admin_TelephoneManage : BasePage
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
    private string OfficeID
    {
        get
        {
            return GetViewState("OfficeID");
        }
        set
        {
            ViewState["OfficeID"] = value;
            btnAdd.Visible = true;
            btnDel.Visible = true;
            btnSub.Visible = true;
            btnSubmit.Visible = true;
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
        if (!IsPostBack)
        {
            BindingTree();
            BindingList();
        }
    }

    #region 绑定部门树
    /// <summary>
    /// 绑定部门树
    /// </summary>
    /// <param name="tOffice"></param>
    /// <param name="oTree"></param>
    private void BindingTree()
    {
        tOffice.Nodes.Clear();
        TreeNodeInfo<OfficerInfo> oTree = new Officer().GetTree(OfficerInfo.ROOT_ID);

        foreach (TreeNodeInfo<OfficerInfo> node in oTree.SubNodeList)
        {
            string name = node.STInstance.Name;
            string id = node.STInstance.ID;
            TreeNode treeNode = new TreeNode(name, id);
            tOffice.Nodes.Add(treeNode);
            if (node.Count != 0)
            {
                BindingTree(node, treeNode);
            }
        }
        tOffice.ExpandAll();
    }

    private void BindingTree(TreeNodeInfo<OfficerInfo> node, TreeNode treeNode)
    {
        foreach (TreeNodeInfo<OfficerInfo> item in node.SubNodeList)
        {
            string name = item.STInstance.Name;
            string id = item.STInstance.ID;
            TreeNode subNode = new TreeNode(name, id);
            treeNode.ChildNodes.Add(subNode);
            if (item.Count != 0)
            {
                BindingTree(item, subNode);
            }
        }
    }
    #endregion

    #region 部门树操作
    protected void tOffice_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            //选中节点值
            string officerID = tOffice.SelectedNode.Value;
            this.OfficeID = officerID;
            OfficerInfo oInfo = new Officer().GetByID(officerID);
            this.ParentID = oInfo.ParentID;
            tbName.Text = oInfo.Name;
            tbSortNum.Text = oInfo.SortNum;
            tbRemark.Text = oInfo.Remark;
            BindingList();
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    #region 联系人列表操作
    /// <summary>
    /// 绑定表格
    /// </summary>
    private void BindingList()
    {
        string officeID = this.OfficeID;
        if (string.IsNullOrEmpty(officeID))
        {
            return;
        }
        int pageSize = gvList.PageSize;
        int pageIndex = pGrid.CurrentPageIndex;
        CustomList<ContactInfo> cList = new Contact().GetList(officeID, pageSize, pageIndex) as CustomList<ContactInfo>;
        cList.Add(new ContactInfo());
        gvList.DataSource = cList;
        gvList.DataBind();
        if (cList == null || cList.Count == 0)
        {
            pGrid.TotalAmout = 0;
            return;
        }
        pGrid.TotalAmout = cList.TotalAmout;
        pGrid.PageSize = pageSize;
    }
    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void pGrid_OnClick(object sender, EventArgs e)
    {
        try
        {
            BindingList();
        }
        catch (Exception exc)
        {
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }
    #endregion


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string id = this.OfficeID;
            string parentID = this.ParentID;
            string name = tbName.Text;
            string remark = tbRemark.Text;
            int sortNum = Convert.ToInt16(tbSortNum.Text);
            new Officer().Update(id, name, remark, sortNum.ToString());
            BindingTree();
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string parentID = this.ParentID;
            string name = tbName.Text;
            string remark = tbRemark.Text;
            int sortNum = Convert.ToInt16(tbSortNum.Text);
            new Officer().Add(name, parentID, remark, sortNum.ToString());
            BindingTree();
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            string id = this.OfficeID;
            new Officer().Delete(id);
            BindingTree();
            this.OfficeID = string.Empty;
            this.ParentID = string.Empty;
            btnAdd.Visible = false;
            btnDel.Visible = false;
            btnSub.Visible = false;
            btnSubmit.Visible = false;
            tbName.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbSortNum.Text = string.Empty;
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    protected void btnSub_Click(object sender, EventArgs e)
    {
        try
        {
            this.ParentID = this.OfficeID;
            string parentID = this.OfficeID;
            string name = tbName.Text;
            string remark = tbRemark.Text;
            int sortNum = Convert.ToInt16(tbSortNum.Text);
            string id = new Officer().Add(name, parentID, remark, sortNum.ToString());
            this.OfficeID = id;
            BindingTree();
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.联系人管理);
        }
    }
    #endregion

    protected void gvList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)e.CommandSource).Parent.Parent;
        Label lblID = row.FindControl("lblID") as Label;//ID
        TextBox tbInnerPhone = row.FindControl("tbInnerPhone") as TextBox;
        TextBox tbOutterPhone = row.FindControl("tbOutterPhone") as TextBox;
        TextBox tbRemark = row.FindControl("tbRemark") as TextBox;
        string id = lblID.Text;
        string innerPhone = tbInnerPhone.Text;
        string outterPhone = tbOutterPhone.Text;
        string remark = tbRemark.Text;
        string officerID = this.OfficeID;
        try
        {
            #region 新增
            if (e.CommandName == "Add")
            {
                new Contact().Add(innerPhone, outterPhone, remark, officerID);
                this.ShowMsg("增加成功!");
            }
            #endregion

            #region 保存
            if (e.CommandName == "Save")
            {
                new Contact().Update(id, innerPhone, outterPhone, remark, officerID);
                this.ShowMsg("保存成功!");
            }
            #endregion

            #region 删除
            if (e.CommandName == "Del")
            {
                new Contact().Delete(id);
                this.ShowMsg("删除成功!");
            }
            #endregion
            BindingList();
        }
        catch (ArgumentNullException aEx)
        {
            this.ShowMsg(aEx.Message);
        }
        catch (Exception ex)
        {
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.其他);
            this.ShowMsg(ex.Message);
        }
    }
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                Button btnDel = (Button)e.Row.FindControl("btnDel");
                Button btnSave = (Button)e.Row.FindControl("btnSave");
                Label lblID = (Label)e.Row.FindControl("lblID"); //基础表ID
                if (lblID.Text == "") //表示新增，只显示新增按钮，不显示删除，修改按钮
                {
                    btnAdd.Visible = true;
                    btnDel.Visible = false;
                    btnSave.Visible = false;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnDel.Visible = true;
                    btnSave.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.其他);
            this.ShowMsg(ex.Message);
        }
    }
}

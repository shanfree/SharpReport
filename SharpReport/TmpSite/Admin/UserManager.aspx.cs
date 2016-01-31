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
using Shanfree.Portal.Model;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Shanfree.Framework.Utility;
using System.Diagnostics;

public partial class Admin_UserManager : BasePage
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    private void BindList()
    {
        IList<AdminUserInfo> list = new AdminUser().GetList(20, 0);
        AdminUserInfo aInfo = new AdminUserInfo();
        aInfo.Time = DateTime.Now;
        list.Add(aInfo);
        gvUserList.DataSource = list;
        gvUserList.DataBind();
    }

    protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string ID = e.CommandArgument.ToString();
            if (e.CommandName == "btnDel")
            {
                new AdminUser().Delete(ID);
            }
            else
            {
                #region 控件
                int index = Convert.ToInt32(ID);
                GridViewRow gvr = (GridViewRow)gvUserList.Rows[index];
                TextBox tbName = (TextBox)gvr.FindControl("tbName");
                TextBox tbPwd = (TextBox)gvr.FindControl("tbPwd");
                TextBox tbTime = (TextBox)gvr.FindControl("tbTime");
                #endregion

                if (e.CommandName == "btnEdit")
                {
                    new AdminUser().Update(tbName.Text, tbPwd.Text);
                }

                if (e.CommandName == "btnAdd")
                {
                    new AdminUser().Add(tbName.Text, tbPwd.Text);
                }
            }
            ShowMsg("操作成功！");
            BindList();
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }
    protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnAdd = (Button)e.Row.FindControl("btnAdd");
            Button btnEdit = (Button)e.Row.FindControl("btnEdit");
            Button btnDel = (Button)e.Row.FindControl("btnDel");
            TextBox tbName = (TextBox)e.Row.FindControl("tbName");
            TextBox tbPwd = (TextBox)e.Row.FindControl("tbPwd");
            TextBox tbTime = (TextBox)e.Row.FindControl("tbTime");

            if (tbName == null || string.IsNullOrEmpty(tbName.Text))
            {
                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDel.Visible = false;
            }
            else
            {
                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDel.Visible = true;
            }
        }
    }
}

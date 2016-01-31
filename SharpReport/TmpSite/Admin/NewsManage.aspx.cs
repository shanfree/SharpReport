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
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Shanfree.Framework.Utility;

public partial class Admin_NewsManage : BasePage
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
            BindMenuList();
            BindList();
        }
    }

    private void BindMenuList()
    {
        //dtMenu.SetClientID(dtMenu.ClientID);
        TreeNodeInfo<MenuInfo> list = new CommonMenu().GetMenuTree(MenuInfo.DEFAULT_PARENT_ID, true);
        dtMenu.DataSource = list;
        dtMenu.DataBind();
    }

    private void BindList()
    {
        int index = pGrid.CurrentPageIndex;
        int pageSize = 20;
        CustomList<NewsInfo> cList = new News().GetList(pageSize, index) as CustomList<NewsInfo>;
        rList.DataSource = cList;
        rList.DataBind();
        if (cList == null || cList.Count == 0)
        {
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
            BindList();
        }
        catch (Exception exc)
        {
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }

    protected void DelComm_Click(object sender, CommandEventArgs e)
    {
        string id = e.CommandName;
        new News().Delelte(id);
        Response.Redirect("NewsManage.aspx");
    }

    protected void btQuery_Click(object sender, EventArgs e)
    {
        string title = tbTitle.Text;
        string menuID = dtMenu.NodeID;
        int pageSize = 20;
        CustomList<NewsInfo> cList = new News().GetList(menuID, title, pageSize, 0) as CustomList<NewsInfo>;
        rList.DataSource = cList;
        rList.DataBind();
        if (cList == null || cList.Count == 0)
        {
            pGrid.TotalAmout = 0;
            return;
        }
        pGrid.TotalAmout = cList.TotalAmout;
        pGrid.PageSize = pageSize;

    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        BindList();
    }
}

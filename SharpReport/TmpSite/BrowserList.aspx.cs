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

public partial class BrowserList : BasePage
{
    /// <summary>
    /// 指定的栏目ID
    /// </summary>
    public string MenuID
    {
        get
        {
            string menuID = GetViewState("MenuID");
            return menuID;
        }
        set
        {
            ViewState["MenuID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string menuID = GetRequest("mID");
            if (string.IsNullOrEmpty(menuID))
            {
                //menuID = "2";
                return;
            }
            this.MenuID = menuID;
            nlMenuNews.MenuID = this.MenuID;
        }
        //BindList(this.MenuID);
    }

    /// <summary>
    /// 绑定子栏目的新闻
    /// </summary>
    /// <param name="menuID"></param>
    private void BindList(string menuID)
    {
        //IList<MenuInfo> mList = new CommonMenu().GetSubMenuList(menuID);
        //gvSubMenu.DataSource = mList;
        //gvSubMenu.DataBind();
    }
    protected void gvSubMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    MenuInfo mInfo = e.Row.DataItem as MenuInfo;

        //    // 选择控件，传入收件的事务主键，用来更新
        //    WUC_MenuDetail rbSel = (WUC_MenuDetail)e.Row.FindControl("nlSub");
        //    rbSel.MenuID = mInfo.ID;
        //}

    }
}

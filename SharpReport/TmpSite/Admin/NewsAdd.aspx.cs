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
using System.Configuration;

public partial class Admin_NewsAdd : BasePage
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
    protected string ID
    {
        get
        {
            return GetViewState("ID");
        }
        set
        {
            ViewState["ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                //开始==========================================
                Session["FCKeditor:UserFilesPath"] = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"] + "/" + DateTime.Now.ToString("yyyyMM") + "/image";

                string userFilesPath = System.Web.HttpContext.Current.Server.MapPath("~") + "/"
                    + ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"].Replace("../", string.Empty)
                    + "/" + DateTime.Now.ToString("yyyyMM") + "/image";
                //检查上传目录是否已经被创建
                //检查当前完整路径是否存在，不存在则开始逐级轮询检查，不存则就创建
                if (!System.IO.Directory.Exists(userFilesPath))
                {
                    string[] tempDirectorys = userFilesPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    string tempDirectory = string.Empty;
                    for (int i = 0; i < tempDirectorys.Length; i++)
                    {
                        tempDirectory += tempDirectorys[i] + "/";
                        if (!System.IO.Directory.Exists(tempDirectory))
                            System.IO.Directory.CreateDirectory(tempDirectory);
                    }
                }
                //结束==========================================

                string menuID = string.Empty;
                string menuName = string.Empty;
                string id = GetRequest("ID");
                // TODO:
                //id = "137";
                if (!string.IsNullOrEmpty(id))
                {
                    this.ID = id;
                    btnBrowse.Visible = true;
                    btnBrowse.Attributes.Add("onclick", "window.open('../Browse.aspx?ID=" + id + "'); return false;");
                    NewsInfo nInfo = new News().GetByID(id);
                    menuID = nInfo.MenuID;
                    menuName = nInfo.MenuName;
                    tbTitle.Text = nInfo.Title;
                    FCKeditor1.Value = nInfo.Content;
                    tbSummary.Text = nInfo.Summary;
                    tbSource.Text = nInfo.Source;
                }
                BindMenuList(menuID, menuName);
            }
        }
        catch (Exception ex)
        {
            ShowMsg(ex.Message);
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.一般错误);
        }
    }
    private void BindMenuList(string menuID, string menuName)
    {
        //dtMenu.SetClientID(dtMenu.ClientID);
        TreeNodeInfo<MenuInfo> list = new CommonMenu().GetMenuTree(MenuInfo.DEFAULT_PARENT_ID, true);
        dtMenu.DataSource = list;
        dtMenu.DataBind();
        dtMenu.NodeID = menuID;
        dtMenu.Name = menuName;
    }

    protected void btnNewsAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string menuID = dtMenu.NodeID;
            string title = tbTitle.Text;
            string content = FCKeditor1.Value;
            string summary = tbSummary.Text;
            string source = tbSource.Text;
            if (string.IsNullOrEmpty(this.ID))
            {
                new News().Add(title, summary, new string[] { "" }, content, menuID, source,"32");
            }
            else
            {
                new News().Update(this.ID, title, summary, new string[] { "" }, content, menuID, source,"32");
            }
            ShowMsg("文档更新成功.");
        }
        catch (Exception ex)
        {
            ShowMsg(ex.Message);
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.一般错误);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shanfree.Framework.Utility;
using Shanfree.Portal.BLL;

public partial class Admin_Config : BasePage
{
    /// <summary>
    /// 需要后台登陆
    /// </summary>
    protected override bool IsAdminPage
    {
        get
        {
            return false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string configFile = AppDomain.CurrentDomain.BaseDirectory + @"web.config";
            string baseUrl = Config.AppSettingsRead(configFile, "HostName");
            this.tbBaseURL.Text = baseUrl;
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        string configFile = AppDomain.CurrentDomain.BaseDirectory + @"web.config";
        string url = tbURL.Text;
        Config.AppSettingsEdit(configFile, "HostName", url);
        this.tbBaseURL.Text = url;
        ShowMsg("修改成功。");
    }
}

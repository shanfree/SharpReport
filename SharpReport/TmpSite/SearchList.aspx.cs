using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Shanfree.Portal.BLL;
using Shanfree.Framework.Utility;
using Shanfree.Portal.Model;
using System.Diagnostics;

public partial class SearchList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList(gvList.PageSize, 0);
        }
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
            int pageSize = gvList.PageSize;
            int pageIndex = pGrid.CurrentPageIndex;
            BindList(pageSize, pageIndex);
        }
        catch (Exception exc)
        {
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }

    private void BindList(int pageSize, int pageIndex)
    {
        string keywordEn = GetRequest("key");
        if (string.IsNullOrEmpty(keywordEn))
        {
            return;
        }
        string keyword = Server.UrlDecode(keywordEn);
        CustomList<NewsInfo> cList = new News().GetList(keyword, pageSize, pageIndex) as CustomList<NewsInfo>;
        gvList.DataSource = cList;
        gvList.DataBind();
        gvList.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0);
        if (cList == null || cList.Count == 0)
        {
            return;
        }
        pGrid.TotalAmout = cList.TotalAmout;
        pGrid.PageSize = pageSize;
    }
}

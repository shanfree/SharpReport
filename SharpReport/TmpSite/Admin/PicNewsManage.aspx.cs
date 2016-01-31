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
using System.IO;

public partial class Admin_PicNewsManage : BasePage
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
            BindList();
        }
    }

    private void BindList()
    {
        int index = 0;
        int pageSize = 20;
        string menuID = "1";
        CustomList<NewsInfo> cList = new News().GetListByMenuID(menuID, pageSize, index) as CustomList<NewsInfo>;
        gvList.DataSource = cList;
        gvList.DataBind();
    }

    protected void btQuery_Click(object sender, EventArgs e)
    {

    }
    protected void btnAll_Click(object sender, EventArgs e)
    {

    }
    protected void btnGen_Click(object sender, EventArgs e)
    {
        try
        {
            NewsListInfo list = new NewsListInfo();
            foreach (GridViewRow row in gvList.Rows)
            {
                CheckBox cbSel = row.FindControl("cbSel") as CheckBox;
                string id = cbSel.Attributes["value"];
                NewsInfo nInfo = new News().GetByID(id);
                if (cbSel.Checked == true)
                {
                    PicNewsInfo pInfo = new PicNewsInfo();
                    pInfo.Summary = nInfo.Summary;
                    pInfo.Url = this.SiteUrl + "Browse.aspx?id=" + id;
                    pInfo.Title = nInfo.Title;
                    string content = nInfo.Content;
                    int imgStart = content.IndexOf("<img");
                    int srcStart = content.IndexOf("src", imgStart);
                    int start = content.IndexOf("UploadFiles/", srcStart);
                    int end = content.IndexOf("\"", start);

                    pInfo.FilePath = content.Substring(start, end - start);
                    list.List.Add(pInfo);
                }
            }
            Save(list);
            ShowMsg("图片新闻生成成功。");
        }
        catch (Exception ex)
        {
            ShowMsg("生成出错：" + ex.Message);
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.一般错误);
        }
    }
    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbSel = e.Row.FindControl("cbSel") as CheckBox;
                NewsInfo nInfo = e.Row.DataItem as NewsInfo;
                cbSel.Attributes["value"] = nInfo.ID;
            }
        }
        catch (Exception ex)
        {
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.一般错误);
        }
    }
    protected void gvSelect_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Flash\PicNews.xml");
        NewsListInfo nInfo = SerializeHandler<NewsListInfo>.DeSerializeFromXMLFile(filePath);

        Button btnSort = e.CommandSource as Button;
        GridViewRow row = btnSort.Parent.Parent as GridViewRow;
        int index = row.DataItemIndex;
        string comName = e.CommandName;
        if (comName == "Up")
        {
            if (index == 0)
            {
                return;
            }
            PicNewsInfo pInfo = nInfo.List[index];
            nInfo.List.RemoveAt(index);
            nInfo.List.Insert(--index, pInfo);
        }
        else if (comName == "Down")
        {
            if (index == gvSelect.Rows.Count -1)
            {
                return;
            }
            PicNewsInfo pInfo = nInfo.List[index];
            nInfo.List.RemoveAt(index);
            nInfo.List.Insert(++index, pInfo);
        }
        Save(nInfo);
    }

    private void Save(NewsListInfo nInfo)
    {
        if (null != nInfo && nInfo.List.Count != 0)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Flash\PicNews.xml");
            SerializeHandler<NewsListInfo>.SerializeToXMLFile(nInfo, filePath);
        }
        gvSelect.DataSource = nInfo.List;
        gvSelect.DataBind();
        gvSelect.Visible = true;
    }
}

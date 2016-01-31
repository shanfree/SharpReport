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
using Shanfree.Framework.Utility;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class Browse : BasePage
{
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
        string id = GetRequest("ID");
        //if (string.IsNullOrEmpty(id))
        //{
        //    id = "137";
        //}
        Label lbClickCount = (Label)((MasterPage)Master).FindControl("lbClickCount");
        lbClickCount.Text = this.GetClickCount(id);

        if (!IsPostBack)
        {
            this.ID = id;
            NewsInfo nInfo = new News().GetByID(id);
            lbTitle.Text = nInfo.Title;
            this.Title = nInfo.Title;
            lbFrom.Text = "文章来源:" + nInfo.Source;
            lbTime.Text = "添加时间:" + nInfo.CreateTime;
            lbClick.Text = "点击数：" + lbClickCount.Text;
            lbContent.Text = nInfo.Content;
        }
        //string xml = new News().ExportPictureNewsToXML("");
    }
}

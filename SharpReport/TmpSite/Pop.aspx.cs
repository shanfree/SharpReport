/********************************************************************************************
 * 文件名称:	Pop.cs
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

public partial class Pop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomList<NewsInfo> cList = new News().GetListByMenuID("14", 1, 0) as CustomList<NewsInfo>;
            if (cList.Count == 0)
            {
                return;
            }
            NewsInfo nInfo = cList[0];
            lbTitle.Text = nInfo.Title;
            this.Title = nInfo.Title;
            lbFrom.Text = "文章来源:" + nInfo.Source;
            lbTime.Text = "添加时间:" + nInfo.CreateTime;
            lbContent.Text = nInfo.Content;
        }
    }
}

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
using System.Web.UI;
using Shanfree.Portal.Model;
using Shanfree.Framework.Utility;

public partial class _Default : BasePage
{
    void Page_Load(object sender, EventArgs e)
    {
        //int i = 0;
        //Response.Write(i.ToString());
        Label lbClickCount = (Label)((MasterPage)Master).FindControl("lbClickCount");
        lbClickCount.Text = this.GetClickCount("-1");
        if (!IsPostBack)
        {
            CustomList<NewsInfo> cList = new News().GetListByMenuID("14", 1, 0) as CustomList<NewsInfo>;
            if (cList.Count == 0)
            {
                return;
            }
            NewsInfo nInfo = cList[0];
            if (nInfo.CreateTime.AddDays(5.0) > DateTime.Now)
            {
                string script = "<script type=\"text/javascript\">openwin();</script>";
                litMsg.Text = script;
            }
        }
    }


}

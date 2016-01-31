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

public partial class Admin_Main : BasePage
{
    /// <summary>
    /// 需要后台登陆
    /// </summary>
    protected override bool IsAdminPage
    {
        get
        {
            return true ;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Name.Text = Server.MachineName;

        ip.Text = Request.UserHostAddress;

        Time.Text = DateTime.Now.ToString();

        Dk.Text = Request.ServerVariables["SERVER_PORT"];

        Os.Text = Environment.OSVersion.ToString().Remove(0, 10);

        Iis.Text = Request.ServerVariables["SERVER_SOFTWARE"];
    }
}

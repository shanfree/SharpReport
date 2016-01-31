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
using System.Diagnostics;
using Shanfree.Portal.Model;
using Shanfree.Framework.Utility;

public partial class Admin_Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (DateTime.Today > Convert.ToDateTime("2009-12-10 0:00:01"))
            //{
            //    ShowMsg("软件试用期即将过期，请联系作者。");
            //}

        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string code = tbCode.Text;
            string tarCode = Session["Code"].ToString();
            if (!string.Equals(code, tarCode))
            {
                ShowMsg("验证码错误。");
                return;
            }
            string name = tbName.Text;
            string pwd = tbPwd.Text;

            bool login = this.Login(name, pwd);
            if (login == false)
            {
                ShowMsg("您输入的账号和密码不匹配。大写锁定是否开启？");
            }
            else
            {
                Response.Redirect("admin/Main.aspx", false);
            }
        }
        catch (ArgumentNullException aEx)
        {
            ShowMsg(aEx.Message);
            return;
        }
        catch (Exception ex)
        {
            ShowMsg(ex.Message);
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }
}

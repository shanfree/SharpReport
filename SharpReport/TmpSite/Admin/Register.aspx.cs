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

public partial class Admin_Register : BasePage
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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string name = tbName.Text;
        string pwd = tbPws.Text;
        string cpwd = tbComfirm.Text;
        if (string.Equals(pwd,cpwd) == false)
        {
            ShowMsg("两次密码输入不一致。");
            return;
        }
        new AdminUser().Add(name, pwd);
        ShowMsg("用户" + name + "已创建。");
    }
}

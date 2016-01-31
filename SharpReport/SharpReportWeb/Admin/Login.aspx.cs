using System;
using SIRC.Framework.SharpMemberShip;
using BLL = SIRC.Framework.SharpMemberShip.BLL;

namespace SharpReportWeb.Admin
{
    public partial class Login : WebBasePage
    {
        public override string MenuID
        {
            get
            {
                return DEFAULT_MENUID;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = userName.Text;
                string pwd = password.Text;
                string guid = new BLL.User().Login(user, pwd);
                if (string.IsNullOrEmpty(guid))
                {
                    ShowMsg("用户名或密码不正确。");
                }
                else
                {
                    string url = string.Format("../MainFrame/Default.aspx?guid={0}", guid);
                    Response.Redirect(url, true);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }

        }
    }
}

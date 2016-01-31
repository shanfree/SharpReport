using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SIRC.Framework.SharpMemberShip;

namespace SharpReportWeb.Admin
{
    public partial class Main : WebBasePage
    {
        /// <summary>
        /// 该页面登录后访问
        /// </summary>
        public override bool CanRediect
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 栏目ID,用于权限验证
        /// </summary>
        public override string MenuID
        {
            get
            {
                // TODO:测试时不进行权限验证
                return DEFAULT_MENUID; 
                // 正式的代码
                //return "15";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Name.Text = Server.MachineName;
                ip.Text = Request.UserHostAddress;
                Time.Text = DateTime.Now.ToString();
                Dk.Text = Request.ServerVariables["SERVER_PORT"];
                Os.Text = Environment.OSVersion.ToString().Remove(0, 10);
                Iis.Text = Request.ServerVariables["SERVER_SOFTWARE"];
            }
        }
    }
}

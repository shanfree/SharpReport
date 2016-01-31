using System;
using System.Web.UI.WebControls;
using System.Configuration;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.Model;
using BLL = SIRC.Framework.SharpMemberShip.BLL;

namespace SharpReportWeb.MasterPage
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected string HOME_PAGE
        {
            get
            {
                return ConfigurationManager.AppSettings["HostName"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string guid = Request.QueryString["guid"];
                if (string.IsNullOrEmpty(guid) == false)
                {
                    //UserInfo uInfo = new BLL.User().GetUserInfoByGuid(guid);
                    //TreeNodeInfo<MenuInfo> tree = new BLL.Menu().GetTreeByUserID(uInfo.ID);
                    //mMain.Items.Clear();
                    //BindTree(tree, mMain);
                }
            }
        }
    }
}

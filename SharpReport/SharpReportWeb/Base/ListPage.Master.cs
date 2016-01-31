using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharpReportWeb.Base
{
    public partial class ListPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //费用类别
        protected void LB_CostCategoryInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/CostCategory.aspx");
        }

        protected void LB_OilTypeInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/OilType.aspx");
        }

        protected void LB_ShipInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/Ship.aspx");
        }

        protected void LB_PartsInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/Parts.aspx");
        }

        protected void LB_RelShipParts_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/RelShipParts.aspx");
        }

        protected void LB_PortInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/Port.aspx");
        }

        protected void LB_PortTypeInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/PortType.aspx");
        }

        protected void LB_RouteInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/Route.aspx");
        }

        protected void LB_VoyageInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/Voyage.aspx");
        }

        protected void LB_RelRoutePort_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DicMgmt/RelRoutePort.aspx");
        }
    }
}

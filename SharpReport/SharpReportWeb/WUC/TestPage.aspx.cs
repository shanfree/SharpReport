using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using System;

namespace SharpReportWeb.WUC
{
    public partial class TestPage : WebBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MonthAndShipNavigate1.OnSelectedChanged += new EventHandler(MonthAndShipNavigate1_OnSelectedChanged);

        }
        #region 月份和船舶选择
        protected void MonthAndShipNavigate1_OnSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                string year = MonthAndShipNavigate1.Year;
                string month = MonthAndShipNavigate1.Month;
                string shipID = MonthAndShipNavigate1.ShipID;
                string msg = string.Format("year:{0},month{1},shipID:{2}", year, month, shipID);
                Response.Write(msg);
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                Log(ex);
            }
        }
        #endregion

    }
}

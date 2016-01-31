using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;

namespace SharpReportWeb.Hangy
{
    public partial class VoyageLoadStatistic : WebBasePage
    {
        #region 权限验证
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
                return DEFAULT_MENUID; ;
                // 正式的代码
                //return "15";
            }
        }
        #endregion

        #region 属性

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("船舶装箱情况汇总", "用户可以查看船舶装箱情况，并按年份和月份形成报表。");
                    BindDDL();
                    ShowResult();
                }
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

        private void BindDDL()
        {
            try
            {
                IList<RouteInfo> dRouteList = new Route().GetList();
                ddlRouteName.DataSource = dRouteList;
                ddlRouteName.DataBind();

                IList<ShipInfo> dShipList = new Ship().GetList();
                ddlShipName.DataSource = dShipList;
                ddlShipName.DataBind();
                ddlShipName.Items.Insert(0, new ListItem("全部", ""));

                //tbStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //tbEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

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

        #region 生成excel
        public override void VerifyRenderingInServerForm(Control control)
        {
        }


        protected void eQuery_Click(object sender, EventArgs e)
        {

        }

        protected void eStatistic_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 切换报表
        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ShowResult();
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

        private void ShowResult()
        {
            trQuery.Visible = true;
            trStatistic.Visible = true;
            string fromDate = tbStartTime.Text;
            string toDate = tbEndTime.Text;
            string shipID = ddlShipName.SelectedValue;
            string voyage = tbVoyageName.Text;
            string type = rblType.SelectedValue;
            if (type == "0")
            {
                DataSet ds = new VoyageOther().GetDataSetByQuery(fromDate, toDate, shipID, voyage, 15, 0);
                gvVoyageList.DataSource = ds;
                gvVoyageList.DataBind();
                trStatistic.Visible = false;
            }
            else if (type == "1")
            {
                DataSet ds = new VoyageOther().GetDataSetByStatistic(fromDate, toDate, shipID, 12, 0);
                gvStatistic.DataSource = ds;
                gvStatistic.DataBind();
                trQuery.Visible = false;
            }
        }
        #endregion

        #region 编辑航线
        protected void btnRoute_Click(object sender, EventArgs e)
        {
            try
            {
                string url = @"../Hangy/Route.aspx";
                Response.Redirect(url, false);
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

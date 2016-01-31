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
    public partial class VoyageInput : WebBasePage
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
        public string VoyageId
        {
            get
            {
                return GetViewState("VoyageId");
            }
            set
            {
                ViewState["VoyageId"] = value;

            }
        }
        #endregion

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("船舶装箱情况", "维护航次信息，可以同时编辑船只载货情况。载货情况根据船只的“装箱类型”填写：“集装箱”船填写箱量相关信息，“散货”船填写散货载货量信息。");
                    BindDDL();

                    #region 航次
                    string voyageId = GetRequest("voyageId");
                    VoyageInfo vInfo = new VoyageInfo();
                    if (string.IsNullOrEmpty(voyageId) == false)
                    {
                        this.VoyageId = voyageId;
                        vInfo = new Voyage().GetByID(this.VoyageId);
                        tbVoyageName.Text = vInfo.Name;
                        ddlRouteName.SelectedValue = vInfo.RouteID.ToString();
                        ddlManagerType.SelectedValue = vInfo.ManagerTypeID;
                        RouteInfo rInfo = new Route().GetByID(vInfo.RouteID.ToString());
                        lbRoute.Text = rInfo.TotalRoute;


                        string stime = vInfo.BeginDate.Date.ToString("yyyy-MM-dd");
                        if (stime.Equals("1900-01-01"))
                        {
                            tbStartTime.Text = "";
                            ddlStartHour.SelectedValue = "0";
                            ddlStartMin.SelectedValue = "0";
                        }
                        else
                        {
                            tbStartTime.Text = stime;
                            ddlStartHour.SelectedValue = vInfo.BeginDate.Hour.ToString();
                            ddlStartMin.SelectedValue = vInfo.BeginDate.Minute.ToString();
                        }
                        string etime = vInfo.EndDate.Date.ToString("yyyy-MM-dd");
                        if (etime.Equals("1900-01-01"))
                        {
                            tbEndTime.Text = "";
                            ddlEndHour.SelectedValue = "0";
                            ddlEndMin.SelectedValue = "0";
                        }
                        else
                        {
                            tbEndTime.Text = etime;
                            ddlEndHour.SelectedValue = vInfo.EndDate.Hour.ToString();
                            ddlEndMin.SelectedValue = vInfo.EndDate.Minute.ToString();
                        }
                        ddlShipName.SelectedValue = vInfo.ShipID.ToString();
                        tbOrder.Text = vInfo.OrderNum.ToString();
                        ShipTypeInitial();
                    }

                    #endregion

                    // 装箱情况
                    VoyageLoadInitial(vInfo);
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

        private void VoyageLoadInitial(VoyageInfo vInfo)
        {
            ShipInfo sInfo = new Ship().GetByID(vInfo.ShipID.ToString());
            switch (sInfo.LoadTypeEnum)
            {
                case ShipType.FCL:
                    #region 集装箱
                    divFCL.Visible = true;
                    VoyageLoadInfo vfInfo = new VoyageLoad().GetByVoyageID(this.VoyageId);
                    if (vfInfo != null && string.IsNullOrEmpty(vfInfo.ID) == false)
                    {
                        tbTEUEmpty.Text = vfInfo.TEUEmpty;
                        tbTEUHeavy.Text = vfInfo.TEUHeavy;
                        tbTEUFROST.Text = vfInfo.TEUFrost;

                        tbFEUEmpty.Text = vfInfo.FEUEmpty;
                        tbFEUHeavy.Text = vfInfo.FEUHeavy;
                        tbFEUFROST.Text = vfInfo.FEUFrost;
                        tbFEUDANG.Text = vfInfo.FEUDanger;

                        tbFFEUEmpty.Text = vfInfo.FFEUEmpty;
                        tbFFEUHeavy.Text = vfInfo.FFEUHeavy;
                        tbFFEUFROST.Text = vfInfo.FFEUFrost;
                        tbFFEUDANG.Text = vfInfo.FFEUDanger;

                        tbRest.Text = vfInfo.Rest;
                        tbEqualTo.Text = vfInfo.EqualTo;
                        tbTotalNatu.Text = vfInfo.TotalNat;
                        tbTotalStand.Text = vfInfo.TotalStand;
                    }
                    #endregion
                    break;
                default:
                    break;
            }

        }

        private void BindDDL()
        {
            IList<RouteInfo> dRouteList = new Route().GetList();
            ddlRouteName.DataSource = dRouteList;
            ddlRouteName.DataBind();

            IList<ManagerTypeInfo> mtList = new ManagerType().GetList();
            ddlManagerType.DataSource = mtList;
            ddlManagerType.DataBind();


            IList<ShipInfo> dShipList = new Ship().GetList();
            ddlShipName.DataSource = dShipList;
            ddlShipName.DataBind();
            ShipTypeInitial();

            tbStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            // 绑定小时和分钟
            for (int i = 0; i < 24; i++)
            {
                ddlStartHour.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlEndHour.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            for (int j = 0; j < 60; j++)
            {
                ddlStartMin.Items.Add(new ListItem(j.ToString(), j.ToString()));
                ddlEndMin.Items.Add(new ListItem(j.ToString(), j.ToString()));
            }
            ddlStartHour.SelectedIndex = 0;
            ddlEndHour.SelectedIndex = 0;
            ddlStartMin.SelectedIndex = 0;
            ddlEndMin.SelectedIndex = 0;
        }

        protected void ddlShipName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VoyageInfo vInfo = new VoyageInfo();
                string voyageId = this.VoyageId;
                if (string.IsNullOrEmpty(voyageId) == false)
                {
                    vInfo = new Voyage().GetByID(voyageId);
                    VoyageLoadInitial(vInfo);
                }

                ShipTypeInitial();

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

        private void ShipTypeInitial()
        {
            ShipInfo sInfo = new Ship().GetByID(ddlShipName.SelectedValue);

            divFCL.Visible = false;
            switch (sInfo.LoadTypeEnum)
            {
                case ShipType.FCL:
                    divFCL.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 航次情况
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = @"../Hangy/Hangci.aspx";
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

        #region 航次操作
        /// <summary>
        /// 新增航次前 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddVoyage_Click(object sender, EventArgs e)
        {
            try
            {
                ddlRouteName.SelectedIndex = 0;
                tbStartTime.Text = "";
                tbEndTime.Text = "";
                ddlShipName.SelectedIndex = 0;
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

        protected void btnSaveVoyage_Click(object sender, EventArgs e)
        {
            try
            {
                VoyageInfo vi = new VoyageInfo();
                if (string.IsNullOrEmpty(this.VoyageId) == false)
                {
                    vi = new Voyage().GetByID(this.VoyageId);
                }

                vi.Name = tbVoyageName.Text;
                vi.ShipID = Convert.ToInt32(ddlShipName.SelectedValue);
                vi.RouteID = Convert.ToInt32(ddlRouteName.SelectedValue);
                vi.OrderNum = Convert.ToInt32(tbOrder.Text);
                vi.ManagerTypeID = ddlManagerType.SelectedValue;

                string stime = tbStartTime.Text;
                string sHour = ddlStartHour.SelectedValue;
                string sMin = ddlStartMin.SelectedValue;
                string etime = tbEndTime.Text;
                string eHour = ddlEndHour.SelectedValue;
                string eMin = ddlEndMin.SelectedValue;

                if (!stime.Equals(""))
                {
                    string beginDate = string.Format("{0} {1}:{2}", stime, sHour, sMin);
                    vi.BeginDate = DateTime.Parse(beginDate);
                }
                else
                {
                    vi.BeginDate = Convert.ToDateTime("1900-01-01");
                }

                if (!etime.Equals(""))
                {
                    string endDate = string.Format("{0} {1}:{2}", etime, eHour, eMin);
                    vi.EndDate = DateTime.Parse(endDate);
                }
                else
                {
                    vi.EndDate = Convert.ToDateTime("1900-01-01");
                }


                if (string.IsNullOrEmpty(this.VoyageId))
                {
                    this.VoyageId = new Voyage().Add(vi);
                }
                else
                {
                    new Voyage().Update(vi);
                }
                ShowMsg("航次保存成功！");
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
        #endregion

        #endregion

        #region 币种选择
        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

        #region 显示航次信息
        protected void ddlRouteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string routeID = ddlRouteName.SelectedValue;
                RouteInfo rInfo = new Route().GetByID(routeID);
                lbRoute.Text = rInfo.TotalRoute;
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

        #region 散货保存
        protected void btnLCLDel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 集装箱保存
        /// <summary>
        /// 增改船舶装箱情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.VoyageId))
                {
                    ShowMsg("请先保存航次信息。");
                    return;
                }
                ShipInfo sInfo = new Ship().GetByID(ddlShipName.SelectedValue);
                switch (sInfo.LoadTypeEnum)
                {
                    case ShipType.FCL:
                        //集装箱
                        VoyageLoadInfo vfInfo = new VoyageLoad().GetByVoyageID(this.VoyageId);
                        if (vfInfo == null)
                        {
                            vfInfo = new VoyageLoadInfo();
                        }
                        vfInfo.TEUEmpty = tbTEUEmpty.Text;
                        vfInfo.TEUHeavy = tbTEUHeavy.Text;
                        vfInfo.TEUFrost = tbTEUFROST.Text;

                        vfInfo.FEUEmpty = tbFEUEmpty.Text;
                        vfInfo.FEUHeavy = tbFEUHeavy.Text;
                        vfInfo.FEUFrost = tbFEUFROST.Text;
                        vfInfo.FEUDanger = tbFEUDANG.Text;

                        vfInfo.FFEUEmpty = tbFFEUEmpty.Text;
                        vfInfo.FFEUHeavy = tbFFEUHeavy.Text;
                        vfInfo.FFEUFrost = tbFFEUFROST.Text;
                        vfInfo.FFEUDanger = tbFFEUDANG.Text;

                        vfInfo.Rest = tbRest.Text;
                        vfInfo.EqualTo = tbEqualTo.Text;
                        vfInfo.TotalNat = tbTotalNatu.Text;
                        vfInfo.TotalStand = tbTotalStand.Text;
                        vfInfo.VoyageID = this.VoyageId;

                        if (string.IsNullOrEmpty(vfInfo.ID))
                        {
                            new VoyageLoad().Add(vfInfo);
                        }
                        else
                        {
                            new VoyageLoad().Update(vfInfo);
                        }
                        break;
                    default:
                        break;
                }

                ShowMsg("操作成功！");
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

        #region 增改船舶装箱情况
        protected void btnDel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

    }
}

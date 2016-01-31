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
    public partial class VoyageLoadInput : WebBasePage
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
                        CustomerInitial();
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
                        lbDays.Text = vInfo.LastingDays;
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
            if (GetRequest("type") == "other")
            {
                divOther.Visible = true;
                divFCL.Visible = false;
                divLCL.Visible = false;
            }
            if (vInfo == null || string.IsNullOrEmpty(vInfo.ID))
            {
                return;
            }

            #region 其他收入
            if (GetRequest("type") == "other")
            {

                VoyageOtherInfo voInfo = new VoyageOther().GetByVoyageID(vInfo.ID);
                if (voInfo != null && string.IsNullOrEmpty(voInfo.ID) == false)
                {
                    tbOtherName.Text = voInfo.OtherName;
                    tbRemark.Text = voInfo.Remark;
                    tbOtherFee.Text = voInfo.Amount;
                    ddlCurrencyOther.SelectedValue = voInfo.CurrencyID;
                    tbOtherUser1.Text = voInfo.User1;
                    tbOtherUser2.Text = voInfo.User2;
                    tbOtherUser3.Text = voInfo.User3;
                    lbOtherRMB.Text = new ExchangeRate().GetRMB(voInfo.Amount, voInfo.CurrencyID, voInfo.CreateTime).ToString();
                }
                return;
            }
            #endregion

            IList<PortInfo> pList = new Port().GetList(vInfo.RouteID.ToString(), string.Empty);
            gvList.DataSource = pList;
            gvList.DataBind();
            ShipInfo sInfo = new Ship().GetByID(vInfo.ShipID.ToString());
            switch (sInfo.LoadTypeEnum)
            {
                case ShipType.LCL:
                    #region 散货
                    divLCL.Visible = true;
                    // 散货
                    VoyageLCLInfo vlInfo = new VoyageLCL().GetByVoyageID(vInfo.ID);
                    if (vlInfo != null && string.IsNullOrEmpty(vlInfo.ID) == false)
                    {
                        tbCustomer.Text = vlInfo.Customer;
                        tbTaxNo.Text = vlInfo.TaxNo;
                        tbLCLAmount.Text = vlInfo.LCLAmount;
                        tbLCLAmountReal.Text = vlInfo.LCLAmountReal;
                        tbLCLName.Text = vlInfo.LCLCatalog;
                        tbTransport.Text = vlInfo.LCLPrice;
                        ddlCurrency.SelectedValue = vlInfo.CurrencyID;
                        lbAmount.Text = vlInfo.Fee;

                        tbDelay.Text = vlInfo.DelayDay;
                        tbDelayFee.Text = vlInfo.DelayRate;
                        lbDelayAmount.Text = vlInfo.DelayAmount;
                        lbDelayRMB.Text = new ExchangeRate().GetRMB(vlInfo.DelayAmount, vlInfo.CurrencyID, vlInfo.CreateTime).ToString();

                        tbDispatch.Text = vlInfo.QuickDay;
                        tbDispatchFee.Text = vlInfo.QuickRate;
                        lbDispatchAmount.Text = vlInfo.DispatchAmount;
                        lbDispatchRMB.Text = new ExchangeRate().GetRMB(vlInfo.DispatchAmount, vlInfo.CurrencyID, vlInfo.CreateTime).ToString();

                        lbTotal.Text = new VoyageLCL().GetAmout(vlInfo);
                        lbLCLCName.Text = ddlCurrency.SelectedItem.Text;
                        lbTotalRMB.Text = new VoyageLCL().GetRMBAmout(vlInfo);

                        tbLCLUser1.Text = vlInfo.User1;
                        tbLCLUser2.Text = vlInfo.User2;
                        tbLCLUser3.Text = vlInfo.User3;
                    }
                    #endregion
                    break;
                case ShipType.FCL:
                    #region 集装箱
                    divFCL.Visible = true;
                    VoyageFCLInfo vfInfo = new VoyageFCL().GetByVoyageID(vInfo.ID);
                    if (vfInfo != null && string.IsNullOrEmpty(vfInfo.ID) == false)
                    {
                        tbCustomer.Text = vfInfo.Customer;
                        tbTaxNo.Text = vfInfo.TaxNo;
                        tbFCLFee.Text = vfInfo.Amount;
                        ddlCurrencyFCL.SelectedValue = vfInfo.CurrencyID;

                        tbFCLUser1.Text = vfInfo.User1;
                        tbFCLUser2.Text = vfInfo.User2;
                        tbFCLUser3.Text = vfInfo.User3;

                        tbFCLFee.Text = vfInfo.Fee;
                        tbBeginFee.Text = vfInfo.BeginFee;
                        tbEndFee.Text = vfInfo.EndFee;
                        tbOilFee.Text = vfInfo.OilFee;
                        tbTally.Text = vfInfo.Tally;
                        tbBox.Text = vfInfo.Box;
                        tbOther.Text = vfInfo.Other;
                        tbSubsidize.Text = vfInfo.Subsidize;
                        tbBookFee.Text = vfInfo.BookFee;
                        tbBranchOther.Text = vfInfo.BranchOther;

                        lbFCLTotal.Text = new VoyageFCL().GetAmout(vfInfo.ID);
                        lbFCLTotalRMB.Text = new VoyageFCL().GetRMBAmout(vfInfo.ID);
                        tbFCLRemark.Text = vfInfo.Remark;
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

            IList<CurrencyInfo> cList = new Currency().GetList();
            ddlCurrency.DataSource = cList;
            ddlCurrency.DataBind();

            ddlCurrencyFCL.DataSource = cList;
            ddlCurrencyFCL.DataBind();

            ddlCurrencyOther.DataSource = cList;
            ddlCurrencyOther.DataBind();
        }

        private void ShipTypeInitial()
        {
            ShipInfo sInfo = new Ship().GetByID(ddlShipName.SelectedValue);

            divFCL.Visible = false;
            divLCL.Visible = false;
            if (GetRequest("type") == "other")
            {
                return;
            }
            switch (sInfo.LoadTypeEnum)
            {
                case ShipType.LCL:
                    divLCL.Visible = true;
                    break;
                case ShipType.FCL:
                    divFCL.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 集装箱运行类别选择
        void CustomerInitial()
        {
            string typeID = ddlManagerType.SelectedValue;
            switch (typeID)
            {
                //外贸台湾线,外贸集装箱填写客户提单情况
                case "1":
                case "2":
                    trCustmer.Visible = true;
                    BindCustomerList();
                    break;
                case "4":
                    trBranch.Visible = true;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 客户提单情况
        /// </summary>
        void BindCustomerList()
        {
            VoyageFCLInfo vfInfo = new VoyageFCL().GetByVoyageID(this.VoyageId);
            string fclID = (vfInfo == null) ? string.Empty : vfInfo.ID;
            IList<FCLCustomerInfo> list = new FCLCustomer().GetByFCLIDAddBlank(fclID);
            gvCustomerList.DataSource = list;
            gvCustomerList.DataBind();
        }
        #endregion

        #region 客户信息保存
        protected void gvCustomerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.VoyageId))
                {
                    ShowMsg("请先保存集装箱费用报表再填写客户提货单。");
                    return;
                }
                string id = e.CommandArgument.ToString();
                if (e.CommandName == "btnDel")
                {
                    new FCLCustomer().Delete(id);
                }
                else
                {
                    #region 控件
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    TextBox tbName = (TextBox)gvr.FindControl("tbName");
                    TextBox tbFee = (TextBox)gvr.FindControl("tbFee");
                    TextBox tbgp20 = (TextBox)gvr.FindControl("tbgp20");
                    TextBox tbgp40 = (TextBox)gvr.FindControl("tbgp40");
                    TextBox tbdp20 = (TextBox)gvr.FindControl("tbdp20");
                    TextBox tbdp40 = (TextBox)gvr.FindControl("tbdp40");
                    #endregion

                    FCLCustomerInfo info = new FCLCustomerInfo(id);
                    info.Name = tbName.Text;
                    info.Fee = tbFee.Text;
                    info.gp20 = tbgp20.Text;
                    info.gp40 = tbgp40.Text;
                    info.dp20 = tbdp20.Text;
                    info.dp40 = tbdp40.Text;
                    VoyageFCLInfo vfInfo = new VoyageFCL().GetByVoyageID(this.VoyageId);
                    string fclID = (vfInfo == null) ? string.Empty : vfInfo.ID;
                    info.FCLID = fclID;

                    if (e.CommandName == "btnEdit")
                    {
                        new FCLCustomer().Update(info);
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new FCLCustomer().Add(info);
                    }
                }
                BindCustomerList();
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
                    case ShipType.LCL:
                        VoyageLCLInfo vlInfo = new VoyageLCL().GetByVoyageID(this.VoyageId);
                        if (vlInfo == null)
                        {
                            vlInfo = new VoyageLCLInfo();
                        }
                        vlInfo.VoyageID = this.VoyageId;
                        vlInfo.Customer = tbCustomer.Text;
                        vlInfo.TaxNo = tbTaxNo.Text;
                        vlInfo.User1 = tbLCLUser1.Text;
                        vlInfo.User2 = tbLCLUser2.Text;
                        vlInfo.User3 = tbLCLUser3.Text;

                        vlInfo.LCLAmount = tbLCLAmount.Text;
                        vlInfo.LCLAmountReal = tbLCLAmountReal.Text;
                        vlInfo.LCLCatalog = tbLCLName.Text;
                        vlInfo.LCLPrice = tbTransport.Text;
                        vlInfo.CurrencyID = ddlCurrency.SelectedValue;
                        vlInfo.DelayDay = tbDelay.Text;
                        vlInfo.DelayRate = tbDelayFee.Text;
                        vlInfo.QuickDay = tbDispatch.Text;
                        vlInfo.QuickRate = tbDispatchFee.Text;

                        lbTotal.Text = new VoyageLCL().GetAmout(vlInfo);
                        vlInfo.Amount = lbTotal.Text;
                        lbTotalRMB.Text = new VoyageLCL().GetRMBAmout(vlInfo);
                        lbLCLCName.Text = ddlCurrency.SelectedItem.Text;

                        if (string.IsNullOrEmpty(vlInfo.ID))
                        {
                            new VoyageLCL().Add(vlInfo);
                        }
                        else
                        {
                            new VoyageLCL().Update(vlInfo);
                        }
                        lbDelayAmount.Text = vlInfo.DelayAmount;
                        lbDelayRMB.Text = new ExchangeRate().GetRMB(vlInfo.DelayAmount, vlInfo.CurrencyID, vlInfo.CreateTime).ToString();
                        lbDispatchAmount.Text = vlInfo.DispatchAmount;
                        lbDispatchRMB.Text = new ExchangeRate().GetRMB(vlInfo.DispatchAmount, vlInfo.CurrencyID, vlInfo.CreateTime).ToString();
                        break;
                    case ShipType.FCL:
                        //集装箱
                        VoyageFCLInfo vfInfo = new VoyageFCL().GetByVoyageID(this.VoyageId);
                        if (vfInfo == null)
                        {
                            vfInfo = new VoyageFCLInfo();
                        }
                        vfInfo.VoyageID = this.VoyageId;
                        vfInfo.Customer = tbCustomer.Text;
                        vfInfo.TaxNo = tbTaxNo.Text;
                        vfInfo.Amount = tbFCLFee.Text;

                        vfInfo.User1 = tbFCLUser1.Text;
                        vfInfo.User2 = tbFCLUser2.Text;
                        vfInfo.User3 = tbFCLUser3.Text;

                        vfInfo.Fee = tbFCLFee.Text;
                        vfInfo.BeginFee = tbBeginFee.Text;
                        vfInfo.EndFee = tbEndFee.Text;
                        vfInfo.OilFee = tbOilFee.Text;
                        vfInfo.Tally = tbTally.Text;
                        vfInfo.Box = tbBox.Text;
                        vfInfo.Other = tbOther.Text;
                        vfInfo.Subsidize = tbSubsidize.Text;
                        vfInfo.BookFee = tbBookFee.Text;
                        vfInfo.BranchOther = tbBranchOther.Text;
                        lbFCLTotal.Text = new VoyageFCL().GetAmout(vfInfo);
                        vfInfo.Amount = lbFCLTotal.Text;
                        lbFCLTotalRMB.Text = new VoyageFCL().GetRMBAmout(vfInfo);
                        vfInfo.Remark = tbFCLRemark.Text;

                        if (string.IsNullOrEmpty(vfInfo.ID))
                        {
                            new VoyageFCL().Add(vfInfo);
                        }
                        else
                        {
                            new VoyageFCL().Update(vfInfo);
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

        #region 其他收入情况
        protected void btnOtherSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.VoyageId))
                {
                    ShowMsg("请先保存航次信息。");
                    return;
                }
                ShipInfo sInfo = new Ship().GetByID(ddlShipName.SelectedValue);
                VoyageOtherInfo voInfo = new VoyageOther().GetByVoyageID(this.VoyageId);
                if (voInfo == null)
                {
                    voInfo = new VoyageOtherInfo();
                }
                voInfo.VoyageID = this.VoyageId;
                voInfo.Customer = tbCustomer.Text;
                voInfo.Remark = tbRemark.Text;
                voInfo.User1 = tbOtherUser1.Text;
                voInfo.User2 = tbOtherUser2.Text;
                voInfo.User3 = tbOtherUser3.Text;

                voInfo.Amount = tbOtherFee.Text;
                voInfo.OtherName = tbOtherName.Text;
                voInfo.CurrencyID = ddlCurrencyOther.SelectedValue;
                if (string.IsNullOrEmpty(voInfo.ID))
                {
                    new VoyageOther().Add(voInfo);
                }
                else
                {
                    new VoyageOther().Update(voInfo);
                }
                lbOtherRMB.Text = new ExchangeRate().GetRMB(voInfo.Amount, voInfo.CurrencyID, voInfo.CreateTime).ToString();

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

        #endregion


        #endregion

    }
}

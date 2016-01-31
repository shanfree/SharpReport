using System;
using System.Data;
using System.Web.UI;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;
using System.Collections.Generic;
using SIRCWEB = SIRC.Framework.WebControlLib;
using System.Web.UI.WebControls;

namespace SharpReportWeb.Hangy
{
    public partial class OilFee : WebBasePage
    {
        #region 属性
        /// <summary>
        /// 报表 ID
        /// </summary>
        private string VoyageId
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
        /// <summary>
        /// 船舶 ID
        /// </summary>
        private string ShipID
        {
            get
            {
                return GetViewState("ShipID");
            }
            set
            {
                ViewState["ShipID"] = value;
            }
        }

        /// <summary>
        /// 报表 ID
        /// </summary>
        private string ReportBaseID
        {
            get
            {
                return GetViewState("ReportBaseID");
            }
            set
            {
                ViewState["ReportBaseID"] = value;
            }
        }
        #endregion

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

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("油料添加录入", "油料添加录入必须首先选定航次，然后录入每个加油港的加油数据。");
                    string reportID = GetRequest("id");
                    if (string.IsNullOrEmpty(reportID) == false)
                    {
                        OilFeeReportInfo oInfo = new OilFeeReport().GetByID(reportID);
                        this.VoyageId = VoyageInitial(oInfo.VoyageID);
                    }
                    string voyageIds = GetRequest("voyageIds");
                    if (string.IsNullOrEmpty(voyageIds) == false)
                    {
                        this.VoyageId = VoyageInitial(voyageIds);
                        OilFeeReportInfo oInfo = new OilFeeReport().GetByVoyageID(this.VoyageId);
                        if (oInfo != null)
                        {
                            reportID = oInfo.ID;
                        }
                    }
                    this.ReportBaseID = ReportInitial(reportID);
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
        /// <summary>
        /// 初始化航次信息
        /// </summary>
        /// <param name="voyageID"></param>
        private string VoyageInitial(string voyageIds)
        {
            //根据航次或者船舶绑定数据
            string[] voyageIdArray = voyageIds.Split(',');
            IList<VoyageInfo> vList = new Voyage().GetList(voyageIdArray);
            ddlVoyage.DataSource = vList;
            ddlVoyage.DataBind();

            string voyageID = voyageIdArray[0];
            VoyageInfo vInfo = new Voyage().GetByID(voyageID);
            ddlVoyage.SelectedValue = voyageID;

            string shipID = vInfo.ShipID.ToString();
            ShipInfo sInfo = new Ship().GetByID(shipID);
            lbShip.Text = sInfo.Name;

            string routeID = vInfo.RouteID.ToString();
            RouteInfo rInfo = new Route().GetByID(routeID);
            lbRoute.Text = rInfo.Name;
            lbMile.Text = rInfo.Distance.ToString();

            IList<PortInfo> pList = new Port().GetList(routeID, "2");
            lbBegin.Text = pList[0].Name;
            pList = new Port().GetList(routeID, "4");
            lbEnd.Text = pList[0].Name;

            return voyageID;
        }
        /// <summary>
        /// 初始化报表信息
        /// </summary>
        /// <param name="reportID"></param>
        private string ReportInitial(string reportID)
        {
            OilFeeReportInfo oInfo = new OilFeeReport().GetByID(reportID);
            if (oInfo == null)
            {
                return reportID;
            }

            lbApprover.Text = oInfo.ApproveUserName;
            lbUser.Text = oInfo.InputUserName;
            lbCreateDate.Text = oInfo.CreateTime.ToString("yyyy-MM-dd");
            rblReportType.SelectedValue = oInfo.ReportTypeID;
            IList<OilTypeFeeInfo> list = new OilTypeFee().GetListAddBlank(oInfo.ID);
            rList.DataSource = list;
            rList.DataBind();

            InvoiceList1.KeyID = reportID;
            return oInfo.ID;
        }

        #endregion

        #region 初始化航次数据
        protected void ddlVoyage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string voyageId = ddlVoyage.SelectedValue;
                string baseID = VoyageInitial(voyageId);
                this.ReportBaseID = baseID;
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

        #region 按钮操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OilFeeReportInfo oInfo = new OilFeeReportInfo();
                string reportID = this.ReportBaseID;
                if (string.IsNullOrEmpty(reportID) == false)
                {
                    oInfo = new OilFeeReport().GetByID(reportID);
                }
                oInfo.VoyageID = ddlVoyage.SelectedValue;
                oInfo.ReportTypeID = rblReportType.SelectedValue;
                if (oInfo.ReportTypeID == "3")
                {
                    // 财务确认
                    oInfo.ApproveUserID = this.UserCacheInfo.ID;
                }
                else
                {
                    oInfo.InputUserID = this.UserCacheInfo.ID;
                }
                if (string.IsNullOrEmpty(reportID))
                {
                    this.ReportBaseID = new OilFeeReport().Add(oInfo);
                    ShowMsg("添加成功。");
                }
                else
                {
                    new OilFeeReport().Update(oInfo);
                    ShowMsg("更新成功。");
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

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string reportID = this.ReportBaseID;
                if (string.IsNullOrEmpty(reportID))
                {
                    ShowMsg("报表未保存，无需删除。");
                }
                new OilFeeReport().Delete(reportID);
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
        #endregion

        #region 绑定港口加油量
        protected void rList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //  确保处理的是数据行，而不是Header或者Footer
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    OilTypeFeeInfo mInfo = e.Row.DataItem as OilTypeFeeInfo;
                    DropDownList ddlPort = (DropDownList)e.Row.FindControl("ddlPort");
                    SIRCWEB.Calendar cDate = (SIRCWEB.Calendar)e.Row.FindControl("cDate");
                    DropDownList ddlOilType = (DropDownList)e.Row.FindControl("ddlOilType");
                    TextBox tbAmout = (TextBox)e.Row.FindControl("tbAmout");
                    TextBox tbPrice = (TextBox)e.Row.FindControl("tbPrice");
                    DropDownList ddlCurrency = (DropDownList)e.Row.FindControl("ddlCurrency");
                    Button btnSave = (Button)e.Row.FindControl("btnSave");
                    Button btnDel = (Button)e.Row.FindControl("btnDel");
                    Button btnAdd = (Button)e.Row.FindControl("btnAdd");

                    ddlPort.DataSource = new Port().GetList();
                    ddlPort.DataBind();
                    ddlOilType.DataSource = new OilType().GetList();
                    ddlOilType.DataBind();
                    ddlCurrency.DataSource = new Currency().GetList();
                    ddlCurrency.DataBind();

                    if (mInfo != null && string.IsNullOrEmpty(mInfo.ID) == false)
                    {
                        string id = mInfo.ID;
                        ddlPort.SelectedValue = mInfo.PortID;
                        cDate.Text = mInfo.CreateTime.ToString("yyyy-MM-dd");
                        ddlOilType.SelectedValue = mInfo.OilTypeID;
                        tbAmout.Text = mInfo.Quantity;
                        tbPrice.Text = mInfo.Price;
                        ddlCurrency.SelectedValue = mInfo.CurrencyID;
                        btnSave.Visible = true;
                        btnDel.Visible = true;
                    }
                    else
                    {
                        btnAdd.Visible = true;
                    }
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
        /// <summary>
        /// 加油记录操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string id = e.CommandArgument.ToString();

                if (e.CommandName == "btnDel")
                {
                    new OilTypeFee().Delete(id);
                }
                else
                {
                    OilTypeFeeInfo mInfo = new OilTypeFeeInfo();
                    if (string.IsNullOrEmpty(id) == false)
                    {
                        mInfo = new OilTypeFee().GetByID(id);
                    }
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    DropDownList ddlPort = (DropDownList)gvr.FindControl("ddlPort");
                    SIRCWEB.Calendar cDate = (SIRCWEB.Calendar)gvr.FindControl("cDate");
                    DropDownList ddlOilType = (DropDownList)gvr.FindControl("ddlOilType");
                    TextBox tbAmout = (TextBox)gvr.FindControl("tbAmout");
                    TextBox tbPrice = (TextBox)gvr.FindControl("tbPrice");
                    DropDownList ddlCurrency = (DropDownList)gvr.FindControl("ddlCurrency");

                    mInfo.CreateTime = Convert.ToDateTime(cDate.Text);
                    mInfo.CurrencyID = ddlCurrency.SelectedValue;
                    mInfo.OilTypeID = ddlOilType.SelectedValue;
                    mInfo.PortID = ddlPort.SelectedValue;
                    mInfo.Price = tbPrice.Text;
                    mInfo.Quantity = tbAmout.Text;
                    mInfo.OilFeeReportID = this.ReportBaseID;

                    if (e.CommandName == "btnSave")
                    {
                        new OilTypeFee().Update(mInfo);
                        ShowMsg("更新成功。");
                    }
                    if (e.CommandName == "btnAdd")
                    {
                        new OilTypeFee().Add(mInfo);
                        ShowMsg("添加成功。");
                    }
                }
                IList<OilTypeFeeInfo> list = new OilTypeFee().GetListAddBlank(this.ReportBaseID);
                rList.DataSource = list;
                rList.DataBind();
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

        protected void btnShipView_Click(object sender, EventArgs e)
        {

        }
    }
}

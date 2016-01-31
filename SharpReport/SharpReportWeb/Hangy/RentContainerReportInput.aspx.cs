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
    public partial class RentContainerReporInput : WebBasePage
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
        public string RentContainerReportID
        {
            get
            {
                return GetViewState("RentContainerReportID");
            }
            set
            {
                ViewState["RentContainerReportID"] = value;
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
                    TitleInitial("货柜出租计费表", "维护货柜出租计费表信息，可以编辑柜出租收入情况。");

                    IList<CurrencyInfo> cList = new Currency().GetList();
                    ddlCurrency.DataSource = cList;
                    ddlCurrency.DataBind();
                    // 装箱情况
                    string id = GetRequest("id");
                    if (string.IsNullOrEmpty(id) == false)
                    {
                        this.RentContainerReportID = id;
                        RentContainerReportInitial(id);
                    }
                    else
                    {
                        gvList.DataSource = new RentContainer().GetList(string.Empty);
                        gvList.DataBind();
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void RentContainerReportInitial(string id)
        {
            RentContainerReportInfo rInfo = new RentContainerReport().GetByID(id);
            if (rInfo != null && string.IsNullOrEmpty(rInfo.ID) == false)
            {
                tbUser1.Text = rInfo.User1;
                tbUser2.Text = rInfo.User2;
                tbUser3.Text = rInfo.User3;
                tbCustomer.Text = rInfo.Customer;
                tbTaxNo.Text = rInfo.TaxNo;
                tbStartTime.Text = rInfo.BeginDate.ToShortDateString();
                tbEndTime.Text = rInfo.EndDate.ToShortDateString();
                ddlCurrency.SelectedValue = rInfo.CurrencyID;
                tbRentDay.Text = rInfo.RentDays;
                tbRemark.Text = rInfo.Remark;

                lbTotal.Text = new RentContainerReport().GetAmout(rInfo.ID);
                lbCName.Text = rInfo.CurrencyName;
                lbTotalRMB.Text = new ExchangeRate().GetRMB(lbTotal.Text, rInfo.CurrencyID, rInfo.CreateTime).ToString();

                gvList.DataSource = new RentContainer().GetList(rInfo.ID);
                gvList.DataBind();
            }
        }


        #endregion

        #region 列表操作

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.RentContainerReportID))
                {
                    ShowMsg("货柜租金报表未保存，无法为特定箱种的租金进行编辑。");
                    return;
                }
                string id = e.CommandArgument.ToString();
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                if (e.CommandName == "btnDel")
                {
                    new InstalmentOfCompensation().Delete(id);
                }
                else
                {
                    #region 控件
                    DropDownList rblContainerTypeID = (DropDownList)gvr.FindControl("rblContainerTypeID");
                    TextBox tbAmount = (TextBox)gvr.FindControl("tbAmount");
                    TextBox tbPrice = (TextBox)gvr.FindControl("tbPrice");
                    TextBox tbRentFee = (TextBox)gvr.FindControl("tbRentFee");
                    TextBox tbRemark = (TextBox)gvr.FindControl("tbRemark");
                    #endregion

                    RentContainerInfo info = new RentContainerInfo();
                    if (string.IsNullOrEmpty(id) == false)
                    {
                        info = new RentContainer().GetByID(id);
                    }
                    info.ReportID = this.RentContainerReportID;
                    info.ContainerTypeID = rblContainerTypeID.SelectedValue;
                    info.Amount = tbAmount.Text;
                    info.Price = tbPrice.Text;
                    info.RentFee = tbRentFee.Text;
                    info.Remark = tbRemark.Text;
                    if (e.CommandName == "btnEdit")
                    {
                        new RentContainer().Update(info);
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new RentContainer().Add(info);
                    }
                }
                gvList.DataSource = new RentContainer().GetList(this.RentContainerReportID);
                gvList.DataBind();

                RentContainerReportInfo rInfo = new RentContainerReport().GetByID(this.RentContainerReportID);
                lbTotal.Text = new RentContainerReport().GetAmout(rInfo.ID);
                lbCName.Text = rInfo.CurrencyName;
                lbTotalRMB.Text = new ExchangeRate().GetRMB(lbTotal.Text, rInfo.CurrencyID, rInfo.CreateTime).ToString();

                ShowMsg("更新成功！");
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
        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    RentContainerInfo rInfo = e.Row.DataItem as RentContainerInfo;
                    DropDownList rblContainerTypeID = (DropDownList)e.Row.FindControl("rblContainerTypeID");
                    rblContainerTypeID.SelectedValue = rInfo.ContainerTypeID;
                }
            }
            catch (ArgumentException ae)
            {
                this.ShowMsg(ae.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
            }
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RentContainerReportInfo rInfo = new RentContainerReportInfo();
                string id = this.RentContainerReportID;
                if (string.IsNullOrEmpty(id) == false)
                {
                    rInfo = new RentContainerReport().GetByID(id);
                }
                rInfo.User1 = tbUser1.Text;
                rInfo.User2 = tbUser2.Text;
                rInfo.User3 = tbUser3.Text;
                rInfo.Customer = tbCustomer.Text;
                rInfo.TaxNo = tbTaxNo.Text;
                rInfo.BeginDate = Convert.ToDateTime(tbStartTime.Text);
                rInfo.EndDate = Convert.ToDateTime(tbEndTime.Text);
                rInfo.CurrencyID = ddlCurrency.SelectedValue;
                rInfo.RentDays = tbRentDay.Text;
                rInfo.Remark = tbRemark.Text;

                if (string.IsNullOrEmpty(id) == false)
                {
                    new RentContainerReport().Update(rInfo);
                }
                else
                {
                    this.RentContainerReportID = new RentContainerReport().Add(rInfo);
                }
                lbTotal.Text = new RentContainerReport().GetAmout(rInfo.ID);
                lbCName.Text = ddlCurrency.SelectedItem.Text;
                lbTotalRMB.Text = new ExchangeRate().GetRMB(lbTotal.Text, rInfo.CurrencyID, rInfo.CreateTime).ToString();
                ShowMsg("保存成功。");
            }
            catch (ArgumentException ae)
            {
                this.ShowMsg(ae.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("RentContainerReportList.aspx", false);
            }
            catch (ArgumentException ae)
            {
                this.ShowMsg(ae.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
            }
        }


    }
}

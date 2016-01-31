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
    public partial class RentShipReportInput : WebBasePage
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
        public string RentShipReportID
        {
            get
            {
                return GetViewState("RentShipReportID");
            }
            set
            {
                ViewState["RentShipReportID"] = value;
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
                    TitleInitial("船舶出租租金计费表", "维护船舶出租租金计费表信息，可以同时编辑船只出租收入情况。");
                    BindDDL();
                    string id = GetRequest("id");
                    if (string.IsNullOrEmpty(id) == false)
                    {
                        this.RentShipReportID = id;
                        RentShipReportInitial(id);
                    }
                    else
                    {
                        string shipID = GetRequest("shipID");
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

        private void RentShipReportInitial(string id)
        {
            RentShipReportInfo rInfo = new RentShipReport().GetByID(id);
            if (rInfo != null && string.IsNullOrEmpty(rInfo.ID) == false)
            {
                tbUser1.Text = rInfo.User1;
                tbUser2.Text = rInfo.User2;
                tbUser3.Text = rInfo.User3;
                ddlShipName.SelectedValue = rInfo.ShipID;
                ddlRentType.SelectedValue = rInfo.RentTypeID;
                tbCustomer.Text = rInfo.Customer;
                tbTaxNo.Text = rInfo.TaxNo;
                tbStartTime.Text = rInfo.BeginDate.ToShortDateString();
                tbEndTime.Text = rInfo.EndDate.ToShortDateString();
                lbDays.Text = (rInfo.EndDate - rInfo.BeginDate).Days.ToString();
                tbDiscountDays.Text = rInfo.DiscountDays;
                tbRealDays.Text = rInfo.RealDays;
                ddlCurrency.SelectedValue = rInfo.CurrencyID;
                tbPrice.Text = rInfo.Price;
                tbRentFee.Text = rInfo.RentFee;
                tbCommunicateFee.Text = rInfo.CommunicateFee;
                tbLockFee.Text = rInfo.LockFee;
                tbOtherFee.Text = rInfo.OtherFee;
                tbRemark.Text = rInfo.Remark;

                lbTotal.Text = new RentShipReport().GetAmout(rInfo);
                lbCName.Text = rInfo.CurrencyName;
                lbTotalRMB.Text = new ExchangeRate().GetRMB(lbTotal.Text, rInfo.CurrencyID, rInfo.CreateTime).ToString();
            }
        }

        private void BindDDL()
        {
            IList<ShipInfo> dShipList = new Ship().GetList();
            ddlShipName.DataSource = dShipList;
            ddlShipName.DataBind();


            IList<CurrencyInfo> cList = new Currency().GetList();
            ddlCurrency.DataSource = cList;
            ddlCurrency.DataBind();
        }

        protected void ddlShipName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string shipID = ddlShipName.SelectedValue;
                //RentShipReportInitial(shipID);
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

        #region 操作
        protected void btnSaveVoyage_Click(object sender, EventArgs e)
        {
            try
            {
                RentShipReportInfo rInfo = new RentShipReportInfo();
                if (string.IsNullOrEmpty(this.RentShipReportID) == false)
                {
                    rInfo = new RentShipReport().GetByID(this.RentShipReportID);
                }
                rInfo.User1 = tbUser1.Text;
                rInfo.User2 = tbUser2.Text;
                rInfo.User3 = tbUser3.Text;
                rInfo.ShipID = ddlShipName.SelectedValue;
                rInfo.RentTypeID = ddlRentType.SelectedValue;
                rInfo.Customer = tbCustomer.Text;
                rInfo.Customer = tbCustomer.Text;
                rInfo.TaxNo = tbTaxNo.Text;
                rInfo.BeginDate = Convert.ToDateTime(tbStartTime.Text);
                rInfo.EndDate = Convert.ToDateTime(tbEndTime.Text);
                rInfo.DiscountDays = tbDiscountDays.Text;
                rInfo.RealDays = tbRealDays.Text;
                rInfo.CurrencyID = ddlCurrency.SelectedValue;
                rInfo.Price = tbPrice.Text;
                rInfo.CommunicateFee = tbCommunicateFee.Text;
                rInfo.LockFee = tbLockFee.Text;
                rInfo.OtherFee = tbOtherFee.Text;
                rInfo.RentFee = tbRentFee.Text;
                rInfo.Remark = tbRemark.Text;
                if (string.IsNullOrEmpty(this.RentShipReportID))
                {
                    this.RentShipReportID = new RentShipReport().Add(rInfo);
                }
                else
                {
                    new RentShipReport().Update(rInfo);
                }
                RentShipReportInitial(this.RentShipReportID);
                ShowMsg("保存成功。");
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
                Response.Redirect("RentShipReportList.aspx", false);
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

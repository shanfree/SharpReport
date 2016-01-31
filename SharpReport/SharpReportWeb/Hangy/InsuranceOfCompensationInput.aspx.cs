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
using WebControlLib = SIRC.Framework.WebControlLib;

namespace SharpReportWeb.Hangy
{
    public partial class InsuranceOfCompensationInput : WebBasePage
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
        /// <summary>
        /// ID
        /// </summary>
        private string ID
        {
            get
            {
                return GetViewState("ID");
            }
            set
            {
                ViewState["ID"] = value;
                InvoiceList1.KeyID = this.ID;
                InvoiceList1.MenuID = this.MenuID;
            }
        }
        /// <summary>
        /// ID
        /// </summary>
        private string DimID
        {
            get
            {
                return GetViewState("DimID");
            }
            set
            {
                ViewState["DimID"] = value;
            }
        }
        /// <summary>
        /// 汇率主键
        /// </summary>
        private string RateID
        {
            get
            {
                return GetViewState("RateID");
            }
            set
            {
                ViewState["RateID"] = value;
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
                    TitleInitial("船舶保赔险", "用户可以维护船舶保赔险相关信息。");
                    this.DimID = GetRequest("dimID");
                    string shipID = string.Empty;
                    BindShip(shipID);
                    BindCurrency();
                    this.ID = GetRequest("ID");
                    InsuranceOfCompensationInfo wInfo = new InsuranceOfCompensationInfo();
                    if (string.IsNullOrEmpty(this.ID) == false)
                    {
                        wInfo = new InsuranceOfCompensation().GetByID(this.ID);
                    }
                    SetPageValue(wInfo);
                    BindRate();
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

        #region 船名
        private void BindShip(string shipID)
        {
            IList<ShipInfo> sList = new Ship().GetList();
            ddlShip.DataSource = sList;
            ddlShip.DataBind();
            if (string.IsNullOrEmpty(shipID) == false)
            {
                ddlShip.SelectedValue = shipID;
            }
            else
            {
                shipID = ddlShip.Items[0].Value;
            }
        }
        #endregion

        #region 币种和汇率
        private void BindCurrency()
        {
            IList<CurrencyInfo> cList = new Currency().GetList();
            ddlCurrency.DataSource = cList;
            ddlCurrency.DataBind();
            ddlCurrency.SelectedIndex = 0;
        }
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindRate();
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
        /// 绑定汇率
        /// </summary>
        private void BindRate()
        {
            string year = ddlYear.SelectedValue;
            string month = ddlMonth.SelectedValue;
            string dimID = new DimTime().GetIDByMonth(year, month);
            string currencyID = ddlCurrency.SelectedValue;
            ExchangeRateInfo eInfo = new ExchangeRate().GetInfo(currencyID, dimID);
            lbRate.Text = eInfo.Rate;
            this.RateID = eInfo.ID;
        }
        #endregion

        #endregion

        #region 设置页面值
        /// <summary>
        /// 根据页面实体设置页面值
        /// </summary>
        /// <param name="wInfo"></param>
        private void SetPageValue(InsuranceOfCompensationInfo wInfo)
        {
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();
            tbYear.Text = wInfo.CreateTime.Year.ToString();
            tbMonth.Text = wInfo.CreateTime.Month.ToString();
            if (string.IsNullOrEmpty(wInfo.ID))
            {
                return;
            }

            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(wInfo.DimTimeID);
            tbMonth.Text = dInfo.MonthNumOfYear.ToString();
            tbYear.Text = dInfo.Year.ToString();

            ddlShip.SelectedValue = wInfo.ShipID.ToString();
            ddlCurrency.SelectedValue = wInfo.CurrencyID;
            ddlYear.SelectedValue = dInfo.Year.ToString();
            ddlMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();

            //船舶险
            cBeginDate.Text = wInfo.BeginDate;
            cEndDate.Text = wInfo.EndDate;
            tb主险保额.Text = wInfo.主险保额;
            tb船舶险保单号.Text = wInfo.船舶险保单号;
            tb主险费率.Text = wInfo.主险费率;
            tb主险保费.Text = wInfo.主险保费;
            tb战争保赔险费率.Text = wInfo.战争保赔险费率;
            tb战争保赔险保费.Text = wInfo.战争保赔险保费;
            tb免赔额.Text = wInfo.免赔额;
            tb船舶险总保费.Text = wInfo.船舶险总保费;
            BindList(this.ID, ReportCatalog.InsuranceOfShip);

            //保赔险
            c保险期限自.Text = wInfo.保险期限自.ToString("yyyy-MM-dd");
            c保险期限到.Text = wInfo.保险期限到.ToString("yyyy-MM-dd");
            tb保赔险保单号.Text = wInfo.保赔险保单号;
            tb保赔险费率.Text = wInfo.保赔险费率;
            tb保赔险保费.Text = wInfo.保赔险保费;
            BindList(this.ID, ReportCatalog.InsuranceOfCompensation);
            tb备注.Text = wInfo.备注;
        }
        #endregion

        #region 列表操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void BindList(string id, ReportCatalog catalogEnum)
        {
            string catalog = EnumHandler<ReportCatalog>.GetStringFromEnum(catalogEnum);
            IList<InstalmentOfCompensationInfo> cList = new InstalmentOfCompensation().GetList(id, catalog);
            InstalmentOfCompensationInfo cInfo = new InstalmentOfCompensationInfo();
            cList.Add(cInfo);
            if (catalogEnum == ReportCatalog.InsuranceOfShip)
            {
                gvShipList.DataSource = cList;
                gvShipList.DataBind();
            }
            else if (catalogEnum == ReportCatalog.InsuranceOfCompensation)
            {
                gvCompensationList.DataSource = cList;
                gvCompensationList.DataBind();
            }
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlListCurrency = (DropDownList)e.Row.FindControl("ddlListCurrency");
                InstalmentOfCompensationInfo cInfo = e.Row.DataItem as InstalmentOfCompensationInfo;
                ddlListCurrency.DataSource = new Currency().GetList();
                ddlListCurrency.DataBind();
                if (cInfo != null && string.IsNullOrEmpty(cInfo.CurrencyID) == false)
                {
                    ddlListCurrency.SelectedValue = cInfo.CurrencyID;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridView gvList = sender as GridView;
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvr = (GridViewRow)gvList.Rows[index];
                HiddenField hfRelateId = (HiddenField)gvr.FindControl("hidRelateId");
                string relateId = hfRelateId.Value.ToString();
                ReportCatalog catalog = ReportCatalog.InsuranceOfShip;
                if (gvList.ID == "gvCompensationList")
                {
                    catalog = ReportCatalog.InsuranceOfCompensation;
                }
                if (e.CommandName == "btnDel")
                {
                    new InstalmentOfCompensation().Delete(relateId);
                }
                else
                {
                    #region 控件
                    DropDownList ddlListCurrency = (DropDownList)gvr.FindControl("ddlListCurrency");
                    TextBox tb支付金额 = (TextBox)gvr.FindControl("tb支付金额");
                    WebControlLib.Calendar c支付日期 = (WebControlLib.Calendar)gvr.FindControl("c支付日期");
                    TextBox tb备注 = (TextBox)gvr.FindControl("tb备注");
                    #endregion

                    InstalmentOfCompensationInfo info = new InstalmentOfCompensationInfo();
                    info.Amount = tb支付金额.Text;
                    info.Remark = tb备注.Text;
                    info.CompensationID = this.ID;
                    info.CurrencyID = ddlListCurrency.SelectedValue; ;
                    info.ReportType = EnumHandler<ReportCatalog>.GetStringFromEnum(catalog);
                    info.PayDate = DateTime.Parse(c支付日期.Text);
                    if (e.CommandName == "btnEdit")
                    {
                        new InstalmentOfCompensation().Update(info);
                        ShowMsg("更新成功！");
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new InstalmentOfCompensation().Add(info);
                    }
                }
                BindList(this.ID, catalog);
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

        #region 控件操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.ID;
                InsuranceOfCompensationInfo wInfo = new InsuranceOfCompensationInfo();
                if (string.IsNullOrEmpty(id) == false)
                {
                    wInfo = new InsuranceOfCompensation().GetByID(id);
                }

                wInfo.InputUserID = this.UserCacheInfo.ID;
                string year = tbYear.Text;
                string month = tbMonth.Text;
                string dimTimeID = new DimTime().GetIDByMonth(year, month);
                wInfo.DimTimeID = dimTimeID;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;
                wInfo.ExchangeRateID = this.RateID;
                wInfo.ShipID = ddlShip.SelectedValue;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;

                //船舶险
                wInfo.BeginDate = cBeginDate.Text;
                wInfo.EndDate = cEndDate.Text;
                wInfo.主险保额 = tb主险保额.Text;
                wInfo.船舶险保单号 = tb船舶险保单号.Text;
                wInfo.主险费率 = tb主险费率.Text;
                wInfo.主险保费 = tb主险保费.Text;
                wInfo.战争保赔险费率 = tb战争保赔险费率.Text;
                wInfo.战争保赔险保费 = tb战争保赔险保费.Text;
                wInfo.免赔额 = tb免赔额.Text;
                wInfo.船舶险总保费 = tb船舶险总保费.Text;

                //保赔险
                wInfo.保险期限自 = DateTime.Parse(c保险期限自.Text);
                wInfo.保险期限到 = DateTime.Parse(c保险期限到.Text);
                wInfo.保赔险保单号 = tb保赔险保单号.Text;
                wInfo.保赔险费率 = tb保赔险费率.Text;
                wInfo.保赔险保费 = tb保赔险保费.Text;
                wInfo.备注 = tb备注.Text;

                if (string.IsNullOrEmpty(id) == true)
                {
                    this.ID = new InsuranceOfCompensation().Add(wInfo);
                    wInfo.ID = this.ID;
                    SetPageValue(wInfo);
                }
                else
                {
                    new InsuranceOfCompensation().Update(wInfo);
                }
                ShowMsg("报表保存成功。");
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
                string id = this.ID;
                if (string.IsNullOrEmpty(id) == true)
                {
                    ShowMsg("未选定任何报表。");
                    return;
                }
                new InsuranceOfCompensation().Delete(id);
                ShowMsg("报表删除成功。");
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

        #region 返回统计页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "InsuranceOfCompensationList.aspx";
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

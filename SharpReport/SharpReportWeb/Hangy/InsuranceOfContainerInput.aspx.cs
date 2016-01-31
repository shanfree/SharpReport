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
    public partial class InsuranceOfContainerInput : WebBasePage
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
                InvoiceList1.KeyID = this.ID;
                InvoiceList1.MenuID = this.MenuID;
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
                    TitleInitial("集装箱箱体保险", "用户可以维护集装箱箱体保险相关信息。");
                    this.DimID = GetRequest("dimID");
                    BindCurrency();
                    this.ID = GetRequest("ID");
                    InsuranceOfContainerInfo wInfo = new InsuranceOfContainerInfo();
                    if (string.IsNullOrEmpty(this.ID) == false)
                    {
                        wInfo = new InsuranceOfContainer().GetByID(this.ID);
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
        private void SetPageValue(InsuranceOfContainerInfo wInfo)
        {
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();
            tbYear.Text = wInfo.CreateTime.Year.ToString();
            if (string.IsNullOrEmpty(wInfo.ID))
            {
                return;
            }
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(wInfo.DimTimeID);
            tbYear.Text = dInfo.Year.ToString();
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();

            ddlCurrency.SelectedValue = wInfo.CurrencyID;
            ddlYear.SelectedValue = dInfo.Year.ToString();
            ddlMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();

            cBeginDate.Text = wInfo.保险期限自.ToShortDateString();
            cEndDate.Text = wInfo.保险期限到.ToShortDateString();
            tb柜号起始字母.Text = wInfo.柜号起始字母;
            tb保费.Text = wInfo.保费;
            tb集装箱数量20.Text = wInfo.集装箱数量20;
            tb集装箱数量40.Text = wInfo.集装箱数量40;
            tb单价20.Text = wInfo.单价20;
            tb单价40.Text = wInfo.单价40;
            tb保额.Text = wInfo.保额;
            tb基本险保险费率.Text = wInfo.基本险保险费率;
            tb备注.Text = wInfo.备注;
            BindList(this.ID, ReportCatalog.InsuranceOfContainer);
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
            gvList.DataSource = cList;
            gvList.DataBind();
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
                string id = e.CommandArgument.ToString();
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                GridView gvList = gvr.Parent as GridView;
                ReportCatalog catalog = ReportCatalog.InsuranceOfContainer;
                if (e.CommandName == "btnDel")
                {
                    new InstalmentOfCompensation().Delete(id);
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
                        info.ID = id;
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
                InsuranceOfContainerInfo wInfo = new InsuranceOfContainerInfo();
                if (string.IsNullOrEmpty(id) == false)
                {
                    wInfo = new InsuranceOfContainer().GetByID(id);
                }

                wInfo.InputUserID = this.UserCacheInfo.ID;
                string year = tbYear.Text;
                string dimTimeID = new DimTime().GetIDByMonth(year, "12");
                wInfo.DimTimeID = dimTimeID;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;
                wInfo.ExchangeRateID = this.RateID;

                wInfo.保险期限自 = DateTime.Parse(cBeginDate.Text);
                wInfo.保险期限到 = DateTime.Parse(cEndDate.Text);
                wInfo.柜号起始字母 = tb柜号起始字母.Text;
                wInfo.保费 = tb保费.Text;
                wInfo.集装箱数量20 = tb集装箱数量20.Text;
                wInfo.集装箱数量40 = tb集装箱数量40.Text;
                wInfo.单价20 = tb单价20.Text;
                wInfo.单价40 = tb单价40.Text;
                wInfo.保额 = tb保额.Text;
                wInfo.基本险保险费率 = tb基本险保险费率.Text;
                wInfo.备注 = tb备注.Text;

                if (string.IsNullOrEmpty(id) == true)
                {
                    this.ID = new InsuranceOfContainer().Add(wInfo);
                    ReportCatalog catalog = ReportCatalog.InsuranceOfContainer;
                    BindList(this.ID, catalog);
                }
                else
                {
                    new InsuranceOfContainer().Update(wInfo);
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
                new InsuranceOfContainer().Delete(id);
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
                string url = "InsuranceOfContainerList.aspx";
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

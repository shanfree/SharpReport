using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using System.Data;
using System.Web.UI;

namespace SharpReportWeb.ChuanJ
{
    public partial class JianyanInputPage : WebBasePage
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
        /// 报表主键
        /// </summary>
        private string ReportID
        {
            get
            {
                return GetViewState("ReportID");
            }
            set
            {
                ViewState["ReportID"] = value;
                InvoiceList1.KeyID = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("检验报表", "用户可以新增、修改或者删除检验报表信息，报表登记用户不能修改已经被财务部门确认过的报表。");
                    this.ReportID = GetRequest("ID");
                    BindShip();
                    BindCurrency();
                    if (string.IsNullOrEmpty(this.ReportID))
                    {
                        SetNewReport();
                        return;
                    }
                    SetPageValue(this.ReportID);
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
        private void BindShip()
        {
            IList<ShipInfo> sList = new Ship().GetList();
            ddlShip.DataSource = sList;
            ddlShip.DataBind();
            ddlShip.SelectedIndex = 0;
        }
        
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
                string year = ddlYear.SelectedValue;
                string month = ddlMonth.SelectedValue;
                string dimID = new DimTime().GetIDByMonth(year, month);
                string currencyID = ddlCurrency.SelectedValue;
                ExchangeRateInfo eInfo = new ExchangeRate().GetInfo(currencyID, dimID);
                lbRate.Text = eInfo.Rate;
                this.RateID = eInfo.ID;
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

        #region 页面赋值
        /// <summary>
        /// 新增报表初始化
        /// </summary>
        private void SetNewReport()
        {
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            ddlReportYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlReportMonth.SelectedValue = DateTime.Now.Month.ToString();
            ddlYear.SelectedValue = DateTime.Now.Month.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            rblUsage.SelectedIndex = 0;
            rblReportType.SelectedIndex = 0;
            ddlShip.SelectedIndex = 0;
            tb总数.Text = "0";
            InvoiceList1.KeyID = string.Empty;
        }

        private void SetPageValue(string id)
        {
            JianyanInputInfo wInfo = new JianyanInput().GetByID(id);
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(wInfo.DimTimeID);
            ddlReportMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();
            ddlReportYear.SelectedValue = dInfo.Year.ToString();
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();

            rblReportType.Items.FindByValue(wInfo.ReportTypeID).Selected = true;
            rblUsage.Items.FindByValue(wInfo.UsageType).Selected = true;
            ddlShip.SelectedItem.Selected = false;
            ddlCurrency.SelectedItem.Selected = false;
            ddlYear.SelectedItem.Selected = false;
            ddlMonth.SelectedItem.Selected = false;
            ddlShip.Items.FindByValue(wInfo.ShipID).Selected = true;
            ddlCurrency.Items.FindByValue(wInfo.CurrencyID).Selected = true;
            ddlYear.Items.FindByValue(dInfo.Year.ToString()).Selected = true;
            ddlMonth.Items.FindByValue(dInfo.MonthNumOfYear.ToString()).Selected = true;

            tb总数.Text = wInfo.总数;
            InvoiceList1.KeyID = id;
        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReportID = string.Empty;
                tbUserName.Text = this.UserCacheInfo.Name;
                tbCreateTime.Text = "新增报表";

                //rblUsage.SelectedIndex = 0;
                rblReportType.SelectedIndex = 0;
                ddlShip.SelectedIndex = 0;
                tb总数.Text = "0";
                InvoiceList1.KeyID = string.Empty;
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.ReportID;
                JianyanInputInfo wInfo = new JianyanInputInfo();
                if (string.IsNullOrEmpty(id) == false)
                {
                    wInfo = new JianyanInput().GetByID(id);
                }

                wInfo.UsageType = rblUsage.SelectedValue;
                string reportTypeID = rblReportType.SelectedValue;
                if (string.IsNullOrEmpty(reportTypeID))
                {
                    ShowMsg("请选择报表类型。");
                    return;
                }
                wInfo.ReportTypeID = rblReportType.SelectedValue;
                wInfo.InputUserID = this.UserCacheInfo.ID;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;
                wInfo.ExchangeRateID = this.RateID;

                wInfo.总数 = tb总数.Text;
                string year = ddlReportYear.SelectedValue;
                string month = ddlReportMonth.SelectedValue;
                string dimTimeID = new DimTime().GetIDByMonth(year, month);
                wInfo.DimTimeID = dimTimeID;
                wInfo.ShipID = ddlShip.SelectedValue; 
                
                if (string.IsNullOrEmpty(id) == true)
                {
                    this.ReportID = new JianyanInput().Add(wInfo);
                }
                else
                {
                    new JianyanInput().Update(wInfo);
                }
                tb总数.Text = wInfo.总数;
                ShowMsg("检验报表保存成功。");
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
                string id = this.ReportID;
                if (string.IsNullOrEmpty(id) == true)
                {
                    ShowMsg("未选定任何检验报表。");
                    return;
                }
                new JianyanInput().Delete(id);
                this.ReportID = string.Empty;
                ShowMsg("检验报表删除成功。");
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

        #region 返回统计页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "JianyanList.aspx";
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
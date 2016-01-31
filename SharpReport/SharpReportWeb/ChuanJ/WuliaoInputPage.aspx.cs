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
    public partial class WuliaoInputPage : WebBasePage
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

        #endregion

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("物料报表", "用户可以新增、修改或者删除物料报表信息，报表登记用户不能修改已经被财务部门确认过的报表。");
                    this.ReportID = GetRequest("ID");
                    BindShip();
                    BindCurrency();
                    if (string.IsNullOrEmpty(this.ReportID) )
                    {
                        SetNewReport();
                        return;
                    }
                    WuliaoInputInfo wInfo = new WuliaoInput().GetByID(this.ReportID);
                    SetPageValue(wInfo, wInfo.ReportTypeID);
                    foreach (ListItem item in rblReportType.Items)
                    {
                        item.Text = item.Text.Replace("（当前状态）", "");
                        if (item.Value == wInfo.ReportTypeID)
                        {
                            item.Text = item.Text + "（当前状态）";
                        }
                    }
                    //InvoiceList1.KeyID = ReportID;
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
            tb办公用品.Text = "0";
            tb生产用品.Text = "0";
            tb生活用品.Text = "0";
            tb缆绳.Text = "0";
            tb其他.Text = "0";
            tb锁具.Text = "0";
            tb药品.Text = "0";
            tb油漆.Text = "0";
            tb其他.Text = "0";
            InvoiceList1.KeyID = string.Empty;
        }

        private void BindShip()
        {
            IList<ShipInfo> sList = new Ship().GetList();
            ddlShip.DataSource = sList;
            ddlShip.DataBind();
            ddlShip.SelectedIndex = 0;
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

        #endregion

        /// <summary>
        /// 根据页面实体设置页面值
        /// </summary>
        /// <param name="wInfo"></param>
        private void SetPageValue(WuliaoInputInfo wInfo, string selectValue)
        {
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(wInfo.DimTimeID);
            ddlReportMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();
            ddlReportYear.SelectedValue = dInfo.Year.ToString();
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();

            rblReportType.SelectedValue = selectValue;
            rblUsage.SelectedValue = wInfo.UsageType;
            ddlShip.SelectedValue = wInfo.ShipID;
            ddlCurrency.SelectedValue = wInfo.CurrencyID;
            ddlYear.SelectedValue = dInfo.Year.ToString();
            ddlMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();

            tb总数.Text = wInfo.总数;
            tb办公用品.Text = wInfo.办公用品;
            tb生产用品.Text = wInfo.生产用品;
            tb生活用品.Text = wInfo.生活用品;
            tb缆绳.Text = wInfo.缆绳;
            tb其他.Text = wInfo.其他;
            tb锁具.Text = wInfo.锁具;
            tb药品.Text = wInfo.药品;
            tb油漆.Text = wInfo.油漆;
        }

        #region 控件操作
        protected void rblReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.ReportID;

            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            WuliaoInputInfo wInfo = new WuliaoInput().GetByID(id);
            string selectValue = rblReportType.SelectedValue;
            if (selectValue == "1" && wInfo.ReportTypeID != "1")
            {
                WuliaoInputInfo preInfo = new ReportBase<WuliaoInputInfo>().GetPreestimateModel(wInfo.ID);
                SetPageValue(preInfo, selectValue);
            }
            else if (selectValue == "2" && wInfo.ReportTypeID == "3")
            {
                WuliaoInputInfo preInfo = new ReportBase<WuliaoInputInfo>().GetAmendModel(wInfo.ID);
                SetPageValue(preInfo, selectValue);
            }
            else
            {
                SetPageValue(wInfo, selectValue);
            }
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReportID = string.Empty;
                SetNewReport();
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
                WuliaoInputInfo wInfo = new WuliaoInputInfo();
                if (string.IsNullOrEmpty(id) == false)
                {
                    wInfo = new WuliaoInput().GetByID(id);
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
                string year = ddlReportYear.SelectedValue;
                string month = ddlReportMonth.SelectedValue;
                string dimTimeID = new DimTime().GetIDByMonth(year, month);
                wInfo.DimTimeID = dimTimeID;
                wInfo.ShipID = ddlShip.SelectedValue;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;
                wInfo.ExchangeRateID = this.RateID;

                wInfo.办公用品 = tb办公用品.Text;
                wInfo.生产用品 = tb生产用品.Text;
                wInfo.生活用品 = tb生活用品.Text;
                wInfo.缆绳 = tb缆绳.Text;
                wInfo.其他 = tb其他.Text;
                wInfo.锁具 = tb锁具.Text;
                wInfo.药品 = tb药品.Text;
                wInfo.油漆 = tb油漆.Text;
                if (string.IsNullOrEmpty(id) == true)
                {
                    this.ReportID = new WuliaoInput().Add(wInfo);
                }
                else
                {
                    new WuliaoInput().Update(wInfo);
                }
                tb总数.Text = wInfo.总数;
                ShowMsg("物料报表保存成功。");
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
                    ShowMsg("未选定任何物料报表。");
                    return;
                }
                new WuliaoInput().Delete(id);
                ShowMsg("物料报表删除成功。");
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

        #region 返回页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "WuliaoList.aspx";
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


    }
}

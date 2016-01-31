using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using SIRC.Framework.SharpMemberShip;
using Sirc.SharpReport.Model;
using System.Collections.Generic;

namespace SharpReportWeb.Caiwu
{
    public partial class InvoiceSearch : WebBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("财务部门报表确认", "财务部门审核人员可以根据发表编号定位到相应报表进行维护。");
                    BindList(0);
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

        private void BindList(int pageIndex)
        {
            BindList(pageIndex, pGrid.PageSize);
        }
        private void BindList(int pageIndex, int pageSize)
        {
            if (rSearchType.SelectedValue == "1")
            {
                //按发票编号
                string invoiceNum = tbInvoiceNo.Text;
                if (string.IsNullOrEmpty(invoiceNum))
                {
                    return;
                }
                IList<InvoiceInfo> vList = new Invoice().GetListByNumber(invoiceNum);
                gvList.DataSource = vList;
                gvList.DataBind();
            }
            else
            { 
                // 按开票日期
            }
        }

        #region 搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindList(0);
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

        protected void rSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInvoiceNo.Visible = false;
            divDate.Visible = false;
            if (rSearchType.SelectedValue == "1")
            {
                tbInvoiceNo.Visible = true;
            }
            else if (rSearchType.SelectedValue == "2")
            {
                divDate.Visible = true;
            }
        }
        #endregion

        #region 列表操作
        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InvoiceInfo rInfo = e.Row.DataItem as InvoiceInfo;
                // 选择控件，传入收件的事务主键，用来更新
                Button btnView = (Button)e.Row.FindControl("btnView");
                string url = "window.open('{0}');return false;";
                url = String.Format(url, rInfo.ReportUrl);
                btnView.OnClientClick = url;

                Label lbReportCatalog = (Label)e.Row.FindControl("lbReportCatalog");
                lbReportCatalog.Text = rInfo.ReportCatalogName;

                Label lbCurrencyName = (Label)e.Row.FindControl("lbCurrencyName");
                CurrencyInfo cInfo = new Currency().GetByID(rInfo.CurrencyID);
                lbCurrencyName.Text = cInfo.Name;

                Label lbExchangeRate = (Label)e.Row.FindControl("lbExchangeRate");
                lbExchangeRate.Text = new Invoice().GetExchangeRate(rInfo.ID);

                Label lbRate = (Label)e.Row.FindControl("lbRate");
                double dRate = double.Parse(rInfo.Rate);
                lbRate.Text = (dRate * 100).ToString();

                Label lbRMB = (Label)e.Row.FindControl("lbRMB");
                lbRMB.Text = new Invoice().GetRMBAmout(rInfo.ID);
                
            }
        }
        #endregion

        #region 月份和船舶选择
        protected void MonthAndShipNavigate1_OnSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                BindList(0);
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

        #region 翻页
        protected void pGridV_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindList(pGrid.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        #region 生成excel事件
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        protected void ExcelGenButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BindList(0, 5000);
            }
            catch (ArgumentNullException ane)
            {
                this.ShowMsg(ane.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                this.Log(ex);
            }
        }
        #endregion



    }
}

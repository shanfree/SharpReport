using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;

namespace SharpReportWeb.WUC
{
    public partial class InvoiceList : System.Web.UI.UserControl
    {
        /// <summary>
        /// 控件所在页面的栏目编号
        /// </summary>
        public string MenuID { get; set; }
        /// <summary>
        /// 发票所属的报表类型
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// 发票所属的报表主键
        /// </summary>
        public string KeyID
        {
            get
            {
                object o = ViewState["KeyID"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                string keyID = this.KeyID;
                if (string.IsNullOrEmpty(value) == false && keyID != value)
                {
                    ViewState["KeyID"] = value;
                    BindGrid();
                }
            }
        }

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //绑定列表
                    //BindGrid();
                    if (this.Page is WebBasePage)
                    {
                        this.MenuID = ((WebBasePage)this.Page).MenuID;
                    }
                }
            }
            catch (ArgumentException ae)
            {
                this.ShowMsg(ae.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                LogEntry.Log.Write(exc.ToString(), MenuID);
            }
        }

        /// <summary>
        /// 在页面在弹出框提示用户信息
        /// </summary>
        /// <param name="message"></param>
        public void ShowMsg(string message)
        {
            // 过滤掉换行符
            message = message.Replace("\r\n", " ");
            message = message.Replace("'", "\"");
            string script = string.Format("<script>alert('{0}')</script>", message);
            Response.Write(script);
        }
        #endregion

        #region 行命令事件
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.ReportType) || string.IsNullOrEmpty(this.KeyID))
                {
                    ShowMsg("请先保存报表信息，再编辑相关的发票信息。");
                    return;
                }
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string id = e.CommandArgument.ToString();

                if (e.CommandName == "btnDel")
                {
                    new Invoice().Delete(id);
                }
                else
                {
                    TextBox tbNumber = (TextBox)gvr.FindControl("tbNumber");
                    TextBox tbAmout = (TextBox)gvr.FindControl("tbAmout");
                    TextBox tbPersonName = (TextBox)gvr.FindControl("tbPersonName");
                    TextBox cInputDate = (TextBox)gvr.FindControl("cInputDate");
                    DropDownList ddlCurrency = (DropDownList)gvr.FindControl("ddlCurrency");
                    DropDownList ddlRate = (DropDownList)gvr.FindControl("ddlRate");

                    string number = tbNumber.Text;
                    string name = tbPersonName.Text;
                    string amout = tbAmout.Text;
                    string currencyID = ddlCurrency.SelectedValue;
                    string rate = ddlRate.SelectedValue;
                    DateTime inputDate = Convert.ToDateTime(cInputDate.Text);

                    if (e.CommandName == "btnEdit")
                    {
                        new Invoice().Update(id, number, amout, currencyID, rate, inputDate, name);
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new Invoice().Add(number, amout, currencyID, rate, inputDate, name, this.ReportType, this.KeyID);
                    }
                    ShowMsg("操作成功！");
                }
                BindGrid();
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

        #region 绑定列表
        private void BindGrid()
        {
            if (string.IsNullOrEmpty(this.ReportType))
            {
                return;
            }
            sum = 0;
            IList<InvoiceInfo> ilist = new Invoice().GetInvoiceListAddBlank(this.ReportType, this.KeyID);
            gvList.DataSource = ilist;
            gvList.DataBind();
        }
        #endregion

        #region 行绑定
        private double sum = 0;
        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InvoiceInfo cInfo = e.Row.DataItem as InvoiceInfo;

                #region 操作按钮
                Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                Button btnDel = (Button)e.Row.FindControl("btnDel");
                Button btnPic = (Button)e.Row.FindControl("btnPic");

                if (string.IsNullOrEmpty(cInfo.ID))
                {
                    btnAdd.Visible = true;
                    btnEdit.Visible = false;
                    btnDel.Visible = false;
                    btnPic.Visible = false;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnEdit.Visible = true;
                    btnDel.Visible = true;
                    btnPic.Visible = true;
                }
                if (!String.IsNullOrEmpty(btnPic.CommandArgument) && btnPic != null)
                {
                    string url = "window.open('../Pages/ViewImage.aspx?id={0}');return false;";
                    url = String.Format(url, btnPic.CommandArgument);
                    btnPic.OnClientClick = url;
                }

                #endregion

                DropDownList ddlCurrency = (DropDownList)e.Row.FindControl("ddlCurrency");
                ddlCurrency.DataSource = new Currency().GetList();
                ddlCurrency.DataBind();
                DropDownList ddlRate = (DropDownList)e.Row.FindControl("ddlRate");
                if (cInfo != null && string.IsNullOrEmpty(cInfo.CurrencyID) == false)
                {
                    ddlCurrency.SelectedValue = cInfo.CurrencyID;
                    ddlRate.SelectedValue = cInfo.Rate;
                }
            }
            if (e.Row.RowIndex >= 0)
            {
                Label lbRMB = (Label)e.Row.FindControl("lbRMB");
                double result = 0;
                bool isDouble = Double.TryParse(lbRMB.Text,out result);
                if (isDouble)
                {
                    sum += Convert.ToDouble(lbRMB.Text);
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text =  "总额相当于人民币："+ sum.ToString() + "元";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetRMB(string invoiceID)
        {
            if (string.IsNullOrEmpty(invoiceID))
            {
                return "--";
            }
            return new Invoice().GetRMBAmout(invoiceID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCost(string invoiceID)
        {
            if (string.IsNullOrEmpty(invoiceID))
            {
                return "--";
            }
            string total = new Invoice().GetRMBAmout(invoiceID);
            decimal dTotal = Convert.ToDecimal(total);
            InvoiceInfo vInfo = new Invoice().GetByID(invoiceID);
            decimal rate = Convert.ToDecimal(vInfo.Rate);
            decimal localAmout = Math.Round(dTotal / (1+ rate), 2);
            return localAmout.ToString();
        }

        #endregion
    }
}
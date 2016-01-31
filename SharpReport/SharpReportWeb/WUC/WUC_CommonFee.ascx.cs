using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;

namespace SharpReportWeb.WUC
{
    public partial class WUC_CommonFee : System.Web.UI.UserControl
    {
        /// <summary>
        /// 控件所在页面的栏目编号
        /// </summary>
        public string MenuID { get; set; }

        /// <summary>
        /// 所属的单位主键
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 当前用户主键
        /// </summary>
        public string UserID { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string DimTimeID
        {
            get
            {
                object o = ViewState["DimTimeID"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                string keyID = this.DimTimeID;
                if (string.IsNullOrEmpty(value) == false && keyID != value)
                {
                    ViewState["DimTimeID"] = value;
                    this.Year = string.Empty;
                    BindGrid(this.DimTimeID, this.DepartmentID);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get
            {
                object o = ViewState["Year"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                string keyID = this.Year;
                if (string.IsNullOrEmpty(value) == false && keyID != value)
                {
                    ViewState["Year"] = value;
                    ShowWholeYear(this.Year);
                }
            }
        }

        #region 控件显示全年的费用汇总
        /// <summary>
        /// 控件显示全年的费用汇总
        /// </summary>
        /// <param name="year"></param>
        public void ShowWholeYear(string year)
        {
            if (string.IsNullOrEmpty(year) == false)
            {
                IList<CommonFeeInfo> ilist = new CommonFee().GetList(year, string.Empty, this.DepartmentID);
                gvList.DataSource = ilist;
                gvList.DataBind();
                this.DimTimeID = string.Empty;
            }
        }
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string companyID = String.Empty;
                    pGrid.PageSize = gvList.PageSize;
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
                string strIndex = e.CommandArgument.ToString();
                int index = Convert.ToInt32(strIndex);
                GridViewRow gvr = (GridViewRow)gvList.Rows[index];
                Label lblID = (Label)gvr.FindControl("lblID");
                string tID = lblID.Text;

                if (e.CommandName == "btnDel")
                {
                    new CommonFee().Delete(tID);
                }
                else
                {
                    Label lbFeeCatalogID = (Label)gvr.FindControl("lbFeeCatalogID");
                    Label lbName = (Label)gvr.FindControl("lbName");
                    TextBox tbAmout = (TextBox)gvr.FindControl("tbAmout");
                    DropDownList ddlListCurrency = (DropDownList)gvr.FindControl("ddlListCurrency");
                    DropDownList ddlFeeCatalog = (DropDownList)gvr.FindControl("ddlFeeCatalog");
                    TextBox tbCreateTime = (TextBox)gvr.FindControl("tbCreateTime");
                    TextBox tbRemark = (TextBox)gvr.FindControl("tbRemark");
                    CommonFeeInfo info = new CommonFeeInfo(tID);
                    if (string.IsNullOrEmpty(tID) == false)
                    {
                        info = new CommonFee().GetByID(tID);
                    }
                    info.Amount = tbAmout.Text;
                    WebBasePage page = this.Page as WebBasePage;
                    if (null == page)
                    {
                        this.ShowMsg("无法获取当前用户信息，请返回登录页重新登录。");
                        return;
                    }
                    info.ApproveUserID = page.UserCacheInfo.ID;
                    info.CurrencyID = ddlListCurrency.SelectedValue;
                    if (string.IsNullOrEmpty(this.DimTimeID) == false)
                    {
                        info.DimTimeID = this.DimTimeID;
                    }
                    info.FeeCatalogID = ddlFeeCatalog.SelectedValue;
                    info.备注 = tbRemark.Text;

                    if (e.CommandName == "btnEdit")
                    {
                        new CommonFee().Update(info);
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new CommonFee().Add(info);
                    }
                    ShowMsg("操作成功！");
                }
                BindGrid(this.DimTimeID, this.DepartmentID);
            }
            catch (ArgumentException ae)
            {
                this.ShowMsg(ae.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                //Log(exc);
            }
        }
        #endregion

        #region 绑定列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimTimeID"></param>
        /// <param name="departmentID"></param>
        private void BindGrid(string dimTimeID, string departmentID)
        {
            IList<CommonFeeInfo> ilist = new List<CommonFeeInfo>();
            if (string.IsNullOrEmpty(this.DimTimeID) == false)
            {
                DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dimTimeID);
                string year = dInfo.Year.ToString();
                string month = dInfo.MonthNumOfYear.ToString();
                if (string.IsNullOrEmpty(departmentID) == false)
                {
                    ilist = new CommonFee().GetListAddBlank(year, month, departmentID);
                }
            }
            else if (string.IsNullOrEmpty(this.Year) == false)
            {
                if (string.IsNullOrEmpty(departmentID) == false)
                {
                    ilist = new CommonFee().GetList(this.Year, string.Empty, this.DepartmentID);
                }
            }

            gvList.DataSource = ilist;
            gvList.DataBind();
        }
        #endregion

        #region 行绑定
        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CommonFeeInfo cInfo = e.Row.DataItem as CommonFeeInfo;
                DropDownList ddlListCurrency = (DropDownList)e.Row.FindControl("ddlListCurrency");
                ddlListCurrency.DataSource = new Currency().GetList();
                ddlListCurrency.DataBind();
                if (cInfo != null && string.IsNullOrEmpty(cInfo.CurrencyID) == false)
                {
                    ddlListCurrency.SelectedValue = cInfo.CurrencyID;
                }

                DropDownList ddlFeeCatalog = (DropDownList)e.Row.FindControl("ddlFeeCatalog");
                ddlFeeCatalog.DataSource = new FeeCatalog().GetList(this.DepartmentID);
                ddlFeeCatalog.DataBind();
                if (cInfo != null && string.IsNullOrEmpty(cInfo.CurrencyID) == false)
                {
                    ddlFeeCatalog.SelectedValue = cInfo.FeeCatalogID;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetRMB(string commonFeeID)
        {
            if (string.IsNullOrEmpty(commonFeeID))
            {
                return "--";
            }
            return new CommonFee().GetRMBAmout(commonFeeID);
        }

        #endregion

        #region 生成excel事件
        protected void ExcelGenButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvList.Columns.Count;
                gvList.Columns[index - 1].Visible = false;
                if (string.IsNullOrEmpty(this.Year) == false)
                {
                    ShowWholeYear(this.Year);
                }
                else if (string.IsNullOrEmpty(this.DimTimeID) == false)
                {
                    BindGrid(this.DimTimeID, this.DepartmentID);
                }
            }
            catch (ArgumentNullException ane)
            {
                this.ShowMsg(ane.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 翻页
        protected void pGrid_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Year) == false)
                {
                    ShowWholeYear(this.Year);
                }
                else if (string.IsNullOrEmpty(this.DimTimeID) == false)
                {
                    BindGrid(this.DimTimeID, this.DepartmentID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
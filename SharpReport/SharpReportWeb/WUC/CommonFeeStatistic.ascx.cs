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
    public partial class CommonFeeStatistic : System.Web.UI.UserControl
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
                    BindGrid(this.DepartmentID);
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
                    string companyID = String.Empty;
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

        #region 绑定列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimTimeID"></param>
        /// <param name="departmentID"></param>
        private void BindGrid(string departmentID)
        {
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(this.Year) == false)
            {
                if (string.IsNullOrEmpty(departmentID) == false)
                {
                    int year = Convert.ToInt16(this.Year);
                    ds = new CommonFee().GetStatistic(this.DepartmentID, year);
                }
            }

            gvList.DataSource = ds;
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
    }
}
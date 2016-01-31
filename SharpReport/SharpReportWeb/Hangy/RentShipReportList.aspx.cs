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
    public partial class RentShipReportList : WebBasePage
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
        #endregion

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MonthAndShipNavigate1.OnSelectedChanged += new EventHandler(MonthAndShipNavigate1_OnSelectedChanged);
                if (!IsPostBack)
                {
                    TitleInitial("船舶其他收入报表汇总", "船舶其他收入报表汇总。用户可以点击“填写其他收入报表”按钮填报其他收入报表。");
                    BindRentReport(0);
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

        #endregion

        #region 月份和船舶选择
        protected void MonthAndShipNavigate1_OnSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                BindRentReport(0);
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
        /// 绑定散货报表
        /// </summary>
        private void BindRentReport(int pageIndex)
        {
            string shipID = MonthAndShipNavigate1.ShipID;
            string year = MonthAndShipNavigate1.Year;
            string month = MonthAndShipNavigate1.Month;
            DataSet ds = new RentShipReport().GetList(year, month, shipID, pGridV.PageSize, pageIndex);
            gvRentReport.DataSource = ds;
            gvRentReport.DataBind();
            CustomDataSet cDS = ds as CustomDataSet;
            if (cDS == null)
            {
                pGridV.TotalAmout = 0;
                return;
            }
            pGridV.TotalAmout = cDS.TotalAmout;
        }
        #endregion

        #region 列表操作
        double sum = 0;
        protected void gvRentReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dv = e.Row.DataItem as DataRowView;
                    if (dv.Row["ID"] == null)
                    {
                        return;
                    }
                    string reportID = dv.Row["ID"].ToString();
                    if (string.IsNullOrEmpty(reportID))
                    {
                        return;
                    }
                    RentShipReportInfo vInfo = new RentShipReport().GetByID(reportID);
                    Label lbTotal = (Label)e.Row.FindControl("lbTotal");
                    Label lbTotalRMB = (Label)e.Row.FindControl("lbTotalRMB");
                    lbTotal.Text = new RentShipReport().GetAmout(reportID); ;
                    lbTotalRMB.Text = new RentShipReport().GetRMBAmout(reportID);
                }
                if (e.Row.RowIndex >= 0)
                {
                    Label lbTotal = (Label)e.Row.FindControl("lbTotal");
                    double result = 0;
                    bool isDouble = Double.TryParse(lbTotal.Text, out result);
                    if (isDouble)
                    {
                        sum += Convert.ToDouble(lbTotal.Text);
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[8].Text = "总额相当于人民币：" + sum.ToString() + "元";
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

        protected void gvRentReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string id = e.CommandArgument.ToString();
                Label lbShipID = gvr.FindControl("lbShipID") as Label;
                string shipID = lbShipID.Text;
                if (e.CommandName == "btnDel")
                {
                }
                if (e.CommandName == "btnEdit")
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        Response.Redirect("RentShipReportInput.aspx?shipID=" + shipID, false);
                    }
                    else
                    {
                        Response.Redirect("RentShipReportInput.aspx?id=" + id, false);
                    }
                }
                BindRentReport(pGridV.CurrentPageIndex);
                ShowMsg("操作成功！");
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

        #region 翻页
        protected void pGridV_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindRentReport(pGridV.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        #endregion

        #region 报表类型选择
        protected void ddlRentReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindRentReport(pGridV.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }

        }
        #endregion

        #region 操作
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string shipID = MonthAndShipNavigate1.ShipID;
                //string year = MonthAndShipNavigate1.Year;
                //string month = MonthAndShipNavigate1.Month;
                //string url = string.Format("RentShipReportInput.aspx?shipID={0}&year={1}&month={2}", shipID, year, month);
                string url = string.Format("RentShipReportInput.aspx?shipID={0}", shipID);
                Response.Redirect(url, false);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion
    }
}

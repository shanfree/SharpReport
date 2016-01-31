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
    public partial class FCLManageList : WebBasePage
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
        //public string VoyageLoadID
        //{
        //    get
        //    {
        //        return GetViewState("VoyageLoadID");
        //    }
        //    set
        //    {
        //        ViewState["VoyageLoadID"] = value;
        //    }
        //}
        #endregion

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MonthAndShipNavigate1.OnSelectedChanged += new EventHandler(MonthAndShipNavigate1_OnSelectedChanged);
                if (!IsPostBack)
                {
                    TitleInitial("集装箱船舶报表汇总", "集装箱船舶运费计费报表汇总。载货情况根据船只的“装箱类型”填写：“集装箱”船填写箱量相关信息，“散货”船填写散货载货量信息。");
                    string shipID = GetRequest("shipID");
                    string dateID = GetRequest("dateID");
                    if (string.IsNullOrEmpty(shipID) == false)
                    {
                        MonthAndShipNavigate1.ShipID = shipID;
                    }
                    if (string.IsNullOrEmpty(dateID) == false)
                    {
                        MonthAndShipNavigate1.DateID = dateID;
                    }

                    BindFCL(0);
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
                BindFCL(0);
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
        private void BindFCL(int pageIndex)
        {
            string shipID = MonthAndShipNavigate1.ShipID;
            string dateID = MonthAndShipNavigate1.DateID;
            string reportType = ddlFCLType.SelectedValue;
            DataSet ds = new VoyageFCL().GetList(dateID, shipID, reportType, pGridV.PageSize, pageIndex);
            gvFCL.DataSource = ds;
            gvFCL.DataBind();
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
        protected void gvFCL_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    VoyageFCLInfo vInfo = new VoyageFCL().GetByID(reportID);
                    Label lbTotal = (Label)e.Row.FindControl("lbTotal");
                    lbTotal.Text = new VoyageFCL().GetRMBAmout(reportID);
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

        protected void gvFCL_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string id = e.CommandArgument.ToString();
                Label lbVoyageID = gvr.FindControl("lbVoyageID") as Label;
                string voyageID = lbVoyageID.Text;
                if (e.CommandName == "btnDel")
                {
                }
                if (e.CommandName == "btnEdit")
                {
                    Response.Redirect("VoyageLoadInput.aspx?voyageId=" + voyageID, false);
                }
                BindFCL(pGridV.CurrentPageIndex);
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
                BindFCL(pGridV.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("VoyageLoadInput.aspx", false);
        }

        #endregion

        #region 报表类型选择
        protected void ddlFCLType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindFCL(pGridV.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }

        }
        #endregion

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string shipID = GetRequest("shipID");
                string dateID = GetRequest("dateID");
                string url = string.Format("ShipIncomeMonthReport.aspx?dateID={0}", dateID);

                Response.Redirect(url, false);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
    }
}

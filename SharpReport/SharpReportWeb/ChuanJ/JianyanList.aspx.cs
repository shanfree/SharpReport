using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;
using System.Web.UI;

namespace SharpReportWeb.ChuanJ
{
    public partial class JianyanList : WebBasePage
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
        /// 选定栏目ID
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
        /// 报表类型
        /// </summary>
        private string ReportTypeID
        {
            get
            {
                return GetViewState("ReportTypeID");
            }
            set
            {
                ViewState["ReportTypeID"] = value;
            }
        }
        #endregion

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TitleInitial("检验报表汇总", "用户可以新增、修改或者删除检验报表信息，报表登记用户不能修改已经被财务部门确认过的报表。");
                MonthAndShipNavigate1.OnSelectedChanged += new EventHandler(MonthAndShipNavigate1_OnSelectedChanged);
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
        /// 带有WUC的页面，必须在WUC载入完毕后再获取控件值
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.DimID = GetRequest("dimID");
                    this.ReportTypeID = GetRequest("ReportTypeID");
                    if (string.IsNullOrEmpty(this.DimID) == false)
                    {
                        MonthAndShipNavigate1.DateID = this.DimID;
                    }
                    BindList(0);
                }
                base.OnPreRender(e);
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
            string dateID = MonthAndShipNavigate1.DateID;
            string shipID = MonthAndShipNavigate1.ShipID;

            DataSet ds = new JianyanInput().GetList(dateID, shipID, this.ReportTypeID, pageSize, pageIndex);
            gvJianyanList.DataSource = ds;
            gvJianyanList.DataBind();
            CustomDataSet cDS = ds as CustomDataSet;
            if (cDS == null)
            {
                pGrid.TotalAmout = 0;
                return;
            }
            pGrid.TotalAmout = cDS.TotalAmout;
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

        #region 列表操作
        protected void gvJianyanList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rInfo = e.Row.DataItem as DataRowView;

                // 选择控件，传入收件的事务主键，用来更新
                //Label lbUsage = (Label)e.Row.FindControl("lbUsage");
                //string usageType = rInfo["UsageType"].ToString();
                //lbUsage.Text = rblUsage.Items.FindByValue(usageType).Text;

                Label lbReportType = (Label)e.Row.FindControl("lbReportType");
                string reportType = rInfo["ReportTypeID"].ToString();
                lbReportType.Text = rblReportType.Items.FindByValue(reportType).Text;
            }
        }
        /// <summary>
        /// 列表命令处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvJianyanList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string reportID = e.CommandArgument.ToString();
                if (e.CommandName.Equals("btnDelete"))
                {
                    new JianyanInput().Delete(reportID);
                    BindList(0);
                    ShowMsg("删除成功");
                }
                else
                {
                    Response.Redirect("JianyanInputPage.aspx?ID=" + reportID, false);
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

        #region 翻页
        protected void pGrid_OnClick(object sender, EventArgs e)
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
        }

        protected void ExcelGenButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvJianyanList.Columns.Count;
                gvJianyanList.Columns[index - 1].Visible = false;
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

        #region 返回统计页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "JianyanSummary.aspx?dimID=" + this.DimID;
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

        #region 新增报表
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string dimID = MonthAndShipNavigate1.DateID;
                string url = "JianyanInputPage.aspx?dimID=" + dimID;
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

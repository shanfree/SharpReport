using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;

namespace SharpReportWeb.ChuanJ
{
    public partial class Hangci : WebBasePage
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

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                    TitleInitial("航次维护", "用户可以维护航次相关信息，通过航次，可以创建燃润料消耗表以及船只油料添加报表。");
                    BindDDL();
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

        private void BindDDL()
        {
            BindVoyage(0);
        }
        #endregion

        #region 航次
        /// <summary>
        /// 绑定航次报表
        /// </summary>
        private void BindVoyage(int pageIndex)
        {
            string shipID = MonthAndShipNavigate1.ShipID;
            string dateID = MonthAndShipNavigate1.DateID;
            DataSet ds = new Voyage().GetBaseList(true, dateID, shipID, pGridV.PageSize, pageIndex);
            gvVoyageList.DataSource = ds;
            gvVoyageList.DataBind();
            CustomDataSet cDS = ds as CustomDataSet;
            if (cDS == null)
            {
                pGridV.TotalAmout = 0;
                return;
            }
            pGridV.TotalAmout = cDS.TotalAmout;

        }

        #region 月份和船舶选择
        protected void MonthAndShipNavigate1_OnSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                BindVoyage(0);
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

        /// <summary>
        /// 航次编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvVoyageList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string voyageId = e.CommandArgument.ToString();

                if (e.CommandName == "btnDelVoyage")
                {
                    //是否报送 判断是否要删除
                    VoyageInfo vi = new Voyage().GetByID(voyageId);

                    if (string.IsNullOrEmpty(vi.HangciBaseID) == false)
                    {
                        ShowMsg("请先删除这个航次对应的燃润料报表！");
                        return;
                    }
                    else
                    {
                        new Voyage().Delete(voyageId);
                        ShowMsg("航次删除成功！");
                        BindVoyage(0);

                        return;
                    }
                }
                else if (e.CommandName == "btnEditVoyage")
                {
                    string url = @"../Hangy/VoyageInput.aspx?voyageId=" + voyageId;
                    Response.Redirect(url, false);
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

        protected void gvVoyageList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dv = e.Row.DataItem as DataRowView;
                    // 选择控件，传入收件的事务主键，用来更新
                    CheckBox cbSel = (CheckBox)e.Row.FindControl("cbSel");
                    Label lbViewRanrun = (Label)e.Row.FindControl("lbViewRanrun");
                    HyperLink hlViewRanrun = (HyperLink)e.Row.FindControl("hlViewRanrun");
                    if (dv.Row["HangciBaseId"] == null || string.IsNullOrEmpty(dv.Row["HangciBaseId"].ToString()))
                    {
                        //为填报
                        cbSel.Visible = true;
                        lbViewRanrun.Visible = true;
                    }
                    else
                    {
                        cbSel.Visible = false;
                        hlViewRanrun.Visible = true;
                    }
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
        /// 新增航次前 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddVoyage_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../Hangy/VoyageLoadInput.aspx", false);
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
        /// 创建燃润报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string voyageids = "";
                string shipId = "";

                for (int i = 0; i < this.gvVoyageList.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)gvVoyageList.Rows[i].Cells[0].FindControl("cbSel");
                    if (cb.Checked)
                    {
                        HiddenField hidVoyageCb = (HiddenField)gvVoyageList.Rows[i].FindControl("hidVoyageCb");
                        string selVoyageId = hidVoyageCb.Value.ToString();

                        HiddenField hidShipId = (HiddenField)gvVoyageList.Rows[i].Cells[0].FindControl("hidShipId");
                        string temp = hidShipId.Value.ToString();
                        if (string.IsNullOrEmpty(shipId) == false && shipId.Equals(temp) == false)
                        {
                            ShowMsg("请选择相同的船只的航次来报送消耗报表！");
                            return;
                        }
                        voyageids += selVoyageId + ",";
                    }
                }

                if (voyageids.Equals(""))
                {
                    ShowMsg("请选择至少一条航次！");
                    return;
                }

                voyageids = voyageids.Substring(0, voyageids.Length - 1);
                Response.Redirect("../ChuanJ/RanrunInput.aspx?voyageIds=" + voyageids, false);
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

        protected void ExcelGenButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // 最多500页
                int pageSize = gvVoyageList.PageSize * 500;
                int pageIndex = 0;
                BindVoyage(pageIndex);

                gvVoyageList.Columns[0].Visible = false;
                gvVoyageList.Columns[6].Visible = false;
                gvVoyageList.Columns[7].Visible = false;

                foreach (GridViewRow gvr in gvVoyageList.Rows)
                {
                    foreach (TableCell cell in gvr.Cells)
                    {
                        cell.Attributes.Add("style", "vnd.ms-excel.numberformat:@;");
                    }
                }
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

        protected void pGridV_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindVoyage(pGridV.CurrentPageIndex);
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
            if (!(control.GetType().Name.Equals("GridView") || control.GetType().Name.Equals("CheckBox")))
            {
                base.VerifyRenderingInServerForm(control);
            }
        }
        #endregion

        #region 维护燃润报表
        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                string url = @"../ChuanJ/RanrunList.aspx";
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

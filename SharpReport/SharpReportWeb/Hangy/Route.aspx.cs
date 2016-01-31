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

namespace SharpReportWeb
{
    public partial class RouteManager : WebBasePage
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
                if (!IsPostBack)
                {
                    TitleInitial("航线登记", "用户创建航线信息，同一航线可以为不同船只的不同航次重复利用。");
                    BindDDL();
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

        private void BindDDL()
        {
            try
            {
                IList<PortInfo> dPortList = new Port().GetList();
                ddlStartPort.DataSource = dPortList;
                ddlStartPort.DataBind();

                ddlEndPort.DataSource = dPortList;
                ddlEndPort.DataBind();

                BindRoute(0, pGrid.PageSize);
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

        #region 航线
        /// <summary>
        /// 绑定路线报表
        /// </summary>
        private void BindRoute(int pageIndex, int pageSize)
        {
            DataSet dsBaseRoute = new Route().GetBaseList(pageSize, pageIndex);
            gvRouteList.DataSource = dsBaseRoute;
            gvRouteList.DataBind();

            CustomDataSet cDS = dsBaseRoute as CustomDataSet;
            if (cDS == null)
            {
                pGrid.TotalAmout = 0;
                return;
            }
            pGrid.TotalAmout = cDS.TotalAmout;
        }
        /// <summary>
        /// 路线报表数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvRouteList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView rInfo = e.Row.DataItem as DataRowView;
                    // 选择控件，传入收件的事务主键，用来更新
                    RadioButton rbSel = (RadioButton)e.Row.FindControl("rbSel");
                    rbSel.Attributes.Add("onclick", "Sel('" + rInfo["ID"].ToString() + "')");
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
        ///  路线报表改变选择路线绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbSel_RouteCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string id = lbID.Value;
                RouteInfo rInfo = new Route().GetByID(id);
                tbRouteName.Text = rInfo.Name;
                tbDistance.Text = rInfo.Distance.ToString();
                lbTotalRoute.Text = rInfo.TotalRoute;

                IList<PortInfo> pList = new Port().GetList(id, "2");
                String startPort = pList[0].ID;
                pList = new Port().GetList(id, "4");
                String endPort = pList[0].ID;
                ddlStartPort.SelectedValue = startPort;
                ddlEndPort.SelectedValue = endPort;

                BindPassPortList(id);
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
        /// 绑定经停港报表
        /// </summary>
        /// <param name="routeId"></param>
        private void BindPassPortList(string routeId)
        {
            try
            {
                DataSet ds = new Port().GetPortListByRoute(routeId, "5");

                DataTable dt = ds.Tables[0];

                int n = dt.Rows.Count;

                DataRow dr = dt.NewRow();
                dr["PortID"] = 0;
                dr["PortName"] = "";
                dt.Rows.InsertAt(dr, n);

                gvPassedPorts.DataSource = dt;
                gvPassedPorts.DataBind();
                gvPassedPorts.SelectedIndex = 0;
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
        /// 经停港初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvPassedPortst_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (((DropDownList)e.Row.FindControl("ddlPassPort")) != null)
                    {
                        DropDownList ddlPassPort = (DropDownList)e.Row.FindControl("ddlPassPort");
                        ddlPassPort.Items.Clear();

                        ddlPassPort.DataSource = new Port().GetList();
                        ddlPassPort.DataBind();
                    }

                    Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                    Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                    Button btnDel = (Button)e.Row.FindControl("btnDel");

                    HiddenField relateId = (HiddenField)e.Row.FindControl("hidRelateId");
                    DropDownList drp = (DropDownList)e.Row.FindControl("ddlPassPort");

                    if (relateId == null || string.IsNullOrEmpty(relateId.Value))
                    {
                        btnAdd.Visible = true;
                        btnEdit.Visible = false;
                        btnDel.Visible = false;
                    }
                    else
                    {
                        btnAdd.Visible = false;
                        btnEdit.Visible = true;
                        btnDel.Visible = true;
                        drp.SelectedValue = ((HiddenField)e.Row.FindControl("hidtxt")).Value.ToString();
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
        /// 经停港按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvPassedPorts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int routeId = Convert.ToInt32(lbID.Value);

                if (e.CommandName == "btnDel")
                {
                    string relateId = e.CommandArgument.ToString();
                    new Relation_RoutePort().Delete(relateId);
                }
                else
                {
                    #region 控件
                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    GridViewRow gvr = (GridViewRow)gvPassedPorts.Rows[index];
                    HiddenField hfRelateId = (HiddenField)gvr.FindControl("hidRelateId");
                    string relateId = hfRelateId.Value.ToString();
                    DropDownList drp = (DropDownList)gvr.FindControl("ddlPassPort");
                    TextBox tbOrderNum = (TextBox)gvr.FindControl("tbOrderNum");
                    #endregion

                    Relation_RoutePortInfo info = new Relation_RoutePortInfo();

                    info.OrderNum = tbOrderNum.Text;
                    info.PortID = Convert.ToInt32(drp.SelectedValue);
                    info.PortTypeID = 5;
                    info.RouteID = routeId;

                    if (e.CommandName == "btnEdit")
                    {
                        info.ID = relateId;
                        new Relation_RoutePort().Update(info);
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new Relation_RoutePort().Add(info);
                    }
                }
                string id = lbID.Value;
                RouteInfo rInfo = new Route().GetByID(id);
                lbTotalRoute.Text = rInfo.TotalRoute;
                BindPassPortList(id);
                ShowMsg("操作成功！");
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
        /// 新增路线按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddRoute_Click(object sender, EventArgs e)
        {
            try
            {
                lbID.Value = "";
                tbRouteName.Text = "";
                tbDistance.Text = "";
                ddlStartPort.SelectedIndex = 0;
                ddlEndPort.SelectedIndex = 0;
                lbTotalRoute.Text = "-无-";
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
        /// 路线增改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRoute_Click(object sender, EventArgs e)
        {
            try
            {
                RouteInfo ri = new RouteInfo();
                ri.Distance = float.Parse(tbDistance.Text);
                ri.Name = tbRouteName.Text;

                Relation_RoutePortInfo rrpis = new Relation_RoutePortInfo();
                rrpis.PortID = Convert.ToInt32(ddlStartPort.SelectedValue);
                rrpis.PortTypeID = 2;
                rrpis.OrderNum = "0";
                Relation_RoutePortInfo rrpie = new Relation_RoutePortInfo();
                rrpie.PortID = Convert.ToInt32(ddlEndPort.SelectedValue);
                rrpie.PortTypeID = 4;
                rrpie.OrderNum = "0";
                //新增
                if (string.IsNullOrEmpty(lbID.Value))
                {
                    int routeId = Convert.ToInt32(new Route().Add(ri));
                    //始发港
                    rrpis.RouteID = routeId;
                    new Relation_RoutePort().Add(rrpis);
                    //目的港
                    rrpie.RouteID = routeId;
                    new Relation_RoutePort().Add(rrpie);
                }
                //编辑
                else
                {
                    int routeId = Convert.ToInt32(lbID.Value);
                    ri.ID = routeId.ToString();
                    new Route().Update(ri);
                    //始发港
                    rrpis.RouteID = routeId;
                    IList<PortInfo> pList = new Port().GetList(routeId.ToString(), "2");

                    rrpis.ID = new Port().GetPortListByRoute(routeId.ToString(), "2").Tables[0].Rows[0]["relateId"].ToString();
                    new Relation_RoutePort().Update(rrpis);
                    //目的港
                    rrpie.RouteID = routeId;
                    rrpie.ID = new Port().GetPortListByRoute(routeId.ToString(), "4").Tables[0].Rows[0]["relateId"].ToString();
                    new Relation_RoutePort().Update(rrpie);

                    string id = lbID.Value;
                    RouteInfo rInfo = new Route().GetByID(id);
                    lbTotalRoute.Text = rInfo.TotalRoute;
                }

                BindRoute(0, pGrid.PageSize);
                BindPassPortList(lbID.Value);
                ShowMsg("操作成功！");
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
        /// 路线删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelRoute_Click(object sender, EventArgs e)
        {
            try
            {
                int routeId = Convert.ToInt32(lbID.Value);

                //查看是否有航次调用
                int isused = new Route().isRouteUsed(routeId.ToString());

                if (isused != 0)
                {
                    ShowMsg("该路线已经被航次引用，请先删除相应航次！");
                    return;
                }

                new Relation_RoutePort().DeleteByRoute(routeId.ToString());
                new Route().Delete(lbID.Value);

                ShowMsg("操作成功！");
                BindRoute(0, gvRouteList.PageSize);

                tbRouteName.Text = "";
                tbDistance.Text = "";
                ddlStartPort.SelectedIndex = 0;
                ddlEndPort.SelectedIndex = 0;
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

        #region 编辑航次
        protected void btnHangci_Click(object sender, EventArgs e)
        {
            try
            {
                string url = @"Hangci.aspx";
                Response.Redirect(url, false);
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

        protected void ExcelGenButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // 最多500页
                int pageSize = gvRouteList.PageSize * 500;
                int pageIndex = 0;
                BindRoute(pageIndex, pageSize);

                gvRouteList.Columns[0].Visible = false;

                foreach (GridViewRow gvr in gvRouteList.Rows)
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

        protected void pGrid_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindRoute(pGrid.CurrentPageIndex, pGrid.PageSize);
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

    }
}

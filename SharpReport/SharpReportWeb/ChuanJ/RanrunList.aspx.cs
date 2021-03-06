﻿using System;
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
    public partial class RanrunList : WebBasePage
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
                    TitleInitial("燃润料报表列表", "编辑所有燃润料报表，用户可以使用“添加燃润料报表”按钮跳转到航次定义栏目，根据选择的航次创建燃润料报表。");
                    BindDll();
                    BindReport(pGridV.PageSize, 0);
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
        #endregion

        #region 月份和船舶选择
        protected void MonthAndShipNavigate1_OnSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                BindReport(pGridV.PageSize, 0);
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

        #region 列表绑定
        private void BindDll()
        {
            try
            {
                //IList<PortInfo> dPortList = new Port().GetList();
                //ddlStartPort.DataSource = dPortList;
                //ddlStartPort.DataBind();
                //ddlStartPort.Items.Insert(0, new ListItem("请选择", ""));
                //ddlStartPort.SelectedIndex = 0;

                //ddlEndPort.DataSource = dPortList;
                //ddlEndPort.DataBind();
                //ddlEndPort.Items.Insert(0, new ListItem("请选择", ""));
                //ddlEndPort.SelectedIndex = 0;
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
        /// 绑定燃润列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        private void BindReport(int pageSize, int pageIndex)
        {
            try
            {
                //string qShipName = tbShipName.Text;
                //string qStartDate = tbStartDate.Text;
                //string qEndDate = tbEndDate.Text;
                //string qStartPort = ddlStartPort.SelectedValue;
                //string qEndPort = ddlEndPort.SelectedValue;
                string qShipName = string.Empty;
                string qStartDate = string.Empty;
                string qEndDate = string.Empty;
                string qStartPort = string.Empty;
                string qEndPort = string.Empty;

                string shipID = MonthAndShipNavigate1.ShipID;
                if (string.IsNullOrEmpty(shipID) == false)
                {
                    ShipInfo sInfo = new Ship().GetByID(shipID);
                    qShipName = sInfo.Name;
                }
                string dateID = MonthAndShipNavigate1.DateID;

                DataSet ds = new HangciBaseInput().GetBaseInputList(dateID, qShipName, qStartDate, qEndDate, qStartPort, qEndPort, pageSize, pageIndex);
                gvReportList.DataSource = ds;
                gvReportList.DataBind();
                CustomDataSet cDS = ds as CustomDataSet;
                if (cDS == null)
                {
                    pGridV.TotalAmout = 0;
                    return;
                }
                pGridV.TotalAmout = cDS.TotalAmout;

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

        protected void pGridV_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindReport(pGridV.PageSize, pGridV.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }


        /// <summary>
        /// 列表命令处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvReportList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string hangciBaseID = e.CommandArgument.ToString();
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                if (e.CommandName.Equals("btnDelete"))
                {
                    new HangciBaseInput().Delete(hangciBaseID);
                    BindReport(pGridV.PageSize, 0);
                    ShowMsg("删除成功");
                }
                else
                {
                    Label lbVoyageID = (Label)gvr.FindControl("lbVoyageID");
                    string voyageID = lbVoyageID.Text;
                    string url = string.Format("RanrunInput.aspx?voyageIds={0}&baseId={1}", voyageID, hangciBaseID);
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
        #endregion

        #region 按钮
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BindReport(pGridV.PageSize, 0);
        //    }
        //    catch (ArgumentNullException aex)
        //    {
        //        ShowMsg(aex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMsg(ex.Message);
        //        Log(ex);
        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../Hangy/Hangci.aspx", false);
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

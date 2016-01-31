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
    public partial class ShipIncomeMonthReport : WebBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MonthAndShipNavigate1.OnSelectedChanged += new EventHandler(MonthAndShipNavigate1_OnSelectedChanged);
                if (!IsPostBack)
                {
                    TitleInitial("船舶月份收入汇总表", "船舶月份收入汇总表按月份统计船舶收入情况，点击船舶名称可以查看对应的船舶月份收入明细。");

                    string dateID = GetRequest("dateID");
                    if (string.IsNullOrEmpty(dateID) == false)
                    {
                        MonthAndShipNavigate1.DateID = dateID;
                    }

                    BindList();
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

        #region 搜索

        #region 月份和船舶选择
        protected void MonthAndShipNavigate1_OnSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                BindList();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindList();
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

        private void BindList()
        {
            string shipID = MonthAndShipNavigate1.ShipID;
            string dateID = MonthAndShipNavigate1.DateID;
            DataSet ds = new Ship().GetIncomeMonthReport(dateID, shipID, pGridV.PageSize, pGridV.CurrentPageIndex);
            CustomDataSet cDS = ds as CustomDataSet;
            gvList.DataSource = ds;
            gvList.DataBind();
            pGridV.TotalAmout = cDS.TotalAmout;
        }

        #endregion

        #region 列表操作
        double sumVoyage = 0;
        double sumContainner = 0;
        double sumLoad = 0;
        double sumRent = 0;
        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    decimal dLCL = Convert.ToDecimal(dv.Row["散货美元收入"]);
                    decimal dLCLR = Convert.ToDecimal(dv.Row["散货人民币收入"]);

                    decimal dFCL = Convert.ToDecimal(dv.Row["集装箱美元收入"]);
                    decimal dFCLR = Convert.ToDecimal(dv.Row["集装箱人民币收入"]);

                    decimal dRent = Convert.ToDecimal(dv.Row["出租美元收入"]);
                    decimal dRentR = Convert.ToDecimal(dv.Row["出租人民币收入"]);

                    Label lbTotalD = (Label)e.Row.FindControl("lbTotalD");
                    lbTotalD.Text = (dLCL + dFCL + dRent).ToString();
                    Label lbTotalR = (Label)e.Row.FindControl("lbTotalR");
                    lbTotalR.Text = (dLCLR + dFCLR + dRentR).ToString();
                    Label lbTotal = (Label)e.Row.FindControl("lbTotal");
                    Label lbTotalNO = (Label)e.Row.FindControl("lbTotalNO");

                    string shipID = dv.Row["ID"].ToString();
                    HyperLink hlShip = (HyperLink)e.Row.FindControl("hlShip");
                    ShipInfo sInfo = new Ship().GetByID(shipID);
                        string dateID = MonthAndShipNavigate1.DateID;
                    if (sInfo.LoadTypeEnum == ShipType.FCL)
                    {
                        hlShip.NavigateUrl = string.Format("FCLManageList.aspx?shipID={0}&dateID={1}", shipID, dateID);
                    }
                    else if (sInfo.LoadTypeEnum == ShipType.LCL)
                    {
                        hlShip.NavigateUrl = string.Format("LCLManageList.aspx?shipID={0}&dateID={1}", shipID, dateID);
                    }
                }
                if (e.Row.RowIndex >= 0)
                {
                    string strVoyage = e.Row.Cells[2].Text;
                    string strLoad = e.Row.Cells[3].Text;
                    string strContainner = e.Row.Cells[6].Text;
                    string strRent = e.Row.Cells[9].Text;

                    double result = 0;
                    bool isDouble = Double.TryParse(strVoyage, out result);
                    if (isDouble)
                    {
                        sumVoyage += Convert.ToDouble(strVoyage);
                    }
                    isDouble = Double.TryParse(strContainner, out result);
                    if (isDouble)
                    {
                        sumContainner += Convert.ToDouble(strContainner);
                    }
                    isDouble = Double.TryParse(strLoad, out result);
                    if (isDouble)
                    {
                        sumLoad += Convert.ToDouble(strLoad);
                    }
                    isDouble = Double.TryParse(strRent, out result);
                    if (isDouble)
                    {
                        sumRent += Convert.ToDouble(strRent);
                    }

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = "航次总计：" + sumVoyage.ToString() + "班";
                    e.Row.Cells[3].Text = "承运货量总计：" + sumLoad.ToString() + "吨";
                    e.Row.Cells[6].Text = "承运箱量总计：" + sumContainner.ToString() + "箱";
                    e.Row.Cells[9].Text = "出租天数总计：" + sumRent.ToString() + "天";
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

        #region 翻页
        protected void pGridV_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindList();
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        #endregion

    }
}

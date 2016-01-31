using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BLL = Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Sirc.SharpReport.BLL;


namespace SharpReportWeb.Hangy
{
    public partial class InsuranceOfFreightTransport : WebBasePage
    {
        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("货运险", "用户可以维护集货运险相关信息。");
                    BindYearList();
                    BindShip();
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
        #endregion

        #region 绑定列表
        private void BindList()
        {
            string year = rblYear.SelectedValue;
            string month = rblMoth.SelectedValue;
            if (year == "-1")
            {
                // 年份选择更多不进行任何操作
                return;
            }
            string dimID = new DimTime().GetIDByMonth(year, month);
            string shipID = rblShip.SelectedValue;
            DataSet ds = new BLL.InsuranceOfFreightTransport().GetList(year, month, shipID);
            rList.DataSource = ds;
            rList.DataBind();
            if (rList.Items.Count == 0)
            {
                trNull.Visible = true;
            }
        }

        /// <summary>
        /// 根据报表ID获取20万元柜的总数
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <returns></returns>
        protected int Get200kiloAmount(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return 0;
            }
            InsuranceOfFreightTransportInfo iInfo = new BLL.InsuranceOfFreightTransport().GetByID(id);
            return iInfo.ContainerList.Count;
        }
        #endregion

        #region 日期选择
        void BindYearList()
        {
            rblYear.Items.Clear();
            int year = DateTime.Now.Year;
            int step = 5;
            for (int i = 0; i < step; i++)
            {
                string strYear = (year - i).ToString();
                ListItem item = new ListItem(strYear, strYear);
                bool enable = (strYear == year.ToString());
                item.Selected = enable;
                rblYear.Items.Add(item);
            }
            rblYear.Items.Add(new ListItem("更多", "-1"));
            rblMoth.SelectedValue = DateTime.Now.Month.ToString();
        }

        protected void rblYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string yearValue = rblYear.SelectedValue;
                if (yearValue == "-1")
                {
                    // 加入3年
                    int year = DateTime.Now.Year;
                    // “更多”不计入
                    int step = rblYear.Items.Count + 3 - 1;
                    rblYear.Items.Clear();
                    for (int i = 0; i < step; i++)
                    {
                        string strYear = (year - i).ToString();
                        rblYear.Items.Add(new ListItem(strYear, strYear));
                    }
                    rblYear.Items.Add(new ListItem("更多", "-1"));
                }
                else
                {
                    // 定位到对应年份
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
        protected void rblDim_SelectedIndexChanged(object sender, EventArgs e)
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

        #region 船舶选择
        void BindShip()
        {
            IList<ShipInfo> sList = new Ship().GetList();
            rblShip.DataSource = sList;
            rblShip.DataBind();
            rblShip.Items.Insert(0, new ListItem("全部", string.Empty));
            rblShip.SelectedIndex = 0;
        }
        protected void rblShip_SelectedIndexChanged(object sender, EventArgs e)
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

        #region 列表操作
        protected void rList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnEdit")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("InsuranceOfFreightTransportInput.aspx?id=" + id, true);
                }
                if (e.CommandName == "btnDel")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    new BLL.InsuranceOfFreightTransport().Delete(id.ToString());
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

        protected void ExcelGenButton1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 新增
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string year = rblYear.SelectedValue;
            string month = rblMoth.SelectedValue;
            if (year == "-1")
            {
                // 年份选择更多不进行任何操作
                return;
            }
            string dimID = new DimTime().GetIDByMonth(year, month);
            Response.Redirect("InsuranceOfFreightTransportInput.aspx?dimID=" + dimID, true);
        }
        #endregion

    }
}

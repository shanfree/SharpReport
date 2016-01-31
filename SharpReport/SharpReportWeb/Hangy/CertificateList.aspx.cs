using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;

namespace SharpReportWeb.Hangy
{
    public partial class CertificateList : WebBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("证书记录汇总", "用户可以维护证书相关信息，并按年份形成报表。");
                    BindYearList();
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

        #region 列表绑定
        private void BindList()
        {
            string year = rblYear.SelectedValue;
            string month = "12";
            if (year == "-1")
            {
                // 年份选择更多不进行任何操作
                return;
            }
            string dimID = new DimTime().GetIDByMonth(year, month);
            DataSet ds = new CertificateFlee().GetList(year);
            rList.DataSource = ds;
            rList.DataBind();
            if (rList.Items.Count == 0)
            {
                trNull.Visible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimTimeID"></param>
        /// <returns></returns>
        protected string GetBeginDate(string dimTimeID)
        {
            if (string.IsNullOrEmpty(dimTimeID))
            {
                return string.Empty;
            }
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dimTimeID);
            return DateTime.Parse(dInfo.Year + "-01-01").ToString("yyyyMMddhh") + "00";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimTimeID"></param>
        /// <returns></returns>
        protected string GetEndDate(string dimTimeID)
        {
            if (string.IsNullOrEmpty(dimTimeID))
            {
                return string.Empty;
            }
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dimTimeID);
            return DateTime.Parse(dInfo.Year + "-12-31").ToString("yyyyMMdd") + "24";
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
            rblYear.SelectedValue = DateTime.Now.Year.ToString();
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

        #region 列表操作
        protected void rList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnEdit")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("CertificateInput.aspx?id=" + id, false);
                }
                if (e.CommandName == "btnDel")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    new CertificateFlee().Delete(id.ToString());
                }

                if (e.CommandName == "btnAdd")
                {
                    int dimTimeID = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("CertificateInput.aspx?dimID=" + dimTimeID, false);
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
            if (year == "-1")
            {
                // 年份选择更多不进行任何操作
                return;
            }
            string dimID = new DimTime().GetIDByMonth(year, "12");
            Response.Redirect("CertificateInput.aspx?dimID=" + dimID, false);
        }
        #endregion
    }
}

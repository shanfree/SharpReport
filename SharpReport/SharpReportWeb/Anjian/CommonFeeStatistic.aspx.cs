using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using System.Web.UI;

namespace SharpReportWeb.Anjian
{
    public partial class CommonFeeStatistic : WebBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("安监部费用年度汇总", "栏目按年度汇总安监部们各项费用的金额，并换算成等额人民币。");
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
            if (year == "-1")
            {
                // 年份选择更多不进行任何操作
                return;
            }
            cfs_List.Year = year;
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
        #endregion

    }
}

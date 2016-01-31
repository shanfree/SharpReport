using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using System.Data;
using System.Web.UI;
using SIRC.Framework.SharpMemberShip;

namespace SharpReportWeb.ChuanJ
{
    public partial class WuliaoStatistic : WebBasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("物料报表汇总统计", "栏目按照船舶汇总各个季度的物料报表的关键指标，用户可以点击下方的“查看报表构成”按钮查看指标的分解情况。");
                    BindYearList();
                    string dimID = GetRequest("dimID");
                    if (string.IsNullOrEmpty(dimID) == false)
                    {
                        DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dimID);
                        int selectYear = dInfo.Year;
                        ListItem item = rblYear.Items.FindByValue(selectYear.ToString());
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                        BindList(selectYear.ToString(), rblQuarter.SelectedValue);
                    }
                    else
                    {
                        BindList();
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

        #region 绑定物料报表
        /// <summary>
        /// 绑定物料报表
        /// </summary>
        private void BindList()
        {
            string year = rblYear.SelectedValue;
            string quarter = rblQuarter.SelectedValue;
            DataSet ds = new WuliaoInput().GetSumStatictis(year, quarter);
            gvWuliaoList.DataSource = ds;
            gvWuliaoList.DataBind();
        }
        /// <summary>
        /// 绑定物料报表
        /// </summary>
        /// <param name="year">报表的年份，为空显示所有年份</param>
        /// <param name="QuarterID">报表对应的季度，为空显示所有的季度</param>
        private void BindList(string year, string quarter)
        {
            DataSet ds = new WuliaoInput().GetSumStatictis(year, quarter);
            gvWuliaoList.DataSource = ds;
            gvWuliaoList.DataBind();
        }

        #endregion

        #region 年份选择
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

        #region 季度选择
        protected void rblQuarter_SelectedIndexChanged(object sender, EventArgs e)
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
        protected void ExcelGenButton1_Click(object sender, EventArgs e)
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

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                string year = rblYear.SelectedValue;
                string quarter = rblQuarter.SelectedValue;
                string dimID = new DimTime().GetIDByQuarter(year, quarter);
                if (string.IsNullOrEmpty(dimID))
                {
                    dimID = new DimTime().GetIDByMonth(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
                }
                string url = "WuliaoSummary.aspx?dimID=" + dimID;
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

    }
}

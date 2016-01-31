using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using System.Data;
using System.Web.UI;

namespace SharpReportWeb.ChuanJ
{
    public partial class XiuliSummary : WebBasePage
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
        #endregion

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("修理报表报送情况", "用户可以点击具体指标，查看其按船舶报送时间分解的具体值。");
                    BindYearList();
                    BindShip();
                    this.DimID = GetRequest("dimID");
                    if (string.IsNullOrEmpty(this.DimID) == false)
                    {
                        DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(this.DimID);
                        int selectYear = dInfo.Year;
                        ListItem item = rblYear.Items.FindByValue(selectYear.ToString());
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                        BindList(selectYear.ToString(), rblShip.SelectedValue);
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
        /// <summary>
        /// 绑定物料报表
        /// </summary>
        private void BindList()
        {
            string year = rblYear.SelectedValue;
            string shipID = rblShip.SelectedValue;
            DataSet ds = new XiuliInput().GetCountStatictis(year, shipID);
            gvXiuliList.DataSource = ds;
            gvXiuliList.DataBind();
        }
        /// <summary>
        /// 绑定物料报表
        /// </summary>
        /// <param name="year">报表的年份，为空显示所有年份</param>
        /// <param name="shipID">报表对应的船舶，为空显示所有的船舶</param>
        private void BindList(string year, string shipID)
        {
            DataSet ds = new XiuliInput().GetCountStatictis(year, shipID);
            gvXiuliList.DataSource = ds;
            gvXiuliList.DataBind();
        }

        protected void gvXiuliList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dv = e.Row.DataItem as DataRowView;
                    // 选择控件，传入收件的事务主键，用来更新
                    RadioButton rbSel = (RadioButton)e.Row.FindControl("rbSel");
                    rbSel.Attributes.Add("onclick", "Sel('" + dv.Row["ID"] + "')");
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

        #region 新增报表
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string dimID = lbID.Value;
                if (string.IsNullOrEmpty(dimID))
                {
                    dimID = new DimTime().GetIDByMonth(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
                }
                string url = "XiuliinputPage.aspx?dimID=" + dimID;
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

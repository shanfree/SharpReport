using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;

namespace SharpReportWeb.WUC
{
    public partial class WUC_MonthAndShipNavigate : System.Web.UI.UserControl
    {
        #region 属性
        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            get
            {
                return rblYear.SelectedValue;
            }
            set
            {
                rblYear.SelectedValue = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Month
        {
            get
            {
                return rblMoth.SelectedValue;
            }
            set
            {
                rblMoth.SelectedValue = value;
            }
        }
        /// <summary>
        /// 选择的报告期ID
        /// </summary>
        public string DateID
        {
            get
            {
                string month = rblMoth.SelectedValue;
                string year = rblYear.SelectedValue;
                if (string.IsNullOrEmpty(month))
                {
                    return string.Empty;
                }
                return new DimTime().GetIDByMonth(year, month);
            }
            set
            {
                string dateID = value;
                DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(dateID);
                rblMoth.SelectedValue = dInfo.MonthNumOfYear.ToString();
                rblYear.SelectedValue = dInfo.Year.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ShipID
        {
            get
            {
                return rblShip.SelectedValue;
            }
            set
            {
                rblShip.SelectedValue = value;
            }
        }
        private bool _IsShowMonthAll = true;
        /// <summary>
        /// 是否显示全部月份选项
        /// </summary>
        public bool IsShowMonthAll
        {
            get
            {
                return _IsShowMonthAll;
            }
            set
            {
                _IsShowMonthAll = value;
            }
        }
        private bool _isShowShipAll = true;
        /// <summary>
        /// 是否显示全部船舶选项
        /// </summary>
        public bool IsShowShipAll
        {
            get
            {
                return _isShowShipAll;
            }
            set
            {
                _isShowShipAll = value;
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindYearList();
                    BindShip();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

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
            if (this.IsShowMonthAll == false)
            {
                rblMoth.Items.RemoveAt(0);
                rblMoth.SelectedValue = DateTime.Now.Month.ToString();
            }
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
                    SelectedChanged();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void rblDim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedChanged();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 船舶选择
        void BindShip()
        {
            IList<ShipInfo> sList = new Ship().GetList();
            rblShip.DataSource = sList;
            rblShip.DataBind();
            if (IsShowShipAll)
            {
                rblShip.Items.Insert(0, new ListItem("全部", string.Empty));
            }
            if (rblShip.Items != null && rblShip.Items.Count > 0)
            {
                rblShip.SelectedIndex = 0;
            }
        }
        protected void rblShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedChanged();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 事件
        public event EventHandler OnSelectedChanged;
        protected void SelectedChanged()
        {
            if (OnSelectedChanged != null)
            {
                EventArgs e = new EventArgs();
                OnSelectedChanged(this, e);
            }
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
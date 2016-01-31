using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BLL = Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using System.Data;
using System.Web.UI;
using Sirc.SharpReport.BLL;

namespace SharpReportWeb.Hangy
{
    public partial class InsuranceOfFreightTransportInput : WebBasePage
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
        /// ID
        /// </summary>
        private string ID
        {
            get
            {
                return GetViewState("ID");
            }
            set
            {
                ViewState["ID"] = value;
                InvoiceList1.KeyID = this.ID;
                InvoiceList1.MenuID = this.MenuID;
            }
        }
        /// <summary>
        /// ID
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
        /// <summary>
        /// 汇率主键
        /// </summary>
        private string RateID
        {
            get
            {
                return GetViewState("RateID");
            }
            set
            {
                ViewState["RateID"] = value;
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
                    TitleInitial("内贸线货运险投保货量及保费输入", "用户可以维护内贸线货运险投保货量及保费输入相关信息。");
                    this.DimID = GetRequest("dimID");
                    string shipID = string.Empty;
                    BindShip(shipID);
                    BindCurrency();
                    this.ID = GetRequest("ID");
                    InsuranceOfFreightTransportInfo wInfo = new InsuranceOfFreightTransportInfo();
                    if (string.IsNullOrEmpty(this.ID) == false)
                    {
                        wInfo = new BLL.InsuranceOfFreightTransport().GetByID(this.ID);
                    }
                    SetPageValue(wInfo);
                    BindRate();
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
        #region 航次和船名
        private void BindShip(string shipID)
        {
            IList<ShipInfo> sList = new Ship().GetList();
            ddlShip.DataSource = sList;
            ddlShip.DataBind();
            if (string.IsNullOrEmpty(shipID) == false)
            {
                ddlShip.SelectedValue = shipID;
            }
            else
            {
                shipID = ddlShip.Items[0].Value;
            }
            BindVoyage(shipID);
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string shipID = ddlShip.SelectedValue;
                BindVoyage(shipID);
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

        private void BindVoyage(string shipID)
        {
            IList<VoyageInfo> sList = new Voyage().GetListByShipID(shipID);
            if (null == sList || sList.Count == 0)
            {
                sList = new List<VoyageInfo>();
                VoyageInfo vInfo = new VoyageInfo();
                vInfo.Name = "未关联到任何航次";
                sList.Add(vInfo);
            }
            ddlVoyage.DataSource = sList;
            ddlVoyage.DataBind();
        }

        //protected void ddlVoyage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string voyageID = ddlVoyage.SelectedValue;
        //        VoyageInfo eInfo = new Voyage().GetByID(voyageID, false, true);
        //        ddlShip.SelectedValue = eInfo.ShipID;
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
        #endregion

        #region 币种和汇率
        private void BindCurrency()
        {
            IList<CurrencyInfo> cList = new Currency().GetList();
            ddlCurrency.DataSource = cList;
            ddlCurrency.DataBind();
            ddlCurrency.SelectedIndex = 0;
        }
        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindRate();
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
        /// 绑定汇率
        /// </summary>
        private void BindRate()
        {
            string year = ddlYear.SelectedValue;
            string month = ddlMonth.SelectedValue;
            string dimID = new DimTime().GetIDByMonth(year, month);
            string currencyID = ddlCurrency.SelectedValue;
            ExchangeRateInfo eInfo = new ExchangeRate().GetInfo(currencyID, dimID);
            lbRate.Text = eInfo.Rate;
            this.RateID = eInfo.ID;
        }
        #endregion

        #endregion

        #region 设置页面值
        /// <summary>
        /// 根据页面实体设置页面值
        /// </summary>
        /// <param name="wInfo"></param>
        private void SetPageValue(InsuranceOfFreightTransportInfo wInfo)
        {
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();
            tbYear.Text = wInfo.CreateTime.Year.ToString();
            tbMonth.Text = wInfo.CreateTime.Month.ToString();
            if (string.IsNullOrEmpty(wInfo.ID))
            {
                return;
            }
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(wInfo.DimTimeID);
            tbMonth.Text = dInfo.MonthNumOfYear.ToString();
            tbYear.Text = dInfo.Year.ToString();

            ddlVoyage.SelectedValue = wInfo.VoyageID;
            VoyageInfo vInfo = new Voyage().GetByID(wInfo.VoyageID);
            ddlShip.SelectedValue = vInfo.ShipID.ToString();
            ddlCurrency.SelectedValue = wInfo.CurrencyID;
            ddlYear.SelectedValue = dInfo.Year.ToString();
            ddlMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();

            tb20英尺.Text = wInfo.Amount50kilo20feet;
            tb40英尺.Text = wInfo.Amount50kilo40feet;
            BindList(this.ID);

            tb总保费.Text = wInfo.总保费;
            lb总重柜量.Text = wInfo.总重柜量;
            tb备注.Text = wInfo.备注;
        }
        #endregion

        #region 列表操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void BindList(string id)
        {
            IList<ContainerInfo> cList = new Container().GetList(id);
            ContainerInfo cInfo = new ContainerInfo();
            cList.Add(cInfo);
            gvList.DataSource = cList;
            gvList.DataBind();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList rblType = (RadioButtonList)e.Row.FindControl("rblType");
                ContainerInfo cInfo = e.Row.DataItem as ContainerInfo;
                rblType.SelectedValue = cInfo.货柜类型;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvr = (GridViewRow)gvList.Rows[index];
                HiddenField hfRelateId = (HiddenField)gvr.FindControl("hidRelateId");
                string relateId = hfRelateId.Value.ToString();

                if (e.CommandName == "btnDel")
                {
                    new Container().Delete(relateId);
                }
                else
                {
                    #region 控件
                    RadioButtonList rblType = (RadioButtonList)gvr.FindControl("rblType");
                    TextBox tb投保金额 = (TextBox)gvr.FindControl("tb投保金额");
                    TextBox tb编号 = (TextBox)gvr.FindControl("tb编号");
                    TextBox tb备注 = (TextBox)gvr.FindControl("tb备注");
                    #endregion

                    ContainerInfo info = new ContainerInfo();
                    info.投保金额 = tb投保金额.Text;
                    info.备注 = tb备注.Text;
                    info.编号 = tb编号.Text;
                    info.货柜类型 = rblType.SelectedValue; ;
                    info.ID = relateId;
                    info.InsuranceID = this.ID;

                    if (e.CommandName == "btnEdit")
                    {
                        new Container().Update(info);
                        ShowMsg("更新成功！");
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new Container().Add(info);
                    }
                }
                BindList(this.ID);
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

        #region 控件操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                InsuranceOfFreightTransportInfo wInfo = new InsuranceOfFreightTransportInfo();
                if (string.IsNullOrEmpty(this.ID) == false)
                {
                    wInfo = new BLL.InsuranceOfFreightTransport().GetByID(this.ID);
                }

                wInfo.VoyageID = ddlVoyage.SelectedValue;
                wInfo.InputUserID = this.UserCacheInfo.ID;
                string year = tbYear.Text;
                string month = tbMonth.Text;
                string dimTimeID = new DimTime().GetIDByMonth(year, month);
                wInfo.DimTimeID = dimTimeID;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;
                wInfo.ExchangeRateID = this.RateID;
                wInfo.Amount50kilo20feet = tb20英尺.Text;
                wInfo.Amount50kilo40feet = tb40英尺.Text;
                wInfo.备注 = tb备注.Text;

                tb总保费.Text = wInfo.总保费;
                lb总重柜量.Text = wInfo.总重柜量;

                if (string.IsNullOrEmpty(this.ID) == true)
                {
                    this.ID = new BLL.InsuranceOfFreightTransport().Add(wInfo);
                    wInfo.ID = this.ID;
                    SetPageValue(wInfo);
                }
                else
                {
                    new BLL.InsuranceOfFreightTransport().Update(wInfo);
                }
                ShowMsg("报表保存成功。");
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

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.ID;
                if (string.IsNullOrEmpty(id) == true)
                {
                    ShowMsg("未选定任何报表。");
                    return;
                }
                new BLL.InsuranceOfFreightTransport().Delete(id);
                ShowMsg("报表删除成功。");
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

        #region 返回统计页面
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "InsuranceOfFreightTransport.aspx";
                Response.Redirect(url, true);
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

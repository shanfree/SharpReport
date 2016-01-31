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
using WebControlLib = SIRC.Framework.WebControlLib;

namespace SharpReportWeb.Hangy
{
    public partial class CertificateInput : WebBasePage
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
                    TitleInitial("证书记录汇总", "用户可以维护证书相关信息，并按年份形成报表。");
                    this.DimID = GetRequest("dimID");
                    this.ID = GetRequest("ID");
                    tbYear.Text = DateTime.Now.Year.ToString();
                    tbUserName.Text = this.UserCacheInfo.Name;
                    tbCreateTime.Text = DateTime.Now.ToShortDateString();
                    CertificateFleeInfo wInfo = new CertificateFleeInfo();
                    if (string.IsNullOrEmpty(this.ID) == false)
                    {
                        wInfo = new CertificateFlee().GetByID(this.ID);
                        SetPageValue(wInfo);
                    }
                    BindCurrency();
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
        private void SetPageValue(CertificateFleeInfo wInfo)
        {
            DimTimeInfo dInfo = new DimTime().GetDimTimeInfo(wInfo.DimTimeID);
            tbYear.Text = dInfo.Year.ToString();
            tbUserName.Text = this.UserCacheInfo.Name;
            tbCreateTime.Text = wInfo.CreateTime.ToShortDateString();

            ddlCurrency.SelectedValue = wInfo.CurrencyID;
            ddlYear.SelectedValue = dInfo.Year.ToString();
            ddlMonth.SelectedValue = dInfo.MonthNumOfYear.ToString();

            c发证日期.Text = wInfo.发证日期.ToShortDateString();
            c有效期至.Text = wInfo.有效期至.ToShortDateString();
            c年审有效日期.Text = wInfo.年审有效日期.ToShortDateString();
            tb项目名称.Text = wInfo.项目名称;
            rblType.SelectedValue = wInfo.证书类型;
            tb快递费.Text = wInfo.快递费;
            tb图纸复印费.Text = wInfo.图纸复印费;
            tb洗照片.Text = wInfo.洗照片;
            tb公正.Text = wInfo.公正;
            tb其他.Text = wInfo.其他;
            tb备注.Text = wInfo.备注;
        }
        #endregion

        #region 控件操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.ID;
                CertificateFleeInfo wInfo = new CertificateFleeInfo();
                if (string.IsNullOrEmpty(id) == false)
                {
                    wInfo = new CertificateFlee().GetByID(id);
                }

                wInfo.InputUserID = this.UserCacheInfo.ID;
                string year = tbYear.Text;
                string dimTimeID = new DimTime().GetIDByMonth(year, "12");
                wInfo.DimTimeID = dimTimeID;
                wInfo.CurrencyID = ddlCurrency.SelectedValue;
                wInfo.ExchangeRateID = this.RateID;

                wInfo.发证日期 = DateTime.Parse(c发证日期.Text);
                wInfo.有效期至 = DateTime.Parse(c有效期至.Text);
                wInfo.年审有效日期 = DateTime.Parse(c年审有效日期.Text);
                wInfo.项目名称 = tb项目名称.Text;
                wInfo.证书类型 = rblType.SelectedValue;
                wInfo.快递费 = tb快递费.Text;
                wInfo.图纸复印费 = tb图纸复印费.Text;
                wInfo.洗照片 = tb洗照片.Text;
                wInfo.公正 = tb公正.Text;
                wInfo.其他 = tb其他.Text;
                wInfo.备注 = tb备注.Text;

                if (string.IsNullOrEmpty(id) == true)
                {
                    this.ID = new CertificateFlee().Add(wInfo);
                    wInfo.ID = this.ID;
                    SetPageValue(wInfo);
                }
                else
                {
                    new CertificateFlee().Update(wInfo);
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
                new CertificateFlee().Delete(id);
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
                string url = "CertificateList.aspx";
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

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Sirc.SharpReport;
using Sirc.SharpReport.Model;
using Sirc.SharpReport.BLL;
using SIRC.Framework.SharpMemberShip;
using SharpReportWeb.Base;

namespace SharpReportWeb.ChuanJ
{
    public partial class MonthReport : WebBasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bindYear();
                    bindDv(DateTime.Now.Year.ToString(),"01");
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

        private void bindYear()
        {
            int year = Convert.ToInt32(DateTime.Now.Year);
            int y = 0;
            for (int i = 2013; i < year + 1; i++)
            {
                qYear.Items.Insert(y,new ListItem(i.ToString(), i.ToString()));
                y++;
            }
            qYear.SelectedValue = year.ToString();
        }

        private void bindDv(string year, string month)
        {
            DataTable dtData = new DataTable();
            HangciBaseInput hcbi = new HangciBaseInput();

            dtData = hcbi.GetMonthlyReportData(year, month);

            DataTable dt = new DataTable();
            dt.Columns.Add("serialNo");
            dt.Columns.Add("shipName");
            dt.Columns.Add("fujiGo");
            dt.Columns.Add("fujiFo");
            dt.Columns.Add("zhujiGo");
            dt.Columns.Add("zhujiFo");
            dt.Columns.Add("guoluGo");
            dt.Columns.Add("guoluFo");
            dt.Columns.Add("other");
            dt.Columns.Add("sumup");
            dt.Columns.Add("zhongYouBi");
            dt.Columns.Add("fujiDay");
            dt.Columns.Add("zhujiDay");
            dt.Columns.Add("distance");
            dt.Columns.Add("tonPerKilo");
            dt.Columns.Add("fujiTonDay");
            dt.Columns.Add("zhujiTonDay");
            dt.Columns.Add("distanDay");
            dt.Columns.Add("TonPerKilo2");
            dt.Columns.Add("beginDate");
            dt.Columns.Add("endDate");

            string shipId = "";
            int serialno = 1;
            double distance = 0;
            double kgkilo = 10000;//未知暂用10000

            //用于计算重油比
            double fo = 0.0;
            double go = 0.0;

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                string tmpShipId = dtData.Rows[i]["shipId"].ToString();

                //第一条
                if (!tmpShipId.Equals(shipId))
                {
                    fo = 0.0;
                    go = 0.0;

                    shipId = tmpShipId;
                    distance = Convert.ToDouble(dtData.Rows[i]["distance"].ToString());

                    DataRow dr = dt.NewRow();
                    dr["serialNo"] = serialno;
                    dr["shipName"] = dtData.Rows[i]["shipName"].ToString();
                    dr["distance"] = distance;
                    dr["beginDate"] = dtData.Rows[i]["beginDate"].ToString();
                    dr["endDate"] = dtData.Rows[i]["endDate"].ToString();

                    dr["fujiGo"] = "0";
                    dr["fujiFo"] = "0";
                    dr["zhujiGo"] = "0";
                    dr["zhujiFo"] = "0";
                    dr["guoluGo"] = "0";
                    dr["guoluFo"] = "0";
                    dr["other"] = "0";
                    dr["sumup"] = "0";
                    dr["zhongYouBi"] = "0";
                    dr["fujiDay"] = "0";
                    dr["zhujiDay"] = "0";
                    dr["tonPerKilo"] = "未知暂用10000";
                    dr["fujiTonDay"] = "0";
                    dr["zhujiTonDay"] = "0";
                    dr["distanDay"] = "0";
                    dr["TonPerKilo2"] = "0";

                    //主机
                    string componentid = dtData.Rows[i]["ShipComponentID"].ToString();
                    if (componentid.Equals("1"))
                    {
                        double diesel = Convert.ToDouble(dtData.Rows[i]["DieselConsume"].ToString());
                        double fuel = Convert.ToDouble(dtData.Rows[i]["FuelConsume"].ToString());
                        double other = Convert.ToDouble(dtData.Rows[i]["OtherConsume"].ToString());
                        double zhujiday = Convert.ToDouble(dtData.Rows[i]["MainSlowWorkTime"].ToString()) +
                                          Convert.ToDouble(dtData.Rows[i]["MainCruiseWorkTime"].ToString()) +
                                          Convert.ToDouble(dtData.Rows[i]["VoyageWorkTime"].ToString());

                        fo += fuel;
                        go += diesel;

                        dr["zhujiGo"] = diesel.ToString();
                        dr["zhujiFo"] = fuel.ToString();
                        dr["zhujiDay"] = zhujiday.ToString();
                        dr["other"] = other.ToString();
                        dr["sumup"] = (diesel + fuel + other).ToString();
                        dr["zhujiTonDay"] = Math.Round(((diesel + fuel) / zhujiday),2).ToString();
                        dr["distanDay"] = Math.Round((1000 * (diesel + fuel + other) / distance),2).ToString();
                        dr["TonPerKilo2"] = Math.Round((1000 * (diesel + fuel + other) / kgkilo),2).ToString();
                        
                    }
                    dt.Rows.Add(dr);
                    serialno++;
                }
                else
                {
                    //辅机
                    string componentid = dtData.Rows[i]["ShipComponentID"].ToString();
                    if (componentid.Equals("2") || componentid.Equals("3") || componentid.Equals("4"))
                    {
                        double diesel = Convert.ToDouble(dtData.Rows[i]["DieselConsume"].ToString());
                        double fuel = Convert.ToDouble(dtData.Rows[i]["FuelConsume"].ToString());
                        double other = Convert.ToDouble(dtData.Rows[i]["OtherConsume"].ToString());
                        double fujiday = Convert.ToDouble(dtData.Rows[i]["MainSlowWorkTime"].ToString()) +
                                          Convert.ToDouble(dtData.Rows[i]["MainCruiseWorkTime"].ToString()) +
                                          Convert.ToDouble(dtData.Rows[i]["VoyageWorkTime"].ToString());

                        double orgfujiGo = Convert.ToDouble(dt.Rows[serialno - 2]["fujiGo"].ToString());//dt.Columns.Add("fujiGo");
                        double orgfujiFo = Convert.ToDouble(dt.Rows[serialno - 2]["fujiFo"].ToString());
                        double orgOther = Convert.ToDouble(dt.Rows[serialno - 2]["other"].ToString());
                        double orgsumup = Convert.ToDouble(dt.Rows[serialno - 2]["sumup"].ToString());
                        double orgfujiDay = Convert.ToDouble(dt.Rows[serialno - 2]["fujiDay"].ToString());

                        fo += fuel;
                        go += diesel;

                        dt.Rows[serialno - 2]["fujiGo"] = (orgfujiGo + diesel).ToString();
                        dt.Rows[serialno - 2]["fujiFo"] = (orgfujiFo + fuel).ToString();
                        dt.Rows[serialno - 2]["other"] = (orgOther + other).ToString();
                        dt.Rows[serialno - 2]["sumup"] = (orgsumup + fuel + diesel + other).ToString();
                        dt.Rows[serialno - 2]["fujiDay"] = (orgfujiDay + fujiday).ToString();
                        dt.Rows[serialno - 2]["fujiTonDay"] = Math.Round((orgfujiFo + fuel) / (orgfujiDay + fujiday),2).ToString();
                        dt.Rows[serialno - 2]["distanDay"] = Math.Round((1000 * (orgsumup + fuel + orgOther) / distance),2).ToString();
                        dt.Rows[serialno - 2]["TonPerKilo2"] = Math.Round((1000 * (orgsumup + fuel + orgOther) / kgkilo),2).ToString();
                    }
                    //锅炉
                    if (dtData.Rows[i]["ShipComponentID"].ToString().Equals("5"))
                    {
                        double diesel = Convert.ToDouble(dtData.Rows[i]["DieselConsume"].ToString());
                        double fuel = Convert.ToDouble(dtData.Rows[i]["FuelConsume"].ToString());
                        double other = Convert.ToDouble(dtData.Rows[i]["OtherConsume"].ToString());

                        double orgOther = Convert.ToDouble(dt.Rows[serialno - 2]["other"].ToString());
                        double orgsumup = Convert.ToDouble(dt.Rows[serialno - 2]["sumup"].ToString());

                        fo += fuel;
                        go += diesel;

                        dt.Rows[serialno - 2]["guoluGo"] = diesel.ToString();
                        dt.Rows[serialno - 2]["guoluFo"] = fuel.ToString();
                        dt.Rows[serialno - 2]["other"] = (orgOther + other).ToString();
                        dt.Rows[serialno - 2]["sumup"] = (orgsumup + + diesel + fuel + other).ToString();
                        dt.Rows[serialno - 2]["distanDay"] = Math.Round((1000 * (orgsumup + +diesel + fuel + other) / distance),2).ToString();
                        dt.Rows[serialno - 2]["TonPerKilo2"] = Math.Round((1000 * (orgsumup + fuel + orgOther) / kgkilo),2).ToString();

                        dt.Rows[serialno - 2]["zhongYouBi"] = Math.Round(fo * 100 / (fo + go),2).ToString();
                    }

                }
            }

            DataRow dr2 = dt.NewRow();
            dr2["serialNo"] = "";
            dr2["shipName"] = "";
            dr2["distance"] = "";
            dr2["beginDate"] = "";
            dr2["endDate"] = "";

            dr2["fujiGo"] = "";
            dr2["fujiFo"] = "";
            dr2["zhujiGo"] = "";
            dr2["zhujiFo"] = "";
            dr2["guoluGo"] = "";
            dr2["guoluFo"] = "";
            dr2["other"] = "";
            dr2["sumup"] = "";
            dr2["zhongYouBi"] = "";
            dr2["fujiDay"] = "";
            dr2["zhujiDay"] = "";
            dr2["tonPerKilo"] = "";
            dr2["fujiTonDay"] = "";
            dr2["zhujiTonDay"] = "";
            dr2["distanDay"] = "";
            dr2["TonPerKilo2"] = "";

            double allzhujiDo = 0;
            double allzhujiFo = 0;
            double allguoluDo = 0;
            double allguoluFo = 0;
            double allsumup = 0;
            double alldistance = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                allzhujiDo += Convert.ToDouble(dt.Rows[i]["zhujiGo"].ToString());
                allzhujiFo += Convert.ToDouble(dt.Rows[i]["zhujiFo"].ToString());
                allguoluDo += Convert.ToDouble(dt.Rows[i]["guoluGo"].ToString());
                allguoluFo += Convert.ToDouble(dt.Rows[i]["guoluFo"].ToString());
                allsumup += Convert.ToDouble(dt.Rows[i]["sumup"].ToString());
                alldistance += Convert.ToDouble(dt.Rows[i]["distance"].ToString());
            }
            dr2["zhujiGo"] = allzhujiDo.ToString();
            dr2["zhujiFo"] = allzhujiFo.ToString();
            dr2["guoluGo"] = allguoluDo.ToString();
            dr2["guoluFo"] = allguoluFo.ToString();
            dr2["sumup"] = allsumup.ToString();
            dr2["distance"] = alldistance.ToString();
            dr2["TonPerKilo2"] = Math.Round(1000 * (allsumup / kgkilo), 2).ToString();

            DataRow dr3 = dt.NewRow();
            dr3["serialNo"] = "";
            dr3["shipName"] = "";
            dr3["distance"] = "";
            dr3["beginDate"] = "";
            dr3["endDate"] = "";

            dr3["fujiGo"] = "";
            dr3["fujiFo"] = "";
            dr3["zhujiGo"] = "";
            dr3["zhujiFo"] = "";
            dr3["guoluGo"] = "";
            dr3["guoluFo"] = "";
            dr3["other"] = "";
            dr3["sumup"] = "";
            dr3["zhongYouBi"] = "";
            dr3["fujiDay"] = "";
            dr3["zhujiDay"] = "";
            dr3["tonPerKilo"] = "";
            dr3["fujiTonDay"] = "";
            dr3["zhujiTonDay"] = "";
            dr3["distanDay"] = "";
            dr3["TonPerKilo2"] = "";
            dt.Rows.Add(dr3);

            dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["serialNo"] = "";
            dr4["shipName"] = "";
            dr4["distance"] = "";
            dr4["beginDate"] = "";
            dr4["endDate"] = "";

            dr4["fujiGo"] = "";
            dr4["fujiFo"] = "";
            dr4["zhujiGo"] = "";
            dr4["zhujiFo"] = "";
            dr4["guoluGo"] = "";
            dr4["guoluFo"] = "";
            dr4["other"] = "";
            dr4["sumup"] = "";
            dr4["zhongYouBi"] = "";
            dr4["fujiDay"] = "";
            dr4["zhujiDay"] = "";
            dr4["tonPerKilo"] = "";
            dr4["fujiTonDay"] = "";
            dr4["zhujiTonDay"] = "";
            dr4["distanDay"] = "";
            dr4["TonPerKilo2"] = "";
            dt.Rows.Add(dr4);

            gvMonthlyReport.DataSource = dt;
            gvMonthlyReport.DataBind();
        }

        protected void gvMonthlyReport_RowCreated(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    string headerText = "序号,船舶," +
                       "油耗量（吨）|辅机|GO|A,油耗量（吨）|辅机|FO|A,油耗量（吨）|主机|GO|B,油耗量（吨）|主机|FO|C,油耗量（吨）|锅炉|GO|D,油耗量（吨）|锅炉|FO|E," +
                       "油耗量（吨）|其他|F,油耗量（吨）|合计|G=A+B+C+D+E+F,油耗量（吨）|重油比|H," +
                       "运行时间（天）|辅机|I,运行时间（天）|主机|J,航行海里|K,千吨海里|L," +
                       "平均消耗量|辅机（吨/天）|M=A/I,平均消耗量|主机（吨/天）|N=（B+C）/J,平均消耗量|航行海里（KG）|O=G/K*1000,平均消耗量|千吨海里（KG）|P=G/L*1000," +
                       "统计开始时间,统计结束时间";

                    DynamicTHeaderHepler dHelper = new DynamicTHeaderHepler();
                    dHelper.genHeader(headerText,gvMonthlyReport, sender, e);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string year = qYear.SelectedValue;
                string month = qMonth.SelectedValue;
                bindDv(year, month);
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
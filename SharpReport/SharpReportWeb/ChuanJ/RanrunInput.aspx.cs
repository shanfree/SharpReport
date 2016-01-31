using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;

namespace SharpReportWeb.ChuanJ
{
    public partial class RanrunInput : WebBasePage
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
        /// 报表 ID
        /// </summary>
        private string ReportID
        {
            get
            {
                return GetViewState("baseId");
            }
            set
            {
                ViewState["baseId"] = value;
            }
        }
        /// <summary>
        /// 航次 ID
        /// </summary>
        private string VoyageIds
        {
            get
            {
                return GetViewState("VoyageIds");
            }
            set
            {
                ViewState["VoyageIds"] = value;
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
                    TitleInitial("燃润料报表列表", "编辑航次相關燃润料报表，用户可以使用“添加油料”按钮跳转到油料添加報表栏目，完善途经港口加油记录。");
                    this.VoyageIds = GetRequest("voyageIds");
                    this.ReportID = GetRequest("baseId");

                    if (string.IsNullOrEmpty(this.ReportID))
                    {
                        if (string.IsNullOrEmpty(this.VoyageIds))
                        {
                            ShowMsg("请指定报表或者报表相关的航次。");
                            return;
                        }
                        HangciBaseInput hcbi = new HangciBaseInput();
                        HangciBaseInputInfo hcbii = new HangciBaseInputInfo();

                        hcbii.ShipInputDate = DateTime.Now;
                        hcbii.GeneralManagerDate = DateTime.Now;

                        this.ReportID = hcbi.Add(hcbii);
                        new Voyage().UpdateVoyage(this.VoyageIds, this.ReportID);
                    }

                    BindData(this.ReportID);
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

        private void BindData(string reportID)
        {
            try
            {
                double diffHrs = 0;
                string voyageName = "";
                // 距离（海里）
                string distance = "";
                // 经停港
                string totalRoute = string.Empty;
                double sumDistance = 0;
                string shipName = "";
                string sTime = "";
                string eTime = "";
                string sPort = "";
                string ePort = "";
                string captain = "";
                string chiefEngineer = "";
                string generalManager = "";
                DateTime temp = new DateTime();

                IList<VoyageInfo> vList = new Voyage().GetVoyageListByReportID(reportID);
                string voyageIds = string.Empty;
                for (int i = 0; i < vList.Count; i++)
                {
                    VoyageInfo vInfo = vList[i];
                    voyageIds += "," + vInfo.ID;
                    RouteInfo rInfo = new Route().GetByID(vInfo.RouteID.ToString());
                    if (i == 0)
                    {
                        shipName = vInfo.ShipName;
                        sTime = vInfo.BeginDate.ToString("yyyy-MM-dd hh:mm");
                        sPort = vInfo.sName;
                        captain = vInfo.Captain;
                        chiefEngineer = vInfo.ChiefEngineer;
                        generalManager = vInfo.GeneralManager;
                    }

                    voyageName += " + " + vInfo.Name;
                    distance += " + " + vInfo.Distance;
                    totalRoute += " + " + rInfo.TotalRoute;
                    sumDistance += vInfo.Distance; ;
                    eTime = vInfo.EndDate.ToString("yyyy-MM-dd hh:mm");
                    diffHrs += vInfo.DiffHours;

                    if (Convert.ToDateTime(eTime) > temp)
                    {
                        temp = Convert.ToDateTime(eTime);
                        ePort = vInfo.eName;
                    }
                }
                this.VoyageIds = voyageIds.Substring(1);
                voyageName = string.IsNullOrEmpty(voyageName) ? string.Empty : voyageName.Substring(3);
                distance = string.IsNullOrEmpty(distance) ? string.Empty : distance.Substring(3);
                totalRoute = string.IsNullOrEmpty(totalRoute) ? string.Empty : totalRoute.Substring(3);

                // 显示总里程
                if (vList.Count > 1)
                {
                    distance += " = " + sumDistance.ToString();
                }

                lblVoyage.Text = voyageName;
                lblDistance.Text = distance + " " + totalRoute;
                lblShipName.Text = shipName;
                lblStartTime.Text = sTime;
                lblStartPort.Text = sPort;
                lblEndTime.Text = eTime;
                lblEndPort.Text = ePort;
                ViewState["diffHrs"] = diffHrs.ToString();

                HangciBaseInputInfo ii = new HangciBaseInput().GetByID(reportID);
                cCaptainDate.Text = ii.ShipInputDate.ToString("yyyy-MM-dd");
                cGeneralDate.Text = ii.GeneralManagerDate.ToString("yyyy-MM-dd");
                lblChiefEngineer.Text = chiefEngineer;
                lblCaptain.Text = captain;
                lblGeneralManager.Text = generalManager;
                bindConsumeInfo(reportID);
                bindOilBalanceInfo(reportID);
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //删除相关
                string baseId = this.ReportID;
                new HangciBaseInput().Delete(baseId);
                ShowMsg("删除成功");

                bindConsumeInfo("0");
                bindOilBalanceInfo("0");
                cCaptainDate.Text = "";
                cGeneralDate.Text = "";

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                ExcelGenButton1.Enabled = false;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region 验证逻辑
                string hangciBaseId = "";
                double diff = Convert.ToDouble(ViewState["diffHrs"].ToString());
                double t1 = Convert.ToDouble(judgeIsNull(tbWorkTime1.Text));
                if (t1 > diff)
                {
                    ShowMsg("主机航次工作时间不能大于航次总时间！");
                    return;
                }

                double t2 = Convert.ToDouble(judgeIsNull(tbWorkTime2.Text));
                if (t2 > diff)
                {
                    ShowMsg("副机1航次工作时间不能大于航次总时间！");
                    return;
                }

                double t3 = Convert.ToDouble(judgeIsNull(tbWorkTime3.Text));
                if (t3 > diff)
                {
                    ShowMsg("副机2航次工作时间不能大于航次总时间！");
                    return;
                }

                double t4 = Convert.ToDouble(judgeIsNull(tbWorkTime4.Text));
                if (t4 > diff)
                {
                    ShowMsg("副机3航次工作时间不能大于航次总时间！");
                    return;
                }

                double t5 = Convert.ToDouble(judgeIsNull(tbWorkTime5.Text));
                if (t5 > diff)
                {
                    ShowMsg("锅炉航次工作时间不能大于航次总时间！");
                    return;
                }
                #endregion

                string voyageIds = this.VoyageIds;
                string baseId = GetViewState("baseId");
                hangciBaseId = baseId;

                HangciBaseInputInfo hcbii = new HangciBaseInputInfo();
                if (string.IsNullOrEmpty(hangciBaseId))
                {
                    hangciBaseId = new HangciBaseInput().Add(hcbii);
                    new Voyage().UpdateVoyage(voyageIds, hangciBaseId);
                }
                hcbii = new HangciBaseInput().GetByID(baseId);
                if (!cCaptainDate.Text.Equals(""))
                {
                    hcbii.ShipInputDate = Convert.ToDateTime(cCaptainDate.Text);
                }
                if (!cGeneralDate.Text.Equals(""))
                {
                    hcbii.GeneralManagerDate = Convert.ToDateTime(cGeneralDate.Text);
                }
                new HangciBaseInput().Update(hcbii);

                //--------------------船舶油料航次消耗表------------------
                VoyageConsume vc = new VoyageConsume();
                VoyageConsumeInfo vci = new VoyageConsumeInfo();
                vci.BaseInputID = Convert.ToInt32(hangciBaseId);

                //主机
                vci.MainSlowWorkTime = judgeIsNull(tbSlowWorkTime1.Text);
                vci.MainCruiseWorkTime = judgeIsNull(tbCruiseWorkTime1.Text);
                vci.VoyageWorkTime = judgeIsNull(tbWorkTime1.Text);
                vci.FuelConsume = judgeIsNull(tbFuelConsume1.Text);
                vci.DieselConsume = judgeIsNull(tbDieselConsume1.Text);
                vci.OtherConsume = judgeIsNull(tbOtherConsume1.Text);
                vci.ShipComponentID = 1;

                if (string.IsNullOrEmpty(lbConZhuji.Text))
                {
                    lbConZhuji.Text = vc.Add(vci);
                }
                else
                {
                    vci.ID = lbConZhuji.Text;
                    vc.Update(vci);
                }

                //副机1
                vci.MainSlowWorkTime = judgeIsNull(tbSlowWorkTime2.Text);
                vci.MainCruiseWorkTime = judgeIsNull(tbCruiseWorkTime2.Text);
                vci.VoyageWorkTime = judgeIsNull(tbWorkTime2.Text);
                vci.FuelConsume = judgeIsNull(tbFuelConsume2.Text);
                vci.DieselConsume = judgeIsNull(tbDieselConsume2.Text);
                vci.OtherConsume = judgeIsNull(tbOtherConsume2.Text);
                vci.ShipComponentID = 2;

                if (string.IsNullOrEmpty(lbConFuji1.Text))
                {
                    lbConFuji1.Text = vc.Add(vci);
                }
                else
                {
                    vci.ID = lbConFuji1.Text;
                    vc.Update(vci);
                }

                //副机2
                vci.MainSlowWorkTime = judgeIsNull(tbSlowWorkTime3.Text);
                vci.MainCruiseWorkTime = judgeIsNull(tbCruiseWorkTime3.Text);
                vci.VoyageWorkTime = judgeIsNull(tbWorkTime3.Text);
                vci.FuelConsume = judgeIsNull(tbFuelConsume3.Text);
                vci.DieselConsume = judgeIsNull(tbDieselConsume3.Text);
                vci.OtherConsume = judgeIsNull(tbOtherConsume3.Text);
                vci.ShipComponentID = 3;

                if (string.IsNullOrEmpty(lbConFuji2.Text))
                {
                    lbConFuji2.Text = vc.Add(vci);
                }
                else
                {
                    vci.ID = lbConFuji2.Text;
                    vc.Update(vci);
                }

                //副机3
                vci.MainSlowWorkTime = judgeIsNull(tbSlowWorkTime4.Text);
                vci.MainCruiseWorkTime = judgeIsNull(tbCruiseWorkTime4.Text);
                vci.VoyageWorkTime = judgeIsNull(tbWorkTime4.Text);
                vci.FuelConsume = judgeIsNull(tbFuelConsume4.Text);
                vci.DieselConsume = judgeIsNull(tbDieselConsume4.Text);
                vci.OtherConsume = judgeIsNull(tbOtherConsume4.Text);
                vci.ShipComponentID = 4;
                vc.Add(vci);

                if (string.IsNullOrEmpty(lbConFuji3.Text))
                {
                    lbConFuji3.Text = vc.Add(vci);
                }
                else
                {
                    vci.ID = lbConFuji3.Text;
                    vc.Update(vci);
                }

                //锅炉
                vci.MainSlowWorkTime = judgeIsNull(tbSlowWorkTime5.Text);
                vci.MainCruiseWorkTime = judgeIsNull(tbCruiseWorkTime5.Text);
                vci.VoyageWorkTime = judgeIsNull(tbWorkTime5.Text);
                vci.FuelConsume = judgeIsNull(tbFuelConsume5.Text);
                vci.DieselConsume = judgeIsNull(tbDieselConsume5.Text);
                vci.OtherConsume = judgeIsNull(tbOtherConsume5.Text);
                vci.ShipComponentID = 5;

                if (string.IsNullOrEmpty(lbConGuolu.Text))
                {
                    lbConGuolu.Text = vc.Add(vci);
                }
                else
                {
                    vci.ID = lbConGuolu.Text;
                    vc.Update(vci);
                }

                //--------------------燃润油领用结存（吨）------------------

                OilUseBalance oub = new OilUseBalance();
                OilUseBalanceInfo oubi = new OilUseBalanceInfo();

                oubi.BaseInputID = Convert.ToInt32(hangciBaseId);

                //燃料油
                oubi.Remaining = judgeIsNull(tbRemain1.Text);
                oubi.Addition = judgeIsNull(tbAdd1.Text);
                oubi.Consuming = judgeIsNull(tbConsume1.Text);
                oubi.Balance = judgeIsNull(tbBalance1.Text);
                oubi.OilTypeID = 1;

                if (string.IsNullOrEmpty(lbOilBalFuel.Text))
                {
                    lbOilBalFuel.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOilBalFuel.Text;
                    oub.Update(oubi);
                }

                //柴油
                oubi.Remaining = judgeIsNull(tbRemain2.Text);
                oubi.Addition = judgeIsNull(tbAdd2.Text);
                oubi.Consuming = judgeIsNull(tbConsume2.Text);
                oubi.Balance = judgeIsNull(tbBalance2.Text);
                oubi.OilTypeID = 2;

                if (string.IsNullOrEmpty(lbOilBalDiesel.Text))
                {
                    lbOilBalDiesel.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOilBalDiesel.Text;
                    oub.Update(oubi);
                }

                //机油
                oubi.Remaining = judgeIsNull(tbRemain3.Text);
                oubi.Addition = judgeIsNull(tbAdd3.Text);
                oubi.Consuming = judgeIsNull(tbConsume3.Text);
                oubi.Balance = judgeIsNull(tbBalance3.Text);
                oubi.OilTypeID = 3;

                if (string.IsNullOrEmpty(lbOilBalEngine.Text))
                {
                    lbOilBalEngine.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOilBalEngine.Text;
                    oub.Update(oubi);
                }

                //气缸油
                oubi.Remaining = judgeIsNull(tbRemain4.Text);
                oubi.Addition = judgeIsNull(tbAdd4.Text);
                oubi.Consuming = judgeIsNull(tbConsume4.Text);
                oubi.Balance = judgeIsNull(tbBalance4.Text);
                oubi.OilTypeID = 4;

                if (string.IsNullOrEmpty(lbOilBalCylinder.Text))
                {
                    lbOilBalCylinder.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOilBalCylinder.Text;
                    oub.Update(oubi);
                }

                //透平油
                oubi.Remaining = judgeIsNull(tbRemain5.Text);
                oubi.Addition = judgeIsNull(tbAdd5.Text);
                oubi.Consuming = judgeIsNull(tbConsume5.Text);
                oubi.Balance = judgeIsNull(tbBalance5.Text);
                oubi.OilTypeID = 5;

                if (string.IsNullOrEmpty(lbOilBalTurbine.Text))
                {
                    lbOilBalTurbine.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOilBalTurbine.Text;
                    oub.Update(oubi);
                }

                //液压油
                oubi.Remaining = judgeIsNull(tbRemain6.Text);
                oubi.Addition = judgeIsNull(tbAdd6.Text);
                oubi.Consuming = judgeIsNull(tbConsume6.Text);
                oubi.Balance = judgeIsNull(tbBalance6.Text);
                oubi.OilTypeID = 6;

                if (string.IsNullOrEmpty(lbOilBalHydraulic.Text))
                {
                    lbOilBalHydraulic.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOilBalHydraulic.Text;
                    oub.Update(oubi);
                }

                //冷冻油
                oubi.Remaining = judgeIsNull(tbRemain7.Text);
                oubi.Addition = judgeIsNull(tbAdd7.Text);
                oubi.Consuming = judgeIsNull(tbConsume7.Text);
                oubi.Balance = judgeIsNull(tbBalance7.Text);
                oubi.OilTypeID = 8;

                if (string.IsNullOrEmpty(lbFrozenOil.Text))
                {
                    lbFrozenOil.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbFrozenOil.Text;
                    oub.Update(oubi);
                }

                //空压机油
                oubi.Remaining = judgeIsNull(tbRemain8.Text);
                oubi.Addition = judgeIsNull(tbAdd8.Text);
                oubi.Consuming = judgeIsNull(tbConsume8.Text);
                oubi.Balance = judgeIsNull(tbBalance8.Text);
                oubi.OilTypeID = 9;

                if (string.IsNullOrEmpty(lbPressOil.Text))
                {
                    lbPressOil.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbPressOil.Text;
                    oub.Update(oubi);
                }

                //其他
                oubi.Remaining = judgeIsNull(tbRemain9.Text);
                oubi.Addition = judgeIsNull(tbAdd9.Text);
                oubi.Consuming = judgeIsNull(tbConsume9.Text);
                oubi.Balance = judgeIsNull(tbBalance9.Text);
                oubi.OilTypeID = 7;

                if (string.IsNullOrEmpty(lbOtherOil.Text))
                {
                    lbOtherOil.Text = oub.Add(oubi);
                }
                else
                {
                    oubi.ID = lbOtherOil.Text;
                    oub.Update(oubi);
                }
                ShowMsg("保存成功");
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

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "../ChuanJ/RanrunList.aspx";
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

        #region 绑定
        //消耗表绑定
        private void bindConsumeInfo(string baseId)
        {
            if (!baseId.Equals("0"))
            {
                //主机
                DataTable dt = new VoyageConsume().GetVoyageConsumeInfo(baseId).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lbConZhuji.Text = dt.Rows[0]["ID1"].ToString();
                    tbSlowWorkTime1.Text = dt.Rows[0]["MainSlowWorkTime1"].ToString();
                    tbCruiseWorkTime1.Text = dt.Rows[0]["MainCruiseWorkTime1"].ToString();
                    tbWorkTime1.Text = dt.Rows[0]["VoyageWorkTime1"].ToString();
                    tbFuelConsume1.Text = dt.Rows[0]["FuelConsume1"].ToString();
                    tbDieselConsume1.Text = dt.Rows[0]["DieselConsume1"].ToString();
                    tbOtherConsume1.Text = dt.Rows[0]["OtherConsume1"].ToString();

                    //副机1
                    lbConFuji1.Text = dt.Rows[0]["ID2"].ToString();
                    tbSlowWorkTime2.Text = dt.Rows[0]["MainSlowWorkTime2"].ToString();
                    tbCruiseWorkTime2.Text = dt.Rows[0]["MainCruiseWorkTime2"].ToString();
                    tbWorkTime2.Text = dt.Rows[0]["VoyageWorkTime2"].ToString();
                    tbFuelConsume2.Text = dt.Rows[0]["FuelConsume2"].ToString();
                    tbDieselConsume2.Text = dt.Rows[0]["DieselConsume2"].ToString();
                    tbOtherConsume2.Text = dt.Rows[0]["OtherConsume2"].ToString();

                    //副机2
                    lbConFuji2.Text = dt.Rows[0]["ID3"].ToString();
                    tbSlowWorkTime3.Text = dt.Rows[0]["MainSlowWorkTime3"].ToString();
                    tbCruiseWorkTime3.Text = dt.Rows[0]["MainCruiseWorkTime3"].ToString();
                    tbWorkTime3.Text = dt.Rows[0]["VoyageWorkTime3"].ToString();
                    tbFuelConsume3.Text = dt.Rows[0]["FuelConsume3"].ToString();
                    tbDieselConsume3.Text = dt.Rows[0]["DieselConsume3"].ToString();
                    tbOtherConsume3.Text = dt.Rows[0]["OtherConsume3"].ToString();

                    //副机3
                    lbConFuji3.Text = dt.Rows[0]["ID4"].ToString();
                    tbSlowWorkTime4.Text = dt.Rows[0]["MainSlowWorkTime4"].ToString();
                    tbCruiseWorkTime4.Text = dt.Rows[0]["MainCruiseWorkTime4"].ToString();
                    tbWorkTime4.Text = dt.Rows[0]["VoyageWorkTime4"].ToString();
                    tbFuelConsume4.Text = dt.Rows[0]["FuelConsume4"].ToString();
                    tbDieselConsume4.Text = dt.Rows[0]["DieselConsume4"].ToString();
                    tbOtherConsume4.Text = dt.Rows[0]["OtherConsume4"].ToString();

                    //锅炉
                    lbConGuolu.Text = dt.Rows[0]["ID5"].ToString();
                    tbSlowWorkTime5.Text = dt.Rows[0]["MainSlowWorkTime5"].ToString();
                    tbCruiseWorkTime5.Text = dt.Rows[0]["MainCruiseWorkTime5"].ToString();
                    tbWorkTime5.Text = dt.Rows[0]["VoyageWorkTime5"].ToString();
                    tbFuelConsume5.Text = dt.Rows[0]["FuelConsume5"].ToString();
                    tbDieselConsume5.Text = dt.Rows[0]["DieselConsume5"].ToString();
                    tbOtherConsume5.Text = dt.Rows[0]["OtherConsume5"].ToString();
                }
                else
                {
                    emptyConsumeInput();
                }
            }
            else
            {
                emptyConsumeInput();
            }
        }

        //用油表绑定
        private void bindOilBalanceInfo(string baseId)
        {
            if (!baseId.Equals("0"))
            {
                //燃料油
                DataTable dt = new OilUseBalance().GetOilBalanceInfo(baseId).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lbOilBalFuel.Text = dt.Rows[0]["ID1"].ToString();
                    tbRemain1.Text = dt.Rows[0]["Remaining1"].ToString();
                    tbAdd1.Text = dt.Rows[0]["Addition1"].ToString();
                    tbConsume1.Text = dt.Rows[0]["Consuming1"].ToString();
                    tbBalance1.Text = dt.Rows[0]["Balance1"].ToString();
                    //柴油
                    lbOilBalDiesel.Text = dt.Rows[0]["ID2"].ToString();
                    tbRemain2.Text = dt.Rows[0]["Remaining2"].ToString();
                    tbAdd2.Text = dt.Rows[0]["Addition2"].ToString();
                    tbConsume2.Text = dt.Rows[0]["Consuming2"].ToString();
                    tbBalance2.Text = dt.Rows[0]["Balance2"].ToString();
                    //机油
                    lbOilBalEngine.Text = dt.Rows[0]["ID3"].ToString();
                    tbRemain3.Text = dt.Rows[0]["Remaining3"].ToString();
                    tbAdd3.Text = dt.Rows[0]["Addition3"].ToString();
                    tbConsume3.Text = dt.Rows[0]["Consuming3"].ToString();
                    tbBalance3.Text = dt.Rows[0]["Balance3"].ToString();
                    //气缸油
                    lbOilBalCylinder.Text = dt.Rows[0]["ID4"].ToString();
                    tbRemain4.Text = dt.Rows[0]["Remaining4"].ToString();
                    tbAdd4.Text = dt.Rows[0]["Addition4"].ToString();
                    tbConsume4.Text = dt.Rows[0]["Consuming4"].ToString();
                    tbBalance4.Text = dt.Rows[0]["Balance4"].ToString();
                    //透平油
                    lbOilBalTurbine.Text = dt.Rows[0]["ID5"].ToString();
                    tbRemain5.Text = dt.Rows[0]["Remaining5"].ToString();
                    tbAdd5.Text = dt.Rows[0]["Addition5"].ToString();
                    tbConsume5.Text = dt.Rows[0]["Consuming5"].ToString();
                    tbBalance5.Text = dt.Rows[0]["Balance5"].ToString();
                    //液压油
                    lbOilBalHydraulic.Text = dt.Rows[0]["ID6"].ToString();
                    tbRemain6.Text = dt.Rows[0]["Remaining6"].ToString();
                    tbAdd6.Text = dt.Rows[0]["Addition6"].ToString();
                    tbConsume6.Text = dt.Rows[0]["Consuming6"].ToString();
                    tbBalance6.Text = dt.Rows[0]["Balance6"].ToString();
                    //冷冻油
                    lbFrozenOil.Text = dt.Rows[0]["ID7"].ToString();
                    tbRemain7.Text = dt.Rows[0]["Remaining7"].ToString();
                    tbAdd7.Text = dt.Rows[0]["Addition7"].ToString();
                    tbConsume7.Text = dt.Rows[0]["Consuming7"].ToString();
                    tbBalance7.Text = dt.Rows[0]["Balance7"].ToString();
                    //空压机油
                    lbPressOil.Text = dt.Rows[0]["ID8"].ToString();
                    tbRemain8.Text = dt.Rows[0]["Remaining8"].ToString();
                    tbAdd8.Text = dt.Rows[0]["Addition8"].ToString();
                    tbConsume8.Text = dt.Rows[0]["Consuming8"].ToString();
                    tbBalance8.Text = dt.Rows[0]["Balance8"].ToString();
                    //其他
                    lbOtherOil.Text = dt.Rows[0]["ID9"].ToString();
                    tbRemain9.Text = dt.Rows[0]["Remaining9"].ToString();
                    tbAdd9.Text = dt.Rows[0]["Addition9"].ToString();
                    tbConsume9.Text = dt.Rows[0]["Consuming9"].ToString();
                    tbBalance9.Text = dt.Rows[0]["Balance9"].ToString();
                }
                else
                {
                    emptyOilBalInput();
                }
            }
            else
            {
                emptyOilBalInput();
            }
        }

        //航次基本信息绑定
        private void bindVoyageInfo(string voyageid)
        {
            VoyageInfo vi = new VoyageInfo();
            Voyage v = new Voyage();

            vi = v.GetByID(voyageid);

            string voyageName = vi.Name;
            string beginDate = vi.BeginDate.ToString();
            string endDate = vi.EndDate.ToString();
            string routeId = vi.RouteID.ToString();

            Route r = new Route();
            RouteInfo ri = new RouteInfo();

            ri = r.GetByID(routeId);
            float distance = ri.Distance;

            Ship ship = new Ship();
            ShipInfo si = new ShipInfo();
            si = ship.GetByID(vi.ShipID.ToString());

            string shipName = si.Name;
            string chiefEngineer = si.ChiefEngineer;
            string captain = si.Captain;
            string generalManager = si.GeneralManager;

            Relation_RoutePort rrp = new Relation_RoutePort();
            Relation_RoutePortInfo rrpi = new Relation_RoutePortInfo();

            int startPortId = 0;
            int endPortId = 0;
            rrpi = rrp.GetListByRouteID(routeId)[0];
            int portType = rrpi.PortTypeID;

            //出发港
            if (portType == 2)
            {
                startPortId = rrpi.PortID;
            }
            //到达港
            if (portType == 4)
            {
                endPortId = rrpi.PortID;
            }

            rrpi = rrp.GetListByRouteID(routeId)[1];
            portType = rrpi.PortTypeID;

            //出发港
            if (portType == 2)
            {
                startPortId = rrpi.PortID;
            }
            //到达港
            if (portType == 4)
            {
                endPortId = rrpi.PortID;
            }

            Port p = new Port();
            PortInfo pi = new PortInfo();

            pi = p.GetByID(startPortId.ToString());
            string startPortName = pi.Name;
            pi = p.GetByID(endPortId.ToString());
            string endPortName = pi.Name;

            lblShipName.Text = shipName;
            lblDistance.Text = distance.ToString();

            if (beginDate.Split(' ')[0].ToString().Equals("1900/1/1"))
            {
                lblStartTime.Text = "";
            }
            else
            {
                lblStartTime.Text = beginDate;
            }

            if (endDate.Split(' ')[0].ToString().Equals("1900/1/1"))
            {
                lblStartTime.Text = "";
            }
            else
            {
                lblEndTime.Text = endDate;
            }

            lblStartPort.Text = startPortName;
            lblEndPort.Text = endPortName;
            lblChiefEngineer.Text = chiefEngineer;
            lblCaptain.Text = captain;
            lblGeneralManager.Text = generalManager;
        }
        #endregion

        #region 私有方法
        private void emptyConsumeInput()
        {
            tbSlowWorkTime1.Text = "";
            tbCruiseWorkTime1.Text = "";
            tbWorkTime1.Text = "";
            tbFuelConsume1.Text = "";
            tbDieselConsume1.Text = "";
            tbOtherConsume1.Text = "";

            tbSlowWorkTime2.Text = "";
            tbCruiseWorkTime2.Text = "";
            tbWorkTime2.Text = "";
            tbFuelConsume2.Text = "";
            tbDieselConsume2.Text = "";
            tbOtherConsume2.Text = "";

            tbSlowWorkTime3.Text = "";
            tbCruiseWorkTime3.Text = "";
            tbWorkTime3.Text = "";
            tbFuelConsume3.Text = "";
            tbDieselConsume3.Text = "";
            tbOtherConsume3.Text = "";

            tbSlowWorkTime4.Text = "";
            tbCruiseWorkTime4.Text = "";
            tbWorkTime4.Text = "";
            tbFuelConsume4.Text = "";
            tbDieselConsume4.Text = "";
            tbOtherConsume4.Text = "";

            tbSlowWorkTime5.Text = "";
            tbCruiseWorkTime5.Text = "";
            tbWorkTime5.Text = "";
            tbFuelConsume5.Text = "";
            tbDieselConsume5.Text = "";
            tbOtherConsume5.Text = "";
        }

        //emptyInputText   emptyConsumeInput();emptyOilBalInput();
        private void emptyOilBalInput()
        {
            tbRemain1.Text = "";
            tbAdd1.Text = "";
            tbConsume1.Text = "";
            tbBalance1.Text = "";

            tbRemain2.Text = "";
            tbAdd2.Text = "";
            tbConsume2.Text = "";
            tbBalance2.Text = "";

            tbRemain3.Text = "";
            tbAdd3.Text = "";
            tbConsume3.Text = "";
            tbBalance3.Text = "";

            tbRemain4.Text = "";
            tbAdd4.Text = "";
            tbConsume4.Text = "";
            tbBalance4.Text = "";

            tbRemain5.Text = "";
            tbAdd5.Text = "";
            tbConsume5.Text = "";
            tbBalance5.Text = "";

            tbRemain6.Text = "";
            tbAdd6.Text = "";
            tbConsume6.Text = "";
            tbBalance6.Text = "";

            tbRemain7.Text = "";
            tbAdd7.Text = "";
            tbConsume7.Text = "";
            tbBalance7.Text = "";

            tbRemain8.Text = "";
            tbAdd8.Text = "";
            tbConsume8.Text = "";
            tbBalance8.Text = "";

            tbRemain9.Text = "";
            tbAdd9.Text = "";
            tbConsume9.Text = "";
            tbBalance9.Text = "";
        }

        private float judgeIsNull(string value)
        {
            if (value.Equals(""))
            {
                return 0;
            }
            return float.Parse(value);
        }

        #endregion

        #region 编辑油料消耗表
        protected void btnEditOil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.VoyageIds))
                {
                    ShowMsg("当前报表未关联航次，无法编辑油料添加情况。");
                }
                string url = "../Hangy/OilFee.aspx?voyageIds=" + this.VoyageIds;
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

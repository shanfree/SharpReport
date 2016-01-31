using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using Sirc.SharpReport.BLL;
using Sirc.SharpReport.Model;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.Utility;
using System.Drawing;

namespace SharpReportWeb.WUC
{
    public partial class ReportState : System.Web.UI.UserControl
    {
        #region 属性
        /// <summary>
        /// 控件所在页面的栏目编号
        /// </summary>
        public string MenuID { get; set; }
        /// <summary>
        /// 报表类型
        /// </summary>
        public ReportCatalog RType { get; set; }
        /// <summary>
        /// 报表状态：1：预估输入；2：修正输入；3：财务确认
        /// </summary>
        public string SelectValue
        {
            get
            {
                object o = ViewState["SelectValue"];
                return o == null ? string.Empty : o.ToString();
            }
            set
            {
                ViewState["SelectValue"] = value;
                //switch (value)
                //{
                //    case "1":
                //        btnState1.BackColor = Color.Yellow;
                //        btnState2.BackColor = Color.Green;
                //        btnState3.BackColor = Color.Green;
                //        break;
                //    case "2":
                //        btnState1.BackColor = Color.Green;
                //        btnState2.BackColor = Color.Yellow;
                //        btnState3.BackColor = Color.Green;
                //        break;
                //    case "3":
                //        btnState1.BackColor = Color.Green;
                //        btnState2.BackColor = Color.Green;
                //        btnState3.BackColor = Color.Yellow;
                //        break;
                //    default:
                //        break;
                //}
            }
        }

        /// <summary>
        /// 所属的报表主键
        /// </summary>
        public string KeyID
        {
            get
            {
                object o = ViewState["KeyID"];
                return o == null ? string.Empty : o.ToString();
            }     
            set   
            {
                ViewState["KeyID"] = value;
                if (string.IsNullOrEmpty(this.KeyID))
                {
                    return;
                }
                ReportBaseInfo rInfo = GetReport(this.RType, this.KeyID);
                if (string.IsNullOrEmpty(rInfo.PreestimateFormID) == false && rInfo.PreestimateFormID != "0")
                {
                    btnState1.Enabled = true;
                }
                else
                {
                    btnState1.Enabled = false;
                }
                if (string.IsNullOrEmpty(rInfo.AmendFormID) == false && rInfo.AmendFormID != "0")
                {
                    btnState2.Enabled = true;
                }
                else
                {
                    btnState2.Enabled = false;
                }
                if (rInfo.ReportTypeID == "3")
                {
                    btnState3.Enabled = true;
                }
                else
                {
                    btnState3.Enabled = false;
                }
            }
        }
        #endregion

        #region 事件
        public event EventHandler OnClick;
        protected void Clicked()
        {
            if (OnClick != null)
            {
                EventArgs e = new EventArgs();
                OnClick(this, e);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogEntry.Log.Write(ex.ToString(), MenuID);
            }
        }

        /// <summary>
        /// 在页面在弹出框提示用户信息
        /// </summary>
        /// <param name="message"></param>
        public void ShowMsg(string message)
        {
            // 过滤掉换行符
            message = message.Replace("\r\n", " ");
            message = message.Replace("'", "\"");
            string script = string.Format("<script>alert('{0}')</script>", message);
            Response.Write(script);
        }


        private ReportBaseInfo GetReport(ReportCatalog rType, string id)
        {
            ReportBaseInfo rInfo = new ReportBaseInfo();
            switch (rType)
            {
                case ReportCatalog.Wuliao:
                    rInfo = new ReportBase<WuliaoInputInfo>().GetReport(id);
                    break;
                case ReportCatalog.Xiuli:
                    rInfo = new ReportBase<XiuliInputInfo>().GetReport(id);
                    break;
                case ReportCatalog.Jianyan:
                    rInfo = new ReportBase<JianyanInputInfo>().GetReport(id);
                    break;
                case ReportCatalog.Beijian:
                    rInfo = new ReportBase<BeijianInputInfo>().GetReport(id);
                    break;
                default:
                    break;
            }
            return rInfo;
        }


        protected void btnState1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBaseInfo rInfo = GetReport(this.RType, this.KeyID);
                // 存在预估录入的数据
                string preestimateURL = rInfo.PreestimateFormID;
                if (string.IsNullOrEmpty(preestimateURL))
                {
                    return;
                }
                this.SelectValue = "1";
                OnClick(sender, e);
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogEntry.Log.Write(ex.ToString(), MenuID);
            }
        }

        protected void btnState2_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBaseInfo rInfo = GetReport(this.RType, this.KeyID);
                // 存在修正录入的数据
                string amendFormID = rInfo.AmendFormID;
                if (string.IsNullOrEmpty(amendFormID))
                {
                    return;
                }
                this.SelectValue = "2";
                OnClick(sender, e);
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogEntry.Log.Write(ex.ToString(), MenuID);
            }
        }

        protected void btnState3_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBaseInfo rInfo = GetReport(this.RType, this.KeyID);
                if (rInfo.ReportTypeID == "3")
                {
                    this.SelectValue = "3";
                    OnClick(sender, e);
                }
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogEntry.Log.Write(ex.ToString(), MenuID);
            }
        }

    }
}
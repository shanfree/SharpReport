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

namespace SharpReportWeb.Hangy
{
    public partial class ShipForm : WebBasePage
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

        #region 页面载入
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("船舶登记", "编辑所有在册船舶的参数，以及船舶的使用情况，只有在使用以及租约未过期的船舶，才能登记航次和各类报表。");
                    BindShip(0);
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

        #region 船舶
        /// <summary>
        /// 绑定船舶报表
        /// </summary>
        private void BindShip(int pageIndex)
        {
            IList<ShipInfo> list = new Ship().GetList();
            gvShipList.DataSource = list;
            gvShipList.DataBind();
            if (list == null)
            {
                pGridV.TotalAmout = 0;
                return;
            }
            pGridV.TotalAmout = list.Count;

        }

        /// <summary>
        /// 船舶编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvShipList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string ShipId = e.CommandArgument.ToString();

                if (e.CommandName == "btnDelShip")
                {
                    new Ship().Delete(ShipId);
                    ShowMsg("操作成功！");
                    BindShip(0);
                    NewShip();
                    return;
                }
                else if (e.CommandName == "btnEditShip")
                {
                    // 编辑
                    lbID2.Value = ShipId;
                    ShipInfo sInfo = new Ship().GetByID(ShipId);
                    tbName.Text = sInfo.Name;
                    tbCode.Text = sInfo.Code;
                    tbCaptain.Text = sInfo.Captain;
                    tbChiefEngineer.Text = sInfo.ChiefEngineer;
                    tbGeneralManager.Text = sInfo.GeneralManager;
                    cRentDate.Text = sInfo.RentDate.ToShortDateString();
                    rblLoadType.SelectedValue = sInfo.LoadType;
                    rblOperationType.SelectedValue = sInfo.OperationType;
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

        private void NewShip()
        {
            tbName.Text = "";
            tbCode.Text = "";
            tbCaptain.Text = "";
            tbChiefEngineer.Text = "";
            tbGeneralManager.Text = "";
            cRentDate.Text = "";
            lbID2.Value = string.Empty;
        }

        protected void gvShipList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ShipInfo sInfo = e.Row.DataItem as ShipInfo;
                    // 选择控件，传入收件的事务主键，用来更新
                    Label tbLoadType = (Label)e.Row.FindControl("tbLoadType");
                    Label tbOperationType = (Label)e.Row.FindControl("tbOperationType");
                    switch (sInfo.LoadTypeEnum)
                    {
                        case ShipType.LCL:
                            tbLoadType.Text = "散货";
                            break;
                        case ShipType.FCL:
                            tbLoadType.Text = "集装箱";
                            break;
                        default:
                            break;
                    }
                    switch (sInfo.OperationTypeEnum)
                    {
                        case ShipOperationType.Own:
                            tbOperationType.Text = "自营";
                            break;
                        case ShipOperationType.Rent:
                            tbOperationType.Text = "租赁";
                            break;
                        default:
                            break;
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
        /// 新增船舶前 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddShip_Click(object sender, EventArgs e)
        {
            try
            {
                NewShip();
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
        /// 增改船舶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveShip_Click(object sender, EventArgs e)
        {
            try
            {
                string shipID = lbID2.Value;
                ShipInfo sInfo = new ShipInfo();
                sInfo.Name = tbName.Text;
                sInfo.Code = tbCode.Text;
                sInfo.Captain = tbCaptain.Text;
                sInfo.ChiefEngineer = tbChiefEngineer.Text;
                sInfo.GeneralManager = tbGeneralManager.Text;
                sInfo.RentDate = (string.IsNullOrEmpty(cRentDate.Text.Trim())) ? DateTime.MaxValue : Convert.ToDateTime(cRentDate.Text);
                sInfo.LoadType = rblLoadType.SelectedValue;
                sInfo.OperationType = rblOperationType.SelectedValue;



                if (string.IsNullOrEmpty(shipID))
                {
                    new Ship().Add(sInfo);
                }
                else
                {
                    sInfo.ID = shipID;
                    new Ship().Update(sInfo);
                }
                ShowMsg("操作成功！");
                BindShip(0);
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


        protected void ExcelGenButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // 最多500页
                int pageSize = gvShipList.PageSize * 500;
                int pageIndex = 0;
                BindShip(pageIndex);

                gvShipList.Columns[0].Visible = false;
                gvShipList.Columns[6].Visible = false;
                gvShipList.Columns[7].Visible = false;

                foreach (GridViewRow gvr in gvShipList.Rows)
                {
                    foreach (TableCell cell in gvr.Cells)
                    {
                        cell.Attributes.Add("style", "vnd.ms-excel.numberformat:@;");
                    }
                }
            }
            catch (ArgumentNullException ane)
            {
                this.ShowMsg(ane.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                this.Log(ex);
            }
        }

        protected void pGridV_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindShip(pGridV.CurrentPageIndex);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        #region 生成excel事件
        public override void VerifyRenderingInServerForm(Control control)
        {
            if (!(control.GetType().Name.Equals("GridView") || control.GetType().Name.Equals("CheckBox")))
            {
                //base.VerifyRenderingInServerForm(control);
            }
        }
        #endregion
    }
}

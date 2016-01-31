using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SharpReportWeb.Admin
{
    public partial class Sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindList();
                    //ddlDepartment.DataSource = new Department().GetList();
                    //ddlDepartment.DataBind();
                }
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                //Log(ex);
            }
        }
        private void BindList()
        {
            //IList<UserInfo> list = new User().GetList(false, true);
            //UserInfo aInfo = new UserInfo();
            //gvUserList.DataSource = list;
            //gvUserList.DataBind();
        }

        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //UserInfo uInfo = e.Row.DataItem as UserInfo;

                //// 选择控件，传入收件的事务主键，用来更新
                //RadioButton rbSel = (RadioButton)e.Row.FindControl("rbSel");
                //rbSel.Attributes.Add("onclick", "Sel('" + uInfo.ID + "')");
            }
        }

        protected void rbSel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string id = lbID.Value;
                if (string.IsNullOrEmpty(id) == true)
                {
                    return;
                }
                divUser.Visible = true;
                //UserInfo uInfo = new User().GetByID(id);
                //tbName.Text = uInfo.Name;
                //ddlDepartment.Items.FindByValue(uInfo.DepartmentID).Selected = true;
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                //Log(ex);
            }
        }

        #region 用户操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = lbID.Value;
                string name = tbName.Text;
                string pwd = tbPws.Text;
                string departmentID = ddlDepartment.SelectedValue;
                //new User().Update(id, name, pwd, departmentID);
                //ddlDepartment.DataSource = new Department().GetList();
                //ddlDepartment.DataBind();
                this.ShowMsg("用户更新成功。");
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                //string id = lbID.Value;
                //new User().Delete(id);
                //ddlDepartment.DataSource = new Department().GetList();
                //ddlDepartment.DataBind();

                this.ShowMsg("用户添加成功。");
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                //Log(ex);
            }
        }

        protected Literal litMsg = new Literal();
        /// <summary>
        /// 在页面在弹出框提示用户信息
        /// </summary>
        /// <param name="message"></param>
        public void ShowMsg(string message)
        {
            // 过滤掉换行符
            message = message.Replace("\r\n", " ");
            message = message.Replace("'", "\"");
            litMsg.Text = string.Format("<script>alert('{0}')</script>", message);
            litMsg.Visible = true;
        }

        #endregion
    }
}

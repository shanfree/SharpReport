using System;
using System.Collections;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.SharpMemberShip.Model;
using System.Web.UI.WebControls;

namespace SharpReportWeb.Admin
{
    public partial class UserManage : WebBasePage
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("用户管理", "可以新增、修改和删除用户。");
                    BindList();
                    ddlDepartment.DataSource = new Department().GetList();
                    ddlDepartment.DataBind();
                    BindRoles();
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

        private void BindRoles()
        {
            cblRoles.DataSource = new Role().GetList();
            cblRoles.DataBind();
        }
        private void BindList()
        {
            IList<UserInfo> list = new User().GetList(false, true);
            gvUserList.DataSource = list;
            gvUserList.DataBind();
        }

        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UserInfo uInfo = e.Row.DataItem as UserInfo;

                // 选择控件，传入收件的事务主键，用来更新
                RadioButton rbSel = (RadioButton)e.Row.FindControl("rbSel");
                rbSel.Attributes.Add("onclick", "Sel('" + uInfo.ID + "')");
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
                UserInfo uInfo = new User().GetByID(id);
                tbName.Text = uInfo.Name;
                ddlDepartment.SelectedValue = uInfo.DepartmentID;

                BindRoles();
                IList<RoleInfo> rList = new Role().GetListByUserID(id);
                foreach (RoleInfo rInfo in rList)
                {
                    string roleID = rInfo.ID;
                    cblRoles.Items.FindByValue(roleID).Selected = true;
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

        #region 用户操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = lbID.Value;
                string name = tbName.Text;
                string pwd = tbPws.Text;
                string departmentID = ddlDepartment.SelectedValue;
                new User().Update(id, name, pwd, departmentID);
                ddlDepartment.DataSource = new Department().GetList();
                ddlDepartment.DataBind();
                this.ShowMsg("用户更新成功。");
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
                string id = lbID.Value;
                new User().Delete(id);
                ddlDepartment.DataSource = new Department().GetList();
                ddlDepartment.DataBind();

                this.ShowMsg("用户添加成功。");
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

        protected void btnRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (cblRoles.SelectedIndex == -1)
                {
                    ShowMsg("未选择任何角色。请重新选择后保存。");
                    return;
                }
                ArrayList alRoleID = new ArrayList();
                for (int i = 0; i < cblRoles.Items.Count; i++)
                {
                    ListItem item = cblRoles.Items[i];
                    if (item.Selected == true)
                    {
                        alRoleID.Add(item.Value);
                    }
                }
                string userID = lbID.Value;
                string[] roleIDArray = new string[alRoleID.Count];
                roleIDArray = (string[])alRoleID.ToArray(typeof(string));
                new User().AddRoles(userID, roleIDArray);
                ShowMsg("角色绑定成功。");
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

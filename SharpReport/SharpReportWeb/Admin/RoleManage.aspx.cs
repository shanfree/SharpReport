using System;
using System.Collections;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.SharpMemberShip.Model;
using System.Web.UI.WebControls;

namespace SharpReportWeb.Admin
{
    public partial class RoleManage : WebBasePage
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
                    TitleInitial("角色管理", "可以新增、修改和删除角色。删除角色，则分配到用户的该角色将被删除，而不会删除具有该角色的用户。");
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
        private void BindList()
        {
            IList<RoleInfo> list = new Role().GetList();
            RoleInfo aInfo = new RoleInfo();
            list.Add(aInfo);
            gvRoleList.DataSource = list;
            gvRoleList.DataBind();
        }

        protected void gvRoleList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string ID = e.CommandArgument.ToString();
                int index = Convert.ToInt32(ID);
                GridViewRow gvr = (GridViewRow)gvRoleList.Rows[index];
                Label lblID = (Label)gvr.FindControl("lblID");
                if (e.CommandName == "btnDel")
                {
                    new Role().Delete(lblID.Text);
                }
                else
                {
                    #region 控件
                    TextBox tbName = (TextBox)gvr.FindControl("tbName");
                    TextBox tbRemark = (TextBox)gvr.FindControl("tbRemark");
                    #endregion

                    if (e.CommandName == "btnEdit")
                    {
                        new Role().Update(lblID.Text, tbName.Text, tbRemark.Text);
                    }

                    if (e.CommandName == "btnAdd")
                    {
                        new Role().Add(tbName.Text, tbRemark.Text);
                    }
                }
                ShowMsg("操作成功！");
                BindList();
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        protected void gvRoleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                Button btnEdit = (Button)e.Row.FindControl("btnEdit");
                Button btnDel = (Button)e.Row.FindControl("btnDel");
                TextBox tbName = (TextBox)e.Row.FindControl("tbName");

                if (tbName == null || string.IsNullOrEmpty(tbName.Text))
                {
                    btnAdd.Visible = true;
                    btnEdit.Visible = false;
                    btnDel.Visible = false;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnEdit.Visible = true;
                    btnDel.Visible = true;
                }
            }
        }

    }
}

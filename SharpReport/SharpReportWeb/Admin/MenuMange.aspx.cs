using System.Collections;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip;
using BLL = SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.SharpMemberShip.Model;
using System.Web.UI.WebControls;
using System;
using SIRC.Framework.Utility;
using SIRC.Framework.SharpMemberShip.BLL;

namespace SharpReportWeb.Admin
{
    public partial class MenuMange : WebBasePage
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
        /// 选定栏目ID
        /// </summary>
        private string NodeID
        {
            get
            {
                return GetViewState("NodeID");
            }
            set
            {
                ViewState["NodeID"] = value;
            }
        }
        /// <summary>
        /// 父栏目ID
        /// </summary>
        private string ParentID
        {
            get
            {
                return GetViewState("ParentID");
            }
            set
            {
                ViewState["ParentID"] = value;
            }
        }
        #endregion

        #region 加载操作
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TitleInitial("栏目管理", "配置栏目浏览方式，对应权限组和可访问的角色。");
                    BindTree();
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
        /// 
        /// </summary>
        private void BindTree()
        {
            tMenus.Nodes.Clear();
            TreeNodeInfo<MenuInfo> tree = new BLL.Menu().GetTree(MenuInfo.DEFAULT_PARENT_ID);
            foreach (TreeNodeInfo<MenuInfo> node in tree.SubNodeList)
            {
                string name = node.STInstance.Name;
                string id = node.STInstance.ID;
                //string url = node.STInstance.URL;
                //string sortNum = node.STInstance.SortNum.ToString();
                TreeNode treeNode = new TreeNode(name, id);
                tMenus.Nodes.Add(treeNode);
                if (node.Count != 0)
                {
                    BindTree(node, treeNode);
                }
            }
        }

        /// <summary>
        /// 生成栏目树
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="parentItem"></param>
        private void BindTree(TreeNodeInfo<MenuInfo> tree, TreeNode treeNode)
        {
            foreach (TreeNodeInfo<MenuInfo> node in tree.SubNodeList)
            {
                string name = node.STInstance.Name;
                string id = node.STInstance.ID;
                //string url = node.STInstance.URLrl;
                TreeNode subNode = new TreeNode(name, id);
                treeNode.ChildNodes.Add(subNode);
                if (node.Count != 0)
                {
                    BindTree(node, subNode);
                }
            }
        }

        #endregion

        /// <summary>
        /// 选择编辑栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tMenus_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                //选中节点值
                string value = tMenus.SelectedNode.Value;
                this.NodeID = value;
                MenuInfo mInfo = new BLL.Menu().GetByID(this.NodeID);
                this.ParentID = mInfo.ParentID;
                tbName.Text = mInfo.Name;
                tbRemark.Text = mInfo.Remark;
                tbSortNum.Text = mInfo.MenuCode;
                tbURL.Text = mInfo.URL;
                //rblIsShow.SelectedIndex = (mInfo.IsShow == true) ? 0 : 1;
                if (string.IsNullOrEmpty(mInfo.Target) == false)
                {
                    rblExtend.SelectedValue = mInfo.Target;
                }
                btnSubmit.Visible = true;
                btnAdd.Visible = true;
                btnDel.Visible = true;
                btnSub.Visible = true;
                // 加载权限组
                rblPower.DataSource = new PermissionGroup().GetList();
                rblPower.DataBind();
                PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(mInfo.ID);
                if (pgInfo != null && string.IsNullOrEmpty(pgInfo.ID) == false)
                {
                    rblPower.SelectedValue = pgInfo.ID;
                    btnRoleBind.Visible = true;
                }
                // 加载角色
                IList<RoleInfo> rList = new Role().GetList();
                cblRole.DataSource = rList;
                cblRole.DataBind();
                IList<RoleInfo> mRoleList = new Role().GetListByMenuID(mInfo.ID);
                foreach (RoleInfo rInfo in mRoleList)
                {
                    cblRole.Items.FindByValue(rInfo.ID).Selected = true;
                }
                // 为选中的角色绑定权限
                gvRoleList.DataSource = mRoleList;
                gvRoleList.DataBind();
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }

        #region 栏目操作
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MenuInfo mInfo = getMenu();
                new BLL.Menu().Update(mInfo);
                BindTree();
                ShowMsg("操作成功。");
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }

        private MenuInfo getMenu()
        {
            MenuInfo mInfo = new MenuInfo();
            mInfo.ID = this.NodeID;
            string parentID = this.ParentID;
            mInfo.Name = tbName.Text;
            mInfo.URL = tbURL.Text;
            mInfo.Remark = tbRemark.Text;
            mInfo.Target = rblExtend.SelectedValue;
            mInfo.MenuCode = tbSortNum.Text;
            return mInfo;
        }
        /// <summary>
        /// 添加同级节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MenuInfo mInfo = getMenu();
                this.NodeID = new BLL.Menu().AddPeer(this.NodeID, mInfo);
                BindTree();
                ShowMsg("操作成功。");
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                MenuInfo mInfo = getMenu();
                this.NodeID = new BLL.Menu().AddChild(this.NodeID, mInfo);
                BindTree();
                ShowMsg("操作成功。");
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string menuID = this.NodeID;
                new BLL.Menu().Delete(menuID);
                BindTree();
                ShowMsg("操作成功。");
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        #region 权限组操作
        protected void btnPowerBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblPower.SelectedIndex == -1)
                {
                    ShowMsg("请选择权限组再绑定到当前栏目。");
                    return;
                }
                if (string.IsNullOrEmpty(this.NodeID))
                {
                    ShowMsg("请选择需要绑定权限组的栏目。");
                    return;
                }
                string powerGroupID = rblPower.SelectedValue;
                new BLL.Menu().AddPermissionGroup(this.NodeID, powerGroupID);
                btnRoleBind.Visible = true;
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        #endregion

        #region 角色权限赋值
        protected void btnRoleBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblPower.SelectedIndex == -1)
                {
                    ShowMsg("请选择权限组绑定。");
                    return;
                }
                if (string.IsNullOrEmpty(this.NodeID))
                {
                    ShowMsg("请选择栏目。");
                    return;
                }
                PermissionGroupInfo pgInfo = new PermissionGroup().GetByMenuID(this.NodeID);
                if (pgInfo == null || string.IsNullOrEmpty(pgInfo.ID))
                {
                    ShowMsg("请先为栏目绑定权限组再添加角色。");
                    return;
                }
                // 绑定选中的角色
                IList<RoleInfo> rList = new Role().GetListByMenuID(this.NodeID);
                new BLL.Menu().AddRolesToMenu(this.NodeID, pgInfo.ID, rList);
                // 显示角色的权限配置列表
                gvRoleList.DataSource = rList;
                gvRoleList.DataBind();
            }
            catch (ArgumentNullException aex)
            {
                ShowMsg(aex.Message);
            }
            catch (Exception exc)
            {
                ShowMsg(exc.Message);
                Log(exc);
            }
        }
        protected void gvRoleList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string ID = e.CommandArgument.ToString();
                int index = Convert.ToInt32(ID);
                if (e.CommandName == "btnDel")
                {
                    //new Role().Delete(ID);
                }
                else
                {
                    #region 控件
                    GridViewRow gvr = (GridViewRow)gvRoleList.Rows[index];
                    TextBox tbName = (TextBox)gvr.FindControl("tbName");
                    TextBox tbRemark = (TextBox)gvr.FindControl("tbRemark");
                    Label lblID = (Label)gvr.FindControl("lblID");
                    #endregion

                    if (e.CommandName == "btnEdit")
                    {
                        //new Role().Update(lblID.Text, tbName.Text, tbRemark.Text);
                    }
                }
                ShowMsg("绑定成功！");
                // 绑定选中的角色
                IList<RoleInfo> rList = new Role().GetListByMenuID(this.NodeID);
                gvRoleList.DataSource = rList;
                gvRoleList.DataBind();
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
                string permissionGroupID = rblPower.SelectedValue;
                IList<PermissionInfo> pList = new Permission().GetList(permissionGroupID);
                CheckBoxList cblPermission = (CheckBoxList)e.Row.FindControl("cblPermission");
                cblPermission.DataSource = pList;
                cblPermission.DataBind();
                // 权限组赋值
                RoleInfo rInfo = e.Row.DataItem as RoleInfo;
                string menuPermissionCode = new BLL.Menu().GetPermissionGroupCodeOfMenuByRole(this.NodeID, rInfo.ID);
                char[] codeArrary = menuPermissionCode.ToCharArray();
                for (int i = 0; i < cblPermission.Items.Count; i++)
                {
                    ListItem item = cblPermission.Items[i];
                    item.Selected = ("0" == codeArrary[i].ToString()) ? false : true;
                }
            }
        }


        #endregion


    }
}

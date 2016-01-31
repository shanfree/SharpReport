using System;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.SharpMemberShip.Model;
using BLL = SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.Utility;
using System.Web.UI.WebControls;

namespace SharpReportWeb.MainFrame
{
    public partial class Main : WebBasePage
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
                return DEFAULT_MENUID;
                // 正式的代码
                //return "1";
            }
        }
        /// <summary>
        /// 权限验证失败时，跳转到登录页
        /// </summary>
        protected override void RediretToLoginPage()
        {
            Response.Redirect("Login.aspx", true);
        }
        #endregion

        /// <summary>
        /// 系统管理栏目的ID
        /// </summary>
        const string ROOT_ID = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bingRepearter(ROOT_ID, rMenu);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        void bingRepearter(string rootID, Repeater rMenu)
        {
            TreeNodeInfo<MenuInfo> cList = new BLL.Menu().GetTreeByUserID(this.UserCacheInfo.ID, rootID);
            //TreeNodeInfo<MenuInfo> cList = new BLL.Menu().GetTree(rootID);
            if (null == cList)
            {
                return;
            }
            rMenu.DataSource = cList.ChildNodeList;
            rMenu.DataBind();
        }

        protected void rMenu_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //  确保处理的是数据行，而不是Header或者Footer
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                MenuInfo mInfo = e.Item.DataItem as MenuInfo;
                if (mInfo != null)
                {
                    string id = mInfo.ID;
                    Repeater r2ndMenu = (Repeater)e.Item.FindControl("r2ndMenu");
                    bingRepearter(id, r2ndMenu);
                    //_subRepeater.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.initSubRepeater);
                }
            }
        }

        protected void r2ndMenu_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //  确保处理的是数据行，而不是Header或者Footer
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                MenuInfo mInfo = e.Item.DataItem as MenuInfo;
                if (mInfo != null)
                {
                    string id = mInfo.ID;
                    Repeater r3rdMenu = (Repeater)e.Item.FindControl("r3rdMenu");
                    bingRepearter(id, r3rdMenu);
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using SIRC.Framework.SharpMemberShip;
using SIRC.Framework.SharpMemberShip.Model;
using BLL = SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.Utility;

namespace SharpReportWeb.MainFrame
{

    public partial class Banner : WebBasePage
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
        const string ROOT_ID = "15";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TreeNodeInfo<MenuInfo> cList = new BLL.Menu().GetTree(ROOT_ID) ;
                    if (null == cList)
                    {
                        return;
                    }
                    rMenu.DataSource = cList.ChildNodeList;
                    rMenu.DataBind();

                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }

        }
    }
}

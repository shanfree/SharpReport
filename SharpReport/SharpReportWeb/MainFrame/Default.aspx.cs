using System;
using SIRC.Framework.SharpMemberShip;

namespace SharpReportWeb.MainFrame
{
    public partial class Default : WebBasePage
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
                //return DEFAULT_MENUID;
                // 正式的代码
                return "1";
            }
        }
        /// <summary>
        /// 权限验证失败时，跳转到登录页
        /// </summary>
        protected override void RediretToLoginPage()
        {
            Response.Redirect("../Login.aspx", true);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }
    }
}

/********************************************************************************************
 * 文件名称:	WebBasePage.cs
 * 设计人员:	严向晖（ｙａｎｘｉａｎｇｈｕｉ＠ｇｍａｉｌ．ｃｏｍ）
 * 设计时间:	2007-09-12
 * 功能描述:	平台的基础页，包含权限验证，更新缓存信息等功能
 *                  具体的业务系统可以重写该类
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *
 ********************************************************************************************/
using System;
using System.Diagnostics;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Configuration;
using SIRC.Framework.SharpMemberShip.Model;
using BLL = SIRC.Framework.SharpMemberShip.BLL;
using SIRC.Framework.Utility;

namespace SIRC.Framework.SharpMemberShip
{

    /// <summary>
    /// 基础页，包含权限验证，更新缓存信息等功能；
    /// 具体的业务系统可以重写该类；
    /// 该页面接收参数guid，为用户登录凭据，登录时，根据该凭据获取用户信息
    /// </summary>
    public class WebBasePage : System.Web.UI.Page
    {
        #region 派生类重写的方法
        /// <summary>
        /// 是否跳转到登录页
        /// </summary>
        public virtual bool CanRediect
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 默认的栏目，表示该栏目不需要用户登录
        /// </summary>
        protected const string DEFAULT_MENUID = "00000";
        /// <summary>
        /// 栏目ID，在派生类中重写
        /// </summary>
        public virtual string MenuID
        {
            get
            {
                return DEFAULT_MENUID;
            }
        }

        /// <summary>
        /// 当前页面失效
        /// </summary>
        protected virtual void AllControlsInVisable()
        {
        }
        /// <summary>
        /// 当用户没有编辑权限时,设置所有信息和操作隐藏,在派生页面中实现
        /// </summary>
        protected virtual void DisableUserToEdit()
        {
        }
        /// <summary>
        /// 如果没有权限，则跳转到登录页
        /// </summary>
        protected virtual void RediretToLoginPage()
        {
            // 通过脚本跳转
            string linkUrl = ConfigurationManager.AppSettings["SiteURL"] + "/Login.aspx";
            string script = string.Format(@"<script>window.top.location = '{0}'</script>", linkUrl);
            if (this.CanRediect)
            {
                litMsg.Text += script;
            }
            // 服务器强制跳转
            //Response.Redirect(linkUrl, false);
        }

        #endregion

        #region 属性

        #region 用户权限
        private const string BASEPAGE_CANVIEW = "BASEPAGE_CANVIEW";
        /// <summary>
        /// 用户是否可以查看
        /// </summary>
        public bool CanView
        {
            get
            {
                if (ViewState[BASEPAGE_CANVIEW] == null)
                {
                    ViewState[BASEPAGE_CANVIEW] = false;
                }
                return (bool)ViewState[BASEPAGE_CANVIEW];
            }
            set { ViewState[BASEPAGE_CANVIEW] = value; }
        }
        private const string BASEPAGE_CANEDIT = "BASEPAGE_CANEDIT";
        /// <summary>
        /// 用户是否可以编辑
        /// </summary>
        public bool CanEdit
        {
            get
            {
                if (ViewState[BASEPAGE_CANEDIT] == null)
                {
                    ViewState[BASEPAGE_CANEDIT] = false;
                }
                return (bool)ViewState[BASEPAGE_CANEDIT];
            }
            set { ViewState[BASEPAGE_CANEDIT] = value; }
        }
        #endregion

        #region 系统变量

        /// <summary>
        /// 用户登录后缓存的信息
        /// </summary>
        public UserInfo UserCacheInfo
        {
            get
            {
                if (null == HttpContext.Current.Session["UserInfo"])
                {
                    this.UserCacheInfo = new UserInfo();
                }
                return HttpContext.Current.Session["UserInfo"] as UserInfo;
            }
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }

        #endregion

        #endregion

        #region 载入
        /// <summary>
        /// 页面载入时进行权限判断
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bool isNeedToLogin = NeedToLogin();
                    if (isNeedToLogin == true)
                    {
                        // 用户未登陆，当前为具有权限的栏目,则跳转到登录页
                        this.CanView = false;
                        return;
                    }
                    // 登录页判断权限
                    UserAccessToThisPage();
                }
                base.OnLoad(e);
            }
            catch (ApplicationException)
            {
                this.CanView = false;
            }
            catch (Exception ex)
            {
                Log(ex.ToString(), EventLogEntryType.Error);
            }
        }
        /// <summary>
        /// 处理用户未登录,判断当前页是否需要跳转到登录页
        /// </summary>
        /// <returns>True:跳转到登陆页；False:用户已经登录或者无需登录</returns>
        private bool NeedToLogin()
        {
            // 用户是否登录过
            if (string.IsNullOrEmpty(this.UserCacheInfo.GUID))
            {
                // 若用户在默认栏目无权限要求,则不跳转
                if (this.MenuID == DEFAULT_MENUID)
                {
                    return false;
                }
                string guid = GetRequest("guid");
                if (string.IsNullOrEmpty(guid))
                {
                    // 要求权限并且无凭据
                    return true;
                }
                else
                {
                    // 要求权限，则通过凭据获取用户信息
                    UserInfo uInfo = new BLL.User().GetUserInfoByGuid(guid);
                    this.UserCacheInfo = uInfo;
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 用户对当前页面的访问权限
        /// </summary>
        private void UserAccessToThisPage()
        {
            // 用户无权查看,页面隐藏,提示用户
            if (this.MenuID == DEFAULT_MENUID)
            {
                // 默认栏目无权限要求
                this.CanView = true;
                this.CanEdit = true;
                return;
            }
            if (!this.CanUserAccessToThisMenu(this.MenuID))
            {
                // 无权查看
                AllControlsInVisable();
                return;
            }
            else
            {
                // 有权访问栏目
                this.CanView = true;
            }
            // 是否有编辑权限
            if (!this.CanUserProcessOperation(DefaultPermissions.修改))
            {
                // 无权更改,具体页面中设置相关按钮为隐藏
                this.CanEdit = false;
                DisableUserToEdit();
            }
            this.CanEdit = true;
        }

        #endregion

        #region 重写的方法
        /// <summary>
        /// 载入完毕后,对设置为不可见的页面跳转到登陆页
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.CanView == false)
            {
                if (this.CanRediect)
                {
                    this.ShowMsg("您没有权限访问该页面，请联系管理员。");
                }
                RediretToLoginPage();
            }
            base.OnPreRender(e);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void CreateChildControls()
        {
            litMsg.Visible = true;
            this.Controls.Add(litMsg);
            if (IsPostBack)
            {
                // 第一次载入 onInitial->pageload->CreateChildControls
                // 回发 onInitial->CreateChildControls->pageload
                litMsg.Text = "";
            }

            base.CreateChildControls();
        }
        #endregion

        #region 公共的方法

        /// <summary>
        /// 判断当前用户是否能否访问该页
        /// </summary>
        /// <param name="menuID">该页对应的栏目ID</param>
        /// <returns>布尔值</returns>
        protected bool CanUserAccessToThisMenu(string menuID)
        {
            if (menuID == null || menuID == string.Empty)
            {
                throw new Exception("栏目ID未赋值.");
            }
            IList<MenuInfo> mList = this.UserCacheInfo.MenuList;
            foreach (MenuInfo mInfo in mList)
            {
                if (mInfo.ID == menuID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证用户是否有权限做该操作
        /// </summary>
        /// <param name="menuPower">操作所需的权限<seealso cref="MenuPower"/></param>
        /// <returns>布尔值</returns>
        protected bool CanUserProcessOperation(DefaultPermissions permission)
        {
            try
            {
                // 权限验证
                string signOnValidGuid = this.UserCacheInfo.GUID;
                // 当前栏目ID，在派生类中重写
                string menuID = this.MenuID;
                return new BLL.Menu().CanUserProcessOperation(permission, menuID,signOnValidGuid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 验证用户是否有权限做该操作
        /// </summary>
        /// <param name="menuPower">操作所需的权限<seealso cref="MenuPower"/></param>
        /// <param name="menuID">栏目ID</param>
        /// <returns>布尔值</returns>
        protected bool CanUserDoTheOperation(int permission)
        {
            try
            {
                // 权限验证
                string signOnValidGuid = this.UserCacheInfo.GUID;
                // 当前栏目ID，在派生类中重写
                string menuID = this.MenuID;
                return new BLL.Menu().CanUserProcessOperation(permission, signOnValidGuid, menuID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///将消息作为错误记入日志 
        /// </summary>
        /// <param name="message">消息</param>
        protected void Log(string message)
        {
            Log(message, EventLogEntryType.Error);
        }
        /// <summary>
        ///将消息作为错误记入日志 
        /// </summary>
        /// <param name="message">消息</param>
        protected void Log(Exception ex)
        {
            Log(ex.ToString(), EventLogEntryType.Error);
        }

        /// <summary>
        ///将消息记入日志 
        /// </summary>
        /// <param name="message">消息</param>
        protected void Log(string message, EventLogEntryType logType)
        {
            try
            {
                string userName = this.UserCacheInfo.Name;
                string menuName = string.Empty;
                if (string.IsNullOrEmpty(this.MenuID))
                {
                    MenuInfo mInfo = new BLL.Menu().GetByID(this.MenuID);
                    if (null == mInfo)
                    {
                        menuName = this.MenuID;
                    }
                    else
                    {
                        menuName = mInfo.Name;
                    }
                }
                string fullMsg =
                    string.Format("用户({0})于{1}访问资源（Menu：{2}时发生如下错误：{3}。请联系系统管理员解决。）",
                    userName, DateTime.Now.ToLongDateString(), menuName, message);
                LogEntry.Log.Write(message, logType, this.MenuID);
            }
            catch (Exception ex)
            {
                // 日志模块失败，为便于调试直接输出错误信息
                // TODO:使用其他持久化介质
                Response.Write(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
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


        /// <summary>
        /// 初始化页面缓存变量
        /// </summary>
        /// <param name="key">缓存的键值</param>
        protected string GetViewState(string key)
        {
            if (ViewState[key] == null)
            {
                ViewState[key] = String.Empty;
            }
            return ViewState[key].ToString();
        }
        /// <summary>
        /// 初始化页面缓存变量
        /// </summary>
        /// <param name="key">缓存的键值</param>
        protected string GetSession(string key)
        {
            if (Session[key] == null)
            {
                Session[key] = String.Empty;
            }
            return Session[key].ToString();
        }
        /// <summary>
        /// 获取URL参数
        /// </summary>
        /// <param name="keyword">参数名称</param>
        /// <returns>参数值</returns>
        protected string GetRequest(string keyword)
        {
            string param = Request[keyword];
            if (string.IsNullOrEmpty(param))
            {
                return string.Empty;
            }
            return param.Trim();
        }

        /// <summary>
        /// 栏目帮助文本赋值
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        protected void TitleInitial(string title, string text)
        {
            if (this.Master == null)
            {
                return;
            }
            Label lbTitle = (Label)(this.Master.FindControl("lbTitle"));
            if (lbTitle == null)
            {
                return;
            }
            lbTitle.Text = title;
            Label lbText = (Label)(this.Master.FindControl("lbText"));
            if (lbText == null)
            {
                return;
            }
            lbText.Text = text;
        }
        #endregion
    }
}

/********************************************************************************************
 * �ļ�����:	WebBasePage.cs
 * �����Ա:	�����ͣ����������������������죮����
 * ���ʱ��:	2007-09-12
 * ��������:	ƽ̨�Ļ���ҳ������Ȩ����֤�����»�����Ϣ�ȹ���
 *                  �����ҵ��ϵͳ������д����
 *		
 *		
 * ע������:	
 *
 * ��Ȩ����:	Copyright (c) 2007, Fujian SIRC
 *
 * �޸ļ�¼: 	�޸�ʱ��		��Ա		�޸ı�ע
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
    /// ����ҳ������Ȩ����֤�����»�����Ϣ�ȹ��ܣ�
    /// �����ҵ��ϵͳ������д���ࣻ
    /// ��ҳ����ղ���guid��Ϊ�û���¼ƾ�ݣ���¼ʱ�����ݸ�ƾ�ݻ�ȡ�û���Ϣ
    /// </summary>
    public class WebBasePage : System.Web.UI.Page
    {
        #region ��������д�ķ���
        /// <summary>
        /// �Ƿ���ת����¼ҳ
        /// </summary>
        public virtual bool CanRediect
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// Ĭ�ϵ���Ŀ����ʾ����Ŀ����Ҫ�û���¼
        /// </summary>
        protected const string DEFAULT_MENUID = "00000";
        /// <summary>
        /// ��ĿID��������������д
        /// </summary>
        public virtual string MenuID
        {
            get
            {
                return DEFAULT_MENUID;
            }
        }

        /// <summary>
        /// ��ǰҳ��ʧЧ
        /// </summary>
        protected virtual void AllControlsInVisable()
        {
        }
        /// <summary>
        /// ���û�û�б༭Ȩ��ʱ,����������Ϣ�Ͳ�������,������ҳ����ʵ��
        /// </summary>
        protected virtual void DisableUserToEdit()
        {
        }
        /// <summary>
        /// ���û��Ȩ�ޣ�����ת����¼ҳ
        /// </summary>
        protected virtual void RediretToLoginPage()
        {
            // ͨ���ű���ת
            string linkUrl = ConfigurationManager.AppSettings["SiteURL"] + "/Login.aspx";
            string script = string.Format(@"<script>window.top.location = '{0}'</script>", linkUrl);
            if (this.CanRediect)
            {
                litMsg.Text += script;
            }
            // ������ǿ����ת
            //Response.Redirect(linkUrl, false);
        }

        #endregion

        #region ����

        #region �û�Ȩ��
        private const string BASEPAGE_CANVIEW = "BASEPAGE_CANVIEW";
        /// <summary>
        /// �û��Ƿ���Բ鿴
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
        /// �û��Ƿ���Ա༭
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

        #region ϵͳ����

        /// <summary>
        /// �û���¼�󻺴����Ϣ
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

        #region ����
        /// <summary>
        /// ҳ������ʱ����Ȩ���ж�
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
                        // �û�δ��½����ǰΪ����Ȩ�޵���Ŀ,����ת����¼ҳ
                        this.CanView = false;
                        return;
                    }
                    // ��¼ҳ�ж�Ȩ��
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
        /// �����û�δ��¼,�жϵ�ǰҳ�Ƿ���Ҫ��ת����¼ҳ
        /// </summary>
        /// <returns>True:��ת����½ҳ��False:�û��Ѿ���¼���������¼</returns>
        private bool NeedToLogin()
        {
            // �û��Ƿ��¼��
            if (string.IsNullOrEmpty(this.UserCacheInfo.GUID))
            {
                // ���û���Ĭ����Ŀ��Ȩ��Ҫ��,����ת
                if (this.MenuID == DEFAULT_MENUID)
                {
                    return false;
                }
                string guid = GetRequest("guid");
                if (string.IsNullOrEmpty(guid))
                {
                    // Ҫ��Ȩ�޲�����ƾ��
                    return true;
                }
                else
                {
                    // Ҫ��Ȩ�ޣ���ͨ��ƾ�ݻ�ȡ�û���Ϣ
                    UserInfo uInfo = new BLL.User().GetUserInfoByGuid(guid);
                    this.UserCacheInfo = uInfo;
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// �û��Ե�ǰҳ��ķ���Ȩ��
        /// </summary>
        private void UserAccessToThisPage()
        {
            // �û���Ȩ�鿴,ҳ������,��ʾ�û�
            if (this.MenuID == DEFAULT_MENUID)
            {
                // Ĭ����Ŀ��Ȩ��Ҫ��
                this.CanView = true;
                this.CanEdit = true;
                return;
            }
            if (!this.CanUserAccessToThisMenu(this.MenuID))
            {
                // ��Ȩ�鿴
                AllControlsInVisable();
                return;
            }
            else
            {
                // ��Ȩ������Ŀ
                this.CanView = true;
            }
            // �Ƿ��б༭Ȩ��
            if (!this.CanUserProcessOperation(DefaultPermissions.�޸�))
            {
                // ��Ȩ����,����ҳ����������ذ�ťΪ����
                this.CanEdit = false;
                DisableUserToEdit();
            }
            this.CanEdit = true;
        }

        #endregion

        #region ��д�ķ���
        /// <summary>
        /// ������Ϻ�,������Ϊ���ɼ���ҳ����ת����½ҳ
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.CanView == false)
            {
                if (this.CanRediect)
                {
                    this.ShowMsg("��û��Ȩ�޷��ʸ�ҳ�棬����ϵ����Ա��");
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
                // ��һ������ onInitial->pageload->CreateChildControls
                // �ط� onInitial->CreateChildControls->pageload
                litMsg.Text = "";
            }

            base.CreateChildControls();
        }
        #endregion

        #region �����ķ���

        /// <summary>
        /// �жϵ�ǰ�û��Ƿ��ܷ���ʸ�ҳ
        /// </summary>
        /// <param name="menuID">��ҳ��Ӧ����ĿID</param>
        /// <returns>����ֵ</returns>
        protected bool CanUserAccessToThisMenu(string menuID)
        {
            if (menuID == null || menuID == string.Empty)
            {
                throw new Exception("��ĿIDδ��ֵ.");
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
        /// ��֤�û��Ƿ���Ȩ�����ò���
        /// </summary>
        /// <param name="menuPower">���������Ȩ��<seealso cref="MenuPower"/></param>
        /// <returns>����ֵ</returns>
        protected bool CanUserProcessOperation(DefaultPermissions permission)
        {
            try
            {
                // Ȩ����֤
                string signOnValidGuid = this.UserCacheInfo.GUID;
                // ��ǰ��ĿID��������������д
                string menuID = this.MenuID;
                return new BLL.Menu().CanUserProcessOperation(permission, menuID,signOnValidGuid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��֤�û��Ƿ���Ȩ�����ò���
        /// </summary>
        /// <param name="menuPower">���������Ȩ��<seealso cref="MenuPower"/></param>
        /// <param name="menuID">��ĿID</param>
        /// <returns>����ֵ</returns>
        protected bool CanUserDoTheOperation(int permission)
        {
            try
            {
                // Ȩ����֤
                string signOnValidGuid = this.UserCacheInfo.GUID;
                // ��ǰ��ĿID��������������д
                string menuID = this.MenuID;
                return new BLL.Menu().CanUserProcessOperation(permission, signOnValidGuid, menuID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///����Ϣ��Ϊ���������־ 
        /// </summary>
        /// <param name="message">��Ϣ</param>
        protected void Log(string message)
        {
            Log(message, EventLogEntryType.Error);
        }
        /// <summary>
        ///����Ϣ��Ϊ���������־ 
        /// </summary>
        /// <param name="message">��Ϣ</param>
        protected void Log(Exception ex)
        {
            Log(ex.ToString(), EventLogEntryType.Error);
        }

        /// <summary>
        ///����Ϣ������־ 
        /// </summary>
        /// <param name="message">��Ϣ</param>
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
                    string.Format("�û�({0})��{1}������Դ��Menu��{2}ʱ�������´���{3}������ϵϵͳ����Ա�������",
                    userName, DateTime.Now.ToLongDateString(), menuName, message);
                LogEntry.Log.Write(message, logType, this.MenuID);
            }
            catch (Exception ex)
            {
                // ��־ģ��ʧ�ܣ�Ϊ���ڵ���ֱ�����������Ϣ
                // TODO:ʹ�������־û�����
                Response.Write(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected Literal litMsg = new Literal();

        /// <summary>
        /// ��ҳ���ڵ�������ʾ�û���Ϣ
        /// </summary>
        /// <param name="message"></param>
        public void ShowMsg(string message)
        {
            // ���˵����з�
            message = message.Replace("\r\n", " ");
            message = message.Replace("'", "\"");
            litMsg.Text = string.Format("<script>alert('{0}')</script>", message);
            litMsg.Visible = true;
        }


        /// <summary>
        /// ��ʼ��ҳ�滺�����
        /// </summary>
        /// <param name="key">����ļ�ֵ</param>
        protected string GetViewState(string key)
        {
            if (ViewState[key] == null)
            {
                ViewState[key] = String.Empty;
            }
            return ViewState[key].ToString();
        }
        /// <summary>
        /// ��ʼ��ҳ�滺�����
        /// </summary>
        /// <param name="key">����ļ�ֵ</param>
        protected string GetSession(string key)
        {
            if (Session[key] == null)
            {
                Session[key] = String.Empty;
            }
            return Session[key].ToString();
        }
        /// <summary>
        /// ��ȡURL����
        /// </summary>
        /// <param name="keyword">��������</param>
        /// <returns>����ֵ</returns>
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
        /// ��Ŀ�����ı���ֵ
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

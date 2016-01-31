using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIRC.Framework.WebControlLib
{
    [PersistChildren(false)]
    [ParseChildren(true)]
    [NonVisualControl]
    public class JavaScriptUpdater : Control
    {
        private const string BasicScripts =
@"if (!window.UpdatePanels) window.UpdatePanels = {};
UpdatePanels._createUpdateMethod = 
function(btnId)
{
	return function()
            {
	            __doPostBack(btnId, '');
            }
}";

        private const string RegisterMethodTemplate =
            "\nUpdatePanels['{0}'] = UpdatePanels._createUpdateMethod('{1}');";

        private string clientButtonId = null;
        private bool initialized = false;

        private bool _Enabled = true;

        public bool Enabled
        {
            get
            {
                return this._Enabled;
            }
            set
            {
                if (this.initialized)
                {
                    throw new InvalidOperationException("Cannot set the property after initialized.");
                }

                this._Enabled = value;
            }
        }


        private string _MethodName;

        public string MethodName
        {
            get
            {
                return this._MethodName;
            }
            set
            {
                if (this.initialized)
                {
                    throw new InvalidOperationException("Cannot set the property after initialized.");
                }

                this._MethodName = value;
            }
        }

        public event EventHandler<ResolveUpdatePanelEventArgs> ResolveUpdatePanel;

        private List<UpdatePanel> _UpdatePanels = new List<UpdatePanel>();

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<UpdatePanel> UpdatePanels
        {
            get
            {
                return _UpdatePanels;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Page.InitComplete += new EventHandler(Page_InitComplete);
        }

        private void Page_InitComplete(object sender, EventArgs e)
        {
            this.initialized = true;

            if (this.Enabled)
            {
                this.Page.Load += new EventHandler(Page_Load);
                this.Page.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
            }
        }

        private void Page_PreRenderComplete(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(),
                "BasicScripts",
                JavaScriptUpdater.BasicScripts,
                true);

            this.Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(),
                this.clientButtonId,
                String.Format(JavaScriptUpdater.RegisterMethodTemplate, this.MethodName, this.clientButtonId),
                true);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            LinkButton button = new LinkButton();
            button.Text = "Update";
            button.ID = this.ID + "Button";
            button.Style[HtmlTextWriterStyle.Display] = "none";
            //模拟按钮点击事件，冒泡为整个控件的事件
            button.Click += new EventHandler(OnTrigger);
            this.Page.Form.Controls.Add(button);

            this.clientButtonId = button.UniqueID;
            ScriptManager.GetCurrent(this.Page).RegisterAsyncPostBackControl(button);
        }

        private void OnTrigger(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                foreach (UpdatePanel panel in this.UpdatePanels)
                {
                    string id = panel.UpdatePanelID;
                    System.Web.UI.UpdatePanel updatePanel = this.FindUpdatePanel(id);
                    // 激发OnResolveUpdatePanel事件，刷新UpdatePanel
                    ResolveUpdatePanelEventArgs re = new ResolveUpdatePanelEventArgs(id);
                    this.OnResolveUpdatePanel(re);
                    if (re.UpdatePanel != null)
                    {
                        updatePanel = re.UpdatePanel;
                    }
                    if (updatePanel != null)
                    {
                        updatePanel.Update();
                    }
                }
            }
        }

        private System.Web.UI.UpdatePanel FindUpdatePanel(string id)
        {
            System.Web.UI.UpdatePanel result =
                this.NamingContainer.FindControl(id) as System.Web.UI.UpdatePanel;

            return result;
        }

        private void OnResolveUpdatePanel(ResolveUpdatePanelEventArgs e)
        {
            if (this.ResolveUpdatePanel != null)
            {
                this.ResolveUpdatePanel(this, e);
            }
        }

        #region IPostBackEventHandler 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaisePostBackEvent(string eventArgument)
        {
            ResolveUpdatePanelEventArgs e = new ResolveUpdatePanelEventArgs(eventArgument);
            if (this.ResolveUpdatePanel != null)
            {
                this.ResolveUpdatePanel(this, e);
            }
        }

        #endregion
    }
}

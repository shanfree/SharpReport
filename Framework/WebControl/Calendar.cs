/********************************************************************************************
 * �ļ�����:	Calendar.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-24
 * ��������:	���ڿؼ�
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace SIRC.Framework.WebControlLib
{
    /// <summary>
    /// ���ڿؼ�
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>"), Designer(typeof(ControlDesigner), typeof(IDesigner))]
    public class Calendar : TextBox
    {
        private string _scriptPath = "../My97DatePicker/WdatePicker.js";
        /// <summary>
        /// �ű��ļ�·��
        /// </summary>
        public string ScriptPath
        {
            get
            {
                return this._scriptPath;
            }
            set
            {
                this._scriptPath = value;
            }
        }
        private string ScriptName = "DatePicker";

        /// <summary>
        /// ��д�����������
        /// </summary>
        /// <param name="writer">Ҫд������ HTML ��д��</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.Attributes.Add("onClick", "WdatePicker();");
            base.Attributes.Add("class", "Wdate");
            base.AddAttributesToRender(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            string format = "   <script src=\"{0}\" type=\"text/javascript\"></script>  ";
            format = string.Format(format, this.ScriptPath);
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.ScriptName))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), this.ScriptName, format, false);
            }
        }

        /// <summary>
        /// ��дHtml�������
        /// </summary>
        /// <param name="writer">Ҫд������ HTML ��д��</param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
        
    }
}

/********************************************************************************************
 * 文件名称:	Calendar.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-24
 * 功能描述:	日期控件
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace SIRC.Framework.WebControlLib
{
    /// <summary>
    /// 日期控件
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>"), Designer(typeof(ControlDesigner), typeof(IDesigner))]
    public class Calendar : TextBox
    {
        private string _scriptPath = "../My97DatePicker/WdatePicker.js";
        /// <summary>
        /// 脚本文件路径
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
        /// 重写属性输出函数
        /// </summary>
        /// <param name="writer">要写出到的 HTML 编写器</param>
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
        /// 重写Html输出函数
        /// </summary>
        /// <param name="writer">要写出到的 HTML 编写器</param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
        
    }
}

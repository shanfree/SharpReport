/********************************************************************************************
 * 文件名称:	ExcelGenButton.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-24
 * 功能描述:	表格数据按Excel文件导出按钮
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace SIRC.Framework.WebControlLib
{
    /// <summary>
    /// Excel文件导出按钮
    /// </summary>
    [DesignerAttribute(typeof(ControlDesigner), typeof(IDesigner)),
DefaultProperty("Text"), ToolboxData("<{0}:ExcelGenButton Text=\"生成Excel\" runat=server></{0}:ExcelGenButton>")]
    public class ExcelGenButton : Button
    {
        private string _gridviewID;
        /// <summary>
        /// 控制输出的gridviewID
        /// </summary>
        public string GridViewID
        {
            get { return _gridviewID; }
            set { _gridviewID = value; }
        }

        private string _fileName = "";
        /// <summary>
        /// Excel文件下载后,客户端保存的名称
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// 得到不显示的列ID
        /// </summary>
        /// <returns>IList</returns>
        private IList<int> getGridViewUnSelectColumnIndexList()
        {
            GridView gv = this.Parent.FindControl(this.GridViewID) as GridView;

            if (gv == null || gv.HeaderRow == null)
            {
                return null;
            }

            IList<int> unselIndex = new List<int>();
            int cntIndex = 0;
            foreach (TableCell cell in gv.HeaderRow.Cells)
            {
                foreach (Control control in cell.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox chk = control as CheckBox;
                        if (chk.Checked == false)
                        {
                            unselIndex.Add(cntIndex);
                        }
                    }
                }
                cntIndex++;
            }
            return unselIndex;

        }
        /// <summary>
        /// 隐藏选中的列
        /// </summary>
        /// <param name="unselIndex">不显示的列ID列表</param>
        private void gridViewUnselectColumnInVisable(IList<int> unselIndex)
        {
            GridView gv = this.Parent.FindControl(this.GridViewID) as GridView;

            if (gv == null || gv.HeaderRow == null)
            {
                return;
            }

            int cellIndex = 0;
            foreach (TableCell cell in gv.HeaderRow.Cells)
            {
                if (unselIndex.Count > 0)
                {
                    int i = unselIndex[0];
                    if (i == cellIndex)
                    {
                        gv.Columns[i].Visible = false;
                        unselIndex.RemoveAt(0);
                    }
                }
                foreach (Control control in cell.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox chk = control as CheckBox;
                        chk.Visible = false;
                    }
                }
                cellIndex++;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            #region 输出列判断
            IList<int> unselIndex = getGridViewUnSelectColumnIndexList();
            base.OnClick(e);
            if (unselIndex != null)
            {
                gridViewUnselectColumnInVisable(unselIndex);
            }
            else
            {
                //为选择导出列的则默认导出所有的列
                GridView gv = this.Parent.FindControl(this.GridViewID) as GridView;
                if (gv != null && gv.HeaderRow != null)
                {
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        foreach (Control control in cell.Controls)
                        {
                            if (control.GetType() == typeof(CheckBox))
                            {
                                CheckBox chk = control as CheckBox;
                                chk.Visible = false;
                            }
                        }
                    }
                }
            }
            #endregion

            if (string.IsNullOrEmpty(FileName))
            {
                FileName = this.Page.Title;
            }
            string strFileName = HttpUtility.UrlEncode(Encoding.UTF8.GetBytes(FileName + ".xls"));
            HttpResponse response = HttpContext.Current.Response;
            // 设置编码和附件格式 
            response.Clear();
            response.Buffer = true;
            response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName));

            response.ContentType = "application/vnd.ms-excel";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.Charset = "";

            // IO用于导出并返回excel文件 
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

            #region 找到GridView,调用Render
            if (this.GridViewID.IndexOf(",") != -1)
            {
                //多个GridView合并一个Excel导出
                string[] gvID = this.GridViewID.Split(',');

                foreach (string var in gvID)
                {
                    GridView gv = this.Parent.FindControl(var) as GridView;
                    if (gv == null)
                    {
                        return;
                    }
                    gv.RenderControl(oHtmlTextWriter);
                }
            }
            else
            {
                //单个GridView合并一个Excel导出
                GridView gv = this.Parent.FindControl(this.GridViewID) as GridView;
                if (gv == null)
                {
                    return;
                }
                gv.RenderControl(oHtmlTextWriter);
            }

            #endregion

            response.Output.Write(oStringWriter.ToString());
            response.Flush();
            response.End();
        }
    }
}

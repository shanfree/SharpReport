/********************************************************************************************
 * �ļ�����:	ExcelGenButton.cs
 * �����Ա:	������
 * ���ʱ��:	2007-09-24
 * ��������:	������ݰ�Excel�ļ�������ť
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
    /// Excel�ļ�������ť
    /// </summary>
    [DesignerAttribute(typeof(ControlDesigner), typeof(IDesigner)),
DefaultProperty("Text"), ToolboxData("<{0}:ExcelGenButton Text=\"����Excel\" runat=server></{0}:ExcelGenButton>")]
    public class ExcelGenButton : Button
    {
        private string _gridviewID;
        /// <summary>
        /// ���������gridviewID
        /// </summary>
        public string GridViewID
        {
            get { return _gridviewID; }
            set { _gridviewID = value; }
        }

        private string _fileName = "";
        /// <summary>
        /// Excel�ļ����غ�,�ͻ��˱��������
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// �õ�����ʾ����ID
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
        /// ����ѡ�е���
        /// </summary>
        /// <param name="unselIndex">����ʾ����ID�б�</param>
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
            #region ������ж�
            IList<int> unselIndex = getGridViewUnSelectColumnIndexList();
            base.OnClick(e);
            if (unselIndex != null)
            {
                gridViewUnselectColumnInVisable(unselIndex);
            }
            else
            {
                //Ϊѡ�񵼳��е���Ĭ�ϵ������е���
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
            // ���ñ���͸�����ʽ 
            response.Clear();
            response.Buffer = true;
            response.AddHeader("content-disposition", string.Format("attachment; filename={0}", strFileName));

            response.ContentType = "application/vnd.ms-excel";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");
            response.Charset = "";

            // IO���ڵ���������excel�ļ� 
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);

            #region �ҵ�GridView,����Render
            if (this.GridViewID.IndexOf(",") != -1)
            {
                //���GridView�ϲ�һ��Excel����
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
                //����GridView�ϲ�һ��Excel����
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

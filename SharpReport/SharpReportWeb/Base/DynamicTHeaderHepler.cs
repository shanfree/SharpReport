//
//***********************************************************************
//  Created: 2007-10-29    Author:  ruijc
//  File: DynamicTHeaderHepler.cs
//  Description: 动态生成复合表头帮助类
//  相邻父列头之间用','分隔,父列头与子列头用空格('|')分隔
//
//  http://blog.csdn.net/langxiaodi/article/details/4732290
/*
    调用说明:使用时在GridView的RowCreated事件中加入下面代码调用

 
    if (e.Row.RowType == DataControlRowType.Header)
    {
        DynamicTHeaderHepler dHelper = new DynamicTHeaderHepler();
        string header = "序号,船舶," +
                       "油耗量（吨）|辅机|GO/FO|A,油耗量（吨）|主机|GO/DO|B,油耗量（吨）|辅机|FO|C,油耗量（吨）|锅炉|GO/DO|D,油耗量（吨）|锅炉|FO|E," +
                       "油耗量（吨）|其他|F,油耗量（吨）|合计|G=A+B+C+D+E+F,油耗量（吨）|重油比|H," +
                       "运行时间（天）|辅机|I,运行时间（天）|主机|J,航行公里|K,千吨公里|L," +
                       "平均消耗量|辅机（吨/天）|M=A/I,平均消耗量|主机（吨/天）|N=（B+C）/J,平均消耗量|航行公里（KG）|O=G/K*1000,平均消耗量|千吨公里（KG）|P=G/L*1000," +
                       "统计开始时间,统计结束时间";

        dHelper.SplitTableHeader(e.Row, header);
    }*/
//***********************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections;

namespace SharpReportWeb.Base
{
    public class DynamicTHeaderHepler
    {
        public DynamicTHeaderHepler()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 重写表头
        /// </summary>
        /// <param name="targetHeader">目标表头</param>
        /// <param name="newHeaderNames">新表头</param>
        /// <remarks>
        public void genHeader(string headerText, GridView gv, Object sender, GridViewRowEventArgs e)
        {
            int layerCount = 0;//层数  
            ArrayList oldCells = new ArrayList();

            int iCellCount = e.Row.Cells.Count;//列数  
            foreach (TableCell oldtc in e.Row.Cells)
            {
                oldCells.Add(oldtc);
            }

            for (int k = 0; k < iCellCount; k++)//将gvHeadText中的列名付给oldcells  
            {
                //((TableCell)oldCells[k]).Text = ((string)ViewState["GridviewHeadText"]).Split(',')[k].ToString();
                ((TableCell)oldCells[k]).Text = headerText.Split(',')[k].ToString();
            }
            //获取最大层数  
            for (int i = 0; i < iCellCount; i++)
            {
                int t = ((TableCell)oldCells[i]).Text.Split('|').Length;
                if (t > layerCount)
                {
                    layerCount = t;
                }
            }
            e.Row.Cells.Clear();
            TableHeaderCell tc = null;
            int flag = 0;
            int flag1 = 1;
            //处理行  
            for (int i = 1; i <= layerCount; i++)
            {
                for (int j = 1; j <= oldCells.Count; j++)
                {
                    string[] arr = ((TableCell)oldCells[j - 1]).Text.Split('|');
                    if (arr.Length == i)
                    {
                        tc = new TableHeaderCell();
                        if (layerCount - i > 0)
                        {
                            tc.RowSpan = layerCount - i + 1;//定义表头的所占的行数    
                        }
                        tc.Text = arr[i - 1];

                        tc.CssClass = gv.HeaderStyle.CssClass;
                        tc.HorizontalAlign = gv.HeaderStyle.HorizontalAlign;
                        tc.VerticalAlign = gv.HeaderStyle.VerticalAlign;
                        tc.BackColor = gv.HeaderStyle.BackColor;
                        tc.BorderColor = gv.HeaderStyle.BorderColor;
                        tc.BorderStyle = gv.HeaderStyle.BorderStyle;
                        tc.BorderWidth = gv.HeaderStyle.BorderWidth;
                        tc.ForeColor = gv.HeaderStyle.ForeColor;
                        tc.Width = gv.HeaderStyle.Width;
                        tc.Height = gv.HeaderStyle.Height;

                        if (j != oldCells.Count)
                        {
                            for (int k = j + 1; k < oldCells.Count; k++)
                            {
                                if (((TableCell)oldCells[j - 1]).Text == ((TableCell)oldCells[k - 1]).Text)
                                {
                                    flag1++;
                                    oldCells.RemoveAt(k - 1);
                                    tc.ColumnSpan = flag1;
                                }
                            }
                            flag1 = 1;
                        }

                        e.Row.Cells.Add(tc);
                    }
                    else if (arr.Length > i)
                    {
                        flag++;
                        if (j >= oldCells.Count || ((TableCell)oldCells[j]).Text.Split('|').Length < i || arr[i - 1] != ((TableCell)oldCells[j]).Text.Split('|')[i - 1])
                        {
                            tc = new TableHeaderCell();
                            tc.ColumnSpan = flag;
                            tc.Text = arr[i - 1];

                            tc.CssClass = gv.HeaderStyle.CssClass;
                            tc.HorizontalAlign = gv.HeaderStyle.HorizontalAlign;
                            tc.VerticalAlign = gv.HeaderStyle.VerticalAlign;
                            tc.BackColor = gv.HeaderStyle.BackColor;
                            tc.BorderColor = gv.HeaderStyle.BorderColor;
                            tc.BorderStyle = gv.HeaderStyle.BorderStyle;
                            tc.BorderWidth = gv.HeaderStyle.BorderWidth;
                            tc.ForeColor = gv.HeaderStyle.ForeColor;
                            tc.Width = gv.HeaderStyle.Width;
                            tc.Height = gv.HeaderStyle.Height;

                            e.Row.Cells.Add(tc);
                            flag = 0;
                        }
                    }
                }
                if (i < layerCount)
                {
                    if (tc != null)
                    {
                        tc.Text += "</tr><tr>";
                    }
                }
            }
        }
    }
}


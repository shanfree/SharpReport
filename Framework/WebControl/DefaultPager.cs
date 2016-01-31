/********************************************************************************************
 * 文件名称:	DefaultPager.cs
 * 设计人员:	严向晖
 * 设计时间:	2007-09-24
 * 功能描述:	分页控件
 *		
 *		
 * 注意事项:	
 *
 * 版权所有:	Copyright (c) 2007, Fujian SIRC
 *
 * 修改记录: 	修改时间		人员		修改备注
 *				----------		------		-------------------------------------------------
 *              20090306    yanxh       增加跳转按钮
 ********************************************************************************************/
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIRC.Framework.WebControlLib
{
    /// <summary>
    /// 分页控件
    /// </summary>
    [ToolboxData("<{0}:DefaultPager runat=server></{0}:DefaultPager>"), DefaultProperty("Text")]
    public class DefaultPager : WebControl, INamingContainer
    {
        // Fields
        private AlignType align;
        //是否创建上一页按钮
        private bool isprepage = true;
        //是否创建下一页按钮
        private bool ifnextpage = true;
        //是否创建首页按钮
        private bool isfirstpage = true;
        //是否创建尾页按钮
        private bool islastpage = true;
        //是否设置字体大小
        private bool isfontsize = false;
        //是否创建跳转按钮
        private bool isgopage = true;
        //是否创建下N页按钮
        private bool isnextcrosspage;
        //是否创建上N 页按钮
        private bool isprecrosspage;
        // 程序使用
        //是否还有下一页
        private bool isnext;
        //是否还有上一页
        private bool ispre;
        //选择跳转的类型
        private JumpChoose jumptype = JumpChoose.TextBox;
        //总页数
        private int m_allpagenum;
        //上,下多少页
        private int m_crosspagenum = 10;
        // 当前的页码
        private int m_curpagenumber;
        // 字体大小
        private int m_fontsize;
        // 按钮图标相对引用页的位置
        private string m_imgpath = @"../Images/Toolbar";
        //// 
        //private int m_nbegin;
        private int[] m_nCon = new int[8];
        private int m_nControls = 0;
        private int n;
        private TextBox tbx = new TextBox();

        #region 控件呈现的方法
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        // Events
        public event EventHandler Click;

        protected void OnChange(EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }

        // Methods
        private void btn_click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            this.CurPageNumber = int.Parse(button.CommandArgument);
            this.CreateChildControls();
            this.OnChange(EventArgs.Empty);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.m_curpagenumber = this.CurPageNumber;
            if ((this.m_crosspagenum < 1) || (this.m_crosspagenum > 100))
            {
                this.m_crosspagenum = 10;
            }
            if (this.TotalAmout == 0)
            {
                string text = "<a style='FONT-SIZE:" + this.m_fontsize + "pt'>暂无记录!</a>";
                if (this.isfontsize)
                {
                    text = "<a style='FONT-SIZE:" + this.m_fontsize + "pt'>暂无记录!</a>";
                }
                else
                {
                    text = "暂无记录!";
                }
                this.Controls.Add(new LiteralControl(text));
            }
            else
            {
                this.m_allpagenum = this.TotalAmout / this.PageSize;
                if ((this.TotalAmout % this.PageSize) != 0)
                {
                    this.m_allpagenum++;
                }
                this.PageAmout = m_allpagenum;
                if (this.m_allpagenum == 1)
                {
                    this.Controls.Add(new LiteralControl("【 共" + this.TotalAmout + "条数据 】"));
                    this.m_curpagenumber = 1;
                }
                else
                {
                    if (this.m_allpagenum >= this.m_crosspagenum)
                    {
                        this.n = this.m_crosspagenum;
                    }
                    else
                    {
                        this.n = this.m_allpagenum;
                    }
                    //this.m_nbegin = this.m_nControls;
                    if (this.m_curpagenumber < 1)
                    {
                        this.Num = 1;
                        this.m_curpagenumber = this.Num + (this.n / 2);
                    }
                    if ((this.m_curpagenumber > 0) && (this.m_curpagenumber <= 5))
                    {
                        this.Num = 1;
                    }
                    else if ((this.m_allpagenum - this.m_curpagenumber) >= 5)
                    {
                        this.Num = this.m_curpagenumber - (this.n / 2);
                    }
                    if (this.m_curpagenumber == this.m_allpagenum)
                    {
                        this.Num = (this.m_allpagenum - this.n) + 1;
                    }
                    else if (this.m_curpagenumber > this.m_allpagenum)
                    {
                        this.Num = (this.m_allpagenum - this.n) + 1;
                        this.m_curpagenumber = this.Num + (this.n / 2);
                    }
                    else if ((this.m_allpagenum - this.m_curpagenumber) < 5)
                    {
                        this.Num = (this.m_allpagenum - this.n) + 1;
                    }
                    int curpagenumber = this.m_curpagenumber;
                    int num = this.Num;
                    if ((this.Num == 1) || (this.m_allpagenum < this.m_crosspagenum))
                    {
                        this.ispre = false;
                        this.isnext = false;
                    }
                    if ((this.m_allpagenum > this.m_crosspagenum) && (this.Num == 1))
                    {
                        this.isnext = true;
                    }
                    else if (((this.m_allpagenum - this.m_crosspagenum) <= this.Num) && (this.m_allpagenum > this.m_crosspagenum))
                    {
                        this.isnext = false;
                        this.ispre = true;
                    }
                    else if (this.Num != 1)
                    {
                        this.ispre = true;
                        this.isnext = true;
                    }
                    string[] strArray = new string[10];
                    this.Controls.Add(new LiteralControl("<table  align='" + this.Align + "'>                                          \n   <tr>                                           \n      <td  nowrap  style='padding-right:15px;padding-bottom:0px;' >"));
                    if (this.isfontsize)
                    {
                        this.Controls.Add(new LiteralControl(string.Concat(new object[] { "<font style='FONT-SIZE:", this.m_fontsize, "pt'>【 共", this.TotalAmout, "条数据 当前第", this.m_curpagenumber, "/", this.m_allpagenum, "页 】</font> " })));
                    }
                    else
                    {
                        this.Controls.Add(new LiteralControl(string.Concat(new object[] { "【共", this.TotalAmout, "条数据 第", this.m_curpagenumber, "/", this.m_allpagenum, "页】" })));
                    }
                    this.m_nControls++;
                    if (this.isfirstpage && this.ispre)
                    {
                        LinkButton child = new LinkButton();
                        child.CausesValidation = false;
                        child.CommandArgument = "1";
                        child.Text = "<img src='" + this.m_imgpath + "/010.gif' border=0>";
                        child.ID = "firstpagebtn";
                        child.ToolTip = "首页";
                        if (this.m_curpagenumber == 1)
                        {
                            child.Enabled = false;
                            child.Visible = false;
                        }
                        child.Click += new EventHandler(this.btn_click);
                        if (child.Visible)
                        {
                            this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap style='padding-right:10px;padding-bottom:0px;'>       "));
                            this.Controls.Add(child);
                            this.m_nControls += 2;
                            this.m_nCon[0] = this.m_nControls;
                        }
                    }
                    if (this.isprepage && this.ispre)
                    {
                        LinkButton button2 = new LinkButton();
                        button2.CausesValidation = false;
                        button2.Text = "<img src='" + this.m_imgpath + "/030.gif' border=0>";
                        button2.CommandArgument = (this.m_curpagenumber - 1).ToString();
                        button2.ID = "prepagebtn";
                        button2.ToolTip = "上一页";
                        if (this.m_curpagenumber == 1)
                        {
                            button2.Enabled = false;
                            button2.Visible = false;
                        }
                        button2.Click += new EventHandler(this.btn_click);
                        if (button2.Visible)
                        {
                            this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap style='padding-right:10px;padding-bottom:0px;' >       "));
                            this.Controls.Add(button2);
                            this.m_nControls += 2;
                            this.m_nCon[1] = this.m_nControls;
                        }
                    }
                    if (((this.m_allpagenum > this.m_crosspagenum) && this.isprecrosspage) && this.ispre)
                    {
                        LinkButton button3 = new LinkButton();
                        button3.CausesValidation = false;
                        button3.Text = "<img src='" + this.m_imgpath + "/060.gif' border=0 style='padding-bottom:0px;'>";
                        button3.ID = "pretenpagebtn";
                        button3.ToolTip = "上" + this.m_crosspagenum + "页";
                        button3.CommandArgument = (this.m_curpagenumber - this.m_crosspagenum).ToString();
                        if (this.Num == 1)
                        {
                            button3.Enabled = false;
                            button3.Visible = false;
                        }
                        button3.Click += new EventHandler(this.btn_click);
                        if (button3.Visible)
                        {
                            this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap style='padding-right:10px;padding-bottom:0px;' valign='bottom'>       "));
                            this.Controls.Add(button3);
                            this.m_nControls += 2;
                            this.m_nCon[3] = this.m_nControls + (this.n * 2);
                        }
                    }
                    for (int i = 0; i < this.n; i++)
                    {
                        this.Controls.Add(new LiteralControl("  </td>                                     \n   <td  nowrap style='padding-right:5px;padding-bottom:0px;' >       "));
                        LinkButton button4 = new LinkButton();
                        button4.CausesValidation = false;
                        button4.Text = (this.Num + i).ToString();
                        button4.CommandArgument = (this.Num + i).ToString();
                        if (button4.Text == this.m_curpagenumber.ToString())
                        {
                            button4.Enabled = false;
                        }
                        button4.Click += new EventHandler(this.btn_click);
                        this.Controls.Add(button4);
                    }
                    if (this.ifnextpage && this.isnext)
                    {
                        LinkButton button5 = new LinkButton();
                        button5.CausesValidation = false;
                        button5.Text = "<img src='" + this.m_imgpath + "/040.gif' border=0>";
                        button5.CommandArgument = (this.m_curpagenumber + 1).ToString();
                        button5.ID = "nextpagebtn";
                        button5.ToolTip = "下一页";
                        if (this.m_curpagenumber == this.m_allpagenum)
                        {
                            button5.Enabled = false;
                            button5.Visible = false;
                        }
                        button5.Click += new EventHandler(this.btn_click);
                        if (button5.Visible)
                        {
                            this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap style='padding-left:10px;padding-bottom:0px;'>       "));
                            this.Controls.Add(button5);
                            this.m_nControls += 2;
                            this.m_nCon[2] = this.m_nControls;
                        }
                    }
                    if (((this.m_allpagenum > this.m_crosspagenum) && this.isnextcrosspage) && this.isnext)
                    {
                        LinkButton button6 = new LinkButton();
                        button6.CausesValidation = false;
                        button6.Text = "<img src='" + this.m_imgpath + "/050.gif' border=0>";
                        button6.ToolTip = "下" + this.m_crosspagenum + "页";
                        int allpagenum = this.m_curpagenumber + this.m_crosspagenum;
                        if (allpagenum > this.m_allpagenum)
                        {
                            allpagenum = this.m_allpagenum;
                        }
                        button6.CommandArgument = allpagenum.ToString();
                        button6.ID = "nexttenpagebtn";
                        button6.Click += new EventHandler(this.btn_click);
                        if ((this.m_allpagenum - this.Num) < this.m_crosspagenum)
                        {
                            button6.Enabled = false;
                            button6.Visible = false;
                        }
                        if (button6.Visible)
                        {
                            this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap style='padding-left:10px;padding-bottom:0px;'>       "));
                            this.Controls.Add(button6);
                            this.m_nControls += 2;
                            this.m_nCon[4] = this.m_nControls + (this.n * 2);
                        }
                    }
                    if (this.islastpage && this.isnext)
                    {
                        LinkButton button7 = new LinkButton();
                        button7.CausesValidation = false;
                        button7.Text = "<img src='" + this.m_imgpath + "/020.gif' border=0>";
                        button7.CommandArgument = this.m_allpagenum.ToString();
                        button7.ID = "lastpagebtn";
                        button7.ToolTip = "尾页";
                        if (this.m_curpagenumber == this.m_allpagenum)
                        {
                            button7.Enabled = false;
                            button7.Visible = false;
                        }
                        button7.Click += new EventHandler(this.btn_click);
                        if (button7.Visible)
                        {
                            this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap style='padding-left:10px;padding-bottom:0px;'>       "));
                            this.Controls.Add(button7);
                            this.m_nControls += 2;
                            this.m_nCon[5] = this.m_nControls + (this.n * 2);
                        }
                    }
                    if (this.isgopage && (this.m_allpagenum > this.m_crosspagenum))
                    {
                        this.Controls.Add(new LiteralControl("</td>                                     \n   <td  nowrap  style='padding-left:15px;padding-bottom:0px;'>       "));
                        if (this.isfontsize)
                        {
                            this.Controls.Add(new LiteralControl("<a  style='FONT-SIZE:" + this.m_fontsize + "pt'>  转至</a>"));
                        }
                        else
                        {
                            this.Controls.Add(new LiteralControl("  转至"));
                        }
                        int[] numArray = new int[this.m_allpagenum];
                        for (int j = 0; j < this.m_allpagenum; j++)
                        {
                            numArray[j] = j + 1;
                        }
                        if (this.jumptype == JumpChoose.DropDownList)
                        {
                            DropDownList list = new DropDownList();
                            list.DataSource = numArray;
                            list.AutoPostBack = true;
                            list.SelectedIndex = this.m_curpagenumber - 1;
                            list.ID = "dplist";
                            list.SelectedIndexChanged += new EventHandler(this.dlt_SelectedIndexChanged);
                            list.DataBind();
                            this.Controls.Add(list);
                        }
                        if (this.jumptype == JumpChoose.TextBox)
                        {
                            this.tbx.Width = 0x17;
                            this.Controls.Add(this.tbx);

                            Button btnJump = new Button();
                            btnJump.CausesValidation = false;
                            btnJump.ID = "btnJump";
                            btnJump.Text = "跳转";
                            btnJump.Width = 0x27;
                            btnJump.CssClass = "Btn_bse37";
                            btnJump.Click += new EventHandler(this.btnJump_Click);
                            this.Controls.Add(btnJump);
                        }
                        this.m_nControls += 3;
                        this.m_nCon[6] = this.m_nControls + (this.n * 2);
                    }
                    this.Controls.Add(new LiteralControl("\t</td> </tr> </table>"));
                }
            }
        }

        public override void DataBind()
        {
            this.CreateChildControls();
        }

        private void dlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurPageNumber = int.Parse(((DropDownList)this.Controls[this.m_nCon[6]]).SelectedValue);
            this.CreateChildControls();
            this.OnChange(EventArgs.Empty);
        }

        protected override void Render(HtmlTextWriter output)
        {
            //if ((base.Site != null) && base.Site.DesignMode)
            //{
            //    this.CreateChildControls();
            //}
            this.CreateChildControls();
            base.Render(output);
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            int allpagenum = 0;
            try
            {
                allpagenum = int.Parse(this.tbx.Text.Trim());
            }
            catch
            {
                this.tbx.Text = "";
            }
            if (allpagenum < 1)
            {
                allpagenum = 1;
                this.tbx.Text = "1";
            }
            if (allpagenum > this.m_allpagenum)
            {
                allpagenum = this.m_allpagenum;
                this.tbx.Text = this.m_allpagenum.ToString();
            }
            this.CurPageNumber = allpagenum;
            this.CreateChildControls();
            this.OnChange(EventArgs.Empty);
        }
        #endregion

        #region 属性
        // Properties
        [Description("对齐方式:Center,Left,Right")]
        public AlignType Align
        {
            get
            {
                return this.align;
            }
            set
            {
                this.align = value;
            }
        }

        [Description("上,下CrossPageNum页")]
        public int CrossPageNum
        {
            get
            {
                return this.m_crosspagenum;
            }
            set
            {
                this.m_crosspagenum = value;
            }
        }

        /// <summary>
        /// 获取和设置页索引
        /// </summary>
        [Description("当前页")]
        public int CurPageNumber
        {
            get
            {
                if (this.ViewState["Number"] != null)
                {
                    return (int)this.ViewState["Number"];
                }
                return 1;
            }
            set
            {
                this.ViewState["Number"] = value;
            }
        }
        /// <summary>
        /// 获取当前页索引(从0开始计算，程序使用)
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return this.CurPageNumber - 1;
            }
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        public int PageAmout
        {
            get
            {
                if (this.ViewState["PageAmout"] != null)
                {
                    return (int)this.ViewState["PageAmout"];
                }
                return 0;
            }
            set
            {
                this.ViewState["PageAmout"] = value;
            }
        }


        [Description("每页大小")]
        public int PageSize
        {
            get
            {
                if (this.ViewState["EveryPageNum"] != null)
                {
                    return (int)this.ViewState["EveryPageNum"];
                }
                return 10;
            }
            set
            {
                this.ViewState["EveryPageNum"] = value;
            }
        }

        [Description("字体大小")]
        public int FontSize
        {
            get
            {
                if (this.m_fontsize == 0)
                {
                    this.isfontsize = false;
                }
                else
                {
                    this.isfontsize = true;
                }
                return this.m_fontsize;
            }
            set
            {
                this.m_fontsize = value;
            }
        }

        [Description("图片路径")]
        public string ImgPath
        {
            get
            {
                return this.m_imgpath;
            }
            set
            {
                this.m_imgpath = value;
            }
        }

        [Description("是否创建首页按钮")]
        public bool IsFirstPage
        {
            get
            {
                return this.isfirstpage;
            }
            set
            {
                this.isfirstpage = value;
            }
        }

        [Description("是否创建跳转按钮")]
        public bool IsGoPage
        {
            get
            {
                return this.isgopage;
            }
            set
            {
                this.isgopage = value;
            }
        }

        [Description("是否创建尾页按钮")]
        public bool IsLastPage
        {
            get
            {
                return this.islastpage;
            }
            set
            {
                this.islastpage = value;
            }
        }

        [Description("是否创建下N页按钮")]
        public bool IsNextCrossPage
        {
            get
            {
                return this.isnextcrosspage;
            }
            set
            {
                this.isnextcrosspage = value;
            }
        }

        [Description("是否创建下一页按钮")]
        public bool IsNextPage
        {
            get
            {
                return this.ifnextpage;
            }
            set
            {
                this.ifnextpage = value;
            }
        }

        [Description("是否创建上N 页按钮")]
        public bool IsPreCrossPage
        {
            get
            {
                return this.isprecrosspage;
            }
            set
            {
                this.isprecrosspage = value;
            }
        }

        [Description("是否创建上一页按钮")]
        public bool IsPrePage
        {
            get
            {
                return this.isprepage;
            }
            set
            {
                this.isprepage = value;
            }
        }

        [Description("选择跳转的类型")]
        public JumpChoose JumpType
        {
            get
            {
                return this.jumptype;
            }
            set
            {
                this.jumptype = value;
            }
        }

        private int Num
        {
            get
            {
                if (this.ViewState["Num"] != null)
                {
                    return (int)this.ViewState["Num"];
                }
                return 1;
            }
            set
            {
                this.ViewState["Num"] = value;
            }
        }

        [Description("总记录数")]
        public int TotalAmout
        {
            get
            {
                if (this.ViewState["TotalAmout"] != null)
                {
                    return (int)this.ViewState["TotalAmout"];
                }
                return 0;
            }
            set
            {
                if (this.TotalAmout == value)
                {
                    return;
                }
                else
                {
                    this.ViewState["TotalAmout"] = value;
                    this.CurPageNumber = 1;
                    //this.CreateChildControls();
                }
            }
        }
        #endregion


        // Nested Types
        public enum AlignType
        {
            Center,
            Left,
            Right
        }

        public enum JumpChoose
        {
            DropDownList,
            TextBox
        }
    }


}

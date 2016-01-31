/********************************************************************************************
 * 文件名称:	.cs
 * 设计人员:	严向晖(yanxianghui@gmail.com)
 * 设计时间:	2009-04-10
 * 功能描述:	
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
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shanfree.Framework.Utility;
using Shanfree.Portal.BLL;

public partial class Admin_Log : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRadionList();
            BindLogList(0);
        }
    }

    #region 列表控件事件
    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void pGrid_OnClick(object sender, EventArgs e)
    {
        try
        {
            BindLogList(pGrid.CurrentPageIndex);
        }
        catch (Exception exc)
        {
            ShowMsg(exc.Message);
            LogEntry.Log.Write(exc.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }
    #endregion

    /// <summary>
    /// 绑定日志类型和来源
    /// </summary>
    private void BindRadionList()
    {
        string[] names = EnumHandler<EventLogEntryType>.GetListFromEnumType();
        rblType.DataSource = names;
        rblType.DataBind();
    }
    /// <summary>
    /// 绑定日志列表
    /// </summary>
    /// <param name="pageIndex"></param>
    private void BindLogList(int pageIndex)
    {
        string sourceID = rblSource.SelectedValue;
        string typeName = (rblType.SelectedItem == null) ? "" : rblType.SelectedItem.Text;
        int size = pGrid.PageSize;
        IList<LogInfo> list = new List<LogInfo>();
        if (typeName != "" && null != typeName)
        {
            EventLogEntryType type = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), typeName);
            list = new SystemLog().GetLogInfoList(DateTime.MinValue, DateTime.MaxValue, type, sourceID, size, pageIndex);
        }
        else
        {
            list = new SystemLog().GetLogInfoList(DateTime.MinValue, DateTime.MaxValue, sourceID, size, pageIndex);
        }
        gvLogInfoList.DataSource = list;
        gvLogInfoList.DataBind();
        CustomList<LogInfo> cList = list as CustomList<LogInfo>;
        if (null != cList)
        {
            pGrid.PageSize = size;
            pGrid.TotalAmout = cList.TotalAmout;
        }
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLogList(0);
    }
    protected void rblSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindLogList(0);
    }
    protected void gvLogInfoList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LogInfo lInfo = e.Row.DataItem as LogInfo;

            // 选择控件，传入收件的事务主键，用来更新
            RadioButton rbSel = (RadioButton)e.Row.FindControl("rbSel");
            rbSel.Attributes.Add("onclick", "Sel('" + lInfo.ID + "')");
        }

    }
    protected void rbSel_CheckedChanged(object sender, EventArgs e)
    {
        string id = lbID.Value;
        LogInfo lInfo = new SystemLog().GetLogInfoByID(id);
        // 使用全角替换
        tbDetail.Text = lInfo.Message.Replace("<", "＜").Replace(">", "＞");
    }

    #region 生成excel事件
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    protected void ExcelGenButton1_Click(object sender, EventArgs e)
    {
        try
        {
            IList<LogInfo> list = new List<LogInfo>();
            list = new SystemLog().GetLogInfoList(5000, 0, true);
            gvLogInfoList.DataSource = list;
            gvLogInfoList.DataBind();
            gvLogInfoList.Columns[0].Visible = false;
        }
        catch (ArgumentNullException ane)
        {
            this.ShowMsg(ane.Message);
        }
        catch (Exception ex)
        {
            ShowMsg(ex.Message);
            LogEntry.Log.Write(ex.ToString(), EventLogEntryType.Error, LogSourceType.其他);
        }
    }
    #endregion

}

<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="JianyanInputPage.aspx.cs" Inherits="SharpReportWeb.ChuanJ.JianyanInputPage"
    Title="检验报表登记" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>检验报表</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td align="right" class="tint">
                        按月统计汇总：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblReportType" runat="server" DataTextField="Name" DataValueField="ID"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="预估录入" Value="1"></asp:ListItem>
                            <asp:ListItem Text="修正录入" Value="2"></asp:ListItem>
                            <asp:ListItem Text="财务确认" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right" class="tint">
                        用途：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblUsage" runat="server" DataTextField="Name" DataValueField="ID"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="日常用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="厂修用" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        登记人:
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tbUserName" ReadOnly runat="server"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        录入时间:
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tbCreateTime" ReadOnly runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        年份：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlReportYear" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                            <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                            <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                            <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                            <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right" class="tint">
                        月份：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlReportMonth" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        总额（元）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb总数" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        船舶：                     </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlShip" runat="server" DataTextField="Name" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        币种：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" class="tint">
                        汇率：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlYear" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                            <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                            <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                            <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                            <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                        </asp:DropDownList>
                        年
                        <asp:DropDownList ID="ddlMonth" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        月 汇率：人民币：外币 = 1：<asp:Label ID="lbRate" runat="server" Text="1"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn" OnClick="btnAdd_Click" />
                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click"
                            OnClientClick="return window.confirm('您真的要保存吗？')" />
                        &nbsp;<asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" OnClick="btnDel_Click"
                            OnClientClick="return window.confirm('您真的要删除吗？')" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回列表页面" CssClass="btn" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <uc1:InvoiceList ID="InvoiceList1" ReportType="3" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

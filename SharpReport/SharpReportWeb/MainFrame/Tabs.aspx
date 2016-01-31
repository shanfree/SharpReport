<%@ Page Title="首页" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="Tabs.aspx.cs" Inherits="SharpReportWeb.MainFrame.Tabs" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged"
        IsShowShipAll="true" />
    <div class="window">
        <div class="title BGx">
            <span>燃润料报表列表</span></div>
        <div class="SlideBox">
            <asp:GridView ID="gvReportList" runat="server" AutoGenerateColumns="False" Width="100%"
                ShowHeader="true" CssClass="t" PageSize="15" OnRowCommand="gvReportList_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="船名" DataField="ShipName"></asp:BoundField>
                    <asp:BoundField HeaderText="航次名称" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="年内排序" DataField="OrderNum" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="航线名称" DataField="RouteName" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="出发港" DataField="sName" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="目的港" DataField="eName" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="启航时间" DataField="BeginDate" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="到港时间" DataField="EndDate" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CssClass="btn" runat="server" Text="查看" CommandName="btnView"
                                CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDelete" CssClass="btn" runat="server" Text="删除" CommandName="btnDelete"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Left" />
            </asp:GridView>
        </div>
        <div class="toolbar" style="text-align:left;">
            <cc1:DefaultPager ID="pGridV" runat="server" OnClick="pGridV_OnClick"
                PageSize="15" Style="text-align: right" />
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>船技部报表列表</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="6" class="mass BGx">
                        物料报表
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        预估输入：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbWuliao1" runat="server" CssClass="inputText" Text="1" />
                    </td>
                    <td class="tint">
                        修正录入：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbWuliao2" runat="server" CssClass="inputText" Text="3" />
                    </td>
                    <td class="tint">
                        财务确认：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="lbWuliao3" runat="server" CssClass="inputText" Text="3" />
                    </td>
                </tr>
                <tr>
                    <th colspan="6" class="mass BGx">
                        修理报表
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        预估输入：
                    </td>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" CssClass="inputText" Text="1" />
                    </td>
                    <td class="tint">
                        修正录入：
                    </td>
                    <td align="left">
                        <asp:Label ID="Label2" runat="server" CssClass="inputText" Text="3" />
                    </td>
                    <td class="tint">
                        财务确认：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="Label3" runat="server" CssClass="inputText" Text="3" />
                    </td>
                </tr>
                <tr>
                    <th colspan="6" class="mass BGx">
                        备件报表
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        预估输入：
                    </td>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" CssClass="inputText" Text="1" />
                    </td>
                    <td class="tint">
                        修正录入：
                    </td>
                    <td align="left">
                        <asp:Label ID="Label5" runat="server" CssClass="inputText" Text="3" />
                    </td>
                    <td class="tint">
                        财务确认：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="Label6" runat="server" CssClass="inputText" Text="3" />
                    </td>
                </tr>
                <tr>
                    <th colspan="6" class="mass BGx">
                        检验报表
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        预估输入：
                    </td>
                    <td align="left">
                        <asp:Label ID="Label7" runat="server" CssClass="inputText" Text="1" />
                    </td>
                    <td class="tint">
                        修正录入：
                    </td>
                    <td align="left">
                        <asp:Label ID="Label8" runat="server" CssClass="inputText" Text="3" />
                    </td>
                    <td class="tint">
                        财务确认：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="Label9" runat="server" CssClass="inputText" Text="3" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

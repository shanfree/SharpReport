<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="RanrunList.aspx.cs" Inherits="SharpReportWeb.ChuanJ.RanrunList" Title="无标题页" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div id="SlideBox">
        <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
        <div class="window">
            <div class="title BGx">
                <span>燃润料报表列表<asp:Button ID="btnAdd" runat="server" Text="添加燃润料报表" OnClick="btnAdd_Click"
                    class="btn" />
                </span>
            </div>
            <div class="SlideBox">
                    <!--滚动必须-->
                    <asp:GridView ID="gvReportList" runat="server" AutoGenerateColumns="False" Width="100%"
                        CssClass="t" PageSize="15" OnRowCommand="gvReportList_RowCommand">
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
                                    <asp:Label ID="lbVoyageID" runat="server" Text='<%#Eval("VoyageID")%>' Visible="false"></asp:Label>
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
            <div class="toolbar">
                <!--翻页-->
                <cc1:DefaultPager ID="pGridV" runat="server" Align="Right" OnClick="pGridV_OnClick"
                    PageSize="15" />
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

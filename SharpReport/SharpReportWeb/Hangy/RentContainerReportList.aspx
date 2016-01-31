<%@ Page Title="货柜出租租金计费表" Language="C#" MasterPageFile="~/MasterPage/Default.Master"
    AutoEventWireup="true" CodeBehind="RentContainerReportList.aspx.cs" Inherits="SharpReportWeb.Hangy.RentContainerReportList" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
    <div class="window">
        <div class="title BGx">
            <span>货柜出租租金计费表 </span>
        </div>
        <div class="SlideBox">
            <!--滚动必须-->
            <asp:GridView ID="gvRentReport" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="t" PageSize="15" OnRowCommand="gvRentReport_RowCommand" OnRowDataBound="gvRentReport_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSel" runat="server" AutoPostBack="false" />
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="承租方" DataField="Customer" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="纳税识别号" DataField="TaxNo" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="租金计算开始时间" DataField="BeginDate" ItemStyle-Width="10%"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField HeaderText="结束时间" DataField="EndDate" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="计费天" DataField="RentDays" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="租金" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbTotal" runat="server" Text="--"></asp:Label><%# DataBinder.Eval(Container.DataItem, "CurrencyName")%>相当于
                            <asp:Label ID="lbTotalRMB" runat="server" Text="--"></asp:Label>元人民币
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="填写时间" DataField="CreateTime" ItemStyle-Width="10%" NullDisplayText="--"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="编辑租金收入报表" CommandName="btnEdit"
                                Visible="true" CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Left" />
            </asp:GridView>
            <!--翻页-->
            <cc1:DefaultPager ID="pGridV" runat="server" Align="Right" Font-Size="Small" OnClick="pGridV_OnClick"
                PageSize="15" />
        </div>
        <!--滚动必须-->
    </div>
    <div class="toolbar" style="text-align: center">
        <asp:Button ID="btnAdd" runat="server" Text="新增货柜出租租金计费表" CssClass="btn" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="LCLManageList.aspx.cs" Inherits="SharpReportWeb.Hangy.LCLManageList"
    Title="散货船舶运费计费报表汇总" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
    <div class="window">
        <div class="title BGx">
            <span>散货船舶运费计费报表</span></div>
        <div class="SlideBox">
            <div>
                <!--滚动必须-->
                <asp:GridView ID="gvLCL" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="t" PageSize="15" OnRowCommand="gvLCL_RowCommand" OnRowDataBound="gvLCL_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSel" runat="server" AutoPostBack="false" />
                                <asp:Label ID="lbVoyageID" Text='<%#Eval("VoyageID") %>' runat="server" Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="船舶" DataField="ShipName" ItemStyle-Width="10%"></asp:BoundField>
                        <asp:BoundField HeaderText="航次" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                        <asp:BoundField HeaderText="经营方式" DataField="ManagerTypeName"></asp:BoundField>
                        <asp:BoundField HeaderText="客户" DataField="Customer" ItemStyle-Width="10%" NullDisplayText="--">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="货运量" DataField="LCLAmount" ItemStyle-Width="10%" NullDisplayText="--">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计费货运量" DataField="LCLAmountReal" ItemStyle-Width="10%"
                            NullDisplayText="--"></asp:BoundField>
                        <asp:BoundField HeaderText="运费" DataField="Amount" ItemStyle-Width="10%" NullDisplayText="--">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="运费（人民币）">
                            <ItemTemplate>
                                <asp:Label ID="lbTotal" runat="server" Text="--"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="填写时间" DataField="CreateTime" ItemStyle-Width="10%" NullDisplayText="--">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="操作" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Button ID="btnEditVoyage" CssClass="btn" runat="server" Text="填写货运报表" CommandName="btnEdit"
                                    Visible="true" CommandArgument='<%#Eval("ID")%>' />
                                <asp:Button ID="btnDelVoyage" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
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
        <div class="toolbar" style="text-align: center"><asp:Button ID="btnReturn" runat="server" Text="返回月份收入统计汇总报表" CssClass="btn" OnClick="btnReturn_Click" />
                        
    
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

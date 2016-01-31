<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="JianyanList.aspx.cs" Inherits="SharpReportWeb.ChuanJ.JianyanList"
    Title="检验报表" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged"
        IsShowShipAll="true" />
    <div class="window">
        <div class="title BGx">
            <span>检验报表查询</span><asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn"
                OnClick="btnAdd_Click" /></div>
        <div id="SlideBox">
            <div>
                <asp:GridView ID="gvJianyanList" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="t" PageSize="12" OnRowDataBound="gvJianyanList_RowDataBound" OnRowCommand="gvJianyanList_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="年份" DataField="Year" ItemStyle-Width="10%"></asp:BoundField>
                        <asp:BoundField HeaderText="月份" DataField="MonthNumOfYear" ItemStyle-Width="10%">
                        </asp:BoundField>
                        <asp:BoundField HeaderText="船舶" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                        <asp:TemplateField HeaderText="报表类型" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbReportType" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用途" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbUsage" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="总数" DataField="总数" ItemStyle-Width="10%"></asp:BoundField>
                        <asp:BoundField HeaderText="登记人" DataField="UserName"></asp:BoundField>
                        <asp:BoundField HeaderText="录入时间" DataField="CreateTime" ItemStyle-Width="10%"></asp:BoundField>
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
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:GridView>
                <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvJianyanList"
                    OnClick="ExcelGenButton1_Click" Text="生成Excel" CssClass="btn"></cc1:ExcelGenButton>
                <asp:Button ID="btnReturn" runat="server" Text="返回统计页面" CssClass="btn" OnClick="btnReturn_Click" />
                <cc1:DefaultPager ID="pGrid" runat="server" Align="Right" OnClick="pGrid_OnClick"
                    PageSize="12"></cc1:DefaultPager>
            </div>
        </div>
    </div>
    <asp:RadioButtonList ID="rblReportType" runat="server" DataTextField="Name" DataValueField="ID"
        Visible="false">
        <asp:ListItem Text="预估录入" Value="1"></asp:ListItem>
        <asp:ListItem Text="修正录入" Value="2"></asp:ListItem>
        <asp:ListItem Text="财务确认" Value="3"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:RadioButtonList ID="rblUsage" runat="server" DataTextField="Name" DataValueField="ID"
        Visible="false">
        <asp:ListItem Text="全部" Value="0"></asp:ListItem>
        <asp:ListItem Text="日常用" Value="1"></asp:ListItem>
        <asp:ListItem Text="厂修用" Value="2"></asp:ListItem>
        <asp:ListItem Text="航修用" Value="3"></asp:ListItem>
    </asp:RadioButtonList>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

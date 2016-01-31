<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="InvoiceSearch.aspx.cs" Inherits="SharpReportWeb.Caiwu.InvoiceSearch"
    Title="发票编号搜索" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>财务部门报表确认</span></div>
        <div class="SlideBox">
            <div>
                <!--滚动必须-->
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td align="right" class="tint">
                            发票编号搜索：
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rSearchType" runat="server" AutoPostBack="true" RepeatLayout="Flow"
                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rSearchType_SelectedIndexChanged">
                                <asp:ListItem Text="按发票编号" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="按发票开票日期" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                            &nbsp;<asp:TextBox CssClass="inputText" ID="tbInvoiceNo" runat="server" Text=""></asp:TextBox>
                            <div runat="server" id="divDate" visible="false">
                                从<cc1:Calendar ID="cBegin" runat="server" CssClass="inputText"></cc1:Calendar>到<cc1:Calendar
                                    ID="cEnd" runat="server" CssClass="inputText"></cc1:Calendar>
                            </div>
                            <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn" OnClick="btnSearch_Click"
                                Width="34px" />
                            <asp:Button ID="btnAll" runat="server" Text="全部" CssClass="btn" />
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4" class="mass BGx">
                            相关发票
                        </th>
                    </tr>
                    <tr>
                        <th colspan="4">
                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%"
                                CssClass="t" PageSize="12" OnRowDataBound="gvList_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnView" runat="server" Text="查看报表" CssClass="btn" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="发票编号" DataField="Number"></asp:BoundField>
                                    <asp:BoundField HeaderText="发票面额" DataField="Amout" ItemStyle-Width="5%">
                                        <ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="币种" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbCurrencyName" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="等额人民币" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRMB" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="汇率" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbExchangeRate" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="增值税税率（%）" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbRate" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="报表类型" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbReportCatalog" runat="server" Text="--"></asp:Label>
                                            <asp:Label ID="lbID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="开票日期" DataField="InputDate"></asp:BoundField>
                                </Columns>
                                <RowStyle HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                                        无符合条件的记录</font>
                                </EmptyDataTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4" align="right">
                            <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvList" OnClick="ExcelGenButton1_Click"
                                Text="生成Excel" FileName="发票信息" CssClass="btn"></cc1:ExcelGenButton>
                            <cc1:DefaultPager ID="pGrid" runat="server" Align="Right" PageSize="12" Visible="false"></cc1:DefaultPager>
                        </td>
                    </tr>
                </table>
            </div>
            <!--滚动必须-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

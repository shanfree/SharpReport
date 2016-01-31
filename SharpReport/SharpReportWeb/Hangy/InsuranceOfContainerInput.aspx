<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="InsuranceOfContainerInput.aspx.cs" Inherits="SharpReportWeb.Hangy.InsuranceOfContainerInput"
    Title="集装箱箱体保险情况输入" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>集装箱箱体保险情况输入</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
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
                    <td align="left" colspan="3">
                        <asp:TextBox CssClass="inputText" ID="tbYear" ReadOnly runat="server" Text="2013"></asp:TextBox>
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
                            <asp:ListItem Text="2013" Value="2013" Selected="True"></asp:ListItem>
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
                            <asp:ListItem Text="5" Value="5" Selected="True"></asp:ListItem>
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
                <tr>
                    <td align="right" class="tint">
                        保险日期自：
                    </td>
                    <td>
                        <cc1:Calendar ID="cBeginDate" runat="server"></cc1:Calendar>
                    </td>
                    <td align="right" class="tint">
                        到：
                    </td>
                    <td>
                        <cc1:Calendar ID="cEndDate" runat="server"></cc1:Calendar>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        柜号起始字母：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb柜号起始字母" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        保费：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb保费" runat="server" Text="0" ReadOnly></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        集装箱数量（20英尺）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb集装箱数量20" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        集装箱数量（40英尺）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb集装箱数量40" runat="server" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        单价（20英尺）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb单价20" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        单价（40英尺）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb单价40" runat="server" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        保额：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb保额" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        基本险保险费率%：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb基本险保险费率" runat="server" Text="0.22"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        集装箱箱体保险付款分期：
                    </td>
                    <td align="left" colspan="3">
                        <asp:GridView ID="gvList" border="0" align="left" CellPadding="0" CellSpacing="0"
                            runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%"
                            CssClass="t" OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound">
                            <EmptyDataTemplate>
                                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="币种">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlListCurrency" runat="server" DataTextField="Name" DataValueField="ID"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="支付金额">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="inputText" ID="tb支付金额" runat="server" Text='<%#Eval("Amount")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="支付日期">
                                    <ItemTemplate>
                                        <cc1:Calendar ID="c支付日期" runat="server" Text='<%#Eval("PayDate")%>'></cc1:Calendar>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="inputText" ID="tb备注" runat="server" Text='<%#Eval("Remark")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                            Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%# Eval("ID") %>' />
                                        <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                            Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%# Eval("ID") %>'
                                            OnClientClick="return window.confirm('您真的要删除吗？')" />
                                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandArgument='<%# Container.DataItemIndex %>'
                                            CommandName="btnAdd" Visible='<%# Eval("ID") == null?true:false%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="200px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        备注：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox CssClass="inputText" ID="tb备注" runat="server" Text="" Height="60px"
                            Width="370px"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click"
                            OnClientClick="return window.confirm('您真的要保存吗？')" />
                        &nbsp;<asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" OnClick="btnDel_Click"
                            OnClientClick="return window.confirm('您真的要删除吗？')" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回" CssClass="btn" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <uc1:InvoiceList ID="InvoiceList1" ReportType="8" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

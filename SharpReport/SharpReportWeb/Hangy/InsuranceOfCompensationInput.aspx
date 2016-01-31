﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="InsuranceOfCompensationInput.aspx.cs" Inherits="SharpReportWeb.Hangy.InsuranceOfCompensationInput"
    Title="船舶保赔险输入" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>船舶保赔险输入</span></div>
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
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tbYear" ReadOnly runat="server" Text="2013"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        月份：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tbMonth" ReadOnly runat="server" Text="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        船舶：
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlShip" runat="server" DataTextField="Name" AutoPostBack="true"
                            DataValueField="ID">
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
                    <th colspan="4" class="mass">
                        船舶险输入：
                    </th>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        船舶险保险日期自：
                    </td>
                    <td>
                        <cc1:Calendar ID="cBeginDate" runat="server"></cc1:Calendar>
                        <font color="red">必填</font>
                    </td>
                    <td align="right" class="tint">
                        到：
                    </td>
                    <td>
                        <cc1:Calendar ID="cEndDate" runat="server"></cc1:Calendar>
                        <font
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        主险保额（元）：&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb主险保额" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        船舶险保单号：               船舶险保单号：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb船舶险保单号" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
  主险费率（含战争险）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb主险费率" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        主险保费（元）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb主险保费" runat="server" Text="0" ReadOnly></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        战争保赔险费率：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb战争保赔险费率" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        战争保赔险保费（元）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb战争保赔险保费" runat="server" Text="0" ReadOnly></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        免赔额：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb免赔额" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        船舶险总保费（元）：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb船舶险总保费" runat="server" Text="0" ReadOnly></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        船舶险付款分期：              船舶险付款分期：
                    </td>
                    <td align="left" colspan="3">
                        <asp:GridView ID="gvShipList" border="0" align="left" CellPadding="0" CellSpacing="0"
                            runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%" CssClass="t"
                            OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound">
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
                                        <asp:HiddenField runat="server" ID="hidRelateId" Value='<%#Eval("ID")%>' />
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                            Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%# Container.DataItemIndex %>' />
                                        <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                            Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%# Container.DataItemIndex %>'
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
                    <th colspan="4" class="mass">
                        保赔险输入：
                    </th>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        保赔险保险日期自：
                    </td>
                    <td>
                        <cc1:Calendar ID="c保险期限自" runat="server"></cc1:Calendar>
                        <font color="red">必填</font>
                    </td>
                    <td align="right" class="tint">
                        到：
                    </td>
                    <td>
                        <cc1:Calendar ID="c保险期限到" runat="server"></cc1:Calendar>
                        <font color="red">必填</font>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        保赔险保单号：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb保赔险保单号" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        保赔险费率：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb保赔险费率" runat="server" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        保赔险保费：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox CssClass="inputText" ID="tb保赔险保费" runat="server" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
  保赔险付款分期：
                    </td>
                    <td align="left" colspan="3">
                        <asp:GridView ID="gvCompensationList" border="0" align="left" CellPadding="0" CellSpacing="0"
                            runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%" CssClass="t"
                            OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound">
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
                                        <asp:HiddenField runat="server" ID="hidRelateId" Value='<%#Eval("ID")%>' />
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                            Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%# Container.DataItemIndex %>' />
                                        <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                            Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%# Container.DataItemIndex %>'
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
    <uc1:InvoiceList ID="InvoiceList1" ReportType="7" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

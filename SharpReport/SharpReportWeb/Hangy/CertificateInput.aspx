<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="CertificateInput.aspx.cs" Inherits="SharpReportWeb.Hangy.CertificateInput"
    Title="福建东方海运公司及船舶许可证、营运证办理情况输入" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>福建东方海运公司及船舶许可证、营运证办理情况输入</span></div>
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
                        项目名称：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb项目名称" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        证书类型：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblType" runat="server" Style="border: 0px" RepeatDirection="Horizontal"
                            DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Text="公司证书" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="船舶证书" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        发证日期：
                    </td>
                    <td>
                        <cc1:Calendar ID="c发证日期" runat="server"></cc1:Calendar>
                    </td>
                    <td align="right" class="tint">
                        有效期至：
                    </td>
                    <td>
                        <cc1:Calendar ID="c有效期至" runat="server"></cc1:Calendar>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        年审有效日期：
                    </td>
                    <td colspan="3">
                        <cc1:Calendar ID="c年审有效日期" runat="server"></cc1:Calendar>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        快递费：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb快递费" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        图纸复印费：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb图纸复印费" runat="server" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        洗照片：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb洗照片" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td align="right" class="tint">
                        公正：
                    </td>
                    <td align="left">
                        <asp:TextBox CssClass="inputText" ID="tb公正" runat="server" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        其他：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox CssClass="inputText" ID="tb其他" runat="server" Text="0"></asp:TextBox>
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
    <uc1:InvoiceList ID="InvoiceList1" ReportType="9" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

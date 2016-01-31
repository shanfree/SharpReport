<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="OilFee.aspx.cs" Inherits="SharpReportWeb.Hangy.OilFee" Title="油料添加录入" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>油料添加录入</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass BGx">
                        基础信息
                    </th>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        船舶：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlShip" AutoPostBack="true" runat="server" DataTextField="Name"
                            DataValueField="ID" Visible="false">
                        </asp:DropDownList>
                        <asp:Label ID="lbShip" runat="server" Text="--"></asp:Label>
                        <asp:Button ID="btnShipView" runat="server" Text="查看船舶信息" CssClass="btn" OnClick="btnShipView_Click" />
                    </td>
                    <td align="right" class="tint">
                        航次:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlVoyage" AutoPostBack="true" runat="server" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlVoyage_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        航线：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbRoute" runat="server" Text="--"></asp:Label>
                    </td>
                    <td align="right" class="tint">
                        里程（海里）：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbMile" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        始发港：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbBegin" runat="server" Text="--"></asp:Label>
                    </td>
                    <td align="right" class="tint">
                        目的港：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbEnd" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        报表登记人：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbUser" runat="server" Text="--"></asp:Label>
                    </td>
                    <td align="right" class="tint">
                        财务审核人员：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbApprover" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        当前状态：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblReportType" runat="server" DataTextField="Name" DataValueField="ID"
                            RepeatDirection="Horizontal" RepeatLayout="Flow" EnableViewState="true">
                            <asp:ListItem Text="预估录入" Value="1"></asp:ListItem>
                            <asp:ListItem Text="修正录入" Value="2"></asp:ListItem>
                            <asp:ListItem Text="财务确认" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right" class="tint">
                        创建时间：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbCreateDate" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click"
                            OnClientClick="return window.confirm('您真的要保存吗？')" />
                        &nbsp;<asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" OnClick="btnDel_Click"
                            OnClientClick="return window.confirm('您真的要删除吗？')" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回列表页面" CssClass="btn" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>当前航次加油汇总</span></div>
        <div class="SlideBox">
            <div>
                <!--滚动必须-->
                <asp:GridView ID="rList" runat="server" OnRowCommand="rList_RowCommand" OnRowDataBound="rList_RowDataBound"
                    Width="100%" PageSize="12" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                                    <tr>
                                        <th colspan="4" class="mass BGx">
                                            油料添加记录
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tint">
                                            加油港：
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPort" runat="server" DataTextField="Name" DataValueField="ID">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="red">* 必选</font>
                                        </td>
                                        <td align="right" class="tint">
                                            加油时间：
                                        </td>
                                        <td align="left">
                                            <cc1:Calendar ID="cDate" runat="server" CssClass="inputText"></cc1:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tint">
                                            油种：
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlOilType" runat="server" DataTextField="Name" DataValueField="ID">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="red">* 必选</font>
                                        </td>
                                        <td align="right" class="tint">
                                            数量（吨）：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="tbAmout" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                                必填,且必须为数字</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tint">
                                            单价（元/吨）：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="tbPrice" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                                必填,且必须为数字</font>
                                        </td>
                                        <td align="right" class="tint">
                                            币种：
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCurrency" runat="server" DataTextField="Name" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="4">
                                            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" CommandArgument='<%# Eval("ID") %>'
                                                CommandName="btnSave" Visible="false" />
                                            <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" CommandArgument='<%# Eval("ID") %>'
                                                CommandName="btnDel" OnClientClick="return window.confirm('您确认要删除吗？')" Visible="false" />
                                            <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandName="btnAdd"
                                                Visible="false" CommandArgument='<%# Eval("ID") %>' />
                                        </td>
                                    </tr>
                                </table>
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
            </div>
            <!--滚动必须-->
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
    <uc1:InvoiceList ID="InvoiceList1" ReportType="12" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

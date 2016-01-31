<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="RentContainerReportInput.aspx.cs" Inherits="SharpReportWeb.Hangy.RentContainerReporInput"
    Title="货柜出租计费表" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>货柜出租计费表 </span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        承租方：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCustomer" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        纳税识别号：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbTaxNo" runat="server" CssClass="inputText" /><font color="red"> 必填</font>
                    </td>
                        <td class="tint">
                        租金计费币种：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
            </tr>
                <tr>
                    <td class="tint">
                        计费开始时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        计费结束时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        计费天：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbRentDay" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left">
                        <font color="red">*如箱种一致因租金不一致另起一行.</font>
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Font-Size="12px"
                            border="0" CellPadding="0" CellSpacing="0" CssClass="t" Width="100%" 
                            OnRowCommand="gvList_RowCommand" onrowdatabound="gvList_RowDataBound"
                            >
                            <EmptyDataTemplate>
                                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="箱种" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="rblContainerTypeID" runat="server" DataTextField="Name" DataValueField="ID"
                                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Text="20英尺" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="40英尺" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="20英尺冻柜" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="40英尺冻柜" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="数量" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbAmount" runat="server" CssClass="inputText" Text='<%#Eval("Amount")%>' /><font
                                            color="red"> 必填</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="天租金" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbPrice" runat="server" CssClass="inputText" Text='<%#Eval("Price")%>' /><font
                                            color="red"> 必填</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="计费期租金" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbRentFee" runat="server" CssClass="inputText" Text='<%#Eval("RentFee")%>' /><font
                                            color="red"> 必填</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注	">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" Text='<%#Eval("Remark")%>'
                                            Width="90%" /><font color="red"> 必填</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                            CommandArgument='<%#Eval("ID")%>' Visible='<%# Eval("ID") == null?false:true%>' />
                                        <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                            CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')"
                                            Visible='<%# Eval("ID") == null?false:true%>' />
                                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandName="btnAdd"
                                            Visible='<%# Eval("ID") == null?true:false%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        合计:<asp:Label ID="lbTotal" runat="server" CssClass="inputText" Text="0" /><asp:Label ID="lbCName"
                            runat="server" Text="" />相当于
                        <asp:Label ID="lbTotalRMB" runat="server" CssClass="inputText" Text="0" />
                        人民币
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        备注：
                    </td>
                    <td align="left" colspan="7">
                        <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" Text="" TextMode="MultiLine"
                            Height="121px" Width="713px" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        主管：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        审核：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        制表：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" 
                            OnClientClick="return window.confirm('您真的要保存吗？')" 
                            onclick="btnSave_Click" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回列表页面" CssClass="btn" 
                            onclick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

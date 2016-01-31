<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="RentContainerReportInput.aspx.cs" Inherits="SharpReportWeb.Hangy.RentContainerReporInput"
    Title="�������Ʒѱ�" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>�������Ʒѱ� </span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        ���ⷽ��
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCustomer" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                    <td class="tint">
                        ��˰ʶ��ţ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbTaxNo" runat="server" CssClass="inputText" /><font color="red"> ����</font>
                    </td>
                        <td class="tint">
                        ���Ʒѱ��֣�
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
            </tr>
                <tr>
                    <td class="tint">
                        �Ʒѿ�ʼʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        �Ʒѽ���ʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        �Ʒ��죺
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbRentDay" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left">
                        <font color="red">*������һ�������һ������һ��.</font>
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Font-Size="12px"
                            border="0" CellPadding="0" CellSpacing="0" CssClass="t" Width="100%" 
                            OnRowCommand="gvList_RowCommand" onrowdatabound="gvList_RowDataBound"
                            >
                            <EmptyDataTemplate>
                                <font style="color: red; font-weight: bold; font-size: larger;">�޷��������ļ�¼</font>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="����" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="rblContainerTypeID" runat="server" DataTextField="Name" DataValueField="ID"
                                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Text="20Ӣ��" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="40Ӣ��" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="20Ӣ�߶���" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="40Ӣ�߶���" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="����" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbAmount" runat="server" CssClass="inputText" Text='<%#Eval("Amount")%>' /><font
                                            color="red"> ����</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="�����" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbPrice" runat="server" CssClass="inputText" Text='<%#Eval("Price")%>' /><font
                                            color="red"> ����</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="�Ʒ������" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbRentFee" runat="server" CssClass="inputText" Text='<%#Eval("RentFee")%>' /><font
                                            color="red"> ����</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="��ע	">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" Text='<%#Eval("Remark")%>'
                                            Width="90%" /><font color="red"> ����</font>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="����" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="����" CommandName="btnEdit"
                                            CommandArgument='<%#Eval("ID")%>' Visible='<%# Eval("ID") == null?false:true%>' />
                                        <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="ɾ��" CommandName="btnDel"
                                            CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('�����Ҫɾ����')"
                                            Visible='<%# Eval("ID") == null?false:true%>' />
                                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="����" CommandName="btnAdd"
                                            Visible='<%# Eval("ID") == null?true:false%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        �ϼ�:<asp:Label ID="lbTotal" runat="server" CssClass="inputText" Text="0" /><asp:Label ID="lbCName"
                            runat="server" Text="" />�൱��
                        <asp:Label ID="lbTotalRMB" runat="server" CssClass="inputText" Text="0" />
                        �����
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ��ע��
                    </td>
                    <td align="left" colspan="7">
                        <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" Text="" TextMode="MultiLine"
                            Height="121px" Width="713px" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ���ܣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        ��ˣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        �Ʊ�
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnSave" runat="server" Text="����" CssClass="btn" 
                            OnClientClick="return window.confirm('�����Ҫ������')" 
                            onclick="btnSave_Click" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="�����б�ҳ��" CssClass="btn" 
                            onclick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--��ҳ-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

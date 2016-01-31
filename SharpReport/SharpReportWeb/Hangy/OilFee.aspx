<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="OilFee.aspx.cs" Inherits="SharpReportWeb.Hangy.OilFee" Title="�������¼��" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>�������¼��</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass BGx">
                        ������Ϣ
                    </th>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        ������
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlShip" AutoPostBack="true" runat="server" DataTextField="Name"
                            DataValueField="ID" Visible="false">
                        </asp:DropDownList>
                        <asp:Label ID="lbShip" runat="server" Text="--"></asp:Label>
                        <asp:Button ID="btnShipView" runat="server" Text="�鿴������Ϣ" CssClass="btn" OnClick="btnShipView_Click" />
                    </td>
                    <td align="right" class="tint">
                        ����:
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlVoyage" AutoPostBack="true" runat="server" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlVoyage_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        ���ߣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbRoute" runat="server" Text="--"></asp:Label>
                    </td>
                    <td align="right" class="tint">
                        ��̣������
                    </td>
                    <td align="left">
                        <asp:Label ID="lbMile" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        ʼ���ۣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbBegin" runat="server" Text="--"></asp:Label>
                    </td>
                    <td align="right" class="tint">
                        Ŀ�ĸۣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbEnd" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        ����Ǽ��ˣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbUser" runat="server" Text="--"></asp:Label>
                    </td>
                    <td align="right" class="tint">
                        ���������Ա��
                    </td>
                    <td align="left">
                        <asp:Label ID="lbApprover" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        ��ǰ״̬��
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblReportType" runat="server" DataTextField="Name" DataValueField="ID"
                            RepeatDirection="Horizontal" RepeatLayout="Flow" EnableViewState="true">
                            <asp:ListItem Text="Ԥ��¼��" Value="1"></asp:ListItem>
                            <asp:ListItem Text="����¼��" Value="2"></asp:ListItem>
                            <asp:ListItem Text="����ȷ��" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right" class="tint">
                        ����ʱ�䣺
                    </td>
                    <td align="left">
                        <asp:Label ID="lbCreateDate" runat="server" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnSave" runat="server" Text="����" CssClass="btn" OnClick="btnSave_Click"
                            OnClientClick="return window.confirm('�����Ҫ������')" />
                        &nbsp;<asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="btn" OnClick="btnDel_Click"
                            OnClientClick="return window.confirm('�����Ҫɾ����')" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="�����б�ҳ��" CssClass="btn" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--��ҳ-->
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>��ǰ���μ��ͻ���</span></div>
        <div class="SlideBox">
            <div>
                <!--��������-->
                <asp:GridView ID="rList" runat="server" OnRowCommand="rList_RowCommand" OnRowDataBound="rList_RowDataBound"
                    Width="100%" PageSize="12" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                                    <tr>
                                        <th colspan="4" class="mass BGx">
                                            ������Ӽ�¼
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tint">
                                            ���͸ۣ�
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlPort" runat="server" DataTextField="Name" DataValueField="ID">
                                                <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="red">* ��ѡ</font>
                                        </td>
                                        <td align="right" class="tint">
                                            ����ʱ�䣺
                                        </td>
                                        <td align="left">
                                            <cc1:Calendar ID="cDate" runat="server" CssClass="inputText"></cc1:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tint">
                                            ���֣�
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlOilType" runat="server" DataTextField="Name" DataValueField="ID">
                                                <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                                            </asp:DropDownList>
                                            <font color="red">* ��ѡ</font>
                                        </td>
                                        <td align="right" class="tint">
                                            �������֣���
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="tbAmout" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                                ����,�ұ���Ϊ����</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tint">
                                            ���ۣ�Ԫ/�֣���
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="tbPrice" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                                ����,�ұ���Ϊ����</font>
                                        </td>
                                        <td align="right" class="tint">
                                            ���֣�
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCurrency" runat="server" DataTextField="Name" DataValueField="ID">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="4">
                                            <asp:Button ID="btnSave" runat="server" Text="����" CssClass="btn" CommandArgument='<%# Eval("ID") %>'
                                                CommandName="btnSave" Visible="false" />
                                            <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="btn" CommandArgument='<%# Eval("ID") %>'
                                                CommandName="btnDel" OnClientClick="return window.confirm('��ȷ��Ҫɾ����')" Visible="false" />
                                            <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="����" CommandName="btnAdd"
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
                            �޷��������ļ�¼</font>
                    </EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <!--��������-->
        </div>
        <div class="toolbar">
            <!--��ҳ-->
        </div>
    </div>
    <uc1:InvoiceList ID="InvoiceList1" ReportType="12" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

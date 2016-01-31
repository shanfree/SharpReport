<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="RentShipReportInput.aspx.cs" Inherits="SharpReportWeb.Hangy.RentShipReportInput"
    Title="�����������Ʒѱ�	" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>�����������Ʒѱ� </span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        ������
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlShipName" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlShipName_SelectedIndexChanged">
                            <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">����</font>
                    </td>
                    <td class="tint">
                        ���ⷽʽ��
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="ddlRentType" runat="server" DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Value="">��ѡ��</asp:ListItem>
                            <asp:ListItem Value="1">��������</asp:ListItem>
                            <asp:ListItem Value="2">�⴬����</asp:ListItem>
                            <asp:ListItem Value="3">�����⴬</asp:ListItem>
                            <asp:ListItem Value="4">�����⴬</asp:ListItem>
                            <asp:ListItem Value="5">�����⴬</asp:ListItem>
                            <asp:ListItem Value="6">���������⴬</asp:ListItem>
                            <asp:ListItem Value="7">�������⴬</asp:ListItem>
                            <asp:ListItem Value="8">���˺�ͬ�⴬</asp:ListItem>
                            <asp:ListItem Value="9">�����⴬</asp:ListItem>
                            <asp:ListItem Value="10">�⴬�⴬</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        �ͻ����ƣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCustomer" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                    <td class="tint">
                        ��˰ʶ��ţ�
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="tbTaxNo" runat="server" CssClass="inputText" /><font color="red"> ����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        �����㿪ʼʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        ���������ʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        ����������
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label runat="server" ID="lbDays" Text="0��0Сʱ0��"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ����ʱ�䣺
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDiscountDays" runat="server" CssClass="inputText" />
                        ��
                    </td>
                    <td class="tint">
                        �������ʱ�䣺
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="tbRealDays" runat="server" CssClass="inputText" />
                        ��
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ���Ʒѱ��֣�
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        �����
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbPrice" runat="server" CssClass="inputText" Text="0" /><font color="red">
                            ����Ϊ����</font>
                    </td>
                    <td class="tint">
                        ����
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbRentFee" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ͨѶ�ѣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCommunicateFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����Ϊ����</font>
                    </td>
                    <td class="tint">
                        �������߲�����
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLockFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����Ϊ����</font>
                    </td>
                    <td class="tint">
                        ����������
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbOtherFee" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        ���ͨѶ�ѡ��������ߡ������ϼ�:<asp:Label ID="lbTotal" runat="server" Text="0" /><asp:Label ID="lbCName"
                            runat="server" Text="" />�൱��
                        <asp:Label ID="lbTotalRMB" runat="server" Text="0" />
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
                        <asp:Button ID="btnSaveVoyage" runat="server" Text="����" CssClass="btn" OnClientClick="return window.confirm('�����Ҫ������')"
                            OnClick="btnSaveVoyage_Click" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="�����б�ҳ��" CssClass="btn" OnClick="btnReturn_Click" />
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

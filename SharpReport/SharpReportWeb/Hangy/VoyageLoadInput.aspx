<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="VoyageLoadInput.aspx.cs" Inherits="SharpReportWeb.Hangy.VoyageLoadInput"
    Title="����װ������Ǽ�" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>����������Ϣ </span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        �������ƣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbVoyageName" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                    <td class="tint">
                        ������
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlShipName" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True">
                            <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">����</font>
                    </td>
                    <td class="tint">
                        ��Ӫ��ʽ��
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlManagerType" runat="server" DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        �������ƣ�
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlRouteName" runat="server" DataTextField="Name" DataValueField="ID"
                            OnSelectedIndexChanged="ddlRouteName_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">��ѡ��</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        ����˵����
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label runat="server" ID="lbRoute" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ��ʼʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server" Width="101px"></cc1:Calendar><asp:DropDownList
                            ID="ddlStartHour" runat="server">
                        </asp:DropDownList>
                        ʱ<asp:DropDownList ID="ddlStartMin" runat="server">
                        </asp:DropDownList>
                        ��
                    </td>
                    <td class="tint">
                        ����ʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar><asp:DropDownList ID="ddlEndHour" runat="server">
                        </asp:DropDownList>
                        ʱ<asp:DropDownList ID="ddlEndMin" runat="server">
                        </asp:DropDownList>
                        ��
                    </td>
                    <td class="tint">
                        ����������
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label runat="server" ID="lbDays" Text="0��0Сʱ0��"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="tint">
                        ��������ţ�
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="tbOrder" runat="server" CssClass="inputText" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--��ҳ-->
        </div>
    </div>
    <div class="window" id="divLCL" runat="server" visible="false">
        <div class="title BGx">
            <span>ɢ�������ػ�����Ǽ�</span></div>
        <div class="SlideBox">
            <!--��������-->
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        �ͻ�����/֧������
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCustomer" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                    <td class="tint">
                        ��˰ʶ��ţ�
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbTaxNo" runat="server" CssClass="inputText" />
                    </td>
                </tr>
                <tr>
                    <th colspan="6" class="mass BGx">
                        ɢ�����ػ�������Ϣ
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        ���֣�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLName" runat="server" CssClass="inputText" Text="" /><font color="red">
                            ����</font>
                    </td>
                    <td class="tint">
                        ���������֣���
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLAmount" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����,�ұ���Ϊ����</font>
                    </td>
                    <td class="tint">
                        �Ʒѻ��������֣���
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLAmountReal" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����,�ұ���Ϊ����,����С�ڻ�����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        �Ʒѱ��֣�
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        �˼ۣ�Ԫ/�֣���
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbTransport" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����</font>
                    </td>
                    <td class="tint">
                        �˷ѣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbAmount" runat="server" CssClass="inputText" Text="0" />�൱��
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ����ʱ�䣨�죩��
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDelay" runat="server" CssClass="inputText" Text="0" /><font color="red">
                            ����,�ұ���Ϊ����</font>
                    </td>
                    <td class="tint">
                        �����ʣ�Ԫ/�죩��
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDelayFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����,�ұ���Ϊ����</font>
                    </td>
                    <td class="tint">
                        ���ڷѣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbDelayAmount" runat="server" CssClass="inputText" Text="0" />�൱��
                        <asp:Label ID="lbDelayRMB" runat="server" CssClass="inputText" Text="0" /><font> �����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ��ǲʱ�䣨�죩��
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDispatch" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����,�ұ���Ϊ����</font>
                    </td>
                    <td class="tint">
                        ��ǲ�ʣ�Ԫ/�죩��
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDispatchFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����,�ұ���Ϊ����</font>
                    </td>
                    <td class="tint">
                        ��ǲ�ѣ�
                    </td>
                    <td align="left">
                        <asp:Label ID="lbDispatchAmount" runat="server" CssClass="inputText" Text="0" />�൱��
                        <asp:Label ID="lbDispatchRMB" runat="server" CssClass="inputText" Text="0" /><font>
                            �����</font>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        �˷ѡ����ڡ���ǲ�ϼ�:<asp:Label ID="lbTotal" runat="server" CssClass="inputText" Text="0" /><asp:Label
                            ID="lbLCLCName" runat="server" Text="" />�൱��
                        <asp:Label ID="lbTotalRMB" runat="server" CssClass="inputText" Text="0" />
                        �����
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ���߸��ۿڶ��壺
                    </td>
                    <td colspan="5" align="left">
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Font-Size="12px"
                            border="0" CellPadding="0" CellSpacing="0" CssClass="t" Width="100%">
                            <EmptyDataTemplate>
                                <font style="color: red; font-weight: bold; font-size: larger;">�޷��������ļ�¼</font>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="�ۿ�����">
                                    <ItemTemplate>
                                        <%#Eval("Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="�ۿ�����">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rblPortType" runat="server" DataTextField="Name" DataValueField="ID"
                                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Text="װ����" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="ж����" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ���ܣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        ��ˣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        �Ʊ�
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbLCLUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnLCLSave" runat="server" Text="����" CssClass="btn" OnClientClick="return window.confirm('�����Ҫ������')"
                            OnClick="btnSave_Click" />
                        &nbsp;<asp:Button ID="btnLCLDel" runat="server" Text="ɾ��" CssClass="btn" OnClientClick="return window.confirm('�����Ҫɾ����')" />
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--��ҳ-->
        </div>
    </div>
    <div class="window" id="divFCL" runat="server" visible="false">
        <div class="title BGx">
            <span>��װ�䴬���ػ�����Ǽ�</span></div>
        <div class="SlideBox">
            <div>
                <!--��������-->
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <th colspan="8" class="mass BGx">
                            ����
                        </th>
                    </tr>
                    <tr>
                        <td class="tint">
                            �˷ѱ��֣�
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCurrencyFCL" runat="server" AutoPostBack="True" DataTextField="Name"
                                DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="tint">
                            �������
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFCLFee" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                ����Ϊ����</font>
                        </td>
                        <td class="tint">
                            ʼ�˸�װж�ѣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbBeginFee" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> ����</font>
                        </td>
                        <td class="tint">
                            Ŀ�ĸ�װж�ѣ�
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbEndFee" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                ����</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="tint">
                            �Ϳ
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbOilFee" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                ����</font>
                        </td>
                        <td class="tint">
                            ����ѣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbTally" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                ����</font>
                        </td>
                        <td class="tint">
                            ��ѣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbBox" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                ����</font>
                        </td>
                        <td class="tint">
                            ������
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbOther" runat="server" CssClass="inputText" Text="0" />
                        </td>
                    </tr>
                    <tr id="trBranch" runat="server" visible="false">
                        <td class="tint">
                            ���������ķ��ã�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbSubsidize" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> ����</font>
                        </td>
                        <td class="tint">
                            ���շѣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbBookFee" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> ����</font>
                        </td>
                        <td class="tint">
                            ������
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbBranchOther" runat="server" CssClass="inputText" Text="0" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center">
                            ���δ�����𣬰���ȼ�ͣ�����ã������ۿڷ��ã�������ʱ��ҵ�ѣ��ۿ�װж�ѣ��ۿ�����Ѻϼ�:<asp:Label ID="lbFCLTotal" runat="server"
                                Text="0" /><asp:Label ID="lbCName" runat="server" Text="" />�൱��
                            <asp:Label ID="lbFCLTotalRMB" runat="server" Text="0" />
                            �����
                        </td>
                    </tr>
                    <tr>
                        <td class="tint">
                            ��ע��
                        </td>
                        <td align="left" colspan="7">
                            <asp:TextBox ID="tbFCLRemark" runat="server" CssClass="inputText" Text="" TextMode="MultiLine"
                                Height="121px" Width="713px" />
                        </td>
                    </tr>
                    <tr id="trCustmer" runat="server" visible="false">
                        <td class="tint">
                            �ͻ��ᵥ�����
                        </td>
                        <td align="left" colspan="7">
                            <asp:GridView ID="gvCustomerList" border="0" align="left" CellPadding="0" CellSpacing="0"
                                runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%" OnRowCommand="gvCustomerList_RowCommand"
                                CssClass="t">
                                <EmptyDataTemplate>
                                    <font style="color: red; font-weight: bold; font-size: larger;">�޷��������ļ�¼</font>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="����">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbName" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�˷�">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbFee" runat="server" Text='<%#Eval("Fee")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="20gp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbgp20" runat="server" Text='<%#Eval("gp20")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="40gp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbgp40" runat="server" Text='<%#Eval("gp40")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="20dp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbdp20" runat="server" Text='<%#Eval("dp20")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="40dp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbdp40" runat="server" Text='<%#Eval("dp40")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="����" ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="����" CommandName="btnEdit"
                                                Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%#Eval("ID")%>' />
                                            <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="ɾ��" CommandName="btnDel"
                                                Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%#Eval("ID")%>'
                                                OnClientClick="return window.confirm('�����Ҫɾ����')" />
                                            <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="����" CommandName="btnAdd"
                                                Visible='<%# Eval("ID") == null?true:false%>' CommandArgument='<%# Container.DataItemIndex %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="tint">
                            ���ܣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFCLUser1" runat="server" CssClass="inputText" Text="" />
                        </td>
                        <td class="tint">
                            ��ˣ�
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFCLUser2" runat="server" CssClass="inputText" Text="" />
                        </td>
                        <td class="tint">
                            �Ʊ�
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbFCLUser3" runat="server" CssClass="inputText" Text="" />
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="8">
                            <asp:Button ID="btnSave" runat="server" Text="����" CssClass="btn" OnClick="btnSave_Click"
                                OnClientClick="return window.confirm('�����Ҫ������')" />
                            &nbsp;<asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="btn" OnClick="btnDel_Click"
                                OnClientClick="return window.confirm('�����Ҫɾ����')" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <!--��������-->
        </div>
        <div class="toolbar">
            <!--��ҳ-->
        </div>
    </div>
    <div class="window" id="divOther" runat="server" visible="false">
        <div class="title BGx">
            <span>�����ػ�������������Ǽ�</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass BGx">
                        �����ػ�����������Ϣ
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        �ұ�
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrencyOther" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        �����
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> ����Ϊ����</font>�൱��
                        <asp:Label ID="lbOtherRMB" runat="server" CssClass="inputText" Text="0" />
                        �����
                    </td>
                    <td class="tint">
                        ������Ŀ��
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherName" runat="server" CssClass="inputText" Text="" /><font
                            color="red"> ����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ����˵����
                    </td>
                    <td align="left" colspan="7">
                        <asp:TextBox ID="tbRemark" TextMode="MultiLine" runat="server" CssClass="inputText"
                            Text="" Height="98px" Width="557px" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ���ܣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        ��ˣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        �Ʊ�
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbOtherUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnOtherSave" runat="server" Text="����" CssClass="btn" OnClientClick="return window.confirm('�����Ҫ������')"
                            OnClick="btnOtherSave_Click" />
                        &nbsp;<asp:Button ID="btinOtherDel" runat="server" Text="ɾ��" CssClass="btn" OnClientClick="return window.confirm('�����Ҫɾ����')" />
                        &nbsp;
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

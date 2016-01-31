<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="ShipForm.aspx.cs" Inherits="SharpReportWeb.Hangy.ShipForm" Title="������Ϣά��" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>�����б�</span></div>
        <div class="SlideBox">
            <!--��������-->
            <asp:GridView ID="gvShipList" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="0" CssClass="t" Width="100%" PageSize="15" OnRowCommand="gvShipList_RowCommand"
                OnRowDataBound="gvShipList_RowDataBound">
                <Columns>
                    <%--<asp:TemplateField HeaderText="ѡ��" ItemStyle-Width="20">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSel" runat="server" AutoPostBack="false" />
                                <asp:HiddenField runat="server" ID="hidShipId" Value='<%#Eval("ID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="����" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="���" DataField="Code" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="����" DataField="Captain"></asp:BoundField>
                    <asp:BoundField HeaderText="�ֻ���" DataField="ChiefEngineer"></asp:BoundField>
                    <asp:BoundField HeaderText="��������" DataField="GeneralManager"></asp:BoundField>
                    <asp:TemplateField HeaderText="����װ������">
                        <ItemTemplate>
                            <asp:Label ID="tbLoadType" runat="server" Text="δ����"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="������������">
                        <ItemTemplate>
                            <asp:Label ID="tbOperationType" runat="server" Text="δ����"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Button ID="btnEditShip" CssClass="btn" runat="server" Text="�༭" CommandName="btnEditShip"
                                Visible="true" CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDelShip" CssClass="btn" runat="server" Text="����" CommandName="btnDelShip"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('�����Ҫ���øô�����')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        �޷��������ļ�¼</font>
                </EmptyDataTemplate>
            </asp:GridView>
            <input id="lbID2" type="hidden" name="lbID2" runat="server" />
        </div>
        <div class="toolbar">
            <!--��ҳ-->
            <cc1:DefaultPager ID="pGridV" runat="server" Align="Right" OnClick="pGridV_OnClick"
                PageSize="15" />
            <cc1:ExcelGenButton ID="ExcelGenButton2" runat="server" GridViewID="gvShipList" OnClick="ExcelGenButton2_Click"
                Text="����Excel" FileName="�����б�" CssClass="btn"></cc1:ExcelGenButton>
            &nbsp;<asp:Button ID="btnAddShip" runat="server" Text="��������" CssClass="btn" OnClick="btnAddShip_Click" />
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>����������ʹ�����</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        �������ƣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbName" runat="server" CssClass="inputText" /><font color="red"> ����</font>
                    </td>
                    <td class="tint">
                        ������ţ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCode" runat="server" CssClass="inputText" /><font color="red"> ����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint" style="height: 37px">
                        ������
                    </td>
                    <td align="left" colspan="3" style="height: 37px">
                        <asp:TextBox ID="tbCaptain" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        �ֻ�����
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbChiefEngineer" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                    <td class="tint">
                        �������ܣ�
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbGeneralManager" runat="server" CssClass="inputText" /><font color="red">
                            ����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ����ʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="cBuild" runat="server"></cc1:Calendar>
                        <font color="red">����</font>
                    </td>
                    <td class="tint">
                        ����ʱ�䣺
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="cBuy" runat="server"></cc1:Calendar>
                        <font color="red">����</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ��λ���֣���
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbTon" runat="server" CssClass="inputText" /><font color="red"> �������Ϊ���֣���1000.5</font>
                    </td>
                    <td class="tint">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        �����������ͣ�
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblOperationType" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="��Ӫ " Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="����" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="tint">
                        �������޵�����Ӫ����������д����
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="cRentDate" runat="server"></cc1:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        ����װ�����ͣ�
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblLoadType" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="��װ�� " Value="2" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="ɢ��" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="tint">
                        ����״̬��
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblEnable" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="���� " Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="ͣ��" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnSaveShip" runat="server" Text="����" CssClass="btn" OnClick="btnSaveShip_Click"
                            OnClientClick="return window.confirm('�����Ҫ������')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

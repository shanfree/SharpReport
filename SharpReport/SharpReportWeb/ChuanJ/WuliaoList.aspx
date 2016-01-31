<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="WuliaoList.aspx.cs" Inherits="SharpReportWeb.ChuanJ.WuliaoList" Title="���ϱ���" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged"
        IsShowShipAll="true" />
    <div class="window">
        <div class="title BGx">
            <span>���ϱ�����ѯ</span><asp:Button ID="btnAdd" runat="server" Text="����" CssClass="btn"
                OnClick="btnAdd_Click" /></div>
        <div id="SlideBox">
            <asp:GridView ID="gvWuliaoList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="t" PageSize="12" OnRowDataBound="gvWuliaoList_RowDataBound" OnRowCommand="gvWuliaoList_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="���" DataField="Year" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="�·�" DataField="MonthNumOfYear" ItemStyle-Width="10%">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:TemplateField HeaderText="��������" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbReportType" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��;" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbUsage" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="����" DataField="����" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="�Ǽ���" DataField="UserName"></asp:BoundField>
                    <asp:BoundField HeaderText="¼��ʱ��" DataField="CreateTime" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <asp:Button ID="btnView" CssClass="btn" runat="server" Text="�鿴" CommandName="btnView"
                                CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDelete" CssClass="btn" runat="server" Text="ɾ��" CommandName="btnDelete"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('�����Ҫɾ����')" />
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
            <asp:Button ID="btnReturn" runat="server" Text="����ͳ��ҳ��" CssClass="btn" OnClick="btnReturn_Click" />
            <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvWuliaoList"
                OnClick="ExcelGenButton1_Click" Text="����Excel" CssClass="btn" Style="text-align: right">
            </cc1:ExcelGenButton>
            <cc1:DefaultPager ID="pGrid" runat="server" Align="Right" OnClick="pGrid_OnClick"
                PageSize="12" Style="text-align: right"></cc1:DefaultPager>
        </div>
    </div>
    <asp:RadioButtonList ID="rblReportType" runat="server" DataTextField="Name" DataValueField="ID"
        Visible="false">
        <asp:ListItem Text="Ԥ��¼��" Value="1"></asp:ListItem>
        <asp:ListItem Text="����¼��" Value="2"></asp:ListItem>
        <asp:ListItem Text="����ȷ��" Value="3"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:RadioButtonList ID="rblUsage" runat="server" DataTextField="Name" DataValueField="ID"
        Visible="false">
        <asp:ListItem Text="ȫ��" Value="0"></asp:ListItem>
        <asp:ListItem Text="�ճ���" Value="1"></asp:ListItem>
        <asp:ListItem Text="������" Value="2"></asp:ListItem>
        <asp:ListItem Text="������" Value="3"></asp:ListItem>
    </asp:RadioButtonList>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>
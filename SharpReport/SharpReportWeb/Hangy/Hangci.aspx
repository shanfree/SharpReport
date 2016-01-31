<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="Hangci.aspx.cs" Inherits="SharpReportWeb.ChuanJ.Hangci" Title="���α༭" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
    <div class="window">
        <div class="title BGx">
            <span>�����б�</span></div>
        <div class="SlideBox">
            <!--��������-->
            <asp:GridView ID="gvVoyageList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="t" PageSize="15" OnRowCommand="gvVoyageList_RowCommand" OnRowDataBound="gvVoyageList_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="ѡ��" ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSel" runat="server" AutoPostBack="false" />
                            <asp:HiddenField runat="server" ID="hidVoyageCb" Value='<%#Eval("ID")%>' />
                            <asp:HiddenField runat="server" ID="hidShipId" Value='<%#Eval("ShipId")%>' />
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="�����" DataField="OrderNum" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="����" DataField="ShipName" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="��������" DataField="VoyageName"></asp:BoundField>
                    <asp:BoundField HeaderText="��������" DataField="RouteName"></asp:BoundField>
                    <asp:BoundField HeaderText="��ʼʱ��" DataField="StartTime" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="����ʱ��" DataField="EndTime" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:TemplateField HeaderText="ȼ���ϱ���" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbViewRanrun" runat="server" Text="δ�" Visible="false"></asp:Label>
                            <asp:HyperLink ID="hlViewRanrun" runat="server" Visible="false" NavigateUrl='<%# "../ChuanJ/RanrunInput.aspx?baseId="+Eval("HangciBaseId") %>'
                                Target="_self">�鿴ȼ���ϱ���</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Button ID="btnEditVoyage" CssClass="btn" runat="server" Text="�༭" CommandName="btnEditVoyage"
                                Visible="true" CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDelVoyage" CssClass="btn" runat="server" Text="ɾ��" CommandName="btnDelVoyage"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('�����Ҫɾ����')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        �޷��������ļ�¼</font>
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Left" />
            </asp:GridView>
            <input id="lbID2" type="hidden" name="lbID2" runat="server" />
            <!--��������-->
        </div>
        <div class="toolbar" style="text-align: center">
            <!--��ҳ-->
            <cc1:DefaultPager ID="pGridV" runat="server" Align="Left" OnClick="pGridV_OnClick"
                PageSize="15" />
            <cc1:ExcelGenButton ID="ExcelGenButton2" runat="server" GridViewID="gvVoyageList"
                OnClick="ExcelGenButton2_Click" Text="����Excel" FileName="�����б�" CssClass="btn">
            </cc1:ExcelGenButton>
            &nbsp;<asp:Button ID="btnAddVoyage" runat="server" Text="��������" CssClass="btn" OnClick="btnAddVoyage_Click" />
            &nbsp;<asp:Button ID="btnCreateReport" runat="server" Text="����ȼ���ϱ���" CssClass="btn"
                OnClick="btnCreateReport_Click" />
            &nbsp;<asp:Button ID="btnViewReport" runat="server" Text="ά��ȼ���ϱ���" CssClass="btn"
                OnClick="btnViewReport_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

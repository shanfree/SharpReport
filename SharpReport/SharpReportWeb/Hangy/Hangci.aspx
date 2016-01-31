<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="Hangci.aspx.cs" Inherits="SharpReportWeb.ChuanJ.Hangci" Title="航次编辑" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
    <div class="window">
        <div class="title BGx">
            <span>航次列表</span></div>
        <div class="SlideBox">
            <!--滚动必须-->
            <asp:GridView ID="gvVoyageList" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="t" PageSize="15" OnRowCommand="gvVoyageList_RowCommand" OnRowDataBound="gvVoyageList_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSel" runat="server" AutoPostBack="false" />
                            <asp:HiddenField runat="server" ID="hidVoyageCb" Value='<%#Eval("ID")%>' />
                            <asp:HiddenField runat="server" ID="hidShipId" Value='<%#Eval("ShipId")%>' />
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="排序号" DataField="OrderNum" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="船名" DataField="ShipName" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="航次名称" DataField="VoyageName"></asp:BoundField>
                    <asp:BoundField HeaderText="航线名称" DataField="RouteName"></asp:BoundField>
                    <asp:BoundField HeaderText="开始时间" DataField="StartTime" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="结束时间" DataField="EndTime" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:TemplateField HeaderText="燃润料报表" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lbViewRanrun" runat="server" Text="未填报" Visible="false"></asp:Label>
                            <asp:HyperLink ID="hlViewRanrun" runat="server" Visible="false" NavigateUrl='<%# "../ChuanJ/RanrunInput.aspx?baseId="+Eval("HangciBaseId") %>'
                                Target="_self">查看燃润料报表</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Button ID="btnEditVoyage" CssClass="btn" runat="server" Text="编辑" CommandName="btnEditVoyage"
                                Visible="true" CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDelVoyage" CssClass="btn" runat="server" Text="删除" CommandName="btnDelVoyage"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Left" />
            </asp:GridView>
            <input id="lbID2" type="hidden" name="lbID2" runat="server" />
            <!--滚动必须-->
        </div>
        <div class="toolbar" style="text-align: center">
            <!--翻页-->
            <cc1:DefaultPager ID="pGridV" runat="server" Align="Left" OnClick="pGridV_OnClick"
                PageSize="15" />
            <cc1:ExcelGenButton ID="ExcelGenButton2" runat="server" GridViewID="gvVoyageList"
                OnClick="ExcelGenButton2_Click" Text="生成Excel" FileName="航次列表" CssClass="btn">
            </cc1:ExcelGenButton>
            &nbsp;<asp:Button ID="btnAddVoyage" runat="server" Text="新增航次" CssClass="btn" OnClick="btnAddVoyage_Click" />
            &nbsp;<asp:Button ID="btnCreateReport" runat="server" Text="创建燃润料报表" CssClass="btn"
                OnClick="btnCreateReport_Click" />
            &nbsp;<asp:Button ID="btnViewReport" runat="server" Text="维护燃润料报表" CssClass="btn"
                OnClick="btnViewReport_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

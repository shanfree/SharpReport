<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonFeeStatistic.ascx.cs"
    Inherits="SharpReportWeb.WUC.CommonFeeStatistic" %>
<asp:GridView ID="gvList" runat="server" Width="100%" CssClass="t" PageSize="50"
    AutoGenerateColumns="false">
    <RowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
        <font color="red" style="font-size: large; color: red; text-decoration: underline;">
            无符合条件的记录</font>
    </EmptyDataTemplate>
    <HeaderStyle HorizontalAlign="Center" />
    <Columns>
        <asp:BoundField HeaderText="费用类型" DataField="Name"></asp:BoundField>
        <asp:BoundField HeaderText="所属部门" DataField="DepartmentName"></asp:BoundField>
        <asp:BoundField HeaderText="总金额" DataField="Amount"></asp:BoundField>
        <asp:BoundField HeaderText="报表数" DataField="Number"></asp:BoundField>
    </Columns>
</asp:GridView>

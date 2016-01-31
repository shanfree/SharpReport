<%@ Page Title="" Language="C#" MasterPageFile="~/Base/ListPage.Master" AutoEventWireup="true"
    CodeBehind="CostCategory.aspx.cs" Inherits="SharpReportWeb.DicMgmt.CostCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="server">
    <asp:Label ID="Label1" runat="server" Text="名称："></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="查询" />&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="新增" />
    <!-- Ajax 查询列表 ->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOperation" runat="server">
    <!-- 操作按钮 -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTable" runat="server">
    <!-- gridlayout -->
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

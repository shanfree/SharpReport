<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Admin_Register" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="Server">
    <div class="adminTitle">
        添加用户</div>
    <div style="padding-left: 12px; padding-top: 6px; padding-bottom: 6px;">
        用户名称：
        <asp:TextBox ID="tbName" runat="server" /><br />
        用户密码：
        <asp:TextBox ID="tbPws" runat="server" TextMode="Password" /><br />
        确认密码：
        <asp:TextBox ID="tbComfirm" runat="server" TextMode="Password"></asp:TextBox><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
    </div>
</asp:Content>

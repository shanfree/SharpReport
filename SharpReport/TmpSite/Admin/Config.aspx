<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Admin_Config" Title="配置管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" Runat="Server">
    <div class="adminTitle">
        配置管理</div>
    <div style="padding-left: 12px; padding-top: 6px; padding-bottom: 6px;">
        现有站点URL：
        <asp:TextBox ID="tbBaseURL" runat="server" Width="450px" /><br />
        迁移后的URL：
        <asp:TextBox ID="tbURL" runat="server" Width="450px" /><br />
        <asp:Button ID="btnModify" runat="server" Text="修改" OnClick="btnModify_Click" /><br />
    </div>
</asp:Content>


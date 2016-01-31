<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Admin_Main"
    MasterPageFile="~/MasterPage/Admin.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="Conut1" runat="server">
    <div class="adminTitle">
        系统信息</div>
    <div style="padding-left: 12px;">
        主机名称:&nbsp;<asp:Label ID="Name" runat="server" /><br />
        服务器IP:&nbsp;<asp:Label ID="ip" runat="server" /><br />
        服务端口:&nbsp;<asp:Label ID="Dk" runat="server" /><br />
        系统时间:&nbsp;<asp:Label ID="Time" runat="server" /><br />
        操作系统:&nbsp;<asp:Label ID="Os" runat="server" /><br />
        环境版本:&nbsp;<asp:Label ID="Iis" runat="server" /><br />
        NET版本:&nbsp;<%
                        int build, major, minor, revision;
                        build = Environment.Version.Build;
                        major = Environment.Version.Major;
                        minor = Environment.Version.Minor;
                        revision = Environment.Version.Revision;
                        Response.Write(major + "." + minor + "." + build + "." + revision);    
        %><br />
    </div>
</asp:Content>

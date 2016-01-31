<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SharpReportWeb.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <!--不能丢-->
    <title>福建东方海运营收成本核算系统--用户登录</title>
    <link href="CSS/Default.css" rel="stylesheet" type="text/css" />

    <script src="Script/jquery-1.7.1.js" type="text/javascript"></script>

    <style type="text/css">
        body
        {
            background-color: #69C;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="loginPanel">
        <asp:TextBox ID="userName" runat="server" Text="admin" class="userName"></asp:TextBox>
        <asp:TextBox ID="password" runat="server" TextMode="SingleLine" Text="1" class="password"></asp:TextBox>
        <asp:Button ID="login" runat="server" Text="" OnClick="btnLogin_Click" />
        <div id="loginTips">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*用户名称不能为空。"
                Display="Dynamic" ControlToValidate="userName"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*用户密码不能为空。"
                Display="Dynamic" ControlToValidate="password"></asp:RequiredFieldValidator><br />
            <a style="color: blue;" href="files/福建东方海运营收成本核算系统用户手册.doc" target="_blank">福建东方海运营收成本核算系统用户手册下载</a>
        </div>
    </div>
    </form>
</body>
</html>

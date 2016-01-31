<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="___TestPage.aspx.cs" Inherits="SharpReportWeb.___TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnIDCheck" runat="server" Text="身份证验证测试" OnClick="btnIDCheck_Click" />

        <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

        <input class="Wdate" type="text" onclick="WdatePicker()">
        <font color="red">&lt;- 点我弹出日期控件</font>
    </div>
    </form>
</body>
</html>

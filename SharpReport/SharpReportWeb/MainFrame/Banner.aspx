<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banner.aspx.cs" Inherits="SharpReportWeb.MainFrame.Banner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <!--不能丢-->
    <title>福建东方海运营收成本核算系统</title>
    <link href="../CSS/Default.css" rel="stylesheet" type="text/css">

    <script src="../Script/jquery-1.7.1.js" type="text/javascript"></script>

    <style type="text/css">
        /*不可外联*/#banner
        {
            background: url(../Images/banner.png) right no-repeat;
        }
    </style>
</head>
<body class="BGx">
    <form id="form1" runat="server">
    <div id="banner">
        <ul>
            <li>当前用户：系统管理员</li>
            <li><a href="#">退出系统</a></li>
        </ul>
        <img src="../Images/sysTitle.png" alt="#" />
    </div>
    <dl id="menuBox">
        <dd class="BG">
            <!---->
        </dd>
        <dd class="BGx">
            <ul>
                <asp:Repeater ID="rMenu" runat="server">
                    <ItemTemplate>
                        <li><a href="<%#Eval("URL") %>" target="mainFrame">
                            <%#Eval("Name") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </dd>
    </dl>

    <script type="text/javascript">
        $("#menuBox a").click(function() {
            var i = $("#menuBox a").index(this)
            var n = $("#menuBox a").length;
            for (j = 0; j < n; j++) {
                if (j != i) { $("#menuBox a")[j].className = "" }
                else { $("#menuBox a")[j].className = "selected" }
            }

        });
        $(document).ready(function() {
            $("#banner li:last").addClass("SP")
            $("#menuBox li:last").addClass("SP")
            $("#menuBox a:last").addClass("SP")
        });
    </script>

    </form>
</body>
</html>

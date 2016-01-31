<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SharpReportWeb.Admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <!--不能丢-->
    <title></title>
    <link href="../CSS/Default.css" rel="stylesheet" type="text/css" />

    <script src="../Script/jquery-1.7.1.js" type="text/javascript"></script>

    <script src="../Script/Default.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="workArea">
        <tr>
            <td valign="top" class="tree">
                <div class="title BG">
                    系统管理</div>
                <dl class="treeBox">
                    <asp:Repeater ID="rMenu" runat="server" onitemdatabound="rMenu_ItemDataBound">
                        <ItemTemplate>
                            <dt><a href="<%#Eval("URL") %>" target="mainFrame">
                                <img src="../Images/folder.png" alt="" />
                                <%#Eval("Name") %></a></dt>
                            <dd id="d2ndMenu">
                                <dl>
                                    <asp:Repeater ID="r2ndMenu" runat="server"  onitemdatabound="r2ndMenu_ItemDataBound">
                                        <ItemTemplate>
                                            <dt><a href="<%#Eval("URL") %>" target="mainFrame">
                                                <img src="../Images/chart_pie.png" alt="" />
                                                <%#Eval("Name") %></a></dt>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </dl>
                            </dd>
                        </ItemTemplate>
                    </asp:Repeater>
            </td>
            <td valign="top">
                <iframe src="Main.aspx" width="100%" scrolling="no" frameborder="0"></iframe>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(".tree dt").click(function() {
            var i = $(".tree dt").index(this)
            var n = $(".tree dt").length
            $(".tree dt").attr("class", "")
            $(".tree dt").get(i).className = "selected"
        });
    </script>

    </form>
</body>
</html>

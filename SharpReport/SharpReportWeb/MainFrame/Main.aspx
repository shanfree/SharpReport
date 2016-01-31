<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SharpReportWeb.MainFrame.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <!--不能丢-->
    <title></title>
    <link href="../CSS/Default.css" rel="stylesheet" type="text/css" />

    <script src="../Script/jquery-1.7.1.js" type="text/javascript"></script>

    <script src="../Script/Default.js" type="text/javascript"></script>

    <link href="../CSS/SpryAccordion.css" rel="stylesheet" type="text/css">

    <script src="../Script/Default.js" type="text/javascript"></script>

    <script src="../Script/SpryAccordion.js" type="text/javascript"></script>

    <style type="text/css">
        body
        {
            background-color: #FFF;
        }
    </style>

    <script type="text/javascript">
        function setH() {
            $(".AccordionPanelContent").height($("body").innerHeight() - 57 - 31 * $(".AccordionPanelTab").length)
            $("#frameBox_S3 iframe").height($("body").innerHeight() - 22)
        }
        $(document).ready(function() {
            setH();
        });
        $(window).resize(function() {
            setH();
        })
    </script>

</head>
<body onload="ChangeUrl('Tabs.aspx')">
    <div id="frameBox_S1">
        <form id="form1" runat="server" style="height: 100%">
        <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="col_S4">
                    <ul class="title_S2">
                        <li class="C BG">
                            <!---->
                        </li>
                        <li class="D BG">
                            <!---->
                        </li>
                        <li class="title BGx">营收成本核算系统</li>
                    </ul>
                    <div id="frameBox_S2">
                        <div id="Accordion" class="Accordion" tabindex="0">
                            <asp:Repeater ID="rMenu" runat="server" OnItemDataBound="rMenu_ItemDataBound">
                                <ItemTemplate>
                                    <div class="AccordionPanel">
                                        <div class="AccordionPanelTab">
                                            <span>
                                                <%#Eval("Name") %></span></div>
                                        <div class="AccordionPanelContent">
                                            <div class="tree">
                                                <dl>
                                                    <asp:Repeater ID="r2ndMenu" runat="server" OnItemDataBound="r2ndMenu_ItemDataBound">
                                                        <ItemTemplate>
                                                            <dt><a href="<%#Eval("URL") %>" target="ifMain">
                                                                <img src="../Images/chart_pie.png" alt="" />
                                                                <%#Eval("Name") %></a></dt>
                                                            <dd class="visible">
                                                                <dl style="margin-left: 20px">
                                                                    <asp:Repeater ID="r3rdMenu" runat="server">
                                                                        <ItemTemplate>
                                                                            <dt><a onclick="javascript:ChangeUrl('<%#Eval("URL") %>')" target="ifMain">
                                                                                <img src="../Images/key.png" alt="" />
                                                                                <%#Eval("Name") %></a></dt>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </dl>
                                                            </dd>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </dl>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </td>
                <td class="col_S5">
                    <img src="../Images/hidden.png" alt="" title="隐藏边栏" />
                </td>
                <td id="frameBox_S3">
                    <iframe id="ifMain" name="ifMain" scrolling="no" src="" style="width: 100%"
                        frameborder="0"></iframe>
                </td>
            </tr>
        </table>

        <script type="text/javascript">
            $("#dropNav li:eq(2)").click(function() {
                if ($(".links").css("display") == "none") {
                    $(".links").css("display", "block");
                    $(this).css("background-position", "-123px 0");
                }
                else {
                    $(".links").css("display", "none");
                    $(this).css("background-position", "-96px 0");
                }
            })
            $("#dropNav a").click(function() {
                var t1 = $(this).text();
                var t2 = $("#dropNav li:eq(3)").text();
                if (t2 != t1) {
                    $("#dropNav li:eq(3)").text(t1);
                }
                $(".links").css("display", "none");
                $("#dropNav li:eq(2)").css("background-position", "-96px 0");
            })
            var n = 1;
            $("img").click(function() {
                if (n == 1) {
                    $(".col_S4").hide();
                    $(this).css("right", "0");
                    $(this).attr("title", "显示边栏");
                    $(this).attr("src", "../Images/show.png");
                    n = 0;
                }
                else {
                    $(".col_S4").show();
                    $(this).css("right", "-1px");
                    $(this).attr("title", "隐藏边栏");
                    $(this).attr("src", "../Images/hidden.png");
                    n = 1;
                }
            })

            $("dt:eq(0)").addClass("selected")
            $("dt").blur(function() {
                var $n = $(this).parents("dd").length
                for (var $i = 0; $i < $n - 1; $i++) {
                    $(this).find(".icon").before("<img src='../Images/treei.png' alt=''/>")
                }
                if ($n != 0) {
                    $(this).find(".icon").before("<img src='../Images/treet.png' alt=''/>")
                }
                $("dl").find("dt:last").find(".icon").prev().attr("src", "../Images/treeL.png")
            })
            $("dt").blur();
            $("dt").click(function() {
                $("dt").attr("class", "")
                $(this).addClass("selected");
            })
            $(".icon").click(function() {
                var $obj = $(this).parent().next("dd")
                if ($obj.attr("class") == "visible") {
                    $obj.attr("class", "hidden")
                    $(this).attr("src", "../Images/folder.png");
                }
                else {
                    $obj.attr("class", "visible")
                    $(this).attr("src", "../Images/folder_page.png");
                }
            })
            $("a").click(function() {
                var $obj = $(this).parent().next("dd")
                if ($(this).attr("href") == "javascript:void(0);") {
                    if ($obj.attr("class") == "visible") {
                        $obj.attr("class", "hidden")
                        $(this).prev("img").attr("src", "../Images/folder.png");
                    }
                    else {
                        $obj.attr("class", "visible")
                        $(this).prev("img").attr("src", "../Images/folder_page.png");
                    }
                }
            })
            var Accordion1 = new Spry.Widget.Accordion("Accordion");

            // 改变右边框架链接
            function ChangeUrl(url) {
                if (url != "") {
                    var openUrl = url.toLowerCase().indexOf("http://");

                    if (openUrl != -1) {
                        window.open(url);
                    }
                    else {
                        var ifMain = document.getElementById("ifMain");
                        ifMain.src = url;
                    }
                }
            }
        </script>

        </form>
    </div>
</body>
</html>

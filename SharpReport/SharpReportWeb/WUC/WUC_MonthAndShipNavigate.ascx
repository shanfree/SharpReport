<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUC_MonthAndShipNavigate.ascx.cs"
    Inherits="SharpReportWeb.WUC.WUC_MonthAndShipNavigate" %>
<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<div id="searchArea">
    <div class="title BGx">
        <img src="../Images/title_06.png" alt="查询区域" /></div>
    <ul id="ulBase" runat="server">
        <li class="normal">年&nbsp;&nbsp;&nbsp;&nbsp;份：
            <asp:DropDownList ID="rblYear" runat="server" Style="border: 0px;" OnSelectedIndexChanged="rblYear_SelectedIndexChanged"
                AutoPostBack="true" DataTextField="Name" DataValueField="ID">
            </asp:DropDownList>
        </li>
        <li class="normal">月&nbsp;&nbsp;&nbsp;&nbsp;份：
            <asp:DropDownList ID="rblMoth" runat="server" OnSelectedIndexChanged="rblDim_SelectedIndexChanged"
                AutoPostBack="true" DataTextField="Name" DataValueField="ID">
                <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                <asp:ListItem Value="1">一月</asp:ListItem>
                <asp:ListItem Value="2">二月</asp:ListItem>
                <asp:ListItem Value="3">三月</asp:ListItem>
                <asp:ListItem Value="4">四月</asp:ListItem>
                <asp:ListItem Value="5">五月</asp:ListItem>
                <asp:ListItem Value="6">六月</asp:ListItem>
                <asp:ListItem Value="7">七月</asp:ListItem>
                <asp:ListItem Value="8">八月</asp:ListItem>
                <asp:ListItem Value="9">九月</asp:ListItem>
                <asp:ListItem Value="10">十月</asp:ListItem>
                <asp:ListItem Value="11">十一月</asp:ListItem>
                <asp:ListItem Value="12">十二月</asp:ListItem>
            </asp:DropDownList>
        </li>
        <li class="normal">船舶选择：
            <asp:DropDownList ID="rblShip" runat="server" OnSelectedIndexChanged="rblShip_SelectedIndexChanged"
                AutoPostBack="true" DataTextField="Name" DataValueField="ID">
            </asp:DropDownList>
        </li>
        <li class="clear"></li>
    </ul>
    <ul id="advancedOptions">
        <li class="normal">船舶名称：&nbsp;<asp:TextBox ID="tbShip" runat="server" class="inputText"></asp:TextBox></li>
        <li class="normal">到港日期：<cc1:Calendar ID="cBeginDate" runat="server" class="inputText"
            size="4"></cc1:Calendar>
            至
            <cc1:Calendar ID="cEndDate" runat="server" class="inputText" size="4"></cc1:Calendar></li>
        <li class="normal">所有类型：<asp:DropDownList ID="rblOperationType" runat="server">
            <asp:ListItem Text="全部 " Value="" Selected="True"></asp:ListItem>
            <asp:ListItem Text="自营 " Value="1"></asp:ListItem>
            <asp:ListItem Text="租赁" Value="2"></asp:ListItem>
        </asp:DropDownList>
        </li>
        <li class="normal">装箱类型：
            <asp:DropDownList ID="rblLoadType" runat="server">
                <asp:ListItem Text="全部 " Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="集装箱 " Value="2"></asp:ListItem>
                <asp:ListItem Text="散货" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </li>
        <li class="clear"></li>
    </ul>
    <ul>
        <li class="normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
            type="button" class="advancedOptionsBtn" />
            <span class="btn">
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn" OnClick="btnSearch_Click" />
            </span></li>
    </ul>
    <div class="clear">
    </div>
</div>

<script type="text/javascript">
    var n = 0
    $("#dropDownList dt").click(function() {
        var popWin = $("#dropDownList dd").get(0)
        if (n == 0) {
            popWin.style.display = ""
            $("#dropDownList span").attr("class", "clicked")
            n = 1
        }
        else {
            popWin.style.display = "none"
            $("#dropDownList span").attr("class", "")
            n = 0
        }
    });
    $(".advancedOptionsBtn").click(function() {
        if ($("#advancedOptions").css("display") == "none") {
            $("#advancedOptions").css("display", "block");
            $(this).css("background-position", "-105px -186px");
        }
        else {
            $("#advancedOptions").css("display", "none");
            $(this).css("background-position", "0 -186px");
        }
    });
</script>


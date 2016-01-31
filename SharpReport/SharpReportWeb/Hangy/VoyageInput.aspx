<%@ Page Title="船期维护" Language="C#" MasterPageFile="~/MasterPage/Default.Master"
    AutoEventWireup="true" CodeBehind="VoyageInput.aspx.cs" Inherits="SharpReportWeb.Hangy.VoyageInput" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>船舶航次信息 </span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        航次名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbVoyageName" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        船舶：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlShipName" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlShipName_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">必填</font>
                    </td>
                    <td class="tint">
                        经营方式：
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlManagerType" runat="server" DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        航线名称：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlRouteName" runat="server" DataTextField="Name" DataValueField="ID"
                            OnSelectedIndexChanged="ddlRouteName_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">航线未登记？请点击</font>
                        <asp:Button ID="btnRoute" runat="server" Text="编辑航线" CssClass="btn" OnClick="btnRoute_Click" /><font
                            color="red">跳转</font>
                    </td>
                    <td class="tint">
                        航线说明：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label runat="server" ID="lbRoute" Text="--"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        开始时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server" Width="101px"></cc1:Calendar><asp:DropDownList
                            ID="ddlStartHour" runat="server">
                        </asp:DropDownList>
                        时<asp:DropDownList ID="ddlStartMin" runat="server">
                        </asp:DropDownList>
                        分
                    </td>
                    <td class="tint">
                        结束时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar><asp:DropDownList ID="ddlEndHour" runat="server">
                        </asp:DropDownList>
                        时<asp:DropDownList ID="ddlEndMin" runat="server">
                        </asp:DropDownList>
                        分
                    </td>
                    <td class="tint">
                        运行天数：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label runat="server" ID="lbDays" Text="0天0小时0分"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" visible="false">
                    <td class="tint">
                        航次排序号：
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="tbOrder" runat="server" CssClass="inputText" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnAddVoyage" runat="server" Text="新增航次" CssClass="btn" OnClick="btnAddVoyage_Click" />
                        &nbsp;<asp:Button ID="btnSaveVoyage" runat="server" Text="保存航次" CssClass="btn" OnClick="btnSaveVoyage_Click"
                            OnClientClick="return window.confirm('您真的要保存吗？')" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="查看航次列表" CssClass="btn" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
    <div class="window" id="divFCL" runat="server" visible="false">
        <div class="title BGx">
            <span>集装箱船舶载货情况登记</span></div>
        <div class="SlideBox">
            <div>
                <!--滚动必须-->
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <th colspan="8" class="mass BGx">
                            20英尺柜
                        </th>
                    </tr>
                    <tr>
                        <td class="tint">
                            空柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbTEUEmpty" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            重柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbTEUHeavy" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            冷冻柜：
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbTEUFROST" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="8" class="mass BGx">
                            40英尺柜
                        </th>
                    </tr>
                    <tr>
                        <td class="tint">
                            空柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFEUEmpty" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            重柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFEUHeavy" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            冷冻柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFEUFROST" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            危险品柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFEUDANG" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="8" class="mass BGx">
                            45英尺柜
                        </th>
                    </tr>
                    <tr>
                        <td class="tint">
                            空柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFFEUEmpty" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            重柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFFEUHeavy" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            冷冻柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFFEUFROST" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            危险品柜：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFFEUDANG" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="8" class="mass BGx">
                            特殊柜
                        </th>
                    </tr>
                    <tr>
                        <td class="tint">
                            特殊的柜数目：
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbRest" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                *</font>相当于
                            <asp:TextBox ID="tbEqualTo" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> *</font>标准柜 <font color="red">特殊的柜数目必须小于或者等于标准柜数目</font>
                        </td>
                        <td class="tint">
                            自然柜总数：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbTotalNatu" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            标准柜总数：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbTotalStand" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="8">
                            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" OnClick="btnSave_Click"
                                OnClientClick="return window.confirm('您真的要保存吗？')" />
                            &nbsp;<asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" OnClick="btnDel_Click"
                                OnClientClick="return window.confirm('您真的要删除吗？')" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <!--滚动必须-->
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

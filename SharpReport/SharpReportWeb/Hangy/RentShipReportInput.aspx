<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="RentShipReportInput.aspx.cs" Inherits="SharpReportWeb.Hangy.RentShipReportInput"
    Title="船舶出租租金计费表	" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>船舶出租租金计费表 </span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
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
                        出租方式：
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="ddlRentType" runat="server" DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="1">班轮运输</asp:ListItem>
                            <asp:ListItem Value="2">租船运输</asp:ListItem>
                            <asp:ListItem Value="3">航次租船</asp:ListItem>
                            <asp:ListItem Value="4">单程租船</asp:ListItem>
                            <asp:ListItem Value="5">往返租船</asp:ListItem>
                            <asp:ListItem Value="6">连续航次租船</asp:ListItem>
                            <asp:ListItem Value="7">航次期租船</asp:ListItem>
                            <asp:ListItem Value="8">包运合同租船</asp:ListItem>
                            <asp:ListItem Value="9">定期租船</asp:ListItem>
                            <asp:ListItem Value="10">光船租船</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        客户名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCustomer" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        纳税识别号：
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="tbTaxNo" runat="server" CssClass="inputText" /><font color="red"> 必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        租金计算开始时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        租金计算结束时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        出租天数：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label runat="server" ID="lbDays" Text="0天0小时0分"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        扣租时间：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDiscountDays" runat="server" CssClass="inputText" />
                        天
                    </td>
                    <td class="tint">
                        计算租金时间：
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="tbRealDays" runat="server" CssClass="inputText" />
                        天
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        租金计费币种：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        日租金：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbPrice" runat="server" CssClass="inputText" Text="0" /><font color="red">
                            必须为数字</font>
                    </td>
                    <td class="tint">
                        租金金额：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbRentFee" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        通讯费：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCommunicateFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必须为数字</font>
                    </td>
                    <td class="tint">
                        绑扎锁具补贴：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLockFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必须为数字</font>
                    </td>
                    <td class="tint">
                        其他补贴：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbOtherFee" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        租金、通讯费、绑扎锁具、其他合计:<asp:Label ID="lbTotal" runat="server" Text="0" /><asp:Label ID="lbCName"
                            runat="server" Text="" />相当于
                        <asp:Label ID="lbTotalRMB" runat="server" Text="0" />
                        人民币
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        备注：
                    </td>
                    <td align="left" colspan="7">
                        <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" Text="" TextMode="MultiLine"
                            Height="121px" Width="713px" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        主管：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        审核：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        制表：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnSaveVoyage" runat="server" Text="保存" CssClass="btn" OnClientClick="return window.confirm('您真的要保存吗？')"
                            OnClick="btnSaveVoyage_Click" />
                        &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回列表页面" CssClass="btn" OnClick="btnReturn_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

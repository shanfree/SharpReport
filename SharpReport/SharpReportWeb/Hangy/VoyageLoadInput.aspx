<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="VoyageLoadInput.aspx.cs" Inherits="SharpReportWeb.Hangy.VoyageLoadInput"
    Title="船舶装箱情况登记" %>

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
                            AutoPostBack="True">
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
                    <td align="left" colspan="5">
                        <asp:TextBox ID="tbOrder" runat="server" CssClass="inputText" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
    <div class="window" id="divLCL" runat="server" visible="false">
        <div class="title BGx">
            <span>散货船舶载货情况登记</span></div>
        <div class="SlideBox">
            <!--滚动必须-->
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        客户名称/支付方：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCustomer" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        纳税识别号：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbTaxNo" runat="server" CssClass="inputText" />
                    </td>
                </tr>
                <tr>
                    <th colspan="6" class="mass BGx">
                        散货船载货费用信息
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        货种：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLName" runat="server" CssClass="inputText" Text="" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        货运量（吨）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLAmount" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必填,且必须为数字</font>
                    </td>
                    <td class="tint">
                        计费货运量（吨）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLAmountReal" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必填,且必须为数字,必须小于货运量</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        计费币种：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        运价（元/吨）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbTransport" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必填</font>
                    </td>
                    <td class="tint">
                        运费：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbAmount" runat="server" CssClass="inputText" Text="0" />相当于
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        滞期时间（天）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDelay" runat="server" CssClass="inputText" Text="0" /><font color="red">
                            必填,且必须为数字</font>
                    </td>
                    <td class="tint">
                        滞期率（元/天）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDelayFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必填,且必须为数字</font>
                    </td>
                    <td class="tint">
                        滞期费：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbDelayAmount" runat="server" CssClass="inputText" Text="0" />相当于
                        <asp:Label ID="lbDelayRMB" runat="server" CssClass="inputText" Text="0" /><font> 人民币</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        速遣时间（天）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDispatch" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必填,且必须为数字</font>
                    </td>
                    <td class="tint">
                        速遣率（元/天）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDispatchFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必填,且必须为数字</font>
                    </td>
                    <td class="tint">
                        速遣费：
                    </td>
                    <td align="left">
                        <asp:Label ID="lbDispatchAmount" runat="server" CssClass="inputText" Text="0" />相当于
                        <asp:Label ID="lbDispatchRMB" runat="server" CssClass="inputText" Text="0" /><font>
                            人民币</font>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        运费、滞期、速遣合计:<asp:Label ID="lbTotal" runat="server" CssClass="inputText" Text="0" /><asp:Label
                            ID="lbLCLCName" runat="server" Text="" />相当于
                        <asp:Label ID="lbTotalRMB" runat="server" CssClass="inputText" Text="0" />
                        人民币
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        航线各港口定义：
                    </td>
                    <td colspan="5" align="left">
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Font-Size="12px"
                            border="0" CellPadding="0" CellSpacing="0" CssClass="t" Width="100%">
                            <EmptyDataTemplate>
                                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="港口名称">
                                    <ItemTemplate>
                                        <%#Eval("Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="港口类型">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rblPortType" runat="server" DataTextField="Name" DataValueField="ID"
                                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Text="装货港" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="卸货港" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        主管：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        审核：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbLCLUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        制表：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbLCLUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnLCLSave" runat="server" Text="保存" CssClass="btn" OnClientClick="return window.confirm('您真的要保存吗？')"
                            OnClick="btnSave_Click" />
                        &nbsp;<asp:Button ID="btnLCLDel" runat="server" Text="删除" CssClass="btn" OnClientClick="return window.confirm('您真的要删除吗？')" />
                        &nbsp;
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
                            费用
                        </th>
                    </tr>
                    <tr>
                        <td class="tint">
                            运费币种：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCurrencyFCL" runat="server" AutoPostBack="True" DataTextField="Name"
                                DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="tint">
                            航次租金：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFCLFee" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                必须为数字</font>
                        </td>
                        <td class="tint">
                            始运港装卸费：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbBeginFee" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            目的港装卸费：
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbEndFee" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                必填</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="tint">
                            油款：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbOilFee" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                必填</font>
                        </td>
                        <td class="tint">
                            理货费：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbTally" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                必填</font>
                        </td>
                        <td class="tint">
                            箱费：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbBox" runat="server" CssClass="inputText" Text="0" /><font color="red">
                                必填</font>
                        </td>
                        <td class="tint">
                            其他：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbOther" runat="server" CssClass="inputText" Text="0" />
                        </td>
                    </tr>
                    <tr id="trBranch" runat="server" visible="false">
                        <td class="tint">
                            政府补贴的费用：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbSubsidize" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            订舱费：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbBookFee" runat="server" CssClass="inputText" Text="0" /><font
                                color="red"> 必填</font>
                        </td>
                        <td class="tint">
                            其他：
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbBranchOther" runat="server" CssClass="inputText" Text="0" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center">
                            航次船舶租金，包干燃油，箱费用，增减港口费用，船舶延时作业费，港口装卸费，港口理货费合计:<asp:Label ID="lbFCLTotal" runat="server"
                                Text="0" /><asp:Label ID="lbCName" runat="server" Text="" />相当于
                            <asp:Label ID="lbFCLTotalRMB" runat="server" Text="0" />
                            人民币
                        </td>
                    </tr>
                    <tr>
                        <td class="tint">
                            备注：
                        </td>
                        <td align="left" colspan="7">
                            <asp:TextBox ID="tbFCLRemark" runat="server" CssClass="inputText" Text="" TextMode="MultiLine"
                                Height="121px" Width="713px" />
                        </td>
                    </tr>
                    <tr id="trCustmer" runat="server" visible="false">
                        <td class="tint">
                            客户提单情况：
                        </td>
                        <td align="left" colspan="7">
                            <asp:GridView ID="gvCustomerList" border="0" align="left" CellPadding="0" CellSpacing="0"
                                runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%" OnRowCommand="gvCustomerList_RowCommand"
                                CssClass="t">
                                <EmptyDataTemplate>
                                    <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="名称">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbName" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="运费">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbFee" runat="server" Text='<%#Eval("Fee")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="20gp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbgp20" runat="server" Text='<%#Eval("gp20")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="40gp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbgp40" runat="server" Text='<%#Eval("gp40")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="20dp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbdp20" runat="server" Text='<%#Eval("dp20")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="40dp">
                                        <ItemTemplate>
                                            <asp:TextBox CssClass="inputText" ID="tbdp40" runat="server" Text='<%#Eval("dp40")%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                                Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%#Eval("ID")%>' />
                                            <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                                Visible='<%# Eval("ID") == null?false:true%>' CommandArgument='<%#Eval("ID")%>'
                                                OnClientClick="return window.confirm('您真的要删除吗？')" />
                                            <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandName="btnAdd"
                                                Visible='<%# Eval("ID") == null?true:false%>' CommandArgument='<%# Container.DataItemIndex %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="tint">
                            主管：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFCLUser1" runat="server" CssClass="inputText" Text="" />
                        </td>
                        <td class="tint">
                            审核：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="tbFCLUser2" runat="server" CssClass="inputText" Text="" />
                        </td>
                        <td class="tint">
                            制表：
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="tbFCLUser3" runat="server" CssClass="inputText" Text="" />
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
    <div class="window" id="divOther" runat="server" visible="false">
        <div class="title BGx">
            <span>船舶载货其他收入情况登记</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass BGx">
                        船舶载货其他收入信息
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        币别：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCurrencyOther" runat="server" AutoPostBack="True" DataTextField="Name"
                            DataValueField="ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="tint">
                        收入金额：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherFee" runat="server" CssClass="inputText" Text="0" /><font
                            color="red"> 必须为数字</font>相当于
                        <asp:Label ID="lbOtherRMB" runat="server" CssClass="inputText" Text="0" />
                        人民币
                    </td>
                    <td class="tint">
                        收入项目：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherName" runat="server" CssClass="inputText" Text="" /><font
                            color="red"> 必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        收入说明：
                    </td>
                    <td align="left" colspan="7">
                        <asp:TextBox ID="tbRemark" TextMode="MultiLine" runat="server" CssClass="inputText"
                            Text="" Height="98px" Width="557px" />
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        主管：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherUser1" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        审核：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbOtherUser2" runat="server" CssClass="inputText" Text="" />
                    </td>
                    <td class="tint">
                        制表：
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="tbOtherUser3" runat="server" CssClass="inputText" Text="" />
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="6">
                        <asp:Button ID="btnOtherSave" runat="server" Text="保存" CssClass="btn" OnClientClick="return window.confirm('您真的要保存吗？')"
                            OnClick="btnOtherSave_Click" />
                        &nbsp;<asp:Button ID="btinOtherDel" runat="server" Text="删除" CssClass="btn" OnClientClick="return window.confirm('您真的要删除吗？')" />
                        &nbsp;
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

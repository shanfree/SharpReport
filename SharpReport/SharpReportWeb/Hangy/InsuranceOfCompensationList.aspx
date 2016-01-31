<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="InsuranceOfCompensationList.aspx.cs" Inherits="SharpReportWeb.Hangy.InsuranceOfCompensationList"
    Title="船舶保赔险" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>报告期选择</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td align="right" class="tint">
                        年份：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblYear" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblDim_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        月份：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblMoth" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblDim_SelectedIndexChanged"
                            AutoPostBack="true" DataTextField="Name" DataValueField="ID" RepeatLayout="Flow"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">一月</asp:ListItem>
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
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        船舶：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblShip" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblShip_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
            </table>
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>船舶保赔险统计总表</span>
        </div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="t">
                <tr>
                    <td colspan="11" align="left">
                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" OnClick="btnAdd_Click" />
                        &nbsp;<cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvList"
                            OnClick="ExcelGenButton1_Click" Text="生成Excel" FileName="货运险" CssClass="btn">
                        </cc1:ExcelGenButton>
                    </td>
                </tr>
                <tr>
                    <th>
                        船名
                    </th>
                    <th>
                        保险期限
                    </th>
                    <th>
                        主险保额
                    </th>
                    <th>
                        主险费率（含战争险）
                    </th>
                    <th>
                        主险保费
                    </th>
                    <%--<th>
                        战争保赔险费率
                    </th>
                    <th>
                        免赔额
                    </th>--%>
                    <th>
                        船舶险总保费
                    </th>
                    <th>
                        保赔险保单号
                    </th>
                    <th>
                        保险期限
                    </th>
                    <th>
                        保赔险费率（美元/吨）
                    </th>
                    <th>
                        保赔险保费
                    </th>
<%--                    <th>
                        币种
                    </th>
--%>                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rList" runat="server" OnItemCommand="rList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("ShipName")%>
                            </td>
                            <td>
                                <%#GetBeginDate(Eval("DimTimeID").ToString()) %>→<%# GetEndDate(Eval("DimTimeID").ToString())%>
                            </td>
                            <td>
                                <%#Eval("主险保额")%>
                            </td>
                            <td>
                                <%#Eval("主险费率")%>
                            </td>
                            <td>
                                <%#Eval("主险保费")%>
                            </td>
                            <%--<td>
                                <%#Eval("战争保赔险费率")%>
                            </td>
                            <td>
                                <%#Eval("免赔额")%>
                            </td>--%>
                            <td>
                                <%#Eval("船舶险总保费")%>
                            </td>
                            <td>
                                <%#Eval("保赔险保单号")%>
                            </td>
                            <td>
                                <%#DateTime.Parse(Eval("保险期限自").ToString()).ToString("yyyyMMddhh")%>→
                                <%#DateTime.Parse(Eval("保险期限到").ToString()).ToString("yyyyMMddhh")%>
                            </td>
                            <td>
                                <%#Eval("保赔险费率")%>
                            </td>
                            <td>
                                <%#Eval("保赔险保费")%>
                            </td>
                            <%--<td>
                                <%#Eval("CurrencyName") %>
                            </td>--%>
                            <td>
                                <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="编辑" CommandName="btnEdit"
                                    Visible="true" CommandArgument='<%# Eval("ID") %>' />
                                <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                    CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                                <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandName="btnAdd"
                                    CommandArgument='<%#Eval("DimTimeID")%>' Visible="false" />
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trNull" runat="server" visible="false">
                    <td colspan="15">
                        <font color="red">无符合要求的记录。</font>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        //全选或反选
        function Sel(ID) {
            oEl = event.srcElement;

            if (oEl.checked) {
                for (i = 0; i < document.all.length; i++) {
                    if (document.all(i).id.indexOf("rbSel") != -1) {
                        document.all(i).checked = false;
                        var trRow = document.all(i).parentElement.parentElement;
                        if (trRow != null) {
                            trRow.setAttribute("bgcolor", "#ffffff", 0);
                        }
                    }
                }
                oEl.checked = true;
                oEl.parentElement.parentElement.setAttribute("bgcolor", "#feeee0", 0);

                for (i = 0; i < document.all.length; i++) {
                    if (document.all(i).id.indexOf("lbID") != -1) {
                        document.all(i).value = ID;
                    }
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

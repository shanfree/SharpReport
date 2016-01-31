<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="InsuranceOfContainerList.aspx.cs" Inherits="SharpReportWeb.Hangy.InsuranceOfContainerList"
    Title="集装箱箱体保险情况表" %>

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
            </table>
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>集装箱箱体保险统计总表</span>
        </div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="t">
                <tr>
                    <td colspan="12" align="left">
                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" OnClick="btnAdd_Click" />
                        &nbsp;<cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvList"
                            OnClick="ExcelGenButton1_Click" Text="生成Excel" FileName="货运险" CssClass="btn">
                        </cc1:ExcelGenButton>
                    </td>
                </tr>
                <tr>
                    <th>
                        柜号起始字母
                    </th>
                    <th>
                        集装箱数量（20尺）
                    </th>
                    <th>
                        （40尺）
                    </th>
                    <th>
                        单价 （20尺）
                    </th>
                    <th>
                        （40尺）
                    </th>
                    <th>
                        保额
                    </th>
                    <th>
                        基本险 保险费率%
                    </th>
                    <th>
                        保险期限
                    </th>
                    <th>
                        保费
                    </th>
                    <th>
                        备注
                    </th>
                    <th>
                        币种
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rList" runat="server" OnItemCommand="rList_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("柜号起始字母")%>
                            </td>
                            <td>
                                <%#Eval("集装箱数量20")%>
                            </td>
                            <td>
                                <%#Eval("集装箱数量40")%>
                            </td>
                            <td>
                                <%#Eval("单价20")%>
                            </td>
                            <td>
                                <%#Eval("单价40")%>
                            </td>
                            <td>
                                <%#Eval("保额")%>
                            </td>
                            <td>
                                <%#Eval("基本险保险费率")%>
                            </td>
                            <td>
                                <%#GetBeginDate(Eval("DimTimeID").ToString()) %>→<%# GetEndDate(Eval("DimTimeID").ToString())%>
                            </td>
                            <td>
                                <%#Eval("保费")%>
                            </td>
                            <td>
                                <%#Eval("备注")%>
                            </td>
                            <td>
                                <%#Eval("CurrencyName") %>
                            </td>
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

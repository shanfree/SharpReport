<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="CertificateList.aspx.cs" Inherits="SharpReportWeb.Hangy.CertificateList"
    Title="福建东方海运公司及船舶许可证、营运证办理情况表" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>福建东方海运公司及船舶许可证、营运证办理情况表</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass">
                        报告期选择：<br />
                    </th>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        年份：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblYear" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblDim_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th colspan="4" class="mass">
                        福建东方海运公司及船舶许可证、营运证办理情况统计总表：<br />
                    </th>
                </tr>
                <tr>
                    <td colspan="4" align="left">
                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" OnClick="btnAdd_Click" />
                        &nbsp;<cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvList"
                            OnClick="ExcelGenButton1_Click" Text="生成Excel" FileName="福建东方海运公司及船舶许可证、营运证办理情况"
                            CssClass="btn"></cc1:ExcelGenButton>
                    </td>
                </tr>
                <tr>
                    <th colspan="4" align="left">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="t">
                            <tr>
                                <th>
                                    项目名称
                                </th>
                                <th>
                                    证书类型
                                </th>
                                <th>
                                    发证日期
                                </th>
                                <th>
                                    有效期至
                                </th>
                                <th>
                                    年审有效日期
                                </th>
                                <th>
                                    快递费
                                </th>
                                <th>
                                    图纸复印费
                                </th>
                                <th>
                                    洗照片
                                </th>
                                <th>
                                    公证
                                </th>
                                <th>
                                    其他
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
                                            <%#Eval("项目名称")%>
                                        </td>
                                        <td>
                                            <%# Eval("证书类型") == "1" ? "公司证书" : "船舶证书"%>
                                        </td>
                                        <td>
                                            <%#Eval("发证日期")%>
                                        </td>
                                        <td>
                                            <%#Eval("有效期至")%>
                                        </td>
                                        <td>
                                            <%#Eval("年审有效日期")%>
                                        </td>
                                        <td>
                                            <%#Eval("快递费")%>
                                        </td>
                                        <td>
                                            <%#Eval("图纸复印费")%>
                                        </td>
                                        <td>
                                            <%#Eval("洗照片")%>
                                        </td>
                                        <td>
                                            <%#Eval("公正")%>
                                        </td>
                                        <td>
                                            <%#Eval("其他")%>
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
                                <td colspan="13">
                                    <font color="red">无符合要求的记录。</font>
                                </td>
                            </tr>
                        </table>
                        <input id="lbID" type="hidden" name="lbID" runat="server" />
                    </th>
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

<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="Log.aspx.cs" Inherits="Admin_Log" Title="日志查看" EnableEventValidation="false" %>

<%@ Register Assembly="WFNetCtrl" Namespace="WFNetCtrl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="Server">
    <div class="adminTitle">
        日志查看</div>
    <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td valign="top" style="width: 120px">
                <div style="width: 100%; height: 800px; overflow: auto;">
                    日志类型:<br />
                    <asp:RadioButtonList ID="rblType" runat="server" OnSelectedIndexChanged="rblType_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:RadioButtonList>
                    <br />
                    日志来源:<br />
                    <asp:RadioButtonList ID="rblSource" runat="server" OnSelectedIndexChanged="rblSource_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem Value="2">其他</asp:ListItem>
                        <asp:ListItem Value="5">栏目管理</asp:ListItem>
                        <asp:ListItem Value="6">一般错误</asp:ListItem>
                        <asp:ListItem Value="7">联系人管理</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </td>
            <td style="border: none" valign="top">
                <table width="95%">
                    <tr>
                        <td colspan="2">
                            <div style="width: 100%; height: 400px; overflow: auto">
                                <asp:GridView ID="gvLogInfoList" runat="server" AutoGenerateColumns="False" Width="100%"
                                    OnRowDataBound="gvLogInfoList_RowDataBound" PageSize="10">
                                    <Columns>
                                        <asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                                            <ItemTemplate>
                                                <asp:RadioButton ID="rbSel" OnCheckedChanged="rbSel_CheckedChanged" runat="server"
                                                    AutoPostBack="true" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="日期和时间" DataField="Time" />
                                        <asp:BoundField HeaderText="信息摘要" DataField="Message" />
                                    </Columns>
                                    <RowStyle HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                                            无符合条件的记录</font>
                                    </EmptyDataTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" CssClass="Btn_bse75" GridViewID="gvLogInfoList"
                                OnClick="ExcelGenButton1_Click" Text="生成Excel" FileName="日志信息"></cc1:ExcelGenButton>
                        </td>
                        <td>
                            <cc1:DefaultPager ID="pGrid" runat="server" Align="Right" OnClick="pGrid_OnClick">
                            </cc1:DefaultPager>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%" valign="top">
                            详细:
                        </td>
                        <td>
                            <asp:TextBox ID="tbDetail" runat="server" Rows="20" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <input id="lbID" type="hidden" name="lbID" runat="server" />

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

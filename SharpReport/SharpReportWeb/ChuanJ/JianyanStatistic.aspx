<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="JianyanStatistic.aspx.cs" Inherits="SharpReportWeb.ChuanJ.JianyanStatistic"
    Title="检验报表统计" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>报告期选择：</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td align="right" class="tint">
                        年份：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblYear" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblYear_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        季度：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblQuarter" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblQuarter_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">一季度</asp:ListItem>
                            <asp:ListItem Value="2">二季度</asp:ListItem>
                            <asp:ListItem Value="3">三季度</asp:ListItem>
                            <asp:ListItem Value="4">四季度</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>检验报表统计</span></div>
        <div id="SlideBox">
            <div>
                <asp:GridView ID="gvJianyanList" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="t" PageSize="12">
                    <Columns>
                        <asp:BoundField HeaderText="船舶" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                        <asp:BoundField HeaderText="检验金额" DataField="总数" ItemStyle-Width="10%"></asp:BoundField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                            无符合条件的记录</font>
                    </EmptyDataTemplate>
                </asp:GridView>
                <input id="lbID" type="hidden" name="lbID" runat="server" />
                <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvJianyanList"
                    OnClick="ExcelGenButton1_Click" Text="生成Excel" FileName="日志信息" CssClass="btn">
                </cc1:ExcelGenButton>
                <asp:Button ID="btnView" runat="server" Text="查看报表构成" CssClass="btn" OnClick="btnView_Click" />
            </div>
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

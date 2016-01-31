<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="VoyageLoadStatistic.aspx.cs" Inherits="SharpReportWeb.Hangy.VoyageLoadStatistic"
    Title="船舶航次装箱情况汇总" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>船舶航次装箱情况汇总 </span>
        </div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass">
                        <asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" OnSelectedIndexChanged="rblType_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">按航次</asp:ListItem>
                            <asp:ListItem Value="1">按月份</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </th>
                </tr>
                <tr id="trQuery" runat="server">
                    <th colspan="4" align="left">
                        <asp:GridView ID="gvVoyageList" runat="server" AutoGenerateColumns="False" Width="100%"
                            CssClass="t" PageSize="12" HeaderStyle-Wrap="false">
                            <Columns>
                                <asp:BoundField HeaderText="船舶名称" DataField="ShipName" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField HeaderText="航次名称" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField HeaderText="散货" DataField="LCLAmount" NullDisplayText="--"></asp:BoundField>
                                <asp:BoundField HeaderText="20英寸柜（空）" DataField="TEUEmpty" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="20英寸柜（重）" DataField="TEUHeavy" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="40英寸柜（空）" DataField="FEUEmpty" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="40英寸柜（重）" DataField="FEUHeavy" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="45英寸柜（空）" DataField="FFEUEmpty" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="45英寸柜（重）" DataField="FFEUHeavy" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="特殊柜" DataField="Rest" NullDisplayText="--"></asp:BoundField>
                                <asp:BoundField HeaderText="相当于标准柜" DataField="EqualTo" NullDisplayText="--"></asp:BoundField>
                                <asp:BoundField HeaderText="合计" DataField="TOTAL" NullDisplayText="--"></asp:BoundField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                                    无符合条件的记录</font>
                            </EmptyDataTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:GridView>
                        <cc1:ExcelGenButton ID="eQuery" runat="server" GridViewID="gvVoyageList" OnClick="eQuery_Click"
                            Text="生成Excel" FileName="月份统计" CssClass="btn"></cc1:ExcelGenButton>
                    </th>
                </tr>
                <tr id="trStatistic" runat="server" visible="false">
                    <th colspan="4" align="left">
                        <asp:GridView ID="gvStatistic" runat="server" AutoGenerateColumns="False" Width="100%"
                            CssClass="t" PageSize="12" HeaderStyle-Wrap="false">
                            <Columns>
                                <asp:BoundField HeaderText="年份" DataField="Year"></asp:BoundField>
                                <asp:BoundField HeaderText="月份" DataField="MonthNumOfYear"></asp:BoundField>
                                <asp:BoundField HeaderText="散货" DataField="LCLAmount" NullDisplayText="--"></asp:BoundField>
                                <asp:BoundField HeaderText="20英寸柜（空）" DataField="TEUEmpty" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="20英寸柜（重）" DataField="TEUHeavy" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="40英寸柜（空）" DataField="FEUEmpty" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="40英寸柜（重）" DataField="FEUHeavy" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="45英寸柜（空）" DataField="FFEUEmpty" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="45英寸柜（重）" DataField="FFEUHeavy" NullDisplayText="--">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="特殊柜" DataField="Rest" NullDisplayText="--"></asp:BoundField>
                                <asp:BoundField HeaderText="相当于标准柜" DataField="EqualTo" NullDisplayText="--"></asp:BoundField>
                                <asp:BoundField HeaderText="合计" DataField="TOTAL" NullDisplayText="--"></asp:BoundField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                                    无符合条件的记录</font>
                            </EmptyDataTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:GridView>
                        <cc1:ExcelGenButton ID="eStatistic" runat="server" GridViewID="gvStatistic" OnClick="eStatistic_Click"
                            Text="生成Excel" FileName="月份统计" CssClass="btn"></cc1:ExcelGenButton>
                    </th>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass">
                        查询项信息
                    </th>
                </tr>
                <tr>
                    <td class="tint">
                        航次名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbVoyageName" runat="server" CssClass="inputText" />
                    </td>
                    <td class="tint">
                        航线名称：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlRouteName" runat="server" DataTextField="TotalRoute" DataValueField="ID">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <font color="red">航线未登记？请点击</font>
                        <asp:Button ID="btnRoute" runat="server" Text="编辑航线" CssClass="btn" OnClick="btnRoute_Click" /><font
                            color="red">跳转</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        开始时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbStartTime" runat="server">
                        </cc1:Calendar>
                    </td>
                    <td class="tint">
                        结束时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="tbEndTime" runat="server">
                        </cc1:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        船名：
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlShipName" runat="server" DataTextField="Name" DataValueField="ID"
                            AutoPostBack="True">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="btn" />
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

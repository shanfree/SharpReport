<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="MonthReport.aspx.cs" Inherits="SharpReportWeb.ChuanJ.MonthReport"
    Title="船舶燃料消耗统计报表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div id="SlideBox">
        <table border="0" cellpadding="0" cellspacing="0" class="form">
            <tr>
                <td align="center">
                    <h1>
                        <b>船舶燃料消耗统计报表</b></h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="left">
                                <h3>
                                    填报单位：福建东方海运有限公司</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvMonthlyReport" runat="server" OnRowCreated="gvMonthlyReport_RowCreated"
                                    AutoGenerateColumns="false" UseAccessibleHeader="false" HeaderStyle-BorderStyle="Solid"
                                    HeaderStyle-BorderWidth="1" CssClass="t">
                                    <Columns>
                                        <asp:BoundField DataField="serialNo" />
                                        <asp:BoundField DataField="shipName" />
                                        <asp:BoundField DataField="fujiGo" />
                                        <asp:BoundField DataField="fujiFo" />
                                        <asp:BoundField DataField="zhujiGo" />
                                        <asp:BoundField DataField="zhujiFo" />
                                        <asp:BoundField DataField="guoluGo" />
                                        <asp:BoundField DataField="guoluFo" />
                                        <asp:BoundField DataField="other" />
                                        <asp:BoundField DataField="sumup" />
                                        <asp:BoundField DataField="zhongYouBi" />
                                        <asp:BoundField DataField="fujiDay" />
                                        <asp:BoundField DataField="zhujiDay" />
                                        <asp:BoundField DataField="distance" />
                                        <asp:BoundField DataField="tonPerKilo" />
                                        <asp:BoundField DataField="fujiTonDay" />
                                        <asp:BoundField DataField="zhujiTonDay" />
                                        <asp:BoundField DataField="distanDay" />
                                        <asp:BoundField DataField="TonPerKilo2" />
                                        <asp:BoundField DataField="beginDate" />
                                        <asp:BoundField DataField="endDate" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <h5>
                                    负责部门:船技部</h5>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <h5>
                                    注:现我司自营船舶:东方盛,榕峰。其他均出租燃油使用租家的。</h5>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <h5>
                                    联系电话:87628917</h5>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <h1>
                        <b>报表查询</b></h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td class="tint">
                                年份：
                            </td>
                            <td>
                                <asp:DropDownList ID="qYear" runat="server" />
                            </td>
                            <td class="tint">
                                月份：
                            </td>
                            <td>
                                <asp:DropDownList ID="qMonth" runat="server">
                                    <asp:ListItem Value="01" Text="1" Selected="True" />
                                    <asp:ListItem Value="02" Text="2" />
                                    <asp:ListItem Value="03" Text="3" />
                                    <asp:ListItem Value="04" Text="4" />
                                    <asp:ListItem Value="05" Text="5" />
                                    <asp:ListItem Value="06" Text="6" />
                                    <asp:ListItem Value="07" Text="7" />
                                    <asp:ListItem Value="08" Text="8" />
                                    <asp:ListItem Value="09" Text="9" />
                                    <asp:ListItem Value="10" Text="10" />
                                    <asp:ListItem Value="11" Text="11" />
                                    <asp:ListItem Value="12" Text="12" />
                                </asp:DropDownList>
                            </td>
                            <td class="tint">
                                <b><asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="查询" OnClick="btnSearch_Click"/> </b>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

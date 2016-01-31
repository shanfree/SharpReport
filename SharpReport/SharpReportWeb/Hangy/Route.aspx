<%@ Page Title="航线列表" Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="Route.aspx.cs" Inherits="SharpReportWeb.RouteManager" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>航线列表</span></div>
        <div id="SlideBox">
            <asp:GridView ID="gvRouteList" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="0" CssClass="t" Width="100%" PageSize="15" OnRowDataBound="gvRouteList_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:RadioButton ID="rbSel" OnCheckedChanged="rbSel_RouteCheckedChanged" runat="server"
                                AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="航线名称" DataField="RouteName"></asp:BoundField>
                    <asp:BoundField HeaderText="出发港" DataField="StartPortName" ItemStyle-Width="10%">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="经停港1" DataField="PassPortName1" ItemStyle-Width="10%">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="经停港2" DataField="PassPortName2" ItemStyle-Width="10%">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="经停港3" DataField="PassPortName3" ItemStyle-Width="10%">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="目的港" DataField="EndPortName" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="总里程" DataField="Distance" ItemStyle-Width="10%"></asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
            <cc1:DefaultPager ID="pGrid" runat="server" Align="Right" OnClick="pGrid_OnClick"
                PageSize="15" />
            <input id="lbID" type="hidden" name="lbID" runat="server" />
            <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvRouteList"
                OnClick="ExcelGenButton1_Click" Text="生成Excel" FileName="航线列表" CssClass="btn">
            </cc1:ExcelGenButton>
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>航线信息登记</span>
        </div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        航线名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbRouteName" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        航程（单位：海里）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDistance" runat="server" CssClass="inputText" />
                        <font color="red">必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        出发港：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlStartPort" runat="server" DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <span class="tips">* 必选</span>
                    </td>
                    <td class="tint">
                        目的港：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlEndPort" runat="server" DataTextField="Name" DataValueField="ID">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <span class="tips">* 必选</span>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        航线说明：
                    </td>
                    <td align="left" colspan="3">
                        <asp:Label ID="lbTotalRoute" runat="server" Text="-无-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        经停港：
                    </td>
                    <td align="left" colspan="3">
                        <asp:GridView ID="gvPassedPorts" border="0" align="left" CellPadding="0" CellSpacing="0"
                            runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%" OnRowCommand="gvPassedPorts_RowCommand"
                            OnRowDataBound="gvPassedPortst_RowDataBound" CssClass="t">
                            <EmptyDataTemplate>
                                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="名称">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPassPort" runat="server" DataTextField="Name" DataValueField="ID">
                                            <asp:ListItem Value="0">请选择</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:HiddenField runat="server" ID="hidTxt" Value='<%#Eval("PortID")%>' />
                                        <asp:HiddenField runat="server" ID="hidName" Value='<%#Eval("PortName")%>' />
                                        <asp:HiddenField runat="server" ID="hidRelateId" Value='<%#Eval("relateId")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="排序号">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="inputText" ID="tbOrderNum" runat="server" Text='<%#Eval("OrderNum")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                            Visible="true" CommandArgument='<%# Container.DataItemIndex %>' />
                                        <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                            CommandArgument='<%#Eval("relateId")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                                        <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandName="btnAdd"
                                            Visible="false" CommandArgument='<%# Container.DataItemIndex %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnAddRoute" runat="server" Text="新增" CssClass="btn" OnClick="btnAddRoute_Click" />
                        &nbsp;<asp:Button ID="btnSaveRoute" runat="server" Text="保存" CssClass="btn" OnClick="btnSaveRoute_Click" />
                        &nbsp;<asp:Button ID="btnDelRoute" runat="server" Text="删除" CssClass="btn" OnClick="btnDelRoute_Click"
                            OnClientClick="return window.confirm('您真的要删除吗？')" />
                        &nbsp;<asp:Button ID="btnHangci" runat="server" Text="编辑航次" CssClass="btn" OnClick="btnHangci_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
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

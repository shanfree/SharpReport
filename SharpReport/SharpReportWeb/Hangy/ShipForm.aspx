<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="ShipForm.aspx.cs" Inherits="SharpReportWeb.Hangy.ShipForm" Title="船舶信息维护" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>船舶列表</span></div>
        <div class="SlideBox">
            <!--滚动必须-->
            <asp:GridView ID="gvShipList" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="0" CssClass="t" Width="100%" PageSize="15" OnRowCommand="gvShipList_RowCommand"
                OnRowDataBound="gvShipList_RowDataBound">
                <Columns>
                    <%--<asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSel" runat="server" AutoPostBack="false" />
                                <asp:HiddenField runat="server" ID="hidShipId" Value='<%#Eval("ID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="船名" DataField="Name" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="编号" DataField="Code" ItemStyle-Width="10%"></asp:BoundField>
                    <asp:BoundField HeaderText="船长" DataField="Captain"></asp:BoundField>
                    <asp:BoundField HeaderText="轮机长" DataField="ChiefEngineer"></asp:BoundField>
                    <asp:BoundField HeaderText="机务主管" DataField="GeneralManager"></asp:BoundField>
                    <asp:TemplateField HeaderText="船舶装箱类型">
                        <ItemTemplate>
                            <asp:Label ID="tbLoadType" runat="server" Text="未定义"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="船舶所有类型">
                        <ItemTemplate>
                            <asp:Label ID="tbOperationType" runat="server" Text="未定义"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Button ID="btnEditShip" CssClass="btn" runat="server" Text="编辑" CommandName="btnEditShip"
                                Visible="true" CommandArgument='<%#Eval("ID")%>' />
                            <asp:Button ID="btnDelShip" CssClass="btn" runat="server" Text="禁用" CommandName="btnDelShip"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要禁用该船舶吗？')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
            </asp:GridView>
            <input id="lbID2" type="hidden" name="lbID2" runat="server" />
        </div>
        <div class="toolbar">
            <!--翻页-->
            <cc1:DefaultPager ID="pGridV" runat="server" Align="Right" OnClick="pGridV_OnClick"
                PageSize="15" />
            <cc1:ExcelGenButton ID="ExcelGenButton2" runat="server" GridViewID="gvShipList" OnClick="ExcelGenButton2_Click"
                Text="生成Excel" FileName="船舶列表" CssClass="btn"></cc1:ExcelGenButton>
            &nbsp;<asp:Button ID="btnAddShip" runat="server" Text="新增船舶" CssClass="btn" OnClick="btnAddShip_Click" />
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>船舶参数和使用情况</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td class="tint">
                        船舶名称：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbName" runat="server" CssClass="inputText" /><font color="red"> 必填</font>
                    </td>
                    <td class="tint">
                        船舶编号：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbCode" runat="server" CssClass="inputText" /><font color="red"> 必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint" style="height: 37px">
                        船长：
                    </td>
                    <td align="left" colspan="3" style="height: 37px">
                        <asp:TextBox ID="tbCaptain" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        轮机长：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbChiefEngineer" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                    <td class="tint">
                        机务主管：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbGeneralManager" runat="server" CssClass="inputText" /><font color="red">
                            必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        建造时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="cBuild" runat="server"></cc1:Calendar>
                        <font color="red">必填</font>
                    </td>
                    <td class="tint">
                        购入时间：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="cBuy" runat="server"></cc1:Calendar>
                        <font color="red">必填</font>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        吨位（吨）：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbTon" runat="server" CssClass="inputText" /><font color="red"> 必填，必须为数字，如1000.5</font>
                    </td>
                    <td class="tint">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        船舶所有类型：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblOperationType" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="自营 " Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="租赁" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="tint">
                        租用期限到（自营船舶无需填写）：
                    </td>
                    <td align="left">
                        <cc1:Calendar ID="cRentDate" runat="server"></cc1:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="tint">
                        船舶装箱类型：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblLoadType" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="集装箱 " Value="2" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="散货" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="tint">
                        船舶状态：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblEnable" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="启用 " Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="停用" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="4">
                        <asp:Button ID="btnSaveShip" runat="server" Text="保存" CssClass="btn" OnClick="btnSaveShip_Click"
                            OnClientClick="return window.confirm('您真的要保存吗？')" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

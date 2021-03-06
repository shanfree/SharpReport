﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="UserManage.aspx.cs" Inherits="SharpReportWeb.Admin.UserManage" Title="用户管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>用户管理</span></div>
        <div id="SlideBox">
            <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="gvUserList_RowDataBound" CssClass="t">
                <Columns>
                    <asp:TemplateField HeaderText="选择" ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:RadioButton ID="rbSel" OnCheckedChanged="rbSel_CheckedChanged" runat="server"
                                AutoPostBack="true" />
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户名" DataField="Name" />
                    <asp:BoundField HeaderText="部门" DataField="DepartmentName" />
                    <asp:BoundField HeaderText="最后登录时间" DataField="LastLoginDate" />
                    <asp:BoundField HeaderText="注册时间" DataField="CreateDate" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
            <input id="lbID" type="hidden" name="lbID" runat="server" />
            <div style="padding-left: 12px; padding-top: 6px; padding-bottom: 6px;" runat="server"
                id="divUser" visible="false">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                    <tr>
                        <td align="right" class="tint">
                            用户名称：
                        </td>
                        <td align="left">
                            <asp:TextBox CssClass="inputText" ID="tbName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="tint">
                            用户密码：
                        </td>
                        <td align="left">
                            <asp:TextBox CssClass="inputText" ID="tbPws" runat="server" TextMode="Password" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="tint">
                            确认密码：
                        </td>
                        <td align="left">
                            <asp:TextBox CssClass="inputText" ID="tbComfirm" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="tint">
                            用户部门：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="FullName" DataValueField="ID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                                        <tr>
                        <td align="right" class="tint">
                            用户角色：
                        </td>
                        <td align="left">
                                <asp:CheckBoxList ID="cblRoles" runat="server" DataTextField="Name" DataValueField="ID">
                                </asp:CheckBoxList>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" Text="保存" />
                            <asp:Button ID="btnDel" runat="server" CssClass="btn" OnClick="btnDel_Click" Text="删除" />
                            <asp:Button ID="btnRole" runat="server" CssClass="btn" OnClick="btnRole_Click" Text="绑定角色" />
                        </td>
                    </tr>
                </table>
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

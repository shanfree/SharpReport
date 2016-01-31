<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="SharpReportWeb.Admin.Register" Title="用户注册" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>用户注册</span></div>
    <div id="SlideBox">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
            <tr>
                <td align="right" class="tint">
                    用户名称：
                </td>
                <td>
                    <asp:TextBox CssClass="inputText" ID="tbName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="tint">
                    用户密码：
                </td>
                <td>
                    <asp:TextBox CssClass="inputText" ID="tbPws" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td align="right" class="tint">
                    确认密码：
                </td>
                <td>
                    <asp:TextBox CssClass="inputText" ID="tbComfirm" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="tint">
                    用户部门：
                </td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="FullName" DataValueField="ID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="添加" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>

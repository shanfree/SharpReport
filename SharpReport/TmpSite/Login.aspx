<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Admin_Login" Title="管理登陆" %>

<asp:Content ID="View" runat="server" ContentPlaceHolderID="cphTop">
    <div style="padding: 12px; margin-bottom: 9px; border: 1px solid #93CEBD;">
        <table border="0" cellpadding="0" cellspacing="0" style="margin: 0 auto; border: 1px solid #93CEBD;">
            <tr>
                <td colspan="2" class="loginTitle" style="font-weight: bold; padding: 6px 6px;">
                    管理登陆
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;&nbsp;管理帐号：
                </td>
                <td style="padding-top: 6px;">
                    <asp:TextBox ID="tbName" runat="server" />&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;&nbsp;管理密码：
                </td>
                <td style="padding-top: 1px;">
                    <asp:TextBox ID="tbPwd" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;&nbsp;验证码：
                </td>
                <td style="padding-top: 1px;">
                    <asp:TextBox ID="tbCode" runat="server" Columns="4" MaxLength="4" />
                    &nbsp;<img src="Admin/Validata.aspx" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; padding: 6px 6px;">
                    <asp:Button ID="btnLogin" runat="server" Text="登陆" OnClick="btnLogin_Click" /><input
                        id="Reset1" type="reset" value="重置" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

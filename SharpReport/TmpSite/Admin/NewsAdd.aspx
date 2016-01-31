<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="NewsAdd.aspx.cs" Inherits="Admin_NewsAdd" Title="添加新闻" %>

<%@ Register Src="../WUC/DropdownTree.ascx" TagName="DropdownTree" TagPrefix="uc2" %>
<asp:Content ID="EditNews" ContentPlaceHolderID="Conut1" runat="server">
    <div class="adminTitle">
        添加新闻</div>
    <table border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 12px;">
        <tr>
            <td align="left" width="15%">
                新闻标题:
            </td>
            <td align="left">
                <asp:TextBox ID="tbTitle" runat="server" MaxLength="50" TextMode="SingleLine" Columns="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                新闻分类:
            </td>
            <td align="left">
                <uc2:DropdownTree ID="dtMenu" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                新闻来源:
            </td>
            <td align="left" style="padding-bottom: 12px;">
                <asp:TextBox ID="tbSource" runat="server">本网讯</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                新闻摘要:
            </td>
            <td align="left" style="padding-bottom: 12px;">
                <div style="color: Red">
                    图片新闻摘要信息（100字以内）<input id="btnBrowse" type="reset" value="浏览" runat="server" visible="false" /></div>
                <asp:TextBox ID="tbSummary" runat="server" MaxLength="100" TextMode="MultiLine" Columns="50"
                    Rows="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="450" Width="620">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" height="25" style="padding: 6px 0;">
                <asp:Button ID="btnNewsAdd" runat="server" Text="更新" OnClick="btnNewsAdd_Click" />
                <input id="Reset1" type="reset" value="取消" onclick="history.go(-1);" />
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="PicNewsManage.aspx.cs" Inherits="Admin_PicNewsManage" Title="图片新闻管理" %>

<%@ Register Assembly="WFNetCtrl" Namespace="WFNetCtrl" TagPrefix="cc1" %>
<%@ Register Src="../WUC/DropdownTree.ascx" TagName="DropdownTree" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="Server">
    <div class="adminTitle">
        图片新闻管理</div>
    <table border="0" cellspacing="0" cellpadding="0" align="center" width="680">
        <tr>
            <td align="left" colspan="4">
                图片新闻只收录“新闻动态”栏目的新闻，可勾选任意5条以内的新闻发布到首页。<br />
                新闻内容的第一张图片将作为新闻的超链接显示。
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="padding: 12px 0;">
                文章标题：<asp:TextBox ID="tbTitle" runat="server"></asp:TextBox><asp:Button ID="btQuery"
                    runat="server" Text="查询" OnClick="btQuery_Click" /><asp:Button ID="btnAll" runat="server"
                        Text="全部" OnClick="btnAll_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowDataBound="gvList_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="选择" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSel" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40%"
                            ItemStyle-Wrap="true" HeaderText="标题">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Wrap="True" Width="40%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="170" DataField="CreateTime"
                            HeaderText="时间">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="170px"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30" NavigateUrl="~/Browse.aspx"
                            Text="查看" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Browse.aspx?id={0}"
                            Target="_blank">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="30px"></ItemStyle>
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Button ID="btnGen" runat="server" Text="生成" OnClick="btnGen_Click" />
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" align="center" width="680">
        <tr>
            <td>
                <asp:GridView ID="gvSelect" runat="server" AutoGenerateColumns="False" Width="100%"
                    Visible="false" onrowcommand="gvSelect_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="排序" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnUp" runat="server" Text="↑" CommandName="Up"></asp:Button>
                                <asp:Button ID="btnDown" runat="server" Text="↓" CommandName="Down"></asp:Button>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40%"
                            ItemStyle-Wrap="true" HeaderText="标题">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Wrap="True" Width="40%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="170" DataField="Summary"
                            HeaderText="简介">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="170px"></ItemStyle>
                        </asp:BoundField>
                        <asp:HyperLinkField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30" Text="查看"
                            DataNavigateUrlFields="Url" Target="_blank">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle Width="30px"></ItemStyle>
                        </asp:HyperLinkField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

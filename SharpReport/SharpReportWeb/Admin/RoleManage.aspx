<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="RoleManage.aspx.cs" Inherits="SharpReportWeb.Admin.RoleManage" Title="角色管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>角色管理</span></div>
        <div id="SlideBox">
            <asp:GridView ID="gvRoleList" border="0" align="center" CellPadding="0" CellSpacing="0"
                runat="server" AutoGenerateColumns="False" PageSize="15" Width="95%" OnRowCommand="gvRoleList_RowCommand"
                OnRowDataBound="gvRoleList_RowDataBound" CssClass="t">
                <EmptyDataTemplate>
                    <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="角色">
                        <ItemTemplate>
                            <asp:TextBox CssClass="inputText" ID="tbName" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <ItemTemplate>
                            <asp:TextBox CssClass="inputText" ID="tbRemark" runat="server" Text='<%#Eval("Remark")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-Width="140px">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="保存" CommandName="btnEdit"
                                Visible="true" CommandArgument='<%# Container.DataItemIndex %>' />
                            <asp:Button ID="btnDel" CssClass="btn" runat="server" Text="删除" CommandName="btnDel"
                                CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                            <asp:Button ID="btnAdd" CssClass="btn" runat="server" Text="新增" CommandName="btnAdd"
                                Visible="false" CommandArgument='<%# Container.DataItemIndex %>' />
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

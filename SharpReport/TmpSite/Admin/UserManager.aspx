<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="UserManager.aspx.cs" Inherits="Admin_UserManager" Title="管理用户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="Server">
    <div class="adminTitle">
        用户管理</div>
    <div style="padding-bottom: 12px;">
        <asp:GridView ID="gvUserList" border="0" align="center" CellPadding="0" CellSpacing="0"
            runat="server" AutoGenerateColumns="False" PageSize="15" Width="95%" OnRowCommand="gvUserList_RowCommand"
            CssClass="usersList" OnRowDataBound="gvUserList_RowDataBound">
            <EmptyDataTemplate>
                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
            </EmptyDataTemplate>
            <RowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="帐户">
                    <ItemTemplate>
                        <asp:TextBox ID="tbName" runat="server" Text='<%#Eval("Name")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPwd" runat="server" Text='<%#Eval("Password")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="创建时间">
                    <ItemTemplate>
                        <asp:TextBox ID="tbTime" runat="server" Text='<%#Eval("Time")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" ItemStyle-Width="140px">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="保存" CommandName="btnEdit" Visible="true"
                            CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:Button ID="btnDel" runat="server" Text="删除" CommandName="btnDel" CommandArgument='<%#Eval("ID")%>'
                            OnClientClick="return window.confirm('您真的要删除吗？')" />
                        <asp:Button ID="btnAdd" runat="server" Text="新增" CommandName="btnAdd" Visible="false"
                            CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

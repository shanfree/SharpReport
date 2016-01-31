<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true"
    CodeBehind="MenuMange.aspx.cs" Inherits="SharpReportWeb.Admin.MenuMange" Title="栏目管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>栏目管理</span></div>
        <div id="SlideBox">
            <div style="float: left;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" valign="top">
                            <div style="float: left; background-color: #E0E0E0; width: 200px;">
                                <asp:TreeView ID="tMenus" runat="server" NodeIndent="10" OnSelectedNodeChanged="tMenus_SelectedNodeChanged"
                                    ExpandDepth="3">
                                </asp:TreeView>
                            </div>
                        </td>
                        <td align="left" valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                                <tr>
                                    <th class="tint" style="width: 15%">
                                        名&nbsp;&nbsp;&nbsp;&nbsp;称：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbName" runat="server" CssClass="inputText"></asp:TextBox>
                                    </td>
                                    <th class="tint" style="width: 15%">
                                        栏目编号：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbSortNum" runat="server" CssClass="inputText"></asp:TextBox><span
                                            class="tips">* 请按规则输入数字</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        连接地址：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="tbURL" runat="server" CssClass="inputText" Width="300"></asp:TextBox>
                                    </td>
                                    <th class="tint">
                                        打开栏目时的对象框架：
                                    </th>
                                    <td>
                                        <asp:RadioButtonList ID="rblExtend" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Selected="True" Value="_self">_self</asp:ListItem>
                                            <asp:ListItem Value="_blank">_blank</asp:ListItem>
                                            <asp:ListItem Value="_target">_target</asp:ListItem>
                                            <asp:ListItem Value="_parent">_parent</asp:ListItem>
                                            <asp:ListItem Value="_top">_top</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        备注：
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" TextMode="MultiLine"
                                            Height="57px" Width="288px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="4" align="center">
                                        <div>
                                            <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn" OnClick="btnSubmit_Click"
                                                Visible="false" OnClientClick="if(window.confirm('您确认要修改栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                                                UseSubmitBehavior="false" />
                                            &nbsp;<asp:Button ID="btnAdd" runat="server" Text="添加同级栏目" CssClass="btn" OnClick="btnAdd_Click"
                                                Visible="false" OnClientClick="if(window.confirm('您确认要添加同级栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                                                UseSubmitBehavior="false" />
                                            &nbsp;<asp:Button ID="btnSub" runat="server" Text="添加子栏目" CssClass="btn" OnClick="btnSub_Click"
                                                Visible="false" OnClientClick="if(window.confirm('您确认要添加子栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                                                UseSubmitBehavior="false" />
                                            &nbsp;<asp:Button ID="btnDel" runat="server" Text="删除栏目" CssClass="btn" OnClick="btnDel_Click"
                                                Visible="false" OnClientClick="if(window.confirm('您确认要删除栏目吗？栏目所属的文章将一并删除。')){this.disabled=true;this.form.submit();}else{return false;}"
                                                UseSubmitBehavior="false" />
                                        </div>
                                    </th>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        权限组：
                                    </th>
                                    <td>
                                        <asp:RadioButtonList ID="rblPower" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                            DataTextField="Name" DataValueField="ID" RepeatColumns="4">
                                        </asp:RadioButtonList>
                                        <asp:Button ID="btnPowerBind" runat="server" Text="绑定该权限组" CssClass="btn" OnClick="btnPowerBind_Click"
                                            OnClientClick="if(window.confirm('您确认要绑定该权限组吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                                            UseSubmitBehavior="false" /><span class="tips">*请先为栏目绑定权限组再添加角色。</span>
                                    </td>
                                    <th class="tint">
                                        角色：
                                    </th>
                                    <td>
                                        <asp:CheckBoxList ID="cblRole" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                            DataTextField="Name" DataValueField="ID" RepeatColumns="4">
                                        </asp:CheckBoxList>
                                        <asp:Button ID="btnRoleBind" runat="server" Text="绑定角色" CssClass="btn" Visible="false"
                                            OnClientClick="if(window.confirm('您确认要绑定上述角色到当前栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                                            UseSubmitBehavior="false" OnClick="btnRoleBind_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="tint">
                                        栏目绑定的角色和权限：
                                    </th>
                                    <td colspan="3">
                                        <asp:GridView ID="gvRoleList"  CellPadding="0" CellSpacing="0"
                                            runat="server" AutoGenerateColumns="False" PageSize="15" Width="95%" OnRowCommand="gvRoleList_RowCommand"
                                            OnRowDataBound="gvRoleList_RowDataBound" CssClass="t">
                                            <EmptyDataTemplate>
                                                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
                                            </EmptyDataTemplate>
                                            <RowStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="角色">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="权限">
                                                    <ItemTemplate>
                                                        <asp:CheckBoxList ID="cblPermission" runat="server" RepeatDirection="Horizontal"
                                                            RepeatLayout="Flow" DataTextField="Name" DataValueField="ID">
                                                        </asp:CheckBoxList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="操作" ItemStyle-Width="140px">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" runat="server" Text="保存" CommandName="btnEdit" Visible="true" CssClass="btn"
                                                            CommandArgument='<%# Container.DataItemIndex %>' />
                                                        <asp:Button ID="btnDel" runat="server" Text="删除" CommandName="btnDel" CommandArgument='<%#Eval("ID")%>'
                                                            OnClientClick="return window.confirm('您真的要删除吗？')" CssClass="btn"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

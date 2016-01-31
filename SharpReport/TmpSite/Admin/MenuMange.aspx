<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="MenuMange.aspx.cs" Inherits="Admin_MenuMange" Title="分类管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="Server">
    <div class="adminTitle">
        分类管理</div>
    <div style="float: left; background-color: #E0E0E0; width: 200px;">
        <asp:TreeView ID="tMenus" runat="server" CssClass="TableNoborder01" NodeIndent="10"
            OnSelectedNodeChanged="tMenus_SelectedNodeChanged" ExpandDepth="0">
        </asp:TreeView>
        <div class="br">
            <!--留空，勿删-->
        </div>
    </div>
    <div style="width: 400px; padding-left: 12px;">
        当前栏目：
        <asp:Label ID="lbName" runat="server"></asp:Label>
        <br />
        名&nbsp;&nbsp;&nbsp;&nbsp;称：
        <asp:TextBox ID="tbName" runat="server" CssClass="input12"></asp:TextBox>
        <br />
        排&nbsp;序&nbsp;号：
        <asp:TextBox ID="tbSortNum" runat="server" CssClass="input12"></asp:TextBox>
        请输入数字<br />
        连接地址：
        <asp:TextBox ID="tbURL" runat="server" CssClass="input12" Width="300"></asp:TextBox>
        <br />
        是否显示在主页：
        <asp:RadioButtonList ID="rblIsShow" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        是否为网站外部链接：
        <asp:RadioButtonList ID="rblExtend" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        是否显示在新闻栏目：
        <asp:RadioButtonList ID="rblNews" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
        </asp:RadioButtonList>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="Btn_bse75" OnClick="btnSubmit_Click"
                Visible="false" OnClientClick="if(window.confirm('您确认要修改栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                UseSubmitBehavior="false" />
            <asp:Button ID="btnAdd" runat="server" Text="添加同级栏目" CssClass="Btn_bse75" OnClick="btnAdd_Click"
                Visible="false" OnClientClick="if(window.confirm('您确认要添加同级栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                UseSubmitBehavior="false" />
            <asp:Button ID="btnSub" runat="server" Text="添加子栏目" CssClass="Btn_bse75" OnClick="btnSub_Click"
                Visible="false" OnClientClick="if(window.confirm('您确认要添加子栏目吗？')){this.disabled=true;this.form.submit();}else{return false;}"
                UseSubmitBehavior="false" />
            <asp:Button ID="btnDel" runat="server" Text="删除栏目" CssClass="Btn_bse75" OnClick="btnDel_Click"
                Visible="false" OnClientClick="if(window.confirm('您确认要删除栏目吗？栏目所属的文章将一并删除。')){this.disabled=true;this.form.submit();}else{return false;}"
                UseSubmitBehavior="false" />
        </div>
    </div>
    <div class="br">
        <!--留空，勿删-->
    </div>
</asp:Content>

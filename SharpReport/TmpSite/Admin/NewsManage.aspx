<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="NewsManage.aspx.cs" Inherits="Admin_NewsManage" Title="新闻管理" %>

<%@ Register Assembly="WFNetCtrl" Namespace="WFNetCtrl" TagPrefix="cc1" %>
<%@ Register Src="../WUC/DropdownTree.ascx" TagName="DropdownTree" TagPrefix="uc2" %>
<asp:Content ID="AdminNews" ContentPlaceHolderID="Conut1" runat="server">
  <style type="text/css">
.newsList {
	margin-top: 12px;
	border-top:1px solid #E0E0E0;
	border-left:1px solid #E0E0E0;
}
.newsList td {
	border-right: 1px solid #CCC;
	border-bottom: 1px solid #CCC;
}
</style> 
  <div class="adminTitle">新闻管理</div>
  <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center" style="margin-top:12px;">
    <tr>
      <td><table border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td>&nbsp;文章标题：<asp:TextBox ID="tbTitle" runat="server"></asp:TextBox></td>
            <td>&nbsp;栏目：</td>
            <td><uc2:DropdownTree ID="dtMenu" runat="server" /></td>
            <td><asp:Button ID="btQuery" runat="server" Text="查询" OnClick="btQuery_Click" /><asp:Button ID="btnAll" runat="server" Text="全部" OnClick="btnAll_Click" /></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table border="0" cellspacing="0" cellpadding="0" align="center" Width="95%" class="newsList">
    <tr>
      <td align="center" height="25" width="40%" colspan="2"> 新闻名称 </td>
      <td align="center"> 分类 </td>
      <td align="center"> 查看 </td>
      <td align="center" width="170"> 添加时间 </td>
      <td align="center" width="100"> 操作 </td>
    </tr>
    <asp:Repeater ID="rList" runat="server">
      <ItemTemplate>
        <tr>
          <td align="left" height="25" colspan="2">&nbsp;&nbsp;<a href="../Browse.aspx?id=<%#Eval("id") %>" target="_blank"><%#Eval("Title") %></a></td>
          <td align="center"><%#Eval("MenuName")%></td>
          <td align="center" style="width: 30px"><a href="../Browse.aspx?id=<%#Eval("ID") %>" target="_blank">查看</a></td>
          <td align="center"><%#Eval("CreateTime") %></td>
          <td align="center"><a href="NewsAdd.aspx?id=<%#Eval("ID") %>">编辑</a>
            <asp:LinkButton ID="LinkButton1" CommandName='<%#Eval("id") %>' OnCommand="DelComm_Click"
                            OnClientClick="return confirm('确定要删除吗?');" runat="server">删除</asp:LinkButton></td>
        </tr>
      </ItemTemplate>
    </asp:Repeater>
  </table>
  <table border="0" align="center" cellspacing="0">
    <tr>
      <td align="right"><cc1:DefaultPager ID="pGrid" runat="server" ImgPath="Images/Toolbar" Align="Right"
                    OnClick="pGrid_OnClick" /></td>
    </tr>
  </table>
</asp:Content>

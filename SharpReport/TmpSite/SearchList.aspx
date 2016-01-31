<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true"
    CodeFile="SearchList.aspx.cs" Inherits="SearchList" Title="搜索结果" %>

<%@ Register Assembly="WFNetCtrl" Namespace="WFNetCtrl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="Server">
    <div id="mainBox">
        <div id="column_04">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                PageSize="12" BorderStyle="None" RowStyle-BorderStyle="None" Style="border: none">
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="Browse.aspx?ID=<%# Eval("ID") %>" title='<%# Eval("Title") %>' target="_blank">
                                <img src="Images/icon_03.gif" />
                                <%# DataBinder.Eval(Container.DataItem, "Title")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <cc1:DefaultPager ID="pGrid" runat="server" ImgPath="Images/Toolbar" Align="Right"
                PageSize="12" OnClick="pGrid_OnClick" />
            <div class="br">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="Server">
</asp:Content>

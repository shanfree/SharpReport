<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse"
    MasterPageFile="~/MasterPage/Default.master" %>

<%@ Register Src="WUC/RecentNews.ascx" TagName="RecentNews" TagPrefix="uc1" %>
<%@ Register Src="WUC/Notice.ascx" TagName="Notice" TagPrefix="uc2" %>
<asp:Content ID="View" runat="server" ContentPlaceHolderID="cphTop">
    <div id="mainBox">
        <div id="column_06">
            <div class="s_Matter">
                <table border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td align="center" height="40" class="View1">
                            <asp:Label ID="lbTitle" runat="server" />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="Login2" height="25">
                            <asp:Label ID="lbFrom" runat="server" />
                            &nbsp;
                            <asp:Label ID="lbTime" runat="server" />
                            &nbsp;
                            <asp:Label ID="lbClick" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="View2">
                            <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
                                <tr>
                                    <td>
                                        <asp:Literal ID="lbContent" runat="server"  />
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

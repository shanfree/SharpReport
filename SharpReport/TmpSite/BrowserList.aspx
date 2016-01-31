<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowserList.aspx.cs" Inherits="BrowserList"
    MasterPageFile="~/MasterPage/Default.master" %>

<%@ Register Src="WUC/RecentNews.ascx" TagName="RecentNews" TagPrefix="uc1" %>
<%@ Register Src="WUC/Notice.ascx" TagName="Notice" TagPrefix="uc2" %>
<%@ Register Src="WUC/MenuDetail.ascx" TagName="MenuDetail" TagPrefix="uc3" %>
<asp:Content ID="View" runat="server" ContentPlaceHolderID="cphTop">
    <div id="mainBox">
        <div id="column_02">
        </div>
        <div id="column_04">
            <uc3:MenuDetail ID="nlMenuNews" runat="server" />
        </div>
    </div>
</asp:Content>

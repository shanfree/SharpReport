<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState="false"
    MasterPageFile="~/MasterPage/Default.master" %>

<%@ Register Src="WUC/NewsList.ascx" TagName="NewsList" TagPrefix="uc1" %>
<%@ Register Src="WUC/IconShortCut.ascx" TagName="IconShortCut" TagPrefix="uc2" %>
<%@ Register Src="WUC/PicNews.ascx" TagName="PicNews" TagPrefix="uc3" %>
<%@ Register Src="WUC/Notice.ascx" TagName="Notice" TagPrefix="uc4" %>
<%@ Register Src="WUC/CentreNews.ascx" TagName="CentreNews" TagPrefix="uc5" %>
<%@ Register Src="WUC/Topic.ascx" TagName="Topic" TagPrefix="uc6" %>
<%@ Register Src="WUC/DownloadList.ascx" TagName="DownloadList" TagPrefix="uc7" %>
<%@ Register Src="WUC/InternalFileMenu.ascx" TagName="InternalFileMenu" TagPrefix="uc8" %>
<%@ Register Src="WUC/StudyMenu.ascx" TagName="StudyMenu" TagPrefix="uc9" %>
<%@ Register src="WUC/Search.ascx" tagname="Search" tagprefix="uc10" %>
<asp:Content ID="View" runat="server" ContentPlaceHolderID="cphTop">
    <div id="mainBox">
        <div id="column_01">
            <uc4:Notice ID="Notice1" MenuID="14" Title="最新公告" runat="server" />
            <uc10:Search ID="Search1" runat="server" />
            <uc2:IconShortCut ID="NewsList5" runat="server" />
            <uc6:Topic ID="Topic" runat="server" />
        </div>
        <div id="column_02">
            <uc1:NewsList ID="NewsList7" Length="12" MenuID="15" Title="部门简报" runat="server" />
            <uc1:NewsList ID="NewsList8" Length="12" MenuID="16" Title="行内动态" runat="server" />
            <uc1:NewsList ID="NewsList6" Length="12" MenuID="17" Title="部室快递" runat="server" />
        </div>
        <div id="column_03">
            <uc3:PicNews ID="PicNews1" runat="server" />
            <uc5:CentreNews ID="NewsList12" MenuID="-1" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="Server">
    <div id="lesserBox">
        <uc7:DownloadList ID="DownloadList1" runat="server" />
        <div class="lesserColumn_02">
            <div class="ad">
                <a href="#">
                    <img src="UploadFiles/AD/233.jpg" alt="以农行智慧，助县城腾飞" width="636" height="122" /></a></div>
            <div class="lesserColumn_03">
                <uc8:InternalFileMenu ID="InternalFileMenu1" Length="22" runat="server" MenuID="20"
                    Title="内部文件" Count="7" />
            </div>
            <div class="lesserColumn_04">
                <uc9:StudyMenu ID="StudyMenu1" Length="22" runat="server" MenuID="19" Title="学习园地" Count="7"/>
            </div>
        </div>
    </div>
</asp:Content>

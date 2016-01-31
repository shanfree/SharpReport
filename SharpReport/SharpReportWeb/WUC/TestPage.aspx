<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="TestPage.aspx.cs" Inherits="SharpReportWeb.WUC.TestPage" Title="无标题页" %>

<%@ Register Src="InvoiceList.ascx" TagName="InvoiceList" TagPrefix="uc1" %>
<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

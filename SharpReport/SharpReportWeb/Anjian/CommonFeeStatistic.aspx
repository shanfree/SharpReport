<%@ Page  Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="CommonFeeStatistic.aspx.cs" Inherits="SharpReportWeb.Anjian.CommonFeeStatistic"  Title="安监部费用年度汇总" %>
   

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register src="../WUC/CommonFeeStatistic.ascx" tagname="CommonFeeStatistic" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>报告期选择</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td align="right" class="tint">
                        年份：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblYear" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblYear_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="window">
        <div class="title BGx">
            <span>安监部费用年度汇总</span>
        </div>
        <div id="SlideBox">
            <uc1:CommonFeeStatistic ID="cfs_List" runat="server" DepartmentID="4"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

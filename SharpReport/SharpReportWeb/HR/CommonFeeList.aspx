<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="CommonFeeList.aspx.cs" Inherits="SharpReportWeb.HR.CommonFeeList" EnableEventValidation="false"
    Title="人力资源部费用情况汇总" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="../WUC/WUC_CommonFee.ascx" TagName="WUC_CommonFee" TagPrefix="uc1" %>
<%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>人力资源部费用情况汇总</span></div>
        <div class="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <th colspan="4" class="mass BGx">
                        报告期选择：
                    </th>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        年份：
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblYear" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblDim_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        月份：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblMoth" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblDim_SelectedIndexChanged"
                            AutoPostBack="true" DataTextField="Name" DataValueField="ID" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                            <asp:ListItem Value="1">一月</asp:ListItem>
                            <asp:ListItem Value="2">二月</asp:ListItem>
                            <asp:ListItem Value="3">三月</asp:ListItem>
                            <asp:ListItem Value="4">四月</asp:ListItem>
                            <asp:ListItem Value="5">五月</asp:ListItem>
                            <asp:ListItem Value="6">六月</asp:ListItem>
                            <asp:ListItem Value="7">七月</asp:ListItem>
                            <asp:ListItem Value="8">八月</asp:ListItem>
                            <asp:ListItem Value="9">九月</asp:ListItem>
                            <asp:ListItem Value="10">十月</asp:ListItem>
                            <asp:ListItem Value="11">十一月</asp:ListItem>
                            <asp:ListItem Value="12">十二月</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th colspan="4" class="mass BGx">
                        人力资源部费用情况汇总：（新增月份请选择费用发生的月份）
                    </th>
                </tr>
                <tr>
                    <th colspan="4" align="left">
                        <uc1:WUC_CommonFee ID="WUC_CommonFee1" runat="server" DepartmentID="5" />
                        <input id="lbID" type="hidden" name="lbID" runat="server" />
                    </th>
                </tr>
            </table>
        </div>
        <div class="toolbar">
            <!--翻页-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

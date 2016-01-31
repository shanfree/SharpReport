<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUC_CommonFee.ascx.cs"
    Inherits="SharpReportWeb.WUC.WUC_CommonFee" %>
<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Font-Size="12px"
    CssClass="t" Width="100%" OnRowCommand="gvList_RowCommand" OnRowDataBound="gvList_RowDataBound">
    <EmptyDataTemplate>
        <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
    </EmptyDataTemplate>
    <RowStyle HorizontalAlign="Center" />
    <Columns>
        <asp:TemplateField HeaderText="年份" ItemStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lbYear" runat="server" Text='<%#Eval("Year")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="月份" ItemStyle-Width="50px">
            <ItemTemplate>
                <asp:Label ID="lbMonth" runat="server" Text='<%#Eval("MonthNumOfYear")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="费用类别">
            <ItemTemplate>
                <asp:DropDownList ID="ddlFeeCatalog" runat="server" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="金额">
            <ItemTemplate>
                <asp:TextBox ID="tbAmout" CssClass="inputText" runat="server" Width="120px" Text='<%#Eval("Amount")%>'
                    MaxLength="100"></asp:TextBox><font color="red">*</font>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="币种">
            <ItemTemplate>
                <asp:DropDownList ID="ddlListCurrency" runat="server" DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="等额人民币">
            <ItemTemplate>
                <asp:Label ID="lbRMB" runat="server" Text='<%# GetRMB(Convert.ToString(Eval("ID")))%>'></asp:Label>
                元
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="税率（%）">
            <ItemTemplate>
                <asp:DropDownList ID="ddlRate" runat="server" DataTextField="Name" DataValueField="ID">
                    <asp:ListItem Text="17" Value="0.17" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="13" Value="0.13"></asp:ListItem>
                    <asp:ListItem Text="11" Value="0.11"></asp:ListItem>
                    <asp:ListItem Text="6" Value="0.06"></asp:ListItem>
                    <asp:ListItem Text="3" Value="0.03"></asp:ListItem>
                    <asp:ListItem Text="1" Value="0.00"></asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="录入时间">
            <ItemTemplate>
                <asp:TextBox ID="tbCreateTime" CssClass="inputText" runat="server" Width="160px"
                    Text='<%#Eval("CreateTime")%>' MaxLength="100" ReadOnly="true"></asp:TextBox><font
                        color="red">*</font>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="备注">
            <ItemTemplate>
                <asp:TextBox ID="tbRemark" runat="server" CssClass="inputText" Text='<%#Eval("备注")%>'>
                </asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ItemStyle-Width="140px">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="保存" CssClass="btn" CommandName="btnEdit"
                    CommandArgument='<%# Container.DataItemIndex %>' Visible='<%# Eval("ID") == null?false:true%>' />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" CommandName="btnDel"
                    CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return window.confirm('您真的要删除吗？')"
                    Visible='<%# Eval("ID") == null?false:true%>' />
                <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn" CommandName="btnAdd"
                    CommandArgument='<%# Container.DataItemIndex %>' Visible='<%# Eval("ID") == null?true:false%>' />
                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<cc1:DefaultPager ID="pGrid" runat="server" OnClick="pGrid_OnClick">
</cc1:DefaultPager>

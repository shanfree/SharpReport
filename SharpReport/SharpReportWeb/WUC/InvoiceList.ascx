<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvoiceList.ascx.cs"
    Inherits="SharpReportWeb.WUC.InvoiceList" %>
<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<style type="text/css">
    #newPreview
    {
        filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);
    }
</style>

<script language="javascript">
    function OpenUrl(url) {
        if (url != "") {
            window.open(url);
            return false;
        }
    }
</script>

<div class="window">
    <div class="title BGx">
        <span>报表相关发票列表</span></div>
    <div class="SlideBox">
        <!--滚动必须-->
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Font-Size="12px"
            border="0" CellPadding="0" CellSpacing="0" CssClass="t" Width="100%" OnRowCommand="gvList_RowCommand"
            OnRowDataBound="gvList_RowDataBound" ShowFooter="true">
            <EmptyDataTemplate>
                <font style="color: red; font-weight: bold; font-size: larger;">无符合条件的记录</font>
            </EmptyDataTemplate>
            <RowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField HeaderText="发票编号">
                    <ItemTemplate>
                        <asp:TextBox ID="tbNumber" CssClass="inputText" runat="server" Width="120px" Text='<%#Eval("Number")%>'
                            MaxLength="100"></asp:TextBox><font color="red">*</font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额（原货币单位）">
                    <ItemTemplate>
                        <asp:TextBox ID="tbAmout" CssClass="inputText" runat="server" Width="120px" Text='<%#Eval("Amout")%>'
                            MaxLength="100"></asp:TextBox><font color="red">*</font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="币种">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlCurrency" runat="server" DataTextField="Name" DataValueField="ID">
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
                <asp:TemplateField HeaderText="净成本">
                    <ItemTemplate>
                        <asp:Label ID="lbCost" runat="server" Text='<%# GetCost(Convert.ToString(Eval("ID")))%>'></asp:Label>
                        元
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="报销人">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPersonName" CssClass="inputText" runat="server" Width="60px" Text='<%#Eval("PersonName")%>'
                            MaxLength="100"></asp:TextBox><font color="red">*</font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开票时间（汇率）">
                    <ItemTemplate>
                        <cc1:Calendar ID="cInputDate" runat="server" CssClass="inputText" Text='<%#Eval("InputDate")%>'></cc1:Calendar>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" ItemStyle-Width="140px">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="保存" CssClass="btn" CommandName="btnEdit"
                            CommandArgument='<%#Eval("ID")%>' />
                        <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="btn" CommandName="btnDel"
                            CommandArgument='<%#Eval("ID")%>' OnClientClick="return window.confirm('您真的要删除吗？')" />
                        <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn" CommandName="btnAdd"
                            Visible="false" CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:Button ID="btnPic" runat="server" Text="图样" CssClass="btn" CommandName="btnPic"
                            Visible="false" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <!--滚动必须-->
    </div>
    <div class="toolbar">
        <!--翻页-->
    </div>
</div>

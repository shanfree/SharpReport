<%@ Page Title="船舶月份收入汇总表" Language="C#" MasterPageFile="~/MasterPage/Default.Master"
    AutoEventWireup="true" CodeBehind="ShipIncomeMonthReport.aspx.cs" Inherits="SharpReportWeb.Hangy.ShipIncomeMonthReport" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
    <%@ Register Src="../WUC/WUC_MonthAndShipNavigate.ascx" TagName="WUC_MonthAndShipNavigate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <uc2:WUC_MonthAndShipNavigate ID="MonthAndShipNavigate1" IsShowMonthAll="false" runat="server" OnSelectedChanged="MonthAndShipNavigate1_OnSelectedChanged" />
    <script type="text/javascript">
        var n = 0
        $("#dropDownList dt").click(function() {
            var popWin = $("#dropDownList dd").get(0)
            if (n == 0) {
                popWin.style.display = ""
                $("#dropDownList span").attr("class", "clicked")
                n = 1
            }
            else {
                popWin.style.display = "none"
                $("#dropDownList span").attr("class", "")
                n = 0
            }
        });
        $(".advancedOptionsBtn").click(function() {
            if ($("#advancedOptions").css("display") == "none") {
                $("#advancedOptions").css("display", "block");
                $(this).css("background-position", "-105px -186px");
            }
            else {
                $("#advancedOptions").css("display", "none");
                $(this).css("background-position", "0 -186px");
            }
        });
    </script>

    <div class="window">
        <div class="title BGx">
            <span>船舶月份收入统计报表 </span>
        </div>
        <div class="SlideBox">
            <!--滚动必须-->
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CssClass="t"
                PageSize="15" OnRowDataBound="gvList_RowDataBound" ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <asp:Label ID="lbIndex" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            <asp:Label ID="lbShipID" Text='<%#Eval("ID") %>' runat="server" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="船舶">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlShip" runat="server"><%#Eval("Name")%></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="运行航次" DataField="运行航次" ItemStyle-Width="10%">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="承运货量" DataField="承运货量" ItemStyle-Width="10%">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="散货美元收入" DataField="散货美元收入" ItemStyle-Width="10%" Visible="false">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="散货人民币收入" DataField="散货人民币收入" ItemStyle-Width="10%" Visible="false">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="承运箱量" DataField="承运箱量" ItemStyle-Width="10%">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="集装箱美元收入" DataField="集装箱美元收入" ItemStyle-Width="10%" Visible="false">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="集装箱人民币收入" DataField="集装箱人民币收入" ItemStyle-Width="10%"
                        Visible="false">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="出租天数" DataField="出租天数" ItemStyle-Width="10%">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="出租美元收入" DataField="出租美元收入" ItemStyle-Width="10%" Visible="false">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="出租人民币收入" DataField="出租人民币收入" ItemStyle-Width="10%" Visible="false">
                        <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="其他收入（人民币）" DataField="其他人民币收入">
                        <ItemStyle Width="30px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="其他收入（美元）" DataField="其他美元收入">
                        <ItemStyle Width="30px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="含税收入（美元）">
                        <ItemTemplate>
                            <asp:Label ID="lbTotalD" runat="server" Text="--"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="含税收入（人民币）">
                        <ItemTemplate>
                            <asp:Label ID="lbTotalR" runat="server" Text="--"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="含税收入合计">
                        <ItemTemplate>
                            <asp:Label ID="lbTotal" runat="server" Text="--"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="不含税收入合计">
                        <ItemTemplate>
                            <asp:Label ID="lbTotalNO" runat="server" Text="--"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        无符合条件的记录</font>
                </EmptyDataTemplate>
                <RowStyle HorizontalAlign="Left" Wrap="false" />
            </asp:GridView>
            <!--翻页-->
            <cc1:DefaultPager ID="pGridV" runat="server" Align="Right" Font-Size="Small" OnClick="pGridV_OnClick"
                PageSize="15" />
        </div>
        <!--滚动必须-->
    </div>
    <div class="toolbar" style="text-align: center">
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

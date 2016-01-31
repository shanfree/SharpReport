<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="WuliaoSummary.aspx.cs" Inherits="SharpReportWeb.ChuanJ.WuliaoSummary"
    Title="���ϱ���ſ�" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">
    <div class="window">
        <div class="title BGx">
            <span>���ϱ�������ѡ��</span></div>
        <div id="SlideBox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="form">
                <tr>
                    <td align="right" class="tint">
                        ��ݣ�
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblYear" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblYear_SelectedIndexChanged"
                            AutoPostBack="true" RepeatDirection="Horizontal" DataTextField="Name" DataValueField="ID"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        ������
                    </td>
                    <td align="left" colspan="3">
                        <asp:RadioButtonList ID="rblShip" runat="server" Style="border: 0px" OnSelectedIndexChanged="rblShip_SelectedIndexChanged"
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
            <span>���ϱ��������</span><asp:Button ID="btnAdd" runat="server" Text="����" CssClass="btn" OnClick="btnAdd_Click"
                            Height="16px" /></div>
        <div id="SlideBox">
            <asp:GridView ID="gvWuliaoList" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="gvWuliaoList_RowDataBound" CssClass="t" PageSize="12">
                <Columns>
                    <asp:TemplateField HeaderText="ѡ��" ItemStyle-Width="20">
                        <ItemTemplate>
                            <asp:RadioButton ID="rbSel" OnClick="Sel('')" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="�·�" DataField="MonthNumOfYear" ItemStyle-Width="10%">
                        <ItemStyle Width="15%"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="��������ȫ����" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <a href="WuliaoList.aspx?dimID=<%#Eval("ID") %>" target="_self">
                                <%#Eval("ȫ��")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��������Ԥ��¼�룩" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <a href="WuliaoList.aspx?dimID=<%#Eval("ID")%>&ReportType=1" target="_self">
                                <%#Eval("Ԥ��¼��")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="������������¼�룩" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <a href="WuliaoList.aspx?dimID=<%#Eval("ID")%>&ReportType=2" target="_self">
                                <%#Eval("����¼��")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="������������ȷ�ϣ�" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <a href="WuliaoList.aspx?dimID=<%#Eval("ID")%>&ReportType=3" target="_self">
                                <%#Eval("����ȷ��")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="������ǧԪ��" DataField="����" ItemStyle-Width="10%"></asp:BoundField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <font color="red" style="font-size: large; color: red; text-decoration: underline;">
                        �޷��������ļ�¼</font>
                </EmptyDataTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
            <input id="lbID" type="hidden" name="lbID" runat="server" />
            <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" GridViewID="gvWuliaoList"
                OnClick="ExcelGenButton1_Click" Text="����Excel" FileName="��־��Ϣ" CssClass="btn">
            </cc1:ExcelGenButton>
        </div>
    </div>

    <script type="text/javascript">
        //ȫѡ��ѡ
        function Sel(ID) {
            oEl = event.srcElement;

            if (oEl.checked) {
                for (i = 0; i < document.all.length; i++) {
                    if (document.all(i).id.indexOf("rbSel") != -1) {
                        document.all(i).checked = false;
                        var trRow = document.all(i).parentElement.parentElement;
                        if (trRow != null) {
                            trRow.setAttribute("bgcolor", "#ffffff", 0);
                        }
                    }
                }
                oEl.checked = true;
                oEl.parentElement.parentElement.setAttribute("bgcolor", "#feeee0", 0);

                for (i = 0; i < document.all.length; i++) {
                    if (document.all(i).id.indexOf("lbID") != -1) {
                        document.all(i).value = ID;
                    }
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

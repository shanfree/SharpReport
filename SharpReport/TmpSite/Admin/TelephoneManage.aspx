<%@ Page Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true"
    CodeFile="TelephoneManage.aspx.cs" Inherits="Admin_TelephoneManage" Title="部门联系方式管理" %>

<%@ Register Assembly="WFNetCtrl" Namespace="WFNetCtrl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Conut1" runat="Server">
    <link href="../Style/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .inputStyle_01
        {
            width: 120px;
        }
    </style>
    <div class="adminTitle">
        部门联系方式管理</div>
    <div style="float: left; background-color: #E0E0E0; width: 200px;">
        <asp:TreeView ID="tOffice" runat="server" CssClass="TableNoborder01" NodeIndent="10"
            OnSelectedNodeChanged="tOffice_SelectedNodeChanged" ExpandDepth="10">
        </asp:TreeView>
        <div class="br">
            <!--留空，勿删-->
        </div>
    </div>
    <div style="width: 400px; padding-left: 12px;">
        当前部门：
        <asp:Label ID="lbName" runat="server"></asp:Label>
        <br />
        名&nbsp;&nbsp;&nbsp;&nbsp;称：
        <asp:TextBox ID="tbName" runat="server" CssClass="input12"></asp:TextBox>
        <br />
        排&nbsp;序&nbsp;号：
        <asp:TextBox ID="tbSortNum" runat="server" CssClass="input12"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="排序号请输入数字"
            ControlToValidate="tbSortNum" ValidationExpression="^-?\d+$"></asp:RegularExpressionValidator>
        <br />
        备注信息：
        <asp:TextBox ID="tbRemark" runat="server" CssClass="input12"></asp:TextBox>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="Btn_bse75" OnClick="btnSubmit_Click"
                OnClientClick="if(window.confirm('您确认要修改部门吗？')==false)return false;" Visible="false" />
            <asp:Button ID="btnAdd" runat="server" Text="添加同级部门" CssClass="Btn_bse75" OnClick="btnAdd_Click"
                OnClientClick="if(window.confirm('您确认要添加同级部门？')==false)return false;" Visible="false" />
            <asp:Button ID="btnSub" runat="server" Text="添加子部门" CssClass="Btn_bse75" OnClick="btnSub_Click"
                OnClientClick="if(window.confirm('您确认要添加子部门？')==false)return false;" Visible="false" />
            <asp:Button ID="btnDel" runat="server" Text="删除部门" CssClass="Btn_bse75" OnClick="btnDel_Click"
                OnClientClick="if(window.confirm('您确认要删除部门？')==false)return false;" UseSubmitBehavior="false"
                Visible="false" />
        </div>
        <div>
            当前部门联系方式：
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" PageSize="20"
                BorderStyle="Solid" OnRowCommand="gvList_RowCommand" ShowHeader="true" OnRowDataBound="gvList_RowDataBound">
                <EmptyDataTemplate>
                    暂无数据。</EmptyDataTemplate>
                <RowStyle BorderStyle="None"></RowStyle>
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" CssClass="inputStyle_01" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="内线电话">
                        <ItemTemplate>
                            <asp:TextBox ID="tbInnerPhone" runat="server" CssClass="inputStyle_01" Text='<%# Bind("InnerPhone") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="外线电话">
                        <ItemTemplate>
                            <asp:TextBox ID="tbOutterPhone" runat="server" CssClass="inputStyle_01" Text='<%# Bind("OutterPhone") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="手机">
                        <ItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" CssClass="inputStyle_01" Text='<%# Bind("Remark") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <table style="width: 100px;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" CommandName="Add" Text="新增" />
                                        <asp:Button ID="btnSave" runat="server" CommandName="Save" Text="保存" />
                                        <asp:Button ID="btnDel" runat="server" Text="删除" CommandName="Del" OnClientClick="return confirm('确定删除吗？');" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <cc1:DefaultPager ID="pGrid" runat="server" ImgPath="Images/Toolbar" Align="Right"
                OnClick="pGrid_OnClick" />
        </div>
    </div>
    <div class="br">
        <!--留空，勿删-->
    </div>
</asp:Content>

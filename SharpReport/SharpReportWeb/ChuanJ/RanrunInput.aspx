<%@ Page Language="C#" MasterPageFile="~/MasterPage/Default.Master" AutoEventWireup="true"
    CodeBehind="RanrunInput.aspx.cs" Inherits="SharpReportWeb.ChuanJ.RanrunInput"
    Title="�������Ϻ������ı�" %>

<%@ Register Assembly="SIRC.Framework.WebControlLib" Namespace="SIRC.Framework.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTop" runat="server">

    <script type="text/javascript">
        function sumup() {
            sumupslowworktime();
            sumupcruiseworktime();
            sumupworktime();
            sumupfuelconsume();
            sumupdisselconsume();
            sumupotherconsume();
        }
        function sumupslowworktime() {
            var v1 = parseInt(document.getElementById("ctl00_cphTop_tbSlowWorkTime1").value);
            //var v2 = parseInt(document.getElementById("ctl00_cphTop_tbSlowWorkTime2").value);
            //var v3 = parseInt(document.getElementById("ctl00_cphTop_tbSlowWorkTime3").value);
            //var v4 = parseInt(document.getElementById("ctl00_cphTop_tbSlowWorkTime4").value);
            //var v5 = parseInt(document.getElementById("ctl00_cphTop_tbSlowWorkTime5").value);

            if (isNaN(v1)) {
                v1 = 0;
            } /*
            if (isNaN(v2)) {
                v2 = 0;
            }
            if (isNaN(v3)) {
                v3 = 0;
            }
            if (isNaN(v4)) {
                v4 = 0;
            }
            if (isNaN(v5)) {
                v5 = 0;
            }*/
            var v = v1; //+ v2 + v3 + v4 + v5;

            document.getElementById("ctl00_cphTop_lblSum1").innerHTML = v;
        }
        function sumupcruiseworktime() {
            var v1 = parseInt(document.getElementById("ctl00_cphTop_tbCruiseWorkTime1").value);
            //var v2 = parseInt(document.getElementById("ctl00_cphTop_tbCruiseWorkTime2").value);
            //var v3 = parseInt(document.getElementById("ctl00_cphTop_tbCruiseWorkTime3").value);
            //var v4 = parseInt(document.getElementById("ctl00_cphTop_tbCruiseWorkTime4").value);
            //var v5 = parseInt(document.getElementById("ctl00_cphTop_tbCruiseWorkTime5").value);

            if (isNaN(v1)) {
                v1 = 0;
            } /*
            if (isNaN(v2)) {
                v2 = 0;
            }
            if (isNaN(v3)) {
                v3 = 0;
            }
            if (isNaN(v4)) {
                v4 = 0;
            }
            if (isNaN(v5)) {
                v5 = 0;
            }*/
            var v = v1;  //+ v2 + v3 + v4 + v5;

            document.getElementById("ctl00_cphTop_lblSum2").innerHTML = v;
        }
        function sumupworktime() {
            var v1 = parseInt(document.getElementById("ctl00_cphTop_tbWorkTime1").value);
            var v2 = parseInt(document.getElementById("ctl00_cphTop_tbWorkTime2").value);
            var v3 = parseInt(document.getElementById("ctl00_cphTop_tbWorkTime3").value);
            var v4 = parseInt(document.getElementById("ctl00_cphTop_tbWorkTime4").value);
            var v5 = parseInt(document.getElementById("ctl00_cphTop_tbWorkTime5").value);

            if (isNaN(v1)) {
                v1 = 0;
            }
            if (isNaN(v2)) {
                v2 = 0;
            }
            if (isNaN(v3)) {
                v3 = 0;
            }
            if (isNaN(v4)) {
                v4 = 0;
            }
            if (isNaN(v5)) {
                v5 = 0;
            }
            var v = v1 + v2 + v3 + v4 + v5;

            document.getElementById("ctl00_cphTop_lblSum3").innerHTML = v;
        }
        function sumupfuelconsume() {
            var v1 = parseInt(document.getElementById("ctl00_cphTop_tbFuelConsume1").value);
            var v2 = parseInt(document.getElementById("ctl00_cphTop_tbFuelConsume2").value);
            var v3 = parseInt(document.getElementById("ctl00_cphTop_tbFuelConsume3").value);
            var v4 = parseInt(document.getElementById("ctl00_cphTop_tbFuelConsume4").value);
            var v5 = parseInt(document.getElementById("ctl00_cphTop_tbFuelConsume5").value);

            if (isNaN(v1)) {
                v1 = 0;
            }
            if (isNaN(v2)) {
                v2 = 0;
            }
            if (isNaN(v3)) {
                v3 = 0;
            }
            if (isNaN(v4)) {
                v4 = 0;
            }
            if (isNaN(v5)) {
                v5 = 0;
            }
            var v = v1 + v2 + v3 + v4 + v5;

            document.getElementById("ctl00_cphTop_lblSum4").innerHTML = v;
        }
        function sumupdisselconsume() {
            var v1 = parseInt(document.getElementById("ctl00_cphTop_tbDieselConsume1").value);
            var v2 = parseInt(document.getElementById("ctl00_cphTop_tbDieselConsume2").value);
            var v3 = parseInt(document.getElementById("ctl00_cphTop_tbDieselConsume3").value);
            var v4 = parseInt(document.getElementById("ctl00_cphTop_tbDieselConsume4").value);
            var v5 = parseInt(document.getElementById("ctl00_cphTop_tbDieselConsume5").value);

            if (isNaN(v1)) {
                v1 = 0;
            }
            if (isNaN(v2)) {
                v2 = 0;
            }
            if (isNaN(v3)) {
                v3 = 0;
            }
            if (isNaN(v4)) {
                v4 = 0;
            }
            if (isNaN(v5)) {
                v5 = 0;
            }
            var v = v1 + v2 + v3 + v4 + v5;

            document.getElementById("ctl00_cphTop_lblSum5").innerHTML = v;
        }
        function sumupotherconsume() {
            var v1 = parseInt(document.getElementById("ctl00_cphTop_tbOtherConsume1").value);
            var v2 = parseInt(document.getElementById("ctl00_cphTop_tbOtherConsume2").value);
            var v3 = parseInt(document.getElementById("ctl00_cphTop_tbOtherConsume3").value);
            var v4 = parseInt(document.getElementById("ctl00_cphTop_tbOtherConsume4").value);
            var v5 = parseInt(document.getElementById("ctl00_cphTop_tbOtherConsume5").value);

            if (isNaN(v1)) {
                v1 = 0;
            }
            if (isNaN(v2)) {
                v2 = 0;
            }
            if (isNaN(v3)) {
                v3 = 0;
            }
            if (isNaN(v4)) {
                v4 = 0;
            }
            if (isNaN(v5)) {
                v5 = 0;
            }
            var v = v1 + v2 + v3 + v4 + v5;

            document.getElementById("ctl00_cphTop_lblSum6").innerHTML = v;
        }
    </script>

    <div id="SlideBox">
        <table width="97%" border="0" cellpadding="0" cellspacing="0" class="form">
            <tr>
                <th colspan="7" style="background-color: rgb(232, 247, 255)">
                    <div style="text-align: center; font-size: x-large;">
                        ���������������޹�˾</div>
                    <div style="text-align: center; font-size: x-large;">
                        �������Ϻ������ı�</div>
                    <div style="text-align: right; font-size: x-large;">
                        ���룺 CPM-07R03</div>
                </th>
            </tr>
            <tr>
                <td class="tint">
                    ����
                </td>
                <td colspan="6">
                    <asp:Label ID="lblVoyage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    ���̣����
                </td>
                <td colspan="6">
                    <asp:Label ID="lblDistance" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tint" rowspan="2">
                    ����
                </td>
                <td rowspan="2">
                    <asp:Label ID="lblShipName" runat="server"></asp:Label>
                </td>
                <td class="tint">
                    ���ο�ʼ
                </td>
                <td colspan="2">
                    <asp:Label ID="lblStartTime" runat="server"></asp:Label>
                </td>
                <td class="tint">
                    ������
                </td>
                <td>
                    <asp:Label ID="lblStartPort" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    ���ν���
                </td>
                <td colspan="2">
                    <asp:Label ID="lblEndTime" runat="server"></asp:Label>
                </td>
                <td class="tint">
                    Ŀ�ĸ�
                </td>
                <td>
                    <asp:Label ID="lblEndPort" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="tint">
                    <b >������������ʱ��</b>
                </td>
                <td class="tint">
                    <b>�������ٹ���ʱ��</b>
                </td>
                <td class="tint">
                    <b>���������ι���ʱ��</b>
                </td>
                <td class="tint">
                    <b>ȼ����</b>
                </td>
                <td class="tint">
                    <b>����</b>
                </td>
                <td class="tint">
                    <b>����</b>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����</b>
                    <asp:Label ID="lbConZhuji" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbSlowWorkTime1" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbCruiseWorkTime1" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbWorkTime1" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbFuelConsume1" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbDieselConsume1" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbOtherConsume1" runat="server" class="inputText"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����1</b>
                    <asp:Label ID="lbConFuji1" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbSlowWorkTime2" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbCruiseWorkTime2" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbWorkTime2" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbFuelConsume2" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbDieselConsume2" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbOtherConsume2" runat="server" class="inputText"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����2</b>
                    <asp:Label ID="lbConFuji2" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbSlowWorkTime3" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbCruiseWorkTime3" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbWorkTime3" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbFuelConsume3" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbDieselConsume3" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbOtherConsume3" runat="server" class="inputText"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����3</b>
                    <asp:Label ID="lbConFuji3" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbSlowWorkTime4" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbCruiseWorkTime4" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbWorkTime4" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbFuelConsume4" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbDieselConsume4" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbOtherConsume4" runat="server" class="inputText"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>��¯</b>
                    <asp:Label ID="lbConGuolu" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbSlowWorkTime5" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbCruiseWorkTime5" runat="server" class="inputText" Visible="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbWorkTime5" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbFuelConsume5" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbDieselConsume5" runat="server" class="inputText"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbOtherConsume5" runat="server" class="inputText"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>
                        <input type="button" onclick="sumup();" value="�ܼ�" class="btn" /></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblSum1" runat="server" Enabled="false" class="inputText"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblSum2" runat="server" Enabled="false" class="inputText"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblSum3" runat="server" Enabled="false" class="inputText"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblSum4" runat="server" Enabled="false" class="inputText"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblSum5" runat="server" Enabled="false" class="inputText"></asp:Label></b>
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblSum6" runat="server" Enabled="false" class="inputText"></asp:Label></b>
                </td>
            </tr>
            <tr class="form">
                <th colspan="7" style="background-color: rgb(232, 247, 255)">
                    <h3>
                        <b>ȼ�������ý�棨�֣�<asp:Button ID="btnEditOil" runat="server" Text="�������" class="btn" OnClick="btnEditOil_Click" Visible="false" />
                        </b>
                    </h3>
                </th>
            </tr>
            <tr>
                <td rowspan="10">
                </td>
                <td>
                </td>
                <td class="tint">
                    <b>�Ϻ��ν��</b>
                </td>
                <td class="tint">
                    <b>�����������</b>
                </td>
                <td class="tint">
                    <b>����������</b>
                </td>
                <td class="tint">
                    <b>�����ν����</b>
                </td>
                <td rowspan="10">
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>ȼ����</b>
                    <asp:Label ID="lbOilBalFuel" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain1" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd1" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume1" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance1" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����</b>
                    <asp:Label ID="lbOilBalDiesel" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain2" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd2" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume2" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance2" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����</b>
                    <asp:Label ID="lbOilBalEngine" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain3" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd3" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume3" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance3" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>������</b>
                    <asp:Label ID="lbOilBalCylinder" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain4" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd4" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume4" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance4" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>͸ƽ��</b>
                    <asp:Label ID="lbOilBalTurbine" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain5" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd5" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume5" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance5" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>Һѹ��</b>
                    <asp:Label ID="lbOilBalHydraulic" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain6" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd6" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume6" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance6" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>�䶳��</b>
                    <asp:Label ID="lbFrozenOil" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain7" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd7" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume7" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance7" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>��ѹ����</b>
                    <asp:Label ID="lbPressOil" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain8" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd8" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume8" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance8" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>����</b>
                    <asp:Label ID="lbOtherOil" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:TextBox ID="tbRemain9" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbAdd9" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbConsume9" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbBalance9" runat="server" class="inputText" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="7">
                    <h3>
                        ע������һʽ���ݣ�һ���ֻ������棬һ���ں��ν�������ʱ����������������</h3>
                </td>
            </tr>
            <tr>
                <td rowspan="2">
                </td>
                <td class="tint">
                    <b>�ֻ�����</b>
                </td>
                <td>
                    <asp:Label ID="lblChiefEngineer" runat="server"></asp:Label>
                </td>
                <td class="tint">
                    <b>������</b>
                </td>
                <td>
                    <asp:Label ID="lblCaptain" runat="server"></asp:Label>
                </td>
                <td class="tint">
                    <b>���ڣ�</b>
                </td>
                <td>
                    <cc1:Calendar ID="cCaptainDate" runat="server"></cc1:Calendar>
                </td>
            </tr>
            <tr>
                <td class="tint">
                    <b>�������ܣ�</b>
                </td>
                <td>
                    <asp:Label ID="lblGeneralManager" runat="server"></asp:Label>
                </td>
                <td class="tint">
                    <b>���ڣ�</b>
                </td>
                <td colspan="3">
                    <cc1:Calendar ID="cGeneralDate" runat="server"></cc1:Calendar>
                </td>
            </tr>
            <tr>
                <td colspan="7" align="center">
                    <h3>
                        <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click" class="btn" />
                        &nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="ɾ��" OnClick="btnDelete_Click" OnClientClick="return window.confirm('�����Ҫɾ����')"
                            class="btn" />
                        &nbsp;
                        <asp:Button ID="btnReturn" runat="server" Text="����" OnClick="btnReturn_Click" class="btn" />
                        &nbsp;
                        <cc1:ExcelGenButton ID="ExcelGenButton1" runat="server" CssClass="btn" FileName="�������Ϻ������ı�"
                            GridViewID="tbTotal" Text="����Excel" />
                    </h3>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBottom" runat="server">
</asp:Content>

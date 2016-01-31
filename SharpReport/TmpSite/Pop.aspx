<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pop.aspx.cs" Inherits="Pop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>最新通知</title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0">
            <tr>
                <td align="center" height="40">
                    <asp:Label ID="lbTitle" runat="server" />
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center" height="25">
                    <asp:Label ID="lbFrom" runat="server" />
                    &nbsp;
                    <asp:Label ID="lbTime" runat="server" />
                    &nbsp;
                    <asp:Label ID="lbClick" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                <asp:Literal ID="lbContent" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

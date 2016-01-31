<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewImage.aspx.cs" Inherits="SharpReportWeb.Pages.ViewImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>图片浏览</title>
    <link href="../CSS/Default.css" rel="stylesheet" type="text/css" />

    <script src="../Script/jquery-1.7.1.js" type="text/javascript"></script>

    <script src="../Script/Default.js" type="text/javascript"></script>

    <link href="../CSS/SpryAccordion.css" rel="stylesheet" type="text/css">

    <script src="../Script/Default.js" type="text/javascript"></script>

    <script src="../Script/SpryAccordion.js" type="text/javascript"></script>

    <script type="text/javascript">
        //预览
        function PreviewImg(imageID, imgFile, divID) {
            var newPreview = document.getElementById(divID);
            var id = document.getElementById(imageID);
            id.style.display = "none";
            newPreview.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + imgFile + "',sizingMethod='scale');"
            newPreview.style.width = "350px";
            newPreview.style.height = "300px";
        }

        // 缩放图片 
        function imgToSize(oBool) {
            var imagePhoto = document.all('imagePhoto');
            imagePhoto.style.zoom = parseInt(imagePhoto.style.zoom) + (oBool ? 20 : -20) + '%';
        }

        // 旋转图片
        var oArcSize = 1;
        function imgRoll() {
            var imagePhoto = document.all('imagePhoto');
            imagePhoto.style.filter = 'Progid:DXImageTransform.Microsoft.BasicImage(Rotation=' + oArcSize + ')';
            oArcSize += 1;
            oArcSize = oArcSize == 4 ? 0 : oArcSize;
        }

        // 翻转图片
        function imgReverse(arg) {
            var imagePhoto = document.all('imagePhoto');
            imagePhoto.style.filter = 'Flip' + arg;
        }

        // 拖动图片
        var oBoolean = false, oLeftSpace = 0, oTopSpace = 0;
        function mStart() {
            oBoolean = true;
            if (oBoolean) {
                var imagePhoto = document.all('imagePhoto');
                oLeftSpace = window.event.clientX - imagePhoto.style.pixelLeft;
                oTopSpace = window.event.clientY - imagePhoto.style.pixelTop;
            }
        }

        function mEnd() {
            oBoolean = false;
        }

        function document.onmousemove() {
            if (window.event.button == 1 && oBoolean) {
                var imagePhoto = document.all('imagePhoto');
                imagePhoto.style.pixelLeft = window.event.clientX - oLeftSpace;
                imagePhoto.style.pixelTop = window.event.clientY - oTopSpace;
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ul id="tip">
        <li class="C BG"></li>
        <li class="title BGx">
            <asp:Label ID="lbTitle" runat="server" Text="图片浏览"></asp:Label></li>
        <li class="arrow BG"></li>
        <li class="D BG"></li>
        <li class="text BGx">
            <asp:Label ID="lbText" runat="server" Text="用户可以浏览图片，或者通过重新上传来覆盖原来的图片，栏目也提供了一些常用的图片浏览工具。"></asp:Label></li>
    </ul>

    <div class="window">
        <div class="title BGx">
            <span>图片文件信息</span></div>
        <div id="SlideBox">
            <table align="left" border="0" cellspacing="0" cellpadding="0" class="form">
                <tr>
                    <td align="right" class="tint">
                        图片上传：
                    </td>
                    <td>
                        <asp:FileUpload ID="flImage" runat="server" onchange="PreviewImg('imagePhoto','file:///'+this.value,'newPreview');"
                            CssClas="btn" />
                        <asp:Button ID="btnSubmit" runat="server" Text="保存" OnClick="btnSubmit_Click" OnClientClick="return window.confirm('您真的要保存吗？')" />
                        <br />
                        <asp:Label ID="lblMessage" ForeColor="red" runat="server" Text="上传的图片不能超过80K，并且是jpg格式的图片"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="tint">
                        图片浏览：
                    </td>
                    <td style="padding: 5px">
                        <div style="position: relative; z-index: 1000;">
                            <input type="button" onclick="imgToSize(1);" style="background-color: transparent;
                                background-image: url(../images/zoomIn.gif); border: none; width: 84px; height: 24px;
                                cursor: hand;" />
                            <input type="button" onclick="imgToSize(0);" style="background-color: transparent;
                                background-image: url(../images/zoomOut.gif); border: none; width: 84px; height: 24px;
                                cursor: hand;" />
                            <input type="button" onclick="imgRoll();" style="background-color: transparent; background-image: url(../images/whirl.gif);
                                border: none; width: 84px; height: 24px; cursor: hand;" />
                        </div>
                        <div align="left">
                            <div id="newPreview" runat="server">
                            </div>
                            <asp:Image runat="server" ID="imagePhoto" ImageUrl="~/images/map.png" Style="position: relative;
                                zoom: 100%; cursor: move;" onmousedown="mStart();" onmouseup="mEnd();" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>

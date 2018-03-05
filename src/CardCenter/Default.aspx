<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CardCenter.Default" %>

<%@ Register Src="ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />
    <script type="text/javascript" src="js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.reveal.js"></script>
    <title>制卡业务系统-首页</title>
    <style>
        .mainpage {margin-left:auto; margin-right:auto; margin-top:20px; width:80%; text-align:center;}
        .maintr {width:33%;text-align:center;}
        .maintrmanager {width:100%;text-align:center;}
        .mainpage img:hover {
            cursor:pointer;
        }
        .mainpage img.building:hover {
            cursor:not-allowed;
        }
    </style>
    <script>
        jQuery(document).ready(function () {
            var iWidth = 1100; //弹出窗口的宽度;
            var iHeight = 600; //弹出窗口的高度;
            var iTop = (window.screen.availHeight - 30 - iHeight) / 2; //获得窗口的垂直位置;
            var iLeft = (window.screen.availWidth - 10 - iWidth) / 2; //获得窗口的水平位置;
            window.open("Notice.html", "通知", "height=" + iHeight + ", width=" + iWidth + ", top=" + iTop + ", left=" + iLeft + ", scrollbars=yes");
        });
    </script>
</head>
<body>
    <div class="mainpage">
        <table class="table">
            <tr>
                <td colspan="3" class="maintrmanager">
                    <img src="images/mainpage/Guide_1.png" onMouseOver="this.src='images/mainpage/Guide.png'" onMouseOut="this.src='images/mainpage/Guide_1.png'" onclick="location.href = 'ServiceGuide.aspx'"/>
                </td>
            </tr>
            <tr>
                <td class="maintr">
                    <img src="images/mainpage/1_1.png" onMouseOver="this.src='images/mainpage/1.png'" onMouseOut="this.src='images/mainpage/1_1.png'" onclick="location.href = 'ApplyForm/NewlyAdded.aspx'"/>
                </td>
                <td class="maintr">
                    <img src="images/mainpage/2_1.png" onMouseOver="this.src='images/mainpage/2.png'" onMouseOut="this.src='images/mainpage/2_1.png'" onclick="location.href = 'ApplyForm/Modify.aspx'"/>
                </td>
                <td class="maintr">
                    <img src="images/mainpage/3_1.png" onMouseOver="this.src='images/mainpage/3.png'" onMouseOut="this.src='images/mainpage/3_1.png'" onclick="location.href = 'ApplyForm/ReIssue.aspx'"/>
                </td>
                
            </tr>
            <tr>
                <td class="maintr">
                    <img src="images/mainpage/4_1.png" onMouseOver="this.src='images/mainpage/4.png'" onMouseOut="this.src='images/mainpage/4_1.png'" onclick="location.href = 'ApplyForm/ReMake.aspx'"/>
                </td>
                <td class="maintr">
                    <img src="images/mainpage/5_1.png" onMouseOver="this.src='images/mainpage/5.png'" onMouseOut="this.src='images/mainpage/5_1.png'" onclick="location.href = 'ApplyForm/UpdateUnlock.aspx'"/>
                </td>
                <td class="maintr">
                    <img src="images/mainpage/6_1.png" onMouseOver="this.src='images/mainpage/6.png'" onMouseOut="this.src='images/mainpage/6_1.png'" onclick="location.href = 'ApplyForm/Sale.aspx'"/>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="maintrmanager">
                    <img src="images/mainpage/button_1.png" onMouseOver="this.src='images/mainpage/button.png'" onMouseOut="this.src='images/mainpage/button_1.png'" onclick="location.href = 'Manager/JobList.aspx'"/>
                </td>
            </tr>
        </table>
    </div>

    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

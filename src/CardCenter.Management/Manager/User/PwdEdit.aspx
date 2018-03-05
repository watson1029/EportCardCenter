<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PwdEdit.aspx.cs" Inherits="CardCenter.Management.Manager.User.PwdEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <title></title>
    <style>
        .table td.title {
            width:35%;
            text-align:right;
            font-weight:bold;
            background: #fcfcfc;
        }
        .table td.content {
            width:65%;
            text-align:left;
            background: #fff;
        }
    </style>
    <script>
        function Submit() {
            if (jQuery("#newPwd").val() == jQuery("#confirmPwd").val()) {
                if (jQuery("#newPwd").val().length >= 6) {
                    jQuery.ajax({
                        type: "POST",
                        dataType: "text",
                        url: "../../Ajax/SaveUser.ashx",
                        data: $('#pwdform').serialize() + "&type=pwd",
                        success: function (msg) {
                            if (msg == "") {
                                jAlert("修改密码成功！", "提示");
                            }
                            else {
                                jAlert(msg, "提示");
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                        }
                    });
                }
                else
                    jAlert("新密码长度至少6位！", "提示");
            }
            else
                jAlert("两次输入的新密码不一致！", "提示");
            return false;
        }
    </script>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">修改密码</h1>
        <span class="pagedesc" style="margin: 0 20px;">修改旧密码为新密码.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <form class="stdform" action="" method="post" id="pwdform">
            <input type="hidden" id="Guid" runat="server" />
            <table class="table">
                <tr>
                    <td class="title">请输入旧密码：</td>
                    <td class="content">
                        <input id="oldPwd" type="password" class="longinput" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td class="title">请输入新密码：</td>
                    <td class="content">
                        <input id="newPwd" type="password" class="longinput" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td class="title">请再次输入新密码：</td>
                    <td class="content">
                        <input id="confirmPwd" type="password" class="longinput" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <button class="button radius2 submit" style="width:120px;" onclick="return Submit()">修改密码</button>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="CardCenter.Management.Manager.User.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../../js/plugins/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <title></title>
    <style>
        .table td.title {
            width:15%;
            text-align:center;
            font-weight:bold;
            background: #fcfcfc;
        }
        .table td.content {
            width:35%;
            text-align:left;
            background: #fff;
        }
    </style>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery(".chzn-select").chosen();
        });

        function Submit() {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../../Ajax/SaveUser.ashx",
                data: $('#userform').serialize() + "&type=add",
                success: function (msg) {
                    if (msg == "") {
                        jAlert("添加用户成功！请注意查收手机短信！\n点击确定跳转至用户列表。", "提示", function () {
                            jQuery.ajax({
                                type: "POST",
                                dataType: "text",
                                url: "../../Ajax/Authorize/AuthorizeJudge.ashx",
                                data: "param=UserEdit",
                                success: function (url) {
                                    location.href = "../" + url;
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                                }
                            });
                        });
                    }
                    else {
                        jAlert(msg, "提示");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
            return false;
        }
    </script>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">添加用户</h1>
        <span class="pagedesc" style="margin: 0 20px;">新建用户，填写用户名、真实姓名、部门、手机号码等信息.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <form class="stdform" action="" method="post" id="userform">
            <table class="table">
                <tr>
                    <td class="title">用户名：</td>
                    <td class="content">
                        <input type="text" id="userName" class="longinput" runat="server"/>
                    </td>
                    <td class="title">真实姓名：</td>
                    <td class="content">
                        <input type="text" id="trueName" class="longinput" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td class="title">所属制卡点：</td>
                    <td class="content">
                        <select id="department" runat="server" data-placeholder="所属制卡点" class="chzn-select" style="width:200px;">
                        </select>
                    </td>
                    <td class="title">手机号码：</td>
                    <td class="content">
                        <input type="text" id="phoneNum" class="longinput" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center;">
                        <button class="button radius2 submit" style="width:120px;" onclick="return Submit()">添&nbsp;&nbsp;加</button>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>

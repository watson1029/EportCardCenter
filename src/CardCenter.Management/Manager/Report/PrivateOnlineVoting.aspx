﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrivateOnlineVoting.aspx.cs" Inherits="CardCenter.Management.Manager.Report.PrivateOnlineVoting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.slimscroll.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.smartWizard-2.0.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../js/custom/forms.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/charCount.js"></script>
    <script type="text/javascript" src="../../js/plugins/ui.spinner.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="../../js/custom/elements.js"></script>
    <script type="text/javascript" src="../../js/plugins/colorpicker.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <title>统计报表</title>
    <style>
        .table td.title {
            width: 15%;
            text-align: center;
            font-weight: bold;
            background: #fcfcfc;
        }

        .table td.content {
            width: 35%;
            background: #fff;
        }
    </style>
    <script>
        jQuery(document).ready(function () {
            jQuery(".datetime").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1980:2020'
            });

            jQuery("#dlStatistics").change(function () {
                var txt;
                switch (jQuery(this).val())
                {
                    case "Statistics5":
                        txt = "统计业务工单详细信息（所有）。条件：时间段。输出结果：所有更新、解锁、变更工单";
                        break;
                    case "Statistics6":
                        txt = "统计业务工单详细信息（其他关区）。条件：时间段。输出结果：市政以外关区处理的更新、解锁、变更工单";
                        break;
                }
                jQuery("#txtStatistics").html(txt);
            });
        });
        function Verifi() {
            if (IsEmpty("dtBegin", "统计开始日期"))
                return false;
            
            if (IsEmpty("dtEnd", "统计结束日期"))
                return false;
            
            return true;
        }

        function IsEmpty(obj, name) {
            var val = jQuery("#" + obj).val();
            if (val == "") {
                jAlert(name + "不能为空!", "提示", function () {
                    addError(obj);
                });
                return true;
            }
            else {
                removeError(obj);
                return false;
            }
        }

        //添加错误样式
        function addError(obj) {
            jQuery("#" + obj).addClass("error");
            jQuery("#" + obj).focus();

        }
        //移除错误样式
        function removeError(obj) {
            jQuery("#" + obj).removeClass("error");
        }
    </script>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
             <ul class="breadcrumbs">
                <li><a href="OnlineVoting.aspx">统计报表</a></li>
            </ul>
            <form id="form1" class="stdform" method="post" action="" runat="server">
                <table class="table">
                    <tr>
                        <td class="title">统计开始日期</td>
                        <td class="content"><input type="text" id="dtBegin" class="longinput datetime" runat="server" /></td>
                        <td class="title">统计结束日期</td>
                        <td class="content"><input type="text" id="dtEnd" class="longinput datetime" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="title">统计类型</td>
                        <td class="content">
                            <select id="dlStatistics" runat="server" data-placeholder="统计类型" class="chzn-select" style="width: 200px;">
                                <option value="Statistics5">业务工单详细信息统计（所有）</option>
                                <option value="Statistics6">业务工单详细信息统计（其他关区）</option>
                            </select>
                        </td>
                        <td colspan="2" style="color:red;text-align:center;"><span id="txtStatistics">统计业务工单详细信息。条件：时间段。</span></td>
                    </tr>
                    <tr>
                        <td style="text-align:center;" colspan="4">
                            <asp:Button ID="submit" runat="server" Text="&nbsp;&nbsp;生&nbsp;&nbsp;成&nbsp;&nbsp;" OnClick="submit_Click" OnClientClick="return Verifi();"/>
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
</body>
</html>

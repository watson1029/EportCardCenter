<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics4.aspx.cs" Inherits="CardCenter.Management.Manager.Report.Statistics4" %>

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
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">东方/南方支付信息</h1>
        <span class="pagedesc" style="margin: 0 20px;">统计东方和南方支付信息.</span>
    </div>
    <form id="form1" class="stdform" method="post" action="" runat="server">
        <table class="table">
            <tr>
                <td class="title">统计开始日期</td>
                <td class="content"><input type="text" id="dtBegin" class="longinput datetime" runat="server" /></td>
                <td class="title">统计结束日期</td>
                <td class="content"><input type="text" id="dtEnd" class="longinput datetime" runat="server" /></td>
            </tr>
            <tr>
                <td style="text-align:center;" colspan="4">
                    <asp:Button ID="submit" runat="server" Text="&nbsp;&nbsp;生&nbsp;&nbsp;成&nbsp;&nbsp;" OnClick="submit_Click" OnClientClick="return Verifi();"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpotInput.aspx.cs" Inherits="CardCenter.Management.Manager.SpotInput" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.slimscroll.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/custom/forms.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../js/plugins/charCount.js"></script>
    <script type="text/javascript" src="../js/plugins/ui.spinner.min.js"></script>
    <script type="text/javascript" src="../js/plugins/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="../js/custom/elements.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.alerts.js"></script>
    <title>制卡业务系统-现场收单</title>
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
        #add:hover {
            cursor:pointer;
        }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            jobChange();
            jQuery("#submit").click(function () {
                if (parseInt(jQuery("#txtNum").val()) < 1)
                    jAlert("数量必须大于0，如安全产品数量不足，请更换其他厂商", "提示");
                else if (jQuery("#customCode").val() == "" || jQuery("#companyName").val() == "" || jQuery("#txtPhone").val() == "")
                    jAlert("请完整填写信息", "提示");
                else if (jQuery("#jobID").val() != '') {
                    jQuery("#hBar").val("");
                    jQuery.ajax({
                        type: "POST",
                        dataType: "json",
                        url: "../Ajax/SpotInput.ashx",
                        data: $('#spotform').serialize(),
                        success: function (data) {
                            if (data.error == "") {
                                jConfirm("提交成功，是否继续添加工单项?", "提示", function (r) {
                                    if (r == true) {
                                        jQuery("#customCode").attr("disabled", "disabled");
                                        jQuery("#companyName").attr("disabled", "disabled");
                                        jQuery("#jobSelect").attr("disabled", "disabled");
                                        jQuery("#jobSelect").trigger("liszt:updated");
                                        jQuery("#txtPhone").attr("disabled", "disabled");
                                        jQuery("#txtRemark").attr("disabled", "disabled");
                                        jQuery("#jobID").val(data.msg);
                                        jQuery("#hjobID").val(data.msg);
                                    }
                                    else {
                                        Reset();
                                    }
                                    jobChange();
                                });
                            }
                            else
                                jAlert("提交数据失败！" + data.error, "提示");
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                        }
                    });
                }
                else {
                    jPrompt("请扫描文件袋条形码", "", "提示", function (obj) {
                        if (obj != null) {
                            jQuery("#hBar").val(obj);
                            jQuery.ajax({
                                type: "POST",
                                dataType: "json",
                                url: "../Ajax/SpotInput.ashx",
                                data: $('#spotform').serialize(),
                                success: function (data) {
                                    if (data.error == "") {
                                        jConfirm("提交成功，是否继续添加工单项?", "提示", function (r) {
                                            if (r == true) {
                                                jQuery("#customCode").attr("disabled", "disabled");
                                                jQuery("#companyName").attr("disabled", "disabled");
                                                jQuery("#jobSelect").attr("disabled", "disabled");
                                                jQuery("#jobSelect").trigger("liszt:updated");
                                                jQuery("#txtPhone").attr("disabled", "disabled");
                                                jQuery("#txtRemark").attr("disabled", "disabled");
                                                jQuery("#jobID").val(data.msg);
                                                jQuery("#hjobID").val(data.msg);
                                            }
                                            else {
                                                Reset();
                                            }
                                            jobChange();
                                        });
                                    }
                                    else
                                        jAlert("提交数据失败！" + data.error, "提示");
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                                }
                            });
                        }
                    });
                }
            });
        }
        function jobChange() {
            jQuery.ajax({
                type: "POST",
                dataType: "json",
                url: "../Ajax/GetJobType.ashx",
                data: "jobType=" + jQuery("#jobSelect").val(),
                success: function (data) {
                    jQuery("#businessSelect").empty();
                    jQuery.each(data.business, function (n, value) {
                        jQuery("#businessSelect").append("<option value='" + value.JobTypeID + "'>" + value.JobName + "</option>");
                    });
                    jQuery("#businessSelect").trigger("liszt:updated");
                    if (jQuery("#jobSelect").val() == "MD" || jQuery("#jobSelect").val() == "UU") {
                        jQuery("#saleSelect").empty();
                        jQuery("#saleSelect").attr("disabled", "disabled");
                        jQuery("#saleSelect").trigger("liszt:updated");
                        jQuery("#remain").css("color", "white");
                        jQuery("#txtNum").spinner({ min: 1, max: 100, increment: 2 });
                    }
                    else {
                        jQuery("#saleSelect").removeAttr("disabled");
                        jQuery("#saleSelect").trigger("liszt:updated");
                        jQuery("#remain").css("color", "red");
                        businessChange();
                    } 
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
        }
        function businessChange() {
            if (jQuery("#jobSelect").val() != "MD" && jQuery("#jobSelect").val() != "UU") {
                jQuery.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "../Ajax/GetSaleList.ashx",
                    data: "jobTypeID=" + jQuery("#businessSelect").val(),
                    success: function (data) {
                        jQuery("#saleSelect").empty();
                        jQuery.each(data.sale, function (n, value) {
                            jQuery("#saleSelect").append("<option value='" + value.Guid + "'>" + value.Name + "</option>");
                        });
                        jQuery("#saleSelect").trigger("liszt:updated");
                        saleChange();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                    }
                });
            }
        }
        function saleChange() {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/GetSaleNum.ashx",
                data: "Guid=" + jQuery("#saleSelect").val(),
                success: function (data) {
                    jQuery("#remainNum").html(data);
                    jQuery("#txtNum").spinner({ min: 1, max: data, increment: 2 });
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
        }
        function getCompany() {
            jQuery.ajax({
                type: "POST",
                dataType: "json",
                url: "../Ajax/GetCompanyName.ashx",
                data: "customCode=" + jQuery("#customCode").val(),
                success: function (data) {
                    if (data.error == "")
                        jQuery("#companyName").val(data.msg);
                    else {
                        jQuery("#companyName").val("");
                        jAlert(data.error, "提示");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
        }
        function Reset() {
            jQuery("#customCode").removeAttr("disabled");
            jQuery("#companyName").removeAttr("disabled");
            jQuery("#jobSelect").removeAttr("disabled");
            jQuery("#jobSelect").trigger("liszt:updated");
            jQuery("#txtPhone").removeAttr("disabled");
            jQuery("#txtRemark").removeAttr("disabled");
            jQuery("#businessSelect").removeAttr("disabled");
            jQuery("#txtNum").removeAttr("disabled");
            jQuery("#jobID").val("");
            jQuery("#customCode").val("");
            jQuery("#companyName").val("");
            jQuery("#txtRemark").val("");
            jQuery("#txtPhone").val("");
            jQuery("#txtNum").val("1");
            jQuery("#hBar").val("");
            jQuery("#hjobID").val("");
        }
    </script>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">现场收单</h1>
        <span class="pagedesc" style="margin: 0 20px;">新建现场取号办理业务的工单.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <form class="stdform" action="" method="post" id="spotform">
            <input type="hidden" id="hBar" runat="server" />
            <input type="hidden" id="hjobID" runat="server" />
            <table class="table">
                <tr>
                    <td class="title">
                        工单号
                    </td>
                    <td class="content">
                        <input type="text" id="jobID" class="longinput" runat="server" disabled="disabled"/>
                    </td>
                    <td class="title"></td>
                    <td class="content"></td>
                </tr>
                <tr>
                    <td class="title">
                        海关编码
                    </td>
                    <td class="content">
                        <input type="text" id="customCode" class="longinput" runat="server" onblur="getCompany();"/>
                    </td>
                    <td class="title">
                        企业名称
                    </td>
                    <td class="content">
                        <input type="text" id="companyName" class="longinput" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="title">
                        工单类型
                    </td>
                    <td class="content">
                        <select id="jobSelect" runat="server" data-placeholder="工单类型" class="chzn-select" style="width:200px;" onchange="jobChange(this);">
                        </select>
                    </td>
                    <td class="title">
                        业务类型
                    </td>
                    <td class="content">
                        <select id="businessSelect" runat="server" data-placeholder="业务类型" class="chzn-select" style="width:200px;" onchange="businessChange(this);">
                        </select>
                    </td>
                    <%--<td class="title">
                        工单状态
                    </td>
                    <td class="content">
                        <select id="flowSelect" runat="server" data-placeholder="工单状态" class="chzn-select" style="width:200px;">
                        </select>
                    </td>--%>
                </tr>
                <tr>
                    <td class="title">
                        安全产品类型
                    </td>
                    <td class="content">
                        <select id="saleSelect" runat="server" data-placeholder="安全产品类型" class="chzn-select" style="width:200px;" onchange="saleChange(this);">
                        </select>
                    </td>
                    <td class="title">
                        数量
                    </td>
                    <td class="content">
                        <input type="text" id="txtNum" class="width50 noradiusright" runat="server"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;<span style="color:red;" id="remain">剩余数量：<span id="remainNum">1</span>份</span>
                    </td>
                </tr>
                <tr>
                    <td class="title">
                        经办人手机
                    </td>
                    <td class="content">
                        <input type="text" id="txtPhone" class="longinput" runat="server" />
                    </td>
                    <td class="title">
                        备注信息
                    </td>
                    <td class="content">
                        <input type="text" id="txtRemark" class="longinput" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;" colspan="4">
                        <button id="submit" onclick="return false;">&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;</button>
                        <button id="reset" onclick="Reset();return false;">&nbsp;&nbsp;重&nbsp;&nbsp;置&nbsp;&nbsp;</button>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>

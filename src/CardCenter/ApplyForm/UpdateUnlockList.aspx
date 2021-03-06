﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUnlockList.aspx.cs" Inherits="CardCenter.ApplyForm.UpdateUnlockList" %>

<%@ Register Src="../ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script>
        jQuery(document).ready(function () {
            if ('<%= listID %>' != '') {
                jQuery("#businessType").attr("disabled", "disabled");
                jQuery("#cardType").attr("disabled", "disabled");
            }
        });
    </script>
    <script type="text/javascript" src="../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.slimscroll.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.smartWizard-2.0.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/custom/forms.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../js/plugins/charCount.js"></script>
    <script type="text/javascript" src="../js/plugins/ui.spinner.min.js"></script>
    <script type="text/javascript" src="../js/plugins/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="../js/custom/elements.js"></script>
    <script type="text/javascript" src="../js/plugins/colorpicker.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.alerts.js"></script>
    <script src="../js/custom/Controller.js"></script>
    <script src="../js/ajaxfileupload.js"></script>
    <script src="../js/custom/Verification.js"></script>
    <title>制卡业务系统-更新解锁</title>
    <script type="text/javascript">
        function Submit() {
            if (UUJobListSaveVerifi()) {
                jQuery.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "../Ajax/UUListSave.ashx",
                    data: $('#form1').serialize(),
                    success: function (msg) {
                        if (msg == "") {
                            jAlert("保存成功", "提示", function () {
                                location.href = "UpdateUnlock.aspx?jobID=" + jQuery("#hJobID").val() + "&type=callback";
                            });
                        }
                        else
                            jAlert("保存数据失败!" + msg, "提示");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                    }
                });
            }
        }
    </script>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <ul class="breadcrumbs">
                <li><a href="../Default.aspx">首页</a></li>
                <li><a href="../Manager/JobList.aspx">工单列表</a></li>
                <li><a href="UpdateUnlock.aspx?jobID=<%= jobID %>&type=callback">更新解锁-工单</a></li>
                <li>更新解锁-工单项</li>
            </ul>
            <div id="tabbed" class="subcontent">
                <form id="form1" class="stdform" method="post" action="" runat="server">
                    <input type="hidden" runat="server" id="hJobID" />
                    <input type="hidden" runat="server" id="hListID" />
                    <div class="pageheader notab">
                        <h1 class="pagetitle">更新解锁业务信息录入</h1>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="title1">
                                业务类型
                            </td>
                            <td class="content1">
                                <select id="businessType" runat="server" data-placeholder="业务类型" class="chzn-select" style="width:200px;">
                                    <option value="0">更新</option>
                                    <option value="1">解锁</option>
                                </select>
                            </td>
                            <td class="title1">
                                卡类型
                            </td>
                            <td class="content1">
                                <select id="cardType" runat="server" data-placeholder="卡类型" class="chzn-select" style="width:200px;">
                                    <option value="1">法人卡</option>
                                    <option value="2">操作员IC卡</option>
                                    <option value="3">操作员IKEY</option>
                                    <option value="4">报关员卡</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">
                                持卡人姓名
                            </td>
                            <td class="content1">
                                <input type="text" id="holdName" class="longinput" runat="server"/>
                            </td>
                            <td class="title1">
                                卡号
                            </td>
                            <td class="content1">
                                <input type="text" id="txtCardNum" class="longinput" runat="server"/>
                            </td>
                        </tr>
                    </table>
                    <div style="margin-top:20px;text-align:center;">
                        <button onclick="Submit();return false;">&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;</button>
                    </div>
                </form>
                <br clear="all" /><br />
            </div><!--#vertical-->
        </div><!--contentwrapper--> 
    </div><!-- centercontent -->
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

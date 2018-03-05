function deleteClick(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/JobDelete.ashx",
                data: "jobID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function completeClick(completeButton) {
    var id = jQuery(completeButton).closest("tr").attr("id");
    jConfirm("是否确定已下载审批回执并完成部门审核?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/ApprovalComplete.ashx",
                data: "jobID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jAlert("反馈成功!", "提示", function () {
                            location.href = "JobList.aspx";
                        });
                    }
                    else
                        jAlert("反馈失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function deleteUUList(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单项?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/UUListDelete.ashx",
                data: "listID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jQuery("#file" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function deleteMDList(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单项?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/MDListDelete.ashx",
                data: "listID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jQuery("#file" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function deleteNAList(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单项?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/NAListDelete.ashx",
                data: "listID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jQuery("#file" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function deleteRIList(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单项?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/RIListDelete.ashx",
                data: "listID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jQuery("#file" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function deleteRMList(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单项?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/RMListDelete.ashx",
                data: "listID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jQuery("#file" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function deleteSLList(deleteButton) {
    var id = jQuery(deleteButton).closest("tr").attr("id");
    jConfirm("是否确定删除工单项?", "提示", function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/SLListDelete.ashx",
                data: "listID=" + id,
                success: function (msg) {
                    if (msg == "") {
                        jQuery("#" + id).remove();
                        jQuery("#file" + id).remove();
                        jAlert("删除成功!", "提示");
                    }
                    else
                        jAlert("删除失败!" + msg, "提示");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });

        }
    });
}

function ajaxFileUpload(id) {

    $.ajaxFileUpload
    (
        {
            url: '../Ajax/UploadFile.aspx?id=' + id, //用于文件上传的服务器端请求地址
            secureuri: false, //是否需要安全协议，一般设置为false
            fileElementId: id, //文件上传域的ID
            dataType: 'json', //返回值类型 一般设置为json
            success: function (data, status)  //服务器成功响应处理函数
            {
                if (typeof (data.error) != 'undefined') {
                    if (data.error != '') {
                        jAlert("上传失败，请联系网站管理员!" + data.error, "提示");
                    } else {
                        jQuery(jQuery("#" + id).next().get(0)).html(data.filename);
                        jQuery("input[name=txt" + id + "]").attr("value", data.filename);
                        jQuery("input[name=h" + id + "]").attr("value", data.guid);
                        jAlert("上传成功!", "提示");
                    }
                }
            },
            error: function (data, status, e)//服务器响应失败处理函数
            {
                jAlert("网络出错，请稍后再试" + e, "提示");
            }
        }
    )
    return false;
}

function typeControl(type) {
    if (type == 'update') {
        jQuery('#tab1').removeClass("selected");
        jQuery('#tab1').addClass("done");
        jQuery('#tab1').attr("isdone", "1");
        jQuery('#wiz1step2_1').hide();
        jQuery('#tab2').removeClass("disabled");
        jQuery('#tab2').addClass("selected");
        jQuery('#tab2').attr("isdone", "1");
        jQuery('#wiz1step2_2').show();
        jQuery('#tab3').removeClass("disabled");
        jQuery('#tab3').addClass("done");
        jQuery('#tab3').attr("isdone", "1");
        jQuery('#wiz1step2_3').hide();
        jQuery('#tab4').removeClass("disabled");
        jQuery('#tab4').addClass("done");
        jQuery('#tab4').attr("isdone", "1");
        jQuery('#wiz1step2_4').hide();
        jQuery('#tab5').removeClass("disabled");
        jQuery('#tab5').addClass("done");
        jQuery('#tab5').attr("isdone", "1");
        jQuery('#wiz1step2_5').hide();

        $("#tab2").trigger("click");
    }
    if (type == 'callback') {
        jQuery('#tab1').removeClass("selected");
        jQuery('#tab1').addClass("done");
        jQuery('#tab1').attr("isdone", "1");
        jQuery('#wiz1step2_1').hide();
        jQuery('#tab2').removeClass("disabled");
        jQuery('#tab2').addClass("done");
        jQuery('#tab2').attr("isdone", "1");
        jQuery('#wiz1step2_2').hide();
        jQuery('#tab3').removeClass("disabled");
        jQuery('#tab3').addClass("done");
        jQuery('#tab3').attr("isdone", "1");
        jQuery('#wiz1step2_3').hide();
        jQuery('#tab4').removeClass("disabled");
        jQuery('#tab4').addClass("selected");
        jQuery('#tab4').attr("isdone", "1");
        jQuery('#wiz1step2_4').show();
        jQuery('#tab5').removeClass("disabled");
        jQuery('#tab5').addClass("done");
        jQuery('#tab5').attr("isdone", "1");
        jQuery('#wiz1step2_5').hide();

        $("#tab4").trigger("click");
    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewlyAddedListFR.aspx.cs" Inherits="CardCenter.ApplyForm.NewlyAddedListFR" %>

<%@ Register Src="../ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
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
    <title>制卡业务系统-新增业务</title>
    <script type="text/javascript">
        function ExpanCloseApplyForm(obj) {
            var dispaly = $("#applyfrominfo").css("display");
            if (dispaly == "none") {
                $(obj).removeClass("expandarrow");
                $(obj).addClass("closearrow");
                $(obj).attr("title", "收起非必填信息");
                $(obj).children("img").attr("src", "../images/customs/arrow2.png")
            }
            else {
                $(obj).removeClass("closearrow");
                $(obj).addClass("expandarrow");
                $(obj).attr("title", "展开非必填信息");
                $(obj).children("img").attr("src", "../images/customs/arrow1.png")
            }
            $("#applyfrominfo").slideToggle();
        }

        jQuery(document).ready(function () {
            jQuery(".datetime").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1980:2020'
            });

            NWChange(jQuery("#selectNW").val());

            jQuery("#selectNW").change(function () {
                NWChange(jQuery(this).val());
            });
        });

        function Submit() {
            //去掉禁用,对商事平台中获取的数据禁用，现在提交时必须去掉禁用，否则serialize()取不到数据
            removedisabled();

            if (FRSaveVerifi()) {
                jQuery.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "../Ajax/NALogicalCheckFR.ashx",
                    data: $('#form1').serialize(),
                    success: function (msg) {
                        if (msg == "1") {
                            jAlert("当前工单中已添加" + jQuery("#txtFDDBR_QS").val() + "(" + jQuery("#txtZJHM_QS").val() + ")" + "的法人卡信息，请勿重复提交！", "提示");
                        }
                        else if (msg == "2") {
                            jConfirm("历史工单中存在已办理(已提交)" + jQuery("#txtFDDBR_QS").val() + "(" + jQuery("#txtZJHM_QS").val() + ")" + "的法人卡信息，是否继续提交？", "提示", function (r) {
                                if (r == true)
                                    DataInsert();
                            });
                        }
                        else {
                            DataInsert();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                    }
                });
            }
        }

        function DataInsert() {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/NAListSaveFR.ashx",
                data: $('#form1').serialize(),
                success: function (msg) {
                    if (msg == "") {
                        jAlert("保存成功", "提示", function () {
                            location.href = "NewlyAdded.aspx?jobID=" + jQuery("#hJobID").val() + "&type=callback";
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

        //去掉禁用
        function removedisabled() {
            $('#txtQYZWMC_QS').removeAttr('disabled'); //企业名称
            $('#txtFDDBR_QS').removeAttr('disabled');//法人代表
            $('#txtJYFW_QS').removeAttr('disabled'); //经营范围
            $('#txtZCZJ_QS').removeAttr('disabled'); //注册资本币制
            $('#dlZCZJBZ_QS').removeAttr('disabled');//绑定币种
            $('#dtCLRQ_QS').removeAttr('disabled'); //成立日期
            $('#txtYYQX_QS').removeAttr('disabled'); //营业期限
            //$('#dlQYLX_QS').removeAttr('disabled');//企业类型
            $('#dtFZRQ_QS').removeAttr('disabled');//发证日期
            $('#txtQYDZ_QS').removeAttr('disabled');//地址
        }

        function setdisabled() {
            $('#txtQYZWMC_QS').attr('disabled', 'disabled'); //企业名称
            $('#txtFDDBR_QS').attr('disabled', 'disabled')//法人代表
            $('#txtJYFW_QS').attr('disabled', 'disabled') //经营范围
            $('#txtZCZJ_QS').attr('disabled', 'disabled') //注册资本币制
            $('#dlZCZJBZ_QS').attr('disabled', 'disabled')//绑定币种
            $('#dtCLRQ_QS').attr('disabled', 'disabled') //成立日期
            $('#txtYYQX_QS').attr('disabled', 'disabled') //营业期限
            //$('#dlQYLX_QS').attr('disabled', 'disabled')//企业类型
            $('#dtFZRQ_QS').attr('disabled', 'disabled')//发证日期
            $('#txtQYDZ_QS').attr('disabled', 'disabled')//地址
        }
        //从商事平台中获取数据
        function LoadData() {

            var urlPar = "GetXSPTData";
            var strZCH = $('#txtSHTYXYDM_QS').val();
            var strdata = "uniscid=" + strZCH;
            if (strZCH.trim() == "") {
                jAlert("统一社会信用代码不能为空", "提示");

                return;
            }
            jQuery.ajax({
                type: "POST",                   //提交方式
                url: "../Ajax/PageLogicHelper.ashx?Action=" + urlPar,   //提交的页面/方法名
                data: strdata,
                dataType: "json",               //类型
                success: function (data) {
                    if (!!data) {
                        if (data.length > 0) {

                            var rd = data[0];
                            //zch,mc,fddbr,zyxmlb,jyfw,rjzczb,basszb,clrq,yyqx,qylx,hzrq,djjg
                            $('#txtQYZWMC_QS').val(rd.MC); //企业名称
                            $('#txtFDDBR_QS').val(rd.FDDBR);//法人代表
                            $('#txtJYFW_QS').val(rd.JYFW);  //经营范围
                            $('#txtZCZJ_QS').val(rd.RJZCZBVALUE); //注册资本币制
                            //$('#dlZCZJBZ_QS').val(rd.RJZCZBTYPE);//绑定币种
                            //var rmb = '人民币';
                            //if (rd.RJZCZBTYPE.indexOf("人民币") == -1) {
                            //    rmb = rd.RJZCZBTYPE;
                            //}
                            //var dl = $('#dlZCZJBZ_QS');
                          
                            //for (var i = 0; i < dl[0].length; i++) {
                            //    if (dl[0][i].text.indexOf(rmb) != -1) {
                            //        dl[0][i].selected = true;
                            //        break;
                            //    }
                            //    //else {
                            //    //    dl[0][i].selected = false;
                                   
                            //    }
                            //}
                            
                            

                            $('#dtCLRQ_QS').val(rd.CLRQ); //成立日期
                            if (rd.YYQX == null || rd.YYQX == "null"||rd.YYQX == "")
                            {
                                rd.YYQX = "长期";
                            }
                            $('#txtYYQX_QS').val(rd.YYQX); //营业期限
                            $('#dlQYLX_QS').val(rd.QYLX);//企业类型
                            $('#dtFZRQ_QS').val(rd.HZRQ);//发证日期

                            $('#txtQYDZ_QS').val(rd.DZ);//地址
                            //添架禁用
                            setdisabled();

                            

                        } else {
                            //$('#txtQYZWMC_QS').val(''); //企业名称
                            //$('#txtFDDBR_QS').val('');//法人代表
                            //$('#txtJYFW_QS').val('');  //经营范围
                            //$('#txtZCZJ_QS').val(''); //注册资本币制
                            //$('#txtZCZJ_QS').val('');//绑定币种
                            //$('#dtCLRQ_QS').val(''); //成立日期
                            //$('#txtYYQX_QS').val(''); //营业期限
                            //$('#dlQYLX_QS').val('');//企业类型
                            //$('#dtFZRQ_QS').val('');//发证日期

                            //$('#txtQYDZ_QS').val('');//地址
                            //去掉禁用
                            removedisabled();
                            //var rmb = '人民币';                           
                            //var dl = $('#dlZCZJBZ_QS');
                            //for (var i = 0; i < dl[0].length; i++) {
                            //    if (dl[0][i].text.indexOf(rmb) != -1) {
                            //        dl[0][i].selected = true;
                            //    }
                            //    else {
                            //        dl[0][i].selected = false;
                            //    }
                            //}
                        }
                    }
                },
                error: function (err) {

                    jAlert("网络出错，请稍后再试" + err, "提示");
                }
            });


        }
    </script>
    <style>
        .NAStype {
            padding: 8px;
            text-align: center;
            font-weight: bold;
            font-size: 14px;
            color: #1A6BAE;
            border: 1px solid #ddd;
        }

            .NAStype:hover {
                cursor: pointer;
            }
    </style>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <ul class="breadcrumbs">
                <li><a href="../Default.aspx">首页</a></li>
                <li><a href="../Manager/JobList.aspx">工单列表</a></li>
                <li><a href="NewlyAdded.aspx?jobID=<%= jobID %>&type=callback">新增业务-工单</a></li>
                <li>新增业务-法人卡(新证)</li>
            </ul>
            <div id="tabbed" class="subcontent">
                <form id="form1" class="stdform" method="post" action="" runat="server">
                    <input type="hidden" runat="server" id="hJobID" />
                    <input type="hidden" runat="server" id="hListID" />
                    <div class="pageheader notab">
                        <h1 class="pagetitle">新增法人卡信息录入</h1>
                        <span class="pagedesc">新入网用户如需同时办理操作员IC卡、IKEY、报关员卡，需要录入新增法人卡信息后同时新增其他卡信息，再一并提交工单。</span>
                    </div>
                    <table class="table">
                        
                        <tr>
                            <td class="title1 Required">统一社会信用代码</td>
                            <td class="content1" title="按照《工商营业执照》中“统一社会信用代码”填写">
                                <input type="text" id="txtSHTYXYDM_QS" class="longinput" runat="server" onblur="LoadData()" />
                            </td>
                            <td class="title1 Required">企业中文名称</td>
                            <td class="content1" title="按照《工商营业执照》中“名称”栏填写">
                                <input type="text" id="txtQYZWMC_QS" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">企业地址</td>
                            <td class="content1" title="按照《工商营业执照》中“住所”栏填写">
                                <input type="text" id="txtQYDZ_QS" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">法定代表人</td>
                            <td class="content1" title="按照《工商营业执照》中“法定代表人”栏填写">
                                <input type="text" id="txtFDDBR_QS" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">企业类型</td>
                            <td class="content1" title="按照《工商营业执照》中“类型”栏选择填写">
                                <select id="dlQYLX_QS" runat="server" data-placeholder="企业类型" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                            <td class="title1 Required">法人类型</td>
                            <td class="content1" title="按实际情况选择填写">
                                <select id="dlFRLX_QS" runat="server" data-placeholder="法人类型" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">注册资金（万）</td>
                            <td class="content1" title="按照《工商营业执照》中“注册资本”栏填写">
                                <input type="text" id="txtZCZJ_QS" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">注册资金币制</td>
                            <td class="content1" title="按实际情况选择填写">
                                <%--不能加样式，不然JS知不怎样控制选择币制class="chzn-select"--%>
                                <select id="dlZCZJBZ_QS" runat="server" data-placeholder="注册资金币制"   style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">法人证件类型</td>
                            <td class="content1" title="按实际情况选择填写">
                                <select id="dlZJLX_QS" runat="server" data-placeholder="证件类型" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                            <td class="title1 Required">法人证件号码</td>
                            <td class="content1" title="按实际情况选择填写">
                                <input type="text" id="txtZJHM_QS" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">营业期限</td>
                            <td class="content1" title="内资企业默认“长期”，外资企业按照《工商营业执照》中“营业期限”栏填写">
                                <input type="text" id="txtYYQX_QS" class="longinput" runat="server" value="长期" />
                            </td>
                            <td class="title1 Required">企业性质</td>
                            <td class="content1" title="按实际情况选择填写">
                                <select id="dlQYXZ_WH" runat="server" data-placeholder="企业性质" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">工商营业执照发证日期</td>
                            <td class="content1" title="按照《工商营业执照》右下角日期选择填写">
                                <input type="text" id="dtFZRQ_QS" class="longinput datetime" runat="server" />
                            </td>
                            <td class="title1 Required">工商营业执照成立日期</td>
                            <td class="content1" title="按照《工商营业执照》中“成立日期”选择填写">
                                <input type="text" id="dtCLRQ_QS" class="longinput datetime" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">经营范围</td>
                            <td class="content1" title="按照广州市商事主体信息公示平台内信息填写">
                                <input type="text" id="txtJYFW_QS" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">报关类别</td>
                            <td class="content1" title="按实际情况选择填写">
                                <select id="dlBGLB_HG" runat="server" data-placeholder="报关类别" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">内资企业/外资企业</td>
                            <td class="content1" title="按实际情况选择填写">
                                <select id="selectNW" runat="server" data-placeholder="内资/外资企业" class="chzn-select" style="width: 200px;">
                                    <option value="1">内资企业</option>
                                    <option value="2">外资企业</option>
                                </select>
                            </td>
                            <td class="title1 Required">进出口企业代码</td>
                            <td class="content1" title="按照《对外贸易经营者备案登记表》中“进出口企业代码”栏填写">
                                <input type="text" id="txtJCKQYDM_WJM" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">对外贸易经营者备案登记表发证日期</td>
                            <td class="content1" title="按照《对外贸易经营者备案登记表》中底部日期">
                                <input type="text" id="dtFZRQ_WJM" class="longinput datetime" runat="server" />
                            </td>
                            <td class="title1 Required">企业（经营者）类型</td>
                            <td class="content1" title="按照《对外贸易经营者备案登记表》中企业（经营者）类型填写">
                                <input type="text" id="txtQYJYLX_WJM" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">行业代码</td>
                            <td class="content1" title="按实际情况选择填写">
                                <select id="dlHYDM_WH" runat="server" data-placeholder="行业代码" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1 Required">开户银行</td>
                            <td class="content1" title="按实际情况选择填写">
                                <input type="text" id="txtKHYH_HG" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">银行账号</td>
                            <td class="content1" title="按实际情况选择填写">
                                <input type="text" id="txtYHZH_HG" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr class="itemRequiredNZ" style="display: none;">
                            <td class="title1 Required">备案登记表编号</td>
                            <td class="content1" title="按照《对外贸易经营者备案登记表》中备案登记表编号填写">
                                <input type="text" id="txtBADJBBH_WJM_R" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">人民币注册资金（万）</td>
                            <td class="content1" title="按照《工商营业执照》注册资本填写">
                                <input type="text" id="txtRMBZCZJ_WH_R" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr class="itemRequiredWZ" style="display: none;">
                            <td class="title1 Required">批准文号</td>
                            <td class="content1" title="按照《外商投资企业批准证书》批准号填写">
                                <input type="text" id="txtPZWH_WJM_R" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">批准日期</td>
                            <td class="content1" title="按照《外商投资企业批准证书》批准日期填写">
                                <input type="text" id="dtPZRQ_WJM_R" class="longinput datetime" runat="server" />
                            </td>
                        </tr>
                        <tr class="itemRequiredWZ" style="display: none;">
                            <td class="title1 Required">经营年限（年）</td>
                            <td class="content1" title="按照《外商投资企业批准证书》经营年限填写">
                                <input type="text" id="txtJYNX_WJM_R" class="longinput" runat="server" />
                            </td>
                        </tr>
                        <tr class="itemRequiredWZ" style="display: none;">
                            <td class="title1 Required">投资总额（万）</td>
                            <td class="content1" title="按照《外商投资企业批准证书》投资总额填写">
                                <input type="text" id="txtTZZE_WJM_R" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">投资币制</td>
                            <td class="content1" title="按照《外商投资企业批准证书》投资总额填写">
                                <select id="dlTZBZ_WJM_R" runat="server" data-placeholder="投资币制" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                        <tr class="itemRequiredWZ" style="display: none;">
                            <td class="title1 Required">外币注册资金（万）</td>
                            <td class="content1" title="按照《外商投资企业批准证书》注册资本填写">
                                <input type="text" id="txtWBZCZJ_WH_R" class="longinput" runat="server" />
                            </td>
                            <td class="title1 Required">外币注册币种</td>
                            <td class="content1" title="按照《外商投资企业批准证书》注册资本填写">
                                <select id="dlWBZCBZ_WH_R" runat="server" data-placeholder="外币注册币种" class="chzn-select" style="width: 200px;">
                                </select>
                            </td>
                        </tr>
                    </table>
                    <div class="applyFomSubTitle NAStype" onclick="ExpanCloseApplyForm(this)">
                        查看非必填信息
                        <img src="../images/customs/arrow1.png" style="float: right;" />
                    </div>
                    <div id="applyfrominfo" style="display: none">
                        <table class="table">
                            <tr>
                                <td class="title1">企业英文名称</td>
                                <td class="content1">
                                    <input type="text" id="txtQYYWMC_QS" class="longinput" runat="server" />
                                </td>
                                <td class="title1">法人电话</td>
                                <td class="content1" title="按实际情况选择填写">
                                    <input type="text" id="txtFRDH_QS" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">邮政编码</td>
                                <td class="content1" title="按实际情况选择填写">
                                    <input type="text" id="txtYZBM_QS" class="longinput" runat="server" />
                                </td>
                                <td class="title1">传真</td>
                                <td class="content1" title="按实际情况选择填写">
                                    <input type="text" id="txtCZ_QS" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">发证机构名称</td>
                                <td class="content1" title="按照《工商营业执照》右下角工商局印章内容填写">
                                    <input type="text" id="txtFZJGMC_QS" class="longinput" runat="server" value="工商行政管理局" />
                                </td>
                                <td class="title1">发卡机构代码</td>
                                <td class="content1">
                                    <input type="text" id="txtFKJGDM_QS" class="longinput" runat="server" disabled="disabled" value="26" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">海关注册号</td>
                                <td class="content1">
                                    <input type="text" id="txtHGZCH_HG" class="longinput" runat="server" />
                                </td>
                                <td class="title1">备案海关</td>
                                <td class="content1">
                                    <input type="text" id="txtBAHG_HG" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">注册日期</td>
                                <td class="content1">
                                    <input type="text" id="dtZCRQ_HG" class="longinput datetime" runat="server" />
                                </td>
                                <td class="title1">企业注册有效日期</td>
                                <td class="content1">
                                    <input type="text" id="dtYXRQ_HG" class="longinput datetime" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">对外英文地址</td>
                                <td class="content1">
                                    <input type="text" id="txtDWDZ_HG" class="longinput" runat="server" />
                                </td>
                                <td class="title1">行业种类</td>
                                <td class="content1">
                                    <select id="dlHYZL_HG" runat="server" data-placeholder="行业种类" class="chzn-select" style="width: 200px;">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">进出口权批准机关</td>
                                <td class="content1">
                                    <input type="text" id="txtJCKQPZJG_HG" class="longinput" runat="server" />
                                </td>
                                <td class="title1">企业生产类型
                                </td>
                                <td class="content1">
                                    <select id="dlQYSCLX_HG" runat="server" data-placeholder="企业生产类型" class="chzn-select" style="width: 200px;">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">总经理</td>
                                <td class="content1">
                                    <input type="text" id="txtZJL_HG" class="longinput" runat="server" />
                                </td>
                                <td class="title1">电话</td>
                                <td class="content1">
                                    <input type="text" id="txtDH_HG" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">免税额（万美元）</td>
                                <td class="content1">
                                    <input type="text" id="txtMSE_HG" class="longinput" runat="server" />
                                </td>
                                <td class="title1">主要产品</td>
                                <td class="content1">
                                    <input type="text" id="txtZYCP_HG" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">到位资本总额（万美元）</td>
                                <td class="content1">
                                    <input type="text" id="txtDWZBZE_HG" class="longinput" runat="server" />
                                </td>
                                <td class="title1">内销比例（%）</td>
                                <td class="content1">
                                    <input type="text" id="txtNXBL_HG" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">主管部门</td>
                                <td class="content1">
                                    <input type="text" id="txtZGBM_WJM" class="longinput" runat="server" />
                                </td>
                                <td class="title1">住所</td>
                                <td class="content1">
                                    <input type="text" id="txtZS_WJM" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">电子邮箱</td>
                                <td class="content1">
                                    <input type="text" id="txtDZYX_WJM" class="longinput" runat="server" />
                                </td>
                                <td class="title1">工商登记注册日期</td>
                                <td class="content1">
                                    <input type="text" id="dtGSDJZCRQ_WJM" class="longinput datetime" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">注册资金（折美元）</td>
                                <td class="content1">
                                    <input type="text" id="txtZCZJ_WJM" class="longinput" runat="server" />
                                </td>
                                <td class="title1">进出口商品目录</td>
                                <td class="content1">
                                    <input type="text" id="txtJCKSPML_WJM" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">备注（外经贸）</td>
                                <td class="content1">
                                    <input type="text" id="txtBZ_WJM" class="longinput" runat="server" />
                                </td>
                                <td class="title1">核销联系人</td>
                                <td class="content1">
                                    <input type="text" id="txtHXLXR_WH" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">截止有效日期</td>
                                <td class="content1">
                                    <input type="text" id="dtJZYXRQ_WH" class="longinput datetime" runat="server" />
                                </td>
                                <td class="title1">外贸证书号</td>
                                <td class="content1">
                                    <input type="text" id="txtWMZSH_WH" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">外贸证书批准日期</td>
                                <td class="content1">
                                    <input type="text" id="dtWMZSPZRQ_WH" class="longinput datetime" runat="server" />
                                </td>
                                <td class="title1">核销开户日期</td>
                                <td class="content1">
                                    <input type="text" id="dtHXKHRQ_WH" class="longinput datetime" runat="server" />
                                </td>
                            </tr>
                            <tr class="itemNotRequiredNZ" style="display: none;">
                                <td class="title1">备案登记表编号</td>
                                <td class="content1">
                                    <input type="text" id="txtBADJBBH_WJM_NR" class="longinput" runat="server" />
                                </td>
                                <td class="title1">人民币注册资金（万）</td>
                                <td class="content1">
                                    <input type="text" id="txtRMBZCZJ_WH_NR" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr class="itemNotRequiredWZ">
                                <td class="title1">批准文号</td>
                                <td class="content1">
                                    <input type="text" id="txtPZWH_WJM_NR" class="longinput" runat="server" />
                                </td>
                                <td class="title1">批准日期</td>
                                <td class="content1">
                                    <input type="text" id="dtPZRQ_WJM_NR" class="longinput datetime" runat="server" />
                                </td>
                            </tr>
                            <tr class="itemNotRequiredWZ">
                                <td class="title1">经营年限（年）</td>
                                <td class="content1">
                                    <input type="text" id="txtJYNX_WJM_NR" class="longinput" runat="server" />
                                </td>
                            </tr>
                            <tr class="itemNotRequiredWZ">
                                <td class="title1">投资总额（万）</td>
                                <td class="content1">
                                    <input type="text" id="txtTZZE_WJM_NR" class="longinput" runat="server" />
                                </td>
                                <td class="title1">投资币制</td>
                                <td class="content1">
                                    <select id="dlTZBZ_WJM_NR" runat="server" data-placeholder="投资币制" class="chzn-select" style="width: 200px;">
                                    </select>
                                </td>
                            </tr>
                            <tr class="itemNotRequiredWZ">
                                <td class="title1">外币注册资金（万）</td>
                                <td class="content1">
                                    <input type="text" id="txtWBZCZJ_WH_NR" class="longinput" runat="server" />
                                </td>
                                <td class="title1">外币注册币种</td>
                                <td class="content1">
                                    <select id="dlWBZCBZ_WH_NR" runat="server" data-placeholder="外币注册币种" class="chzn-select" style="width: 200px;">
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-top: 20px; text-align: center;">
                        <button onclick="Submit();return false;">&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

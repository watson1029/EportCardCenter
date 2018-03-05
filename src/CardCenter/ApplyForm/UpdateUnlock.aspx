<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUnlock.aspx.cs" Inherits="CardCenter.ApplyForm.UpdateUnlock" %>

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
    <script src="../js/uploadify/jquery.uploadify.js" type="text/javascript"></script>
    <script src="../js/custom/Controller.js"></script>
    <script src="../js/ajaxfileupload.js"></script>
    <script src="../js/custom/Verification.js"></script>

    <title>制卡业务系统-更新解锁</title>
    <script type="text/javascript">

        jQuery(document).ready(function () {
            // Smart Wizard 	
            jQuery('#wizard').smartWizard({ onFinish: onFinishCallback, onLeaveStep: onNextCallback });

            function onFinishCallback() {
                if (JobHeadSaveVerifi()) {
                    jConfirm("请认真核对所填业务，以免影响相关制卡业务办理。信息确认无误点击【确定】，如需修改点击【取消】!", "提示", function (r) {
                        if (r == true)
                            onSave('complete');
                    });
                }
                else
                    return false;
            }

            function onNextCallback(stepObj) {
                switch (stepObj.attr("id"))
                {
                    case "tab1":
                        if (jQuery("#checkAgree").attr("checked") == "checked")
                            return true;
                        else {
                            jAlert("请阅读并同意用户协议许可!", "提示");
                            return false;
                        }
                        break;
                    case "tab2":
                        return JobHeadStep2Verifi();
                        break;
                    case "tab3":
                        if ($("input:radio[name='expressflat']:checked").val() == "上门领取") {
                            return true;
                        }
                        else {
                            return JobHeadStep3Verifi();
                        }
                        break;
                    default:
                        break;
                }
                return true;
            }

            jQuery("#updateForm").keypress(function (e) {
                if (e.keyCode == 13) {
                    e.preventDefault();
                }
            });

            jQuery("input:file").change(function () {
                var id = jQuery(this).attr("id");
                ajaxFileUpload(id);
                $("#" + id).live("change", function () {
                    ajaxFileUpload(id);
                    $("#" + id).replaceWith($("#" + id).clone(true));
                })
            });

            typeControl('<%= type %>');

            radioInit();

            jQuery("input:file").each(function () {
                jQuery(jQuery(this).next("span").get(0)).html(jQuery("#txt" + jQuery(this).attr("id")).val());
            });

            jQuery("input:radio").change(function () {
                if (jQuery("#expressTrue").attr("checked") == "checked") {
                    jQuery(".stepContainer").css("height", "375px");
                    jQuery("#expressMsg").hide();
                    jQuery("#divConsignee").show();
                }
                else {
                    jQuery(".stepContainer").css("height", "267px");
                    jQuery("#divConsignee").hide();
                    jQuery("#expressMsg").show();
                }
            });

            jQuery("#agentName").change(function () {
                jQuery("#consigneeName").val(jQuery(this).val());
            });

            jQuery("#agentPhone").change(function () {
                jQuery("#consigneePhone").val(jQuery(this).val());
            });
        });

        function radioInit() {
            if (jQuery("#expressTrue").attr("checked") == "checked") {
                jQuery("#expressMsg").hide();
                jQuery("#divConsignee").show();
            }
            else {
                jQuery("#divConsignee").hide();
                jQuery("#expressMsg").show();
            } 
        }
        function onSave(type) {
            jQuery("#btnAddList").attr("disabled", "disabled");
            jQuery("#btnAddList").attr("class", "submitdis radius2");
            jQuery("#hSaveType").val(type);
            jQuery.ajax({
                type: "POST",
                dataType: "json",
                url: "../Ajax/UUHeadSave.ashx",
                data: $('#updateForm').serialize() + "&type=" + type,
                success: function (data) {
                    if (data.error == "") {
                        if (type == "complete") {
                            jAlert("保存成功", "提示", function () {
                            //jConfirm("提交成功！您是否愿意配合电子口岸数据分中心填写调查问卷？", "提示", function (r) {
                            //    if (r == true) {
                            //        var iWidth = 450; //弹出窗口的宽度;
                            //        var iHeight = 600; //弹出窗口的高度;
                            //        var iTop = (window.screen.availHeight - 30 - iHeight) / 2; //获得窗口的垂直位置;
                            //        var iLeft = (window.screen.availWidth - 10 - iWidth) / 2; //获得窗口的水平位置;
                            //        window.open("../Question.aspx", "调查问卷", "height=" + iHeight + ", width=" + iWidth + ", top=" + iTop + ", left=" + iLeft + ", scrollbars=yes");
                            //    }
                                location.href = "../Manager/JobList.aspx";
                                window.open("../Express.aspx");
                            });
                        }
                        else {
                            location.href = "UpdateUnlockList.aspx?jobID=" + data.msg;
                        }
                    }
                    else {
                        if (type == "complete") {
                            jAlert("提交数据失败!" + data.error, "提示");
                        }
                        else {
                            jAlert("暂存数据失败!" + data.error, "提示");
                        }
                        jQuery("#btnAddList").attr("disabled", "");
                        jQuery("#btnAddList").attr("class", "submit radius2");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                    jQuery("#btnAddList").attr("disabled", "");
                    jQuery("#btnAddList").attr("class", "submit radius2");
                }
            });
        }
    </script>
</head>

<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <ul class="breadcrumbs">
                <li><a href="../Default.aspx">首页</a></li>
                <li><a href="../Manager/JobList.aspx">工单列表</a></li>
                <li>更新解锁-工单</li>
            </ul>
            <div id="tabbed" class="subcontent">
                <form id="updateForm" class="stdform" method="post" action="" runat="server">
                <input type="hidden" runat="server" id="hJobID" />
                <input type="hidden" runat="server" id="hSaveType" />
                <div id="wizard" class="wizard">
                    <ul class="tabbedmenu">
                        <li>
                            <a id="tab1" href="#wiz1step2_1">
                                <span class="label">第一步: 用户协议许可</span>
                            </a>
                        </li>
                        <li>
                            <a id="tab2" href="#wiz1step2_2">
                                <span class="label">第二步: 企业信息</span>
                            </a>
                        </li>
                        <li>
                            <a id="tab3" href="#wiz1step2_3">
                                <span class="label">第三步: 办理方式 </span>
                            </a>
                        </li>
                        <li>
                            <a id="tab4" href="#wiz1step2_4">
                                <span class="label">第四步: 持卡人信息</span>
                            </a>
                        </li>
                        <% if(!string.IsNullOrEmpty(fileHtml)) %>
                        <% { %>
                            <li>
                                <a id="tab5" href="#wiz1step2_5">
                                    <span class="label">第五步: 随附资料</span>
                                </a>
                            </li>
                        <% } %>
                    </ul>

                    <div id="wiz1step2_1" class="formwiz">
                        <h4>第一步: 用户协议许可</h4>
                        <p>
                            <span class="trfield">
                                <textarea cols="80" rows="10" class="longinput" readonly="readonly">
    在使用中国电子口岸数据中心广州分中心在线制卡系统（以下简称“本系统”）之前，您应当认真阅读并遵守本用户协议，请您务必审慎阅读、充分理解各条款内容，如您对协议有任何疑问的，应向中国电子口岸数据中心广州分中心（以下简称“我中心”）客服咨询。
当您按照页面提示阅读并勾选“我已经阅读并同意用户许可协议”，即表示您已充分阅读、理解并同意接受本协议的全部内容的约束。您承诺接受并遵守本协议的约定，届时您不应以未阅读本协议的内容或者未获得我中心对您问询的解答等理由，主张本协议无效，或要求撤销本协议，具体协议如下：
    一、用户资料
    （一）企业登录本系统，需使用本企业已在广州海关易通关平台注册的账号和密码，不得使用其它企业的账号密码登录，否则，因此产生的一切后果由企业承担。
    （二）企业使用本系统办理业务时，应正确、完整、真实地填写相关信息和提交我中心要求的资料，并同意我中心保留和使用相关数据，如因信息不正确、不完整、不真实导致的业务办理失败、延误等问题及其他相关后果，一切责任和经济损失由企业承担。
    二、费用缴纳
    （一）企业应按我中心规定的时间期限缴纳业务费用，未按时缴纳费用导致的一切后果由企业承担。
    （二）企业汇款出现多汇、串汇等情况时，款项将被作退款处理。企业申请退款时需向我中心提交退款证明，我中心凭退款证明将款项退回至企业账户,退款过程中产生的银行手续费等相关费用（将在退款中自动扣除）及由此导致的办卡延误等情况，由企业自行承担。
    三、快递须知
    （一）企业须承担文件邮递往来全部邮费，建议选用EMS快递公司邮递寄件，寄件时若发生丢失请自行与快件公司协商解决。
    （二）我中心选择EMS快递公司作为回邮公司，产生费用由企业自行承担。
    （三）企业邮寄的电子口岸制卡业务办理资料应正确、完整、真实，邮寄电子口岸卡须在正面需粘贴标签并注明“企业全称”、“操作员姓名”信息。（如：法人卡应在标注“企业全称”；操作员卡应标注“企业全称+操作员姓名”。）
     如因提供资料不正确、不完整、不真实或未按规定粘贴标签等原因导致的一切后果由企业自行承担。
    （三）企业须在A4规格纸上打印完整的回邮信息和办卡联系邮箱（回邮信息包括：收件单位名称、收件人姓名、邮寄地址、联系电话、联系邮箱等内容）并加盖公章进行确认，如因信息不完整而导致一切后果由企业自行承担。
    （四）我中心邮寄地址：广州市天河区珠江新城华利路61号广州市政务服务中心4楼423-429窗口。 
    四、风险与责任
    （一）若企业提供的资料不真实或不能满足我中心对用户资料的要求，我中心有权拒绝为甲方办理相应的业务。如我中心发现因企业资料失实或者企业未配合及时更正影响协议正常履行的，我中心有权在企业更正前终止相关服务，且我中心无需向企业承担任何责任。
    （二）企业应妥善保管自己的法人卡、操作员卡、IKEY及其他安全产品，若发现丢失或被盗用，必须及时向我中心反馈，并可向公安机关报案，但我中心不承担上述情形对企业所造成的后果。
    （三）企业如通过本系统填写或上传违法及其他违反公序良俗内容的信息，我中心有权终止企业服务。
    （四）如企业将注册用户密码交予他人使用，因此引起的义务与责任仍由企业承担。
    （五）如发生以下任何一种情形，我中心有权随时中断或终止向用户提供服务，且我中心无需向企业承担任何责任，一切后果由企业自行承担。
      1.企业提供资料不真实的；
      2.企业违反服务条款的有关规定的；
      3.企业提出办卡申请半年内，未按规定缴纳相关办卡费用的；
      4.企业在提出办卡申请一年内，尚未办结相关部门审批手续的。
    （六）我中心有对本系统进行升级、改造的权利，有权根据业务发展变更本条款或变更本系统向用户提供的服务内容。一旦发生前述变更，本系统将会在页面上进行提示。如对变更内容有异议，用户可以主动取消本系统的客户服务。如果继续使用本系统服务，则视为同意所变更内容。
    （七）为保证本系统的正常运行，我中心负责定期或不定期对提供网络服务的平台或相关设备进行检修或维护，本系统将会在页面上进行提示，企业在检修或维护期间应暂不使用本系统，如果企业在此期间继续使用本网站，则视为同意承担网络服务中断等情况引发的风险及责任。
    五、本协议最终解释权归中国电子口岸数据中心广州分中心所有。
    联系咨询电话：020-83939000。
                                </textarea>
                            </span> 
                        </p>
                        <p>
                            <span class="formwrapper">
                            	<input type="checkbox" id="checkAgree" checked="checked" /> 我已经阅读并同意用户许可协议.<br />
                            </span>
                        </p>
                    </div><!--#wiz1step2_1-->
                        
                    <div id="wiz1step2_2" class="formwiz">
                        <h4>第二步: 企业信息</h4>
                        <table class="table">
                            <tr>
                                <td class="title1">
                                    经办人姓名
                                </td>
                                <td class="content1">
                                    <input type="text" id="agentName" class="longinput" runat="server"/>
                                </td>
                                <td class="title1">
                                    经办人手机
                                </td>
                                <td class="content1">
                                    <input type="text" id="agentPhone" class="longinput" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">
                                    企业名称
                                </td>
                                <td class="content1">
                                    <input type="text" id="companyName" class="longinput" runat="server" disabled="disabled"/>
                                </td>
                                <td class="title1">
                                    企业地址
                                </td>
                                <td class="content1">
                                    <input type="text" id="companyAddress" class="longinput" runat="server" disabled="disabled"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">
                                    企业代码类别
                                </td>
                                <td class="content1">
                                    <select id="typeSelect" runat="server" data-placeholder="企业代码类别" class="chzn-select" style="width:200px;" disabled="disabled">
                                        <option value="1">1组织机构代码</option>
                                        <option value="2">2社会统一信用编号</option>
                                    </select>
                                </td>
                                <td class="title1">
                                    企业代码
                                </td>
                                <td class="content1">
                                    <input type="text" id="companyCode" class="longinput" runat="server" disabled="disabled"/>
                                </td>
                            </tr>
                        </table>                                                   
                    </div><!--#wiz1step2_2-->
                        
                    <div id="wiz1step2_3">
                        <h4>第三步: 办理方式</h4>
                        <p>
                            <span class="formwrapper1">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;电子口岸卡更新解锁业务除需在本系统提交更新解锁工单申请外，还必须将电子口岸卡带至或快递至制卡点进行写卡操作。企业可按照自身情况在完成工单提交后，前往就近制卡点现场办理写卡，或将卡快递至广州制卡点办理写卡。
                            </span>
							<span class="formwrapper1">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;相关办理方式及填写信息一旦提交不得修改，请注意核对。
							</span>
                            <span class="formwrapper">
                            	<input type="radio" name="expressflat"  checked="true" runat="server" id="expresssFalse" value="上门领取"/>现场办理&nbsp;&nbsp;
								<input type="radio" name="expressflat" runat="server" id="expressTrue"  value="快递"/>快递办理
                            </span>
                        </p>
                        <p id="expressMsg">
                            <span class="formwrapper">
                                制卡点现场办理地点：<a href="../gzeport/pages/14.html" target="_blank"><strong>点此查看广州关区各隶属海关（办事处）制卡点地址及联系方式</strong></a>
                            </span>
                        </p>
                        <table class="table" id="divConsignee">
                            <tr>
                                <td colspan="4">
                                    <span style="display:block;margin:auto 50px;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;快递办理需在本系统提交更新解锁工单申请后，将电子口岸卡快递至广州市政务服务中心制卡点写卡<a href="../Express.aspx" target="_blank"><strong>（点此查看快递单填写要求）</strong></a>，完成写卡操作后电子口岸卡将快递寄回企业，请企业务必仔细填写下方快递寄回收货人姓名、手机号及收货地址。
                                    </span>
								</td>
                            </tr>
							<tr>
                                <td class="title1">
                                    收货人姓名
                                </td>
                                <td class="content1">
                                    <input type="text" id="consigneeName" class="longinput" runat="server"/>
                                </td>
                                <td class="title1">
                                    收货人手机
                                </td>
                                <td class="content1">
                                    <input type="text" id="consigneePhone" class="longinput" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="title1">
                                    收货人地址
                                </td>
                                <td colspan="3" class="content1">
                                    <input type="text" id="consigneeAddress" class="longinput" runat="server"/>
                                </td>
                            </tr>
                        </table>
                    </div><!--#wiz1step2_3-->

                    <div id="wiz1step2_4">
                        <h4>第四步: 持卡人信息</h4>
                        <p class="stdformbutton">
                        	<button id="btnAddList" class="submit radius2" runat="server" onClick="onSave('add');return false;">更新解锁卡信息</button>
                        </p>
                        <table cellpadding="0" cellspacing="0" border="0" class="stdtable stdtablequick">
                            <colgroup>
                                <col class="con0" />
                                <col class="con1" />
                                <col class="con0" />
                                <col class="con1" />
                                <col class="con0" />
                            </colgroup>
                            <thead>
                                <tr>
                                    <th class="head0">业务类型</th>
                                    <th class="head1">卡类型</th>
                                    <th class="head0">持卡人姓名</th>
                                    <th class="head1">卡号</th>
                                    <th class="head0">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr id="<%# Eval("ListID") %>">
                                            <td class="con0"><%# Eval("JobName") %></td>
                                            <td class="con1"><%# Eval("CardType") %></td>
                                            <td class="con0"><%# Eval("CardholderName") %></td>
                                            <td class="con1"><%# Eval("CardNum") %></td>
                                            <td class="con0"><a href="UpdateUnlockList.aspx?jobID=<%=jobID %>&listID=<%# Eval("ListID") %>">修改</a>&nbsp;&nbsp;<a href="#" onClick="deleteUUList(this)">删除</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div><!--#wiz1step2_4-->

                    <% if(!string.IsNullOrEmpty(fileHtml)) %>
                    <% { %>
                        <div id="wiz1step2_5">
                            <h4>第五步: 随附资料</h4>
                                <%=fileHtml %>
                        </div><!--#wiz1step2_5-->
                    <% } %>
                </div><!--#wizard-->
                </form>
                    
                <br clear="all" /><br />
                    
                <!-- END OF VERTICAL WIZARD -->
                    
            </div><!--#vertical-->
            
        </div><!--contentwrapper--> 
    </div><!-- centercontent -->    
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>

</html>
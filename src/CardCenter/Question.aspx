<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="CardCenter.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />
    <script type="text/javascript" src="js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="js/custom/forms.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.alerts.js"></script>
    <title>调查问卷</title>
    <style>
        h1{margin-left:50px;}
        .title {font-size:16px;font-weight:bold;}
    </style>
    <script>
        window.onload = function () {
            jQuery("#check4_1").click(function () {
                $('.p5').show();
                $('.p6').hide();
            });
            jQuery("#check4_2").click(function () {
                $('.p5').hide();
                $('.p6').show();
            });

            jQuery("#submit").click(function () {
                var check1 = $('input:radio[name="q1"]:checked').val();
                if (check1 == null) {
                    jAlert("题目1没有选择", "提示");
                    return;
                }
                if ($('#check2_1').attr('checked') != 'checked' && $('#check2_2').attr('checked') != 'checked' && $('#check2_3').attr('checked') != 'checked' && $('#check2_4').attr('checked') != 'checked' && $('#check2_5').attr('checked') != 'checked') {
                    jAlert("题目2没有选择", "提示");
                    return;
                }
                var check3 = $('input:radio[name="q3"]:checked').val();
                if (check3 == null) {
                    jAlert("题目3没有选择", "提示");
                    return;
                }
                var check4 = $('input:radio[name="q4"]:checked').val();
                if (check4 == null) {
                    jAlert("题目4没有选择", "提示");
                    return;
                }
                if (check4 == '1') {
                    var check5 = $('input:radio[name="q5"]:checked').val();
                    if (check5 == null) {
                        jAlert("题目5没有选择", "提示");
                        return;
                    }
                }
                else
                {
                    var check6 = $('input:radio[name="q6"]:checked').val();
                    if (check6 == null) {
                        jAlert("题目6没有选择", "提示");
                        return;
                    }
                    else if (check6 == '7')
                    {
                        txt6_7 = $('#check6_7_txt').val();
                        if (txt6_7 == '') {
                            jAlert("题目6没有填写【其他】", "提示");
                            return;
                        }
                    }
                }
                var check7 = $('input:radio[name="q7"]:checked').val();
                if (check7 == null) {
                    jAlert("题目7没有选择", "提示");
                    return;
                }
                var txt8 = $('#check8_1_txt').val();
                if (txt8 == '') {
                    jAlert("题目8没有填写", "提示");
                    return;
                }
                jQuery.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "Ajax/Question.ashx",
                    data: $('#questionForm').serialize(),
                    success: function (data) {
                        if (data == "") {
                            jAlert("提交成功！感谢您的支持和配合！", "提示", function () {
                                window.close();
                            });
                        }
                        else
                            jAlert("提交失败!" + data, "提示");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                    }
                });
            });
        };
    </script>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <form id="questionForm" class="stdform" method="post" action="" runat="server">
                <div>
                    <h1 style="text-align:center;">调查问卷题目</h1>
                    <p>
                        <span class="formwrapper title">1、您办理的电子口岸业务属于以下哪类：</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check1_1" name="q1" value="1"/>首次办理电子口岸业务</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check1_2" name="q1" value="2"/>办理本企业的电子口岸业务卡</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check1_3" name="q1" value="3"/>办理本集团下属其他子公司的电子口岸业务卡</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check1_4" name="q1" value="4"/>代办其他企业的电子口岸业务卡</span>
                    </p>
                    <p>
                        <span class="formwrapper title">2、您是通过什么途径了解到广州海关已开通电子口岸业务卡网上办理的（可多选）：</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="checkbox" id="check2_1" name="check2_1" value="1"/>海关现场张贴的通知了解</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="checkbox" id="check2_2" name="check2_2" value="2"/>广州市政务服务中心办理业务时业务人员告知</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="checkbox" id="check2_3" name="check2_3" value="3"/>朋友或其他企业办事人员告知</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="checkbox" id="check2_4" name="check2_4" value="4"/>网上新闻或消息</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="checkbox" id="check2_5" name="check2_5" value="5"/>不知道</span>
                    </p>
                    <p>
                        <span class="formwrapper title">3、您是否知道电子口岸业务通过网上办理和到现场办理的区别：</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check3_1" name="q3" value="1"/>知道</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check3_2" name="q3" value="2"/>不知道</span>
                    </p>
                    <p>
                        <span class="formwrapper"><a href="GuideFile/线下办理模式与线上办理模式对比.doc" target="_blank" style="color:red;">链接：“线下办理”模式与“线上办理”模式对比</a></span>
                    </p>
                    <p>
                        <span class="formwrapper title">4、您是否愿意选择通过网上办理电子口岸业务：</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check4_1" name="q4" value="1"/>愿意（如选择本项，则回答题目5）</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check4_2" name="q4" value="2"/>不愿意（如选择本项，则回答题目6）</span>
                    </p>
                    <p class="p5">
                        <span class="formwrapper title">5、如您选择网上办理，希望通过哪种途径取回办理的电子口岸业务卡：</span>
                    </p>
                    <p class="p5">
                        <span class="formwrapper"><input type="radio" id="check5_1" name="q5" value="1"/>现场领取</span>
                    </p>
                    <p class="p5">
                        <span class="formwrapper"><input type="radio" id="check5_2" name="q5" value="2"/>快递领取</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper title">6、您觉得目前使用广州数据分中心在线制卡系统最大的困难或修改意见是：</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_1" name="q6" value="1"/>注册和实名认证功能</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_2" name="q6" value="2"/>工单资料填写及提交功能</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_3" name="q6" value="3"/>业务操作指引</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_4" name="q6" value="4"/>工单处理反馈功能</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_5" name="q6" value="5"/>工单状态短信通知功能</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_6" name="q6" value="6"/>网上支付功能</span>
                    </p>
                    <p class="p6">
                        <span class="formwrapper"><input type="radio" id="check6_7" name="q6" value="7"/>其他&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" id="check6_7_txt" name="check6_7_txt" style="width:300px;" /></span>
                    </p>
                    <p>
                        <span class="formwrapper title">7、您是否知道在广州关区其他隶属海关（办事处）制卡点也可以办理电子口岸业务：</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check7_1" name="q7" value="1"/>知道</span>
                    </p>
                    <p>
                        <span class="formwrapper"><input type="radio" id="check7_2" name="q7" value="2"/>不知道</span>
                    </p>
                    <p>
                        <span class="formwrapper"><a href="GuideFile/广州关区制卡点基本情况.xls" target="_blank" style="color:red;">链接：广州关区制卡点基本情况</a></span>
                    </p>
                    <p>
                        <span class="formwrapper title">8、建议：</span>
                    </p>
                    <p>
                        <span class="formwrapper"><textarea id="check8_1_txt" name="check8_1_txt" style="width:360px;" ></textarea></span>
                    </p>
                    <p>
                        <span class="formwrapper" style="text-align:center;"><button id="submit" onclick="return false;">&nbsp;&nbsp;提&nbsp;&nbsp;交&nbsp;&nbsp;</button></span>
                    </p>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

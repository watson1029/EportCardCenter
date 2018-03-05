<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleList.aspx.cs" Inherits="CardCenter.ApplyForm.SaleList" %>

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
            InitCommodityList();
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
    <title>制卡业务系统-安全产品</title>
    <script type="text/javascript">
        function Submit() {
            if (SLJobListSaveVerifi()) {
                jQuery.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "../Ajax/SLListSave.ashx",
                    data: $('#form1').serialize(),
                    success: function (msg) {
                        if (msg == "") {
                            jAlert("保存成功", "提示", function () {
                                location.href = "Sale.aspx?jobID=" + jQuery("#hJobID").val() + "&type=callback";
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

        //初始化商品列表
        function InitCommodityList()
        {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/Commodity/GetCommodityType.ashx",
                success: function (msg) {
                    jQuery(".commodityFactory").html(msg);
                    if ('<%= listID %>' != '') {
                        jQuery(".commodityFactory").children().each(function () {
                            if (jQuery(this).children().children().html() == '<%= cObj.CommodityType %>')
                                factoryClick(jQuery(this).children());
                        });
                    }
                    else
                        factoryClick(jQuery("#fr0"));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
        }
        
        //厂商列表点击
        function factoryClick(obj)
        {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/Commodity/GetCommodityDetal.ashx",
                data: "type=" + jQuery(obj).children().html(),
                success: function (msg) {
                    jQuery(".commodityDetal").html(msg);
                    if ('<%= listID %>' != '') {
                        jQuery(".commodityDetal").children().each(function () {
                            if (jQuery(this).children().attr("id") == '<%= cObj.Guid %>')
                                commodityClick(jQuery(this).children());
                        });
                    }
                    else
                        jQuery("#hCommodityID").val("");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
            jQuery(obj).parents('.commodityFactory').children().each(function () {
                var radio = jQuery(this).children();
                if (radio.is(jQuery(obj)))
                    radio.css('border-color', '#0B5996');
                else
                    radio.css('border-color', '#fff');
            });
        }

        //商品列表点击
        function commodityClick(obj)
        {
            jQuery("#hCommodityID").val(jQuery(obj).attr("id"));
            jQuery(obj).parents('.commodityDetal').children().each(function () {
                var radio = jQuery(this).children();
                if (radio.is(jQuery(obj)))
                    radio.css('border-color', '#0B5996');
                else
                    radio.css('border-color', '#fff');
            });
            jQuery("#txtNum").spinner({ min: 1, max: jQuery(obj).children(".remain").attr("count"), increment: 2 });
        }
    </script>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <ul class="breadcrumbs">
                <li><a href="../Default.aspx">首页</a></li>
                <li><a href="../Manager/JobList.aspx">工单列表</a></li>
                <li><a href="SaLe.aspx?jobID=<%= jobID %>&type=callback">安全产品-工单</a></li>
                <li>安全产品-工单项</li>
            </ul>
            <div id="tabbed" class="subcontent">
                <form id="form1" class="stdform" method="post" action="" runat="server">
                    <input type="hidden" runat="server" id="hJobID" />
                    <input type="hidden" runat="server" id="hListID" />
                    <input type="hidden" runat="server" id="hCommodityID" />
                    <div class="pageheader notab">
                        <h1 class="pagetitle">选择安全产品</h1>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="title1">安全产品厂商
                            </td>
                            <td colspan="3">
                                <ul class="commodityFactory">
                                </ul>
                                <a href="Introduce.html" target="_blank">简介：广东南方信息安全产业基地有限公司</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">安全产品类型
                            </td>
                            <td colspan="3">
                                <ul class="commodityDetal">
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <td class="title1">
                                数量
                            </td>
                            <td class="content3">
                                <input type="text" id="txtNum" class="width50 noradiusright" runat="server"/>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockEdit.aspx.cs" Inherits="CardCenter.Management.Manager.Stock.StockEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../js/custom/forms.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/ui.spinner.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <title></title>
    <script>
        window.onload = function () {
            jQuery(".stockNum").change(function () {
                var id = jQuery(this).parents("tr").attr("id");
                var desplay = jQuery("#desplay_" + id).val();
                var actual = jQuery("#actual_" + id).val();
                if (jQuery(this).val() == '0') {
                    jQuery("#" + id).children().eq(3).html(desplay + "份");
                    jQuery("#" + id).children().eq(3).css("color", "");
                    jQuery("#" + id).children().eq(4).html(actual + "份");
                    jQuery("#" + id).children().eq(4).css("color", "");
                }
                else {
                    jQuery("#" + id).children().eq(3).html(EditNote(desplay, jQuery(this).val()));
                    jQuery("#" + id).children().eq(3).css("color", "red");
                    jQuery("#" + id).children().eq(4).html(EditNote(actual, jQuery(this).val()));
                    jQuery("#" + id).children().eq(4).css("color", "red");
                }
            });
        };

        function EditNote(oldNum, editNum) {
            var sum = parseInt(oldNum) + parseInt(editNum);
            var str = "提交前" + oldNum + "份，提交后" + sum + "份.";
            return str;
        }

        function Submit(obj) {
            var id = jQuery(obj).parents("tr").attr("id");
            var desplay = jQuery("#desplay_" + id).val();
            var actual = jQuery("#actual_" + id).val();
            var num = jQuery("#num_" + id).val();
            if (num == "0") {
                jAlert("数量调整不能为0，请重新修改后提交！", "提示");
            }
            else if (parseInt(desplay) + parseInt(num) < 0) {
                jAlert("调整后显示库存不能小于0，请重新修改后提交！", "提示");
            }
            else if (parseInt(actual) + parseInt(num) < 0) {
                jAlert("调整后实际库存不能小于0，请重新修改后提交！", "提示");
            }
            else {
                jConfirm("确认修改" + jQuery("#" + id).children().eq(0).html() + "（" + jQuery("#" + id).children().eq(1).html() + "）库存数量？\n显示库存：" + EditNote(desplay, num) + "\n实际库存：" + EditNote(actual, num), "确认提示", function (cobj) {
                    if (cobj) {
                        jQuery.ajax({
                            type: "POST",
                            dataType: "text",
                            url: "../../Ajax/SaveStock.ashx",
                            data: "Guid=" + id + "&EditNum=" + num,
                            success: function (msg) {
                                if (msg == "") {
                                    jAlert("修改库存成功！", "提示", function () {
                                        window.location.reload();
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
                    }
                });
            }
        }
    </script>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">修改库存信息</h1>
        <span class="pagedesc" style="margin: 0 20px;">修改库存信息。注：显示库存数量 = 实际库存数量 + 提交工单占用库存数量.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <form>
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="stocktable">
            <thead>
                <tr>
                    <th class='head0'>安全产品类型</th>
                    <th class='head1'>安全产品厂商</th>
                    <th class='head0'>销售价格</th>
                    <th class='head1'>显示库存</th>
                    <th class='head0'>实际库存</th>
                    <th class="head1">数量调整（添加份数）</th>
                </tr>
            </thead>
            <tbody>
                <% for (int i = 0; i < stockDt.Rows.Count; i++) %>
                <% { %>
                    <tr id="<%= stockDt.Rows[i]["Guid"].ToString() %>">
                        <td class='con0'><%= stockDt.Rows[i]["CommodityName"].ToString() %></td>
                        <td class='con1'><%= stockDt.Rows[i]["CommodityType"].ToString() + stockDt.Rows[i]["AdditionalAttributes"].ToString() %></td>
                        <td class='con0'><%= stockDt.Rows[i]["SellingPrice"].ToString() + "元" %></td>
                        <td class='con1'><%= stockDt.Rows[i]["StockDesplay"].ToString() + "份" %></td>
                        <td class="con0"><%= stockDt.Rows[i]["StockActual"].ToString() + "份" %></td>
                        <td class="con1"><input type="text" id="num_<%= stockDt.Rows[i]["Guid"].ToString() %>" class="width50 noradiusright stockNum"/><a href="#" style="margin-left:20px;" onclick="return Submit(this)">提交</a></td>
                        <input type="hidden" id="desplay_<%= stockDt.Rows[i]["Guid"].ToString() %>" value="<%= stockDt.Rows[i]["StockDesplay"].ToString() %>"/>
                        <input type="hidden" id="actual_<%= stockDt.Rows[i]["Guid"].ToString() %>" value="<%= stockDt.Rows[i]["StockActual"].ToString() %>"/>
                    </tr>
                <% } %>
            </tbody>
        </table>
            </form>
    </div>
</body>
</html>

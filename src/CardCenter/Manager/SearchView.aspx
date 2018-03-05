<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchView.aspx.cs" Inherits="CardCenter.Manager.SearchView" %>

<%@ Register Src="../ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script src="../js/custom/widgets.js"></script>
    <title>制卡业务系统-自主查询-详情</title>
    <style>
        .table td.title {
            width: 15%;
            text-align: center;
            font-weight: bold;
            background: #fcfcfc;
        }

        .table td.content {
            width: 35%;
            text-align: center;
            background: #fff;
        }
    </style>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <div id="tabs">
                <ul>
                    <li><a href="#tabs-1">工单信息</a></li>
                    <li><a href="#tabs-2">工单项信息</a></li>
                    <li><a href="#tabs-3">工单流程信息</a></li>
                </ul>
                <div id="tabs-1">
                    <div class="contenttitle2">
                        <h3>工单信息</h3>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="title">工单编号</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["JobID"].ToString() %></td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td class="title">工单类型</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["JobName"].ToString() %></td>
                            <td class="title">创建时间</td>
                            <td class="content"><%= DateTime.Parse(viewDt.Tables[0].Rows[0]["CreateTime"].ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                        </tr>
                        <tr>
                            <td class="title">企业名称</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["EnterpriseName"].ToString() %></td>
                            <td class="title">企业代码</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["EnterpriseCode"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">经办人姓名</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["AgentName"].ToString() %></td>
                            <td class="title">经办人电话</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["AgentPhone"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">缴费标识</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["FeeFlat"].ToString() %></td>
                            <td class="title">缴费金额</td>
                            <td class="content"><%= "工本费：" + viewDt.Tables[0].Rows[0]["Fee"].ToString() + "元"%></td>
                        </tr>
                        <tr>
                            <td class="title">工单状态</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["StatusName"].ToString() %></td>
                            <td class="title">提交地点</td>
                            <td class="content"><%= bool.Parse(viewDt.Tables[0].Rows[0]["IsOnline"].ToString()) == true ? "网上交单" : "现场交单" %></td>
                        </tr>
                        <tr>
                            <td class="title">备注</td>
                            <td class="content" colspan="3"><%= viewDt.Tables[0].Rows[0]["Remark"].ToString() %></td>
                        </tr>
                    </table>
                </div>
                <div id="tabs-2">
                    <% for (int i = 0; i < viewDt.Tables[1].Rows.Count; i++) %>
                    <% { %>
                        <div class="contenttitle2">
                            <h3>工单项编号:<%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></h3>
                        </div>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "SL") %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">安全产品厂商</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CommodityType"].ToString() %></td>
                                    <td class="title">安全产品类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["AdditionalAttributes"].ToString() %><%= viewDt.Tables[1].Rows[i]["CommodityName"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">单价</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["SellingPrice"].ToString() %> 元</td>
                                    <td class="title">数量</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["Num"].ToString() %></td>
                                </tr>
                            </table>
                        <% } %>
                        <% else %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">工单项类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                    <td class="title">卡类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                </tr>
                            </table>
                        <% } %>
                        <br clear="all" />
                        <br />
                    <% } %>
                </div>
                <div id="tabs-3">
                    <% for (int i = 0; i < viewDt.Tables[3].Rows.Count; i++) %>
                    <% { %>
                    <div class="contenttitle2">
                        <h3>流程信息<%= i+1 %>:</h3>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="title">流水号</td>
                            <td class="content"><%= viewDt.Tables[3].Rows[i]["Guid"].ToString() %></td>
                            <td class="title">流程状态</td>
                            <td class="content"><%= viewDt.Tables[3].Rows[i]["StatusName"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">提交日期</td>
                            <td class="content"><%= DateTime.Parse(viewDt.Tables[3].Rows[i]["SubmitDate"].ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                            <td class="title">提交用户</td>
                            <td class="content"><%= new CardCenter.DataAccess.ManagerUser().Exists(viewDt.Tables[3].Rows[i]["SubmitUser"].ToString()) ? "工号" + new CardCenter.DataAccess.ManagerUser().GetModel(viewDt.Tables[3].Rows[i]["SubmitUser"].ToString()).UserName : "用户" %></td>
                        </tr>
                        <tr>
                            <td class="title">备注</td>
                            <td class="content" colspan="3"><%= viewDt.Tables[3].Rows[i]["Content"].ToString() %></td>
                        </tr>
                    </table>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

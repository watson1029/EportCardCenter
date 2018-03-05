<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockList.aspx.cs" Inherits="CardCenter.Management.Manager.Stock.StockList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <title></title>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">查询库存信息</h1>
        <span class="pagedesc" style="margin: 0 20px;">查询库存信息。注：显示库存数量 = 实际库存数量 + 提交工单占用库存数量.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="stocktable">
            <thead>
                <tr>
                    <th class='head0'>安全产品类型</th>
                    <th class='head1'>安全产品厂商</th>
                    <th class='head0'>销售价格</th>
                    <th class='head1'>显示库存</th>
                    <th class='head0'>实际库存</th>
                </tr>
            </thead>
            <tbody>
                <% for (int i = 0; i < stockDt.Rows.Count; i++) %>
                <% { %>
                    <tr>
                        <td class='con0'><%= stockDt.Rows[i]["CommodityName"].ToString() %></td>
                        <td class='con1'><%= stockDt.Rows[i]["CommodityType"].ToString() + stockDt.Rows[i]["AdditionalAttributes"].ToString() %></td>
                        <td class='con0'><%= stockDt.Rows[i]["SellingPrice"].ToString() + "元" %></td>
                        <td class='con1'><%= stockDt.Rows[i]["StockDesplay"].ToString() + "份" %></td>
                        <td class="con0"><%= stockDt.Rows[i]["StockActual"].ToString() + "份" %></td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</body>
</html>

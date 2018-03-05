<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="CardCenter.Management.Manager.JobList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.alerts.js"></script>
    <script type="text/javascript" src="../js/custom/tables.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../js/custom/Controller.js"></script>
    <title>制卡业务系统-工单列表</title>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">最近工单</h1>
        <span class="pagedesc" style="margin: 0 20px;">办理15天内企业提交的工单.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="dyntable">
            <colgroup>
                <col class="con0" />
                <col class="con1" />
                <col class="con0" />
                <col class="con1" />
                <col class="con0" />
                <col class="con1" />
                <col class="con0" />
                <col class="con1" />
            </colgroup>
            <thead>
                <tr>
                    <th class="head0">工单编号</th>
                    <th class="head1">企业名称</th>
                    <th class="head0">业务类型</th>
                    <th class="head1">申请时间</th>
                    <th class="head0">提交方式</th>
                    <th class="head1">缴费标识</th>
                    <th class="head0">状态</th>
                    <th class="head1">文件袋编号</th>
                    <th class="head0">操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater id="repeater" runat="server">
                    <ItemTemplate>
                        <tr id="<%# ((System.Data.DataRow)Container.DataItem)["JobID"] %>">
                            <td class="con0"><%# ((System.Data.DataRow)Container.DataItem)["JobID"] %></td>
                            <td class="con1"><%# ((System.Data.DataRow)Container.DataItem)["EnterpriseName"] %></td>
                            <td class="con0"><%# ((System.Data.DataRow)Container.DataItem)["JobName"] %></td>
                            <td class="con1"><%# DateTime.Parse(((System.Data.DataRow)Container.DataItem)["CreateTime"].ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                            <td class="con0"><%# bool.Parse(((System.Data.DataRow)Container.DataItem)["IsOnline"].ToString()) == true ? "网上交单" : "现场交单" %></td>
                            <td class="con0"><%# ((System.Data.DataRow)Container.DataItem)["FeeFlat"] %></td>
                            <td class="con1"><%# ((System.Data.DataRow)Container.DataItem)["StatusName"] %></td>
                            <td class="con0"><%# ((System.Data.DataRow)Container.DataItem)["BarCode"] %></td>
                            <td class="con1"><a href='View.aspx?jobID=<%# ((System.Data.DataRow)Container.DataItem)["JobID"] %>&jobType=<%# ((System.Data.DataRow)Container.DataItem)["JobType"] %>&type=view' target="_blank">查看</a><%# !((System.Data.DataRow)Container.DataItem)["StatusName"].ToString().Contains("已办结") && !((System.Data.DataRow)Container.DataItem)["StatusName"].ToString().Contains("退单") ? BindEdit(((System.Data.DataRow)Container.DataItem)["JobID"].ToString(), ((System.Data.DataRow)Container.DataItem)["JobType"].ToString()) : "" %><%# ((System.Data.DataRow)Container.DataItem)["FeeFlat"].ToString().Contains("待缴费") && !((System.Data.DataRow)Container.DataItem)["StatusName"].ToString().Contains("已办结") ? BindFeeButton(((System.Data.DataRow)Container.DataItem)["JobID"].ToString()) : "" %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</body>
</html>
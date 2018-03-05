<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceList.aspx.cs" Inherits="CardCenter.Management.Manager.InvoiceList" %>

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
    <title>制卡业务系统-发票列表</title>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">发票列表</h1>
        <span class="pagedesc" style="margin: 0 20px;">财务人员确认发票信息.</span>
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
            </colgroup>
            <thead>
                <tr>
                    <th class="head0">工单编号</th>
                    <th class="head1">企业名称</th>
                    <th class="head0">业务类型</th>
                    <th class="head1">申请时间</th>
                    <th class="head0">提交方式</th>
                    <th class="head1">缴费金额</th>
                    <th class="head0">操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater id="repeater" runat="server">
                    <ItemTemplate>
                        <tr id="<%# Eval("JobID") %>">
                            <td class="con0"><%# Eval("JobID") %></td>
                            <td class="con1"><%# Eval("EnterpriseName") %></td>
                            <td class="con0"><%# Eval("JobName") %></td>
                            <td class="con1"><%# DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                            <td class="con0"><%# bool.Parse(Eval("IsOnline").ToString()) == true ? "网上交单" : "现场交单" %></td>
                            <td class="con1"><%# Eval("Fee") %>元</td>
                            <td class="con0"><a href='View.aspx?jobID=<%# Eval("JobID") %>&jobType=<%# Eval("JobType") %>&type=view' target="_blank">查看</a>&nbsp;&nbsp;<a href='View.aspx?jobID=<%# Eval("JobID") %>&jobType=<%# Eval("JobType") %>&type=edit' target='_blank'>处理</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</body>
</html>
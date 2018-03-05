<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryList.aspx.cs" Inherits="CardCenter.Management.Manager.HistoryList" %>

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

    <script type="text/javascript" src="../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js/custom/forms.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.tagsinput.min.js"></script>
    <script type="text/javascript" src="../js/plugins/charCount.js"></script>
    <script type="text/javascript" src="../js/plugins/ui.spinner.min.js"></script>
    <script type="text/javascript" src="../js/plugins/chosen.jquery.min.js"></script>

    <title>制卡业务系统-历史工单</title>
    <style>
        .table td.title {
            width:10%;
            text-align:center;
            font-weight:bold;
            background: #fcfcfc;
        }
        .table td.content {
            width:20%;
            text-align:left;
            background: #fff;
        }
        #add:hover {
            cursor:pointer;
        }
    </style>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">历史工单</h1>
        <span class="pagedesc" style="margin: 0 20px;">查询企业提交的工单.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <form class="stdform" action="" method="post" id="spotform" runat="server">
            <table class="table">
                <tr>
                    <td class="title">
                        工单号
                    </td>
                    <td class="content">
                        <input type="text" id="jobID" class="longinput" runat="server"/>
                    </td>
                    <td class="title">
                        企业名称
                    </td>
                    <td class="content">
                        <input type="text" id="companyName" class="longinput" runat="server" />
                    </td>
                    <td class="title">
                        业务类型
                    </td>
                    <td class="content">
                        <select id="jobSelect" runat="server" data-placeholder="业务类型" class="chzn-select" style="width:200px;" onchange="jobChange(this);">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;" colspan="6">
                        <asp:Button ID="search" Text="&nbsp;&nbsp;查&nbsp;&nbsp;询&nbsp;&nbsp;" runat="server" OnClick="search_Click" />
                    </td>
                </tr>
            </table>
        </form>

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
                        <tr id="<%# Eval("JobID") %>">
                            <td class="con0"><%# Eval("JobID") %></td>
                            <td class="con1"><%# Eval("EnterpriseName") %></td>
                            <td class="con0"><%# Eval("JobName") %></td>
                            <td class="con1"><%# DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                            <td class="con0"><%# bool.Parse(Eval("IsOnline").ToString()) == true ? "网上交单" : "现场交单" %></td>
                            <td class="con0"><%# Eval("FeeFlat") %></td>
                            <td class="con1"><%# Eval("StatusName") %></td>
                            <td class="con0"><%# Eval("BarCode") %></td>
                            <td class="con1"><a href='View.aspx?jobID=<%# Eval("JobID") %>&jobType=<%# Eval("JobType") %>&type=view' target="_blank">查看</a><%# !Eval("StatusName").ToString().Contains("已办结") && !Eval("StatusName").ToString().Contains("退单") ? BindEdit(Eval("JobID").ToString(), Eval("JobType").ToString()) : "" %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</body>
</html>

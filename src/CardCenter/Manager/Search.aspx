<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CardCenter.Manager.Search" %>

<%@ Register Src="../ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
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
    <title>制卡业务系统-自主查询</title>
</head>
<body>
    <div class="centercontent">
        <form class="stdform" action="" method="post" id="flowform" runat="server">
            <div style="margin-top:50px;margin-left:20px;">
                <input type="text" id="txtSearch" class="smallinput" runat="server" value="输入海关编码进行查询.." onfocus="if($(this).val()=='输入海关编码进行查询..')$(this).val('');" onblur="if($(this).val()=='')$(this).val('输入海关编码进行查询..');"/>
                <asp:Button ID="btnSearch" CssClass="submit radius2 button" runat="server" Text="&nbsp;&nbsp;查&nbsp;&nbsp;询&nbsp;&nbsp;" OnClick="btnSearch_Click" />
            </div>
        </form>
        <div id="contentwrapper" class="contentwrapper">
            <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="dyntable">
                <colgroup>
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
                        <th class="head1">业务类型</th>
                        <th class="head0">申请时间</th>
                        <th class="head1">缴费标识</th>
                        <th class="head0">工单状态</th>
                        <th class="head1">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater id="repeater" runat="server">
                        <ItemTemplate>
                            <tr id="<%# Eval("JobID") %>">
                                <td class="con0"><%# Eval("JobID") %></td>
                                <td class="con1"><%# Eval("JobName") %></td>
                                <td class="con0"><%# DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                                <td class="con1"><%# Eval("FeeFlat") %></td>
                                <td class="con0"><%# Eval("StatusName") %></td>
                                <td class="con1"><a target="_blank" href='SearchView.aspx?jobID=<%# Eval("JobID") %>&jobType=<%# Eval("JobType") %>'>查看</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

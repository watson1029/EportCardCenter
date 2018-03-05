<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="CardCenter.Management.Manager.User.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <script type="text/javascript" src="../../js/custom/tables.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.dataTables.min.js"></script>
    <title></title>
</head>
<body>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">修改用户</h1>
        <span class="pagedesc" style="margin: 0 20px;">选择或查找用户进行信息修改.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable" id="usertable">
            <thead>
                <tr>
                    <th class='head0'>用户名</th>
                    <th class='head1'>姓名</th>
                    <th class='head0'>电话号码</th>
                    <th class='head1'>所属部门</th>
                    <th class='head0'>操作</th>
                </tr>
            </thead>
            <tbody>
                <% for (int i = 0; i < userDt.Rows.Count; i++) %>
                <% { %>
                    <tr>
                        <td class='con0'><%= userDt.Rows[i]["UserName"].ToString() %></td>
                        <td class='con1'><%= userDt.Rows[i]["Name"].ToString() %></td>
                        <td class='con0'><%= userDt.Rows[i]["Phone"].ToString() %></td>
                        <td class='con1'><%= new CardCenter.DataAccess.Sys_Department().GetModel(int.Parse(userDt.Rows[i]["Department"].ToString())).DepartmentName %></td>
                        <td class="con0"><a href="UserEdit.aspx?Guid=<%= userDt.Rows[i]["Guid"].ToString() %>">修改</a></td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</body>
</html>

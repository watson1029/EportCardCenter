<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="CardCenter.Management.Manager.Authorize.UserRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.alerts.js"></script>
    <script type="text/javascript" src="../../js/custom/tables.js"></script>
    <script type="text/javascript" src="../../js/plugins/jquery.dataTables.min.js"></script>
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
            jQuery('input:checkbox, input:radio, select.uniformselect, input:file').uniform();

            jQuery("input:checkbox").click(function () {
                var userid = jQuery(this).parents("tr").attr("id");
                var authorize = "";
                jQuery(this).parents("tr").children().each(function (index) {
                    if (index != 0) {
                        if (jQuery(this).find("span").attr("class") == "checked") {
                            authorize += jQuery(this).attr("name") + "#";
                        }
                    }
                });
                jQuery.ajax({
                    type: "POST",
                    dataType: "text",
                    url: "../../Ajax/Authorize/UserRole.ashx",
                    data: "userid=" + userid + "&authorize=" + authorize,
                    success: function (data) {
                        if (data != "")
                            jAlert(data);
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
    <div class="pageheader notab">
        <h1 class="pagetitle" style="margin: 0 20px 10px 20px;">授权用户-角色</h1>
        <span class="pagedesc" style="margin: 0 20px;">指定用户所属角色，每个用户可以对应多个角色.</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <table cellpadding="0" cellspacing="0" border="0" class="stdtable">
            <colgroup>
                <col class='con0' />
                <% for (int i = 0; i < roleDt.Rows.Count; i++) %>
                <% { %>
                    <%= i%2 == 0 ? "<col class='con1' />" : "<col class='con0' />" %>
                <% } %>
            </colgroup>
            <thead>
                <tr>
                    <th class='head0'>用户</th>
                    <% for (int i = 0; i < roleDt.Rows.Count; i++) %>
                    <% { %>
                        <%= i%2 == 0 ? string.Format("<th class='head1'>{0}</th>", roleDt.Rows[i]["RoleName"].ToString()) : string.Format("<th class='head0'>{0}</th>", roleDt.Rows[i]["RoleName"].ToString()) %>
                    <% } %>
                </tr>
            </thead>
            <tbody>
                <% for (int i = 0; i < userDt.Rows.Count; i++) %>
                <% { %>
                    <tr id="<%= userDt.Rows[i]["Guid"].ToString() %>">
                        <td class='con0'><%= userDt.Rows[i]["Name"].ToString() %></td>
                        <% for (int j = 0; j < roleDt.Rows.Count; j++) %>
                        <% { %>
                            <%= j%2 == 0 ? string.Format("<td class='con1' name='{0}'>", roleDt.Rows[j]["ID"].ToString()) : string.Format("<td class='con0' name='{0}'>", roleDt.Rows[j]["ID"].ToString())  %>
                                <% if (userDt.Rows[i]["RoleAuthorize"].ToString().IndexOf(roleDt.Rows[j]["ID"].ToString()) >= 0) %>
                                <% { %>
                                    <input type="checkbox" checked="checked" style="width:10px;"/>
                                <% } %>
                                <% else %>
                                <% { %>
                                    <input type="checkbox" style="width:10px;"/>
                                <% } %>
                            </td>
                        <% } %>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</body>
</html>

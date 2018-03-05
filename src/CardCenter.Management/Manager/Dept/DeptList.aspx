<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptList.aspx.cs" Inherits="CardCenter.Management.Manager.Dept.DeptList" %>

 <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>授权页面</title>
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.alerts.js"></script>
    <script src="../../js/plugins/jquery-1.8.3.min.js"></script>
    <script src="../../js/plugins/jquery-labelauty.js"></script>
    <script type="text/javascript">
        //添加行
        function SetRoles(objid, rowType, UserId, RoleId) {

            if (rowType == true) {
                rowType = 1;
                //debugger
                $(objid).removeAttr('data-labelauty');
                $(objid).attr('data-labelauty', "已授权");

            } else {
                rowType = 0;
                $(objid).removeAttr('data-labelauty');
                $(objid).attr('data-labelauty', "未授权");

            }

            var strdata = "roleId=" + RoleId + '&rowType=' + rowType + "&UserId=" + UserId;
            UpdateData(strdata, "Action=UpdateData");
        }
        function StartData() {
            var strroleId = '1';
            var strdata = "roleId=" + strroleId
            LoadData(strdata, "Action=LoadData");
        }
        function LoadData(strdata, urlPar) {

            jQuery.ajax({
                type: "POST",                   //提交方式
                url: "../../Ajax/Dept.ashx?" + urlPar,   //提交的页面/方法名
                data: strdata,
                dataType: "json",               //类型
                success: function (data) {
                    if (!!data) {
                        if (data.length > 0) {
                            for (var i = 0; i < data.length; i++) {
                                var rd = data[i];

                                //rd.rowType, MemuName, MemuCode, OperationCode, OperationName, OperationType, OperationNumber
                                

                                $('#' + rd.DepartmentID + "_" + rd.DistrictID).attr("checked", "checked");
                            }
                        }
                    }
                },
                error: function (err) {

                    //jQuery('.nousername').fadeIn();
                    //jQuery('#errormsg').html(err);
                }
            });


        }
        //提交
        function UpdateData(strdata, urlPar) {


            jQuery.ajax({
                type: "POST",                   //提交方式
                url: "../../Ajax/Dept.ashx?" + urlPar,   //提交的页面/方法名
                data: strdata,
                dataType: "text",               //类型
                success: function (data) {
                    if (data != '保存成功') {
                        alert(data);
                    }
                },
                error: function (err) {

                    //jQuery('.nousername').fadeIn();
                    //jQuery('#errormsg').html(err);
                }
            });


        }

     //启用
        function StartRole(id) {
            var strdata = "UserId=" + id;
            if (confirm("确定要启用吗?")) {
                jQuery.ajax({
                    type: "POST",                   //提交方式
                    url: "../../Ajax/Dept.ashx?Action=StartUserById",   //提交的页面/方法名
                    data: strdata,
                    dataType: "text",               //类型
                    success: function (data) {
                        if (!!data) {
                            if (data == "启用成功") {
                                //刷新页面
                                alert(data);
                                window.location.reload();

                            }
                        }
                    },
                    error: function (err) {

                        alert(err)
                    }
                });
            }
        }
        //删除角色
        function deleteRole(id) {
            var strdata = "UserId=" + id;
            if (confirm("确定要删除吗?")) {
                jQuery.ajax({
                    type: "POST",                   //提交方式
                    url: "../../Ajax/Dept.ashx?Action=DeleteUserById",   //提交的页面/方法名
                    data: strdata,
                    dataType: "text",               //类型
                    success: function (data) {
                        if (!!data) {
                            if (data == "删除成功") {
                                // 移出记录
                                $('#tr_' + id).remove();
                            }
                        }
                    },
                    error: function (err) {

                        alert(err)
                    }
                });
            }
        }
        //初始密码
        function resetPwdRole(id) {
            var strdata = "userId=" + id;
            if (confirm("确定要重置为初始密码吗?")) {
                jQuery.ajax({
                    type: "POST",                   //提交方式
                    url: "../../Ajax/Dept.ashx?Action=ResetPwd",   //提交的页面/方法名
                    data: strdata,
                    dataType: "text",               //类型
                    success: function (data) {
                        if (!!data) {
                            if (data == "重置成功") {
                                // 移出记录
                                alert(data);
                            }
                        }
                    },
                    error: function (err) {

                        alert(err)
                    }
                });
            }
        }

        //增加角色
        function Save() {
            var id = $('#hidId').val()
            var userName = $('#txtUserName').val();
            var name = $('#txtName').val();

            var detpId=$('#dllGroup').val();
          
            if (userName.trim() == "") {
                alert('登录账号不能为空!');
                $('#txtUserName').focus();
                return;
            }
            if (name.trim() == "") {
                alert('名称不能为空!');
                $('#txtName').focus();
                return;
            }
            if (detpId.trim() == "") {
                alert('请选择部门!');
                $('#dllGroup').focus();
                return;
            }

            var action = "AddUser";
            if (!!id) {
                if (id != "") {
                    action = "EditUser";
                }
            }
            var strdata = "Name=" + name + "&UserId=" + id + "&UserName=" + userName + "&DetpId=" + detpId;
            jQuery.ajax({
                type: "POST",                   //提交方式
                url: "../../Ajax/Dept.ashx?Action=" + action,   //提交的页面/方法名
                data: strdata,
                dataType: "text",               //类型
                success: function (data) {
                    if (!!data) {
                        if (data == "保存成功") {
                            //刷新页面
                            alert(data);
                            window.location.reload();

                        }
                        else { alert(data); }
                    }
                },
                error: function (err) {

                    alert(err)
                }
            });

        }
        function EditRole(id, username, name,detpId) {
            $('#hidId').val(id);
            $('#txtUserName').val(username);
            $('#txtUserName').removeAttr("disabled");
            $('#txtUserName').attr("disabled", "disabled");
            $('#txtName').val(name);

            $('#dllGroup').val(detpId);
            $('#txtUserName').focus();
            showAdd(1);
            $('#editType').html('编辑');
        }
        function Clear() {
            $('#hidId').val('');
            $('#txtUserName').val('');
            $('#txtUserName').removeAttr("disabled");

            $('#txtName').val('');
            $('#txtUserName').focus();
            $('#editType').html('新增');
        }



        function showAdd(isShow) {
            if (isShow == '-1') {
                isShow = $('#hidIsShow').val();
                if (isShow == '0')
                    isShow = 1;
                else
                    isShow = 0;
            }
            if (isShow == '1') {
                $('#tbAdd').removeAttr("style");
                $('#tbAdd').attr("style", "display:block");

            } else {
                $('#tbAdd').removeAttr("style");
                $('#tbAdd').attr("style", "display:none");
            }
            $('#hidIsShow').val(isShow);
        }

    </script>
    <script type="text/javascript">
        $(function () {
            /* For zebra striping */
            $("table tr:nth-child(odd)").addClass("odd-row");
            /* For cell text alignment */
            $("table td:first-child, table th:first-child").addClass("first");
            /* For removing the last border */
            $("table td:last-child, table th:last-child").addClass("last");
        });
    </script>
    <style type="text/css">
        table {
            overflow: hidden;
            border: 1px solid #d3d3d3;
            background: #fefefe;
            width: 100%;
            /*margin: 5% auto 0;*/
            -moz-border-radius: 5px; /* FF1+ */
            -webkit-border-radius: 5px; /* Saf3-4 */
            border-radius: 5px;
            -moz-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2);
            -webkit-box-shadow: 0 0 4px rgba(0, 0, 0, 0.2);
        }

        th, td {
            padding: 5px 5px 5px;
            text-align: center;
            margin: 0px;
        }

        th {
            padding-top: 12px;
            text-shadow: 1px 1px 1px #fff;
            background: #e8eaeb;
        }

        td {
            border-top: 1px solid #e0e0e0;
            border-right: 1px solid #e0e0e0;
        }

        tr.odd-row td {
            /*background: #f6f6f6;*/
        }

        td.first, th.first {
            text-align: center;
        }

        td.last {
            border-right: none;
        }

        /* create an arrow that points right */
        div#right {
            width: 0px;
            height: 0px;
            border-top: 20px solid transparent;
            border-bottom: 20px solid transparent;
            border-left: 20px solid green;
        }
    </style>

    <!--开始按钮选择-->
    <link href="../../css/plugins/jquery-labelauty.css" rel="stylesheet" />

    <style>
        ul {
            list-style-type: none;
        }

        li {
            display: inline-block;
        }

        li {
            margin: 0px 0;
        }

        .dowebok {
            margin: 0;
            padding: 0;
        }

        input.labelauty + label {
            font: 12px "Microsoft Yahei";
            padding: 10px,10px,10px,10px;
            color: #808080;
            align-content: center;
        }
    </style>


    <script>
        $(function () {
           
            $(':input').labelauty();
            //初始化页面
            StartData();

        });
    </script>
    <!--结束按钮选择-->


</head>
<body>
    <form id="form1" runat="server">
        <div>
         
            <table cellspacing="0">

                <tr>
                    <th><span style="color: #808080">序号</span></th>
                    <th><span style="color: #808080">部门</span></th>
                    <%= GetRolesHead()  %>
                     
                </tr>
                <asp:Repeater ID="repeater" runat="server">
                    <ItemTemplate>
                        <tr id="tr_<%# Eval("DepartmentID") %>">
                            <td><%#Container.ItemIndex+1%></td>
                            
                            <td><%#Eval("DepartmentName").ToString()%></td>


                            <%# GetRolesDetail( Eval("DepartmentID").ToString())  %>

                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
        </div>
    </form>
</body>
</html>

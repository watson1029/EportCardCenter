<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="CardCenter.Management.Manager.Frame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>广州海关制卡系统管理端</title>
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.flot.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.flot.resize.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.slimscroll.js"></script>
    <script type="text/javascript" src="../js/custom/general.js"></script>
    <script>
        window.onload = function () {
            setIframeHeight(document.getElementById('external-frame'));

            jQuery(".headermenu li").click(function () {
                jQuery(".headermenu li").each(function () {
                    jQuery(this).removeClass("current");
                });
                jQuery(this).addClass("current");
                jQuery(".iconmenu").hide();
                jQuery("#" + jQuery(this).attr("name")).show();
            });
        };

        function setIframeHeight(iframe) {
            if (iframe) {
                var iframeWin = iframe.contentWindow || iframe.contentDocument.parentWindow;
                if (iframeWin.document.body) {
                    iframe.height = iframeWin.document.documentElement.scrollHeight || iframeWin.document.body.scrollHeight;
                }
            }
        };

        function changeTab(param) {
            jQuery.ajax({
                type: "POST",
                dataType: "text",
                url: "../Ajax/Authorize/AuthorizeJudge.ashx",
                data: "param=" + param,
                success: function (url) {
                    jQuery('#mainIFrame').removeAttr("src");
                    jQuery('#mainIFrame').attr("src", url);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    jAlert("网络出错，请稍后再试" + errorThrown, "提示");
                }
            });
        }

        function frameChange(url) {
            jQuery('#mainIFrame').removeAttr("src");
            jQuery('#mainIFrame').attr("src", url);
        }
    </script>
</head>
<body class="withvernav">
    <div class="bodywrapper">
        <div class="topheader">
            <div class="left">
                <h1 class="logo" style="cursor:pointer;" onclick="javascript:frameChange('../Welcome.aspx')">广州海关制卡系统</h1>
                <span class="slogan">电子口岸业务卡在线办理系统—管理端</span>
                <br clear="all" />
            </div><!--left-->

            <div class="right">
                <div class="userinfo">
            	    <img src="../images/user_1/<%= CardCenter.PageBase.CommonObject.ManagerUserInfo.pic %>" alt="" />
                    <span><%= CardCenter.PageBase.CommonObject.ManagerUserInfo.name %></span>
                </div><!--userinfo-->
            
                <div class="userinfodrop">
            	    <div class="avatar">
                	    <a href=""><img src="../images/user_2/<%= CardCenter.PageBase.CommonObject.ManagerUserInfo.pic %>" alt="" /></a>
                    </div><!--avatar-->
                    <div class="userdata">
                	    <h4><%= CardCenter.PageBase.CommonObject.ManagerUserInfo.name %></h4>
                        <span class="email"><%= CardCenter.PageBase.CommonObject.ManagerUserInfo.username %></span>
                        <ul>
                    	    <li><a href="javascript:frameChange('User/PwdEdit.aspx')">修改密码</a></li>
                            <li><a href="javascript:frameChange('../FunctionCoding.aspx')">帮助</a></li>
                            <li><a href="loginOut.aspx">退出</a></li>
                        </ul>
                    </div><!--userdata-->
                </div><!--userinfodrop-->
            </div><!--right-->
        </div><!--topheader-->

        <div class="header" style="height:95px;">
    	    <ul class="headermenu">
                <% foreach (System.Data.DataRow dr in menu.Select("MenuHigherLevel is null", "MenuOrder asc")) %>
                <% { %>
                    <% if(int.Parse(dr["MenuOrder"].ToString()) == 1) %>
                    <% { %>
                        <li class="current" name="<%= dr["MenuCode"].ToString() %>"><a href="#"><span class="<%= dr["MenuClass"].ToString() %>"></span><%= dr["MenuName"].ToString() %></a></li>
                    <% } %>
                    <% else %>
                    <% { %>
                        <li name="<%= dr["MenuCode"].ToString() %>"><a href="#"><span class="<%= dr["MenuClass"].ToString() %>"></span><%= dr["MenuName"].ToString() %></a></li>
                    <% } %>
                <% } %>
            </ul>
            <div class="headerwidget">
        	    <div class="earnings">
            	    <div>
                	    <h4>日期</h4>
                        <h2><%=Time %></h2>
                    </div><!--one_half-->
                </div><!--earnings-->
            </div><!--headerwidget-->
        </div><!--header-->

        <% foreach (System.Data.DataRow dr1 in menu.Select("MenuHigherLevel is null", "MenuOrder asc")) %>
        <% { %>
            <% if(int.Parse(dr1["MenuOrder"].ToString()) == 1) %>
            <% { %>
                <div class="vernav2 iconmenu" id="<%= dr1["MenuCode"].ToString() %>">
            <% } %>
            <% else %>
            <% { %>
                <div class="vernav2 iconmenu" id="<%= dr1["MenuCode"].ToString() %>" style="display:none">
            <% } %>
                <ul>
                    <% foreach(System.Data.DataRow dr2 in menu.Select("MenuHigherLevel=" + dr1["ID"].ToString(), "MenuOrder asc")) %>
                    <% { %>
                        <li><a href="#<%= dr2["MenuCode"].ToString() %>" class="<%= dr2["MenuClass"].ToString() %>"><%= dr2["MenuName"].ToString() %></a>
                            <span class="arrow"></span>
                            <ul id="<%= dr2["MenuCode"].ToString() %>" class="detailmenu">
                                <% foreach(System.Data.DataRow dr3 in menu.Select("MenuHigherLevel=" + dr2["ID"].ToString(), "MenuOrder asc")) %>
                                <% { %>
                                    <li><a href="javascript:changeTab('<%= dr3["MenuCode"].ToString() %>')"><%= dr3["MenuName"].ToString() %></a></li>
                                <% } %>
                            </ul>
                        </li>
                    <% } %>
                </ul>
                <a class="togglemenu"></a>
                <br /><br />
            </div>
        <% } %>
        <div class="centercontent">
            <iframe id="mainIFrame" width="100%" frameborder="0" src="../Welcome.aspx" scrolling="no" onload="setIframeHeight(this)">

            </iframe>
        </div>
    </div>
    
    
    <%--<form id="form1" runat="server">
    </form>--%>
</body>
</html>

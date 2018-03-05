<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CardCenter.Management._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />
    <script type="text/javascript" src="js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="js/custom/general.js"></script>
    <script type="text/javascript" src="js/custom/index.js"></script>
    <title>制卡业务系统-用户登陆</title>
    <script type="text/javascript">

    </script>
</head>
<body class="loginpage">
	<div class="loginbox">
    	<div class="loginboxinner">
        	
            <div class="logo">
            	<h1 class="logo"><span>制卡业务</span></h1>
				<span class="slogan">管理系统</span>
            </div><!--logo-->
            
            <br clear="all" /><br />
            
            <div class="nousername">
				<div class="loginmsg"><span id="errormsg">用户名不能为空.</span></div>
            </div><!--nousername-->
            
            <form id="login" runat="server" method="post">
            	
                <div class="username">
                	<div class="usernameinner">
                    	<input type="text" name="username" id="username" runat="server" />
                    </div>
                </div>
                
                <div class="password">
                	<div class="passwordinner">
                        <asp:TextBox TextMode="Password" runat="server" ID="password"></asp:TextBox>
                    	<%--<input type="password" name="password" id="password" runat="server"/>--%>
                    </div>
                </div>
                
                <button>登录</button>
                
                <div class="keep"><input type="checkbox" id="remember" name="remember"/> 记住密码</div>
            
            </form>
            
        </div><!--loginboxinner-->
    </div><!--loginbox-->


</body>
</html>
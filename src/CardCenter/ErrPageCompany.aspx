<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrPageCompany.aspx.cs" Inherits="CardCenter.ErrPageCompany" %>

<%@ Register Src="ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>制卡业务系统-错误</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <img src="images/customs/error1.jpg" />
        <div style="color:red; font-size:15;">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

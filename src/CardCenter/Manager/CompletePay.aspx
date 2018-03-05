<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompletePay.aspx.cs" Inherits="CardCenter.Manager.CompletePay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>制卡业务系统-支付失败</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <img src="../images/customs/error.jpg" />
        <div style="color:red; font-size:15;">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>

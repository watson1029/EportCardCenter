<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Express.aspx.cs" Inherits="CardCenter.Express" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快递单填写要求</title>
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            background-color: #ffffff;
            font: 12pt "Tahoma";
            text-align: center;
        }


        .divPage
        {
            width: 29.7cm;
            min-height: 21cm;
            background: white;
        }

        @page
        {
            size: A4 landscape;
            margin: 0;
        }

        @media print
        {
            input
            {
                visibility: hidden;
            }

            .page
            {
                visibility: visible;
                margin: 0;
                border: initial;
                border-radius: initial;
                width: initial;
                min-height: initial;
                box-shadow: initial;
                background: initial;
                page-break-after: always;
            }
        }

        #btnPrint
        {
            height: 31px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function myprint() {
            document.getElementById('btnPrint').style.display = "none";
            document.getElementById('txtMsg').style.display = "none";
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <input type="button" id="btnPrint" name="btnPrint" value="确认打印" onclick="javascript: myprint();" />
        <input type="text" id="txtMsg" readonly="readonly" value="如需快递按请以下要求填写快递单！" style="border: 0px; padding: 0px; margin: 0px; color: red; width: 288px; table-layout: 0; border-collapse: 0; border-spacing: 0px; empty-cells: 0; caption-side: 0; clip: rect(0px, 0px, 0px, 0px);" />
    </div>
    
    <div style="text-align:center;">
        <img src="images/customs/Express.jpg" />
    </div>
    </form>
</body>
</html>

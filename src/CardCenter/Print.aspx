<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="CardCenter.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>网上业务受理审批回执</title>
    <style type="text/css">
        table.gridtable
        {
            font-family: verdana,arial,sans-serif;
            font-size: 14px;
            color: #333333;
            border-width: 1px;
            border-color: #666666;
            border-collapse: collapse;
            width: 80%;
            text-align: center;
            flex-align: center;
        }

            table.gridtable th
            {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #dedede;
            }

            table.gridtable td
            {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #ffffff;
            }

        .auto-style1
        {
            font-size: x-large;
        }

        .auto-style2
        {
            height: 51px;
        }

        .auto-style3
        {
            height: 53px;
        }

        .auto-style5
        {
            height: 236px;
        }

        .auto-style6
        {
            height: 46px;
        }
    </style>
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
            document.getElementById('txtMsg').style.display = "none";
            document.getElementById('btnPrint').style.display = "none";
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">


        <table width="100%">

            <tr>
                <td align="center">
                    <!--startprint1-->
                    

                        <p style="text-align: center; height: 80px;">
                            <img src="images/customs/seal.png" style="float: right; top: 10px" />
                        </p>
                        <p style="text-align: center; height: 80px">
                            <strong><span class="auto-style1">网上业务受理审批回执(广州地区<asp:Label ID="lblAreaTitle" runat="server" Text="省"></asp:Label>属企业)</span></strong>
                        </p>

                        <table style="height: 114px; width: 92%; text-align: center">

                            <tr>
                                <td>业务类型：</td>
                                <td>
                                    <asp:Label ID="lblJobName" runat="server" Text=""></asp:Label></td>
                                <td>经办人：</td>
                                <td>
                                    <asp:Label ID="lblAgentName" runat="server" Text=""></asp:Label></td>
                                <td>电话：</td>
                                <td>
                                    <asp:Label ID="lblAgentPhone" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>企业名称：</td>
                                <td>
                                    <asp:Label ID="lblEnterpriseName" runat="server" Text=""></asp:Label></td>
                                <td>社会统一信用代码：</td>
                                <td>
                                    <asp:Label ID="lblEnterpriseCode" runat="server" Text=""></asp:Label></td>
                                <td>操作员姓名：</td>
                                <td>
                                    <asp:Label ID="lblCardholderName" runat="server" Text=""></asp:Label></td>
                            </tr>

                        </table>
                        <p></p>
                        <table class="gridtable" runat="server" id="dtContent">
                            <thead>

                                <tr>

                                    <td class="auto-style2"><b>广州数据分中心</b></td>
                                    <td class="auto-style2"><b>广州海关(437、438窗口)</b></td>
                                    <td class="auto-style2"><b>
                                        <asp:Label ID="lblArea" runat="server" Text="省"></asp:Label>外汇管理局</b></td>
                                    <td class="auto-style2"><b>
                                        <asp:Label ID="lblArea2" runat="server" Text="省"></asp:Label>商务委</b></td>
                                </tr>

                            </thead>
                            <tr>

                                <td class="auto-style3">业务受理日期</td>
                                <td class="auto-style3">□审核通过&nbsp;&nbsp;□审核不通过</td>
                                <td class="auto-style3">□审核通过&nbsp;&nbsp;□审核不通过</td>
                                <td class="auto-style3">□审核通过&nbsp;&nbsp;□审核不通过</td>
                            </tr>
                            <tr>
                                <td rowspan="2">
                                    <asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="auto-style6" align="left">日期:</td>
                                <td class="auto-style6" align="left">日期：</td>
                                <td class="auto-style6" align="left">日期：</td>
                            </tr>
                            <tr>

                                <td class="auto-style6">
                                    <asp:Label ID="lblTblast1" runat="server" Text="1、IC卡备案 2、IC卡权限"></asp:Label></td>
                                <td class="auto-style6">
                                    <asp:Label ID="lblTblast2" runat="server" Text="1、IC卡备案 2、IC卡权限"></asp:Label></td>
                                <td class="auto-style6">
                                    <asp:Label ID="lblTblast3" runat="server" Text="1、IC卡备案 2、IC卡权限"></asp:Label></td>
                            </tr>
                        </table>
                        <input type="button" id="btnPrint" name="btnPrint" value="确认打印" onclick="javascript: myprint();" />
                        <input type="text" id="txtMsg" readonly="readonly" value="*请用A4打印并设置横向打印！" style="border: 0px; padding: 0px; margin: 0px; color: red; width: 288px; table-layout: 0; border-collapse: 0; border-spacing: 0px; empty-cells: 0; caption-side: 0; clip: rect(0px, 0px, 0px, 0px);" />
                    
                    <!--endprint1-->
                </td>
            </tr>
        </table>

        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
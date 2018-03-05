<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fee.aspx.cs" Inherits="CardCenter.Manager.Fee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>缴费通知单</title>
    <style type="text/css">
        table.gridtable
        {
            font-family: verdana,arial,sans-serif;
            font-size: 16px;
            color: #333333;
            border-width: 1px;
            border-color: #666666;
            border-collapse: collapse;
            width: 90%;
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
                border-width: 2px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #ffffff;
                height: 25px;
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
            /*width: 29.7cm;
            min-height: 21cm;*/
        }


        .divPage
        {
            width: 21cm;
            min-height: 29.7cm;
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
            height: 21px;
        }

        .auto-style1
        {
            font-size: large;
        }

        .auto-style2
        {
        }

        .auto-style5
        {
             width: 20.1cm;
           
            height: 760px;
        }
        .auto-style6
        {
            font-size: xx-large;
        }
        .auto-style7
        {
            text-align: left;
            margin-left:20px;
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
                    <input type="button" id="btnPrint" name="btnPrint" value="确认打印" onclick="javascript: myprint();" />
                    <input type="text" id="txtMsg" readonly="readonly" value="*请用A4打印并设置纵向打印！" style="border: 0px; padding: 0px; margin: 0px; color: red; width: 288px; table-layout: 0; border-collapse: 0; border-spacing: 0px; empty-cells: 0; caption-side: 0; clip: rect(0px, 0px, 0px, 0px);" />
                    <div class="divPage" align="center">
                        <strong><span class="auto-style1">                           
                            <br />
                            </span><span class="auto-style6">                           
                            缴费通知单</span></strong>
                        <br />
                        <table class="gridtable" id="dtMain" align="center">
                           <%-- <tr>
                                <td colspan="4">请将该工单（工单号<asp:Label ID="lblJobID0" runat="server" Text="JobID" Style="font-weight: 700"></asp:Label>）的信息处理费
                                     <asp:Label ID="lblHandlingFee2" runat="server" Text="HandlingFee" Style="font-weight: 700"></asp:Label>元汇入以下账号</td>
                            </tr>
                            <tr>

                                <td>单位名称:</td>
                                <td><strong>中国电子口岸数据中心广州分中心</strong></td>
                                <td>账户:</td>
                                <td><strong>686058654534</strong></td>
                            </tr>
                            <tr>

                                <td>开户银行:</td>
                                <td><strong>中国银行广州粤电支行</strong></td>
                                <td>金额:</td>
                                <td>
                                    <asp:Label ID="lblHandlingFee" runat="server" Text="HandlingFee" Style="font-weight: 700"></asp:Label></td>
                            </tr>
--%>
                            <tr>
                                <td colspan="4">请将该工单（工单号<asp:Label ID="lblJobID" runat="server" Text="JobID" Style="font-weight: 700"></asp:Label>）的工本费
                                    <asp:Label ID="lblCostFee2" runat="server" Text="CostFee" Style="font-weight: 700"></asp:Label>元汇入以下账号</td>
                            </tr>

                            <tr>

                                <td>单位名称:</td>
                                <td><strong>广州海成电子科技有限公司</strong></td>
                                <td>账户:</td>
                                <td><strong>692558431058</strong></td>
                            </tr>
                            <tr>

                                <td>开户银行:</td>
                                <td><strong>中国银行广州粤电支行</strong></td>
                                <td>金额:</td>
                                <td>
                                    <asp:Label ID="lblCostFee" runat="server" Text="CostFee" Style="font-weight: 700"></asp:Label></td>
                            </tr>

                        </table>
                       
                        <table>
                            <tr>
                                <td align="center">
                                     <div class="auto-style7">
                            <strong>企业可以通过以下方式完成汇款：</strong>
                        </div>
                                    <div class="auto-style2">
                                        
                                        <img class="auto-style5" src="../images/customs/bank.jpg" title="缴费通知单汇款方式说明" /></div>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblMsg" runat="server" Text="" Style="background-color: #FF3300"></asp:Label>
                    </div>
                    
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

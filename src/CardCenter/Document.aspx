<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Document.aspx.cs" Inherits="CardCenter.Document" %>

<%@ Register Src="ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />
    <script type="text/javascript" src="js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.alerts.js"></script>
    <script type="text/javascript" src="js/custom/tables.js"></script>
    <script type="text/javascript" src="js/plugins/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/custom/Controller.js"></script>
    <title>制卡业务系统-操作指引</title>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <br clear="all" />
            <table cellpadding="0" cellspacing="0" border="0" class="stdtable">
                <tbody>
                    <tr>
                        <td class="con0">
                            1、中国电子口岸安全数据库客户端IE设置：<a style="font-weight:bold;" href="GuideFile/中国电子口岸安全数据库客户端IE设置20161011.rar">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            2、电子口岸客户端程序IE浏览器设置：<a style="font-weight:bold;" href="GuideFile/电子口岸客户端程序IE浏览器设置.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            3、电子口岸客户端程序安装手册：<a style="font-weight:bold;" href="GuideFile/电子口岸客户端程序安装手册.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            4、易通关平台注册操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/易通关平台注册操作指引/易通关平台注册操作指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/易通关平台注册操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            5、申请进度查询操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/申请进度查询操作指引/申请进度查询操作指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/申请进度查询操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            6、新入网企业操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/新增法人卡/新入网新增法人卡.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/新入网企业操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            7、新增其他卡操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/新增其他卡/新增其他卡.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/新增其他卡操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            8、法人卡变更业务操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/变更业务/变更业务指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/法人卡变更业务操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            9、其他电子口岸业务卡(操作员IC卡、Ikey、报关员卡)变更操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/其他电子口岸业务卡变更操作指引/其他电子口岸业务卡变更操作指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/其他电子口岸业务卡变更操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            10、操作员IC卡、Ikey补办业务操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/补办业务/补办业务指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/补办业务操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            11、报关员卡重制业务操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/重制业务/重制业务指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/重制业务操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            12、更新解锁业务操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/更新解锁业务/更新解锁业务操作指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/更新解锁业务操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            13、购买读卡器操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/读卡器业务/读卡器操作指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/读卡器操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="con0">
                            14、微信上传图片指引操作指引：<a style="font-weight:bold;" href="gzeport/指引网页版/微信上传图片指引操作指引/微信上传图片指引操作指引.htm" target="_blank">在线查看</a>&nbsp;&nbsp;<a style="font-weight:bold;" href="GuideFile/微信上传图片指引操作指引.doc">文件下载</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="CardCenter.Manager.View" %>

<%@ Register Src="../ucFooter.ascx" TagName="ucFooter" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script src="../js/custom/widgets.js"></script>
    <script type="text/javascript">
        function ExpanCloseApplyForm(obj) {
            var dispaly = $("#applyfrominfo").css("display");
            if (dispaly == "none") {
                $(obj).removeClass("expandarrow");
                $(obj).addClass("closearrow");
                $(obj).attr("title", "收起三证合一信息");
                $(obj).children("img").attr("src", "../images/customs/arrow2.png")
            }
            else {
                $(obj).removeClass("closearrow");
                $(obj).addClass("expandarrow");
                $(obj).attr("title", "展开三证合一信息");
                $(obj).children("img").attr("src", "../images/customs/arrow1.png")
            }
            $("#applyfrominfo").slideToggle();
        }
        function ExpanCloseApplyForm1(obj) {
            var dispaly = $("#applyfrominfo1").css("display");
            if (dispaly == "none") {
                $(obj).removeClass("expandarrow");
                $(obj).addClass("closearrow");
                $(obj).attr("title", "收起海关信息");
                $(obj).children("img").attr("src", "../images/customs/arrow2.png")
            }
            else {
                $(obj).removeClass("closearrow");
                $(obj).addClass("expandarrow");
                $(obj).attr("title", "展开海关信息");
                $(obj).children("img").attr("src", "../images/customs/arrow1.png")
            }
            $("#applyfrominfo1").slideToggle();
        }
        function ExpanCloseApplyForm2(obj) {
            var dispaly = $("#applyfrominfo2").css("display");
            if (dispaly == "none") {
                $(obj).removeClass("expandarrow");
                $(obj).addClass("closearrow");
                $(obj).attr("title", "收起外经贸信息");
                $(obj).children("img").attr("src", "../images/customs/arrow2.png")
            }
            else {
                $(obj).removeClass("closearrow");
                $(obj).addClass("expandarrow");
                $(obj).attr("title", "展开外经贸信息");
                $(obj).children("img").attr("src", "../images/customs/arrow1.png")
            }
            $("#applyfrominfo2").slideToggle();
        }
        function ExpanCloseApplyForm3(obj) {
            var dispaly = $("#applyfrominfo3").css("display");
            if (dispaly == "none") {
                $(obj).removeClass("expandarrow");
                $(obj).addClass("closearrow");
                $(obj).attr("title", "收起外汇信息");
                $(obj).children("img").attr("src", "../images/customs/arrow2.png")
            }
            else {
                $(obj).removeClass("closearrow");
                $(obj).addClass("expandarrow");
                $(obj).attr("title", "展开外汇信息");
                $(obj).children("img").attr("src", "../images/customs/arrow1.png")
            }
            $("#applyfrominfo3").slideToggle();
        }
    </script>
    <title>制卡业务系统-工单详情</title>
    <style>
        .table td.title {
            width: 15%;
            text-align: center;
            font-weight: bold;
            background: #fcfcfc;
        }

        .table td.content {
            width: 35%;
            text-align: center;
            background: #fff;
        }

        .table td.title2 {
            width: 30%;
            text-align: center;
            font-weight: bold;
            background: #fcfcfc;
        }

        .table td.content2 {
            width: 70%;
            text-align: center;
            background: #fff;
        }

        .NAStype {
            padding: 8px;
            text-align:center;
            font-weight:bold;
            font-size:14px; 
            color: #1A6BAE;
            border: 1px solid #ddd;
        }
        .NAStype:hover {
            cursor:pointer;
        }
    </style>
</head>
<body>
    <div class="centercontent">
        <div id="contentwrapper" class="contentwrapper">
            <ul class="breadcrumbs">
                <li><a href="../Default.aspx">首页</a></li>
                <li><a href="../Manager/JobList.aspx">工单列表</a></li>
                <li>工单详情</li>
            </ul>
            <div id="tabs">
                <ul>
                    <li><a href="#tabs-1">工单信息</a></li>
                    <li><a href="#tabs-2">工单项信息</a></li>
                    <li><a href="#tabs-3">工单流程信息</a></li>
                </ul>
                <div id="tabs-1">
                    <div class="contenttitle2">
                        <h3>表单信息</h3>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="title">工单编号</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["JobID"].ToString() %></td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td class="title">工单类型</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["JobName"].ToString() %></td>
                            <td class="title">创建时间</td>
                            <td class="content"><%= DateTime.Parse(viewDt.Tables[0].Rows[0]["CreateTime"].ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                        </tr>
                        <tr>
                            <td class="title">企业名称</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["EnterpriseName"].ToString() %></td>
                            <td class="title">企业代码</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["EnterpriseCode"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">企业地址</td>
                            <td class="content" colspan="3"><%= viewDt.Tables[0].Rows[0]["EnterpriseAddress"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">经办人姓名</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["AgentName"].ToString() %></td>
                            <td class="title">经办人电话</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["AgentPhone"].ToString() %></td>
                        </tr>
                        <% if(!string.IsNullOrEmpty(viewDt.Tables[0].Rows[0]["ExpressFlat"].ToString())) %>
                        <% { %>
                            <tr>
                                <td class="title">领取方式</td>
                                <td class="content"><%= bool.Parse(viewDt.Tables[0].Rows[0]["ExpressFlat"].ToString()) == true ? "快递" : "上门领取" %></td>
                                <% if (!bool.Parse(viewDt.Tables[0].Rows[0]["ExpressFlat"].ToString())) %>
                                <% { %>
                                <td class="title">领取地址</td>
                                <td class="content">广州市天河区珠江新城华利路61号广州市政务服务中心4楼&nbsp;&nbsp;&nbsp;020-83939000-2</td>
                                <% } %>
                            </tr>
                            <% if (bool.Parse(viewDt.Tables[0].Rows[0]["ExpressFlat"].ToString())) %>
                            <% { %>
                            <tr>
                                <td class="title">收货人姓名</td>
                                <td class="content"><%= viewDt.Tables[0].Rows[0]["ConsigneeName"].ToString() %></td>
                                <td class="title">收货人电话</td>
                                <td class="content"><%= viewDt.Tables[0].Rows[0]["ConsigneePhone"].ToString() %></td>
                            </tr>
                            <tr>
                                <td class="title">收货人地址</td>
                                <td class="content" colspan="3"><%= viewDt.Tables[0].Rows[0]["ConsigneeAddress"].ToString() %></td>
                            </tr>
                            <% } %>
                        <% } %>
                        <% if (!string.IsNullOrEmpty(viewDt.Tables[0].Rows[0]["InvoiceName"].ToString()))  %>
                        <% { %>
                        <tr>
                            <td class="title">发票收件人</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["InvoiceName"].ToString() %></td>
                            <td class="title">发票收件人手机</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["InvoicePhone"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">发票电子邮箱</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["InvoiceEmail"].ToString() %></td>
                            <td class="title">发票收件地址邮政编码</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["InvoicePostCode"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">纳税人识别号（18位统一社会信用代码）</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["InvoiceCode"].ToString() %></td>
                            <td class="title">发票收件地址</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["InvoiceAddress"].ToString() %></td>
                        </tr>
                        <% } %>
                        <tr>
                            <td class="title">缴费标识</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["FeeFlat"].ToString() %></td>
                            <td class="title">缴费金额</td>
                            <td class="content"><%= "工本费：" + viewDt.Tables[0].Rows[0]["Fee"].ToString() + "元"%></td>
                        </tr>
                        <tr>
                            <td class="title">工单状态</td>
                            <td class="content"><%= viewDt.Tables[0].Rows[0]["StatusName"].ToString() %></td>
                            <td class="title">提交地点</td>
                            <td class="content"><%= bool.Parse(viewDt.Tables[0].Rows[0]["IsOnline"].ToString()) == true ? "网上交单" : "现场交单" %></td>
                        </tr>
                        <tr>
                            <td class="title">备注</td>
                            <td class="content" colspan="3"><%= viewDt.Tables[0].Rows[0]["Remark"].ToString() %></td>
                        </tr>
                    </table>
                    <% if (viewDt.Tables[0].Rows[0]["JobType"].ToString() == "SL") %>
                    <% { %>
                        <div class="contenttitle2">
                            <h3>绑定信息</h3>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" class="stdtable stdtablequick">
                            <colgroup>
                                <col class="con0" />
                                <col class="con1" />
                                <col class="con0" />
                                <col class="con1" />
                                <col class="con0" />
                            </colgroup>
                            <thead>
                                <tr>
                                    <th class="head0">工单编号</th>
                                    <th class="head1">业务类型</th>
                                    <th class="head0">申请时间</th>
                                    <th class="head1">操作</th>
                                </tr>
                            </thead>
                            <tbody id="jobList">
                                <asp:Repeater id="repeater" runat="server">
                                    <ItemTemplate>
                                        <tr id="<%# Eval("JobID") %>">
                                            <td class="con0"><%# Eval("JobID") %></td>
                                            <td class="con1"><%# Eval("JobName") %></td>
                                            <td class="con0"><%# DateTime.Parse(Eval("CreateTime").ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                                            <td class="con1"><a target="_blank" href='View.aspx?jobID=<%# Eval("JobID") %>&jobType=<%# Eval("JobType") %>'>查看</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    <% } %>
                    <% System.Data.DataRow[] fileDr = viewDt.Tables[2].Select("ListID = ''"); %>
                    <% if(fileDr.Length > 0) %>
                    <% { %>
                        <div class="contenttitle2">
                            <h3>随附资料</h3>
                        </div>
                    <% } %>
                    <% for (int i = 0; i < fileDr.Length; i++) %>
                    <% { %>
                        <table class="table">
                            <tr>
                                <td class="title2"><%= fileDr[i]["FileTypeName"].ToString() %></td>
                                <td class="content2"><a href="../UploadFile/<%= fileDr[i]["Guid"].ToString() %>" target="_blank"><%= fileDr[i]["FileName"].ToString() %></a></td>
                            </tr>
                        </table>
                    <% } %>
                    <br clear="all" />
                    <% System.Data.DataTable dt = new CardCenter.DataAccess.PrintList().GetList("").Tables[0]; %>
                    <div class="contenttitle2">
                        <h3>广州地区市属企业-审批回执打印</h3>
                    </div>
                    <table class="table">
                        <% for (int k = 0; k < viewDt.Tables[1].Rows.Count; k++) %>
                        <% { %>
                            <% System.Data.DataRow[] dr = dt.Select("Value='" + viewDt.Tables[1].Rows[k]["JobTypeID"] + "'"); %>
                            <% if(dr.Length == 1) %>
                            <% { %>
                                <tr>
                                    <td class="title2">
                                        <a href='../Print.aspx?jobID=<%= viewDt.Tables[1].Rows[k]["JobID"] %>&listID=<%= viewDt.Tables[1].Rows[k]["ListID"] %>&area=1' target="_blank"><%= viewDt.Tables[1].Rows[k]["JobName"] %>（持卡人姓名：<%= viewDt.Tables[1].Rows[k]["CardholderName"] %>）回执打印</a>
                                    </td>
                                </tr>
                            <% } %>
                        <% } %>
                    </table>
                    <br clear="all" />
                    <div class="contenttitle2">
                        <h3>广州地区省属企业-审批回执打印</h3>
                    </div>
                    <table class="table">
                        <% for (int k = 0; k < viewDt.Tables[1].Rows.Count; k++) %>
                        <% { %>
                            <% System.Data.DataRow[] dr = dt.Select("Value='" + viewDt.Tables[1].Rows[k]["JobTypeID"] + "'"); %>
                            <% if(dr.Length == 1) %>
                            <% { %>
                                <tr>
                                    <td class="title2">
                                        <a href='../Print.aspx?jobID=<%= viewDt.Tables[1].Rows[k]["JobID"] %>&listID=<%= viewDt.Tables[1].Rows[k]["ListID"] %>&area=2' target="_blank"><%= viewDt.Tables[1].Rows[k]["JobName"] %>（持卡人姓名：<%= viewDt.Tables[1].Rows[k]["CardholderName"] %>）回执打印</a>
                                    </td>
                                </tr>
                            <% } %>
                        <% } %>
                    </table>
                </div>
                <div id="tabs-2">
                    <% for (int i = 0; i < viewDt.Tables[1].Rows.Count; i++) %>
                    <% { %>
                        <div class="contenttitle2">
                            <h3>工单项编号:<%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></h3>
                        </div>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "UU") %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">工单项类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                    <td class="title">卡类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">持卡人姓名</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderName"].ToString() %></td>
                                    <td class="title">卡号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardNum"].ToString() %></td>
                                </tr>
                            </table>
                        <% } %>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "MD") %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">工单项类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                    <td class="title">卡类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">新持卡人姓名</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderName"].ToString() %></td>
                                    <td class="title">卡号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardNum"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">其他信息</td>
                                    <td class="content" colspan="3"><%= bool.Parse(viewDt.Tables[1].Rows[i]["IsChangeName"].ToString()) == true ? viewDt.Tables[1].Rows[i]["JobTypeID"].ToString() == "MD001" ? "变更法人卡的法人名称或企业名称." : "变更操作员IC/IKEY卡的持卡人姓名." : ""%></td>
                                </tr>
                            </table>
                        <% } %>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "RI") %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">工单项类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                    <td class="title">卡类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">持卡人姓名</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderName"].ToString() %></td>
                                    <td colspan="2"></td>
                                </tr>
                            </table>
                        <% } %>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "RM") %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">工单项类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                    <td class="title">卡类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">持卡人姓名</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderName"].ToString() %></td>
                                    <td class="title">报关员备案编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CardNum"].ToString() %></td>
                                </tr>
                            </table>
                        <% } %>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "SL") %>
                        <% { %>
                            <table class="table">
                                <tr>
                                    <td class="title">工单编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                    <td class="title">工单项编号</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">安全产品厂商</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["CommodityType"].ToString() %></td>
                                    <td class="title">安全产品类型</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["AdditionalAttributes"].ToString() %><%= viewDt.Tables[1].Rows[i]["CommodityName"].ToString() %></td>
                                </tr>
                                <tr>
                                    <td class="title">单价</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["SellingPrice"].ToString() %> 元</td>
                                    <td class="title">数量</td>
                                    <td class="content"><%= viewDt.Tables[1].Rows[i]["Num"].ToString() %></td>
                                </tr>
                            </table>
                        <% } %>
                        <% if(viewDt.Tables[0].Rows[0]["JobType"].ToString() == "NA") %>
                        <% { %>
                            <% if (viewDt.Tables[1].Rows[i]["JobTypeID"].ToString() == "NA001" && bool.Parse(viewDt.Tables[0].Rows[0]["IsOnline"].ToString())) %>
                            <% { %>
                                <% CardCenter.Entity.NewlyAddedListFR na001 = new CardCenter.DataAccess.NewlyAddedListFR().GetModel(viewDt.Tables[1].Rows[i]["ListID"].ToString()); %>
                                <table class="table">
                                    <tr>
                                        <td class="title">工单编号</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                        <td class="title">工单项编号</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                    </tr>
                                    <tr>
                                        <td class="title">工单项类型</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                        <td class="title">卡类型</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                    </tr>
                                    <tr>
                                        <td class="title">持卡人姓名</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderName"].ToString() %></td>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td class="title">持卡人证件类型</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderIdentificationType"].ToString() %></td>
                                        <td class="title">持卡人证件号码</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderIdentificationNum"].ToString() %></td>
                                    </tr>
                                </table>
                                <div class="applyFomSubTitle NAStype" onclick="ExpanCloseApplyForm(this)">
                                    查看三证合一信息
                                    <img src="../images/customs/arrow1.png" style="float:right;"/>
                                </div>
                                <div id="applyfrominfo" style="display: none">
                                    <table class="table">
                                        <tr>
                                            <td class="title">统一社会信用代码</td>
                                            <td class="content"><%= na001.SHTYXYDM_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">主体识别码</td>
                                            <td class="content"><%= na001.ZTSBM_QS %></td>
                                            <td class="title">登记管理机关行政区域划码</td>
                                            <td class="content"><%= na001.XZQYHM_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">企业中文名称</td>
                                            <td class="content"><%= na001.QYZWMC_QS %></td>
                                            <td class="title">企业英文名称</td>
                                            <td class="content"><%= na001.QYYWMC_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">企业地址</td>
                                            <td class="content"><%= na001.QYDZ_QS %></td>
                                            <td class="title">法定代表人</td>
                                            <td class="content"><%= na001.FDDBR_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">法人电话</td>
                                            <td class="content"><%= na001.FRDH_QS %></td>
                                            <td class="title">企业类型</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.QYLX_QS) ? "" : new CardCenter.DataAccess.Para_QYLX().GetModel(na001.QYLX_QS).QYLX_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">注册资金（万）</td>
                                            <td class="content"><%= na001.ZCZJ_QS %></td>
                                            <td class="title">注册资金币值</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.ZCZJBZ_QS) ? "" : new CardCenter.DataAccess.Para_BZ().GetModel(na001.ZCZJBZ_QS).BZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">证件类型</td>
                                            <td class="content"><%= na001.ZJLX_QS_QS == null ? "" : new CardCenter.DataAccess.Para_IdentificationType().GetModel(Convert.ToInt32(na001.ZJLX_QS_QS)).Name %></td>
                                            <td class="title">证件号码</td>
                                            <td class="content"><%= na001.ZJHM_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">营业期限</td>
                                            <td class="content"><%= na001.YYQX_QS %></td>
                                            <td class="title">法人类型</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.FRLX_QS) ? "" : new CardCenter.DataAccess.Para_FRLX().GetModel(na001.FRLX_QS).FRLX_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">邮政编码</td>
                                            <td class="content"><%= na001.YZBM_QS %></td>
                                            <td class="title">传真</td>
                                            <td class="content"><%= na001.CZ_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">发证机构名称</td>
                                            <td class="content"><%= na001.FZJGMC_QS %></td>
                                            <td class="title">发卡机构代码</td>
                                            <td class="content"><%= na001.FKJGDM_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">发证日期</td>
                                            <td class="content"><%= na001.FZRQ_QS == null ? "" : Convert.ToDateTime(na001.FZRQ_QS).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">成立日期</td>
                                            <td class="content"><%= na001.CLRQ_QS == null ? "" : Convert.ToDateTime(na001.CLRQ_QS).ToString("yyyy年MM月dd日") %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">工商审核单位代码</td>
                                            <td class="content"><%= na001.GSSPDWDM_QS %></td>
                                            <td class="title">技监审核单位代码</td>
                                            <td class="content"><%= na001.ZJSPDWDM_QS %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">税务审核单位代码</td>
                                            <td class="content"><%= na001.SWSPDWDM_QS %></td>
                                            <td class="title">经营范围</td>
                                            <td class="content"><%= na001.JYFW_QS %></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="applyFomSubTitle NAStype" onclick="ExpanCloseApplyForm1(this)">
                                    查看海关信息
                                    <img src="../images/customs/arrow1.png" style="float:right;"/>
                                </div>
                                <div id="applyfrominfo1" style="display: none">
                                    <table class="table">
                                        <tr>
                                            <td class="title">组织机构代码</td>
                                            <td class="content"><%= na001.ZZJGDM_HG %></td>
                                            <td class="title">海关注册号</td>
                                            <td class="content"><%= na001.HGZCH_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">主管海关代码</td>
                                            <td class="content"><%= na001.ZGHG_HG %></td>
                                            <td class="title">备案海关</td>
                                            <td class="content"><%= na001.BAHG_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">注册日期</td>
                                            <td class="content"><%= na001.ZCRQ_HG == null ? "" : Convert.ToDateTime(na001.ZCRQ_HG).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">企业注册有效日期</td>
                                            <td class="content"><%= na001.YXRQ_HG == null ? "" : Convert.ToDateTime(na001.YXRQ_HG).ToString("yyyy年MM月dd日") %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">工商注册全称</td>
                                            <td class="content"><%= na001.GSZCQC_HG %></td>
                                            <td class="title">海关注册名称</td>
                                            <td class="content"><%= na001.HGZCMC_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">对外(英文)名称</td>
                                            <td class="content"><%= na001.DWMC_HG %></td>
                                            <td class="title">工商注册地址</td>
                                            <td class="content"><%= na001.GSZCDZ_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">对外(英文)地址</td>
                                            <td class="content"><%= na001.DWDZ_HG %></td>
                                            <td class="title">营业执照注册号</td>
                                            <td class="content"><%= na001.YYZZZCH_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">邮政编码</td>
                                            <td class="content"><%= na001.YZBM_HG %></td>
                                            <td class="title">法人代表</td>
                                            <td class="content"><%= na001.FRDB_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">法人电话</td>
                                            <td class="content"><%= na001.FRDH_HG %></td>
                                            <td class="title">报关类别</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.BGLB_HG) ? "" : new CardCenter.DataAccess.Para_BGLB().GetModel(na001.BGLB_HG).BGLB_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">证件类别</td>
                                            <td class="content"><%= na001.ZJLX_HG == null ? "" : new CardCenter.DataAccess.Para_IdentificationType().GetModel(Convert.ToInt32(na001.ZJLX_HG)).Name %></td>
                                            <td class="title">法人证件号码</td>
                                            <td class="content"><%= na001.FRZJHM_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">进出口权批准机关</td>
                                            <td class="content"><%= na001.JCKQPZJG_HG %></td>
                                            <td class="title">批准文号</td>
                                            <td class="content"><%= na001.PZWH_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">注册资本（万）</td>
                                            <td class="content"><%= na001.ZCZB_HG %></td>
                                            <td class="title">注册资本币制</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.ZCZBBZ_HG) ? "" : new CardCenter.DataAccess.Para_BZ().GetModel(na001.ZCZBBZ_HG).BZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">总经理</td>
                                            <td class="content"><%= na001.ZJL_HG %></td>
                                            <td class="title">电话</td>
                                            <td class="content"><%= na001.DH_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">开户银行</td>
                                            <td class="content"><%= na001.KHYH_HG %></td>
                                            <td class="title">银行帐号</td>
                                            <td class="content"><%= na001.YHZH_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">税务登记号</td>
                                            <td class="content"><%= na001.SWDJH_HG %></td>
                                            <td class="title">行业种类</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.HYZL_HG) ? "" : new CardCenter.DataAccess.Para_HYZL().GetModel(na001.HYZL_HG).HYZL_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">免税额（万美元）</td>
                                            <td class="content"><%= na001.MSE_HG %></td>
                                            <td class="title">主要产品</td>
                                            <td class="content"><%= na001.ZYCP_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">经营范围及备注</td>
                                            <td class="content"><%= na001.JYFWJBZ_HG %></td>
                                            <td class="title">进出口企业代码</td>
                                            <td class="content"><%= na001.JCKQYDM_HG %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">投资总额（万）</td>
                                            <td class="content"><%= na001.TZZE_HG %></td>
                                            <td class="title">投资总额币制</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.BZ_HG) ? "" : new CardCenter.DataAccess.Para_BZ().GetModel(na001.BZ_HG).BZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">到位资本总额（万美元）</td>
                                            <td class="content"><%= na001.DWZBZE_HG %></td>
                                            <td class="title">企业生产类型</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.QYSCLX_HG) ? "" : new CardCenter.DataAccess.Para_SCFS().GetModel(na001.QYSCLX_HG).SCFS_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">内销比率(%)</td>
                                            <td class="content"><%= na001.NXBL_HG %></td>
                                            <td class="title">注册有效日期</td>
                                            <td class="content"><%= na001.ZCYXRQ_HG == null ? "" : Convert.ToDateTime(na001.ZCYXRQ_HG).ToString("yyyy年MM月dd日") %></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="applyFomSubTitle NAStype" onclick="ExpanCloseApplyForm2(this)">
                                    查看外经贸信息
                                    <img src="../images/customs/arrow1.png" style="float:right;"/>
                                </div>
                                <div id="applyfrominfo2" style="display: none">
                                    <table class="table">
                                        <tr>
                                            <td class="title">组织机构代码</td>
                                            <td class="content"><%= na001.ZZJGDM_WJM %></td>
                                            <td class="title">批准文号</td>
                                            <td class="content"><%= na001.PZWH_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">进出口企业代码</td>
                                            <td class="content"><%= na001.JCKQYDM_WJM %></td>
                                            <td class="title">批准日期</td>
                                            <td class="content"><%= na001.PZRQ_WJM == null ? "" : Convert.ToDateTime(na001.PZRQ_WJM).ToString("yyyy年MM月dd日") %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">发证（备案）日期</td>
                                            <td class="content"><%= na001.FZRQ_WJM == null ? "" : Convert.ToDateTime(na001.FZRQ_WJM).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">发证（备案）机关</td>
                                            <td class="content"><%= na001.FZJG_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">主管外经委代码</td>
                                            <td class="content"><%= na001.ZGWJM_WJM %></td>
                                            <td class="title">企业（经营者）中文名称</td>
                                            <td class="content"><%= na001.QYZWMC_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">英文对照（经营者英文名称）</td>
                                            <td class="content"><%= na001.YWDZ_WJM %></td>
                                            <td class="title">企业地址（经营场所）</td>
                                            <td class="content"><%= na001.QYDZ_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">经营场所（英文）</td>
                                            <td class="content"><%= na001.JYCS_WJM %></td>
                                            <td class="title">主管部门</td>
                                            <td class="content"><%= na001.ZGBM_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">法定代表人（个体工商负责人）</td>
                                            <td class="content"><%= na001.FDDBR_WJM %></td>
                                            <td class="title">住所</td>
                                            <td class="content"><%= na001.ZS_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">联系电话</td>
                                            <td class="content"><%= na001.LXDH_WJM %></td>
                                            <td class="title">联系传真</td>
                                            <td class="content"><%= na001.LXCZ_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">邮政编码</td>
                                            <td class="content"><%= na001.YZBM_WJM %></td>
                                            <td class="title">电子邮箱</td>
                                            <td class="content"><%= na001.DZYX_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">工商登记注册日期</td>
                                            <td class="content"><%= na001.GSDJZCRQ_WJM == null ? "" : Convert.ToDateTime(na001.GSDJZCRQ_WJM).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">工商登记注册号</td>
                                            <td class="content"><%= na001.GSDJZCH_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">企业（经营者）类型</td>
                                            <td class="content"><%= na001.QYJYLX_WJM %></td>
                                            <td class="title">经营年限（年）</td>
                                            <td class="content"><%= na001.JYNX_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">投资总额（万)</td>
                                            <td class="content"><%= na001.TZZE_WJM %></td>
                                            <td class="title">投资币制</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.TZBZ_WJM) ? "" : new CardCenter.DataAccess.Para_BZ().GetModel(na001.TZBZ_WJM).BZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">注册资本（万）</td>
                                            <td class="content"><%= na001.ZCZB_WJM %></td>
                                            <td class="title">注册资本币制</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.ZCZBBZ_WJM) ? "" : new CardCenter.DataAccess.Para_BZ().GetModel(na001.ZCZBBZ_WJM).BZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">备案登记表编号</td>
                                            <td class="content"><%= na001.BADJBBH_WJM %></td>
                                            <td class="title">注册资金（折美元）</td>
                                            <td class="content"><%= na001.ZCZJ_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">经营范围</td>
                                            <td class="content"><%= na001.JYFW_WJM %></td>
                                            <td class="title">进出口商品目录</td>
                                            <td class="content"><%= na001.JCKSPML_WJM %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">备注</td>
                                            <td class="content" colspan="3"><%= na001.BZ_WJM %></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="applyFomSubTitle NAStype" onclick="ExpanCloseApplyForm3(this)">
                                    查看外汇信息
                                    <img src="../images/customs/arrow1.png" style="float:right;"/>
                                </div>
                                <div id="applyfrominfo3" style="display: none">
                                    <table class="table">
                                        <tr>
                                            <td class="title">组织机构代码</td>
                                            <td class="content"><%= na001.ZZJGDM_WH %></td>
                                            <td class="title">工商注册号</td>
                                            <td class="content"><%= na001.GSZCH_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">海关注册号</td>
                                            <td class="content"><%= na001.HGZCH_WH %></td>
                                            <td class="title">海关注册有效期</td>
                                            <td class="content"><%= na001.HGZCYXQ_WH == null ? "" : Convert.ToDateTime(na001.HGZCYXQ_WH).ToString("yyyy年MM月dd日") %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">主管外汇局代码</td>
                                            <td class="content"><%= na001.ZGWHJ_WH %></td>
                                            <td class="title">企业中文全称</td>
                                            <td class="content"><%= na001.QYZWMC_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">企业地址</td>
                                            <td class="content"><%= na001.QYDZ_WH %></td>
                                            <td class="title">传真</td>
                                            <td class="content"><%= na001.CZ_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">电话</td>
                                            <td class="content"><%= na001.DH_WH %></td>
                                            <td class="title">电子信箱</td>
                                            <td class="content"><%= na001.DZYX_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">法定代表人</td>
                                            <td class="content"><%= na001.FDDBR_WH %></td>
                                            <td class="title">核销联系人</td>
                                            <td class="content"><%= na001.HXLXR_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">经营范围</td>
                                            <td class="content"><%= na001.JYFW_WH %></td>
                                            <td class="title">行业代码</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.HYDM_WH) ? "" : new CardCenter.DataAccess.Para_HYDM().GetModel(na001.HYDM_WH).HYDM_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">企业邮编</td>
                                            <td class="content"><%= na001.QYYB_WH %></td>
                                            <td class="title">企业性质</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.QYXZ_WH) ? "" : new CardCenter.DataAccess.Para_QYXZ().GetModel(na001.QYXZ_WH).QYXZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">人民币注册资金（万）</td>
                                            <td class="content"><%= na001.RMBZCZJ_WH %></td>
                                            <td class="title">外币注册币种</td>
                                            <td class="content"><%= string.IsNullOrEmpty(na001.WBZCBZ_WH) ? "" : new CardCenter.DataAccess.Para_BZ().GetModel(na001.WBZCBZ_WH).BZ_Name %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">外币注册资金（万）</td>
                                            <td class="content"><%= na001.WBZCZJ_WH %></td>
                                            <td class="title">最初设立日期</td>
                                            <td class="content"><%= na001.ZCSLRQ_WH == null ? "" : Convert.ToDateTime(na001.ZCSLRQ_WH).ToString("yyyy年MM月dd日") %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">截止有效日期</td>
                                            <td class="content"><%= na001.JZYXRQ_WH == null ? "" : Convert.ToDateTime(na001.JZYXRQ_WH).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">外贸证书号</td>
                                            <td class="content"><%= na001.WMZSH_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">外贸证书批准日期</td>
                                            <td class="content"><%= na001.WMZSPZRQ_WH == null ? "" : Convert.ToDateTime(na001.WMZSPZRQ_WH).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">外贸经营范围</td>
                                            <td class="content"><%= na001.WMJYFW_WH %></td>
                                        </tr>
                                        <tr>
                                            <td class="title">核销开户日期</td>
                                            <td class="content"><%= na001.HXKHRQ_WH == null ? "" : Convert.ToDateTime(na001.HXKHRQ_WH).ToString("yyyy年MM月dd日") %></td>
                                            <td class="title">企业类型名称</td>
                                            <td class="content"><%= na001.QYLXMC_WH %></td>
                                        </tr>
                                    </table>
                                </div>
                            <% } %>
                            <% else %>
                            <% { %>
                                <table class="table">
                                    <tr>
                                        <td class="title">工单编号</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["JobID"].ToString() %></td>
                                        <td class="title">工单项编号</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["ListID"].ToString() %></td>
                                    </tr>
                                    <tr>
                                        <td class="title">工单项类型</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["JobName"].ToString() %></td>
                                        <td class="title">卡类型</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardType"].ToString() %></td>
                                    </tr>
                                    <tr>
                                        <td class="title">持卡人姓名</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderName"].ToString() %></td>
                                        <td class="title">持卡人手机号</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderPhone"].ToString() %></td>
                                    </tr>
                                    <tr>
                                        <td class="title">持卡人证件类型</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderIdentificationType"].ToString() %></td>
                                        <td class="title">持卡人证件号码</td>
                                        <td class="content"><%= viewDt.Tables[1].Rows[i]["CardholderIdentificationNum"].ToString() %></td>
                                    </tr>
                                </table>
                            <% } %>
                        <% } %>
                    <% string listID = viewDt.Tables[1].Rows[i]["ListID"].ToString(); %>
                    <% System.Data.DataRow[] itemFileDr = viewDt.Tables[2].Select("ListID = '" + listID + "'"); %>
                    <% for (int j = 0; j < itemFileDr.Length; j++) %>
                    <% { %>
                    <table class="table">
                        <tr>
                            <td class="title2"><%= itemFileDr[j]["FileTypeName"].ToString() %></td>
                            <td class="content2"><a href="../UploadFile/<%= itemFileDr[j]["Guid"].ToString() %>" target="_blank"><%= itemFileDr[j]["FileName"].ToString() %></a></td>
                        </tr>
                    </table>
                    <% } %>
                    <br clear="all" />
                    <br />
                    <% } %>
                </div>
                <div id="tabs-3">
                    <% for (int i = 0; i < viewDt.Tables[3].Rows.Count; i++) %>
                    <% { %>
                    <div class="contenttitle2">
                        <h3>流程信息<%= i+1 %>:</h3>
                    </div>
                    <table class="table">
                        <tr>
                            <td class="title">流水号</td>
                            <td class="content"><%= viewDt.Tables[3].Rows[i]["Guid"].ToString() %></td>
                            <td class="title">流程状态</td>
                            <td class="content"><%= viewDt.Tables[3].Rows[i]["StatusName"].ToString() %></td>
                        </tr>
                        <tr>
                            <td class="title">提交日期</td>
                            <td class="content"><%= DateTime.Parse(viewDt.Tables[3].Rows[i]["SubmitDate"].ToString()).ToString("yyyy年MM月dd日 HH时mm分") %></td>
                            <td class="title">提交用户</td>
                            <td class="content"><%= LoginUserInfo.companyId == viewDt.Tables[3].Rows[i]["SubmitUser"].ToString() ? viewDt.Tables[0].Rows[0]["EnterpriseName"].ToString() : "工号" + new CardCenter.DataAccess.ManagerUser().GetModel(viewDt.Tables[3].Rows[i]["SubmitUser"].ToString()).UserName %></td>
                        </tr>
                        <tr>
                            <td class="title">备注</td>
                            <td class="content" colspan="3"><%= viewDt.Tables[3].Rows[i]["Content"].ToString() %></td>
                        </tr>
                    </table>
                    <% } %>
                </div>
            </div>
            <!--#tabs-->
        </div>
    </div>
    <uc1:ucFooter ID="ucFooter1" runat="server" />
</body>
</html>

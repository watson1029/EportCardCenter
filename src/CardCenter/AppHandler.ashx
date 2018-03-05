<%@ WebHandler Language="C#" Class="AppHandler" %>

using System;
using System.Web;
using Newtonsoft.Json;
public class AppHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        if (context.Request["get"].Contains( "test"))
        {
            context.Response.Write(@"{""access_token"":""abcdeasdfdfasd""}");
        }
        else if (context.Request["get"].Contains( "getCompany"))
        {
            //string str = @"{}";
            string str = @"{""TRADE_CO"":""443096143D"",""REG_CO"":""广州森晓贸易有限公司"",""FULL_NAME"":""广州森晓贸易有限公司"",""CUSTOMS_CODE"":""5169"",""CO_CLASS"":""B"",""CREDIT_MAR"":""00000000"",""EXAM_SCORE"":null,""VALID_DATE"":null,""ACCO_BANK"":null,""ACCO_NO"":null,""MAIL_CO"":""510000"",""BROKER_TYPE"":null,""RG_DATE"":""2015-03-12T13:55:47.000Z"",""LICENSE_ID"":""440110000052358"",""EN_FULL_CO"":null,""EN_ADDR_CO"":null,""ADDR_CO"":""广州市南沙区万顷沙镇粤海大道九涌段加工区管委会大楼1楼X1020（仅限办公用途）（WB）"",""BUSI_TYPE"":""6300"",""CONTAC_CO"":""高心祥"",""TEL_CO"":""020-23359345"",""APPR_DEP"":null,""APPR_ID"":null,""LAW_MAN"":""高心祥"",""LAW_MAN_TEL"":null,""INV_FUND_T"":0,""ID_NUMBER"":""341281196802266552"",""RG_FUND"":0,""CURR_CODE"":null,""TAXY_RG_NO"":""440115331351294"",""CHK_DATE"":""2015-03-12T13:57:17.000Z"",""CO_TYPE"":null,""BREAK_LAW_TIME1"":null,""BREAK_LAW_TIME2"":null,""IN_RATIO"":null,""INSPECT_TIME"":null,""SPE_CO"":null,""TRADE_AREA"":null,""MAIN_PRO"":null,""ACT_FUND"":0,""DUTY_FREE_AMT"":null,""COP_FLAG"":""10000000"",""COP_NOTE"":null,""PRE_TRADE_CO"":null,""CHK_OPER_CODE"":null,""CHK_OPER_FLAG"":null,""CHK_OPER_DATE"":null,""CHK_DPT_CODE"":null,""CHK_DPT_FLAG"":null,""CHK_DPT_DATE"":null,""CHK_MASTER_CODE"":null,""CHK_MASTER_FLAG"":null,""CHK_MASTER_DATE"":null,""CHK_EARNEST_MON"":null,""CHK_CODE"":null,""COP_GB_CODE"":""331351294"",""COP_IO_CODE"":""4401331351294"",""COP_END_DATE"":""2016-07-31T00:00:00.000Z"",""COP_MODIFY_DATE"":""2016-03-30T02:07:29.000Z"",""COP_RANGE"":null,""BUSINESS_CATEGORY"":""10000000000000000000000000000000"",""SUPERIOR_COP_GB_CODE"":null,""SUPERIOR_FULL_NAME"":null,""SUPERIOR_TRADE_CO"":null,""SIGNOUT_FLAG"":""00000000"",""ADMIN_DIVISION_CODE"":""440115"",""ECONOMIC_AREA_CODE"":""09"",""ECONOMIC_CATEGORY_CODE"":""150"",""BUSINESS_CATEGORY_BRIEF"":""A"",""CORP_TYPE"":""99"",""CROSS_BORDER_TRADE_FLAGS"":""00000000"",""HOME_PAGE"":null,""CO_CLASS_PRO"":""00000000"",""SOCIAL_CREDIT_CODE"":null,""SPECIAL_TRADE_ZONE"":""99999999""}";
            context.Response.Write(str);
        }
        else if (context.Request["get"].Contains( "getUser"))
        {
            string str = @" { ""_id"": ""567e0ba5a29bd3c57083677c"",
  ""email"": ""zouweilun@163.com"",
  ""mobile"": ""15820200921"",
  ""displayName"":""邹巍伦"",
  ""companyId"":""443096143D""
  
 
   }
"; //@"{ ""_id"" : ""567509acc07e00e37cb162c9"", ""companyId"" : ""deng@qq.com"", ""companId"" : ""deng@qq.com"", ""Email"" : ""deng@qq.com"", ""Mobile"" : ""15012345678"", ""DisplayName"" : ""dyh20032004"", ""Created"" : ""2015-12-19"", ""Enabled"" : ""true"", ""Permission"" : ""1234"", ""CompanyId"" : """", ""Authenticated"" : ""1"", ""SubAccounts"" : """", ""IKeyPublicKey"" : """", ""IkeySerialNo"" : """", ""Notifications"" : ""12"" }";
            context.Response.Write(str);
        }
            
            
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
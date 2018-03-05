<%@ WebHandler Language="C#" Class="AppHandler1" %>

using System;
using System.Web;
using Newtonsoft.Json;
public class AppHandler1 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request["get"].Contains("4401986999"))
        {
            string str = @" { ""FULL_NAME"": ""广州市海通科技服务公司"",
                              ""COP_GB_CODE"": ""190784351"",
                              ""TRADE_CO"": ""4401986999"",
                              ""CONTAC_CO"":""陈建秋"",
                              ""TEL_CO"":"""",
                              ""CUSTOMS_CODE"": ""5135"",
                              ""ADDR_CO"": ""广州市天河区石牌西路海欣街3号首层"",
                              ""LAW_MAN"":""吴伟平"",
                              ""LAW_MAN_TEL"":""""
                            }";
            context.Response.Write(str);
        }
        else
            context.Response.Write(@"");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="AppHandler2" %>

using System;
using System.Web;
using Newtonsoft.Json;
public class AppHandler2 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request["get"].Contains("190784351"))
        {
            string str = @" { ""FULL_NAME"": ""广州市海通科技服务公司"",
                              ""COP_GB_CODE"": ""190784351"",
                              ""TRADE_CO"": ""4401986999"",
                              ""CONTAC_CO"":""陈建秋"",
                              ""TEL_CO"":"""",
                              ""CUSTOMS_CODE"": ""5135""
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
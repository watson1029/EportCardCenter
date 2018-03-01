using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax.Commodity
{
    /// <summary>
    /// GetCommodityType 的摘要说明
    /// </summary>
    public class GetCommodityType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<string> list = new DataAccess.Stock_Commodity().GetCommodityType();
            string html = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                html += string.Format("<li><a href = '#' id = 'fr{0}' onclick='factoryClick(this)'><span>{1}</span></a></li>", i, list[i]);
            }
            context.Response.Write(html);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
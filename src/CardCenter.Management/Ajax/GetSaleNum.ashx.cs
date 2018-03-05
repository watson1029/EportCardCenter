using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// GetSaleNum 的摘要说明
    /// </summary>
    public class GetSaleNum : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Entity.Stock_Commodity entity = new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["Guid"]);
            context.Response.Write(entity.StockDesplay);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// SaveStock 的摘要说明
    /// </summary>
    public class SaveStock : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                Entity.Stock_Commodity stock = new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["Guid"]);
                stock.StockDesplay += int.Parse(context.Request.Form["EditNum"]);
                stock.StockActual += int.Parse(context.Request.Form["EditNum"]);
                if (new DataAccess.Stock_Commodity().UpdateEx(stock))
                    context.Response.Write("");
                else
                    context.Response.Write("修改库存失败！入库出错，请联系管理员！");
            }
            catch (Exception ex)
            {
                context.Response.Write("修改库存失败！请联系管理员！" + ex.ToString());
            }
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
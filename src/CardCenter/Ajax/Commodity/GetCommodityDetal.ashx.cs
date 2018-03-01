using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax.Commodity
{
    /// <summary>
    /// GetCommodityDetal 的摘要说明
    /// </summary>
    public class GetCommodityDetal : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DataTable dt = new DataAccess.Stock_Commodity().GetList(string.Format("CommodityType='{0}'", context.Request["type"])).Tables[0];
            List<Entity.Stock_Commodity> list = new List<Entity.Stock_Commodity>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new DataAccess.Stock_Commodity().DataRowToEntity(dr));
            string html = string.Empty;
            foreach (Entity.Stock_Commodity model in list)
            {
                if(model.StockDesplay > 0)
                    html += string.Format("<li><a href = '#' id = '{0}' onclick='commodityClick(this)'><span class='name'>{1}</span><span class='price'>价格：{2} 元</span><span class='remain' count='{3}'>剩余：{3} 份</span></a></li>", model.Guid, model.CommodityName, model.SellingPrice, model.StockDesplay);
                else
                    html += string.Format("<li><a href = '#' id = '{0}' style='cursor:not-allowed'><span class='name'>{1}</span><span class='price'>价格：{2} 元</span><span class='remain' count='{3}'>剩余：{3} 份</span></a></li>", model.Guid, model.CommodityName, model.SellingPrice, model.StockDesplay);
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
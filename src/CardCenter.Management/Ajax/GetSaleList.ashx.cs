using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// GetSaleList 的摘要说明
    /// </summary>
    public class GetSaleList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jobTypeID = context.Request.Form["jobTypeID"];
            DataTable dt = new DataAccess.RunProcedure().SpotGetSaleList(jobTypeID).Tables[0];
            dt.TableName = "sale";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt.Copy());
            string json = JsonConvert.SerializeObject(ds);
            context.Response.Write(json);
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
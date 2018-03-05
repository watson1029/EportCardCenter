using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// GetJobType 的摘要说明
    /// </summary>
    public class GetJobType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jobType = context.Request.Form["jobType"];
            DataTable dt = new DataAccess.Para_JobType().GetList("JobTypeParent='" + jobType + "'").Tables[0];
            dt.TableName = "business";
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
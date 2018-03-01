using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax
{
    /// <summary>
    /// JobDelete 的摘要说明
    /// </summary>
    public class JobDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jobID = context.Request.Form["jobID"];
            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            string dbName = run.GetListDbName(jobID);
            if (string.IsNullOrEmpty(dbName))
                context.Response.Write("获取子表数据失败!");
            else
            {
                if (run.JobDelete(jobID, dbName))
                    context.Response.Write("");
                else
                    context.Response.Write("删除失败!");
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
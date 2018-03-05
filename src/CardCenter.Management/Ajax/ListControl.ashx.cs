using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// ListControl 的摘要说明
    /// </summary>
    public class ListControl : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["jobID"];
                string listID = context.Request.Form["listID"];
                int selectOperation = int.Parse(context.Request.Form["selectOperation"]);
                string content = context.Request.Form["content"];

                string dbName = new DataAccess.RunProcedure().GetListDbName(jobID);
                if (string.IsNullOrEmpty(dbName))
                    context.Response.Write("获取子表失败!");
                else
                {
                    if (new DataAccess.RunProcedure().ListOperation(listID, selectOperation, content, dbName))
                        context.Response.Write("");
                    else
                        context.Response.Write("请联系网站管理员!");
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
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
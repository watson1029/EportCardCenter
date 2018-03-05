using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// BindBar 的摘要说明
    /// </summary>
    public class BindBar : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["jobID"];
                string barCode = context.Request.Form["barCode"];
                DataAccess.TranHelper.BeginTran();
                new DataAccess.JobBar().BindFile(barCode, jobID);
                try
                {
                    DataAccess.TranHelper.CommitTran();
                    context.Response.Write("");
                }
                catch (Exception ex)
                {
                    context.Response.Write("数据提交出错!" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString());
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
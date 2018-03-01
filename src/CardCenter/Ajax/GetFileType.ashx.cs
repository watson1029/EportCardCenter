using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax
{
    /// <summary>
    /// GetFileType 的摘要说明
    /// </summary>
    public class GetFileType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.Form["type"];
            DataTable dt = new DataAccess.RunProcedure().SelectFileTypeByJobType(type).Tables[0];
            string JsonStr = JsonConvert.SerializeObject(dt);
            context.Response.Write(JsonStr);
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
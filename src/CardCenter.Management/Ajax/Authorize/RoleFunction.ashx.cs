using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax.Authorize
{
    /// <summary>
    /// RoleFunction 的摘要说明
    /// </summary>
    public class RoleFunction : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                int roleid = int.Parse(context.Request.Form["roleid"]);
                string authorize = context.Request.Form["authorize"];
                Entity.Sys_Role role = new DataAccess.Sys_Role().GetModel(roleid);
                role.FunctionAuthorize = authorize;
                if (new DataAccess.Sys_Role().Update(role))
                    context.Response.Write("");
                else
                    context.Response.Write("修改失败！入库出错，请联系管理员！");
            }
            catch (Exception ex)
            {
                context.Response.Write("修改失败！请联系管理员！" + ex.ToString());
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax.Authorize
{
    /// <summary>
    /// UserRole 的摘要说明
    /// </summary>
    public class UserRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string userid = context.Request.Form["userid"];
                string authorize = context.Request.Form["authorize"];
                Entity.Sys_User user = new DataAccess.Sys_User().GetModel(userid);
                user.RoleAuthorize = authorize;
                if (new DataAccess.Sys_User().Update(user))
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
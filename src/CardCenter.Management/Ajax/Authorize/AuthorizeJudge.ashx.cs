using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax.Authorize
{
    /// <summary>
    /// AuthorizeJudge 的摘要说明
    /// </summary>
    public class AuthorizeJudge : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            bool IsAuthorize = false;
            string param = context.Request.Form["param"];
            string[] roles = PageBase.CommonObject.ManagerUserInfo.role.Split('#');
            Entity.Sys_Menu menu = new DataAccess.Sys_Menu().DataRowToModel(new DataAccess.Sys_Menu().GetList(string.Format("MenuCode='{0}'", param)).Tables[0].Rows[0]);
            if (PageBase.CommonObject.ManagerUserInfo.isSuperUser)
                IsAuthorize = true;
            else
            {
                foreach (string roleid in roles)
                {
                    if (!string.IsNullOrEmpty(roleid))
                    {
                        Entity.Sys_Role role = new DataAccess.Sys_Role().GetModel(int.Parse(roleid));
                        if (role.MenuAuthorize.IndexOf(menu.ID.ToString()) >= 0)
                        {
                            IsAuthorize = true;
                            break;
                        }
                    }
                }
            }
            if (IsAuthorize)
                context.Response.Write(menu.MenuUrl);
            else
                context.Response.Write("../PowerError.aspx");
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
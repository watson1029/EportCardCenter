using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request.Form["username"];
            string password = context.Request.Form["password"];
            string remember = context.Request.Form["remember"];
            DataAccess.Sys_User da = new DataAccess.Sys_User();
            DataTable dt = da.GetList("UserName='" + username + "' and IsDelete=0").Tables[0];
            if (dt.Rows.Count == 0)
                context.Response.Write(JsonConvert.SerializeObject(new Data("用户名不存在.", "")));
            else
            {
                Entity.Sys_User model = da.DataRowToModel(dt.Rows[0]);
                string cookie = ZWL.ObjectOperation.CookieHelper.GetCookie("pw");
                if (cookie == password)
                {
                    if (password == model.Password)
                    {
                        SaveCookie(username, password, remember);
                        PageBase.CommonObject.ManagerUserInfo = GetUserInfo(model);
                        context.Response.Write(JsonConvert.SerializeObject(new Data("", "")));
                    }
                    else
                        context.Response.Write(JsonConvert.SerializeObject(new Data("密码错误.", "")));
                }
                else
                {
                    if (ZWL.Encrypt.AbstractHelper.EncryptMD5(password) == model.Password)
                    {
                        SaveCookie(username, password, remember);
                        PageBase.CommonObject.ManagerUserInfo = GetUserInfo(model);
                        context.Response.Write(JsonConvert.SerializeObject(new Data("", "")));
                    }
                    else
                        context.Response.Write(JsonConvert.SerializeObject(new Data("密码错误.", "")));
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void SaveCookie(string username, string password, string remember)
        {
            if (remember == "checked")
            {
                ZWL.ObjectOperation.CookieHelper.SetCookie("un", username);
                ZWL.ObjectOperation.CookieHelper.SetCookie("pw", ZWL.Encrypt.AbstractHelper.EncryptMD5(password));
            }
        }

        private PageBase.ManagerUserEntity GetUserInfo(Entity.Sys_User user)
        {
            PageBase.ManagerUserEntity entity = new PageBase.ManagerUserEntity();
            entity.guid = user.Guid;
            entity.username = user.UserName;
            entity.name = user.Name;
            entity.role = user.RoleAuthorize;
            entity.department = (int)user.Department;
            entity.isSuperUser = user.IsSuperUser;
            entity.phone = user.Phone;
            entity.pic = user.Pic;
            return entity;
        }
    }

    public class Data
    {
        public string error;
        public string msg;
        public Data(string error, string msg)
        {
            this.error = error;
            this.msg = msg;
        }
    }
}
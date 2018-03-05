using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// SaveUser 的摘要说明
    /// </summary>
    public class SaveUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                Entity.Sys_User user = new Entity.Sys_User();
                DataAccess.Sys_User da = new DataAccess.Sys_User();
                switch (context.Request.Form["type"])
                {
                    case "add":
                        user.Guid = Guid.NewGuid().ToString();
                        user.UserName = context.Request.Form["userName"];
                        if (da.GetList(string.Format("UserName='{0}'", user.UserName)).Tables[0].Rows.Count > 0)
                        {
                            context.Response.Write("添加用户信息失败！用户名已存在！");
                            return;
                        }
                        user.Name = context.Request.Form["trueName"];
                        string encrpyPwd = da.RndPwd(8);
                        user.Password = ZWL.Encrypt.AbstractHelper.EncryptMD5(encrpyPwd);
                        user.Phone = context.Request.Form["phoneNum"];
                        user.Department = int.Parse(context.Request.Form["department"]);
                        user.IsDelete = false;
                        user.IsSuperUser = false;
                        user.Pic = "avatar.png";
                        user.CreateTime = DateTime.Now;
                        if (da.Add(user))
                        {
                            DataAccess.CardCenterHelper.SendPwdMessage(user, encrpyPwd);
                            context.Response.Write("");
                        }
                        else
                            context.Response.Write("添加用户信息失败！入库出错，请联系管理员！");
                        break;
                    case "edit":
                        user = da.GetModel(context.Request.Form["Guid"]);
                        user.Name = context.Request.Form["trueName"];
                        user.Phone = context.Request.Form["phoneNum"];
                        user.Department = int.Parse(context.Request.Form["department"]);
                        if (da.Update(user))
                            context.Response.Write("");
                        else
                            context.Response.Write("修改用户信息失败！入库出错，请联系管理员！");
                        break;
                    case "reset":
                        user = da.GetModel(context.Request.Form["Guid"]);
                        string resetPwd = da.RndPwd(8);
                        user.Password = ZWL.Encrypt.AbstractHelper.EncryptMD5(resetPwd);
                        if (da.Update(user))
                        {
                            DataAccess.CardCenterHelper.SendPwdMessage(user, resetPwd);
                            context.Response.Write("");
                        }
                        else
                            context.Response.Write("重置密码失败！入库出错，请联系管理员！");
                        break;
                    case "pwd":
                        user = da.GetModel(context.Request.Form["Guid"]);
                        if (user.Password == ZWL.Encrypt.AbstractHelper.EncryptMD5(context.Request.Form["oldPwd"]))
                        {
                            user.Password = ZWL.Encrypt.AbstractHelper.EncryptMD5(context.Request.Form["newPwd"]);
                            if (da.Update(user))
                                context.Response.Write("");
                            else
                                context.Response.Write("修改失败！入库出错，请联系管理员！");
                        }
                        else
                            context.Response.Write("旧密码错误，修改失败！");
                        break;
                    default:
                        context.Response.Write("参数错误！");
                        break;
                }

            }
            catch (Exception ex)
            {
                context.Response.Write("操作失败！请联系管理员！" + ex.ToString());
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
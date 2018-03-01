using CardCenter.PageBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// Question 的摘要说明
    /// </summary>
    public class Question : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                Entity.Question entity = new Entity.Question();
                entity.Guid = Guid.NewGuid().ToString();
                entity.CustomCode = CommonObject.LoginUserInfo.companyId;
                entity.CreateTime = DateTime.Now;
                entity.Q1 = int.Parse(context.Request.Form["q1"]);
                for (int i = 1; i <= 5; i++)
                {
                    entity.Q2Content += context.Request.Form["check2_" + i] == null ? "" : context.Request.Form["check2_" + i] + "-";
                }
                if (!string.IsNullOrEmpty(entity.Q2Content))
                    entity.Q2Content = entity.Q2Content.Remove(entity.Q2Content.Length - 1);
                entity.Q3 = int.Parse(context.Request.Form["q3"]);
                entity.Q4 = int.Parse(context.Request.Form["q4"]);
                if (entity.Q4 == 1)
                    entity.Q5 = int.Parse(context.Request.Form["q5"]);
                else
                {
                    entity.Q6 = int.Parse(context.Request.Form["q6"]);
                    if (entity.Q6 == 7)
                        entity.Q6Content = context.Request.Form["check6_7_txt"];
                }
                entity.Q7 = int.Parse(context.Request.Form["q7"]);
                entity.Q8Content = context.Request.Form["check8_1_txt"];

                DataAccess.TranHelper.BeginTran();
                new DataAccess.Question().Add(entity);
                try
                {
                    DataAccess.TranHelper.CommitTran();
                    context.Response.Write("");
                }
                catch (Exception ex)
                {
                    context.Response.Write("提交问卷失败！" + ex.Message);
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
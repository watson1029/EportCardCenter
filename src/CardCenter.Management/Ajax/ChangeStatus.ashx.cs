using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// ChangeStatus 的摘要说明
    /// </summary>
    public class ChangeStatus : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                int select = int.Parse(context.Request.Form["select"]);
                string listid = context.Request.Form["listid"];
                Entity.SaleList entity = new DataAccess.SaleList().GetModel(listid);
                entity.ManagerFlag = select;
                entity.ManagerUser = PageBase.CommonObject.ManagerUserInfo.guid;
                entity.ManagerTime = DateTime.Now;
                new DataAccess.SaleList().Update(entity);
                try
                {
                    DataAccess.TranHelper.CommitTran();
                    context.Response.Write(JsonConvert.SerializeObject(new Data("", entity.ManagerUser, entity.ManagerTime)));
                }
                catch (Exception ex)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new Data("数据提交出错!" + ex.Message, "", null)));
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new Data("修改发放信息错误！" + ex.Message, "", null)));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class Data
        {
            public string error;
            public string user;
            public string time;

            public Data(string error, string user, DateTime? time)
            {
                this.error = error;
                if(!string.IsNullOrEmpty(user))
                    this.user = new DataAccess.ManagerUser().GetModel(user).Name;
                if(time != null)
                    this.time = time.Value.ToString("yyyy年MM月dd日 HH时mm分");
            }
        }
    }
}
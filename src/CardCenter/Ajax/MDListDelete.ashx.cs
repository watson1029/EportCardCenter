using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// MDListDelete 的摘要说明
    /// </summary>
    public class MDListDelete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string listID = context.Request.Form["listID"];
            string jobID = new DataAccess.ModifyList().GetModel(listID).JobID;
            DataSet view = new DataAccess.RunProcedure().JobView(jobID, "ModifyList");
            if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
            {
                if (new DataAccess.RunProcedure().MDListDelete(listID))
                    context.Response.Write("");
                else
                    context.Response.Write("删除失败!");
            }
            else
                context.Response.Write("该工单状态为已提交，无法继续修改工单信息!");
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
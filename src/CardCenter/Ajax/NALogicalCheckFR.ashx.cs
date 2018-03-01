using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// NALogicalCheckFR 的摘要说明
    /// </summary>
    public class NALogicalCheckFR : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int IDType = Convert.ToInt32(context.Request.Form["dlZJLX_QS"]);
            string IDNum = context.Request.Form["txtZJHM_QS"];
            string companyID = PageBase.CommonObject.LoginUserInfo.companyId;
            string jobID = context.Request.Form["hJobID"];
            string listID = context.Request.Form["hListID"];

            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            DataTable dt = run.NALogicalCheckFR(IDType, IDNum, companyID, jobID, listID).Tables[0];

            if(int.Parse(dt.Rows[0]["thisFR"].ToString()) > 0)
                context.Response.Write("1");
            else if(int.Parse(dt.Rows[0]["otherFR"].ToString()) > 0)
                context.Response.Write("2");
            else
                context.Response.Write("3");

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
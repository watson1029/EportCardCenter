using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// NALogicalCheckQT 的摘要说明
    /// </summary>
    public class NALogicalCheckQT : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int IDType = int.Parse(context.Request.Form["holdIDType"]);
            string IDNum = context.Request.Form["holdID"];
            string companyID = PageBase.CommonObject.LoginUserInfo.companyId;
            string jobID = context.Request.Form["hJobID"];
            string listID = context.Request.Form["hListID"];

            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            DataTable dt = run.NALogicalCheckQT(IDType, IDNum, companyID, jobID, listID).Tables[0];

            if (int.Parse(dt.Rows[0]["thisQT"].ToString()) > 0)
                context.Response.Write("1");
            else if (int.Parse(dt.Rows[0]["otherQT"].ToString()) > 0)
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
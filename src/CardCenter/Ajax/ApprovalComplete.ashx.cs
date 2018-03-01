using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// ApprovalComplete 的摘要说明
    /// </summary>
    public class ApprovalComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jobID = context.Request.Form["jobID"];
            DataAccess.TranHelper.BeginTran();
            Entity.FlowInfo flow = new Entity.FlowInfo();
            flow.Guid = Guid.NewGuid().ToString();
            flow.JobID = jobID;
            flow.FlowID = 4;
            flow.SubmitDate = DateTime.Now;
            flow.SubmitUser = PageBase.CommonObject.LoginUserInfo.companyId;
            flow.Content = PageBase.CommonObject.LoginCompanyInfo.FULL_NAME + "完成国税.质检.工商部门审批";
            flow.IsDelete = false;
            flow.Remark = "";
            new DataAccess.FlowInfo().Add(flow);
            Entity.HandleList handle = new DataAccess.HandleList().DataRowToModel(new DataAccess.HandleList().GetList("OpeartionID=5 and JobID='" + jobID + "'").Tables[0].Rows[0]);
            handle.IsChecked = true;
            handle.Status = "已处理";
            handle.OpeartionUser = PageBase.CommonObject.LoginUserInfo.companyId;
            handle.OpeartionTime = DateTime.Now;
            handle.Remark = PageBase.CommonObject.LoginCompanyInfo.FULL_NAME + "完成国税.质检.工商部门审批";
            new DataAccess.HandleList().Update(handle);
            try
            {
                DataAccess.TranHelper.CommitTran();
                context.Response.Write("");
            }
            catch (Exception ex)
            {
                context.Response.Write("数据提交出错!" + ex.ToString());
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
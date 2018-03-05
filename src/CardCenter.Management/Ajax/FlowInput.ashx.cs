using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// FlowInput 的摘要说明
    /// </summary>
    public class FlowInput : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["jobID"];
                string jobType = context.Request.Form["jobType"];
                string selectFlow = context.Request.Form["selectFlow"];
                string content = context.Request.Form["content"];
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                string dbName = run.GetListDbName(jobID);
                //生成受理回执
                #region 2016.4.21业务修改为提交工单后可下载回执，本段代码取消
                //if(selectFlow == "5")
                //{
                //    FileInfo file = new FileInfo(context.Server.MapPath("../ApprovalDemo/业务受理审批回执.jpg"));
                //    string fileName =  Guid.NewGuid().ToString() + ".jpg";
                //    file.CopyTo(ZWL.GeneralHelper.GetSettingByKey("CardPrintingApprovalPath") + fileName, true);
                //    CardPrinting.Entity.JobInfo job = new CardPrinting.DataAccess.JobInfo().GetModel(jobID);
                //    job.ApprovalFile = fileName;
                //    if (!new CardPrinting.DataAccess.JobInfo().Update(job))
                //    {
                //        context.Response.Write("生成业务受理审批回执失败!");
                //        return;
                //    }
                //}
                #endregion
                if (new DataAccess.StatusType().GetModel(int.Parse(selectFlow)).StatusName.Contains("已办结"))
                {
                    if(!run.CanFinish(jobID, dbName))
                    {
                        context.Response.Write("请先完成工单项处理，再标记工单流程为【已办结】!");
                        return;
                    }
                }
                Entity.FlowInfo entity = new Entity.FlowInfo();
                entity.Guid = Guid.NewGuid().ToString();
                entity.JobID = jobID;
                entity.FlowID = int.Parse(selectFlow);
                entity.SubmitDate = DateTime.Now;
                entity.SubmitUser = PageBase.CommonObject.ManagerUserInfo.guid;
                entity.Content = content;
                entity.IsDelete = false;
                entity.Remark = "";
                DataAccess.TranHelper.BeginTran();
                new DataAccess.FlowInfo().Add(entity);
                try
                {
                    DataAccess.TranHelper.CommitTran();
                    context.Response.Write("提交成功");
                }
                catch (Exception ex)
                {
                    context.Response.Write("提交失败" + ex.Message);
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
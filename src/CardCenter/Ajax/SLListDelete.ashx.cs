using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// SLListDelete 的摘要说明
    /// </summary>
    public class SLListDelete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string listID = context.Request.Form["listID"];
            string jobID = new DataAccess.SaleList().GetModel(listID).JobID;
            DataAccess.RunProcedure run = new DataAccess.RunProcedure();
            DataSet view = run.JobView(jobID, "SaleList");
            if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
            {
                if (run.SLListDelete(listID))
                {
                    Entity.JobInfo job = new DataAccess.JobInfo().GetModel(jobID);
                    DataTable feeDt = run.JobFeeDetal(job.JobID, "SaleList").Tables[0];
                    job.Fee = decimal.Parse(feeDt.Rows[0]["Fee"].ToString());
                    if (job.Fee == 0)
                        job.FeeFlat = "无须缴费";
                    else
                        job.FeeFlat = "待缴费";
                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.JobInfo().Update(job);
                    try
                    {
                        DataAccess.TranHelper.CommitTran();
                        context.Response.Write("");
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("\n更新缴费信息出错!" + ex.Message);
                    }
                }
                else
                    context.Response.Write("删除工单项失败!");
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
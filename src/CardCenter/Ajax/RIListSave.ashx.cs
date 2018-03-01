using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// RIListSave 的摘要说明
    /// </summary>
    public class RIListSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "ReIssueList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.ReIssueList ri = new Entity.ReIssueList();
                    DataAccess.ReIssueList da = new DataAccess.ReIssueList();
                    DateTime time = DateTime.Now;

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        ri.JobType = "RI00" + context.Request.Form["cardType"];
                        ri.ListID = ri.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        ri.JobID = jobID;
                        ri.CardType = Enum.Parse(typeof(Entity.Enum.CardType), context.Request.Form["CardType"]).ToString();
                    }
                    else
                    {
                        ri = da.GetModel(listID);
                    }
                    ri.CardholderName = context.Request.Form["holdName"];
                    ri.IsDelete = false;
                    ri.Remark = "";

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.RIDataAccess().InsertListData(ri);
                    try
                    {
                        DataAccess.TranHelper.CommitTran();
                        context.Response.Write("");
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("\n数据提交出错!" + ex.Message);
                    }
                }
                else
                    context.Response.Write("该工单状态为已提交，无法继续修改工单信息!");
            }
            catch (Exception ex)
            {
                context.Response.Write("\n" + ex.Message);
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
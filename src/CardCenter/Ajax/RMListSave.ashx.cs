using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// RMListSave 的摘要说明
    /// </summary>
    public class RMListSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "ReMakeList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.ReMakeList rm = new Entity.ReMakeList();
                    DataAccess.ReMakeList da = new DataAccess.ReMakeList();
                    DateTime time = DateTime.Now;

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        rm.JobType = "RM001";
                        rm.ListID = rm.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        rm.JobID = jobID;
                        rm.CardType = "报关员卡";
                    }
                    else
                    {
                        rm = da.GetModel(listID);
                    }
                    rm.CardholderName = context.Request.Form["holdName"];
                    rm.CardNum = context.Request.Form["holdID"];
                    rm.IsDelete = false;
                    rm.Remark = "";

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.RMDataAccess().InsertListData(rm);
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
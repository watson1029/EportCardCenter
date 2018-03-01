using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// UUListSave 的摘要说明
    /// </summary>
    public class UUListSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "UpdateUnlockList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.UpdateUnlockList uu = new Entity.UpdateUnlockList();
                    DataAccess.UpdateUnlockList da = new DataAccess.UpdateUnlockList();
                    DateTime time = DateTime.Now;

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        uu.JobType = "UU00" + ((int.Parse(context.Request.Form["businessType"]) * 4) + int.Parse(context.Request.Form["cardType"])).ToString();
                        uu.ListID = uu.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        uu.JobID = jobID;
                        uu.CardType = Enum.Parse(typeof(Entity.Enum.CardType), context.Request.Form["CardType"]).ToString();
                    }
                    else
                    {
                        uu = da.GetModel(listID);
                    }
                    uu.CardNum = context.Request.Form["txtCardNum"];
                    uu.CardholderName = context.Request.Form["holdName"];
                    uu.IsDelete = false;
                    uu.Remark = "";

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.UUDataAccess().InsertListData(uu);
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
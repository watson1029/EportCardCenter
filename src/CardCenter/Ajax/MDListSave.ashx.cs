using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// MDListSave 的摘要说明
    /// </summary>
    public class MDListSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "ModifyList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.ModifyList md = new Entity.ModifyList();
                    DataAccess.ModifyList da = new DataAccess.ModifyList();
                    DateTime time = DateTime.Now;

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        md.JobType = "MD00" + ((int.Parse(context.Request.Form["cardType"]) * 2) - int.Parse(context.Request.Form["businessType"])).ToString();
                        md.ListID = md.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        md.JobID = jobID;
                        md.CardType = Enum.Parse(typeof(Entity.Enum.CardType), context.Request.Form["CardType"]).ToString();
                    }
                    else
                    {
                        md = da.GetModel(listID);
                    }
                    md.CardNum = context.Request.Form["txtCardNum"];
                    md.CardholderName = context.Request.Form["holdName"];
                    md.IsChangeName = context.Request.Form["changeName"] == "on" ? true : false;
                    md.IsDelete = false;
                    md.Remark = "";

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.MDDataAccess().InsertListData(md);
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
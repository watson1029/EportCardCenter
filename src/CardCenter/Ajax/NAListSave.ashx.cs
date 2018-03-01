using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// NAListSave 的摘要说明
    /// </summary>
    public class NAListSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "NewlyAddedList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.NewlyAddedList na = new Entity.NewlyAddedList();
                    DataAccess.NewlyAddedList da = new DataAccess.NewlyAddedList();
                    DateTime time = DateTime.Now;

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        na.JobType = "NA00" + ((int.Parse(context.Request.Form["cardType"]) * 2) - int.Parse(context.Request.Form["businessType"])).ToString();
                        na.ListID = na.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        na.JobID = jobID;
                        na.CardType = Enum.Parse(typeof(Entity.Enum.CardType), context.Request.Form["CardType"]).ToString();
                    }
                    else
                    {
                        na = da.GetModel(listID);
                    }
                    na.CardholderName = context.Request.Form["holdName"];
                    na.CardholderPhone = context.Request.Form["txtCardholderPhone"];
                    na.CardholderIdentificationType = int.Parse(context.Request.Form["holdIDType"]);
                    na.CardholderIdentificationNum = context.Request.Form["holdID"];
                    na.IsDelete = false;
                    na.Remark = "";

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.NADataAccess().InsertListData(na);
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
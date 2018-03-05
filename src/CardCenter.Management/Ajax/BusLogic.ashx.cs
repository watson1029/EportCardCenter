using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
	[Serializable]
	public class RequestDataJSON
	{
		public string id
		{
			get;
			set;
		}
		public string operation
		{
			get;
			set;
		}
		public string remark
		{
			get;
			set;
		}
		 
	}
	/// <summary>
	/// BusLogic 的摘要说明
	/// </summary>
    public class BusLogic : IHttpHandler, IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{

			try
			{

				string strAction = context.Request.QueryString["Action"];
				switch ( strAction )
				{
					case "Save":
						Save(context);
						break;
					case "Cancel":
						Cancel(context);
						break;
                    case "SendQS":
                        SendQS(context);
                        break;
                    case "SendDKQ":
                        SendDKQ(context);
                        break;
                    default:
						break;
				}

			}
			catch ( Exception ex )
			{

				context.Response.Write("保存失败" + ex.Message);
			}
			 
		}

		/// <summary>
		/// 保存提交
		/// </summary>
		/// <param name="context"></param>
		private static void Save(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			var data = context.Request;
			var sr = new StreamReader(data.InputStream);
			var stream = sr.ReadToEnd();
			var javaScriptSerializer = new JavaScriptSerializer();
            RequestDataJSON[] PostedData = javaScriptSerializer.Deserialize<RequestDataJSON[]>(stream);
            bool flag = true;
            if (PostedData != null)
            {
                string jobID = null;
                DateTime time = DateTime.Now;
                DataAccess.TranHelper.BeginTran();                
                foreach (RequestDataJSON post in PostedData)
                {
                    Entity.HandleList handle = new DataAccess.HandleList().GetModel(post.id);
                    handle.IsChecked = bool.Parse(post.operation == "" ? "false" : post.operation);
                    handle.Status = handle.IsChecked ? "已处理" : "待处理";
                    handle.Remark = post.remark;
                    handle.OpeartionUser = PageBase.CommonObject.ManagerUserInfo.guid;
                    handle.OpeartionTime = time;
                    jobID = handle.JobID;
                    
                    if (handle.FunctionID.Equals("A06") && handle.JobID.IndexOf("SL") >= 0)
                    {
                        DataSet sl = new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and IsDelete=0", handle.JobID));
                        if (sl.Tables[0].Select("ManagerFlag<>2").Length > 0)
                            flag = false;
                        else
                            new DataAccess.HandleList().Update(handle);
                    }
                    else
                        new DataAccess.HandleList().Update(handle);
                    if (handle.OpeartionID == 8)
                    {
                        Entity.JobInfo job = new DataAccess.JobInfo().GetModel(handle.JobID);
                        job.FeeFlat = handle.IsChecked ? "已缴费" : "待缴费";
                        new DataAccess.JobInfo().Update(job);
                    }
                }
                try
                {
                    DataAccess.TranHelper.CommitTran();
                    if (jobID != null)
                    {
                        Entity.JobInfo job = new DataAccess.JobInfo().GetModel(jobID);
                        switch (job.JobType)
                        {
                            case "NA":
                                new DataAccess.NADataAccess().ChangeFlow(job);
                                break;
                            case "MD":
                                new DataAccess.MDDataAccess().ChangeFlow(job);
                                break;
                            case "RI":
                                new DataAccess.RIDataAccess().ChangeFlow(job);
                                break;
                            case "RM":
                                new DataAccess.RMDataAccess().ChangeFlow(job);
                                break;
                            case "SL":
                                new DataAccess.SLDataAccess().ChangeFlow(job);
                                break;
                            case "UU":
                                new DataAccess.UUDataAccess().ChangeFlow(job);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write("提交失败" + ex.Message);
                }
            }
            if(flag)
			    context.Response.Write("提交成功");
            else
                context.Response.Write("工单项发放状态标记为“已发放”后，才允许修改发放环节状态！");
        }
		/// <summary>
		/// 退单
		/// </summary>
		/// <param name="context"></param>
		private static void Cancel(HttpContext context)
		{
            string jobid = context.Request["jobid"];
            string reason = context.Request["reason"];
            Entity.FlowInfo flow = new Entity.FlowInfo();
            flow.Guid = Guid.NewGuid().ToString();
            flow.JobID = jobid;
            flow.FlowID = 18;
            flow.SubmitDate = DateTime.Now;
            flow.SubmitUser = PageBase.CommonObject.ManagerUserInfo.guid;
            flow.Content = reason;
            flow.IsDelete = false;
            DataAccess.TranHelper.BeginTran();
            new DataAccess.FlowInfo().Add(flow);
            if (jobid.Substring(0, 2) == "SL")
            {
                DataTable dtSale = new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and IsDelete=0", jobid)).Tables[0];
                foreach (DataRow drSale in dtSale.Rows)
                {
                    Entity.SaleList mSale = new DataAccess.SaleList().DataRowToModel(drSale);
                    Entity.Stock_Commodity mCommodity = new DataAccess.Stock_Commodity().GetEntity(mSale.ProductType);
                    mCommodity.StockDesplay += mSale.Num;
                    new DataAccess.Stock_Commodity().Update(mCommodity);
                }
            }
            try
            {
                DataAccess.TranHelper.CommitTran();
                context.Response.Write("失效成功");
            }
            catch (Exception ex)
            {
                context.Response.Write("失效失败" + ex.Message);
            }
		}

        private static void SendQS(HttpContext context)
        {
            try
            {
                string jobid = context.Request["jobid"];
                string content = context.Request["content"];
                DataAccess.CardCenterHelper.SendMessageQS(jobid, content);
                context.Response.Write("发送成功");
            }
            catch (Exception ex)
            {
                context.Response.Write("发送失败" + ex.Message);
            }
        }

        private static void SendDKQ(HttpContext context)
        {
            try
            {
                string jobid = context.Request["jobid"];
                string content = context.Request["content"];
                DataAccess.CardCenterHelper.SendMessageDKQ(jobid, content);
                context.Response.Write("发送成功");
            }
            catch (Exception ex)
            {
                context.Response.Write("发送失败" + ex.Message);
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
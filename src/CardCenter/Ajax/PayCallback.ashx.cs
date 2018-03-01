using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// PayCallback 的摘要说明
    /// </summary>
    public class PayCallback : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (string key in context.Request.Params)
                    dic.Add(key, context.Request.QueryString[key]);
                if (!DataAccess.PayHelper.Verify(dic))
                    context.Response.Write(JsonConvert.SerializeObject(new Data("FAIL", "SignatureInvalid")));
                else
                {
                    string jobID = dic["OrderId"];
                    string status = dic["Status"];
                    DateTime date = new DateTime();
                    try
                    {
                        jobID = dic["OrderId"];
                        status = dic["Status"];
                        date = DateTime.ParseExact(dic["LastUpdated"], "yyyyMMddHHmmss", null).AddHours(8);
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new Data("FAIL", "ArgumentsInvalid." + ex.ToString())));
                        return;
                    }
                    switch (status)
                    {
                        case "Success":
                            Entity.JobInfo job = new DataAccess.JobInfo().GetModel(jobID);
                            Entity.HandleList handle = new DataAccess.HandleList().GetFeeData(jobID);
                            if (job == null || handle == null)
                                context.Response.Write(JsonConvert.SerializeObject(new Data("FAIL", "OrderNotFound")));
                            else
                            {
                                if (job.FeeFlat.Equals("已缴费"))
                                    context.Response.Write(JsonConvert.SerializeObject(new Data("SUCCESS", "OK")));
                                else
                                {
                                    job.FeeFlat = "已缴费";
                                    handle.IsChecked = true;
                                    handle.Status = "已处理";
                                    handle.OpeartionUser = job.CustomsCode;
                                    handle.OpeartionTime = date;
                                    handle.Remark = "网上支付";

                                    //提交事务至后台
                                    DataAccess.TranHelper.BeginTran();
                                    new DataAccess.JobInfo().Update(job);
                                    new DataAccess.HandleList().Update(handle);
                                    try
                                    {
                                        DataAccess.TranHelper.CommitTran();
                                        switch (job.JobType)
                                        {
                                            case "NA":
                                                new CardCenter.DataAccess.NADataAccess().ChangeFlow(job);
                                                break;
                                            case "MD":
                                                new CardCenter.DataAccess.MDDataAccess().ChangeFlow(job);
                                                break;
                                            case "RI":
                                                new CardCenter.DataAccess.RIDataAccess().ChangeFlow(job);
                                                break;
                                            case "RM":
                                                new CardCenter.DataAccess.RMDataAccess().ChangeFlow(job);
                                                break;
                                            case "SL":
                                                new CardCenter.DataAccess.SLDataAccess().ChangeFlow(job);
                                                break;
                                            case "UU":
                                                new CardCenter.DataAccess.UUDataAccess().ChangeFlow(job);
                                                break;
                                        }
                                        context.Response.Write(JsonConvert.SerializeObject(new Data("SUCCESS", "OK")));
                                    }
                                    catch (Exception ex)
                                    {
                                        context.Response.Write(JsonConvert.SerializeObject(new Data("FAIL", "WriteDataError." + ex.ToString())));
                                        return;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new Data("FAIL", "SystemError." + ex.ToString())));
                return;
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

    public class Data
    {
        public string Result;
        public string Message;

        public Data(string result, string message)
        {
            this.Result = result;
            this.Message = message;
        }

    }
}
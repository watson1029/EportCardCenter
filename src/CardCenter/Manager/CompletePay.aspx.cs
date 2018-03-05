using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Manager
{
    public partial class CompletePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (string key in Request.Params)
                        dic.Add(key, Request.QueryString[key]);
                    if (!DataAccess.PayHelper.Verify(dic))
                        lblMessage.Text = "验签失败.";
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
                            lblMessage.Text = "参数错误." + ex.ToString();
                            return;
                        }
                        switch (status)
                        {
                            case "Success":
                                Entity.JobInfo job = new DataAccess.JobInfo().GetModel(jobID);
                                Entity.HandleList handle = new DataAccess.HandleList().GetFeeData(jobID);
                                if (job == null || handle == null)
                                    lblMessage.Text = "订单数据不存在.";
                                else
                                {
                                    if (job.FeeFlat.Equals("已缴费"))
                                        Response.Redirect("JobList.aspx", false);
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
                                            Response.Redirect("JobList.aspx", false);
                                        }
                                        catch (Exception ex)
                                        {
                                            lblMessage.Text = "更新支付数据失败." + ex.ToString();
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
                    lblMessage.Text = "系统错误." + ex.ToString();
                    return;
                }
            }
        }
    }
}
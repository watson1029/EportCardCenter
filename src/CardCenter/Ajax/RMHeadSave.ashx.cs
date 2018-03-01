using CardCenter.PageBase;
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
    /// RMHeadSave 的摘要说明
    /// </summary>
    public class RMHeadSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                DataAccess.RunProcedure procedure = new DataAccess.RunProcedure();
                bool flat = true;
                if (!string.IsNullOrEmpty(jobID))
                {
                    DataSet view = procedure.JobView(jobID, "ReMakeList");
                    if (!view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                        flat = false;
                }
                if (flat)
                {
                    //JobInfo数据
                    Entity.JobInfo job = new Entity.JobInfo();
                    DateTime time = DateTime.Now;
                    job.JobID = string.IsNullOrEmpty(jobID) ? "RM-" + CardCenter.DataAccess.CardCenterHelper.GetCardNo() : jobID;
                    job.JobType = "RM";
                    job.CreateTime = time;
                    job.CreateUser = PageBase.CommonObject.LoginUserInfo.companyId;
                    job.IsDelete = false;
                    job.EnterpriseName = CommonObject.LoginCompanyInfo.FULL_NAME;
                    job.EnterpriseAddress = CommonObject.LoginCompanyInfo.ADDR_CO;
                    job.EnterpriseCode = CommonObject.LoginCompanyInfo.COP_GB_CODE;
                    job.AgentName = context.Request.Form["agentName"];
                    job.AgentPhone = context.Request.Form["agentPhone"];
                    job.ConsigneeName = context.Request.Form["consigneeName"];
                    job.ConsigneeAddress = context.Request.Form["consigneeAddress"];
                    job.ConsigneePhone = context.Request.Form["consigneePhone"];
                    job.ExpressFlat = null;
                    job.Remark = string.Empty;
                    job.Fee = 0;
                    job.FeeFlat = "无须缴费";
                    job.CustomsCode = CommonObject.LoginUserInfo.companyId;
                    job.IsOnline = true;

                    //FileList数据
                    List<Entity.FileList> fileList = new List<Entity.FileList>();
                    DataSet ds = procedure.SelectFileTypeByJobType("RM");
                    string fileErr = string.Empty;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string guid = context.Request.Form["h" + dr["FileTypeID"].ToString()];
                        string fileName = context.Request.Form["txt" + dr["FileTypeID"].ToString()];
                        if (!string.IsNullOrEmpty(guid))
                        {
                            Entity.FileList file = new Entity.FileList();
                            file.Guid = guid;
                            file.FileType = dr["FileTypeID"].ToString();
                            file.FileName = fileName;
                            file.JobID = job.JobID;
                            file.ListID = string.Empty;
                            file.IsDelete = false;
                            file.Remark = string.Empty;
                            fileList.Add(file);
                        }
                        else
                            fileErr += "\n工单随附资料【" + dr["FileTypeName"] + "】未上传!";
                    }

                    DataSet list = new DataAccess.ReMakeList().GetList("JobID='" + jobID + "' and IsDelete=0");
                    foreach (DataRow dr in list.Tables[0].Rows)
                    {
                        DataSet typeDs = procedure.SelectFileTypeByJobType(dr["JobType"].ToString());
                        foreach (DataRow typeDr in typeDs.Tables[0].Rows)
                        {
                            string guid = context.Request.Form["h" + typeDr["FileTypeID"].ToString() + dr["ListID"].ToString()];
                            string fileName = context.Request.Form["txt" + typeDr["FileTypeID"].ToString() + dr["ListID"].ToString()];
                            if (!string.IsNullOrEmpty(guid))
                            {
                                Entity.FileList file = new Entity.FileList();
                                file.Guid = guid;
                                file.FileType = typeDr["FileTypeID"].ToString();
                                file.FileName = fileName;
                                file.JobID = job.JobID;
                                file.ListID = dr["ListID"].ToString();
                                file.IsDelete = false;
                                file.Remark = string.Empty;
                                fileList.Add(file);
                            }
                            else
                                fileErr += "\n工单项【业务类型：" + new DataAccess.Para_JobType().GetModel(dr["JobType"].ToString()).JobName + "，持卡人姓名：" + dr["CardholderName"] + "】随附资料【" + typeDr["FileTypeName"] + "】未上传!";
                        }
                    }

                    if (context.Request.Form["type"] == "complete")
                    {
                        //判断是否添加附件
                        if (fileErr != "")
                        {
                            context.Response.Write(JsonConvert.SerializeObject(new Data(fileErr, "")));
                            return;
                        }
                        //判断是否添加工单项
                        ds = procedure.JobView(jobID, "ReMakeList");
                        if (ds.Tables[1].Rows.Count == 0)
                        {
                            context.Response.Write(JsonConvert.SerializeObject(new Data("\n请添加至少一条工单项记录!", "")));
                            return;
                        }
                    }

                    //FlowInfo数据
                    Entity.FlowInfo flow = new Entity.FlowInfo();
                    flow.Guid = Guid.NewGuid().ToString();
                    flow.JobID = job.JobID;
                    flow.FlowID = context.Request.Form["hSaveType"] == "add" ? 1 : int.Parse(new CardCenter.DataAccess.Flow().GetList("JobType='RM' and FlowOrder=2").Tables[0].Rows[0]["FlowStatus"].ToString());
                    flow.SubmitDate = time;
                    flow.SubmitUser = PageBase.CommonObject.LoginUserInfo.companyId;
                    flow.Content = context.Request.Form["hSaveType"] == "add" ? PageBase.CommonObject.LoginCompanyInfo.FULL_NAME + "暂存数据." : PageBase.CommonObject.LoginCompanyInfo.FULL_NAME + "提交工单.";
                    flow.IsDelete = false;
                    flow.Remark = string.Empty;

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    DataAccess.RMDataAccess rm = new DataAccess.RMDataAccess();
                    rm.InsertHeadData(job, fileList, flow);
                    if (context.Request.Form["hSaveType"] == "complete")
                        rm.InsertHandleList(job);
                    try
                    {
                        DataAccess.TranHelper.CommitTran();
                        DataAccess.CardCenterHelper.SendMessage(job.JobID);
                        context.Response.Write(JsonConvert.SerializeObject(new Data("", job.JobID)));
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new Data("\n数据提交出错!" + ex.Message, "")));
                    }
                }
                else
                    context.Response.Write(JsonConvert.SerializeObject(new Data("该工单状态为已提交，无法继续修改工单信息!", "")));
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new Data("\n" + ex.Message, "")));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class Data
        {
            public string error;
            public string msg;

            public Data(string error, string msg)
            {
                this.error = error;
                this.msg = msg;
            }
        }
    }
}
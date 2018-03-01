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
    /// SLHeadSave 的摘要说明
    /// </summary>
    public class SLHeadSave : IHttpHandler, IRequiresSessionState
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
                    DataSet view = procedure.JobView(jobID, "SaleList");
                    if (!view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                        flat = false;
                }
                if (flat)
                {
                    //JobInfo数据
                    Entity.JobInfo job = new Entity.JobInfo();
                    DateTime time = DateTime.Now;
                    job.JobID = string.IsNullOrEmpty(jobID) ? "SL-" + CardCenter.DataAccess.CardCenterHelper.GetCardNo() : jobID;
                    job.JobType = "SL";
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
                    job.ExpressFlat = context.Request.Form["expressflat"] == "快递" ? true : false;
                    job.Remark = string.Empty;
                    DataTable feeDt = procedure.JobFeeDetal(job.JobID, "SaleList").Tables[0];
                    job.Fee = decimal.Parse(feeDt.Rows[0]["Fee"].ToString());
                    if (job.Fee == 0)
                        job.FeeFlat = "无须缴费";
                    else
                        job.FeeFlat = "待缴费";
                    job.CustomsCode = CommonObject.LoginUserInfo.companyId;
                    job.IsOnline = true;
                    job.InvoiceName = context.Request.Form["txtInvoiceName"];
                    job.InvoicePhone = context.Request.Form["txtInvoicePhone"];
                    job.InvoiceAddress = context.Request.Form["txtInvoiceAddress"];
                    job.InvoicePostCode = context.Request.Form["txtInvoicePostCode"];
                    job.InvoiceEmail = context.Request.Form["txtInvoiceEmail"];
                    job.InvoiceCode = context.Request.Form["txtInvoiceCode"];

                    //FileList数据
                    List<Entity.FileList> fileList = new List<Entity.FileList>();
                    DataSet ds = procedure.SelectFileTypeByJobType("SL");
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

                    DataSet list = new DataAccess.SaleList().GetList("JobID='" + job.JobID + "' and IsDelete=0");
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
                        ds = procedure.JobView(job.JobID, "SaleList");
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
                    flow.FlowID = context.Request.Form["hSaveType"] == "add" ? 1 : int.Parse(new CardCenter.DataAccess.Flow().GetList("JobType='SL' and FlowOrder=2").Tables[0].Rows[0]["FlowStatus"].ToString());
                    flow.SubmitDate = time;
                    flow.SubmitUser = PageBase.CommonObject.LoginUserInfo.companyId;
                    flow.Content = context.Request.Form["hSaveType"] == "add" ? PageBase.CommonObject.LoginCompanyInfo.FULL_NAME + "暂存数据." : PageBase.CommonObject.LoginCompanyInfo.FULL_NAME + "提交工单.";
                    flow.IsDelete = false;
                    flow.Remark = string.Empty;

                    //SaleBinding数据
                    Entity.SaleBinding mBinding = new Entity.SaleBinding();
                    DataAccess.SaleBinding dalBinding = new DataAccess.SaleBinding();
                    DataTable dtBindList = dalBinding.GetList("SaleID='" + job.JobID + "'").Tables[0];
                    if (dtBindList.Rows.Count > 0)
                    {
                        mBinding = dalBinding.GetEntity(dtBindList.Rows[0][0].ToString());
                        mBinding.JobID = context.Request.Form["hJobList"];
                        dalBinding.Update(mBinding);
                    }
                    else
                    {
                        mBinding.Guid = Guid.NewGuid().ToString();
                        mBinding.SaleID = job.JobID;
                        mBinding.JobID = context.Request.Form["hJobList"];
                        dalBinding.Add(mBinding);
                    }

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    DataAccess.SLDataAccess sl = new DataAccess.SLDataAccess();
                    sl.InsertHeadData(job, fileList, flow);
                    if (context.Request.Form["hSaveType"] == "complete")
                    {
                        sl.InsertHandleList(job);
                        //减少显示库存
                        ds = new DataAccess.RunProcedure().JobView(jobID, "SaleList");
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            Entity.Stock_Commodity commodityEntity = new DataAccess.Stock_Commodity().GetEntity(dr["ProductType"].ToString());
                            commodityEntity.StockDesplay -= int.Parse(dr["Num"].ToString());
                            if (commodityEntity.StockDesplay < 0)
                            {
                                context.Response.Write(JsonConvert.SerializeObject(new Data(string.Format("\n{0}{1}（{2}）库存不足,请更换库存充足的安全产品厂商或稍后再试!", commodityEntity.AdditionalAttributes, commodityEntity.CommodityName, commodityEntity.CommodityType), "")));
                                return;
                            }
                            else
                                new DataAccess.Stock_Commodity().Update(commodityEntity);
                        }
                    }
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
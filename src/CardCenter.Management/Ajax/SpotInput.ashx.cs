using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// SpotInput 的摘要说明
    /// </summary>
    public class SpotInput : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hjobID"];
                string saleID = string.Empty;
                
                Entity.JobInfo job = new Entity.JobInfo();
                Entity.JobInfo sJob = new Entity.JobInfo();
                DateTime time = DateTime.Now;
                DataAccess.TranHelper.BeginTran();
                if (string.IsNullOrEmpty(jobID))
                {
                    DataAccess.RunProcedure procedure = new DataAccess.RunProcedure();
                    
                    //JobInfo数据
                    job.JobID = context.Request.Form["jobSelect"] + "-" + DataAccess.CardCenterHelper.GetCardNo();
                    job.JobType = context.Request.Form["jobSelect"];
                    job.EnterpriseName = context.Request.Form["companyName"];
                    job.AgentPhone = context.Request.Form["txtPhone"];
                    job.CreateTime = time;
                    job.CreateUser = context.Request.Form["customCode"];
                    job.IsDelete = false;
                    job.Remark = context.Request.Form["txtRemark"];
                    job.CustomsCode = context.Request.Form["customCode"].Length == 10 ? context.Request.Form["customCode"] : null;
                    job.IsOnline = false;
                    job.ExpressFlat = false;
                    if (job.JobType == "SL")
                    {
                        job.Fee = new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["saleSelect"]).SellingPrice * int.Parse(context.Request.Form["txtNum"]);
                        job.FeeFlat = "待缴费";
                    }
                    else
                    {
                        job.Fee = 0;
                        job.FeeFlat = "无须缴费";
                    }
                    new DataAccess.JobInfo().Add(job);

                    if (job.JobType == "NA" || job.JobType == "RI" || job.JobType == "RM")
                    {
                        sJob.JobID = "SL-" + DataAccess.CardCenterHelper.GetCardNo();
                        sJob.JobType = "SL";
                        sJob.EnterpriseName = job.EnterpriseName;
                        sJob.AgentPhone = job.AgentPhone;
                        sJob.CreateTime = job.CreateTime;
                        sJob.CreateUser = job.CreateUser;
                        sJob.IsDelete = false;
                        sJob.Remark = job.Remark;
                        sJob.CustomsCode = job.CustomsCode;
                        sJob.IsOnline = false;
                        sJob.Fee = new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["saleSelect"]).SellingPrice * int.Parse(context.Request.Form["txtNum"]);
                        sJob.FeeFlat = "待缴费";
                        sJob.ExpressFlat = false;
                        new DataAccess.JobInfo().Add(sJob);

                        Entity.SaleBinding saleBind = new Entity.SaleBinding();
                        saleBind.Guid = Guid.NewGuid().ToString();
                        saleBind.JobID = job.JobID;
                        saleBind.SaleID = sJob.JobID;
                        new DataAccess.SaleBinding().Add(saleBind);
                        saleID = saleBind.SaleID;
                    }

                    //FlowInfo数据
                    Entity.FlowInfo flow = new Entity.FlowInfo();
                    flow.Guid = Guid.NewGuid().ToString();
                    flow.JobID = job.JobID;
                    flow.FlowID = int.Parse(new DataAccess.Flow().GetList(string.Format("FlowOrder=2 and JobType='{0}'", job.JobType)).Tables[0].Rows[0]["FlowStatus"].ToString());
                    flow.SubmitDate = time;
                    flow.SubmitUser = PageBase.CommonObject.ManagerUserInfo.guid;
                    flow.Content = "现场交单.";
                    flow.IsDelete = false;
                    flow.Remark = string.Empty;
                    new DataAccess.FlowInfo().Add(flow);

                    if (job.JobType == "NA" || job.JobType == "RI" || job.JobType == "RM")
                    {
                        Entity.FlowInfo sFlow = new Entity.FlowInfo();
                        sFlow.Guid = Guid.NewGuid().ToString();
                        sFlow.JobID = sJob.JobID;
                        sFlow.FlowID = int.Parse(new DataAccess.Flow().GetList("FlowOrder=2 and JobType='SL'").Tables[0].Rows[0]["FlowStatus"].ToString());
                        sFlow.SubmitDate = flow.SubmitDate;
                        sFlow.SubmitUser = flow.SubmitUser;
                        sFlow.Content = flow.Content;
                        sFlow.IsDelete = false;
                        sFlow.Remark = string.Empty;
                        new DataAccess.FlowInfo().Add(sFlow);
                    }

                    //绑定文件袋
                    if (!string.IsNullOrEmpty(context.Request.Form["hBar"]))
                    {
                        new DataAccess.JobBar().BindFile(context.Request.Form["hBar"], job.JobID);
                        if (job.JobType == "NA" || job.JobType == "RI" || job.JobType == "RM")
                            new DataAccess.JobBar().BindFile(context.Request.Form["hBar"], sJob.JobID);
                    }
                }
                else
                {
                    job = new DataAccess.JobInfo().GetModel(jobID);
                    if (job.JobType == "SL")
                    {
                        job.Fee += new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["saleSelect"]).SellingPrice * int.Parse(context.Request.Form["txtNum"]);
                        new DataAccess.JobInfo().Update(job);
                    }
                    else if (job.JobType == "NA" || job.JobType == "RI" || job.JobType == "RM")
                    {
                        saleID = new DataAccess.SaleBinding().GetList(string.Format("JobID='{0}'", jobID)).Tables[0].Rows[0]["SaleID"].ToString();
                        sJob = new DataAccess.JobInfo().GetModel(saleID);
                        sJob.Fee += new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["saleSelect"]).SellingPrice * int.Parse(context.Request.Form["txtNum"]);
                        new DataAccess.JobInfo().Update(sJob);
                    }
                }
                

                //工单项信息
                int random = new Random().Next(1, 9999);
                switch (job.JobType)
                {
                    case "MD":
                        for (int i = 0; i < int.Parse(context.Request.Form["txtNum"]); i++)
                        {
                            Entity.ModifyList md = new Entity.ModifyList();
                            md.JobType = context.Request.Form["businessSelect"];
                            md.ListID = md.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (random + i).ToString().PadLeft(4, '0');
                            md.JobID = job.JobID;
                            md.CardType = new DataAccess.Para_JobType().GetModel(md.JobType).CardType;
                            md.IsChangeName = false;
                            md.IsDelete = false;
                            md.Remark = "现场交单.";
                            new DataAccess.ModifyList().Add(md);
                        }
                        break;
                    case "NA":
                        for (int i = 0; i < int.Parse(context.Request.Form["txtNum"]); i++)
                        {
                            Entity.NewlyAddedList na = new Entity.NewlyAddedList();
                            na.JobType = context.Request.Form["businessSelect"];
                            na.ListID = na.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (random + i).ToString().PadLeft(4, '0');
                            na.JobID = job.JobID;
                            na.CardType = new DataAccess.Para_JobType().GetModel(na.JobType).CardType;
                            na.CardholderIdentificationType = 1;
                            na.IsDelete = false;
                            na.Remark = "现场交单.";
                            new DataAccess.NewlyAddedList().Add(na);
                        }
                        Entity.SaleList naSl = new Entity.SaleList();
                        if (new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows.Count == 0)
                        {
                            naSl.JobType = "SL001";
                            naSl.ListID = naSl.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + random.ToString().PadLeft(4, '0');
                            naSl.JobID = saleID;
                            naSl.ProductType = context.Request.Form["saleSelect"];
                            naSl.Num = int.Parse(context.Request.Form["txtNum"]);
                            naSl.IsDelete = false;
                            naSl.Remark = "现场交单.";
                            new DataAccess.SaleList().Add(naSl);
                        }
                        else
                        {
                            naSl = new DataAccess.SaleList().GetModel(new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows[0]["ListID"].ToString());
                            naSl.Num += int.Parse(context.Request.Form["txtNum"]);
                            new DataAccess.SaleList().Update(naSl);
                        }
                        break;
                    case "RI":
                        for (int i = 0; i < int.Parse(context.Request.Form["txtNum"]); i++)
                        {
                            Entity.ReIssueList ri = new Entity.ReIssueList();
                            ri.JobType = context.Request.Form["businessSelect"];
                            ri.ListID = ri.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (random + i).ToString().PadLeft(4, '0');
                            ri.JobID = job.JobID;
                            ri.CardType = new DataAccess.Para_JobType().GetModel(ri.JobType).CardType;
                            ri.IsDelete = false;
                            ri.Remark = "现场交单.";
                            new DataAccess.ReIssueList().Add(ri);
                        }
                        Entity.SaleList riSl = new Entity.SaleList();
                        if (new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows.Count == 0)
                        {
                            riSl.JobType = "SL001";
                            riSl.ListID = riSl.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + random.ToString().PadLeft(4, '0');
                            riSl.JobID = saleID;
                            riSl.ProductType = context.Request.Form["saleSelect"];
                            riSl.Num = int.Parse(context.Request.Form["txtNum"]);
                            riSl.IsDelete = false;
                            riSl.Remark = "现场交单.";
                            new DataAccess.SaleList().Add(riSl);
                        }
                        else
                        {
                            riSl = new DataAccess.SaleList().GetModel(new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows[0]["ListID"].ToString());
                            riSl.Num += int.Parse(context.Request.Form["txtNum"]);
                            new DataAccess.SaleList().Update(riSl);
                        }
                        break;
                    case "RM":
                        for (int i = 0; i < int.Parse(context.Request.Form["txtNum"]); i++)
                        {
                            Entity.ReMakeList rm = new Entity.ReMakeList();
                            rm.JobType = context.Request.Form["businessSelect"];
                            rm.ListID = rm.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (random + i).ToString().PadLeft(4, '0');
                            rm.JobID = job.JobID;
                            rm.CardType = new DataAccess.Para_JobType().GetModel(rm.JobType).CardType;
                            rm.IsDelete = false;
                            rm.Remark = "现场交单.";
                            new DataAccess.ReMakeList().Add(rm);
                        }
                        Entity.SaleList rmSl = new Entity.SaleList();
                        if (new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows.Count == 0)
                        {
                            rmSl.JobType = "SL001";
                            rmSl.ListID = rmSl.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + random.ToString().PadLeft(4, '0');
                            rmSl.JobID = saleID;
                            rmSl.ProductType = context.Request.Form["saleSelect"];
                            rmSl.Num = int.Parse(context.Request.Form["txtNum"]);
                            rmSl.IsDelete = false;
                            rmSl.Remark = "现场交单.";
                            new DataAccess.SaleList().Add(rmSl);
                        }
                        else
                        {
                            rmSl = new DataAccess.SaleList().GetModel(new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows[0]["ListID"].ToString());
                            rmSl.Num += int.Parse(context.Request.Form["txtNum"]);
                            new DataAccess.SaleList().Update(rmSl);
                        }
                        break;
                    case "SL":
                        Entity.SaleList sl = new Entity.SaleList();
                        if (new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows.Count == 0)
                        {
                            sl.JobType = "SL001";
                            sl.ListID = sl.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + random.ToString().PadLeft(4, '0');
                            sl.JobID = job.JobID;
                            sl.ProductType = context.Request.Form["saleSelect"];
                            sl.Num = int.Parse(context.Request.Form["txtNum"]);
                            sl.IsDelete = false;
                            sl.Remark = "现场交单.";
                            sl.ManagerFlag = 0;
                            sl.ManagerUser = PageBase.CommonObject.ManagerUserInfo.guid;
                            sl.ManagerTime = DateTime.Now;
                            new DataAccess.SaleList().Add(sl);
                        }
                        else
                        {
                            sl = new DataAccess.SaleList().GetModel(new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and ProductType='{1}' and IsDelete=0", saleID, context.Request.Form["saleSelect"])).Tables[0].Rows[0]["ListID"].ToString());
                            sl.Num += int.Parse(context.Request.Form["txtNum"]);
                            new DataAccess.SaleList().Update(sl);
                        }
                        break;
                    case "UU":
                        for (int i = 0; i < int.Parse(context.Request.Form["txtNum"]); i++)
                        {
                            Entity.UpdateUnlockList uu = new Entity.UpdateUnlockList();
                            uu.JobType = context.Request.Form["businessSelect"];
                            uu.ListID = uu.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (random + i).ToString().PadLeft(4, '0');
                            uu.JobID = job.JobID;
                            uu.CardType = new DataAccess.Para_JobType().GetModel(uu.JobType).CardType;
                            uu.IsDelete = false;
                            uu.Remark = "现场交单.";
                            new DataAccess.UpdateUnlockList().Add(uu);
                        }
                        break;
                }
                try
                {
                    if (job.JobType != "UU" && job.JobType != "MD")
                    {
                        //减少显示库存
                        Entity.Stock_Commodity mCommodity = new DataAccess.Stock_Commodity().GetEntity(context.Request.Form["saleSelect"]);
                        mCommodity.StockDesplay -= int.Parse(context.Request.Form["txtNum"]);
                        if (mCommodity.StockDesplay < 0)
                        {
                            throw new Exception(string.Format("{0}{1}（{2}）库存不足，请更换库存充足的安全产品厂商或稍后再试！", mCommodity.AdditionalAttributes, mCommodity.CommodityName, mCommodity.CommodityType));
                        }
                        else
                            new DataAccess.Stock_Commodity().Update(mCommodity);
                    }
                    DataAccess.TranHelper.CommitTran();
                    DataAccess.TranHelper.BeginTran();
                    //处理列表信息
                    switch (job.JobType)
                    {
                        case "MD":
                            new DataAccess.MDDataAccess().InsertHandleList(job);
                            break;
                        case "NA":
                            new DataAccess.NADataAccess().InsertHandleList(job);
                            new DataAccess.SLDataAccess().InsertHandleList(sJob);
                            break;
                        case "RI":
                            new DataAccess.RIDataAccess().InsertHandleList(job);
                            new DataAccess.SLDataAccess().InsertHandleList(sJob);
                            break;
                        case "RM":
                            new DataAccess.RMDataAccess().InsertHandleList(job);
                            new DataAccess.SLDataAccess().InsertHandleList(sJob);
                            break;
                        case "SL":
                            new DataAccess.SLDataAccess().InsertHandleList(job);
                            break;
                        case "UU":
                            new DataAccess.UUDataAccess().InsertHandleList(job);
                            break;
                    }
                    DataAccess.TranHelper.CommitTran();
                    context.Response.Write(JsonConvert.SerializeObject(new Data("", job.JobID)));
                }
                catch (Exception ex)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new Data(ex.Message, "")));
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new Data(ex.Message, "")));
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
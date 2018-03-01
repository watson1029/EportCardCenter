using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// SLListSave 的摘要说明
    /// </summary>
    public class SLListSave : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                string commodity = context.Request.Form["hCommodityID"];
                int num = int.Parse(context.Request.Form["txtNum"]);
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "SaleList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.SaleList sl = new Entity.SaleList();
                    DataAccess.SaleList da = new DataAccess.SaleList();
                    DateTime time = DateTime.Now;

                    //判断是否已经存在选中安全产品类型的工单
                    if (da.GetList(string.Format("JobID='{0}' and IsDelete=0 and ProductType='{1}'", jobID, commodity)).Tables[0].Rows.Count > 0)
                    {
                        context.Response.Write("\n工单中已存在所选安全产品类型的工单项，请在原工单项中进行修改!");
                        return;
                    }

                    //工单缴费信息part1 - 更新为最新价格
                    Entity.JobInfo job = new DataAccess.JobInfo().GetModel(jobID);
                    DataTable feeDt = run.JobFeeDetal(job.JobID, "SaleList").Tables[0];
                    job.Fee = decimal.Parse(feeDt.Rows[0]["Fee"].ToString());

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        sl.JobType = "SL001";
                        sl.ListID = sl.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        sl.JobID = jobID;
                    }
                    else
                    {
                        sl = da.GetModel(listID);
                        //工单缴费信息part2 - 减去修改前的价格
                        job.Fee -= new DataAccess.Stock_Commodity().GetEntity(sl.ProductType).SellingPrice * sl.Num;
                    }
                    sl.ProductType = commodity;
                    sl.Num = num;
                    sl.IsDelete = false;
                    sl.Remark = "";
                    sl.ManagerFlag = 0;
                    sl.ManagerUser = PageBase.CommonObject.LoginUserInfo.companyId;
                    sl.ManagerTime = DateTime.Now;

                    //工单缴费信息part3 - 加上新的价格
                    job.Fee += new DataAccess.Stock_Commodity().GetEntity(sl.ProductType).SellingPrice * sl.Num;
                    if (job.Fee == 0)
                        job.FeeFlat = "无须缴费";
                    else
                        job.FeeFlat = "待缴费";

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.SLDataAccess().InsertListData(sl);
                    new DataAccess.JobInfo().Update(job);
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
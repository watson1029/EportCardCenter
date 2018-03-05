using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CardCenter.AutoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataAccess.RunProcedure().CloseList();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    try
                    {
                        result = DataAccess.PayHelper.IPaySearch(dr["JobID"].ToString());
                    }
                    catch (Exception ex)
                    {
                        new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:查询接口失败.{1}", dr["JobID"].ToString(), ex.ToString()));
                    }
                    bool IsSuccess = false;
                    if (result["status"] != null)
                    {
                        if (result["status"].Equals("Success"))
                            IsSuccess = true;
                    }
                    if (!IsSuccess)
                    {
                        //关闭工单
                        Entity.FlowInfo flow = new Entity.FlowInfo();
                        flow.Guid = Guid.NewGuid().ToString();
                        flow.JobID = dr["JobID"].ToString();
                        flow.FlowID = 18;
                        flow.SubmitDate = DateTime.Now;
                        flow.SubmitUser = "d8f752cf-a933-460e-8e35-065f11e61b02";
                        flow.Content = "超时未支付，系统自动关闭工单。";
                        flow.IsDelete = false;
                        try
                        {
                            if (!new DataAccess.FlowInfo().AddEx(flow))
                            {
                                new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:关闭工单失败.入库失败", flow.JobID));
                            }
                        }
                        catch (Exception ex)
                        {
                            new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:关闭工单失败.{1}", flow.JobID, ex.ToString()));
                        }
                        //恢复库存
                        DataTable dtSale = new DataAccess.SaleList().GetList(string.Format("JobID='{0}' and IsDelete=0", flow.JobID)).Tables[0];
                        foreach (DataRow drSale in dtSale.Rows)
                        {
                            Entity.SaleList mSale = new DataAccess.SaleList().DataRowToModel(drSale);
                            Entity.Stock_Commodity mCommodity = new DataAccess.Stock_Commodity().GetEntity(mSale.ProductType);
                            mCommodity.StockDesplay += mSale.Num;
                            try
                            {
                                if (!new DataAccess.Stock_Commodity().UpdateEx(mCommodity))
                                {
                                    new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:恢复库存失败.入库失败", flow.JobID));
                                }
                            }
                            catch (Exception ex)
                            {
                                new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:恢复库存失败.{1}", flow.JobID, ex.ToString()));
                            }
                        }
                    }
                    else
                    {
                        Entity.JobInfo job = new DataAccess.JobInfo().GetModel(dr["JobID"].ToString());
                        Entity.HandleList handle = new DataAccess.HandleList().GetFeeData(dr["JobID"].ToString());
                        if (job != null && handle != null)
                        {
                            //更新工单缴费信息
                            job.FeeFlat = "已缴费";
                            handle.IsChecked = true;
                            handle.Status = "已处理";
                            handle.OpeartionUser = job.CustomsCode;
                            handle.OpeartionTime = DateTime.ParseExact(result["lastUpdated"], "yyyyMMddHHmmss", null).AddHours(8);
                            handle.Remark = "网上支付";
                            try
                            {
                                if (!new DataAccess.JobInfo().UpdateEx(job) && new DataAccess.HandleList().UpdateEx(handle))
                                {
                                    new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:更新工单失败.入库失败", job.JobID));
                                }
                            }
                            catch (Exception ex)
                            {
                                new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:更新工单失败.{1}", job.JobID, ex.ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    new DataAccess.Sys_Log().AddLog(string.Format("Function:CloseJob.Main;Param:{0};ErrorMsg:未知错误.{1}", dr["JobID"].ToString(), ex.ToString()));
                }
            }
        }
    }
}

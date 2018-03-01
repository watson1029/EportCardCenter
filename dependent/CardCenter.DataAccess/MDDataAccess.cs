using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CardCenter.DataAccess
{
    public class MDDataAccess
    {
        public MDDataAccess()
        { }

        public void InsertHeadData(Entity.JobInfo job, List<Entity.FileList> fileList, Entity.FlowInfo flow)
        {
            DataAccess.JobInfo daJob = new JobInfo();
            if (daJob.Exists(job.JobID))
                daJob.Update(job);
            else
                daJob.Add(job);

            DataAccess.FileList daFile = new FileList();
            foreach (Entity.FileList file in fileList)
            {
                if (daFile.GetList("FileType='" + file.FileType + "' and JobID='" + file.JobID + "' and ListID='" + file.ListID + "'").Tables[0].Rows.Count == 0)
                    daFile.Add(file);
                else
                    daFile.Update(file);
            }

            new DataAccess.FlowInfo().Add(flow);
        }

        public void InsertListData(Entity.ModifyList md)
        {
            DataAccess.ModifyList daMD = new ModifyList();
            if (daMD.Exists(md.ListID))
                daMD.Update(md);
            else
                daMD.Add(md);
        }

        public void InsertHandleList(Entity.JobInfo job)
        {
            HandleList dal = new HandleList();
            dal.DeleteJobID(job.JobID);
            dal.InsertA01(job);
            dal.InsertA08(job);
            dal.InsertA07(job);
            dal.InsertA04(job);
            dal.InsertA06(job);
        }

        public void ChangeFlow(Entity.JobInfo job)
        {
            DataTable handle = new HandleList().GetList("JobID='" + job.JobID + "'").Tables[0];
            Entity.FlowInfo flowNow = new FlowInfo().DataRowToModel(new FlowInfo().GetList("JobID='" + job.JobID + "' and IsDelete=0 order by SubmitDate desc").Tables[0].Rows[0]);
            DataAccess.TranHelper.BeginTran();
            bool IsChange = false;
            switch (flowNow.FlowID)
            {
                case 7:
                    #region 当流程处于7（工单已受理）时
                    //是否资料已经确认
                    if (handle.Select("OpeartionID=11 and IsChecked=1").Length > 0)
                    {
                        bool isChange = new ModifyList().GetList("IsDelete=0 and IsChangeName=1 and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0 ? true : false;
                        //是否变更法人名或企业名
                        if (isChange)
                        {
                            //将流程从7修改成8
                            Entity.FlowInfo flowSP = new Entity.FlowInfo();
                            flowSP.Guid = Guid.NewGuid().ToString();
                            flowSP.JobID = job.JobID;
                            flowSP.FlowID = 8;
                            flowSP.SubmitDate = DateTime.Now;
                            flowSP.SubmitUser = handle.Select("OpeartionID=11 and IsChecked=1")[0]["OpeartionUser"].ToString();
                            flowSP.Content = handle.Select("OpeartionID=11 and IsChecked=1")[0]["Remark"].ToString();
                            flowSP.IsDelete = false;
                            new FlowInfo().Add(flowSP);
                            IsChange = true;
                            if ((bool)job.ExpressFlat)
                            {
                                //是否资料确认、收卡、制卡、快递
                                if (handle.Select("OpeartionID=11 and IsChecked=1").Length > 0 && handle.Select("FunctionID='A07' and IsChecked=1").Length > 0 && handle.Select("OpeartionID=14 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=10 and IsChecked=1").Length > 0)
                                {
                                    //将流程从8修改为6
                                    Entity.FlowInfo flow = new Entity.FlowInfo();
                                    flow.Guid = Guid.NewGuid().ToString();
                                    flow.JobID = job.JobID;
                                    flow.FlowID = 6;
                                    flow.SubmitDate = DateTime.Now;
                                    flow.SubmitUser = handle.Select("OpeartionID=10 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                    flow.Content = handle.Select("OpeartionID=10 and IsChecked=1")[0]["Remark"].ToString();
                                    flow.IsDelete = false;
                                    new FlowInfo().Add(flow);
                                    IsChange = true;
                                }
                            }
                            else
                            {
                                //是否资料确认、收卡、制卡
                                if (handle.Select("OpeartionID=11 and IsChecked=1").Length > 0 && handle.Select("FunctionID='A07' and IsChecked=1").Length > 0 && handle.Select("OpeartionID=14 and IsChecked=1").Length > 0)
                                {
                                    if (handle.Select("OpeartionID=9 and IsChecked=1").Length > 0)
                                    { 
                                        //将流程从8修改为5
                                        Entity.FlowInfo flow = new Entity.FlowInfo();
                                        flow.Guid = Guid.NewGuid().ToString();
                                        flow.JobID = job.JobID;
                                        flow.FlowID = 5;
                                        flow.SubmitDate = DateTime.Now;
                                        flow.SubmitUser = handle.Select("OpeartionID=9 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                        flow.Content = handle.Select("OpeartionID=9 and IsChecked=1")[0]["Remark"].ToString();
                                        flow.IsDelete = false;
                                        new FlowInfo().Add(flow);
                                        IsChange = true;
                                    }
                                    else
                                    {
                                        //将流程从8修改为11
                                        Entity.FlowInfo flow = new Entity.FlowInfo();
                                        flow.Guid = Guid.NewGuid().ToString();
                                        flow.JobID = job.JobID;
                                        flow.FlowID = 11;
                                        flow.SubmitDate = DateTime.Now;
                                        flow.SubmitUser = handle.Select("", "OpeartionTime desc")[0]["OpeartionUser"].ToString();
                                        flow.IsDelete = false;
                                        new FlowInfo().Add(flow);
                                        IsChange = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //将流程从7修改成9
                            Entity.FlowInfo flow = new Entity.FlowInfo();
                            flow.Guid = Guid.NewGuid().ToString();
                            flow.JobID = job.JobID;
                            flow.FlowID = 9;
                            flow.SubmitDate = DateTime.Now;
                            flow.SubmitUser = handle.Select("OpeartionID=11 and IsChecked=1")[0]["OpeartionUser"].ToString();
                            flow.Content = handle.Select("OpeartionID=11 and IsChecked=1")[0]["Remark"].ToString();
                            flow.IsDelete = false;
                            new FlowInfo().Add(flow);
                            IsChange = true;
                        }
                    }
                    #endregion
                    break;
                case 8:
                    #region 当流程处于8（资料已去确认）时
                    //是否快递领取
                    if ((bool)job.ExpressFlat)
                    {
                        //是否资料确认、收卡、制卡、快递
                        if (handle.Select("OpeartionID=11 and IsChecked=1").Length > 0 && handle.Select("FunctionID='A07' and IsChecked=1").Length > 0 && handle.Select("OpeartionID=14 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=10 and IsChecked=1").Length > 0)
                        {
                            //将流程从8修改为6
                            Entity.FlowInfo flow = new Entity.FlowInfo();
                            flow.Guid = Guid.NewGuid().ToString();
                            flow.JobID = job.JobID;
                            flow.FlowID = 6;
                            flow.SubmitDate = DateTime.Now;
                            flow.SubmitUser = handle.Select("OpeartionID=10 and IsChecked=1")[0]["OpeartionUser"].ToString();
                            flow.Content = handle.Select("OpeartionID=10 and IsChecked=1")[0]["Remark"].ToString();
                            flow.IsDelete = false;
                            new FlowInfo().Add(flow);
                            IsChange = true;
                        }
                    }
                    else
                    {
                        //是否资料确认、收卡、制卡
                        if (handle.Select("OpeartionID=11 and IsChecked=1").Length > 0 && handle.Select("FunctionID='A07' and IsChecked=1").Length > 0 && handle.Select("OpeartionID=14 and IsChecked=1").Length > 0)
                        {
                            if (handle.Select("OpeartionID=9 and IsChecked=1").Length > 0)
                            {
                                //将流程从8修改为5
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 5;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("OpeartionID=9 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                flow.Content = handle.Select("OpeartionID=9 and IsChecked=1")[0]["Remark"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                            else
                            {
                                //将流程从8修改为11
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 11;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("", "OpeartionTime desc")[0]["OpeartionUser"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                        }
                    }
                    #endregion
                    break;
                case 11:
                    #region 当流程处于11（等待现场领取）时
                    //是否已现场领取
                    if (handle.Select("OpeartionID=9 and IsChecked=1").Length > 0)
                    {
                        //将流程从11修改为5
                        Entity.FlowInfo flow = new Entity.FlowInfo();
                        flow.Guid = Guid.NewGuid().ToString();
                        flow.JobID = job.JobID;
                        flow.FlowID = 5;
                        flow.SubmitDate = DateTime.Now;
                        flow.SubmitUser = handle.Select("OpeartionID=9 and IsChecked=1")[0]["OpeartionUser"].ToString();
                        flow.Content = handle.Select("OpeartionID=9 and IsChecked=1")[0]["Remark"].ToString();
                        flow.IsDelete = false;
                        new FlowInfo().Add(flow);
                        IsChange = true;
                    }
                    #endregion
                    break;
            }
            try
            {
                DataAccess.TranHelper.CommitTran();
                if (IsChange)
                    DataAccess.CardCenterHelper.SendMessage(job.JobID);
            }
            catch (Exception ex)
            {
                throw new Exception("流程提交失败!" + ex.ToString());
            }
        }
    }
}

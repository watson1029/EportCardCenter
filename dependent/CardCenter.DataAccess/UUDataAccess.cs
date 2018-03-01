using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CardCenter.DataAccess
{
    public class UUDataAccess
    {
        public UUDataAccess()
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

        public void InsertListData(Entity.UpdateUnlockList uu)
        {
            DataAccess.UpdateUnlockList daUU = new UpdateUnlockList();
            if (daUU.Exists(uu.ListID))
                daUU.Update(uu);
            else
                daUU.Add(uu);
        }

        public void InsertHandleList(Entity.JobInfo job)
        {
            HandleList dal = new HandleList();
            dal.DeleteJobID(job.JobID);
            dal.InsertA01(job);
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
                case 10:
                    #region 当流程处于10（工单已受理）时
                    //是否快递领取
                    if ((bool)job.ExpressFlat)
                    {
                        //是否收卡、制卡、快递
                        if (handle.Select("FunctionID='A07' and IsChecked=1").Length > 0 && handle.Select("OpeartionID=16 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=10 and IsChecked=1").Length > 0)
                        {
                            //将流程从10修改为6
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
                        //是否收卡、制卡
                        if (handle.Select("FunctionID='A07' and IsChecked=1").Length > 0 && handle.Select("OpeartionID=16 and IsChecked=1").Length > 0)
                        {
                            //是否已现场领取
                            if (handle.Select("OpeartionID=9 and IsChecked=1").Length > 0)
                            {
                                //将流程从2修改为5
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
                                //将流程从10修改为11
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

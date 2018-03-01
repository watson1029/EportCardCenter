using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CardCenter.DataAccess
{
    public class NADataAccess
    {
        public NADataAccess()
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

        public void InsertListData(Entity.NewlyAddedList na)
        {
            DataAccess.NewlyAddedList daNA = new NewlyAddedList();
            if (daNA.Exists(na.ListID))
                daNA.Update(na);
            else
                daNA.Add(na);
        }

        public void InsertListData(Entity.NewlyAddedList na, Entity.NewlyAddedListFR fr)
        {
            DataAccess.NewlyAddedList daNA = new NewlyAddedList();
            DataAccess.NewlyAddedListFR daFR = new NewlyAddedListFR();
            if (daNA.Exists(na.ListID))
            {
                daNA.Update(na);
                daFR.Update(fr);
            }
            else
            {
                daNA.Add(na);
                daFR.Add(fr);
            }
        }

        public void InsertHandleList(Entity.JobInfo job)
        {
            HandleList dal = new HandleList();
            dal.DeleteJobID(job.JobID);
            dal.InsertA01(job);
            dal.InsertA02(job);
            dal.InsertA03(job);
            dal.InsertA04(job);
            //dal.InsertA05(job);
            //dal.InsertA06(job);
        }

        public void ChangeFlow(Entity.JobInfo job)
        {
            DataTable handle = new HandleList().GetList("JobID='" + job.JobID + "'").Tables[0];
            Entity.FlowInfo flowNow = new FlowInfo().DataRowToModel(new FlowInfo().GetList("JobID='" + job.JobID + "' and IsDelete=0 order by SubmitDate desc").Tables[0].Rows[0]);
            DataAccess.TranHelper.BeginTran();
            bool IsChange = false;
            switch (flowNow.FlowID)
            {
                case 2:
                    #region 当前流程处于2（工单已受理，请缴费）时
                    bool haveFR = new NewlyAddedList().GetList("IsDelete=0 and JobType='NA001' and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0 ? true : false;
                    bool haveQT = new NewlyAddedList().GetList("IsDelete=0 and JobType<>'NA001' and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0 ? true : false;
                    //是否有法人卡
                    if (haveFR)
                    {
                        bool IsGZ = true;
                        if (job.IsOnline)
                        {
                            string shtyxydm = new NewlyAddedListFR().GetList("ListID='" + new NewlyAddedList().GetList("IsDelete=0 and JobType='NA001' and JobID='" + job.JobID + "'").Tables[0].Rows[0]["ListID"] + "'").Tables[0].Rows[0]["SHTYXYDM_QS"].ToString().Substring(2, 4);
                            if (shtyxydm != "4401" && shtyxydm != "4400")
                                IsGZ = false;
                        }
                        //是否非广州市属企业
                        if (!IsGZ)
                        {
                            //是否已录入前三数据
                            if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0)
                            {
                                //将流程从2修改为3
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 3;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("OpeartionID=3 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                flow.Content = handle.Select("OpeartionID=3 and IsChecked=1")[0]["Remark"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                        }
                        else
                        {
                            //是否有操作员卡
                            if (haveQT)
                            {
                                //是否录入前三、后三、制法人卡、制操作员卡
                                if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=4 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=6 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=7 and IsChecked=1").Length > 0)
                                {
                                    //将流程从2修改为9
                                    Entity.FlowInfo flow = new Entity.FlowInfo();
                                    flow.Guid = Guid.NewGuid().ToString();
                                    flow.JobID = job.JobID;
                                    flow.FlowID = 9;
                                    flow.SubmitDate = DateTime.Now;
                                    flow.SubmitUser = handle.Select("OpeartionID=6 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                    flow.Content = handle.Select("OpeartionID=6 and IsChecked=1")[0]["Remark"].ToString();
                                    flow.IsDelete = false;
                                    new FlowInfo().Add(flow);
                                    IsChange = true;
                                }
                            }
                            else
                            {
                                //是否录入前三、后三、制法人卡
                                if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=4 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=6 and IsChecked=1").Length > 0)
                                {
                                    //将流程从2修改为9
                                    Entity.FlowInfo flow = new Entity.FlowInfo();
                                    flow.Guid = Guid.NewGuid().ToString();
                                    flow.JobID = job.JobID;
                                    flow.FlowID = 9;
                                    flow.SubmitDate = DateTime.Now;
                                    flow.SubmitUser = handle.Select("OpeartionID=6 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                    flow.Content = handle.Select("OpeartionID=6 and IsChecked=1")[0]["Remark"].ToString();
                                    flow.IsDelete = false;
                                    new FlowInfo().Add(flow);
                                    IsChange = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        //是否录入制操作员卡
                        if (handle.Select("OpeartionID=7 and IsChecked=1").Length > 0)
                        {
                            //将流程从2修改为9
                            Entity.FlowInfo flow = new Entity.FlowInfo();
                            flow.Guid = Guid.NewGuid().ToString();
                            flow.JobID = job.JobID;
                            flow.FlowID = 9;
                            flow.SubmitDate = DateTime.Now;
                            flow.SubmitUser = handle.Select("OpeartionID=7 and IsChecked=1")[0]["OpeartionUser"].ToString();
                            flow.Content = handle.Select("OpeartionID=7 and IsChecked=1")[0]["Remark"].ToString();
                            flow.IsDelete = false;
                            new FlowInfo().Add(flow);
                            IsChange = true;
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region 当前流程处于3（等待审批确认）时
                    //是否审批确认
                    if (handle.Select("OpeartionID=5 and IsChecked=1").Length > 0)
                    {
                        //将流程从3修改为4
                        Entity.FlowInfo flowSP = new Entity.FlowInfo();
                        flowSP.Guid = Guid.NewGuid().ToString();
                        flowSP.JobID = job.JobID;
                        flowSP.FlowID = 4;
                        flowSP.SubmitDate = DateTime.Now;
                        flowSP.SubmitUser = handle.Select("OpeartionID=5 and IsChecked=1")[0]["OpeartionUser"].ToString();
                        flowSP.Content = handle.Select("OpeartionID=5 and IsChecked=1")[0]["Remark"].ToString();
                        flowSP.IsDelete = false;
                        new FlowInfo().Add(flowSP);
                        IsChange = true;
                        bool QT = new NewlyAddedList().GetList("IsDelete=0 and JobType<>'NA001' and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0 ? true : false;
                        //是否有操作员卡
                        if (QT)
                        {
                            //是否录入前三、后三、制法人卡、制操作员卡
                            if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=4 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=6 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=7 and IsChecked=1").Length > 0)
                            {
                                //将流程从2修改为9
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 9;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("OpeartionID=6 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                flow.Content = handle.Select("OpeartionID=6 and IsChecked=1")[0]["Remark"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                        }
                        else
                        {
                            //是否录入前三、后三、制法人卡
                            if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=4 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=6 and IsChecked=1").Length > 0)
                            {
                                //将流程从2修改为9
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 9;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("OpeartionID=6 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                flow.Content = handle.Select("OpeartionID=6 and IsChecked=1")[0]["Remark"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                        }
                    }
                    #endregion
                    break;
                case 4:
                    #region 当前流程处于4（审批确认，工单处理中）时
                    //是否审批确认
                    if (handle.Select("OpeartionID=5 and IsChecked=1").Length > 0)
                    {
                        bool QT = new NewlyAddedList().GetList("IsDelete=0 and JobType<>'NA001' and JobID='" + job.JobID + "'").Tables[0].Rows.Count > 0 ? true : false;
                        //是否有操作员卡
                        if (QT)
                        {
                            //是否录入前三、后三、制法人卡、制操作员卡
                            if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=4 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=6 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=7 and IsChecked=1").Length > 0)
                            {
                                //将流程从2修改为9
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 9;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("OpeartionID=6 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                flow.Content = handle.Select("OpeartionID=6 and IsChecked=1")[0]["Remark"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                        }
                        else
                        {
                            //是否录入前三、后三、制法人卡
                            if (handle.Select("OpeartionID=3 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=4 and IsChecked=1").Length > 0 && handle.Select("OpeartionID=6 and IsChecked=1").Length > 0)
                            {
                                //将流程从2修改为9
                                Entity.FlowInfo flow = new Entity.FlowInfo();
                                flow.Guid = Guid.NewGuid().ToString();
                                flow.JobID = job.JobID;
                                flow.FlowID = 9;
                                flow.SubmitDate = DateTime.Now;
                                flow.SubmitUser = handle.Select("OpeartionID=6 and IsChecked=1")[0]["OpeartionUser"].ToString();
                                flow.Content = handle.Select("OpeartionID=6 and IsChecked=1")[0]["Remark"].ToString();
                                flow.IsDelete = false;
                                new FlowInfo().Add(flow);
                                IsChange = true;
                            }
                        }
                    }
                    else
                    {
                        //将流程从4修改为3
                        Entity.FlowInfo flow = new Entity.FlowInfo();
                        flow.Guid = Guid.NewGuid().ToString();
                        flow.JobID = job.JobID;
                        flow.FlowID = 3;
                        flow.SubmitDate = DateTime.Now;
                        flow.SubmitUser = handle.Select("OpeartionID=5 and IsChecked=0")[0]["OpeartionUser"].ToString();
                        flow.Content = handle.Select("OpeartionID=5 and IsChecked=0")[0]["Remark"].ToString();
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
                if(IsChange)
                    DataAccess.CardCenterHelper.SendMessage(job.JobID);
            }
            catch (Exception ex)
            {
                throw new Exception("流程提交失败!" + ex.ToString());
            }
        }
    }
}

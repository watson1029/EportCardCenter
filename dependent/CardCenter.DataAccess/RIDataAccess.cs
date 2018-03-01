using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CardCenter.DataAccess
{
    public class RIDataAccess
    {
        public RIDataAccess()
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

        public void InsertListData(Entity.ReIssueList ri)
        {
            DataAccess.ReIssueList daRI = new ReIssueList();
            if (daRI.Exists(ri.ListID))
                daRI.Update(ri);
            else
                daRI.Add(ri);
        }

        public void InsertHandleList(Entity.JobInfo job)
        {
            HandleList dal = new HandleList();
            dal.DeleteJobID(job.JobID);
            dal.InsertA01(job);
            //dal.InsertA05(job);
            dal.InsertA04(job);
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
                    #region 当流程处于2（工单已受理）时
                    //是否补办卡
                    if (handle.Select("OpeartionID=15 and IsChecked=1").Length > 0)
                    {
                        //将流程从2修改为9
                        Entity.FlowInfo flow = new Entity.FlowInfo();
                        flow.Guid = Guid.NewGuid().ToString();
                        flow.JobID = job.JobID;
                        flow.FlowID = 9;
                        flow.SubmitDate = DateTime.Now;
                        flow.SubmitUser = handle.Select("OpeartionID=15 and IsChecked=1")[0]["OpeartionUser"].ToString();
                        flow.Content = handle.Select("OpeartionID=15 and IsChecked=1")[0]["Remark"].ToString();
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

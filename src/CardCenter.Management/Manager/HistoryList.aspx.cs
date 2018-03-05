using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager
{
    public partial class HistoryList : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataAccess.Para_JobType().GetList("JobTypeParent is NULL");
                jobSelect.Items.Add(new ListItem("--请选择业务类型--", ""));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    jobSelect.Items.Add(new ListItem(dr["JobName"].ToString(), dr["JobTypeID"].ToString()));
                }
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        private void DataBind()
        {
            string where = string.Empty;
            if (!string.IsNullOrEmpty(jobID.Value.Trim()))
            {
                where += string.Format("and JobInfo.JobID like '%{0}%' ", jobID.Value.Trim());
            }
            if (!string.IsNullOrEmpty(companyName.Value.Trim()))
            {
                where += string.Format("and JobInfo.EnterpriseName like '%{0}%' ", companyName.Value.Trim());
            }
            if (!string.IsNullOrEmpty(jobSelect.Value))
            {
                where += string.Format("and JobInfo.JobType='{0}'", jobSelect.Value);
            }
            DataAccess.RunProcedure pro = new DataAccess.RunProcedure();
            //repeater.DataSource = pro.ManagerList(CardPrinting.PageBase.CommonObject.ManagerUserInfo.department.ToString());
            repeater.DataSource = pro.HistoryList(where);
            repeater.DataBind();
        }

        public string BindEdit(string jobID, string jobType)
        {
            string url = string.Empty;
            if (jobType != "UU" && jobType != "MD" && PageBase.CommonObject.ManagerUserInfo.department != 1)
                return "";
            else
            {
                url = "View.aspx?jobID=" + jobID + "&jobType=" + jobType + "&type=edit";
                return "&nbsp;&nbsp;<a href='" + url + "' target='_blank'>处理</a>";
            }
        }
    }
}